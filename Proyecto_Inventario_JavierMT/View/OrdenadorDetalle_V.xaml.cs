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
        public OrdenadorDetalle_V()
        {
            InitializeComponent();
            vm = new OrdenadorDetalle_VM();
            BindingContext = vm;
            tipo.SelectedIndex = 0;
            funcion.SelectedIndex = 0;
            sistop.SelectedIndex = 0;


        }

        private void Guardar(object sender, EventArgs e)
        {
            
            Ordenador_M ordenador = new Ordenador_M(tipo.SelectedIndex.ToString(), funcion.SelectedIndex.ToString(), sistop.SelectedIndex.ToString());
            if (vm.ComprobarPc(ordenador))
            {
                vm.AddVM(ordenador);
                DisplayAlert("ACEPT", "Ordenador Registrado", "Aceptar");
                Navigation.PopAsync();
            }
            else
            {

                DisplayAlert("CANCEL", "Ya existe un aula con ese Código", "Aceptar");

            }
            



        }
    }
}