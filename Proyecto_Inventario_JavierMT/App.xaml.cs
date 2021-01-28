using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Inventario_JavierMT.View;
using Proyecto_Inventario_JavierMT.DataBase;
namespace Proyecto_Inventario_JavierMT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var x = DataBase_Inventario.ConectionDatabase;
            MainPage = new NavigationPage(new PaginaPrincipal_V());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
