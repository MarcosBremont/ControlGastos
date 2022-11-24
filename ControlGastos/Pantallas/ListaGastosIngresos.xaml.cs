using Acr.UserDialogs;
using ControlGastos.Herramientas;
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
        ToastConfigClass toastConfig = new ToastConfigClass();

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
            toastConfig.MostrarNotificacion($"Datos cargados nuevamente.", ToastPosition.Top, 3, "#3A944A");

        }

        public async void Refresh()
        {
            var datos = await metodos.GetControlGastosIngresos(App.token);
            lsv_TablaPuntuacion.ItemsSource = datos;

            var Gastos = await metodos.GetControlGastosIngresos(App.tokenCompa);
            lsv_TablaPuntuacion2.ItemsSource = Gastos;


            var datosGastos = await metodos.GetGastos("G", App.token);
            LblTotalGastos.Text = datosGastos[0].Gastos.ToString();

            var datosIngresos = await metodos.GetIngresos("I", App.token);
            LblIngresos.Text = datosIngresos[0].ingresos.ToString();

            var datosGastosCompanero = await metodos.GetGastos("G", App.tokenCompa);
            LblTotalGastosCompa.Text = datosGastosCompanero[0].Gastos.ToString();

            var datosIngresosCompanero = await metodos.GetIngresos("I", App.tokenCompa);
            LblTotalIngresosCompa.Text = datosIngresosCompanero[0].ingresos.ToString();


        }
    }
}