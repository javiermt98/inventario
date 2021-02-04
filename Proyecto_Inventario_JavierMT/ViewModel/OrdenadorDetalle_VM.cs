using Proyecto_Inventario_JavierMT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class OrdenadorDetalle_VM: NotifyPropertyBase
    {
        private Dispositivo _disp { get; set; }
        public Dispositivo disp { get { return _disp; }set { _disp = value;OnPropertyChanged(); } }
        private Ordenador_M _ordenadorseleccionado { get; set; }
        public Ordenador_M ordenadorseleccionado { get { return _ordenadorseleccionado; } set { _ordenadorseleccionado = value;OnPropertyChanged(); } }
        private ObservableCollection<Ordenador_M> _listaordenadores { get; set; }

        public ObservableCollection<Ordenador_M> listaordenadores { get { return _listaordenadores; } set { _listaordenadores = value; OnPropertyChanged(); } }
        public Task<List<Ordenador_M>> TaskOrdenador { get; set; }


        internal bool ComprobarPc()
        {
            ordenadorseleccionado.disp = disp;
            TaskOrdenador = Provider.daoOrdenadores.AllOrdenadoresAsync();
            listaordenadores = new ObservableCollection<Ordenador_M>(TaskOrdenador.Result);
            bool existe = true;
            foreach (Ordenador_M o in listaordenadores)
            {
                if (!o.disp.nombre.Equals(ordenadorseleccionado.disp.nombre))
                {
                    existe = false;
                }
            }

            return existe;

        }

        internal void AddVM()
        {
            ordenadorseleccionado.disp = disp;
            Provider.daoOrdenadores.InsertOrdenadores(ordenadorseleccionado);
            listaordenadores.Insert(0, ordenadorseleccionado);
            OnPropertyChanged();
            
        }
    }
}
