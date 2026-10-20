using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class SuplidoresForm : Form
    {
        private readonly SuplidorServicio _servicio;
        private readonly FormularioPrincipal _principal;

        /// <summary>
        /// Recibe el servicio y conecta las acciones del listado.
        /// </summary>
        public SuplidoresForm(SuplidorServicio servicio, FormularioPrincipal principal)
        {
            InitializeComponent();
            _servicio = servicio;
            _principal = principal;
            DoubleBuffered = true;
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
            DataGridViewTextBoxColumn columnaNombreEmpresa = new DataGridViewTextBoxColumn();
            columnaNombreEmpresa.HeaderText = "Empresa";
            columnaNombreEmpresa.DataPropertyName = "NombreEmpresa";
            dgvCategorias.Columns.Add(columnaNombreEmpresa);
            DataGridViewTextBoxColumn columnaNombreContacto = new DataGridViewTextBoxColumn();
            columnaNombreContacto.HeaderText = "Contacto";
            columnaNombreContacto.DataPropertyName = "NombreContacto";
            dgvCategorias.Columns.Add(columnaNombreContacto);
            DataGridViewTextBoxColumn columnaTelefono = new DataGridViewTextBoxColumn();
            columnaTelefono.HeaderText = "Teléfono";
            columnaTelefono.DataPropertyName = "Telefono";
            dgvCategorias.Columns.Add(columnaTelefono);
            DataGridViewTextBoxColumn columnaCorreoElectronico = new DataGridViewTextBoxColumn();
            columnaCorreoElectronico.HeaderText = "Correo electrónico";
            columnaCorreoElectronico.DataPropertyName = "CorreoElectronico";
            dgvCategorias.Columns.Add(columnaCorreoElectronico);
            DataGridViewTextBoxColumn columnaSitioWeb = new DataGridViewTextBoxColumn();
            columnaSitioWeb.HeaderText = "Sitio web";
            columnaSitioWeb.DataPropertyName = "SitioWeb";
            dgvCategorias.Columns.Add(columnaSitioWeb);
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

        private void IrPapelera_Click(object? sender, EventArgs e)
        {
            _principal.AbrirPantalla("Papelera");
        }

        private void Volver_Click(object? sender, EventArgs e)
        {
            _principal.MostrarInicio();
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
                using (MostrarSuplidorForm formulario = new MostrarSuplidorForm(_servicio, entidad))
                {
                    if (formulario.ShowDialog(_principal) == DialogResult.OK)
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
