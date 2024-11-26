using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestionCatalogo
{
    public partial class formAlta : Form
    {
        private List<string> urlsPorCargar;
        private Articulos articulo;
        public formAlta()
        {
            InitializeComponent();
            urlsPorCargar = new List<string>();
        }
        public formAlta(Articulos articulo)
        {
            InitializeComponent();
            urlsPorCargar = new List<string>();
            this.articulo = articulo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            urlsPorCargar.Clear();
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            ImagenesNegocio imgNegocio = new ImagenesNegocio();

            try
            {

                if(articulo == null)
                    articulo = new Articulos();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtNombre.Text;
                articulo.Categoria = (Categorias)boxCategoria.SelectedItem;
                articulo.Marca = (Marcas)boxMarca.SelectedItem;
                articulo.Precio = decimal.Parse(txtPrecio.Text);


                if(articulo.Id != 0)
                {
                    negocio.Modificar(articulo);
                    MessageBox.Show("modificado exitosamente");
                }
                else
                {
                    negocio.Agregar(articulo);
                    MessageBox.Show("agregado exitosamente");
                    articulo.Id = negocio.UltimoArticuloCargado();
                }


                if (urlsPorCargar.Count == 0)
                {
                    urlsPorCargar.Add("");
                }
                if (urlsPorCargar.Count == 1) {
                    imgNegocio.cargarImagen(articulo.Id, urlsPorCargar[0]);
                } else if (urlsPorCargar.Count > 1)
                {
                    imgNegocio.cargarImagenes(articulo.Id, urlsPorCargar);
                }

                urlsPorCargar.Clear();
                MessageBox.Show("Articulo agregado correctamente");
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formAlta_Load(object sender, EventArgs e)
        {
            MarcasNegocio marca = new MarcasNegocio();
            CategoriasNegocio categoria = new CategoriasNegocio();
            ImagenesNegocio imagen = new ImagenesNegocio();
            urlsPorCargar.Clear();
            try
            {
                boxCategoria.DataSource = categoria.listar();
                boxCategoria.ValueMember = "Id";
                boxCategoria.DisplayMember = "Descripcion";
                
                boxMarca.DataSource = marca.listar();
                boxMarca.ValueMember = "Id";
                boxMarca.DisplayMember = "Descripcion";

                if (this.articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;

                    boxCategoria.SelectedValue = articulo.Categoria.Id;
                    boxMarca.SelectedValue = articulo.Marca.Id;

                    txtPrecio.Text = articulo.Precio.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrlImagen.Text != "")
                {
                    urlsPorCargar.Add(txtUrlImagen.Text);
                    txtUrlImagen.Text = "";
                }
                // agregar un case else en el cual se agregue un aviso de que el campo esta vacio
                // y es necesario rellenarlo para enviar.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
