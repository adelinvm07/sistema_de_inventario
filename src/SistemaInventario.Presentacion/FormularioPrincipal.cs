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

    private void AbrirPantalla(string pantalla)
    {
        try
        {
            while (pantalla != "")
            {
                if (pantalla == "Categorias")
                {
                    using (CategoriasForm formulario = new CategoriasForm(_categorias))
                    {
                        formulario.ShowDialog(this);
                        pantalla = formulario.PantallaSeleccionada;
                    }
                }
                else if (pantalla == "Suplidores")
                {
                    using (SuplidoresForm formulario = new SuplidoresForm(_suplidores))
                    {
                        formulario.ShowDialog(this);
                        pantalla = formulario.PantallaSeleccionada;
                    }
                }
                else if (pantalla == "Productos")
                {
                    using (ProductosForm formulario = new ProductosForm(_productos))
                    {
                        formulario.ShowDialog(this);
                        pantalla = formulario.PantallaSeleccionada;
                    }
                }
                else if (pantalla == "Papelera")
                {
                    using (PapeleraForm formulario = new PapeleraForm(_categorias, _suplidores, _productos))
                    {
                        formulario.ShowDialog(this);
                        pantalla = formulario.PantallaSeleccionada;
                    }
                }
                else
                    pantalla = "";
            }
            ActualizarTotales();
        }
        catch (Exception ex)
        {
            Logger.RegistrarLog(ex);
            MessageBox.Show("No se pudo abrir la pantalla. Inténtelo nuevamente.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
