using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.ViewModel;

namespace Proyecto_Inventario_JavierMT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonitorDetalle_V : ContentPage
    {
        private MonitorDetalle_VM vm;
         
        public MonitorDetalle_V(Monitor_M monitor, Dispositivo dispositivo)
        {
            vm = new MonitorDetalle_VM { monitorseleccionado = monitor, disp = dispositivo };
            BindingContext = vm;
            InitializeComponent();



        }


        private void Guardar(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(factura.Text))
            {
                DisplayAlert("ERROR", "No puede haber campos vacíos", "Aceptar");

            }

            else
            {

                if (vm.ComprobarMonitor())
                {




                    vm.AddVM();
                    DisplayAlert("ACEPT", "Impresora Registrada", "Aceptar");
                    Navigation.PopAsync();
                }
                else
                {

                    DisplayAlert("CANCEL", "Ya existe una impresora con ese Nombre", "Aceptar");

                }
            }

        }
    }
}
