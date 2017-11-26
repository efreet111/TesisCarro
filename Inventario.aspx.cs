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
    public partial class Inventario : System.Web.UI.Page
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
                    llenaGridMateriales(null, null, null, "10");
                    llenaGridPinturas(null, null, null, "9");
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                llenaGridMateriales( string.IsNullOrEmpty(txtCodigo.Text) ? null : (txtCodigo.Text),
                                       string.IsNullOrEmpty(txtNombre.Text) ? null : (txtNombre.Text),
                                        DropEstatus.SelectedValue == "-1" ? null : (DropEstatus.SelectedValue),
                                        "10");

                llenaGridPinturas( string.IsNullOrEmpty(txtCodigo.Text) ? null : (txtCodigo.Text),
                                       string.IsNullOrEmpty(txtNombre.Text) ? null : (txtNombre.Text),
                                        DropEstatus.SelectedValue == "-1" ? null : (DropEstatus.SelectedValue),
                                        "9");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
               CleanControl(this.Controls);
               Response.Redirect("Inventario.aspx", true);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void LinkAddPerfil_Click(object sender, EventArgs e)
        {

        }

        protected void GridMateriales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Modificar")
                {
                    int id= Convert.ToInt32(GridMateriales.DataKeys[System.Convert.ToInt32(e.CommandArgument)].Values["id"].ToString());
                    Response.Redirect("CrearEditarInventario.aspx?id=" + id.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void GridMateriales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                GridMateriales.PageIndex = e.NewPageIndex;
                llenaGridMateriales(
                                       string.IsNullOrEmpty(txtCodigo.Text) ? null : (txtCodigo.Text),
                                       string.IsNullOrEmpty(txtNombre.Text) ? null : (txtNombre.Text),
                                        DropEstatus.SelectedValue == "-1" ? null : (DropEstatus.SelectedValue),
                                        "10"
                                       );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void GridPinturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Modificar")
                {
                    int id = Convert.ToInt32(GridMateriales.DataKeys[System.Convert.ToInt32(e.CommandArgument)].Values["id"].ToString());
                    Response.Redirect("DetalleMaterial.aspx?id=" + id.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void GridPinturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                GridPinturas.PageIndex = e.NewPageIndex;
                llenaGridPinturas(
                                       string.IsNullOrEmpty(txtCodigo.Text) ? null : (txtCodigo.Text),
                                       string.IsNullOrEmpty(txtNombre.Text) ? null : (txtNombre.Text),
                                        DropEstatus.SelectedValue == "-1" ? null : (DropEstatus.SelectedValue),
                                        "10"
                                       );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region<metodos>
        protected void llenaDropUsuarios(DropDownList pDrop, List<Entity.GestionAccesoEntity.UsuarioEntity> plista)
        {
            System.Web.UI.WebControls.ListItem lstControl = null;

            try
            {
                pDrop.Items.Clear();
                lstControl = new System.Web.UI.WebControls.ListItem("Seleccione...", "0");
                pDrop.Items.Add(lstControl);

                plista = plista.OrderBy(p => p.Nombre).ToList();
                if (plista.Count > 0)
                {
                    foreach (Entity.GestionAccesoEntity.UsuarioEntity objB in plista)
                    {
                        lstControl = new System.Web.UI.WebControls.ListItem(objB.Nombre, objB.idUsuario.ToString());
                        pDrop.Items.Add(lstControl);
                    }
                }

            }
            catch (Exception er)
            {
                throw er;
            }
        }

        protected void llenaGridMateriales(string Codigo, string Nombre, string Estatus, string idTipo)
        {
            _GestionInventarioLogic = new Logic.MaterialesLogic();

            try
            {
                Entity.InventarioEntity.MaterialEntity obj = new Entity.InventarioEntity.MaterialEntity();
                obj.Codigo = (string.IsNullOrEmpty(Codigo)) ? null : Codigo;
                obj.Estatus = (string.IsNullOrEmpty(Estatus)) ? null : Estatus;
                obj.Nombre = (string.IsNullOrEmpty(Nombre)) ? null : Nombre;
                obj.idTipo = (idTipo == "-1" || idTipo == null) ? (int?)null : Convert.ToInt32(idTipo);
                GridMateriales.DataSource = _GestionInventarioLogic.ObtenerMateriales(obj);
                GridMateriales.DataBind();
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        protected void llenaGridPinturas(string Codigo, string Nombre, string Estatus, string idTipo)
        {
            _GestionInventarioLogic = new Logic.MaterialesLogic();

            try
            {
                Entity.InventarioEntity.MaterialEntity obj = new Entity.InventarioEntity.MaterialEntity();
                obj.Codigo = (string.IsNullOrEmpty(Codigo)) ? null : Codigo;
                obj.Estatus = (string.IsNullOrEmpty(Estatus)) ? null : Estatus;
                obj.Nombre = (string.IsNullOrEmpty(Nombre)) ? null : Nombre;
                obj.idTipo = (idTipo == "-1" || idTipo == null) ? (int?)null : Convert.ToInt32(idTipo);
                GridPinturas.DataSource = _GestionInventarioLogic.ObtenerMateriales(obj);
                GridPinturas.DataBind();
            }
            catch (Exception er)
            {
                throw er;
            }
        }


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


        #endregion

        protected void imagebut_Command(object sender, CommandEventArgs e)
        {

        }

        protected void LinkAddInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEditarInventario.aspx");
        }

     



    }
}