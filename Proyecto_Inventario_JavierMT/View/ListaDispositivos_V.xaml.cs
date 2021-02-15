using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.ViewModel;
using Proyecto_Inventario_JavierMT.View;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Inventario_JavierMT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaDispositivos_V : TabbedPage
    {
        private ListaDispositivos_VM vm;

        public ListaDispositivos_V()
        {
            vm = new ListaDispositivos_VM();
            InitializeComponent();
            Children.Add(new ListaOrdenador_V());

        }


    }
}
