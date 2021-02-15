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

        public ObservableCollection<String> listatipos { get; set; } = new ObservableCollection<string>(Provider.listatipos);
        public ObservableCollection<String> listafuncion { get; set; } = new ObservableCollection<string>(Provider.listafuncion);
        public ObservableCollection<String> listasistop { get; set; } = new ObservableCollection<string>(Provider.listasistop);




        public Task<List<Ordenador_M>> TaskOrdenador { get; set; }
        public OrdenadorDetalle_VM() {

            disp = new Dispositivo();
            ordenadorseleccionado = new Ordenador_M();
        }

        internal bool ComprobarPc()
        {
            
            ordenadorseleccionado.dispositivo = disp;
            ordenadorseleccionado.dispositivo.id_aula = Provider.auladeldispositivo.Id;
            TaskOrdenador = Provider.daoOrdenadores.AllOrdenadoresAsync();
            listaordenadores = new ObservableCollection<Ordenador_M>();



            bool existe = true;
            foreach (Ordenador_M o in listaordenadores)
            {
                if (o.dispositivo.nombre != null) {
                    if (!o.dispositivo.nombre.Equals(ordenadorseleccionado.dispositivo.nombre))
                    {
                        existe = false;
                    }
                }

            }

            return existe;

        }



        internal void AddVM()
        {
            Provider.daoOrdenadores.InsertOrdenadores(ordenadorseleccionado);
            listaordenadores.Insert(0, ordenadorseleccionado);
            OnPropertyChanged();
            
        }
    }
}
