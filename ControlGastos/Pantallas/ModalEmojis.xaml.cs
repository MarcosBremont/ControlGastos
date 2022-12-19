using Acr.UserDialogs;
using ControlGastos.Modelo;
using Plugin.Permissions.Abstractions;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static ControlGastos.Utilidades.Herramientas;
using ControlGastos.Utilidades;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using ControlGastos.Modelo.Entidades;
using Rg.Plugins.Popup.Services;

namespace ControlGastos.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalEmojis : Rg.Plugins.Popup.Pages.PopupPage
    {
        public event EventHandler OnLLamarOtraPantalla;
        private bool _userTapped;
        Metodos metodos = new Metodos();
        ToastConfigClass toastConfig = new ToastConfigClass();
        private object fileSelectedPath;
        private bool busy;
        public ModalEmojis()
        {
            InitializeComponent();

            ImgEnamorado1.GestureRecognizers.Add(
            new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    if (_userTapped)
                        return;

                    _userTapped = true;

                    try
                    {
                        var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, App.tokenCompa, "1");
                        if (Register.respuesta == "OK")
                        {
                            toastConfig.MostrarNotificacion($"Emoji Guardado.", ToastPosition.Top, 3, "#3A944A");
                        }
                        else
                        {
                            toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                        }
                    }
                    catch (Exception ex)
                    {
                        toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                    }

                    await Task.Delay(1000);
                    _userTapped = false;
                    Opacity = 1;
                }),
                NumberOfTapsRequired = 1

            }
        );

            Imgdesconcertado2.GestureRecognizers.Add(
            new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    if (_userTapped)
                        return;

                    _userTapped = true;

                    try
                    {
                        var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, App.tokenCompa, "2");
                        if (Register.respuesta == "OK")
                        {
                            toastConfig.MostrarNotificacion($"Emoji Guardado.", ToastPosition.Top, 3, "#3A944A");
                        }
                        else
                        {
                            toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                        }
                    }
                    catch (Exception ex)
                    {
                        toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                    }

                    await Task.Delay(1000);
                    _userTapped = false;
                    Opacity = 1;
                }),
                NumberOfTapsRequired = 1

            }
        );

            Imgenojado3.GestureRecognizers.Add(
           new TapGestureRecognizer()
           {
               Command = new Command(async () =>
               {
                   if (_userTapped)
                       return;

                   _userTapped = true;

                   try
                   {
                       var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, App.tokenCompa, "3");
                       if (Register.respuesta == "OK")
                       {
                           toastConfig.MostrarNotificacion($"Emoji Guardado.", ToastPosition.Top, 3, "#3A944A");
                       }
                       else
                       {
                           toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                       }
                   }
                   catch (Exception ex)
                   {
                       toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                   }

                   await Task.Delay(1000);
                   _userTapped = false;
                   Opacity = 1;
               }),
               NumberOfTapsRequired = 1

           }
       );

            Imgllorando.GestureRecognizers.Add(
          new TapGestureRecognizer()
          {
              Command = new Command(async () =>
              {
                  if (_userTapped)
                      return;

                  _userTapped = true;

                  try
                  {
                      var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, App.tokenCompa, "4");
                      if (Register.respuesta == "OK")
                      {
                          toastConfig.MostrarNotificacion($"Emoji Guardado.", ToastPosition.Top, 3, "#3A944A");
                      }
                      else
                      {
                          toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                      }
                  }
                  catch (Exception ex)
                  {
                      toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                  }

                  await Task.Delay(1000);
                  _userTapped = false;
                  Opacity = 1;
              }),
              NumberOfTapsRequired = 1

          }
      );

            Imgmareado.GestureRecognizers.Add(
            new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    if (_userTapped)
                        return;

                    _userTapped = true;

                    try
                    {
                        var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, App.tokenCompa, "5");
                        if (Register.respuesta == "OK")
                        {
                            toastConfig.MostrarNotificacion($"Emoji Guardado.", ToastPosition.Top, 3, "#3A944A");
                        }
                        else
                        {
                            toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                        }
                    }
                    catch (Exception ex)
                    {
                        toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                    }

                    await Task.Delay(1000);
                    _userTapped = false;
                    Opacity = 1;
                }),
                NumberOfTapsRequired = 1

            }
        );

            Imgpensar.GestureRecognizers.Add(
           new TapGestureRecognizer()
           {
               Command = new Command(async () =>
               {
                   if (_userTapped)
                       return;

                   _userTapped = true;

                   try
                   {
                       var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, App.tokenCompa, "6");
                       if (Register.respuesta == "OK")
                       {
                           toastConfig.MostrarNotificacion($"Emoji Guardado.", ToastPosition.Top, 3, "#3A944A");
                       }
                       else
                       {
                           toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                       }
                   }
                   catch (Exception ex)
                   {
                       toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                   }

                   await Task.Delay(1000);
                   _userTapped = false;
                   Opacity = 1;
               }),
               NumberOfTapsRequired = 1

           }
       );

            Imgsospresa.GestureRecognizers.Add(
       new TapGestureRecognizer()
       {
           Command = new Command(async () =>
           {
               if (_userTapped)
                   return;

               _userTapped = true;

               try
               {
                   var Register = await metodos.UToken(App.idControlGastosAppTokens, App.token, App.nombre, App.tokenCompa, "7");
                   if (Register.respuesta == "OK")
                   {
                       toastConfig.MostrarNotificacion($"Emoji Guardado.", ToastPosition.Top, 3, "#3A944A");
                   }
                   else
                   {
                       toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
                   }
               }
               catch (Exception ex)
               {
                   toastConfig.MostrarNotificacion($"El Emoji no se pudo guardar.", ToastPosition.Top, 3, "#3A944A");
               }

               await Task.Delay(1000);
               _userTapped = false;
               Opacity = 1;
           }),
           NumberOfTapsRequired = 1

       }
   );

        }

        private async void BtnVolverAtras_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();

        }
    }
}