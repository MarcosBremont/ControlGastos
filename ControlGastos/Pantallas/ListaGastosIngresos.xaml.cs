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
            //Anuncio.IsVisible = true;

            try
            {
                //using (UserDialogs.Instance.Loading("loading", null, null, true, MaskType.Black))
                //{
                var datos = await metodos.GetControlGastosIngresos(App.token);
                lsv_TablaPuntuacion.ItemsSource = datos;

                var datosCompanero = await metodos.GetControlGastosIngresos(App.tokenCompa);
                lsv_TablaPuntuacion2.ItemsSource = datosCompanero;
                //}
            }
            catch (Exception ex)
            {
                //Acr.UserDialogs.UserDialogs.Instance.Toast("Please check your internet connection");
            }

        }
    }
}