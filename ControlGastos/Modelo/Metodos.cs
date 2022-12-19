using ControlGastos.Modelo.Entidades;
using ControlGastos.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlGastos.Modelo
{
    public class Metodos
    {
        Herramientas herramientas = new Herramientas();

        public Metodos()
        {
            // constructor
        }
        public async Task<EGastosIngresos> IGastoIngreso(string mes, string dinero, string descripcion, string nombrepersonaentrante, string gastoingreso)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/IControlGastos/{mes.ToUpper()}/{dinero.ToUpper()}/{descripcion.ToUpper()}/{nombrepersonaentrante.ToUpper()}/{gastoingreso.ToUpper()}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<EGastosIngresos>(result);
            return response;
        }


        public async Task<ETokens> GetTokens(string tokens)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/STokens/{tokens}");
            var Tokens = Newtonsoft.Json.JsonConvert.DeserializeObject<ETokens>(result);

            if (Tokens.respuesta == "OK")
            {
                App.tokens = Tokens.tokens;
                App.nombre = Tokens.nombre;
                App.nombrepersonaentrante = Tokens.nombrepersonaentrante;
            }

            return Tokens;
        } // Fin del método ObtenerVerbos


        public async Task<ETokens> IToken(string token, string nombre, string nombrepersonaentrante)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/ITokens/{token.ToUpper()}/{nombre.ToUpper()}/{nombrepersonaentrante.ToUpper()}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ETokens>(result);
            return response;
        }


        public async Task<EUsuario> IniciarSesion(string nombre, string contrasena)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/InicioSesion/{nombre}/{contrasena}");
            var usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<EUsuario>(result);

            if (usuario.respuesta == "OK")
            {
                App.nombre = usuario.nombre;
                App.token = usuario.tokens;
                App.clave = usuario.clave;
                App.emojiTuyo = usuario.emoji;
            }


            return usuario;
        } // Fin del método ObtenerVerbos


        public async Task<List<EGastosIngresos>> GetControlGastosIngresos(string token)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/Scontrolgastosapptokens/{token}");
            var listado_Posiciones = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EGastosIngresos>>(result);

            return listado_Posiciones;
        } // Fin del método ObtenerTablaDePosiciones

        public async Task<ETokens> GetEmoji(string token)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/SEmoji/{token}");
            var Emoji = Newtonsoft.Json.JsonConvert.DeserializeObject<ETokens>(result);

            return Emoji;
        } // Fin del método ObtenerTablaDePosiciones

        public async Task<ETokens> UToken(int idControlGastosAppTokens, string token, string nombre, string nombrepersonaentrante, string emoji)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/UToken/{idControlGastosAppTokens}/{token.ToUpper()}/{nombre.ToUpper()}/{nombrepersonaentrante.ToUpper()}/{emoji}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ETokens>(result);
            return response;
        }

        public async Task<ETokens> UEmoji(string nombrepersonaentrante, string emoji)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/UEmoji/{nombrepersonaentrante.ToUpper()}/{emoji.ToUpper()}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ETokens>(result);
            return response;
        }

        public async Task<Result> CrearCuenta(string nombre, string clave, string tokens)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/RegistrarUsuario/{nombre.ToUpper()}/{clave.ToUpper()}/{tokens.ToUpper()}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(result);
            return response;
        }


        public async Task<List<EGastosIngresos>> GetGastos(string gastoingreso, string nombrepersonaentrante)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/SGastos/{gastoingreso}/{nombrepersonaentrante}");
            var Gastos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EGastosIngresos>>(result);

            return Gastos;
        } // Fin del método ObtenerTablaDePosiciones


        public async Task<List<EGastosIngresos>> GetIngresos(string gastoingreso, string nombrepersonaentrante)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/SIngresos/{gastoingreso}/{nombrepersonaentrante}");
            var Ingresos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EGastosIngresos>>(result);

            return Ingresos;
        } // Fin del método ObtenerTablaDePosiciones

        public async Task<List<EGastosIngresos>> DIngresosGastos(int idControlGastosApp)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/DIngresosGastos/{idControlGastosApp}");
            var list_gastosinngresos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EGastosIngresos>>(result);

            return list_gastosinngresos;
        } // Fin del método Obtener Vocabularios

    }
}
