using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OPTIMA.Helper;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.IO;

namespace OPTIMA
{
    public partial class CrearEditarMaterial : System.Web.UI.Page
    {
        Logic.MaterialesLogic _GestionInventarioLogic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

                this.Master.LimpiarMensajes();

                //if (Session["usuario_nombre"] == null || Session["usuario_nombre"].ToString() == "")
                //    Response.Redirect("index.aspx", true);

                if (!Page.IsPostBack)
                {

                    string id = Request.QueryString["id"] != null || !string.IsNullOrEmpty(Request.QueryString["id"]) ? Request.QueryString["id"].ToString() : (string)null;
                    HideInsertEdit.Value = id;



                    if (id == "0" || string.IsNullOrEmpty(id))
                    {
                        id = null;
                        HideInsertEdit.Value = id;

                    }
                    else if (!string.IsNullOrEmpty(id))
                    {

                        HideInsertEdit.Value = id;
                        int? idMaterial = Convert.ToInt16(id);
                        List<Entity.InventarioEntity.MaterialEntity> objMateriales = new List<Entity.InventarioEntity.MaterialEntity>();
                        _GestionInventarioLogic = new Logic.MaterialesLogic();

                        Entity.InventarioEntity.MaterialEntity obj = new Entity.InventarioEntity.MaterialEntity();
                        obj.id = idMaterial;

                        objMateriales = _GestionInventarioLogic.ObtenerMateriales(obj);
                        if (objMateriales.Count > 0)
                        {
                            foreach (var item in objMateriales)
                            {
                                txtNombre.Text = item.Nombre.ToString();
                                txtCantidad.Text = item.cantidad.ToString();
                                txtCodigo.Text = item.Codigo.ToString();
                                DropEstatus.SelectedValue = item.Estatus.ToString();
                                DropTipo.SelectedValue = item.idTipo.ToString();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }

        }



        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                CleanControl(this.Controls);
                Response.Redirect("CrearEditarInventario.aspx", true);
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }


        protected void BtnAtras_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Inventario.aspx", true);
            }
            catch (Exception)
            {

                throw;
            }
        }






        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<Entity.InventarioEntity.MaterialEntity> objMateriales = new List<Entity.InventarioEntity.MaterialEntity>();
            _GestionInventarioLogic = new Logic.MaterialesLogic();


            var validar = string.Empty;
            string msg = string.Empty;
            string error = string.Empty;
            int? idMaterial = null;
            int idinsertado = 0;
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    error = "El campo Nombre no puede estar vacio <br>";
                }
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    error = "El campo Codigo no puede estar vacio <br>";
                }
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    error = "El campo Cantidad no puede estar vacio <br>";
                }
                if (DropTipo.SelectedValue == "-1")
                {
                    error = "Debe seleccionar un Tipo <br>";
                }
                if (DropEstatus.SelectedValue == "-1")
                {
                    error = "Debe seleccionar un Estatus <br>";
                }
                if (!string.IsNullOrEmpty(error))
                {
                    // muestra lo que alamacena error 
                    return;

                }


                if (HideInsertEdit.Value == null || HideInsertEdit.Value == "")
                {
                    idMaterial = null;
                }
                else
                {
                    idMaterial = Convert.ToInt16(HideInsertEdit.Value);
                }


                Entity.InventarioEntity.MaterialEntity obj = new Entity.InventarioEntity.MaterialEntity();
                obj.id = idMaterial;
                obj.Nombre = txtNombre.Text.ToUpper();
                obj.Estatus = DropEstatus.SelectedValue;
                obj.idTipo = Convert.ToInt16(DropTipo.SelectedValue);
                obj.cantidad = Convert.ToInt32(txtCantidad.Text);
                obj.Codigo = (txtCodigo.Text).ToUpper();
                obj.idUsuarioCambio = 1;

                validar = validadExistente(txtNombre.Text, txtCodigo.Text, idMaterial);

                if (string.IsNullOrEmpty(validar))
                {

                    idinsertado = _GestionInventarioLogic.InsertUpdateMateriales(obj);
                }
                else
                {
                    msg = validar;
                    return;
                }

                if (idinsertado < 1)
                {
                    msg = "Error al realizar la operación comuniquese con el administrador de sistema";

                }
                else
                {
                    Response.Redirect("CrearEditarInventario.aspx?id=" + idinsertado.ToString());
                }

            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        #region<metodos>

        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).SelectedValue = "0";
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }

        public string validadExistente(string nombre, string codigo, int? idmat)
        {
            string respuesta = string.Empty;
            Entity.InventarioEntity.MaterialEntity obj1 = new Entity.InventarioEntity.MaterialEntity();
            List<Entity.InventarioEntity.MaterialEntity> objMatteriales = new List<Entity.InventarioEntity.MaterialEntity>();
            try
            {
                obj1.id = null;
                objMatteriales = _GestionInventarioLogic.ObtenerMateriales(obj1);

                foreach (var item in objMatteriales)
                {
                    if (item.Nombre == nombre || item.Codigo == codigo)
                    {
                        if(item.id == idmat)
                        {

                        }
                        else
                        {
                            respuesta = "Nombre o codigo existente, por favor vefique e intente nuevamente";
                        }
                        
                    }
                }

            }
            catch (Exception es)
            {

                throw es;
            }
            return respuesta;

        }

        #endregion



    }
}