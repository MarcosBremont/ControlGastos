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
        private bool _userTapped;
        RegistroPage registerPage = new RegistroPage();


        public LoginPage()
        {
            InitializeComponent();

            SignUpHere.GestureRecognizers.Add(
           new TapGestureRecognizer()
           {
               Command = new Command(async () =>
               {
                   if (_userTapped)
                       return;

                   _userTapped = true;
                   registerPage = new RegistroPage();
                     //registerPage.OnLLamarOtraPantalla += ModalTournament_OnLLamarOtraPantalla;

                     await Navigation.PushModalAsync(registerPage);
                   await Task.Delay(1000);
                   _userTapped = false;
                   Opacity = 1;
               }),
               NumberOfTapsRequired = 1

           }
         );
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
                    toastConfig.MostrarNotificacion($"El usuario y la contraseña son obligatorias.", ToastPosition.Top, 3, "#e63946");
                }
                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Loading();
                    var result = await metodos.IniciarSesion(TxtUsername.Text.ToUpper(), TxtPassword.Text.ToUpper());
                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();


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
                        toastConfig.MostrarNotificacion($"Hubo un error a la hora de iniciar sesión.", ToastPosition.Top, 3, "#e63946");
                    }
                }


            }
            catch (Exception ex)
            {
                toastConfig.MostrarNotificacion($"Hubo un error a la hora de iniciar sesión.", ToastPosition.Top, 3, "#e63946");
            }


        }
    }
}