﻿using ControlGastos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlGastos.Modelo
{
    public class Metodos
    {
        Herramientas.Herramientas herramientas = new Herramientas.Herramientas();

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
            }

            return usuario;
        } // Fin del método ObtenerVerbos


        public async Task<List<EGastosIngresos>> GetControlGastosIngresos(string token)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/Scontrolgastosapptokens/{token}");
            var listado_Posiciones = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EGastosIngresos>>(result);

            return listado_Posiciones;
        } // Fin del método ObtenerTablaDePosiciones


        public async Task<ETokens> UToken(int idControlGastosAppTokens, string token, string nombre, string nombrepersonaentrante)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Productos/UToken/{idControlGastosAppTokens}/{token.ToUpper()}/{nombre.ToUpper()}/{nombrepersonaentrante.ToUpper()}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ETokens>(result);
            return response;
        }


    }
}
