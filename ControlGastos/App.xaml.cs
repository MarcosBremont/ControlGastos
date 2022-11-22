﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlGastos
{
    public partial class App : Application
    {
        public static string nombre { get; set; }
        public static string clave { get; set; }
        public static string token { get; set; }
        public static string mes { get; set; }
        public static string mes2 { get; set; }
        public static string tokens { get; set; }
        public static string nombrepersonaentrante { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new Pantallas.LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
