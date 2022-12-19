using Acr.UserDialogs;
using ControlGastos.Modelo;
using ControlGastos.Utilidades;
using Rg.Plugins.Popup.Services;
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
        private bool _userTapped;
        Metodos metodos = new Metodos();
        ModalEmojis modalEmojis = new ModalEmojis();


        public ConfiguracionPage()
        {
            InitializeComponent();
            TxtTokenCompa.Text = App.tokenCompa;
            TxtToken.Text = App.token;
            GetEmojiCompra();
            GetEmojiTuyo();
           
            FrameEmoji.GestureRecognizers.Add(
           new TapGestureRecognizer()
           {
               Command = new Command(async () =>
               {
                   if (_userTapped)
                       return;

                   _userTapped = true;
                   modalEmojis = new ModalEmojis();
                   modalEmojis.OnLLamarOtraPantalla += ModalEmojis_OnLLamarOtraPantalla;
                   //modalTournament.Disappearing += ModalTournament_Disappearing;

                   await PopupNavigation.PushAsync(modalEmojis);
                   await Task.Delay(1000);
                   _userTapped = false;
                   Opacity = 1;
               }),
               NumberOfTapsRequired = 1

           }
         );
        }

        public async void GetEmojiCompra()
        {
            var EmojiCompa = await metodos.GetEmoji(App.tokenCompa);
            App.emojiCompa = EmojiCompa.emoji;

          
            if (App.emojiCompa == "3")
            {
                IMGMoodCompa.Source = "enamorado.png";
            }
            else if (App.emojiCompa == "2")
            {
                IMGMoodCompa.Source = "desconcertado.png";
            }
            else if (App.emojiCompa == "1")
            {
                IMGMoodCompa.Source = "enojado.png";
            }
            else if (App.emojiCompa == "4")
            {
                IMGMoodCompa.Source = "llorando.png";
            }
            else if (App.emojiCompa == "5")
            {
                IMGMoodCompa.Source = "mareado.png";
            }
            else if (App.emojiCompa == "6")
            {
                IMGMoodCompa.Source = "pensar.png";
            }
            else if (App.emojiCompa == "7")
            {
                IMGMoodCompa.Source = "sorpresa.png";
            }

        }

        public async void GetEmojiTuyo()
        {
            var EmojiTuyo = await metodos.GetEmoji(App.token);
            App.emojiTuyo = EmojiTuyo.emoji;

            if (App.emojiTuyo == "3")
            {
                IMGMood.Source = "enamorado.png";
            }
            else if (App.emojiTuyo == "2")
            {
                IMGMood.Source = "desconcertado.png";
            }
            else if (App.emojiTuyo == "1")
            {
                IMGMood.Source = "enojado.png";
            }
            else if (App.emojiTuyo == "4")
            {
                IMGMood.Source = "llorando.png";
            }
            else if (App.emojiTuyo == "5")
            {
                IMGMood.Source = "mareado.png";
            }
            else if (App.emojiTuyo == "6")
            {
                IMGMood.Source = "pensar.png";
            }
            else if (App.emojiTuyo == "7")
            {
                IMGMood.Source = "sorpresa.png";
            }

        }

        private void ModalEmojis_OnLLamarOtraPantalla(object sender, EventArgs e)
        {
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, TxtTokenCompa.Text, App.emojiTuyo);
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
                toastConfig.MostrarNotificacion($"El token no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");

            }

        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Informacion", "¿Deseas cerrar sesión?", "Si", "No"))
            {
                DatosConfiguracion.GrabarDatosSesion("", "", "S");
                await Navigation.PushModalAsync(new LoginPage());
                DatosConfiguracion.EliminarDatosSesion();
            }
        }

        private void BtnCopiarToken_Clicked(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(TxtToken.Text);
            toastConfig.MostrarNotificacion($"Token Copiado.", ToastPosition.Top, 3, "#3A944A");


        }
    }
}