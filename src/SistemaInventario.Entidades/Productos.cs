using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Entidades
{
    public class Productos : ClaseBase
    {
        public int IdCategoria { get; set; }
        public int IdSuplidor { get; set; }
        public string NombreCategoria { get; set; } = "";
        public string NombreSuplidor { get; set; } = "";
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
