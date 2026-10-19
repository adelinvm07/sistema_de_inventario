using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Entidades
{
    public class ImagenCategoria : ClaseBase
    {
        public int IdCategoria { get; set; }
        public byte[] Datos { get; set; } 
    }
}
