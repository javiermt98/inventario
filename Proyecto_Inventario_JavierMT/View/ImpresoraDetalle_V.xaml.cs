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
    public partial class ImpresoraDetalle_V : ContentPage
    {
        private ImpresoraDetalle_VM vm;
        public ImpresoraDetalle_V(Impresora_M impresora)
        {
            InitializeComponent();

            vm = new ImpresoraDetalle_VM { impresoraseleccionada = impresora };
            BindingContext = vm;
            tipo.SelectedIndex = 0;

        }

        private void Guardar(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(factura.Text))
            {
                DisplayAlert("ERROR", "No puede haber campos vacíos", "Aceptar");

            }

            else
            {

                if (vm.ComprobarImpresora())
                {
                    vm.impresoraseleccionada.tipo = tipo.Items[tipo.SelectedIndex];
                    vm.impresoraseleccionada.color = color.IsChecked;
                    vm.impresoraseleccionada.escaner = escaner.IsChecked;



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