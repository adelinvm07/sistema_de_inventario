#nullable enable
using Guna.UI2.WinForms;

namespace SistemaInventario.Presentacion
{
    partial class MostrarProductoForm
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
            components = new System.ComponentModel.Container();
            errores = new ErrorProvider(components);
            txtNombre = new Guna2TextBox();
            cmbCategoria = new Guna2ComboBox();
            cmbSuplidor = new Guna2ComboBox();
            numPrecioUnitario = new Guna2NumericUpDown();
            lblNombre = new Label();
            lblPrecioUnitario = new Label();
            lblCategoria = new Label();
            lblSuplidor = new Label();
            btnGuardar = new Guna2Button();
            btnCancelar = new Guna2Button();
            ((System.ComponentModel.ISupportInitialize)errores).BeginInit();
            SuspendLayout();
            Text = "Producto";
            ClientSize = new Size(520, 422);
            BackColor = Color.FromArgb(244, 246, 249);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            txtNombre.Name = "txtNombre";
            cmbCategoria.Name = "cmbCategoria";
            cmbSuplidor.Name = "cmbSuplidor";
            numPrecioUnitario.Name = "numPrecioUnitario";
            lblNombre.Name = "lblNombre";
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblCategoria.Name = "lblCategoria";
            lblSuplidor.Name = "lblSuplidor";
            btnGuardar.Name = "btnGuardar";
            btnCancelar.Name = "btnCancelar";
            errores.ContainerControl = this;
            lblNombre.Text = "Nombre";
            lblNombre.Location = new Point(24, 20);
            lblNombre.AutoSize = true;
            txtNombre.Location = new Point(24, 46);
            txtNombre.Size = new Size(458, 38);
            txtNombre.BorderRadius = 5;
            txtNombre.MaxLength = 100;
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            lblPrecioUnitario.Text = "Precio unitario";
            lblPrecioUnitario.Location = new Point(24, 98);
            lblPrecioUnitario.AutoSize = true;
            numPrecioUnitario.Location = new Point(24, 124);
            numPrecioUnitario.Size = new Size(458, 38);
            numPrecioUnitario.BorderRadius = 5;
            Controls.Add(lblPrecioUnitario);
            Controls.Add(numPrecioUnitario);
            lblCategoria.Text = "Categoría";
            lblCategoria.Location = new Point(24, 176);
            lblCategoria.AutoSize = true;
            cmbCategoria.Location = new Point(24, 202);
            cmbCategoria.Size = new Size(458, 38);
            cmbCategoria.BorderRadius = 5;
            Controls.Add(lblCategoria);
            Controls.Add(cmbCategoria);
            lblSuplidor.Text = "Suplidor";
            lblSuplidor.Location = new Point(24, 254);
            lblSuplidor.AutoSize = true;
            cmbSuplidor.Location = new Point(24, 280);
            cmbSuplidor.Size = new Size(458, 38);
            cmbSuplidor.BorderRadius = 5;
            Controls.Add(lblSuplidor);
            Controls.Add(cmbSuplidor);
            numPrecioUnitario.DecimalPlaces = 2;
            numPrecioUnitario.Maximum = 99999999.99m;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplidor.DropDownStyle = ComboBoxStyle.DropDownList;
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(210, 360);
            btnGuardar.Size = new Size(132, 40);
            btnGuardar.BorderRadius = 12;
            btnGuardar.FillColor = Color.FromArgb(40, 112, 237);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(350, 360);
            btnCancelar.Size = new Size(132, 40);
            btnCancelar.BorderRadius = 12;
            btnCancelar.FillColor = Color.FromArgb(19, 44, 82);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnGuardar.Click += Guardar_Click;
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Load += Formulario_Load;
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
            Name = "EditarProductoForm";
            ((System.ComponentModel.ISupportInitialize)errores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ErrorProvider errores = null!;
        private Guna2TextBox txtNombre = null!;
        private Guna2ComboBox cmbCategoria = null!;
        private Guna2ComboBox cmbSuplidor = null!;
        private Guna2NumericUpDown numPrecioUnitario = null!;
        private Label lblNombre = null!;
        private Label lblPrecioUnitario = null!;
        private Label lblCategoria = null!;
        private Label lblSuplidor = null!;
        private Guna2Button btnGuardar = null!;
        private Guna2Button btnCancelar = null!;
    }
}
