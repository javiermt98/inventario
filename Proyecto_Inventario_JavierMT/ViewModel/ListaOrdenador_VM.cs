using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class ListaOrdenador_VM : NotifyPropertyBase
    {
        private Ordenador_M _PcSeleccionado { get; set; }
        public Ordenador_M PcSeleccionado { get { return _PcSeleccionado; }set { _PcSeleccionado = value; OnPropertyChanged(); } }

        private ObservableCollection<Ordenador_M> _listaordenadores { get; set; }

        public ObservableCollection<Ordenador_M> listaordenadores { get { return _listaordenadores; } set { _listaordenadores = value; OnPropertyChanged(); } }
        public Task<List<Ordenador_M>> TaskOrdenador { get; set; }

        public ListaOrdenador_VM()
        {
            TaskOrdenador = Provider.daoOrdenadores.AllOrdenadoresAsync();
            listaordenadores = new ObservableCollection<Ordenador_M>(TaskOrdenador.Result);
            OnPropertyChanged();


        }

        internal void Recargar()
        {
            TaskOrdenador = Provider.daoOrdenadores.AllOrdenadoresAsync();
            listaordenadores = new ObservableCollection<Ordenador_M>(TaskOrdenador.Result);
            OnPropertyChanged();

        }
    }
}
