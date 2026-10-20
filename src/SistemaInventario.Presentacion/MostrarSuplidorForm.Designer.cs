#nullable enable
using Guna.UI2.WinForms;

namespace SistemaInventario.Presentacion
{
    partial class MostrarSuplidorForm
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
            txtNombreEmpresa = new Guna2TextBox();
            txtNombreContacto = new Guna2TextBox();
            txtTelefono = new Guna2TextBox();
            txtCorreoElectronico = new Guna2TextBox();
            txtSitioWeb = new Guna2TextBox();
            lblNombreEmpresa = new Label();
            lblNombreContacto = new Label();
            lblTelefono = new Label();
            lblCorreoElectronico = new Label();
            lblSitioWeb = new Label();
            btnGuardar = new Guna2Button();
            btnCancelar = new Guna2Button();
            ((System.ComponentModel.ISupportInitialize)errores).BeginInit();
            SuspendLayout();
            Text = "Suplidor";
            ClientSize = new Size(520, 500);
            BackColor = Color.FromArgb(244, 246, 249);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            txtNombreEmpresa.Name = "txtNombreEmpresa";
            txtNombreContacto.Name = "txtNombreContacto";
            txtTelefono.Name = "txtTelefono";
            txtCorreoElectronico.Name = "txtCorreoElectronico";
            txtSitioWeb.Name = "txtSitioWeb";
            lblNombreEmpresa.Name = "lblNombreEmpresa";
            lblNombreContacto.Name = "lblNombreContacto";
            lblTelefono.Name = "lblTelefono";
            lblCorreoElectronico.Name = "lblCorreoElectronico";
            lblSitioWeb.Name = "lblSitioWeb";
            btnGuardar.Name = "btnGuardar";
            btnCancelar.Name = "btnCancelar";
            errores.ContainerControl = this;
            lblNombreEmpresa.Text = "Empresa";
            lblNombreEmpresa.Location = new Point(24, 20);
            lblNombreEmpresa.AutoSize = true;
            txtNombreEmpresa.Location = new Point(24, 46);
            txtNombreEmpresa.Size = new Size(458, 38);
            txtNombreEmpresa.BorderRadius = 5;
            txtNombreEmpresa.MaxLength = 100;
            Controls.Add(lblNombreEmpresa);
            Controls.Add(txtNombreEmpresa);
            lblNombreContacto.Text = "Contacto";
            lblNombreContacto.Location = new Point(24, 98);
            lblNombreContacto.AutoSize = true;
            txtNombreContacto.Location = new Point(24, 124);
            txtNombreContacto.Size = new Size(458, 38);
            txtNombreContacto.BorderRadius = 5;
            txtNombreContacto.MaxLength = 100;
            Controls.Add(lblNombreContacto);
            Controls.Add(txtNombreContacto);
            lblTelefono.Text = "Teléfono";
            lblTelefono.Location = new Point(24, 176);
            lblTelefono.AutoSize = true;
            txtTelefono.Location = new Point(24, 202);
            txtTelefono.Size = new Size(458, 38);
            txtTelefono.BorderRadius = 5;
            txtTelefono.MaxLength = 12;
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            lblCorreoElectronico.Text = "Correo electrónico";
            lblCorreoElectronico.Location = new Point(24, 254);
            lblCorreoElectronico.AutoSize = true;
            txtCorreoElectronico.Location = new Point(24, 280);
            txtCorreoElectronico.Size = new Size(458, 38);
            txtCorreoElectronico.BorderRadius = 5;
            txtCorreoElectronico.MaxLength = 100;
            Controls.Add(lblCorreoElectronico);
            Controls.Add(txtCorreoElectronico);
            lblSitioWeb.Text = "Sitio web (opcional)";
            lblSitioWeb.Location = new Point(24, 332);
            lblSitioWeb.AutoSize = true;
            txtSitioWeb.Location = new Point(24, 358);
            txtSitioWeb.Size = new Size(458, 38);
            txtSitioWeb.BorderRadius = 5;
            txtSitioWeb.MaxLength = 200;
            Controls.Add(lblSitioWeb);
            Controls.Add(txtSitioWeb);
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(210, 438);
            btnGuardar.Size = new Size(132, 40);
            btnGuardar.BorderRadius = 12;
            btnGuardar.FillColor = Color.FromArgb(40, 112, 237);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(350, 438);
            btnCancelar.Size = new Size(132, 40);
            btnCancelar.BorderRadius = 12;
            btnCancelar.FillColor = Color.FromArgb(19, 44, 82);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnGuardar.Click += Guardar_Click;
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
            Name = "EditarSuplidorForm";
            ((System.ComponentModel.ISupportInitialize)errores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ErrorProvider errores = null!;
        private Guna2TextBox txtNombreEmpresa = null!;
        private Guna2TextBox txtNombreContacto = null!;
        private Guna2TextBox txtTelefono = null!;
        private Guna2TextBox txtCorreoElectronico = null!;
        private Guna2TextBox txtSitioWeb = null!;
        private Label lblNombreEmpresa = null!;
        private Label lblNombreContacto = null!;
        private Label lblTelefono = null!;
        private Label lblCorreoElectronico = null!;
        private Label lblSitioWeb = null!;
        private Guna2Button btnGuardar = null!;
        private Guna2Button btnCancelar = null!;
    }
}
