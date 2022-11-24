using Acr.UserDialogs;
using ControlGastos.Herramientas;
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
    public partial class AhorrosPage : ContentPage
    {
        int cuantoGanas = 0;
        string CuandoAhorraras;
        double total = 0;
        ToastConfigClass toastConfig = new ToastConfigClass();

        public AhorrosPage()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Clicked(object sender, EventArgs e)
        {
            CuandoAhorraras = TxtAhorro.Text;

            cuantoGanas = Convert.ToInt32(TxtCuantoGanas.Text);

            if (string.IsNullOrEmpty(TxtAhorro.Text))
            {
                toastConfig.MostrarNotificacion($"Por favor llena todos los campos primero.", ToastPosition.Top, 3, "#e63946");
            }
            else if (string.IsNullOrEmpty(TxtCuantoGanas.Text))
            {
                toastConfig.MostrarNotificacion($"Por favor llena todos los campos primero.", ToastPosition.Top, 3, "#e63946");
            }
            else
            {
                total = cuantoGanas * Convert.ToDouble(CuandoAhorraras);
                LblAhorros.Text = "Tienes que guardar " + total.ToString() + " lo cual es el " + TxtAhorro.Text + " % de tu sueldo";
            }
        }


        private void BtnLimpiarCampos_Clicked(object sender, EventArgs e)
        {
            LblAhorros.Text = "";
            TxtAhorro.Text = "";
            TxtCuantoGanas.Text = "";
        }
    }
}