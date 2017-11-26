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
    public partial class Usuarios : System.Web.UI.Page
    {
        Logic.GestionAccesoLogic _GestionAccesoLogic = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

                this.Master.LimpiarMensajes();

                if (Session["usuario_idUsuario"] == null || Session["usuario_idUsuario"].ToString() == "")
                    Response.Redirect("index.aspx", true);

                if (!Page.IsPostBack)
                {
                    llenaGridActor(null, null, null);
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                llenaGridActor(null, txtNombre.Text, DropEstatus.SelectedValue);
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
                limpiar();
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void LinkAddUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("DetalleUsuarios.aspx");
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void GridUsuariosAdm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridUsuariosAdm.PageIndex = e.NewPageIndex;
                llenaGridActor(null, txtNombre.Text, DropEstatus.SelectedValue);
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void GridUsuariosAdm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Modificar")
                {
                    int idUsuario = Convert.ToInt32(GridUsuariosAdm.DataKeys[System.Convert.ToInt32(e.CommandArgument)].Values["idUsuario"].ToString());
                    Response.Redirect("DetalleUsuario.aspx?idUsuario=" + idUsuario.ToString());
                    return;
                } 
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void BtnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }




        #region<METODOS>

        protected void llenaGridActor(string idActor, string NomActor, string idEstatus)
        {
            _GestionAccesoLogic = new Logic.GestionAccesoLogic();

            try
            {
                Entity.GestionAccesoEntity.UsuarioEntity obj = new Entity.GestionAccesoEntity.UsuarioEntity();
                obj.idEstatus = (idEstatus == "-1" || idEstatus == null) ? (int?)null : Convert.ToInt32(idEstatus);
                obj.Nombre = (string.IsNullOrEmpty(NomActor)) ? null : NomActor;


                GridUsuariosAdm.DataSource = _GestionAccesoLogic.ObtenerUsuarioLogic(obj);
                GridUsuariosAdm.DataBind();
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        protected void limpiar()
        {
            try
            {
                txtNombre.Text = "";
                DropEstatus.SelectedValue = "0";

                llenaGridActor(null, null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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


        #endregion
    }
}