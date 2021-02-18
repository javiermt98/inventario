using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    public class ListaImpresoras_VM: NotifyPropertyBase
    {
        private Impresora_M _ImpresoraSeleccionada { get; set; }
        public Impresora_M ImpresoraSeleccionada { get { return _ImpresoraSeleccionada; } set { _ImpresoraSeleccionada = value; OnPropertyChanged(); } }

        private ObservableCollection<Impresora_M> _listaimpresoras { get; set; }

        public ObservableCollection<Impresora_M> listaimpresoras { get { return _listaimpresoras; } set { _listaimpresoras = value; OnPropertyChanged(); } }
        public List<Impresora_M> TaskImpresoras { get; set; }

        public ListaImpresoras_VM()
        {
            TaskImpresoras = Provider.daoImpresoras.AllImpresorasAsync();
            listaimpresoras = new ObservableCollection<Impresora_M>(TaskImpresoras);
            OnPropertyChanged();


        }

        public void BorrarVM()
        {

            listaimpresoras.Remove(ImpresoraSeleccionada);
            Provider.daoImpresoras.Borrar(ImpresoraSeleccionada);
            OnPropertyChanged("listaimpresoras");
        }

        internal void Recargar()
        {
            TaskImpresoras = Provider.daoImpresoras.AllImpresorasAsync();
            listaimpresoras = new ObservableCollection<Impresora_M>(TaskImpresoras);
            OnPropertyChanged();

        }
    }
}
