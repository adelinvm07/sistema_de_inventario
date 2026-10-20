using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class DetalleCategoriaForm : Form
    {
        private readonly CategoriaServicio _servicio;
        private readonly int idCategoria;

        /// <summary>
        /// Recibe el servicio y la categoría que se desea consultar.
        /// </summary>
        public DetalleCategoriaForm(CategoriaServicio servicio, Categoria categoria)
        {
            InitializeComponent();
            _servicio = servicio;
            idCategoria = categoria.Id;
        }

        private void Formulario_Load(object? sender, EventArgs e)
        {
            try
            {
                Categoria? categoria = _servicio.ObtenerPorId(idCategoria);
                if (categoria == null || !categoria.Activo)
                {
                    MessageBox.Show("La categoría ya no está disponible.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                lblNombre.Text = categoria.Nombre;
                txtDescripcion.Text = categoria.Descripcion;
                lblCreacion.Text = "Creada: " + categoria.FechaCreacion.ToString("dd/MM/yyyy");
                lblModificacion.Text = "Modificada: " + categoria.FechaModificacion.ToString("dd/MM/yyyy");
                List<Productos> productos = _servicio.ObtenerProductos(idCategoria);
                dgvProductos.DataSource = productos;
                lblProductos.Text = "Productos activos: " + productos.Count;
                List<ImagenCategoria> fotos = _servicio.ObtenerFotos(idCategoria);
                lblFotos.Text = "Fotos: " + fotos.Count + "/5";
                foreach (ImagenCategoria foto in fotos)
                {
                    using (MemoryStream memoria = new MemoryStream(foto.Datos))
                    using (Image imagen = Image.FromStream(memoria))
                    {
                        PictureBox miniatura = new PictureBox();
                        miniatura.Size = new Size(120, 100);
                        miniatura.Margin = new Padding(5);
                        miniatura.SizeMode = PictureBoxSizeMode.Zoom;
                        miniatura.BorderStyle = BorderStyle.FixedSingle;
                        miniatura.Image = new Bitmap(imagen);
                        pnlFotos.Controls.Add(miniatura);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo cargar la información de la categoría.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void Formulario_FormClosed(object? sender, FormClosedEventArgs e)
        {
            foreach (PictureBox miniatura in pnlFotos.Controls)
            {
                if (miniatura.Image != null)
                    miniatura.Image.Dispose();
            }
        }
    }
}