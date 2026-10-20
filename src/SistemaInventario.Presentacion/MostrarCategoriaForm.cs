using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public partial class MostrarCategoriaForm : Form
    {
        private readonly CategoriaServicio _servicio;
        private readonly Categoria _entidad;
        private readonly List<ImagenCategoria> fotosGuardadas = new List<ImagenCategoria>();
        private readonly List<string> rutasFotos = new List<string>();
        private readonly List<int> idsFotosQuitar = new List<int>();
        private PictureBox? fotoSeleccionada;

        /// <summary>
        /// Recibe el servicio y, al editar, los datos que se mostrarán.
        /// </summary>
        public MostrarCategoriaForm(CategoriaServicio servicio, Categoria? entidad = null)
        {
            _servicio = servicio;
            _entidad = new Categoria();
            if (entidad != null)
            {
                _entidad.Id = entidad.Id;
                _entidad.Nombre = entidad.Nombre;
                _entidad.Descripcion = entidad.Descripcion;
            }
            InitializeComponent();
            txtNombre.Text = _entidad.Nombre;
            txtDescripcion.Text = _entidad.Descripcion;
            FormClosed += Formulario_FormClosed;
        }

        private void Guardar_Click(object? sender, EventArgs e)
        {
            errores.Clear();
            try
            {
                _entidad.Nombre = txtNombre.Text;
                _entidad.Descripcion = txtDescripcion.Text;
                Dictionary<string, string> mensajes = _servicio.Guardar(_entidad, rutasFotos, idsFotosQuitar);
                foreach (KeyValuePair<string, string> mensaje in mensajes)
                {
                    if (mensaje.Key == "Nombre")
                        errores.SetError(txtNombre, mensaje.Value);
                    else if (mensaje.Key == "Descripcion")
                        errores.SetError(txtDescripcion, mensaje.Value);
                    else if (mensaje.Key == "Fotos")
                        errores.SetError(pnlFotos, mensaje.Value);
                }
                if (mensajes.Count == 0)
                    DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo guardar el registro. Inténtelo nuevamente.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Formulario_Load(object? sender, EventArgs e)
        {
            try
            {
                if (_entidad.Id > 0)
                    fotosGuardadas.AddRange(_servicio.ObtenerFotos(_entidad.Id));
                MostrarFotos();
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudieron cargar las fotos. Abra nuevamente el formulario.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AgregarFoto_Click(object? sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialogo = new OpenFileDialog())
                {
                    dialogo.Title = "Seleccionar foto de la categoría";
                    dialogo.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (dialogo.ShowDialog(this) != DialogResult.OK)
                        return;
                    string mensaje = _servicio.ValidarFoto(_entidad.Id, dialogo.FileName, rutasFotos.Count, idsFotosQuitar);
                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje, "Foto no aceptada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Comprueba que se pueda mostrar antes de agregarla a las fotos pendientes.
                    using (Image imagen = Image.FromFile(dialogo.FileName))
                    {
                        rutasFotos.Add(dialogo.FileName);
                    }
                    errores.SetError(pnlFotos, "");
                    MostrarFotos();
                }
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo abrir la foto. Compruebe que sea una imagen válida y que el archivo esté disponible.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuitarFoto_Click(object? sender, EventArgs e)
        {
            if (fotoSeleccionada == null)
            {
                MessageBox.Show("Seleccione una miniatura para quitarla.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string dato = (string)fotoSeleccionada.Tag!;
                if (dato.StartsWith("guardada:"))
                    idsFotosQuitar.Add(int.Parse(dato.Substring(9)));
                else
                    rutasFotos.Remove(dato);
                MostrarFotos();
                errores.SetError(pnlFotos, "");
            }
            catch (Exception ex)
            {
                Logger.RegistrarLog(ex);
                MessageBox.Show("No se pudo quitar la foto. Inténtelo nuevamente.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarFotos()
        {
            LimpiarMiniaturas();
            foreach (ImagenCategoria foto in fotosGuardadas)
            {
                if (!idsFotosQuitar.Contains(foto.Id))
                {
                    using (MemoryStream memoria = new MemoryStream(foto.Datos))
                    using (Image imagen = Image.FromStream(memoria))
                    {
                        AgregarMiniatura(imagen, "guardada:" + foto.Id);
                    }
                }
            }
            foreach (string ruta in rutasFotos)
            {
                using (Image imagen = Image.FromFile(ruta))
                {
                    AgregarMiniatura(imagen, ruta);
                }
            }
            lblContador.Text = pnlFotos.Controls.Count + "/5";
        }

        private void AgregarMiniatura(Image imagen, string dato)
        {
            PictureBox miniatura = new PictureBox();
            miniatura.Image = new Bitmap(imagen);
            miniatura.Size = new Size(82, 100);
            miniatura.Margin = new Padding(3);
            miniatura.SizeMode = PictureBoxSizeMode.Zoom;
            miniatura.BorderStyle = BorderStyle.FixedSingle;
            miniatura.Cursor = Cursors.Hand;
            miniatura.Tag = dato;
            miniatura.Click += SeleccionarFoto_Click;
            pnlFotos.Controls.Add(miniatura);
        }

        private void SeleccionarFoto_Click(object? sender, EventArgs e)
        {
            if (fotoSeleccionada != null)
                fotoSeleccionada.BackColor = Color.Transparent;
            fotoSeleccionada = sender as PictureBox;
            if (fotoSeleccionada != null)
                fotoSeleccionada.BackColor = Color.LightBlue;
        }

        private void Formulario_FormClosed(object? sender, FormClosedEventArgs e)
        {
            LimpiarMiniaturas();
        }

        private void LimpiarMiniaturas()
        {
            fotoSeleccionada = null;
            while (pnlFotos.Controls.Count > 0)
            {
                PictureBox miniatura = (PictureBox)pnlFotos.Controls[0];
                if (miniatura.Image != null)
                    miniatura.Image.Dispose();
                miniatura.Dispose();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 100)
                label1.ForeColor = Color.DarkRed;
            else
                label1.ForeColor = Color.Black;

            label1.Text = txtNombre.TextLength.ToString() + "/100";
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.TextLength > 500)
                label2.ForeColor = Color.DarkRed;
            else
                label2.ForeColor = Color.Black;

            label2.Text = txtDescripcion.TextLength.ToString() + "/500";
        }
    }
}
