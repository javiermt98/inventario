﻿using System;
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
    public partial class ListaImpresoras_V : ContentPage
    {
        private ListaImpresoras_VM vm;
        private Impresora_M impresoraanterior;
        public ListaImpresoras_V()
        {
            InitializeComponent();
            vm = new ListaImpresoras_VM();
            BindingContext = vm;



        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (impresoraanterior != null)
            {

                impresoraanterior.activada = false;
            }

            impresoraanterior = vm.ImpresoraSeleccionada;
            vm.ImpresoraSeleccionada.activada = true;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void Editar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImpresoraDetalle_V(vm.ImpresoraSeleccionada));

        }

        private void Borrar(object sender, EventArgs e)
        {

        }

        private void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImpresoraDetalle_V(new Impresora_M()));
        }
        protected override void OnAppearing()
        {
            vm.Recargar();
            base.OnAppearing();
        }
    }
}