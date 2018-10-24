using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActualizarPrecios.Clases
{
    public class ArticuloBascula
    {
        public int codigo { set; get; }
        public string clave_microsip { set; get; }
        public string nombre { set; get; }
    }

    public class ArticuloEnBascula
    {
        public int codigo { set; get; }
        public string clave_microsip { set; get; }
        public string nombre { set; get; }
        public decimal precio { set; get; }
        public int noplu { set; get; }
        public decimal impuesto { set; get; }
        public int caducidad { set; get; }
        public int tipoplu { set; get; }
        public int? editable { get; set; } 
        public int? id_producto { set; get; }
    }
}
