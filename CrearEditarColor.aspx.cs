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
    public partial class CrearEditarPintura : System.Web.UI.Page
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

                    string id = Request.QueryString["idColor"] != null || !string.IsNullOrEmpty(Request.QueryString["idColor"]) ? Request.QueryString["idColor"].ToString() : (string)null;
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
                        List<Entity.InventarioEntity.coloresEntity> objColores = new List<Entity.InventarioEntity.coloresEntity>();
                        _GestionInventarioLogic = new Logic.MaterialesLogic();

                        Entity.InventarioEntity.coloresEntity obj = new Entity.InventarioEntity.coloresEntity();
                        obj.idColor = idMaterial;

                        objColores = _GestionInventarioLogic.ObtenerColores(obj);
                        if (objColores.Count > 0)
                        {
                            foreach (var item in objColores)
                            {
                                txtNombre.Text = item.Nombre.ToString();
                                txtCodPaleta.Text = item.codigoPaleta.ToString();
                                txtCodigo.Text = item.codigo.ToString();
                                DropEstatus.SelectedValue = item.Estatus.ToString();
                                txtAmarillo.Text = item.Amarillo.ToString();
                                txtAzul.Text = item.Azul.ToString();
                                txtBlanco.Text = item.Blanco.ToString();
                                txtCian.Text = item.Cian.ToString();
                                txtDorado.Text = item.Dorado.ToString();
                                txtMagenta.Text = item.Magenta.ToString();
                                txtNegro.Text = item.Negro.ToString();
                                txtPlateado.Text = item.Plateado.ToString();
                                txtRojo.Text = item.Rojo.ToString();
                                txtVerde.Text = item.Verde.ToString();
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

        protected void BtnAtras_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Pintura.aspx", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                CleanControl(this.Controls);
                Response.Redirect("CrearEditarColor.aspx", true);
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<Entity.InventarioEntity.coloresEntity> objMateriales = new List<Entity.InventarioEntity.coloresEntity>();
            _GestionInventarioLogic = new Logic.MaterialesLogic();


            var validar = string.Empty;
            string msg = string.Empty;
            string error = string.Empty;
            int? idColor = null;
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
                    idColor = null;
                }
                else
                {
                    idColor = Convert.ToInt16(HideInsertEdit.Value);
                }

                if(txtAmarillo.Text == "")
                {
                    txtAmarillo.Text = "0";
                }
                if(txtAzul.Text == "")
                {
                    txtAzul.Text = "0";
                }
                if (txtCian.Text == "")
                {
                    txtCian.Text = "0";
                }
                if (txtMagenta.Text == "")
                {
                    txtMagenta.Text = "0";
                }
                if (txtNegro.Text == "")
                {
                    txtNegro.Text = "0";
                }
                if (txtPlateado.Text == "")
                {
                    txtPlateado.Text = "0";
                }
                if (txtRojo.Text == "")
                {
                    txtRojo.Text = "0";
                }
                if (txtVerde.Text == "")
                {
                    txtVerde.Text = "0";
                }
    

                Entity.InventarioEntity.coloresEntity obj = new Entity.InventarioEntity.coloresEntity();
                obj.idColor = idColor;
                obj.Nombre = txtNombre.Text.ToUpper();
                obj.Estatus = DropEstatus.SelectedValue;
                obj.codigo = (txtCodigo.Text).ToUpper();
                obj.codigoPaleta = (txtCodPaleta.Text).ToUpper();
                obj.idUsuarioCambio = 1;
                obj.Amarillo = Convert.ToInt32(txtAmarillo.Text);
                obj.Azul = Convert.ToInt32(txtAzul.Text);
                obj.Blanco = Convert.ToInt32(txtBlanco.Text);
                obj.Cian = Convert.ToInt32(txtCian.Text);
                obj.Dorado = Convert.ToInt32(txtDorado.Text);
                obj.Magenta = Convert.ToInt32(txtMagenta.Text);
                obj.Negro = Convert.ToInt32(txtNegro.Text);
                obj.Plateado = Convert.ToInt32(txtPlateado.Text);
                obj.Rojo = Convert.ToInt32(txtRojo.Text);
                obj.Verde =  Convert.ToInt32(txtVerde.Text);


                validar = validadExistente(txtNombre.Text, txtCodigo.Text, txtCodPaleta.Text ,idColor);

                if (string.IsNullOrEmpty(validar))
                {

                    idinsertado = _GestionInventarioLogic.InsertUpdateColores(obj);
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
                    Response.Redirect("CrearEditarColor.aspx?idcolor=" + idinsertado.ToString());
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

        public string validadExistente(string nombre, string codigo,string codigoPaleta , int? idColor)
        {
            string respuesta = string.Empty;
            Entity.InventarioEntity.coloresEntity obj1 = new Entity.InventarioEntity.coloresEntity();
            List<Entity.InventarioEntity.coloresEntity> objcolor = new List<Entity.InventarioEntity.coloresEntity>();
            try
            {
                obj1.idColor = null;
                objcolor = _GestionInventarioLogic.ObtenerColores(obj1);

                foreach (var item in objcolor)
                {
                    if (item.Nombre == nombre || item.codigo == codigo)
                    {
                        if (item.idColor == idColor)
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