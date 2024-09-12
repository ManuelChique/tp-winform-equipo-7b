using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm
{
    public partial class frmArticulos : Form
    {

        // Lista de artículos y variables para las imágenes de cada artículo
        private List<Articulo> listaArticulo;
        private List<string> imagenesArticulo; // Lista de URLs de imágenes del artículo seleccionado
        private int indiceActualImagen; // Índice de la imagen actual en la lista

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar(); // Carga los artículos al iniciar el formulario
        }

        // Método para cargar la imagen en el PictureBox, si falla carga una imagen por defecto
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen); // Carga la imagen en el PictureBox
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://www.came-educativa.com.ar/upsoazej/2022/03/placeholder-2.png"); // Imagen por defecto
            }
        }

        // Método para ocultar columnas de la grilla
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Codigo"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
        }

        // Método para cargar la lista de artículos en el DataGridView
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulo = negocio.listar(); // Asigna los datos obtenidos de la base de datos a listaArticulo
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();

                if (listaArticulo.Count > 0)
                {
                    cargarImagen(listaArticulo[0].UrlImagen); // Carga la imagen del primer artículo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Método para mostrar más columnas si el checkbox está marcado
        private void chkbVerDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbVerDetalle.Checked)
            {
                dgvArticulos.Columns["Codigo"].Visible = true;
                dgvArticulos.Columns["Descripcion"].Visible = true;
                dgvArticulos.Columns["Categoria"].Visible = true;
            }
            else
            {
                ocultarColumnas();
            }
        }

        // Método para cargar las imágenes asociadas al artículo seleccionado en el DataGridView
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem; // Obtiene el artículo seleccionado
                cargarImagenesArticulo(seleccionado.ID); // Carga las imágenes del artículo
            }
        }

        // Método para cargar todas las imágenes de un artículo en el PictureBox
        private void cargarImagenesArticulo(int idArticulo)
        {
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            imagenesArticulo = imagenesNegocio.listar(idArticulo); // Trae las imágenes desde la base de datos

            if (imagenesArticulo != null && imagenesArticulo.Count > 0)
            {
                indiceActualImagen = 0; // Comenzamos con la primera imagen
                cargarImagen(imagenesArticulo[indiceActualImagen]); // Carga la primera imagen
            }
            else
            {
                // Si no hay imágenes, muestra una imagen por defecto
                cargarImagen("https://www.came-educativa.com.ar/upsoazej/2022/03/placeholder-2.png");
            }
        }

        // Botón para avanzar a la siguiente imagen
      
        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            if (imagenesArticulo != null && imagenesArticulo.Count > 0)
            {
                indiceActualImagen = (indiceActualImagen + 1) % imagenesArticulo.Count; // Avanza al siguiente índice
                cargarImagen(imagenesArticulo[indiceActualImagen]); // Muestra la nueva imagen
            }
        }

        // Botón para retroceder a la imagen anterior
     

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (imagenesArticulo != null && imagenesArticulo.Count > 0)
            {
                indiceActualImagen = (indiceActualImagen - 1 + imagenesArticulo.Count) % imagenesArticulo.Count; // Retrocede al índice anterior
                cargarImagen(imagenesArticulo[indiceActualImagen]); // Muestra la imagen anterior
            }
        }
       
        
        
        
        
        
        
        
        
        
        
        // Botón para agregar un nuevo artículo
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulos alta = new frmAltaArticulos();
            alta.ShowDialog();
            cargar(); // Recarga los artículos después de agregar uno nuevo
        }

        // Botón para modificar un artículo seleccionado
        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulos modificar = new frmAltaArticulos(seleccionado);
                modificar.ShowDialog();
                cargar(); // Recarga los artículos después de la modificación
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún artículo para modificar.");
            }
        }

    } 
}
