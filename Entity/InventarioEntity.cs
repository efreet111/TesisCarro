using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InventarioEntity
    {
        //public class PerfilEntity
        //{
        //    public int? idPerfil { get; set; }
        //    public string Nombre { get; set; }
        //    public bool? Activo { get; set; }
        //    public string nomActivo { get; set; }
        //}

        public class MaterialEntity
        {
            public int? id { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public int? idUsuarioCambio { get; set; }
            public string Estatus { get; set; }
            public int? idTipo { get; set; }
            public int? cantidad { get; set; }
            public string nomEstatus { get; set; } 
        }


        public class TipoEntity
        {
            public int? idTipo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int? idUsuarioCambio { get; set; }
            public string Estatus { get; set; }
            public int? idTipoPadre { get; set; }
        }

    }
}
