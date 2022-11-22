using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ControlGastos.Herramientas
{
    public class DatosConfiguracion
    {
        public static string UrlLogo { get; set; }
        public static string NombreEmpresa { get; set; }
        public static bool IsPrimeraVez { get; set; } = false;
        public static string UrlApi { get; set; }
        public static string urlsistemaonline { get; set; }
        public static string Telefono { get; set; }


        public async void Grabar(string url_api, string telefono)
        {
            try
            {
                string fileUrlApi = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "url_api");
                string fileTelefono = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "telefono");

                File.WriteAllText(fileUrlApi, url_api);
                File.WriteAllText(fileTelefono, telefono);
                //await this.LLenarConfiguracion();

            }
            catch (Exception)
            {

            }

        }
        public static void LLenarVariablesConfiguracion()
        {
            try
            {
                string fileUrlApi = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "url_api");
                string fileTelefono = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "telefono");
                DatosConfiguracion.UrlApi = File.ReadAllText(fileUrlApi);
                DatosConfiguracion.Telefono = File.ReadAllText(fileTelefono);
            }
            catch (Exception)
            {
                DatosConfiguracion.IsPrimeraVez = true;
            }
        }


        public static void GrabarDatosSesion(string email, string clave, string SiCierrasSesion)
        {
            try
            {
                string fileemail = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "email");
                string fileclave = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clave");
                string fileCerrarSesion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SiCierrasSesion");

                File.WriteAllText(fileemail, email);
                File.WriteAllText(fileclave, clave);
                File.WriteAllText(fileCerrarSesion, SiCierrasSesion);
            }
            catch (Exception)
            {

            }


        }


        public static void EliminarDatosSesion()
        {
            try
            {
                string fileemail = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "email");
                string fileclave = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clave");

                File.Delete(fileemail);
                File.Delete(fileclave);
            }
            catch (Exception)
            {

            }


        }
        public static Tuple<string, string, string> ObtenerDatosSesion()
        {
            string email = string.Empty, clave = string.Empty, SiCierrasSesion = string.Empty;
            try
            {
                string fileemail = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "email");
                string fileclave = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clave");
                string fileCerrarSesion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SiCierrasSesion");
                email = File.ReadAllText(fileemail);
                clave = File.ReadAllText(fileclave);
                SiCierrasSesion = File.ReadAllText(fileCerrarSesion);

            }
            catch (Exception ex)
            {

            }

            return Tuple.Create(email, clave, SiCierrasSesion);
        }

    }
}
