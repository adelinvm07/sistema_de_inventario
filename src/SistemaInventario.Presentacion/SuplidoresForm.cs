using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class SuplidoresForm : Form
    {
        private readonly SuplidorServicio _servicio;
        public string PantallaSeleccionada { get; private set; } = "";

        /// <summary>
        /// Recibe el servicio y conecta las acciones del listado.
        /// </summary>
        public SuplidoresForm(SuplidorServicio servicio)
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
            dgvCategorias.Columns[dgvCategorias.Columns.Add("NombreEmpresa", "Empresa")].DataPropertyName = "NombreEmpresa";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("NombreContacto", "Contacto")].DataPropertyName = "NombreContacto";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("Telefono", "Teléfono")].DataPropertyName = "Telefono";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("CorreoElectronico", "Correo electrónico")].DataPropertyName = "CorreoElectronico";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("SitioWeb", "Sitio web")].DataPropertyName = "SitioWeb";
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
                MessageBox.Show("No se pudo cargar el listado. Inténtelo nuevamente.", "Suplidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione un registro para eliminar.", "Suplidores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado? Podrá recuperarlo desde la papelera.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Suplidores? entidad = dgvCategorias.CurrentRow.DataBoundItem as Suplidores;
                if (entidad == null)
                    return;
                string mensaje = _servicio.Eliminar(entidad.Id);
                if (mensaje != "")
                    MessageBox.Show(mensaje, "Suplidores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListado();
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo eliminar el registro. Inténtelo nuevamente.", "Suplidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione un registro para editar.", "Suplidores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AbrirEditor(dgvCategorias.CurrentRow.DataBoundItem as Suplidores);
        }

        private void AbrirEditor(Suplidores? entidad)
        {
            try
            {
                using (EditarSuplidorForm formulario = new EditarSuplidorForm(_servicio, entidad))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarListado();
                }
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo abrir el formulario de edición.", "Suplidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
