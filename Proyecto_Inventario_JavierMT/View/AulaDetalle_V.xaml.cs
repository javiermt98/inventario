using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Inventario_JavierMT.ViewModel;
using Proyecto_Inventario_JavierMT.Model;

namespace Proyecto_Inventario_JavierMT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AulaDetalle_V : ContentPage
    {
        private ListaAulas_VM vm;
        public AulaDetalle_V()
        {
            InitializeComponent();
            vm = new ListaAulas_VM();
            BindingContext = vm;
            

        }

        private void Guardar(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(codigo.Text) && !String.IsNullOrWhiteSpace(nombre.Text) && !String.IsNullOrWhiteSpace(abrev.Text) && !String.IsNullOrWhiteSpace(lvl.Text))
            {
                Aula_M aula = new Aula_M(Convert.ToInt32(codigo.Text), nombre.Text, abrev.Text, lvl.Text);
                if (vm.ComprobarAula(aula))
                {
                    vm.AddVM(aula);
                    DisplayAlert("ACEPT", "Aula creada", "Aceptar");
                    Navigation.PopAsync();
                }
                else
                {

                    DisplayAlert("CANCEL", "Ya existe un aula con ese Código", "Aceptar");

                }
            }
            else {
                DisplayAlert("CANCEL", "No puedes dejar campos en blanco", "Aceptar");
            }
           
            
        }
    }
}
