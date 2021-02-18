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
    public partial class OrdenadorDetalle_V : ContentPage
    {
        private OrdenadorDetalle_VM vm;
        public OrdenadorDetalle_V(Ordenador_M ordenador, Dispositivo dispositivo)
        {   
            InitializeComponent();
            vm = new OrdenadorDetalle_VM{ordenadorseleccionado = ordenador, disp = dispositivo };
            BindingContext = vm;



        }



        private void Guardar(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(factura.Text))
            {
                DisplayAlert("ERROR", "No puede haber campos vacíos", "Aceptar");

            }

            else {
                
                if (vm.ComprobarPc())
                {
                    

                    vm.AddVM();
                    DisplayAlert("ACEPT", "Ordenador Registrado", "Aceptar");
                    Navigation.PopAsync();
                }
                else
                {

                    DisplayAlert("CANCEL", "Ya existe un ordenador con ese Nombre", "Aceptar");

                }
            }
           
            



        }


    }
}