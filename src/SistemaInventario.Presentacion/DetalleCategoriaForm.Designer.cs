#nullable enable
using Guna.UI2.WinForms;

namespace SistemaInventario.Presentacion
{
    partial class DetalleCategoriaForm
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombre = new Label();
            txtDescripcion = new TextBox();
            lblCreacion = new Label();
            lblModificacion = new Label();
            lblProductos = new Label();
            dgvProductos = new DataGridView();
            lblFotos = new Label();
            pnlFotos = new FlowLayoutPanel();
            btnCerrar = new Guna2Button();
            columnaNombre = new DataGridViewTextBoxColumn();
            columnaPrecio = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Categoría";
            lblNombre.Location = new Point(24, 20);
            lblNombre.Size = new Size(712, 40);
            lblNombre.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(19, 44, 82);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Location = new Point(24, 72);
            txtDescripcion.Size = new Size(712, 60);
            txtDescripcion.Multiline = true;
            txtDescripcion.ReadOnly = true;
            txtDescripcion.TabStop = false;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.BackColor = Color.FromArgb(244, 246, 249);
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            lblCreacion.Name = "lblCreacion";
            lblCreacion.Location = new Point(24, 148);
            lblCreacion.Size = new Size(340, 26);
            lblModificacion.Name = "lblModificacion";
            lblModificacion.Location = new Point(390, 148);
            lblModificacion.Size = new Size(346, 26);
            lblProductos.Name = "lblProductos";
            lblProductos.Text = "Productos activos";
            lblProductos.Location = new Point(24, 190);
            lblProductos.AutoSize = true;
            lblProductos.Font = new Font("Trebuchet MS", 11F, FontStyle.Bold);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Location = new Point(24, 222);
            dgvProductos.Size = new Size(712, 160);
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersHeight = 32;
            dgvProductos.EnableHeadersVisualStyles = false;
            lblFotos.Name = "lblFotos";
            lblFotos.Text = "Fotos: 0/5";
            lblFotos.Location = new Point(24, 402);
            lblFotos.AutoSize = true;
            lblFotos.Font = new Font("Trebuchet MS", 11F, FontStyle.Bold);
            pnlFotos.Name = "pnlFotos";
            pnlFotos.Location = new Point(24, 434);
            pnlFotos.Size = new Size(712, 120);
            pnlFotos.AutoScroll = true;
            pnlFotos.WrapContents = false;
            pnlFotos.BorderStyle = BorderStyle.FixedSingle;
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(600, 572);
            btnCerrar.Size = new Size(136, 38);
            btnCerrar.BorderRadius = 12;
            btnCerrar.FillColor = Color.FromArgb(40, 112, 237);
            btnCerrar.DialogResult = DialogResult.Cancel;
            columnaNombre.HeaderText = "Producto";
            columnaNombre.DataPropertyName = "Nombre";
            columnaNombre.FillWeight = 75;
            columnaPrecio.HeaderText = "Precio unitario";
            columnaPrecio.DataPropertyName = "PrecioUnitario";
            columnaPrecio.FillWeight = 25;
            columnaPrecio.DefaultCellStyle.Format = "N2";
            dgvProductos.Columns.AddRange(columnaNombre, columnaPrecio);
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(19, 44, 82);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 630);
            Font = new Font("Trebuchet MS", 10F);
            BackColor = Color.FromArgb(244, 246, 249);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            Text = "Información de la categoría";
            Name = "DetalleCategoriaForm";
            CancelButton = btnCerrar;
            Controls.Add(lblNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(lblCreacion);
            Controls.Add(lblModificacion);
            Controls.Add(lblProductos);
            Controls.Add(dgvProductos);
            Controls.Add(lblFotos);
            Controls.Add(pnlFotos);
            Controls.Add(btnCerrar);
            Load += Formulario_Load;
            FormClosed += Formulario_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblNombre = null!;
        private TextBox txtDescripcion = null!;
        private Label lblCreacion = null!;
        private Label lblModificacion = null!;
        private Label lblProductos = null!;
        private DataGridView dgvProductos = null!;
        private Label lblFotos = null!;
        private FlowLayoutPanel pnlFotos = null!;
        private Guna2Button btnCerrar = null!;
        private DataGridViewTextBoxColumn columnaNombre = null!;
        private DataGridViewTextBoxColumn columnaPrecio = null!;
    }
}
