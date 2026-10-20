using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion;

public partial class FormularioPrincipal : Form
{
    private readonly CategoriaServicio _categorias;
    private readonly SuplidorServicio _suplidores;
    private readonly ProductoServicio _productos;

    /// <summary>
    /// Recibe la fábrica y utiliza sus servicios en las pantallas.
    /// </summary>
    public FormularioPrincipal(FabricaServicios fabrica)
    {
        InitializeComponent();
        DoubleBuffered = true;
        _categorias = fabrica.Categorias;
        _suplidores = fabrica.Suplidores;
        _productos = fabrica.Productos;
        guna2Button1.Click += btnPapelera_Click;
        string nombreUsuario = Environment.UserName;
        bienvenidaLabel.Text = $"¡Bienvenid@, {char.ToUpper(nombreUsuario[0]) + nombreUsuario.Substring(1)}!";
    }

    private void ActualizarTotales()
    {
        try
        {
            CategoriasNum.Text = _categorias.ObtenerTodas().Count.ToString();
            SuplidoresNum.Text = _suplidores.ObtenerTodos().Count.ToString();
            ProductosNum.Text = _productos.ObtenerTodos().Count.ToString();
        }
        catch (Exception ex)
        {
            Logger.RegistrarLog(ex);
            MessageBox.Show("No se pudieron cargar los totales. Revise la conexión a la base de datos.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Muestra el listado dentro de la ventana principal.
    /// </summary>
    public void AbrirPantalla(string pantalla)
    {
        try
        {
            if (pantalla == "Categorias")
                MostrarFormulario(new CategoriasForm(_categorias, this));
            else if (pantalla == "Suplidores")
                MostrarFormulario(new SuplidoresForm(_suplidores, this));
            else if (pantalla == "Productos")
                MostrarFormulario(new ProductosForm(_productos, this));
            else if (pantalla == "Papelera")
                MostrarFormulario(new PapeleraForm(_categorias, _suplidores, _productos, this));
        }
        catch (Exception ex)
        {
            Logger.RegistrarLog(ex);
            MessageBox.Show("No se pudo abrir la pantalla. Inténtelo nuevamente.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void MostrarFormulario(Form formulario)
    {
        // Quitar la pantalla anterior.
        if (pnlPantalla.Controls.Count > 0)
            pnlPantalla.Controls[0].Dispose();

        // Colocar el formulario dentro del panel.
        formulario.TopLevel = false;
        formulario.FormBorderStyle = FormBorderStyle.None;
        formulario.Dock = DockStyle.Fill;
        pnlPantalla.Controls.Add(formulario);
        formulario.Show();
        pnlPantalla.BringToFront();
        pnlPantalla.Visible = true;
    }

    public void MostrarInicio()
    {
        pnlPantalla.Visible = false;
        if (pnlPantalla.Controls.Count > 0)
            pnlPantalla.Controls[0].Dispose();

        ActualizarTotales();
    }

    private void FormularioPrincipal_Load(object? sender, EventArgs e)
    {
        ActualizarTotales();
    }

    private void btnCategoria_Click(object? sender, EventArgs e)
    {
        AbrirPantalla("Categorias");
    }

    private void btnSuplidores_Click(object? sender, EventArgs e)
    {
        AbrirPantalla("Suplidores");
    }

    private void btnProductos_Click(object? sender, EventArgs e)
    {
        AbrirPantalla("Productos");
    }

    private void btnPapelera_Click(object? sender, EventArgs e)
    {
        AbrirPantalla("Papelera");
    }

    private void guna2PictureBox7_Click(object? sender, EventArgs e)
    {
        AbrirPantalla("Categorias");
    }

    private void guna2CirclePictureBox3_Click(object? sender, EventArgs e)
    {
        AbrirPantalla("Productos");
    }
}
