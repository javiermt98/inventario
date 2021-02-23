using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Inventario_JavierMT.ViewModel;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;

namespace Proyecto_Inventario_JavierMT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAulas_V : ContentPage
    {
        private ListaAulas_VM vm;
        private Aula_M aulaanterior;
        
        public ListaAulas_V()
        {
            
            InitializeComponent();
            vm = new ListaAulas_VM();
            BindingContext = vm;


        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if(aulaanterior != null) {

                aulaanterior.activada = false;
            }

                aulaanterior = vm.AulaSeleccionada;
                vm.AulaSeleccionada.activada = true;
            
            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        private void Add(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new AulaDetalle_V(vm.AulaSeleccionada));
            

        }

        private async void Borrar(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Borrar", "Esta seguro de que quiere borrar", "Si", "No");
            if (answer)
            {
                vm.BorrarVM();
            }

        }

        private void Sort(object sender, EventArgs e)
        {

        }

        private void Editar(object sender, EventArgs e)
        {
            Provider.auladeldispositivo = vm.AulaSeleccionada;
            Navigation.PushAsync(new ListaDispositivos_V());
            
        }

        protected override void OnAppearing()
        {
            vm.Recargar();
            base.OnAppearing();
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            vm.TextFilter(searchbar.Text);
        }
    }
}
