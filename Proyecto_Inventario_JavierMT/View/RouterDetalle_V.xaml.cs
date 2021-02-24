using System;
using System.Collections.ObjectModel;
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
    public partial class RouterDetalle_V : ContentPage
    {
        private RouterDetalle_VM vm;

        public RouterDetalle_V(Router_M router, Dispositivo dispositivo)
        {
            InitializeComponent();
            vm = new RouterDetalle_VM {routerseleccionado = router, disp = dispositivo };
            BindingContext = vm;
            


        }

        private void Guardar(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(factura.Text))
            {
                DisplayAlert("ERROR", "No puede haber campos vacíos", "Aceptar");

            }

            else
            {

                if (vm.ComprobarRouter())
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
