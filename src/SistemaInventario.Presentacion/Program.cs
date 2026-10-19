using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        FabricaServicios fabrica = new FabricaServicios();
        Application.Run(new FormularioPrincipal(fabrica.CrearCategoriaServicio(), fabrica.CrearSuplidorServicio(), fabrica.CrearProductoServicio()));
    }
}
