using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        
        
        
        
  

       // TEMA IMAGENES -----------------------------------------------------------------------------------------------
        
        private void cargarImagen(string imagen)
        {
            try
            {   
                //Cuando cargue por primera vez el pictureBox...
                pbxArticulo.Load(imagen); // Carga la imagen en el PictureBox
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://www.came-educativa.com.ar/upsoazej/2022/03/placeholder-2.png"); // Imagen por defecto
            }
        }
                       
        
        // Método para cargar la lista de artículos en el DataGridView

        // (A)
        private void cargar()
        {

            ArticuloNegocio negocio = new ArticuloNegocio();    


            try
            {


                listaArticulo = negocio.listar(); // Lista los artículos desde la base de datos
                dgvArticulos.DataSource = listaArticulo; // Muestra los artículos en el DataGridView
                ocultarColumnas();

                
                
                
                // Si hay artículos, carga la imagen del primero
                if(listaArticulo.Count > 0)
                {
                    cargarImagen(listaArticulo[0].UrlImagen);   //Si hay artículos, carga la imagen del primero
                }
            


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); // Muestra el error si ocurre
            }






        }


        //(B)
       //  Método para cargar todas las imágenes de un artículo en el PictureBox
      //   Buscar las imágenes asociadas al artículo en la tabla IMAGENES de la base de datos.
     //  Cargar la primera imagen en el PictureBox y, si hay varias, prepararlas para navegación
        private void cargarImagenesArticulo(int idArticulo)
        {
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            imagenesArticulo = imagenesNegocio.listar(idArticulo); // Lista de imágenes asociadas al artículo


            if (imagenesArticulo != null && imagenesArticulo.Count > 0)
            {
                indiceActualImagen = 0;
                cargarImagen(imagenesArticulo[indiceActualImagen]);//Carga LA primer Imagen.
            }
            else
            {
                // Si no hay imágenes, muestra una imagen por defecto
                cargarImagen("https://www.came-educativa.com.ar/upsoazej/2022/03/placeholder-2.png");
            }
        }

        

        // (c)  BOTON PARA SIGUIENTE IMAGEN Y ANTERIOR.
              
        // Botón para avanzar a la siguiente imagen
      
        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            if (imagenesArticulo != null && imagenesArticulo.Count > 0)
            {
                indiceActualImagen = (indiceActualImagen + 1) % imagenesArticulo.Count; //Avanzo a la porx img 
                cargarImagen(imagenesArticulo[indiceActualImagen]); //MUESTRO LA IMG.
                //LLAMO a cargar imagen para mostrarlo en el PictureBox.


            }
        }

        
        // Método para cargar las imágenes asociadas al artículo seleccionado en el DataGridView
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null) //Comprueba si actualmente hay una fila seleccionada en el DataGridView.
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem; // Obtiene el artículo seleccionado
                cargarImagenesArticulo(seleccionado.ID); // Carga las imágenes del artículo
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
       
        
        
        
        
        
        
        //BOTONES AGREGAR Y MODIFICAR ARTICULOS -----------------------------------------------------------------------------------------------------
        
        
        
        // Botón para agregar un nuevo artículo, ME MADA A frmAltaArticulo.
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulos alta = new frmAltaArticulos();
            alta.ShowDialog();
            cargar(); // Recarga los artículos después de agregar uno nuevo
        }

        
               
        // Botón para modificar un artículo seleccionado
        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null) //COMPRUEBO SI TENGO UNA CURRENROW SELECCIONADA EN LA GRILLA.
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem; //Obtengo el artículo que está vinculado a la fila seleccionada en el DataGridView.

                frmAltaArticulos modificar = new frmAltaArticulos(seleccionado); //instancio mi frm pasandole la fila seleccionda;

                modificar.ShowDialog();
                cargar(); //vuelve a cargar los artículos desde la base de datos y actualiza el DataGridView para mostrar los cambios.
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún artículo para modificar.");
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
        
        
        // Método para ocultar columnas de la grilla
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Codigo"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
        }



        //BOTON ELIMINAR ARTICULO.
        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            { 
                DialogResult respuesta = MessageBox.Show("Confirme nuevamente si quiere eliminarlo.", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //Muestra un mensaje de confirmación al usuario preguntando si realmente desea eliminar el artículo. Utiliza los botones Yes(Sí) y No(No)
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.ID);
                    cargar(); // recarga todos los artículos en el DataGridView. segura que la tabla se actualice y ya no muestre el artículo que se eliminó.
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningun articulo para eliminar");
                }

            }
            catch (Exception ex) { throw ex; }  






        }

       
        
        //FILTRO DE BUSQUEDA
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            //Esta lista contendrá los artículos que cumplan con el filtro ingresado por el usuario


            string filtro = txtFiltro.Text; //CAPTURAMOS EL TEXTO EN MI VARIABLE FILTRO.

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dgvArticulos.DataSource = null; //establece la fuente de datos del DataGridView a null para limpiar los datos actuales
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
            //Al asignar null y luego la lista filtrada, te aseguras de que el control se refresque correctamente con los nuevos datos.
        }

        
    } 
}
