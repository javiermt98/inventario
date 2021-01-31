﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Impresora")]
    public class Impresora_M : Dispositivo
    {
        [PrimaryKey, AutoIncrement]
        public int id_impresora { get; set; }
        public string tipo { get; set; }
        public bool escaner { get; set; }
        public bool color { get; set; }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }

    }
}
