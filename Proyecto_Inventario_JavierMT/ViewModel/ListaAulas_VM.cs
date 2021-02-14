using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Threading.Tasks;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    public class ListaAulas_VM : NotifyPropertyBase
    {
        private Aula_M _AulaSeleccionada { get; set; } = new Aula_M();
        public Aula_M AulaSeleccionada { get { return _AulaSeleccionada; } set { _AulaSeleccionada = value; OnPropertyChanged(); } }

        private ObservableCollection<Aula_M> _aulaslist { get; set; }
        public ObservableCollection<Aula_M> aulaslist { get { return _aulaslist; } set { _aulaslist = value; OnPropertyChanged(); } }

        public ListaAulas_VM() {
                AulaSeleccionada = new Aula_M();
                Task<List<Aula_M>> TaskAulas = Provider.daoAulas.AllAulasAsync();
                aulaslist = new ObservableCollection<Aula_M>(TaskAulas.Result);
                OnPropertyChanged("aulaslist");


        }

         

        public void BorrarVM() {

            aulaslist.Remove(AulaSeleccionada);
            Provider.daoAulas.Borrar(AulaSeleccionada);
            OnPropertyChanged("aulaslist");
        }


    }
}
