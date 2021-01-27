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

        private ObservableCollection<Aula_M> _aulaslist { get; set; }
        public ObservableCollection<Aula_M> aulaslist { get { return _aulaslist; } set { _aulaslist = value; OnPropertyChanged(); } }

        public ListaAulas_VM() {

            Task<List<Aula_M>> TaskAulas = Provider.daoAulas.AllAulasAsync();
            aulaslist = new ObservableCollection<Aula_M>(TaskAulas.Result);
        }

         
        public bool ComprobarAula(Aula_M aula)
        {
            bool existe = true;
            foreach(Aula_M a in aulaslist){
                if (a.codigo.Equals(aula.codigo))
                {
                    existe = false;
                }
            }

            return existe;
           

        }

        public void AddVM(Aula_M aula) {
            aulaslist.Insert(0, aula);
            Provider.daoAulas.Insert(aula);
            OnPropertyChanged("aulaslist");
        }
        public void BorrarVM() {

            //Provider.daoAulas.Borrar(AulaSeleccionada);
            aulaslist.Remove(AulaSeleccionada);
            Provider.daoAulas.Borrar(AulaSeleccionada);
            OnPropertyChanged("aulaslist");
        }


    }
}
