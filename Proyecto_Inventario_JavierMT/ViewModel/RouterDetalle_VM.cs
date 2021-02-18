using Proyecto_Inventario_JavierMT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class RouterDetalle_VM: NotifyPropertyBase
    {
        private Dispositivo _disp { get; set; }
        public Dispositivo disp { get { return _disp; } set { _disp = value; OnPropertyChanged(); } }
        private Router_M _routerseleccionado { get; set; }
        public Router_M routerseleccionado { get { return _routerseleccionado; } set { _routerseleccionado = value; OnPropertyChanged(); } }
        private ObservableCollection<Router_M> _listarouters { get; set; }

        public ObservableCollection<Router_M> listarouters { get { return _listarouters; } set { _listarouters = value; OnPropertyChanged(); } }
        public ObservableCollection<String> listatiposrouter { get; set; } = new ObservableCollection<string>(Provider.listatiposrouter);


        public Task<List<Router_M>> TaskRouters { get; set; }

        public RouterDetalle_VM() {
            disp = new Dispositivo();
            routerseleccionado = new Router_M();
        }

        internal bool ComprobarRouter()
        {

            routerseleccionado.dispositivo = disp;
            routerseleccionado.dispositivo.id_aula = Provider.auladeldispositivo.Id;
            TaskRouters = Provider.daoRouters.AllRoutersAsync();
            listarouters = new ObservableCollection<Router_M>();



            bool existe = true;
            foreach (Router_M o in listarouters)
            {
                if (o.dispositivo.nombre != null)
                {
                    if (!o.dispositivo.nombre.Equals(routerseleccionado.dispositivo.nombre))
                    {
                        existe = false;
                    }
                }

            }

            return existe;

        }

        internal void AddVM()
        {
            Provider.daoRouters.InsertRouters(routerseleccionado);
            listarouters.Insert(0, routerseleccionado);
            OnPropertyChanged();
        }

    }
}
