using Acr.UserDialogs;
using ControlGastos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlGastos.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaGastosIngresos : ContentPage
    {
        Metodos metodos = new Metodos();
        public ListaGastosIngresos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            try
            {
                Refresh();
            }
            catch (Exception ex)
            {
            }

        }

        private void BtnRefrescar_Clicked(object sender, EventArgs e)
        {
            Refresh();
        }

        public async void Refresh()
        {
            var datos = await metodos.GetControlGastosIngresos(App.token);
            lsv_TablaPuntuacion.ItemsSource = datos;

            var datosCompanero = await metodos.GetControlGastosIngresos(App.tokenCompa);
            lsv_TablaPuntuacion2.ItemsSource = datosCompanero;
        }
    }
}