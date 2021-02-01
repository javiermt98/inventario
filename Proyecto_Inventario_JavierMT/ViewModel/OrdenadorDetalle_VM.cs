using Proyecto_Inventario_JavierMT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Helpers;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class OrdenadorDetalle_VM: NotifyPropertyBase
    {
        private Dispositivo _disp { get; set; }
        public Dispositivo disp { get { return _disp; }set { _disp = value;OnPropertyChanged(); } }
        private Ordenador_M _ordenadorseleccionado { get; set; }
        public Ordenador_M ordenadorseleccionado { get { return _ordenadorseleccionado; } set { _ordenadorseleccionado = value;OnPropertyChanged(); } }
        internal bool ComprobarPc()
        {
            return false;
        }

        internal void AddVM()
        {
            
        }
    }
}
