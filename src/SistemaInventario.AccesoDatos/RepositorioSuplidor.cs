using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;

namespace SistemaInventario.AccesoDatos
{
    public class RepositorioSuplidor : RepositorioBase<Suplidores>
    {
        protected override string NombreTabla { get { return "Suplidores"; } }
        protected override Suplidores DeFilaAEntidad(SqlDataReader lector)
        {
            var s = new Suplidores();
            s.Id = (int)lector["id"];
            s.NombreEmpresa = lector["nombre_empresa"].ToString();
            s.NombreContacto = lector["nombre_contacto"].ToString();
            s.Telefono = lector["telefono"].ToString();
            s.CorreoElectronico = lector["correo_electronico"].ToString();
            s.FechaCreacion = (DateTime)lector["fecha_creacion"];
            s.FechaModificacion = (DateTime)lector["fecha_modificacion"];
            s.Activo = (bool)lector["activo"];

            if (lector["sitio_web"] != DBNull.Value)
                s.SitioWeb = lector["sitio_web"].ToString();

            return s;
        }
        public override void Insertar(Suplidores suplidores)
        {
            string insertar = "INSERT INTO Suplidores (nombre_empresa, nombre_contacto, telefono, correo_electronico, sitio_web) " +
                "VALUES (@nombre_empresa, @nombre_contacto, @telefono, @correo_electronico, @sitio_web)";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(insertar, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre_empresa", suplidores.NombreEmpresa);
                        comando.Parameters.AddWithValue("@nombre_contacto", suplidores.NombreContacto);
                        comando.Parameters.AddWithValue("@telefono", suplidores.Telefono);
                        comando.Parameters.AddWithValue("@correo_electronico", suplidores.CorreoElectronico);
                        comando.Parameters.AddWithValue("@sitio_web", (object)suplidores.SitioWeb ?? DBNull.Value);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.RegistrarLog(ex);
                throw;
            }
        }

        public override void Actualizar(Suplidores suplidores)
        {
            string actualizar = "UPDATE Suplidores SET nombre_empresa = @nombre_empresa, nombre_contacto = @nombre_contacto, " +
                "telefono = @telefono, correo_electronico = @correo_electronico, sitio_web = @sitio_web, " +
                "fecha_modificacion = GETDATE() WHERE id = @id";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtenerConexion().CrearConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(actualizar, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre_empresa", suplidores.NombreEmpresa);
                        comando.Parameters.AddWithValue("@nombre_contacto", suplidores.NombreContacto);
                        comando.Parameters.AddWithValue("@telefono", suplidores.Telefono);
                        comando.Parameters.AddWithValue("@correo_electronico", suplidores.CorreoElectronico);
                        comando.Parameters.AddWithValue("@sitio_web", (object)suplidores.SitioWeb ?? DBNull.Value);
                        comando.Parameters.AddWithValue("@id", suplidores.Id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.RegistrarLog(ex);
                throw;
            }
        }
    }
}