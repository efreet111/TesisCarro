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

        public class coloresEntity
        {
            public int? idColor { get; set; }
            public string Nombre { get; set; }
            public string codigo { get; set; }
            public string codigoPaleta { get; set; }
            public int? Amarillo { get; set; }
            public int? Magenta { get; set; }
            public int? Cian { get; set; }
            public int? Rojo { get; set; }
            public int? Azul { get; set; }
            public int? Verde { get; set; }
            public int? Blanco { get; set; }
            public int? Negro { get; set; }
            public int? Plateado { get; set; }
            public int? Dorado { get; set; }
            public int? idUsuarioCambio { get; set; }
            public string Estatus { get; set; }
        }

    }
}
