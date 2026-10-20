using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class MostrarProductoForm : Form
    {
        private readonly ProductoServicio _servicio;
        private readonly Productos _entidad;

        /// <summary>
        /// Recibe el servicio y, al editar, los datos que se mostrarán.
        /// </summary>
        public MostrarProductoForm(ProductoServicio servicio, Productos? entidad = null)
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

    }
}
