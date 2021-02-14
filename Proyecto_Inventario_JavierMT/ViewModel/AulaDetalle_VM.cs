using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Inventario_JavierMT.Helpers;
using Proyecto_Inventario_JavierMT.Model;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class AulaDetalle_VM : NotifyPropertyBase
    {

        private Aula_M _AulaSeleccionada { get; set; }
        public Aula_M AulaSeleccionada { get { return _AulaSeleccionada; } set { _AulaSeleccionada = value; OnPropertyChanged(); } }
        private ObservableCollection<Aula_M> _aulaslist { get; set; }
        public ObservableCollection<Aula_M> aulaslist { get { return _aulaslist; } set { _aulaslist = value; OnPropertyChanged(); } }

        public AulaDetalle_VM() {
        }
        public bool ComprobarAula()
        {

            Task<List<Aula_M>> TaskAulas = Provider.daoAulas.AllAulasAsync();
            aulaslist = new ObservableCollection<Aula_M>(TaskAulas.Result);
            bool existe = true;
            if (aulaslist == null) {
                existe = false;
            }
            else
            {
                foreach (Aula_M a in aulaslist)
                {
                    if (a.codigo.Equals(AulaSeleccionada.codigo))
                    {
                        existe = false;
                    }
                }

            }


            return existe;


        }

        public void AddVM()
        {
            aulaslist.Insert(0, AulaSeleccionada);
            Provider.daoAulas.Insert(AulaSeleccionada);
            
        }


    }
}
