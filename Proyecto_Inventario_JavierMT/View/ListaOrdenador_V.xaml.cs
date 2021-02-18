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
    public partial class ListaOrdenador_V : ContentPage
    {
        private ListaOrdenador_VM vm;
        private Ordenador_M ordenadoranterior;

        public ListaOrdenador_V()
        {
            vm = new ListaOrdenador_VM();
            BindingContext = vm;
            InitializeComponent();


        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (ordenadoranterior != null)
            {

                ordenadoranterior.activada = false;
            }

            ordenadoranterior = vm.PcSeleccionado;
            vm.PcSeleccionado.activada = true;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void Editar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrdenadorDetalle_V(ordenadoranterior, ordenadoranterior.dispositivo));
        }

        private async void Borrar(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Borrar", "Esta seguro de que quiere borrar", "Si", "No");
            if (answer)
            {
                vm.BorrarVM();
            }

        }

        private void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrdenadorDetalle_V(new Ordenador_M(), new Dispositivo()));
        }

        protected override void OnAppearing()
        {
            vm.Recargar();
            base.OnAppearing();
        }
    }
}
