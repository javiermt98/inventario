using Proyecto_Inventario_JavierMT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Proyecto_Inventario_JavierMT.ViewModel
{
    public class ImpresoraDetalle_VM:NotifyPropertyBase
    {
    private Dispositivo _disp { get; set; }
    public Dispositivo disp { get { return _disp; } set { _disp = value; OnPropertyChanged(); } }
    private Impresora_M _impresoraseleccionada { get; set; }
    public Impresora_M impresoraseleccionada { get { return _impresoraseleccionada; } set { _impresoraseleccionada = value; OnPropertyChanged(); } }
    private ObservableCollection<Impresora_M> _listaimpresoras { get; set; }

    public ObservableCollection<Impresora_M> listaimpresoras { get { return _listaimpresoras; } set { _listaimpresoras = value; OnPropertyChanged(); } }

    public ObservableCollection<String> listatiposimpresoras { get; set; } = new ObservableCollection<string>(Provider.listatiposimpresora);

    public List<Impresora_M> TaskImpresoras { get; set; }

        public ImpresoraDetalle_VM()
        {

            disp = new Dispositivo();
            impresoraseleccionada = new Impresora_M();
        }
        internal bool ComprobarImpresora()
        {

            impresoraseleccionada.dispositivo = disp;
            impresoraseleccionada.dispositivo.id_aula = Provider.auladeldispositivo.Id;
            TaskImpresoras = Provider.daoImpresoras.AllImpresorasAsync();
            listaimpresoras = new ObservableCollection<Impresora_M>();



            bool existe = true;
            foreach (Impresora_M o in listaimpresoras)
            {
                if (o.dispositivo.nombre != null)
                {
                    if (!o.dispositivo.nombre.Equals(impresoraseleccionada.dispositivo.nombre))
                    {
                        existe = false;
                    }
                }

            }

            return existe;

        }



        internal void AddVM()
        {
            Provider.daoImpresoras.InsertImpresroas(impresoraseleccionada);
            listaimpresoras.Insert(0, impresoraseleccionada);
            OnPropertyChanged();

        }
    }
}
