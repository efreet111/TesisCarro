using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using OPTIMA.Helper;

namespace OPTIMA
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        public static string itemsMenu;
        private static Boolean menu = true;

        private string mensajeError;
        private string mensajeAdvertencia;
        private string mensajeExito;
        private string _Modal;
        private string _Modal2;
        private string urlMensaje;

        private string _ModalRegistrarse;
        private string _ModalLogin;
        public string modalmsjerror = "";
        //private static Admin configuracion;
        public static string NombrePerfil;


        #region<variables>
        public String MensajeError
        {
            get
            {
                return mensajeError;
            }
            set
            {
                mensajeError = value;

            }
        }

        public String MensajeExito
        {
            get
            {
                return mensajeExito;
            }
            set
            {
                mensajeExito = value;

            }
        }

        public String MensajeAdvertencia
        {
            get
            {
                return mensajeAdvertencia;
            }
            set
            {
                mensajeAdvertencia = value;

            }
        }

        public Boolean Menu
        {
            get
            {
                return menu;
            }
            set
            {
                menu = value;

            }
        }

        public String UrlMensaje
        {
            get
            {
                return urlMensaje;
            }
            set
            {
                urlMensaje = value;

            }
        }

        public String Modal
        {
            get
            {
                return _Modal;
            }
            set
            {
                _Modal = value;

            }
        }

        public String Modal2
        {
            get
            {
                return _Modal2;
            }
            set
            {
                _Modal2 = value;

            }
        }

        public String RegistrarseModal
        {
            get
            {
                return _ModalRegistrarse;
            }
            set
            {
                _ModalRegistrarse = value;

            }
        }

        public String LoginModal
        {
            get
            {
                return _ModalLogin;
            }
            set
            {
                _ModalLogin = value;

            }
        }

        //public Admin Configuracion
        //{
        //    get
        //    {
        //        return configuracion;
        //    }
        //    set
        //    {
        //        configuracion = value;

        //    }
        //}
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (!Page.IsPostBack)
                {

                }
                //CargarConfiguracion();                

            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                ManejadorError.MostrarMensaje(this.Page, @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}", ex);
            }
        }


        

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                LimpiarMensajes();
                Response.Redirect("login.aspx", false);
            }
            catch (Exception ex)
            {
                ManejadorError.ErrorManejador(Request.RawUrl, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                ManejadorError.MostrarMensaje(this.Page, @"Error en el Evento: " + System.Reflection.MethodBase.GetCurrentMethod().Name + ".\r{0}", ex);
            }
        }




        public void LimpiarMensajes()
        {

            this.MensajeAdvertencia = "";
            this.MensajeError = "";
            this.MensajeExito = "";

            this.UrlMensaje = "";
            this.Modal = "";
            this.Modal2 = "";

            this.RegistrarseModal = "";
            this.LoginModal = "";

        }
    }
}