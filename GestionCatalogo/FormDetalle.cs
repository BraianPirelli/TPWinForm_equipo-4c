using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCatalogo
{
    public partial class FormDetalle : Form
    {
        int contador;
        private Articulos articulo;
        public FormDetalle()
        {
            InitializeComponent();
        }

        public FormDetalle(Articulos articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void FormDetalle_Load(object sender, EventArgs e)
        {
            //
            ImagenesNegocio imagen = new ImagenesNegocio();
            try
            {
                contador = 0;
                lblCodigo.Text = articulo.Codigo.ToString();
                lblCategoria.Text = articulo.Categoria.ToString();
                lblMarca.Text = articulo.Marca.ToString();
                lblNombre.Text = articulo.Nombre;
                lblPrecio.Text = "$" + articulo.Precio.ToString();
                boxDescripcion.Text = articulo.Descripcion;
                boxDescripcion.Enabled = false;
                cargarImagen(articulo.Imagen[contador].ToString());
                btnAtras.Enabled = false;
                btnAdelante.Enabled = false;
                if (articulo.Imagen.Count > 1)
                {
                    btnAdelante.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            contador--;
            if (contador == 0)
            {
                btnAtras.Enabled = false;
                cargarImagen(articulo.Imagen[contador].ToString());
                btnAdelante.Enabled = true;
            }
            else if (contador > 0 && (contador < articulo.Imagen.Count))
            {
                btnAdelante.Enabled = true;
                cargarImagen(articulo.Imagen[contador].ToString());
                btnAtras.Enabled = true;
            }

        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            contador++;
            btnAtras.Enabled = true;
            if (contador >= articulo.Imagen.Count - 1)
            {
                btnAdelante.Enabled = false;
            }
            if (contador > 0 && (contador < articulo.Imagen.Count-1))
            {
                btnAdelante.Enabled = true;
                cargarImagen(articulo.Imagen[contador].ToString());
            }
            else
            {
                cargarImagen(articulo.Imagen[contador].ToString());
                btnAdelante.Enabled = false;
            }
        }

        private void cargarImagen(string url)
        {
            try
            {
                pboxImagen.Load(url);
            }
            catch (Exception ex)
            {
                pboxImagen.Load("https://www.drupal.org/files/project-images/broken-image.jpg");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}
