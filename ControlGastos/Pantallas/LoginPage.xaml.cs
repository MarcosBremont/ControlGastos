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
    public partial class LoginPage : ContentPage
    {
        ToastConfigClass toastConfig = new ToastConfigClass();
        Metodos metodos = new Metodos();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void eye_Clicked(object sender, EventArgs e)
        {
            eyecrossed.IsVisible = true;
            eye.IsVisible = false;
            TxtPassword.IsPassword = false;

        }

        private void eyecrossed_Clicked(object sender, EventArgs e)
        {

            eye.IsVisible = true;
            eyecrossed.IsVisible = false;
            TxtPassword.IsPassword = true;
        }


        void BtnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            IniciarSesion();

        }

        public async void IniciarSesion()
        {

            try
            {

                if (string.IsNullOrEmpty(TxtUsername.Text) || string.IsNullOrEmpty(TxtPassword.Text))
                {
                    await DisplayAlert("Alert", "You have been alerted", "OK");

                    //toastConfig.MostrarNotificacion($"El usuario y la contraseña son obligatorias.", ToastPosition.Top, 3, "#e63946");
                }
                else
                {
                    var result = await metodos.IniciarSesion(TxtUsername.Text.ToUpper(), TxtPassword.Text.ToUpper());


                    if (result.respuesta == "OK")
                    {
                        App.token = result.tokens;
                        App.nombre = result.nombre;
                        App.tokenCompa = result.nombrepersonaentrante;
                        App.idControlGastosAppTokens = result.idControlGastosAppTokens;
                        //toastConfig.MostrarNotificacion($"Welcome {result.name}", ToastPosition.Top, 3, "#51C560");
                        await Navigation.PushModalAsync(new TabbedPagePrincipal());
                        DatosConfiguracion.GrabarDatosSesion(TxtUsername.Text, TxtPassword.Text, "N");

                    }
                    else
                    {
                        await DisplayAlert("Alert", "You have been alerted", "OK");

                        //toastConfig.MostrarNotificacion($"the information is not correct, please check again.", ToastPosition.Top, 4, "#e63946");
                    }
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", "You have been alerted", "OK");

                //toastConfig.MostrarNotificacion($"The connection could not be established, please try again later.", ToastPosition.Top, 4, "#e63946");
            }


        }
    }
}