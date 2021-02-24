using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Inventario_JavierMT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaRouters_V : ContentPage
    {
        private ListaRouters_VM vm;
        private Router_M routeranterior;
        public ListaRouters_V()
        {
            vm = new ListaRouters_VM();
            BindingContext = vm;
            InitializeComponent();

            
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;


            if (routeranterior != null)
            {

                routeranterior.activada = false;
            }

            routeranterior = vm.RouterSeleccionado;
            vm.RouterSeleccionado.activada = true;
            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        private async void Borrar(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Borrar", "Esta seguro de que quiere borrar", "Si", "No");
            if (answer)
            {
                vm.BorrarVM();
            }

        }

        private void Editar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RouterDetalle_V(routeranterior, routeranterior.dispositivo));
        }

        private void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RouterDetalle_V(new Router_M(), new Dispositivo()));
        }
        protected override void OnAppearing()
        {
            vm.Recargar();
            base.OnAppearing();
        }
    }
}
