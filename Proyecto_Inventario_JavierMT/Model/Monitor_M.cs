using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Proyecto_Inventario_JavierMT.Helpers;


namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Monitor")]
    public class Monitor_M : NotifyPropertyBase
    {
        [PrimaryKey, AutoIncrement]
        public int id_monitor { get; set; }
        public double pulgadas { get; set; }
        public string marca { get; set; }
        private bool _activada { get; set; } = false;
        [Ignore]
        public bool activada { get { return _activada; } set { _activada = value; OnPropertyChanged(); } }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }
    }
}
