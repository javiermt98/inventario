using Proyecto_Inventario_JavierMT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class MonitorDetalle_VM:NotifyPropertyBase
    {
        private Dispositivo _disp { get; set; }
        public Dispositivo disp { get { return _disp; } set { _disp = value; OnPropertyChanged(); } }
        private Monitor_M _monitorseleccionado { get; set; }
        public Monitor_M monitorseleccionado { get { return _monitorseleccionado; } set { _monitorseleccionado = value; OnPropertyChanged(); } }
        private ObservableCollection<Monitor_M> _listamonitores { get; set; }

        public ObservableCollection<Monitor_M> listamonitores { get { return _listamonitores; } set { _listamonitores = value; OnPropertyChanged(); } }

        public List<Monitor_M> TaskMonitores { get; set; }

        public MonitorDetalle_VM() {
            disp = new Dispositivo();
            monitorseleccionado = new Monitor_M();
        }
        internal bool ComprobarMonitor()
        {

            monitorseleccionado.dispositivo = disp;
            monitorseleccionado.dispositivo.id_aula = Provider.auladeldispositivo.Id;
            TaskMonitores = Provider.daoMonitores.AllMonitoresAsync();
            listamonitores = new ObservableCollection<Monitor_M>();



            bool existe = true;
            foreach (Monitor_M o in listamonitores)
            {
                if (o.dispositivo.nombre != null)
                {
                    if (!o.dispositivo.nombre.Equals(monitorseleccionado.dispositivo.nombre))
                    {
                        existe = false;
                    }
                }

            }

            return existe;

        }

        internal void AddVM()
        {
            Provider.daoMonitores.InsertMonitor(monitorseleccionado);
            listamonitores.Insert(0, monitorseleccionado);
            OnPropertyChanged();

        }
    }
}
