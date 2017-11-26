using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GestionAccesoEntity
    {
        public class PerfilEntity
        {
            public int? idPerfil { get; set; }
            public string Nombre { get; set; }
            public bool? Activo { get; set; }
            public string nomActivo { get; set; }
        }

        public class UsuarioEntity
        {
            public int? idUsuario { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Correo { get; set; }
            public string Cedula { get; set; }
            public string Telefono { get; set; }
            public string Pwd { get; set; }
            public int? idPerfil { get; set; }
            public int? idEstatus { get; set; }
            public string nomEstatus { get; set; }
            public string NombrePerfil { get; set; }
        }
    }
}
