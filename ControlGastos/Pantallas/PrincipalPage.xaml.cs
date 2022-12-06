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
    public partial class PrincipalPage : ContentPage
    {
        ToastConfigClass toastConfig = new ToastConfigClass();
        Metodos metodos = new Metodos();
        public PrincipalPage()
        {
            InitializeComponent();
        }

        private void PickerMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.mes = PickerMes.SelectedItem.ToString();
        }

        private void PickerMes2_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.mes2 = PickerMes2.SelectedItem.ToString();
        }


        private async void BtnGastos_Clicked(object sender, EventArgs e)
        {
            try
            {


                if (PickerMes.SelectedItem == null)
                {
                    toastConfig.MostrarNotificacion($"Primero seleccione un mes.", ToastPosition.Top, 3, "#e63946");
                }
                else if (string.IsNullOrEmpty(TxtGastos.Text))
                {
                    toastConfig.MostrarNotificacion($"Primero digita un gasto.", ToastPosition.Top, 3, "#e63946");
                    TxtGastos.Focus();
                }
                else if (string.IsNullOrEmpty(TxtDescripcion.Text))
                {
                    toastConfig.MostrarNotificacion($"Primero digita la descripcion.", ToastPosition.Top, 3, "#e63946");
                    TxtDescripcion.Focus();
                }
                else
                {
                    var Register = await metodos.IGastoIngreso(App.mes, TxtGastos.Text, TxtDescripcion.Text, App.token, "G");

                    if (Register.respuesta == "OK")
                    {
                        toastConfig.MostrarNotificacion($"Gasto ingresado con exito.", ToastPosition.Top, 3, "#3A944A");
                        TxtDescripcion.Text = "";
                        TxtGastos.Text = "";
                        PickerMes.SelectedItem = "";

                    }
                    else
                    {
                        toastConfig.MostrarNotificacion($"No se pudo ingresar el gasto en este momento, intente mas tarde.", ToastPosition.Top, 3, "#e63946");
                    }
                }
            }
            catch (Exception ex)
            {
                toastConfig.MostrarNotificacion($"No se pudo ingresar el gasto en este momento, intente mas tarde.", ToastPosition.Top, 3, "#e63946");

            }
        }

        private async void BtnIngresos_Clicked(object sender, EventArgs e)
        {

            try
            {


                if (PickerMes2.SelectedItem == null)
                {
                    toastConfig.MostrarNotificacion($"Primero seleccione un mes.", ToastPosition.Top, 3, "#e63946");
                }
                else if (string.IsNullOrEmpty(TxtGastos2.Text))
                {
                    toastConfig.MostrarNotificacion($"Primero digita un gasto.", ToastPosition.Top, 3, "#e63946");
                    TxtGastos2.Focus();
                }
                else if (string.IsNullOrEmpty(TxtDescripcion2.Text))
                {
                    toastConfig.MostrarNotificacion($"Primero digita la descripcion.", ToastPosition.Top, 3, "#e63946");
                    TxtDescripcion2.Focus();
                }
                else
                {
                    var Register = await metodos.IGastoIngreso(App.mes2, TxtGastos2.Text, TxtDescripcion2.Text, App.token, "I");

                    if (Register.respuesta == "OK")
                    {
                        toastConfig.MostrarNotificacion($"Ingreso guardado con exito.", ToastPosition.Top, 3, "#3A944A");
                        TxtDescripcion2.Text = "";
                        TxtGastos2.Text = "";
                        PickerMes2.SelectedItem = "";
                    }
                    else
                    {
                        toastConfig.MostrarNotificacion($"No se pudo insertar el ingreso en este momento, intente mas tarde.", ToastPosition.Top, 3, "#3A944A");
                    }
                }
            }
            catch (Exception ex)
            {
                toastConfig.MostrarNotificacion($"No se pudo insertar el ingreso en este momento, intente mas tarde.", ToastPosition.Top, 3, "#3A944A");

            }
        }
    }
}