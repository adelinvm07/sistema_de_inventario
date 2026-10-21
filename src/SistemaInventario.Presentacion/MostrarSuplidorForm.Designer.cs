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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            // 
            // errores
            // 
            errores.ContainerControl = this;
            // 
            // txtNombreEmpresa
            // 
            txtNombreEmpresa.BorderRadius = 5;
            txtNombreEmpresa.CustomizableEdges = customizableEdges5;
            txtNombreEmpresa.DefaultText = "";
            txtNombreEmpresa.Font = new Font("Segoe UI", 9F);
            txtNombreEmpresa.Location = new Point(24, 46);
            txtNombreEmpresa.Margin = new Padding(3, 4, 3, 4);
            txtNombreEmpresa.MaxLength = 100;
            txtNombreEmpresa.Name = "txtNombreEmpresa";
            txtNombreEmpresa.PlaceholderText = "";
            txtNombreEmpresa.SelectedText = "";
            txtNombreEmpresa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNombreEmpresa.Size = new Size(458, 38);
            txtNombreEmpresa.TabIndex = 1;
            // 
            // txtNombreContacto
            // 
            txtNombreContacto.BorderRadius = 5;
            txtNombreContacto.CustomizableEdges = customizableEdges7;
            txtNombreContacto.DefaultText = "";
            txtNombreContacto.Font = new Font("Segoe UI", 9F);
            txtNombreContacto.Location = new Point(24, 124);
            txtNombreContacto.Margin = new Padding(3, 4, 3, 4);
            txtNombreContacto.MaxLength = 100;
            txtNombreContacto.Name = "txtNombreContacto";
            txtNombreContacto.PlaceholderText = "";
            txtNombreContacto.SelectedText = "";
            txtNombreContacto.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtNombreContacto.Size = new Size(458, 38);
            txtNombreContacto.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.BorderRadius = 5;
            txtTelefono.CustomizableEdges = customizableEdges9;
            txtTelefono.DefaultText = "";
            txtTelefono.Font = new Font("Segoe UI", 9F);
            txtTelefono.Location = new Point(24, 202);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.MaxLength = 12;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "";
            txtTelefono.SelectedText = "";
            txtTelefono.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtTelefono.Size = new Size(458, 38);
            txtTelefono.TabIndex = 5;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            // 
            // txtCorreoElectronico
            // 
            txtCorreoElectronico.BorderRadius = 5;
            txtCorreoElectronico.CustomizableEdges = customizableEdges11;
            txtCorreoElectronico.DefaultText = "";
            txtCorreoElectronico.Font = new Font("Segoe UI", 9F);
            txtCorreoElectronico.Location = new Point(24, 280);
            txtCorreoElectronico.Margin = new Padding(3, 4, 3, 4);
            txtCorreoElectronico.MaxLength = 100;
            txtCorreoElectronico.Name = "txtCorreoElectronico";
            txtCorreoElectronico.PlaceholderText = "";
            txtCorreoElectronico.SelectedText = "";
            txtCorreoElectronico.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtCorreoElectronico.Size = new Size(458, 38);
            txtCorreoElectronico.TabIndex = 7;
            // 
            // txtSitioWeb
            // 
            txtSitioWeb.BorderRadius = 5;
            txtSitioWeb.CustomizableEdges = customizableEdges13;
            txtSitioWeb.DefaultText = "";
            txtSitioWeb.Font = new Font("Segoe UI", 9F);
            txtSitioWeb.Location = new Point(24, 358);
            txtSitioWeb.Margin = new Padding(3, 4, 3, 4);
            txtSitioWeb.MaxLength = 200;
            txtSitioWeb.Name = "txtSitioWeb";
            txtSitioWeb.PlaceholderText = "";
            txtSitioWeb.SelectedText = "";
            txtSitioWeb.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtSitioWeb.Size = new Size(458, 38);
            txtSitioWeb.TabIndex = 9;
            // 
            // lblNombreEmpresa
            // 
            lblNombreEmpresa.AutoSize = true;
            lblNombreEmpresa.Location = new Point(24, 20);
            lblNombreEmpresa.Name = "lblNombreEmpresa";
            lblNombreEmpresa.Size = new Size(75, 23);
            lblNombreEmpresa.TabIndex = 0;
            lblNombreEmpresa.Text = "Empresa";
            // 
            // lblNombreContacto
            // 
            lblNombreContacto.AutoSize = true;
            lblNombreContacto.Location = new Point(24, 98);
            lblNombreContacto.Name = "lblNombreContacto";
            lblNombreContacto.Size = new Size(78, 23);
            lblNombreContacto.TabIndex = 2;
            lblNombreContacto.Text = "Contacto";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(24, 176);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(74, 23);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono";
            // 
            // lblCorreoElectronico
            // 
            lblCorreoElectronico.AutoSize = true;
            lblCorreoElectronico.Location = new Point(24, 254);
            lblCorreoElectronico.Name = "lblCorreoElectronico";
            lblCorreoElectronico.Size = new Size(151, 23);
            lblCorreoElectronico.TabIndex = 6;
            lblCorreoElectronico.Text = "Correo electrónico";
            // 
            // lblSitioWeb
            // 
            lblSitioWeb.AutoSize = true;
            lblSitioWeb.Location = new Point(24, 332);
            lblSitioWeb.Name = "lblSitioWeb";
            lblSitioWeb.Size = new Size(160, 23);
            lblSitioWeb.TabIndex = 8;
            lblSitioWeb.Text = "Sitio web (opcional)";
            // 
            // btnGuardar
            // 
            btnGuardar.BorderRadius = 12;
            btnGuardar.CustomizableEdges = customizableEdges1;
            btnGuardar.FillColor = Color.FromArgb(40, 112, 237);
            btnGuardar.Font = new Font("Segoe UI", 9F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(210, 438);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnGuardar.Size = new Size(132, 40);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += Guardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderRadius = 12;
            btnCancelar.CustomizableEdges = customizableEdges3;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FillColor = Color.FromArgb(19, 44, 82);
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(350, 438);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancelar.Size = new Size(132, 40);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            // 
            // MostrarSuplidorForm
            // 
            AcceptButton = btnGuardar;
            BackColor = Color.FromArgb(244, 246, 249);
            CancelButton = btnCancelar;
            ClientSize = new Size(520, 500);
            Controls.Add(lblNombreEmpresa);
            Controls.Add(txtNombreEmpresa);
            Controls.Add(lblNombreContacto);
            Controls.Add(txtNombreContacto);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblCorreoElectronico);
            Controls.Add(txtCorreoElectronico);
            Controls.Add(lblSitioWeb);
            Controls.Add(txtSitioWeb);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MostrarSuplidorForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Suplidor";
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
