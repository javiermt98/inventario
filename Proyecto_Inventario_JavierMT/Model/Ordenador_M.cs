﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Ordenador")]
    public class Ordenador_M: Dispositivos_I
    {
        [PrimaryKey, AutoIncrement]
        public int id_dispositivo { get; set; }
        public int num_factura { get; set; }
        public DateTime fecha_compra { get; set; }
        public string descripcion { get; set; }
        private string tipo { get;set; }
        private string funcion { get; set; }
        private string sistop { get; set; }
        
    }
}
