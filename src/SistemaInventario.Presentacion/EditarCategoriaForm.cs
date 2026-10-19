using Guna.UI2.WinForms;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public class EditarCategoriaForm : Form
    {
        private readonly CategoriaServicio _servicio;
        private readonly Categoria _entidad;
        private readonly ErrorProvider errores = new ErrorProvider();
        private readonly Guna2TextBox txtNombre = new Guna2TextBox();
        private readonly Guna2TextBox txtDescripcion = new Guna2TextBox();

        /// <summary>
        /// Recibe el servicio y, al editar, los datos que se mostrarán.
        /// </summary>
        public EditarCategoriaForm(CategoriaServicio servicio, Categoria? entidad = null)
        {
            _servicio = servicio;
            _entidad = new Categoria();
            if (entidad != null)
            {
                _entidad.Id = entidad.Id;
                _entidad.Nombre = entidad.Nombre;
                _entidad.Descripcion = entidad.Descripcion;
            }
            InitializeComponent();
            txtNombre.Text = _entidad.Nombre;
            txtDescripcion.Text = _entidad.Descripcion;
        }

        private void InitializeComponent()
        {
            Text = "Categoria";
            ClientSize = new Size(520, 266);
            BackColor = Color.FromArgb(244, 246, 249);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            errores.ContainerControl = this;
            Label lblNombre = new Label { Text = "Nombre", Location = new Point(24, 20), AutoSize = true };
            txtNombre.Location = new Point(24, 46);
            txtNombre.Size = new Size(458, 38);
            txtNombre.BorderRadius = 5;
            txtNombre.MaxLength = 100;
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Label lblDescripcion = new Label { Text = "Descripción", Location = new Point(24, 98), AutoSize = true };
            txtDescripcion.Location = new Point(24, 124);
            txtDescripcion.Size = new Size(458, 38);
            txtDescripcion.BorderRadius = 5;
            txtDescripcion.MaxLength = 500;
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Guna2Button btnGuardar = new Guna2Button { Text = "Guardar", Location = new Point(210, 204), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(40, 112, 237) };
            Guna2Button btnCancelar = new Guna2Button { Text = "Cancelar", Location = new Point(350, 204), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(19, 44, 82), DialogResult = DialogResult.Cancel };
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
                _entidad.Nombre = txtNombre.Text;
                _entidad.Descripcion = txtDescripcion.Text;
                Dictionary<string, string> mensajes = _servicio.Guardar(_entidad);
                foreach (KeyValuePair<string, string> mensaje in mensajes)
                {
                    if (mensaje.Key == "Nombre")
                        errores.SetError(txtNombre, mensaje.Value);
                    else if (mensaje.Key == "Descripcion")
                        errores.SetError(txtDescripcion, mensaje.Value);
                }
                if (mensajes.Count == 0)
                    DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo guardar el registro. Inténtelo nuevamente.", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
