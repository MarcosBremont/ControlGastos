using Acr.UserDialogs;
using ControlGastos.Modelo;
using ControlGastos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace ControlGastos.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaGastosIngresos : ContentPage
    {
        ToastConfigClass toastConfig = new ToastConfigClass();
        public List<Modelo.Entidades.EGastosIngresos> ListPuntos { get; set; } = new List<Modelo.Entidades.EGastosIngresos>();

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
            lsv_gastoseingresos.ItemsSource = datos;

            var Gastos = await metodos.GetControlGastosIngresos(App.tokenCompa);
            lsv_gastoseinngresoscompa.ItemsSource = Gastos;


            var datosGastos = await metodos.GetGastos("G", App.token);
            LblTotalGastos.Text = datosGastos[0].Gastos.ToString();

            var datosIngresos = await metodos.GetIngresos("I", App.token);
            LblIngresos.Text = datosIngresos[0].ingresos.ToString();

            var datosGastosCompanero = await metodos.GetGastos("G", App.tokenCompa);
            LblTotalGastosCompa.Text = datosGastosCompanero[0].Gastos.ToString();

            var datosIngresosCompanero = await metodos.GetIngresos("I", App.tokenCompa);
            LblTotalIngresosCompa.Text = datosIngresosCompanero[0].ingresos.ToString();


            int totalingresos = Convert.ToInt32(LblIngresos.Text);

            int totalgastos = Convert.ToInt32(LblTotalGastos.Text);

            int totalcalculo = totalingresos - totalgastos;
            LblTotal.Text = totalcalculo.ToString();


            int totalingresosCompa = Convert.ToInt32(LblTotalIngresosCompa.Text);

            int totalgastosCompa = Convert.ToInt32(LblTotalGastosCompa.Text);

            int totalcalculoCompa = totalingresosCompa - totalgastosCompa;
            LblTotalCompa.Text = totalcalculoCompa.ToString();

        }

        async void lsv_gastoseingresos_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (await DisplayAlert("Information", "Estas seguro que deseas eliminar este dato?", "Si", "No"))
            {
                try
                {               
                    using (UserDialogs.Instance.Loading("loading", null, null, true, MaskType.Black))
                    {
                        var obj = (Modelo.Entidades.EGastosIngresos)e.SelectedItem;
                        var ide = Convert.ToInt32(obj.idControlGastosApp);

                        var datos = await metodos.DIngresosGastos(ide);
                        toastConfig.MostrarNotificacion($"Eliminado con exito.", ToastPosition.Top, 3, "#3A944A");

                    }
                }
                catch (Exception ex)
                {
                    //Acr.UserDialogs.UserDialogs.Instance.Toast("Please check your internet connection");
                }
            }
            Refresh();

        }
    }
}