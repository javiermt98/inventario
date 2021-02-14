using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Helpers;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proyecto_Inventario_JavierMT.Model
{   
    [Table("Aula")]
    public class Aula_M : NotifyPropertyBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        private int _codigo { get; set; }
        private string _nombre { get; set; }
        private string _abreviatura { get; set; }
        private string _nivel { get; set; }
        [Ignore]
        private bool _activada { get; set; } = false;
        [ForeignKey(typeof(Dispositivo))]
        private int dispositivos_ID { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Dispositivo> dispositivos { get; set; }


        public int codigo { get { return _codigo; } set { _codigo = value; OnPropertyChanged(); } }
        public string nombre { get { return _nombre; } set { _nombre = value; OnPropertyChanged(); } }
        public string abreviatura { get { return _abreviatura; } set { _abreviatura = value; OnPropertyChanged(); } }
        public string nivel { get { return _nivel; } set { _nivel = value; OnPropertyChanged(); } }
        [Ignore]
        public bool activada { get { return _activada; } set { _activada = value; OnPropertyChanged(); } }


        public Aula_M() { 
        
        }
        public Aula_M(int codigo, string nombre, string abreviatura, string nivel) {

            this.codigo = codigo;
            this.nombre = nombre;
            this.abreviatura = abreviatura;
            this.nivel = nivel;

        }


    }
}
