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
    public partial class ListaMonitores_V : ContentPage
    {
        private ListaMonitores_VM vm;
        private Monitor_M monitoranterior;

        public ListaMonitores_V()
        {
            vm = new ListaMonitores_VM();
            BindingContext = vm;
            InitializeComponent();

           
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;


            if (monitoranterior != null)
            {

                monitoranterior.activada = false;
            }

            monitoranterior = vm.MonitorSeleccionado;
            vm.MonitorSeleccionado.activada = true;
            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        private void Borrar(object sender, EventArgs e)
        {

        }

        private void Editar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MonitorDetalle_V(vm.MonitorSeleccionado));
        }

        private void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MonitorDetalle_V(new Monitor_M()));
        }

        protected override void OnAppearing()
        {
            vm.Recargar();
            base.OnAppearing();
        }
    }
}
