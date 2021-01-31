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
        public ListaOrdenador_VM PcSeleccionado { get; set; }

        private ObservableCollection<ListaOrdenador_VM> _pclist { get; set; }
        public ObservableCollection<ListaOrdenador_VM> pclist { get { return _pclist; } set { _pclist = value; OnPropertyChanged(); } }

        public ListaOrdenador_VM()
        {

            //Task<List<Ordenador_VM>> TaskAulas = Provider.daoAulas.AllAulasAsync();
            //pclist = new ObservableCollection<Ordenador_VM>(TaskAulas.Result);


        }

    }
}
