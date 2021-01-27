using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Monitor")]
    public class Monitor_M : Dispositivos_I
    {
        [PrimaryKey, AutoIncrement]
        public int id_dispositivo { get; set; }
        public int num_factura { get; set; }
        public DateTime fecha_compra { get; set; }
        public string descripcion { get; set; }
        public string codigoaula { get; set; }

        private double pulgadas { get; set; }
        private string marca { get; set; }
    }
}
