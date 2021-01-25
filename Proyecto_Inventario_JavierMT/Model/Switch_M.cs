using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Switch")]
    public class Switch_M : Dispositivos_I
    {
        [PrimaryKey, AutoIncrement]
        public int id_dispositivo { get; set; }
        public int num_factura { get; set; }
        public DateTime fecha_compra { get; set; }
        public string descripcion { get; set; }
        private int num_puertos { get; set; }
        private double velocidad { get; set; }
        private bool wifi { get; set; }
    }
}
