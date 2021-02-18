using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Proyecto_Inventario_JavierMT.Helpers;

namespace Proyecto_Inventario_JavierMT.Model
{
    public class Foto_M : NotifyPropertyBase
    {
        [PrimaryKey, AutoIncrement]
        public int id_foto{get;set;}
        public string descripcion { get; set; }
        public byte[] picture { get; set; }
        private int _id_dispositivo { get; set; }
        public int id_dispositivo { get { return _id_dispositivo; } set { _id_dispositivo = value; OnPropertyChanged(); } }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Dispositivo dispositivo { get; set; }
    }
}
