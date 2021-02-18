using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Proyecto_Inventario_JavierMT.Helpers;


namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Router")]
    public class Router_M : NotifyPropertyBase
    {
        [PrimaryKey, AutoIncrement]
        public int id_router { get; set; }


        public int num_puertos { get; set; }
        public double velocidad { get; set; }
        public bool wifi { get; set; }
        public string rout_switch { get; set; }
        private bool _activada { get; set; } = false;
        [Ignore]
        public bool activada { get { return _activada; } set { _activada = value; OnPropertyChanged(); } }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }

    }
}
