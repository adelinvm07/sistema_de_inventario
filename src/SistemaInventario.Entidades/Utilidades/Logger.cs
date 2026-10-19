using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SistemaInventario.Entidades.Utilidades
{
    public class Logger
    {
        public static readonly string ArchivoLogger = "errores.log";
        public static void RegistrarLog(Exception ex)
        {
            //Falta colocarle los niveles
            string mensaje = $"[{DateTime.Now:dd/MM/yyyy hh:mm:ss tt} error level ] " +
                $"{ex.Message} ({ex.StackTrace}) {Environment.NewLine}";

            File.AppendAllText(ArchivoLogger, mensaje);  
        }
    }
}
