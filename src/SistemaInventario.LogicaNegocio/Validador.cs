using System.Text.RegularExpressions;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio;

public static class Validador
{
    // Revisa que el correo tenga un formato valido.
    private static bool ValidarEmail(string email)
    {
        if (String.IsNullOrEmpty(email))
            return false;

        string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }

    // Revisa que el telefono tenga el formato 809/829/849-XXX-XXXX.
    private static bool ValidarTelefono(string telefono)
    {
        if (String.IsNullOrEmpty(telefono))
            return false;

        string regex = @"^(809|829|849)-\d{3}-\d{4}$";
        return Regex.IsMatch(telefono, regex);
    }

    // Revisa que la URL sea valida. Si esta vacia es valida, porque el sitio web es opcional.
    private static bool ValidarUrl(string url)
    {
        if (String.IsNullOrEmpty(url))
            return true;

        string patron = @"^(https?://)?([\w-]+\.)+[\w-]{2,}(/.*)?$";
        return Regex.IsMatch(url, patron, RegexOptions.IgnoreCase);
    }

    // Revisa que el precio sea mayor a 0 y tenga maximo 2 decimales.
    private static bool ValidarPrecio(decimal precio)
    {
        if (precio > 0 && precio == Math.Round(precio, 2))
            return true;
        return false;
    }

    /// <summary>
    /// Revisa que el archivo exista, sea .jpg, .jpeg o .png y pese maximo 2 MB.
    /// </summary>
    public static bool ValidarImagen(string ruta)
    {
        if (String.IsNullOrWhiteSpace(ruta))
            return false;

        FileInfo info = new FileInfo(ruta);

        if (!info.Exists)
            return false;

        string extension = info.Extension.ToLower();

        if ((extension == ".png" || extension == ".jpg" || extension == ".jpeg") && info.Length <= 2 * 1024 * 1024)
            return true;
        return false;
    }

    //Validaciones por entidad

    /// <summary>
    /// Revisa el nombre y la descripción de la categoría.
    /// </summary>
    public static Dictionary<string, string> ValidarCategoria(Categoria c)
    {
        Dictionary<string, string> errores = new Dictionary<string, string>();

        if (String.IsNullOrWhiteSpace(c.Nombre))
            errores.Add("Nombre", "Coloque el nombre.");
        else if (c.Nombre.Length < 3)
            errores.Add("Nombre", "Nombre muy corto.");
        else if (c.Nombre.Length > 100)
            errores.Add("Nombre", "Nombre muy largo.");

        if (String.IsNullOrWhiteSpace(c.Descripcion))
            errores.Add("Descripcion", "Coloque una descripción.");
        else if (c.Descripcion.Length > 500)
            errores.Add("Descripcion", "Descripción muy larga.");

        return errores;
    }

    /// <summary>
    /// Revisa los datos de contacto del suplidor.
    /// </summary>
    public static Dictionary<string, string> ValidarSuplidor(Suplidores s)
    {
        Dictionary<string, string> errores = new Dictionary<string, string>();

        if (String.IsNullOrWhiteSpace(s.NombreEmpresa))
            errores.Add("NombreEmpresa", "Coloque el nombre de la empresa.");
        else if (s.NombreEmpresa.Length > 100)
            errores.Add("NombreEmpresa", "Nombre de la empresa muy largo.");

        if (String.IsNullOrWhiteSpace(s.NombreContacto))
            errores.Add("NombreContacto", "Coloque el nombre del contacto.");
        else if (s.NombreContacto.Length > 100)
            errores.Add("NombreContacto", "Nombre del contacto muy largo.");

        if (String.IsNullOrWhiteSpace(s.Telefono))
            errores.Add("Telefono", "Coloque el teléfono.");
        else if (!ValidarTelefono(s.Telefono))
            errores.Add("Telefono", "Teléfono inválido. Formato: 809-555-1234.");

        if (String.IsNullOrWhiteSpace(s.CorreoElectronico))
            errores.Add("CorreoElectronico", "Coloque el correo electrónico.");
        else if (s.CorreoElectronico.Length > 100)
            errores.Add("CorreoElectronico", "Correo electrónico muy largo.");
        else if (!ValidarEmail(s.CorreoElectronico))
            errores.Add("CorreoElectronico", "Correo electrónico inválido.");

        if (!ValidarUrl(s.SitioWeb))
            errores.Add("SitioWeb", "Sitio web inválido.");
        else if (s.SitioWeb != null && s.SitioWeb.Length > 200)
            errores.Add("SitioWeb", "Sitio web muy largo.");

        return errores;
    }
    /// <summary>
    /// Revisa el nombre, precio, categoría y suplidor del producto.
    /// </summary>
    public static Dictionary<string, string> ValidarProducto(Productos p)
    {
        Dictionary<string, string> errores = new Dictionary<string, string>();

        if (String.IsNullOrWhiteSpace(p.Nombre))
            errores.Add("Nombre", "Coloque el nombre del producto.");
        else if (p.Nombre.Length > 100)
            errores.Add("Nombre", "Nombre muy largo.");

        if (!ValidarPrecio(p.PrecioUnitario))
            errores.Add("PrecioUnitario", "El precio debe ser mayor a 0 y tener máximo 2 decimales.");

        if (p.IdCategoria <= 0)
            errores.Add("IdCategoria", "Seleccione una categoría.");

        if (p.IdSuplidor <= 0)
            errores.Add("IdSuplidor", "Seleccione un suplidor.");

        return errores;
    }
}