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
    public partial class ListaAulas_V : ContentPage
    {
        private ListaAulas_VM vm;
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
            Aula_M aulaseleccionada = (Aula_M)e.Item;
            aulaseleccionada = vm.AulaSeleccionada;

            

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        private void Add(object sender, EventArgs e)
        {
            vm.AddVM();

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

        private void ActivaBorrar(object sender, EventArgs e)
        {
            vm.CambiaBoton();
        }
    }
}
