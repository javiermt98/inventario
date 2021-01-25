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
        public Aula_M AulaSeleccionada { get; set; }
        private bool _botonborrar { get; set; } = false;
        public bool botonborrar { get{ return _botonborrar; } set{ _botonborrar = value; OnPropertyChanged(); } }

        private ObservableCollection<Aula_M> _aulaslist { get; set; }
        public ObservableCollection<Aula_M> aulaslist { get { return _aulaslist; } set { _aulaslist = value; OnPropertyChanged(); } }

        public ListaAulas_VM() {

            Task<List<Aula_M>> TaskAulas = Provider.daoAulas.AllAulasAsync();
            aulaslist = new ObservableCollection<Aula_M>(TaskAulas.Result);
        }
        public void AddVM()
        {
            
            aulaslist.Insert(0, new Aula_M());
            OnPropertyChanged("aulaslist");
        }
        public void BorrarVM() {

            //Provider.daoAulas.Borrar(AulaSeleccionada);
            aulaslist.Remove(AulaSeleccionada);
            OnPropertyChanged("aulaslist");
        }

        internal void CambiaBoton()
        {
            botonborrar = !botonborrar;
            
            OnPropertyChanged("botonborrar");
        }
    }
}
