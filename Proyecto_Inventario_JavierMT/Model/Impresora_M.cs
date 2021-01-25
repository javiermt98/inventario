using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Impresora")]
    public class Impresora_M
    {
        [PrimaryKey, AutoIncrement]
        public int id_dispositivo { get; set; }
        public int num_factura { get; set; }
        public DateTime fecha_compra { get; set; }
        public string descripcion { get; set; }
        private string tipo { get; set; }
        private bool escaner { get; set; }
        private bool color { get; set; }

    }
}
