using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestionCatalogo
{
    public partial class Form1 : Form
    {
        // lista local
        private List<Articulos> listaArticulos;
        private int contador;
        public Form1()
        {
            InitializeComponent();
            contador = 0;
            cboCampo.Items.Add("ID");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
        }

        private void cargar()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            listaArticulos = negocio.listar();
            dgvCatalogo.DataSource = listaArticulos;

            foreach (Articulos aux in listaArticulos)
            {
                foreach (Imagenes url in aux.Imagen)
                {
                    cargarImagen(url.ToString());
                }
            }

            ocultarColumnas();
        }

        //Apenas carga la aplicacion, se ejecutara esto
        private void Form1_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            listaArticulos = negocio.listar();
            dgvCatalogo.DataSource = listaArticulos;
            //cargar imagen

            foreach (Articulos aux in listaArticulos)
            {
                foreach (Imagenes url in aux.Imagen)
                {
                    cargarImagen(url.ToString());
                }
            }

            ocultarColumnas();
        }

        private void ocultarColumnas()
        {
            dgvCatalogo.Columns["IdMarca"].Visible = false;
            dgvCatalogo.Columns["IdCategoria"].Visible = false;
        }

        private void dgvCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            Articulos aux = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;
            contador = 0;
            cargarImagen(aux.Imagen[contador].UrlImagen);


            //si solo tiene una imagen, inhabilita el boton de cambiar imagen
            if (aux.Imagen.Count == 1)
            {
                btnCambiarImagen.Enabled = false;
            }
            else
            {
                btnCambiarImagen.Enabled = true;
            }
        }

        private void cargarImagen(string url)
        {
            try
            {
                picArticulos.Load(url);
            }
            catch (Exception ex)
            {
                picArticulos.Load("https://www.drupal.org/files/project-images/broken-image.jpg");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formAlta alta = new formAlta();
            alta.ShowDialog();
            cargar();
        }

        private void picArticulos_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count != 0)
            {
                try
                {
                    Articulos aux = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;
                    if (contador <= aux.Imagen.Count - 1)
                    {
                        cargarImagen(aux.Imagen[contador].ToString());
                        contador++;
                    }
                    else
                    {
                        contador = 0;
                        cargarImagen(aux.Imagen[contador].ToString());
                        contador++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void picArticulos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count != 0)
            {
                Articulos seleccionado;
                seleccionado = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;

                FormDetalle modificar = new FormDetalle(seleccionado);
                modificar.ShowDialog();
                cargar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos seleccionado;
            seleccionado = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;

            formAlta modificar = new formAlta(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            Articulos seleccionado;
            int id;
            try
            {
                seleccionado = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;
                id = seleccionado.Id;
                DialogResult respuesta = MessageBox.Show("Seguro de eliminar el articulo " + id + "?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.Eliminar(id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cambiarImagen_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count != 0)
            {
                btnCambiarImagen.Enabled = true;
                Articulos aux = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;

                //cambiar imagen
                if (contador <= aux.Imagen.Count - 1)
                {
                    cargarImagen(aux.Imagen[contador].ToString());
                    contador++;
                }
                else
                {
                    contador = 0;
                    cargarImagen(aux.Imagen[contador].ToString());
                    contador++;
                }
            }
            else
            {
                btnCambiarImagen.Enabled = false;
            }
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedItem == null || cboCriterio.SelectedItem == null)
            {
                lblValidarCampo.ForeColor = Color.Red;
                lblValidarCampo.Text = "*";
                lblValidarCriterio.ForeColor = Color.Red;
                lblValidarCriterio.Text = "*";
                lblValidarFiltroAvanzado.ForeColor = Color.Red;
                lblValidarFiltroAvanzado.Text = "*";
                MessageBox.Show("los campos marcados son obligatorios");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "ID")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    txtFiltroAvanzado.BackColor = Color.IndianRed;
                    MessageBox.Show("debe ingresar numeros en este campo");
                    return true;
                }
                if ((!(soloNumero(txtFiltroAvanzado.Text))))
                {
                    MessageBox.Show("solo debe ingresar numeros en este campo");
                    return true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    txtFiltroAvanzado.BackColor = Color.IndianRed;
                    MessageBox.Show("Debe ingresar textod en el campo para poder filtrar");
                    return true;
                }
            }
            return false;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> listaFiltrada;

            string filtro = txtBuscar.Text;


            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));

                if (listaFiltrada.LongCount() == 0)
                {
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            else
            {
                listaFiltrada = listaArticulos;
            }


            dgvCatalogo.DataSource = null;
            dgvCatalogo.DataSource = listaFiltrada;
            ocultarColumnas();
        }
        private bool soloNumero(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            cboCriterio.Items.Clear();
            if (opcion == "ID")
            {
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtFiltroAvanzado.Text) && !string.IsNullOrWhiteSpace(txtFiltroAvanzado.Text))
            //{
                ArticulosNegocio negocio = new ArticulosNegocio();
                try
                {
                    if (validarFiltro())
                        return;
                    string campo = cboCampo.SelectedItem.ToString();
                    string criterio = cboCriterio.SelectedItem.ToString();
                    string filtro = txtFiltroAvanzado.Text;

                    dgvCatalogo.DataSource = negocio.filtrar(campo, criterio, filtro);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            //}
            //else
            //{
            //    lblValidarFiltroAvanzado.ForeColor = Color.Red;
            //    lblValidarFiltroAvanzado.Text = "*";
            //    lblValidarCampo.ForeColor = Color.Red;
            //    lblValidarCampo.Text = "*";
            //    lblValidarCriterio.ForeColor = Color.Red;
            //    lblValidarCriterio.Text = "*";
            //    MessageBox.Show("los campos marcados son obligatorios");
            //}
        }

    }
}
