using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Dispositivos")]
    public class Dispositivo
    {

        [PrimaryKey, AutoIncrement]
        public int id_dispositivo { get; set; }
        public string nombre { get; set; }
        public string num_factura { get; set; }
        public DateTime fecha_compra { get; set; }
        public string descripcion { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Aula_M aula { get; set; }
    }
}
