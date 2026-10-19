using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class CategoriasForm : Form
    {
        private readonly CategoriaServicio _servicio;
        public string PantallaSeleccionada { get; private set; } = "";

        /// <summary>
        /// Recibe el servicio y conecta las acciones del listado.
        /// </summary>
        public CategoriasForm(CategoriaServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
            ConfigurarListado();
            Load += Formulario_Load;
            guna2TextBox1.TextChanged += Buscar_TextChanged;
            guna2Button3.Click += Eliminar_Click;
            btnNuevo.Click += Nuevo_Click;
            guna2Button2.Click += Editar_Click;
            btnCategoria.Click += IrCategorias_Click;
            btnSuplidores.Click += IrSuplidores_Click;
            btnProductos.Click += IrProductos_Click;
            guna2Button1.Click += IrPapelera_Click;
            btnVolver.Click += Volver_Click;
            tituloLabel.Click += Volver_Click;
        }

        private void ConfigurarListado()
        {
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.ColumnHeadersHeight = 32;
            dgvCategorias.Columns.Clear();
            dgvCategorias.Columns[dgvCategorias.Columns.Add("Nombre", "Nombre")].DataPropertyName = "Nombre";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("Descripcion", "Descripción")].DataPropertyName = "Descripcion";
        }

        private void Formulario_Load(object? sender, EventArgs e)
        {
            CargarListado();
        }

        private void CargarListado()
        {
            try
            {
                dgvCategorias.DataSource = _servicio.Buscar(guna2TextBox1.Text);
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo cargar el listado. Inténtelo nuevamente.", "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar_TextChanged(object? sender, EventArgs e)
        {
            CargarListado();
        }

        private void Eliminar_Click(object? sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado? Podrá recuperarlo desde la papelera.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Categoria? entidad = dgvCategorias.CurrentRow.DataBoundItem as Categoria;
                if (entidad == null)
                    return;
                string mensaje = _servicio.Eliminar(entidad.Id);
                if (mensaje != "")
                    MessageBox.Show(mensaje, "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListado();
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo eliminar el registro. Inténtelo nuevamente.", "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IrCategorias_Click(object? sender, EventArgs e)
        {
            PantallaSeleccionada = "Categorias";
            Close();
        }

        private void IrSuplidores_Click(object? sender, EventArgs e)
        {
            PantallaSeleccionada = "Suplidores";
            Close();
        }

        private void IrProductos_Click(object? sender, EventArgs e)
        {
            PantallaSeleccionada = "Productos";
            Close();
        }

        private void IrPapelera_Click(object? sender, EventArgs e)
        {
            PantallaSeleccionada = "Papelera";
            Close();
        }

        private void Volver_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void Nuevo_Click(object? sender, EventArgs e)
        {
            AbrirEditor(null);
        }

        private void Editar_Click(object? sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para editar.", "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AbrirEditor(dgvCategorias.CurrentRow.DataBoundItem as Categoria);
        }

        private void AbrirEditor(Categoria? entidad)
        {
            try
            {
                using (EditarCategoriaForm formulario = new EditarCategoriaForm(_servicio, entidad))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarListado();
                }
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo abrir el formulario de edición.", "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
