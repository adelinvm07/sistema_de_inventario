using Microsoft.Data.SqlClient;

namespace SistemaInventario.AccesoDatos;

/// <summary>
/// Conexion a la base de datos utilizando el patron Singleton.
/// </summary>
public sealed class ConexionBD
{
    public static ConexionBD _instancia;
    private readonly string CadenaConexion = "Persist Security Info=False;Integrated Security=true;Initial Catalog=SistemaInventario;Server=(localdb)\\MSSQLLocalDB;Encrypt=True;";

    // El contructor privado para evitar que
    // se creen mas instancias con "new".
    private ConexionBD() { }


    /// <summary>
    /// Devuelve la unica instancia de la base de datos, si no existe entonces la crea.
    /// </summary>
    public static ConexionBD ObtenerConexion()
    {
        if (_instancia == null)
        {
            _instancia = new ConexionBD();
        }
        return _instancia;
    }

    /// <summary>
    /// Crea una conexion nueva (cerrada) con la cadena configurada.
    /// </summary>
    public SqlConnection CrearConexion()
    {
        return new SqlConnection(CadenaConexion);
    }
}
