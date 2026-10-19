using Guna.UI2.WinForms;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public class EditarSuplidorForm : Form
    {
        private readonly SuplidorServicio _servicio;
        private readonly Suplidores _entidad;
        private readonly ErrorProvider errores = new ErrorProvider();
        private readonly Guna2TextBox txtNombreEmpresa = new Guna2TextBox();
        private readonly Guna2TextBox txtNombreContacto = new Guna2TextBox();
        private readonly Guna2TextBox txtTelefono = new Guna2TextBox();
        private readonly Guna2TextBox txtCorreoElectronico = new Guna2TextBox();
        private readonly Guna2TextBox txtSitioWeb = new Guna2TextBox();

        /// <summary>
        /// Recibe el servicio y, al editar, los datos que se mostrarán.
        /// </summary>
        public EditarSuplidorForm(SuplidorServicio servicio, Suplidores? entidad = null)
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

        private void InitializeComponent()
        {
            Text = "Suplidor";
            ClientSize = new Size(520, 500);
            BackColor = Color.FromArgb(244, 246, 249);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            errores.ContainerControl = this;
            Label lblNombreEmpresa = new Label { Text = "Empresa", Location = new Point(24, 20), AutoSize = true };
            txtNombreEmpresa.Location = new Point(24, 46);
            txtNombreEmpresa.Size = new Size(458, 38);
            txtNombreEmpresa.BorderRadius = 5;
            txtNombreEmpresa.MaxLength = 100;
            Controls.Add(lblNombreEmpresa);
            Controls.Add(txtNombreEmpresa);
            Label lblNombreContacto = new Label { Text = "Contacto", Location = new Point(24, 98), AutoSize = true };
            txtNombreContacto.Location = new Point(24, 124);
            txtNombreContacto.Size = new Size(458, 38);
            txtNombreContacto.BorderRadius = 5;
            txtNombreContacto.MaxLength = 100;
            Controls.Add(lblNombreContacto);
            Controls.Add(txtNombreContacto);
            Label lblTelefono = new Label { Text = "Teléfono", Location = new Point(24, 176), AutoSize = true };
            txtTelefono.Location = new Point(24, 202);
            txtTelefono.Size = new Size(458, 38);
            txtTelefono.BorderRadius = 5;
            txtTelefono.MaxLength = 12;
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Label lblCorreoElectronico = new Label { Text = "Correo electrónico", Location = new Point(24, 254), AutoSize = true };
            txtCorreoElectronico.Location = new Point(24, 280);
            txtCorreoElectronico.Size = new Size(458, 38);
            txtCorreoElectronico.BorderRadius = 5;
            txtCorreoElectronico.MaxLength = 100;
            Controls.Add(lblCorreoElectronico);
            Controls.Add(txtCorreoElectronico);
            Label lblSitioWeb = new Label { Text = "Sitio web (opcional)", Location = new Point(24, 332), AutoSize = true };
            txtSitioWeb.Location = new Point(24, 358);
            txtSitioWeb.Size = new Size(458, 38);
            txtSitioWeb.BorderRadius = 5;
            txtSitioWeb.MaxLength = 200;
            Controls.Add(lblSitioWeb);
            Controls.Add(txtSitioWeb);
            Guna2Button btnGuardar = new Guna2Button { Text = "Guardar", Location = new Point(210, 438), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(40, 112, 237) };
            Guna2Button btnCancelar = new Guna2Button { Text = "Cancelar", Location = new Point(350, 438), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(19, 44, 82), DialogResult = DialogResult.Cancel };
            btnGuardar.Click += Guardar_Click;
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                errores.Dispose();
            base.Dispose(disposing);
        }
    }
}
