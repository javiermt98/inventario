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
        private AulaDetalle_VM vm ;
        public AulaDetalle_V(Aula_M aula)
        {
            InitializeComponent();
            if (aula == null)
            {
                vm = new AulaDetalle_VM();
                vm.AulaSeleccionada = new Aula_M();
            }
            else {
                vm = new AulaDetalle_VM { AulaSeleccionada = aula };
            }
            
            
            BindingContext = vm;
            

        }

        private async void Guardar(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(codigo.Text) && !String.IsNullOrWhiteSpace(nombre.Text) && !String.IsNullOrWhiteSpace(abrev.Text) && !String.IsNullOrWhiteSpace(lvl.Text))
            {
                //Aula_M aula = new Aula_M(Convert.ToInt32(codigo.Text), nombre.Text, abrev.Text, lvl.Text);
                if (vm.ComprobarAula())
                {
                    vm.AddVM();
                    await DisplayAlert("ACEPT", "Aula creada", "ACEPTAR");
                    await Navigation.PopAsync();
                }
                else
                {

                    if (await DisplayAlert("WARNING", "Ya existe un aula con ese Código,¿ Desea sobreescribir el aula ?", "ACTUALIZAR", "CANCELAR"))
                    {
                        await DisplayAlert("ACEPTAR", "Aula sobreescrita", "ACEPTAR");
                        vm.AddVM();
                    }
                    else {
                        await DisplayAlert("CANCEL", "No se ha sobreescrito el aula", "ACEPTAR");
                    }
                    
                    
                }
            }
            else {
               await DisplayAlert("CANCEL", "No puedes dejar campos en blanco", "ACEPTAR");
            }
           
            
        }



        private void Reset(object sender, EventArgs e)
        {
            vm.AulaSeleccionada = new Aula_M();
        }
    }
}
