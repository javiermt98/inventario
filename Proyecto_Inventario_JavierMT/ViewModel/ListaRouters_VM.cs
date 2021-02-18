using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    public class ListaRouters_VM: NotifyPropertyBase
    {
        private Router_M _RouterSeleccionado { get; set; }
        public Router_M RouterSeleccionado { get { return _RouterSeleccionado; } set { _RouterSeleccionado = value; OnPropertyChanged(); } }

        private ObservableCollection<Router_M> _listarouters { get; set; }

        public ObservableCollection<Router_M> listarouters { get { return _listarouters; } set { _listarouters = value; OnPropertyChanged(); } }
        public List<Router_M> TaskRouters { get; set; }

        public ListaRouters_VM() {
            TaskRouters = Provider.daoRouters.AllRoutersAsync();
            listarouters = new ObservableCollection<Router_M>(TaskRouters);
            OnPropertyChanged();
        }
        public void BorrarVM()
        {

            listarouters.Remove(RouterSeleccionado);
            Provider.daoRouters.Borrar(RouterSeleccionado);
            OnPropertyChanged("listarouters");
        }

        internal void Recargar()
        {
            TaskRouters = Provider.daoRouters.AllRoutersAsync();
            listarouters = new ObservableCollection<Router_M>(TaskRouters);
            OnPropertyChanged();

        }
    }
}
