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
    public partial class ConfiguracionPage : ContentPage
    {
        Metodos metodos = new Metodos();
        public ConfiguracionPage()
        {
            InitializeComponent();
            TxtTokenCompa.Text = App.tokenCompa;
            TxtToken.Text = App.token;
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, TxtTokenCompa.Text);
            if (Register.respuesta == "OK")
            {
                await DisplayAlert("Alert", "Greattttt", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "You have been alerted", "OK");
            }
        }
    }
}