using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Agrega el Hola antes del string  ej. Hola Yael
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AgregarSaludo(this string s)
            => $"Hola {s}";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AgregarFecha(this string s)
            => $"{s} {DateTime.Now}";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string AgregarFecha(this string s,DateTime fecha)
           => $"{s} {fecha}";

        public static int HacerDoble(this int numero)
             => numero * 2;

    }
}
