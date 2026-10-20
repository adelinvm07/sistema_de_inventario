#nullable enable

using Guna.UI2.WinForms;

namespace SistemaInventario.Presentacion
{
    partial class MostrarCategoriaForm
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            errores = new ErrorProvider(components);
            lblNombre = new Label();
            txtNombre = new Guna2TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new Guna2TextBox();
            lblFotos = new Label();
            lblContador = new Label();
            pnlFotos = new FlowLayoutPanel();
            btnAgregarFoto = new Guna2Button();
            btnQuitarFoto = new Guna2Button();
            btnGuardar = new Guna2Button();
            btnCancelar = new Guna2Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)errores).BeginInit();
            SuspendLayout();
            // 
            // errores
            // 
            errores.ContainerControl = this;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(24, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(69, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderRadius = 5;
            txtNombre.CustomizableEdges = customizableEdges5;
            txtNombre.DefaultText = "";
            txtNombre.Font = new Font("Segoe UI", 9F);
            txtNombre.Location = new Point(24, 46);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.MaxLength = 120;
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "";
            txtNombre.SelectedText = "";
            txtNombre.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNombre.Size = new Size(562, 38);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(24, 98);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(97, 23);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderRadius = 5;
            txtDescripcion.CustomizableEdges = customizableEdges7;
            txtDescripcion.DefaultText = "";
            txtDescripcion.Font = new Font("Segoe UI", 9F);
            txtDescripcion.Location = new Point(24, 124);
            txtDescripcion.Margin = new Padding(3, 4, 3, 4);
            txtDescripcion.MaxLength = 520;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "";
            txtDescripcion.SelectedText = "";
            txtDescripcion.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtDescripcion.Size = new Size(562, 76);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // lblFotos
            // 
            lblFotos.AutoSize = true;
            lblFotos.Location = new Point(24, 227);
            lblFotos.Name = "lblFotos";
            lblFotos.Size = new Size(382, 23);
            lblFotos.TabIndex = 4;
            lblFotos.Text = "Fotos (JPG, JPEG o PNG; máximo 2 MB cada una)";
            // 
            // lblContador
            // 
            lblContador.Location = new Point(432, 257);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(50, 28);
            lblContador.TabIndex = 5;
            lblContador.Text = "0/5";
            // 
            // pnlFotos
            // 
            pnlFotos.AutoScroll = true;
            pnlFotos.BorderStyle = BorderStyle.FixedSingle;
            pnlFotos.Location = new Point(24, 291);
            pnlFotos.Name = "pnlFotos";
            pnlFotos.Size = new Size(458, 132);
            pnlFotos.TabIndex = 6;
            pnlFotos.WrapContents = false;
            // 
            // btnAgregarFoto
            // 
            btnAgregarFoto.BorderRadius = 8;
            btnAgregarFoto.CustomizableEdges = customizableEdges9;
            btnAgregarFoto.FillColor = Color.FromArgb(40, 112, 237);
            btnAgregarFoto.Font = new Font("Segoe UI", 9F);
            btnAgregarFoto.ForeColor = Color.White;
            btnAgregarFoto.Location = new Point(24, 255);
            btnAgregarFoto.Name = "btnAgregarFoto";
            btnAgregarFoto.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAgregarFoto.Size = new Size(150, 30);
            btnAgregarFoto.TabIndex = 7;
            btnAgregarFoto.Text = "Agregar foto";
            btnAgregarFoto.Click += AgregarFoto_Click;
            // 
            // btnQuitarFoto
            // 
            btnQuitarFoto.BorderRadius = 8;
            btnQuitarFoto.CustomizableEdges = customizableEdges11;
            btnQuitarFoto.FillColor = Color.FromArgb(220, 56, 56);
            btnQuitarFoto.Font = new Font("Segoe UI", 9F);
            btnQuitarFoto.ForeColor = Color.White;
            btnQuitarFoto.Location = new Point(184, 255);
            btnQuitarFoto.Name = "btnQuitarFoto";
            btnQuitarFoto.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnQuitarFoto.Size = new Size(198, 30);
            btnQuitarFoto.TabIndex = 8;
            btnQuitarFoto.Text = "Quitar seleccionada";
            btnQuitarFoto.Click += QuitarFoto_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BorderRadius = 12;
            btnGuardar.CustomizableEdges = customizableEdges1;
            btnGuardar.FillColor = Color.FromArgb(40, 112, 237);
            btnGuardar.Font = new Font("Segoe UI", 9F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(334, 447);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnGuardar.Size = new Size(132, 40);
            btnGuardar.TabIndex = 9;
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
            btnCancelar.Location = new Point(474, 447);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancelar.Size = new Size(132, 40);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            // 
            // label1
            // 
            label1.Location = new Point(503, 20);
            label1.Name = "label1";
            label1.Size = new Size(83, 23);
            label1.TabIndex = 11;
            label1.Text = "0/100";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(503, 98);
            label2.Name = "label2";
            label2.Size = new Size(83, 23);
            label2.TabIndex = 12;
            label2.Text = "0/500";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MostrarCategoriaForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            CancelButton = btnCancelar;
            ClientSize = new Size(633, 512);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblFotos);
            Controls.Add(lblContador);
            Controls.Add(pnlFotos);
            Controls.Add(btnAgregarFoto);
            Controls.Add(btnQuitarFoto);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MostrarCategoriaForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Categoría";
            Load += Formulario_Load;
            ((System.ComponentModel.ISupportInitialize)errores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ErrorProvider errores = null!;
        private Label lblNombre = null!;
        private Guna2TextBox txtNombre = null!;
        private Label lblDescripcion = null!;
        private Guna2TextBox txtDescripcion = null!;
        private Label lblFotos = null!;
        private Label lblContador = null!;
        private FlowLayoutPanel pnlFotos = null!;
        private Guna2Button btnAgregarFoto = null!;
        private Guna2Button btnQuitarFoto = null!;
        private Guna2Button btnGuardar = null!;
        private Guna2Button btnCancelar = null!;
        private Label label1;
        private Label label2;
    }
}
