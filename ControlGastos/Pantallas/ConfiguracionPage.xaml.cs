using Acr.UserDialogs;
using ControlGastos.Herramientas;
using ControlGastos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlGastos.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracionPage : ContentPage
    {
        ToastConfigClass toastConfig = new ToastConfigClass();

        Metodos metodos = new Metodos();
        public ConfiguracionPage()
        {
            InitializeComponent();
            TxtTokenCompa.Text = App.tokenCompa;
            TxtToken.Text = App.token;
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, TxtTokenCompa.Text);
                if (Register.respuesta == "OK")
                {
                    toastConfig.MostrarNotificacion($"Guardando Token.", ToastPosition.Top, 3, "#3A944A");
                }
                else
                {
                    toastConfig.MostrarNotificacion($"El token no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Informacion", "¿Deseas cerrar sesión?", "Si", "No"))
            {
                await Navigation.PushModalAsync(new LoginPage());
            }
        }

        private void BtnCopiarToken_Clicked(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(TxtToken.Text);
            toastConfig.MostrarNotificacion($"Token Copiado.", ToastPosition.Top, 3, "#3A944A");


        }
    }
}