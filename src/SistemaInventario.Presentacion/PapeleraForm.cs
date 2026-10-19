using Guna.UI2.WinForms;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public class PapeleraForm : Form
    {
        private readonly CategoriaServicio _categorias;
        private readonly SuplidorServicio _suplidores;
        private readonly ProductoServicio _productos;
        private readonly TabControl pestanas = new TabControl();
        private readonly DataGridView dgvCategorias = new DataGridView();
        private readonly DataGridView dgvSuplidores = new DataGridView();
        private readonly DataGridView dgvProductos = new DataGridView();

        /// <summary>
        /// Recibe los servicios para consultar y restaurar los registros eliminados.
        /// </summary>
        public PapeleraForm(CategoriaServicio categorias, SuplidorServicio suplidores, ProductoServicio productos)
        {
            _categorias = categorias;
            _suplidores = suplidores;
            _productos = productos;
            InitializeComponent();
            Load += Formulario_Load;
            pestanas.SelectedIndexChanged += Pestana_SelectedIndexChanged;
        }

        private void InitializeComponent()
        {
            Text = "Papelera";
            ClientSize = new Size(850, 480);
            BackColor = Color.FromArgb(244, 246, 249);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Label lblTitulo = new Label { Text = "Restaurar registros eliminados", Location = new Point(24, 18), AutoSize = true, Font = new Font("Trebuchet MS", 15F, FontStyle.Bold) };
            pestanas.Location = new Point(24, 62);
            pestanas.Size = new Size(802, 392);
            CrearPestana("Categorías", dgvCategorias);
            CrearPestana("Suplidores", dgvSuplidores);
            CrearPestana("Productos", dgvProductos);
            AgregarColumna(dgvCategorias, "Nombre", "Nombre");
            AgregarColumna(dgvCategorias, "Descripcion", "Descripción");
            AgregarColumna(dgvSuplidores, "NombreEmpresa", "Empresa");
            AgregarColumna(dgvSuplidores, "NombreContacto", "Contacto");
            AgregarColumna(dgvSuplidores, "Telefono", "Teléfono");
            AgregarColumna(dgvSuplidores, "CorreoElectronico", "Correo electrónico");
            AgregarColumna(dgvProductos, "Nombre", "Producto");
            AgregarColumna(dgvProductos, "PrecioUnitario", "Precio unitario");
            dgvProductos.Columns[1].DefaultCellStyle.Format = "N2";
            Controls.Add(lblTitulo);
            Controls.Add(pestanas);
        }

        private void CrearPestana(string titulo, DataGridView listado)
        {
            TabPage pagina = new TabPage(titulo);
            pagina.BackColor = BackColor;
            listado.Location = new Point(12, 14);
            listado.Size = new Size(768, 282);
            listado.AutoGenerateColumns = false;
            listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listado.AllowUserToAddRows = false;
            listado.AllowUserToDeleteRows = false;
            listado.ReadOnly = true;
            listado.MultiSelect = false;
            listado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listado.RowHeadersVisible = false;
            listado.BackgroundColor = Color.White;
            listado.BorderStyle = BorderStyle.None;
            listado.ColumnHeadersHeight = 32;
            listado.EnableHeadersVisualStyles = false;
            listado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(19, 44, 82);
            listado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Guna2Button btnRestaurar = new Guna2Button { Text = "Restaurar seleccionado", Location = new Point(540, 310), Size = new Size(240, 40), BorderRadius = 12, FillColor = Color.FromArgb(40, 112, 237) };
            btnRestaurar.Click += Restaurar_Click;
            pagina.Controls.Add(listado);
            pagina.Controls.Add(btnRestaurar);
            pestanas.TabPages.Add(pagina);
        }

        private void AgregarColumna(DataGridView listado, string propiedad, string titulo)
        {
            int indice = listado.Columns.Add(propiedad, titulo);
            listado.Columns[indice].DataPropertyName = propiedad;
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
                ClaseBase? entidad = listado.CurrentRow?.DataBoundItem as ClaseBase;
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
