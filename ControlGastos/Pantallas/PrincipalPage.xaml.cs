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
            if (string.IsNullOrEmpty(TxtGastos.Text))
            {
                await DisplayAlert("Alerta", "Primero digita un gasto", "OK");
                TxtGastos.Focus();
            }
            else if (string.IsNullOrEmpty(TxtDescripcion.Text))
            {
                await DisplayAlert("Alerta", "Primero digita la descripcion", "OK");
                TxtDescripcion.Focus();
            }
            else
            {
                var Register = await metodos.IGastoIngreso(App.mes, TxtGastos.Text, TxtDescripcion.Text, App.token, "G");

                if (Register.respuesta == "OK")
                {
                    await DisplayAlert("Alerta", "Gasto ingresado con exito", "OK");

                    //toastConfig.MostrarNotificacion($"Listo", ToastPosition.Top, 3, "#3A944A");
                    TxtDescripcion.Text = "";
                    TxtGastos.Text = "";
                    PickerMes.Title = "Seleccione el mes";

                }
                else
                {
                    await DisplayAlert("Alerta", "No se pudo ingresar el gasto en este momento, intente mas tarde", "OK");

                    //toastConfig.MostrarNotificacion($"No fue posible guardar el gasto.", ToastPosition.Top, 3, "#e63946");
                }
            }
        }

        private async void BtnIngresos_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtGastos2.Text))
            {
                await DisplayAlert("Alerta", "Primero digita un gasto", "OK");
                TxtGastos2.Focus();
            }
            else if (string.IsNullOrEmpty(TxtDescripcion2.Text))
            {
                await DisplayAlert("Alerta", "Primero digita la descripcion", "OK");
                TxtDescripcion2.Focus();
            }
            else
            {
                var Register = await metodos.IGastoIngreso(App.mes2, TxtGastos2.Text, TxtDescripcion2.Text, App.token, "I");

                if (Register.respuesta == "OK")
                {
                    await DisplayAlert("Alerta", "Ingreso insertado con exito", "OK");

                    //toastConfig.MostrarNotificacion($"Listo", ToastPosition.Top, 3, "#3A944A");
                    TxtDescripcion2.Text = "";
                    TxtGastos2.Text = "";
                    PickerMes2.Title = "Seleccione el mes";
                }
                else
                {
                    await DisplayAlert("Alerta", "No se pudo insertar el ingreso en este momento, intente mas tarde", "OK");

                    //toastConfig.MostrarNotificacion($"No fue posible guardar el ingreso.", ToastPosition.Top, 3, "#e63946");
                }
            }
        }
    }
}