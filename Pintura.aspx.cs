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
    public partial class Pintura : System.Web.UI.Page
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
                    llenaGridColores(null, null, null, "Activo");
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
                llenaGridColores(string.IsNullOrEmpty(txtCodigo.Text) ? null : (txtCodigo.Text),
                                       string.IsNullOrEmpty(txtNombre.Text) ? null : (txtNombre.Text),
                                       string.IsNullOrEmpty(txtcodigoPaleta.Text) ? null : (txtcodigoPaleta.Text),
                                        DropEstatus.SelectedValue == "-1" ? null : (DropEstatus.SelectedValue)
                                        );


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
                Response.Redirect("Pintura.aspx", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void LinkAddColor_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEditarColor.aspx", false);
            return;
        }

        protected void GridColores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Modificar")
                {
                    int idColor = Convert.ToInt32(GridColores.DataKeys[System.Convert.ToInt32(e.CommandArgument)].Values["idColor"].ToString());
                    Response.Redirect("CrearEditarColor.aspx?idColor=" + idColor.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Master.MensajeError = "Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}" + ex;
            }
        }

        protected void GridColores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                GridColores.PageIndex = e.NewPageIndex;
                llenaGridColores(string.IsNullOrEmpty(txtCodigo.Text) ? null : (txtCodigo.Text),
                                       string.IsNullOrEmpty(txtNombre.Text) ? null : (txtNombre.Text),
                                       string.IsNullOrEmpty(txtcodigoPaleta.Text) ? null : (txtcodigoPaleta.Text),
                                        DropEstatus.SelectedValue == "-1" ? null : (DropEstatus.SelectedValue)
                                       );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imagebut_Command(object sender, CommandEventArgs e)
        {

        }



        #region<Metodos>
        protected void llenaGridColores(string Codigo, string Nombre, string CodigoPaleta, string Estatus)
        {
            _GestionInventarioLogic = new Logic.MaterialesLogic();

            try
            {
                Entity.InventarioEntity.coloresEntity obj = new Entity.InventarioEntity.coloresEntity();
                obj.codigo = (string.IsNullOrEmpty(Codigo)) ? null : Codigo;
                obj.Estatus = (string.IsNullOrEmpty(Estatus)) ? null : Estatus;
                obj.Nombre = (string.IsNullOrEmpty(Nombre)) ? null : Nombre;
                obj.codigoPaleta = (string.IsNullOrEmpty(CodigoPaleta)) ? null : CodigoPaleta;
                GridColores.DataSource = _GestionInventarioLogic.ObtenerColores(obj);
                GridColores.DataBind();
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








        //protected void GridItem_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    ClsSeccion ServicioSeccion = new ClsSeccion(); ;
        //    ClsSeccion.SeccionEntity _objSeccionEntity = null;

        //    ClsSeccionExtendida ServicioSeccionExtendida = new ClsSeccionExtendida();
        //    ClsSeccionExtendida.SeccionExitendidaEntity _objSeccionExitendidaEntity = null;

        //    try
        //    {
        //        if (e.CommandName == "Modificar")
        //        {
        //            int idSeccion = (int)GridItem.DataKeys[System.Convert.ToInt32(e.CommandArgument)].Value;
        //            HideInsertEdit.Value = idSeccion.ToString();

        //            limpiarModal();
        //            _objSeccionEntity = new ClsSeccion.SeccionEntity();
        //            _objSeccionEntity.idSeccion = idSeccion;
        //            var lista = ServicioSeccion.ObtenerSeccion(_objSeccionEntity);
        //            if (lista.Count > 0)
        //            {
        //                txtNombre2.Text = lista.FirstOrDefault().Nombre;

        //                _objSeccionExitendidaEntity = new ClsSeccionExtendida.SeccionExitendidaEntity();
        //                _objSeccionExitendidaEntity.idSeccion = idSeccion;
        //                var lista2 = ServicioSeccionExtendida.ObtenerSeccionExtendida(_objSeccionExitendidaEntity);
        //                if (lista2.Count > 0)
        //                {
        //                    TxtUrl.Text = Utility.EmptyIfNull((from c in lista2 where c.idTipo == ConfigurationManager.AppSettings.Get("URL_SECCION_tipo") select c.Valor).FirstOrDefault());
        //                    string EstatusTemp = Utility.CeroIfNull((from c in lista2 where c.idTipo == ConfigurationManager.AppSettings.Get("ESTATUS_SECCION_tipo") select c.Valor).FirstOrDefault());
        //                    DropEstatus2.SelectedValue = (EstatusTemp == "-1") ? "0" : EstatusTemp;
        //                    linkImagen.HRef = Utility.EmptyIfNull((from c in lista2 where c.idTipo == ConfigurationManager.AppSettings.Get("IMAGEN_tipo") select c.Valor).FirstOrDefault());
        //                    imgImagen.ImageUrl = Utility.EmptyIfNull((from c in lista2 where c.idTipo == ConfigurationManager.AppSettings.Get("IMAGEN_tipo") select c.Valor).FirstOrDefault());
        //                }
        //            }


        //            this.Master.ActualizarModal = "true";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejadorError.ErrorManejador("marcas.aspx", "GridItem_RowCommand", ex);
        //        ManejadorError.MostrarMensaje(this, @"Error en el evento GridItem_RowCommand.\r{0}", ex);
        //    }
        //}





        #endregion

    }
}