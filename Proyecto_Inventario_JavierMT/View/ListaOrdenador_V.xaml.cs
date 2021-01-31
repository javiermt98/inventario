using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Inventario_JavierMT.ViewModel;

namespace Proyecto_Inventario_JavierMT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaOrdenador_V : ContentPage
    {
        private ListaOrdenador_VM vm;

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

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void Editar(object sender, EventArgs e)
        {

        }

        private void Borrar(object sender, EventArgs e)
        {

        }

        private void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrdenadorDetalle_V());
        }
    }
}
