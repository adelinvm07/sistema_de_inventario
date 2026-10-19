using SistemaInventario.LogicaNegocio;
namespace SistemaInventario.Presentacion;

public partial class FormularioPrincipal : Form
{
    public FormularioPrincipal()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var fabrica = new FabricaServicios();

        int categorias = fabrica.CrearCategoriaServicio().ObtenerTodas().Count;
        int suplidores = fabrica.CrearSuplidorServicio().ObtenerTodos().Count;
        int productos = fabrica.CrearProductoServicio().ObtenerTodos().Count;

        MessageBox.Show("Categorías: " + categorias +
                        "\nSuplidores: " + suplidores +
                        "\nProductos: " + productos);
    }
}
