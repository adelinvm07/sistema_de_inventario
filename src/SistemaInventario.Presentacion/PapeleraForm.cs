using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class PapeleraForm : Form
    {
        private readonly CategoriaServicio _categorias;
        private readonly SuplidorServicio _suplidores;
        private readonly ProductoServicio _productos;
        private readonly FormularioPrincipal _principal;

        /// <summary>
        /// Recibe los servicios y la ventana principal para la navegación.
        /// </summary>
        public PapeleraForm(CategoriaServicio categorias, SuplidorServicio suplidores, ProductoServicio productos, FormularioPrincipal principal)
        {
            InitializeComponent();
            _categorias = categorias;
            _suplidores = suplidores;
            _productos = productos;
            _principal = principal;
            DoubleBuffered = true;
        }

        private void IrCategorias_Click(object? sender, EventArgs e)
        {
            _principal.AbrirPantalla("Categorias");
        }

        private void IrSuplidores_Click(object? sender, EventArgs e)
        {
            _principal.AbrirPantalla("Suplidores");
        }

        private void IrProductos_Click(object? sender, EventArgs e)
        {
            _principal.AbrirPantalla("Productos");
        }

        private void Volver_Click(object? sender, EventArgs e)
        {
            _principal.MostrarInicio();
        }

        private void Formulario_Load(object? sender, EventArgs e)
        {
            CargarPestana();
        }

        private void Pestana_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarPestana();
        }

        private void CargarPestana()
        {
            try
            {
                if (pestanas.SelectedIndex == 0)
                    dgvCategorias.DataSource = _categorias.ObtenerEliminados();
                else if (pestanas.SelectedIndex == 1)
                    dgvSuplidores.DataSource = _suplidores.ObtenerEliminados();
                else if (pestanas.SelectedIndex == 2)
                    dgvProductos.DataSource = _productos.ObtenerEliminados();
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudieron cargar los registros eliminados. Inténtelo nuevamente.", "Papelera", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Restaurar_Click(object? sender, EventArgs e)
        {
            try
            {
                DataGridView listado = dgvCategorias;
                if (pestanas.SelectedIndex == 1)
                    listado = dgvSuplidores;
                else if (pestanas.SelectedIndex == 2)
                    listado = dgvProductos;
                ClaseBase? entidad = null;
                if (listado.CurrentRow != null)
                    entidad = listado.CurrentRow.DataBoundItem as ClaseBase;
                if (entidad == null)
                {
                    MessageBox.Show("Seleccione un registro para restaurar.", "Papelera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string mensaje;
                if (pestanas.SelectedIndex == 0)
                    mensaje = _categorias.Restaurar(entidad.Id);
                else if (pestanas.SelectedIndex == 1)
                    mensaje = _suplidores.Restaurar(entidad.Id);
                else
                    mensaje = _productos.Restaurar(entidad.Id);
                if (mensaje != "")
                    MessageBox.Show(mensaje, "No se pudo restaurar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPestana();
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo restaurar el registro. Inténtelo nuevamente.", "Papelera", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
