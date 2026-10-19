using Guna.UI2.WinForms;
using SistemaInventario.Entidades;
using SistemaInventario.Entidades.Utilidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    public class EditarCategoriaForm : Form
    {
        private readonly CategoriaServicio _servicio;
        private readonly Categoria _entidad;
        private readonly ErrorProvider errores = new ErrorProvider();
        private readonly Guna2TextBox txtNombre = new Guna2TextBox();
        private readonly Guna2TextBox txtDescripcion = new Guna2TextBox();
        private readonly FlowLayoutPanel pnlFotos = new FlowLayoutPanel();
        private readonly Label lblContador = new Label();
        private readonly List<ImagenCategoria> fotosGuardadas = new List<ImagenCategoria>();
        private readonly List<string> rutasFotos = new List<string>();
        private readonly List<int> idsFotosQuitar = new List<int>();
        private PictureBox? fotoSeleccionada;

        /// <summary>
        /// Recibe el servicio y, al editar, los datos que se mostrarán.
        /// </summary>
        public EditarCategoriaForm(CategoriaServicio servicio, Categoria? entidad = null)
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
            Load += Formulario_Load;
        }

        private void InitializeComponent()
        {
            Text = "Categoría";
            ClientSize = new Size(520, 460);
            BackColor = Color.FromArgb(244, 246, 249);
            Font = new Font("Trebuchet MS", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            errores.ContainerControl = this;
            Label lblNombre = new Label { Text = "Nombre", Location = new Point(24, 20), AutoSize = true };
            txtNombre.Location = new Point(24, 46);
            txtNombre.Size = new Size(458, 38);
            txtNombre.BorderRadius = 5;
            txtNombre.MaxLength = 100;
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Label lblDescripcion = new Label { Text = "Descripción", Location = new Point(24, 98), AutoSize = true };
            txtDescripcion.Location = new Point(24, 124);
            txtDescripcion.Size = new Size(458, 38);
            txtDescripcion.BorderRadius = 5;
            txtDescripcion.MaxLength = 500;
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Label lblFotos = new Label { Text = "Fotos (JPG, JPEG o PNG; máximo 2 MB cada una)", Location = new Point(24, 180), AutoSize = true };
            lblContador.Location = new Point(432, 210);
            lblContador.Size = new Size(50, 28);
            lblContador.Text = "0/5";
            pnlFotos.Location = new Point(24, 244);
            pnlFotos.Size = new Size(458, 132);
            pnlFotos.AutoScroll = true;
            pnlFotos.WrapContents = false;
            pnlFotos.BorderStyle = BorderStyle.FixedSingle;
            Guna2Button btnAgregarFoto = new Guna2Button { Text = "Agregar foto", Location = new Point(24, 208), Size = new Size(150, 30), BorderRadius = 8, FillColor = Color.FromArgb(40, 112, 237) };
            Guna2Button btnQuitarFoto = new Guna2Button { Text = "Quitar seleccionada", Location = new Point(184, 208), Size = new Size(198, 30), BorderRadius = 8, FillColor = Color.FromArgb(220, 56, 56) };
            btnAgregarFoto.Click += AgregarFoto_Click;
            btnQuitarFoto.Click += QuitarFoto_Click;
            Controls.AddRange(new Control[] { lblFotos, lblContador, pnlFotos, btnAgregarFoto, btnQuitarFoto });
            Guna2Button btnGuardar = new Guna2Button { Text = "Guardar", Location = new Point(210, 398), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(40, 112, 237) };
            Guna2Button btnCancelar = new Guna2Button { Text = "Cancelar", Location = new Point(350, 398), Size = new Size(132, 40), BorderRadius = 12, FillColor = Color.FromArgb(19, 44, 82), DialogResult = DialogResult.Cancel };
            btnGuardar.Click += Guardar_Click;
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                LimpiarMiniaturas();
                errores.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
