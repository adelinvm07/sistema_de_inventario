using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class ProductosForm : Form
    {
        private readonly ProductoServicio _servicio;
        public string PantallaSeleccionada { get; private set; } = "";
        private readonly ComboBox cmbCategorias = new ComboBox();
        private readonly ComboBox cmbSuplidores = new ComboBox();
        private readonly NumericUpDown numPrecioMinimo = new NumericUpDown();
        private readonly NumericUpDown numPrecioMaximo = new NumericUpDown();
        private List<Categoria> categorias = new List<Categoria>();
        private List<Suplidores> suplidores = new List<Suplidores>();
        private bool cargando;

        /// <summary>
        /// Recibe el servicio y conecta las acciones del listado.
        /// </summary>
        public ProductosForm(ProductoServicio servicio)
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
            ConfigurarFiltros();
        }

        private void ConfigurarListado()
        {
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.ColumnHeadersHeight = 32;
            dgvCategorias.Columns.Clear();
            dgvCategorias.Columns[dgvCategorias.Columns.Add("Nombre", "Producto")].DataPropertyName = "Nombre";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("IdCategoria", "Categoría")].DataPropertyName = "IdCategoria";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("IdSuplidor", "Suplidor")].DataPropertyName = "IdSuplidor";
            dgvCategorias.Columns[dgvCategorias.Columns.Add("PrecioUnitario", "Precio unitario")].DataPropertyName = "PrecioUnitario";
            dgvCategorias.Columns[3].DefaultCellStyle.Format = "N2";
            dgvCategorias.CellFormatting += Listado_CellFormatting;
        }

        private void Formulario_Load(object? sender, EventArgs e)
        {
            try
            {
                cargando = true;
                categorias = _servicio.ObtenerCategorias();
                suplidores = _servicio.ObtenerSuplidores();
                List<Categoria> opcionesCategorias = new List<Categoria>();
                opcionesCategorias.Add(new Categoria { Id = 0, Nombre = "Todas" });
                opcionesCategorias.AddRange(categorias);
                cmbCategorias.DisplayMember = "Nombre";
                cmbCategorias.ValueMember = "Id";
                cmbCategorias.DataSource = opcionesCategorias;
                List<Suplidores> opcionesSuplidores = new List<Suplidores>();
                opcionesSuplidores.Add(new Suplidores { Id = 0, NombreEmpresa = "Todos" });
                opcionesSuplidores.AddRange(suplidores);
                cmbSuplidores.DisplayMember = "NombreEmpresa";
                cmbSuplidores.ValueMember = "Id";
                cmbSuplidores.DataSource = opcionesSuplidores;
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudieron cargar los filtros. Intente abrir la pantalla nuevamente.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
            CargarListado();
        }

        private void CargarListado()
        {
            try
            {
                if (cargando)
                    return;
                int idCategoria = 0;
                int idSuplidor = 0;
                if (cmbCategorias.SelectedItem != null)
                    idCategoria = ((Categoria)cmbCategorias.SelectedItem).Id;
                if (cmbSuplidores.SelectedItem != null)
                    idSuplidor = ((Suplidores)cmbSuplidores.SelectedItem).Id;
                decimal? precioMinimo = null;
                decimal? precioMaximo = null;
                if (numPrecioMinimo.Value > 0)
                    precioMinimo = numPrecioMinimo.Value;
                if (numPrecioMaximo.Value > 0)
                    precioMaximo = numPrecioMaximo.Value;
                dgvCategorias.DataSource = _servicio.Filtrar(guna2TextBox1.Text, idCategoria, idSuplidor, precioMinimo, precioMaximo);
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo cargar el listado. Inténtelo nuevamente.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione un registro para eliminar.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado? Podrá recuperarlo desde la papelera.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Productos? entidad = dgvCategorias.CurrentRow.DataBoundItem as Productos;
                if (entidad == null)
                    return;
                string mensaje = _servicio.Eliminar(entidad.Id);
                if (mensaje != "")
                    MessageBox.Show(mensaje, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListado();
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo eliminar el registro. Inténtelo nuevamente.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione un registro para editar.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AbrirEditor(dgvCategorias.CurrentRow.DataBoundItem as Productos);
        }

        private void AbrirEditor(Productos? entidad)
        {
            try
            {
                using (EditarProductoForm formulario = new EditarProductoForm(_servicio, entidad))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarListado();
                }
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo abrir el formulario de edición.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarFiltros()
        {
            Label lblCategoria = new Label { Text = "Categoría", Location = new Point(336, 157), AutoSize = true };
            Label lblSuplidor = new Label { Text = "Suplidor", Location = new Point(564, 157), AutoSize = true };
            Label lblDesde = new Label { Text = "Desde", Location = new Point(336, 194), AutoSize = true };
            Label lblHasta = new Label { Text = "Hasta", Location = new Point(564, 194), AutoSize = true };
            cmbCategorias.Location = new Point(413, 153);
            cmbCategorias.Size = new Size(140, 28);
            cmbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplidores.Location = new Point(636, 153);
            cmbSuplidores.Size = new Size(154, 28);
            cmbSuplidores.DropDownStyle = ComboBoxStyle.DropDownList;
            numPrecioMinimo.Location = new Point(413, 190);
            numPrecioMinimo.Size = new Size(140, 28);
            numPrecioMinimo.DecimalPlaces = 2;
            numPrecioMinimo.Maximum = 99999999.99m;
            numPrecioMinimo.ThousandsSeparator = true;
            numPrecioMaximo.Location = new Point(636, 190);
            numPrecioMaximo.Size = new Size(154, 28);
            numPrecioMaximo.DecimalPlaces = 2;
            numPrecioMaximo.Maximum = 99999999.99m;
            numPrecioMaximo.ThousandsSeparator = true;
            Label lblLimites = new Label { Text = "0 = sin límite", Location = new Point(803, 195), AutoSize = true };
            Controls.Add(lblLimites);
            cmbCategorias.AccessibleName = "Filtrar por categoría";
            cmbSuplidores.AccessibleName = "Filtrar por suplidor";
            numPrecioMinimo.AccessibleName = "Precio desde; cero sin límite";
            numPrecioMaximo.AccessibleName = "Precio hasta; cero sin límite";
            Controls.AddRange(new Control[] { lblCategoria, lblSuplidor, lblDesde, lblHasta, cmbCategorias, cmbSuplidores, numPrecioMinimo, numPrecioMaximo });
            cmbCategorias.SelectedIndexChanged += Buscar_TextChanged;
            cmbSuplidores.SelectedIndexChanged += Buscar_TextChanged;
            numPrecioMinimo.ValueChanged += Buscar_TextChanged;
            numPrecioMaximo.ValueChanged += Buscar_TextChanged;
        }

        private void Listado_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            if (dgvCategorias.Columns[e.ColumnIndex].Name == "IdCategoria")
            {
                foreach (Categoria categoria in categorias)
                {
                    if (categoria.Id == (int)e.Value)
                    {
                        e.Value = categoria.Nombre;
                        e.FormattingApplied = true;
                        break;
                    }
                }
            }
            else if (dgvCategorias.Columns[e.ColumnIndex].Name == "IdSuplidor")
            {
                foreach (Suplidores suplidor in suplidores)
                {
                    if (suplidor.Id == (int)e.Value)
                    {
                        e.Value = suplidor.NombreEmpresa;
                        e.FormattingApplied = true;
                        break;
                    }
                }
            }
        }
    }
}
