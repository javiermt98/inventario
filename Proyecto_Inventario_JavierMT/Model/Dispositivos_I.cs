using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Proyecto_Inventario_JavierMT.Model
{
    
    public interface Dispositivos_I
    {
        int id_dispositivo { get; set; }
        int num_factura { get; set; }
        DateTime fecha_compra { get; set; }
        string descripcion { get; set; }
    }
}
