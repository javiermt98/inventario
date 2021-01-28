using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Threading.Tasks;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    class ListaDispositivos_VM : NotifyPropertyBase
    {
        private ObservableCollection<Aula_M> _listaobjetos { get; set; }
        public ObservableCollection<Aula_M> listaobjetos { get { return _listaobjetos; } set { _listaobjetos = value; OnPropertyChanged(); } }

        private Aula_M _aula { get; set; }
        public Aula_M aula { get { return _aula; } set { _aula = value; OnPropertyChanged(); } }

        public ListaDispositivos_VM()
        {
            if (aula != null) {
                Task<List<Aula_M>> TaskDispositivos = Provider.daoAulas.DispositivosPorClase(aula.Id);
                _listaobjetos = new ObservableCollection<Aula_M>(TaskDispositivos.Result);
            }   

        }
    }
}
