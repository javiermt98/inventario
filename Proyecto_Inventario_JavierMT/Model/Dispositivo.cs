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
        int id_dispositivo { get; set; }
        int num_factura { get; set; }
        DateTime fecha_compra { get; set; }
        string descripcion { get; set; }
        [ManyToOne]
        Aula_M aula { get; set; }
    }
}
