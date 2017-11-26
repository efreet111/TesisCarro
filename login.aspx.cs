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
    public partial class login : System.Web.UI.Page
    {
        public static bool cambioClave;
        public static string passwordOld;



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {
                    Session.Clear();
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.lbMensajeError.Text = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            Logic.GestionAccesoLogic serv = new Logic.GestionAccesoLogic();
            Entity.GestionAccesoEntity.UsuarioEntity obj = new Entity.GestionAccesoEntity.UsuarioEntity();

            try
            {
                if (TxtEmail.Text != "" && Txtpassword.Text != "")
                {
                    obj.Correo = TxtEmail.Text;
                    obj.Pwd = Txtpassword.Text;
                    obj.idEstatus = 1;
                    var ll = serv.ObtenerUsuarioLogic(obj);
                    if (ll.Count > 0)
                    {
                        foreach (var item in ll)
                        {
                            Session["usuario_idUsuario"] = item.idUsuario;
                            Session["usuario_Nombre"] = item.Nombre;
                            Session["usuario_Correo"] = item.Correo;
                            Session["usuario_idPerfil"] = item.idPerfil;
                            Session["usuario_NomPerfil"] = item.NombrePerfil;
                            //lblUsuario.Text = "Bienvenido, " + Session["usuario_nombre"].ToString();
                            Response.Redirect("index.aspx", false);
                        }
                    }
                    else
                    {
                        lbMensaje.Text = "Usuarios y Contrasena incorrectos. Verifique e intente nuevamente.";
                    }
                }
                else
                {
                    lbMensaje.Text = "Existen campos vacios. Verifique e intente nuevamente.";
                }
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.lbMensajeError.Text = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }

        }

        protected void btEnviarPass_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                this.lbMensajeError.Text = @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\r" + ((ConfigurationManager.AppSettings.Get("MuestraTraza").ToString().ToLower() == "true") ? ex.ToString() : string.Empty);
            }
        }

        protected void btCambiarPassword_Click(object sender, EventArgs e)
        {

        }
    }
}