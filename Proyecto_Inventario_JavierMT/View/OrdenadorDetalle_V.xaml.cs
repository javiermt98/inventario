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
        public OrdenadorDetalle_V(Ordenador_M ordenador)
        {   
            InitializeComponent();
            vm = new OrdenadorDetalle_VM{ordenadorseleccionado = ordenador };
            BindingContext = vm;
            tipo.SelectedIndex = 0;
            funcion.SelectedIndex = 0;
            sistop.SelectedIndex = 0;


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
                    String f = funcion.Items[funcion.SelectedIndex];
                    String t = tipo.Items[tipo.SelectedIndex];
                    String s = sistop.Items[sistop.SelectedIndex];
                    vm.ordenadorseleccionado.funcion = f;
                    vm.ordenadorseleccionado.tipo = t;
                    vm.ordenadorseleccionado.sistop = s;
                    

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