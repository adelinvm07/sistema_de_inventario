using System;
using System.IO;

namespace SistemaInventario.Entidades.Utilidades
{
    public class Logger
    {
        private static readonly string CarpetaLogs = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SistemaInventario");

        public static readonly string ArchivoLogger = Path.Combine(CarpetaLogs, "errores.log");

        /// <summary>
        /// Guarda el error sin interrumpir la aplicación si no se puede escribir.
        /// </summary>
        public static void RegistrarLog(Exception ex)
        {
            try
            {
                Directory.CreateDirectory(CarpetaLogs);
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] ERROR{Environment.NewLine}" +
                    ex.ToString() + Environment.NewLine + Environment.NewLine;
                File.AppendAllText(ArchivoLogger, mensaje);
            }
            catch (IOException)
            {
                // Un fallo al escribir el registro no debe cerrar la aplicación.
            }
            catch (UnauthorizedAccessException)
            {
                // La aplicación puede continuar aunque no tenga permiso para escribir.
            }
        }
    }
}
