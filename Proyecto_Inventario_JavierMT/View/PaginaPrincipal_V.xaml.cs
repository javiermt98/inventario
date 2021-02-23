using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Inventario_JavierMT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal_V : ContentPage
    {

        public PaginaPrincipal_V()
        {
            InitializeComponent();

        }

        private void Aulas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaAulas_V());
        }

        private void Dispositivos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaDispositivos_V());
        }
    }
}
