using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class MostrarSuplidorForm : Form
    {
        private readonly SuplidorServicio _servicio;
        private readonly Suplidores _entidad;

        /// <summary>
        /// Recibe el servicio y al editar los datos que se mostrarán
        /// </summary>
        public MostrarSuplidorForm(SuplidorServicio servicio, Suplidores? entidad = null)
        {
            _servicio = servicio;
            _entidad = new Suplidores();
            if (entidad != null)
            {
                _entidad.Id = entidad.Id;
                _entidad.NombreEmpresa = entidad.NombreEmpresa;
                _entidad.NombreContacto = entidad.NombreContacto;
                _entidad.Telefono = entidad.Telefono;
                _entidad.CorreoElectronico = entidad.CorreoElectronico;
                _entidad.SitioWeb = entidad.SitioWeb;
            }
            InitializeComponent();
            txtNombreEmpresa.Text = _entidad.NombreEmpresa;
            txtNombreContacto.Text = _entidad.NombreContacto;
            txtTelefono.Text = _entidad.Telefono;
            txtCorreoElectronico.Text = _entidad.CorreoElectronico;
            txtSitioWeb.Text = _entidad.SitioWeb;
        }


        private void Guardar_Click(object? sender, EventArgs e)
        {
            errores.Clear();
            try
            {
                _entidad.NombreEmpresa = txtNombreEmpresa.Text;
                _entidad.NombreContacto = txtNombreContacto.Text;
                _entidad.Telefono = txtTelefono.Text;
                _entidad.CorreoElectronico = txtCorreoElectronico.Text;
                _entidad.SitioWeb = txtSitioWeb.Text;
                Dictionary<string, string> mensajes = _servicio.Guardar(_entidad);
                foreach (KeyValuePair<string, string> mensaje in mensajes)
                {
                    if (mensaje.Key == "NombreEmpresa")
                        errores.SetError(txtNombreEmpresa, mensaje.Value);
                    else if (mensaje.Key == "NombreContacto")
                        errores.SetError(txtNombreContacto, mensaje.Value);
                    else if (mensaje.Key == "Telefono")
                        errores.SetError(txtTelefono, mensaje.Value);
                    else if (mensaje.Key == "CorreoElectronico")
                        errores.SetError(txtCorreoElectronico, mensaje.Value);
                    else if (mensaje.Key == "SitioWeb")
                        errores.SetError(txtSitioWeb, mensaje.Value);
                }
                if (mensajes.Count == 0)
                    DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo guardar el registro. Inténtelo nuevamente.", "Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string n = "";

            foreach (char caracter in txtTelefono.Text)
            {
                if (char.IsDigit(caracter) && n.Length < 10)
                    n += caracter;
            }

            if (n.Length > 6)
                n = n.Insert(6, "-");

            if (n.Length > 3)
                n = n.Insert(3, "-");

            if (txtTelefono.Text != n)
            {
                txtTelefono.Text = n;
                txtTelefono.SelectionStart = txtTelefono.Text.Length;
            }
        }
    }
}
