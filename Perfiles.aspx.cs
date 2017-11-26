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
    public partial class Perfiles : System.Web.UI.Page
    {
        Logic.GestionAccesoLogic _GestionAccesoLogic = null;



        protected void Page_Load(object sender, EventArgs e)
        {
            _GestionAccesoLogic = new Logic.GestionAccesoLogic();

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

                this.Master.LimpiarMensajes();

                if (Session["usuario_idUsuario"] == null || Session["usuario_idUsuario"].ToString() == "")
                    Response.Redirect("index.aspx", true);

                if (!Page.IsPostBack)
                {
                    llenaDropPerfil(DropPerfil, _GestionAccesoLogic.ObtenerPerfilLogic(new Entity.GestionAccesoEntity.PerfilEntity { Activo = true }));

                    llenaGridPerfil(null, null);
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.Master.MensajeError = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }

        protected void GridPerfil_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Modificar")
                {
                    int idPerfil = Convert.ToInt32(GridPerfil.DataKeys[System.Convert.ToInt32(e.CommandArgument)].Values["idPerfil"].ToString());
                    Response.Redirect("DetallePerfiles.aspx?idPerfil=" + idPerfil.ToString());
                    return;
                } 
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.Master.MensajeError = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }

        protected void GridPerfil_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridPerfil.PageIndex = e.NewPageIndex;
                llenaGridPerfil(DropPerfil.SelectedValue, DropEstatus.SelectedValue);
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.Master.MensajeError = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }

        protected void LinkAddPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("DetallePerfiles.aspx");
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.Master.MensajeError = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
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
                this.Master.MensajeError = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                llenaGridPerfil(DropPerfil.SelectedValue, DropEstatus.SelectedValue);
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.Master.MensajeError = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }

        protected void imagebut_Command(object sender, CommandEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.Master.MensajeError = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }



        #region<METODOS>

        protected void llenaGridPerfil(string idPerfil, string Activo)
        {
            _GestionAccesoLogic = new Logic.GestionAccesoLogic();

            try
            {
                Entity.GestionAccesoEntity.PerfilEntity obj = new Entity.GestionAccesoEntity.PerfilEntity();
                obj.Activo = (Activo == "-1" || Activo == null) ? (bool?)null : Convert.ToBoolean(Convert.ToInt32(Activo));
                obj.idPerfil = (idPerfil == "-1" || idPerfil == null) ? (int?)null : Convert.ToInt32(idPerfil);
                

                GridPerfil.DataSource = _GestionAccesoLogic.ObtenerPerfilLogic(obj);
                GridPerfil.DataBind();
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
                DropPerfil.SelectedValue = "0";
                DropEstatus.SelectedValue = "0";

                llenaGridPerfil(null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void llenaDropPerfil(DropDownList pDrop, List<Entity.GestionAccesoEntity.PerfilEntity> plista)
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
                    foreach (Entity.GestionAccesoEntity.PerfilEntity objB in plista)
                    {
                        lstControl = new System.Web.UI.WebControls.ListItem(objB.Nombre, objB.idPerfil.ToString());
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