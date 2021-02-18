using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class ListaMonitores_VM:NotifyPropertyBase
    {
        private Monitor_M _MonitorSeleccionado { get; set; }
        public Monitor_M MonitorSeleccionado { get { return _MonitorSeleccionado; } set { _MonitorSeleccionado = value; OnPropertyChanged(); } }

        private ObservableCollection<Monitor_M> _listamonitores { get; set; }

        public ObservableCollection<Monitor_M> listamonitores { get { return _listamonitores; } set { _listamonitores = value; OnPropertyChanged(); } }
        public Task<List<Monitor_M>> TaskMonitores { get; set; }

        public ListaMonitores_VM() {

            TaskMonitores = Provider.daoMonitores.AllMonitoresAsync();
            listamonitores = new ObservableCollection<Monitor_M>(TaskMonitores.Result);
            OnPropertyChanged();

        }
        internal void Recargar()
        {
            TaskMonitores = Provider.daoMonitores.AllMonitoresAsync();
            listamonitores = new ObservableCollection<Monitor_M>(TaskMonitores.Result);
            OnPropertyChanged();

        }
    }
}
