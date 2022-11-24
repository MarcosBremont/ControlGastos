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
    public partial class RegistroPage : ContentPage
    {
        ToastConfigClass toastConfig = new ToastConfigClass();

        Metodos metodos = new Metodos();
        public RegistroPage()
        {
            InitializeComponent();

            LayoutLogin.GestureRecognizers.Add(
            new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PopModalAsync();
                    await Task.Delay(1000);
                    Opacity = 1;
                }),
                NumberOfTapsRequired = 1

            }
          );
        }
        private async void BtnAtrasSettings_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Cargando...");
            await Navigation.PopModalAsync();
            UserDialogs.Instance.HideLoading();
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

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Creating your account, wait a minute");
                if (string.IsNullOrEmpty(TxtUsername.Text))
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast("Fill in the Name to continue");
                    TxtUsername.Focus();
                }

                else if (string.IsNullOrEmpty(TxtPassword.Text))
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast("Fill in the Password to continue");
                    TxtPassword.Focus();
                }
                else
                {
                    string tokengenerado = Guid.NewGuid().ToString();
                    var apiResult = await metodos.CrearCuenta(TxtUsername.Text, TxtPassword.Text, tokengenerado);

                    if (apiResult.Respuesta == "OK")
                    {
                        toastConfig.MostrarNotificacion($"Cuenta creada, ahora puedes iniciar sesión", ToastPosition.Top, 3, "#51C560");
                        TxtUsername.Text = "";
                        TxtPassword.Text = "";
                    }
                    else
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Toast("Error, por favor verifica tu conexión a internet");
                    }
                }

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Error, por favor verifica tu conexión a internet");
            }
        }

    }
}