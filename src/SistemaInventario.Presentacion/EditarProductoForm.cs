using Guna.UI2.WinForms;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public class EditarProductoForm : Form
    {
        private readonly ProductoServicio _servicio;
        private readonly Productos _entidad;
        private readonly ErrorProvider errores = new ErrorProvider();
        private readonly Guna2TextBox txtNombre = new Guna2TextBox();
        private readonly Guna2ComboBox cmbCategoria = new Guna2ComboBox();
        private readonly Guna2ComboBox cmbSuplidor = new Guna2ComboBox();
        private readonly Guna2NumericUpDown numPrecioUnitario = new Guna2NumericUpDown();

        /// <summary>
        /// Recibe el servicio y, al editar, los datos que se mostrarán.
        /// </summary>
        public EditarProductoForm(ProductoServicio servicio, Productos? entidad = null)
        {
            _servicio = servicio;
            _entidad = new Productos();
            if (entidad != null)
            {
                _entidad.Id = entidad.Id;
                _entidad.Nombre = entidad.Nombre;
                _entidad.IdCategoria = entidad.IdCategoria;
                _entidad.IdSuplidor = entidad.IdSuplidor;
                _entidad.PrecioUnitario = entidad.PrecioUnitario;
            }
            InitializeComponent();
            txtNombre.Text = _entidad.Nombre;
            numPrecioUnitario.Value = _entidad.PrecioUnitario;
            Load += Formulario_Load;
        }

        private void InitializeComponent()
        {
            Text = "Producto";
            ClientSize = new Size(520, 422);
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
            Label lblPrecioUnitario = new Label { Text = "Precio unitario", Location = new Point(24, 98), AutoSize = true };
            numPrecioUnitario.Location = new Point(24, 124);
            numPrecioUnitario.Size = new Size(458, 38);
            numPrecioUnitario.BorderRadius = 5;
            Controls.Add(lblPrecioUnitario);
            Controls.Add(numPrecioUnitario);
            Label lblCategoria = new Label { Text = "Categoría", Location = new Point(24, 176), AutoSize = true };
            cmbCategoria.Location = new Point(24, 202);
            cmbCategoria.Size = new Size(458, 38);
            cmbCategoria.BorderRadius = 5;
            Controls.Add(lblCategoria);
            Controls.Add(cmbCategoria);
            Label lblSuplidor = new Label { Text = "Suplidor", Location = new Point(24, 254), AutoSize = true };
            cmbSuplidor.Location = new Point(24, 280);
            cmbSuplidor.Size = new Size(458, 38);
            cmbSuplidor.BorderRadius = 5;
            Controls.Add(lblSuplidor);
            Controls.Add(cmbSuplidor);
            numPrecioUnitario.DecimalPlaces = 2;
            numPrecioUnitario.Maximum = 99999999.99m;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplidor.DropDownStyle = ComboBoxStyle.DropDownList;
            Guna2Button btnGuardar = new Guna2Button { Text = "Guardar", Location = new Point(210, 360), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(40, 112, 237) };
            Guna2Button btnCancelar = new Guna2Button { Text = "Cancelar", Location = new Point(350, 360), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(19, 44, 82), DialogResult = DialogResult.Cancel };
            btnGuardar.Click += Guardar_Click;
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }

        private void Formulario_Load(object? sender, EventArgs e)
        {
            try
            {
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DataSource = _servicio.ObtenerCategorias();
                cmbSuplidor.DisplayMember = "NombreEmpresa";
                cmbSuplidor.ValueMember = "Id";
                cmbSuplidor.DataSource = _servicio.ObtenerSuplidores();
                cmbCategoria.SelectedValue = _entidad.IdCategoria;
                cmbSuplidor.SelectedValue = _entidad.IdSuplidor;
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudieron cargar las categorías y suplidores.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardar_Click(object? sender, EventArgs e)
        {
            errores.Clear();
            try
            {
                _entidad.Nombre = txtNombre.Text;
                _entidad.PrecioUnitario = numPrecioUnitario.Value;
                _entidad.IdCategoria = 0;
                _entidad.IdSuplidor = 0;
                if (cmbCategoria.SelectedItem != null)
                    _entidad.IdCategoria = ((Categoria)cmbCategoria.SelectedItem).Id;
                if (cmbSuplidor.SelectedItem != null)
                    _entidad.IdSuplidor = ((Suplidores)cmbSuplidor.SelectedItem).Id;
                Dictionary<string, string> mensajes = _servicio.Guardar(_entidad);
                foreach (KeyValuePair<string, string> mensaje in mensajes)
                {
                    if (mensaje.Key == "Nombre")
                        errores.SetError(txtNombre, mensaje.Value);
                    else if (mensaje.Key == "PrecioUnitario")
                        errores.SetError(numPrecioUnitario, mensaje.Value);
                    else if (mensaje.Key == "IdCategoria")
                        errores.SetError(cmbCategoria, mensaje.Value);
                    else if (mensaje.Key == "IdSuplidor")
                        errores.SetError(cmbSuplidor, mensaje.Value);
                }
                if (mensajes.Count == 0)
                    DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo guardar el registro. Inténtelo nuevamente.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
