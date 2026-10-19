using Guna.UI2.WinForms;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public class PapeleraForm : Form
    {
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1 = null!;
        private Label tituloLabel = null!;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1 = null!;
        private Guna.UI2.WinForms.Guna2Button btnCategoria = null!;
        private Guna.UI2.WinForms.Guna2Button btnSuplidores = null!;
        private Panel panel2 = null!;
        private Panel panel1 = null!;
        private Guna.UI2.WinForms.Guna2Button guna2Button1 = null!;
        private Guna.UI2.WinForms.Guna2Button btnProductos = null!;

        private Guna2Button btnVolver = null!;

        public string PantallaSeleccionada { get; private set; } = "";

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
            Text = "Sistema de Inventario";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 554);
            BackColor = Color.FromArgb(244, 246, 249);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            CrearMenu();
            Label lblTitulo = new Label { Text = "Papelera", Location = new Point(336, 53), AutoSize = true, Font = new Font("Trebuchet MS", 18F, FontStyle.Bold) };
            pestanas.Location = new Point(336, 116);
            pestanas.Size = new Size(602, 365);
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

        private void CrearMenu()
        {
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
        btnVolver = new Guna.UI2.WinForms.Guna2Button();
        panel2 = new Panel();
        panel1 = new Panel();
        guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
        btnProductos = new Guna.UI2.WinForms.Guna2Button();
        btnSuplidores = new Guna.UI2.WinForms.Guna2Button();
        btnCategoria = new Guna.UI2.WinForms.Guna2Button();
        guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
        tituloLabel = new Label();

        guna2Panel1.BackColor = Color.FromArgb(19, 44, 82);
        guna2Panel1.Controls.Add(btnVolver);
        guna2Panel1.Controls.Add(panel2);
        guna2Panel1.Controls.Add(panel1);
        guna2Panel1.Controls.Add(guna2Button1);
        guna2Panel1.Controls.Add(btnProductos);
        guna2Panel1.Controls.Add(btnSuplidores);
        guna2Panel1.Controls.Add(btnCategoria);
        guna2Panel1.Controls.Add(guna2PictureBox1);
        guna2Panel1.Controls.Add(tituloLabel);
        guna2Panel1.CustomizableEdges = customizableEdges13;
        guna2Panel1.FillColor = Color.FromArgb(19, 44, 82);
        guna2Panel1.Font = new Font("Trebuchet MS", 12F);
        guna2Panel1.ForeColor = SystemColors.ButtonHighlight;
        guna2Panel1.Location = new Point(-1, 1);
        guna2Panel1.Name = "guna2Panel1";
        guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges14;
        guna2Panel1.Size = new Size(284, 552);
        guna2Panel1.TabIndex = 0;
        btnVolver.CustomizableEdges = customizableEdges1;
        btnVolver.DisabledState.BorderColor = Color.DarkGray;
        btnVolver.DisabledState.CustomBorderColor = Color.DarkGray;
        btnVolver.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnVolver.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnVolver.FillColor = Color.Transparent;
        btnVolver.Font = new Font("Segoe UI", 9F);
        btnVolver.ForeColor = Color.White;
        btnVolver.Image = Properties.Resources.arrow_back_29dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
        btnVolver.ImageSize = new Size(50, 50);
        btnVolver.Location = new Point(22, 482);
        btnVolver.Name = "btnVolver";
        btnVolver.ShadowDecoration.CustomizableEdges = customizableEdges2;
        btnVolver.Size = new Size(52, 56);
        btnVolver.TabIndex = 27;
        panel2.BackColor = SystemColors.ButtonHighlight;
        panel2.Location = new Point(36, 372);
        panel2.Name = "panel2";
        panel2.Size = new Size(216, 2);
        panel2.TabIndex = 2;
        panel1.BackColor = SystemColors.ButtonHighlight;
        panel1.Location = new Point(36, 120);
        panel1.Name = "panel1";
        panel1.Size = new Size(216, 2);
        panel1.TabIndex = 1;
        guna2Button1.BorderRadius = 15;
        guna2Button1.CustomizableEdges = customizableEdges3;
        guna2Button1.DisabledState.BorderColor = Color.DarkGray;
        guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
        guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        guna2Button1.FillColor = Color.FromArgb(40, 112, 237);
        guna2Button1.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        guna2Button1.ForeColor = Color.White;
        guna2Button1.Image = Properties.Resources.delete_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
        guna2Button1.ImageAlign = HorizontalAlignment.Left;
        guna2Button1.ImageOffset = new Point(10, 0);
        guna2Button1.ImageSize = new Size(30, 30);
        guna2Button1.Location = new Point(13, 392);
        guna2Button1.Name = "guna2Button1";
        guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
        guna2Button1.Size = new Size(258, 57);
        guna2Button1.TabIndex = 7;
        guna2Button1.Text = "Papelera";
        btnProductos.BorderRadius = 15;
        btnProductos.CustomizableEdges = customizableEdges5;
        btnProductos.DisabledState.BorderColor = Color.Transparent;
        btnProductos.DisabledState.CustomBorderColor = Color.Transparent;
        btnProductos.DisabledState.FillColor = Color.Transparent;
        btnProductos.DisabledState.ForeColor = Color.Transparent;
        btnProductos.FillColor = Color.FromArgb(19, 44, 82);
        btnProductos.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnProductos.ForeColor = Color.White;
        btnProductos.Image = Properties.Resources.shopping_bag_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
        btnProductos.ImageAlign = HorizontalAlignment.Left;
        btnProductos.ImageOffset = new Point(10, 0);
        btnProductos.ImageSize = new Size(30, 30);
        btnProductos.Location = new Point(13, 286);
        btnProductos.Name = "btnProductos";
        btnProductos.ShadowDecoration.CustomizableEdges = customizableEdges6;
        btnProductos.Size = new Size(258, 57);
        btnProductos.TabIndex = 5;
        btnProductos.Text = "Productos";
        btnSuplidores.BorderRadius = 15;
        btnSuplidores.CustomizableEdges = customizableEdges7;
        btnSuplidores.DisabledState.BorderColor = Color.Transparent;
        btnSuplidores.DisabledState.CustomBorderColor = Color.Transparent;
        btnSuplidores.DisabledState.FillColor = Color.Transparent;
        btnSuplidores.DisabledState.ForeColor = Color.Transparent;
        btnSuplidores.FillColor = Color.FromArgb(19, 44, 82);
        btnSuplidores.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnSuplidores.ForeColor = Color.White;
        btnSuplidores.Image = Properties.Resources.group_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
        btnSuplidores.ImageAlign = HorizontalAlignment.Left;
        btnSuplidores.ImageOffset = new Point(10, 0);
        btnSuplidores.ImageSize = new Size(30, 30);
        btnSuplidores.Location = new Point(13, 223);
        btnSuplidores.Name = "btnSuplidores";
        btnSuplidores.ShadowDecoration.CustomizableEdges = customizableEdges8;
        btnSuplidores.Size = new Size(258, 57);
        btnSuplidores.TabIndex = 3;
        btnSuplidores.Text = "Suplidores";
        btnCategoria.BorderRadius = 15;
        btnCategoria.CustomizableEdges = customizableEdges9;
        btnCategoria.DisabledState.BorderColor = Color.Transparent;
        btnCategoria.DisabledState.CustomBorderColor = Color.Transparent;
        btnCategoria.DisabledState.FillColor = Color.Transparent;
        btnCategoria.DisabledState.ForeColor = Color.Transparent;
        btnCategoria.FillColor = Color.FromArgb(19, 44, 82);
        btnCategoria.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnCategoria.ForeColor = Color.White;
        btnCategoria.Image = Properties.Resources.category_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24;
        btnCategoria.ImageAlign = HorizontalAlignment.Left;
        btnCategoria.ImageOffset = new Point(10, 0);
        btnCategoria.ImageSize = new Size(30, 30);
        btnCategoria.Location = new Point(13, 156);
        btnCategoria.Name = "btnCategoria";
        btnCategoria.ShadowDecoration.CustomizableEdges = customizableEdges10;
        btnCategoria.Size = new Size(258, 57);
        btnCategoria.TabIndex = 1;
        btnCategoria.Text = "Categorias";
        guna2PictureBox1.CustomizableEdges = customizableEdges11;
        guna2PictureBox1.Image = Properties.Resources.inventory_2_24dp_EFEFEF_FILL0_wght400_GRAD0_opsz24;
        guna2PictureBox1.ImageRotate = 0F;
        guna2PictureBox1.Location = new Point(36, 52);
        guna2PictureBox1.Name = "guna2PictureBox1";
        guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges12;
        guna2PictureBox1.Size = new Size(38, 32);
        guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        guna2PictureBox1.TabIndex = 1;
        guna2PictureBox1.TabStop = false;
        tituloLabel.BackColor = Color.Transparent;
        tituloLabel.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        tituloLabel.ForeColor = SystemColors.ButtonHighlight;
        tituloLabel.Location = new Point(80, 40);
        tituloLabel.Name = "tituloLabel";
        tituloLabel.Size = new Size(149, 64);
        tituloLabel.TabIndex = 0;
        tituloLabel.Text = "Sistema de Inventario";
            Controls.Add(guna2Panel1);
            btnCategoria.Click += IrCategorias_Click;
            btnSuplidores.Click += IrSuplidores_Click;
            btnProductos.Click += IrProductos_Click;
            btnVolver.Click += Volver_Click;
            tituloLabel.Click += Volver_Click;
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

        private void CrearPestana(string titulo, DataGridView listado)
        {
            TabPage pagina = new TabPage(titulo);
            pagina.BackColor = BackColor;
            listado.Location = new Point(12, 14);
            listado.Size = new Size(570, 248);
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
            Guna2Button btnRestaurar = new Guna2Button { Text = "Restaurar seleccionado", Location = new Point(342, 278), Size = new Size(240, 40), BorderRadius = 12, FillColor = Color.FromArgb(40, 112, 237) };
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
