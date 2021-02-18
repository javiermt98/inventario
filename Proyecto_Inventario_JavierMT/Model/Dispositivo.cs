using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
using Proyecto_Inventario_JavierMT.Helpers;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Dispositivos")]
    public class Dispositivo: NotifyPropertyBase
    {

        [PrimaryKey, AutoIncrement]
        public int id_dispositivo { get; set; }
        private string _nombre { get; set; }
        private string _num_factura { get; set; }
        private DateTime _fecha_compra { get; set; }
        private int _id_aula { get; set; }
        public string descripcion { get; set; }

        public int id_aula { get { return _id_aula; } set { _id_aula = value; OnPropertyChanged(); } }
        public string nombre { get { return _nombre; } set { _nombre = value; OnPropertyChanged(); } }
        public string num_factura { get { return _num_factura; } set { _num_factura = value; OnPropertyChanged(); } }
        public DateTime fecha_compra { get { return _fecha_compra; } set { _fecha_compra = value; OnPropertyChanged(); } }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Aula_M aula { get; set; }



    }
}
