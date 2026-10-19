#nullable enable

namespace SistemaInventario.Presentacion;

partial class FormularioPrincipal
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        errorProvider1 = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();
        // 
        // errorProvider1
        // 
        errorProvider1.ContainerControl = this;
        // 
        // FormularioPrincipal
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1143, 800);
        Margin = new Padding(3, 4, 3, 4);
        Name = "FormularioPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sistema de Inventario";
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
    }

    private ErrorProvider errorProvider1;
}
