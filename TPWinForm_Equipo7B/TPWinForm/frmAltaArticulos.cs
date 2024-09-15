using Dominio;
using Negocio;//(0) Agregamos negocio.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace TPWinForm
{
    public partial class frmAltaArticulos : Form
    {


        private Articulo articulo = null; //(1)
        private OpenFileDialog archivo = null;   


        public frmAltaArticulos()
        {
            InitializeComponent();
        }


        public frmAltaArticulos(Articulo articulo) //(2) Constructor.
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void btnCancelar_Click(object sender, EventArgs e) //(3) btn para cancelar.
        {
            Close();
        }


        //(4) Funcion cargar imagen para usarla en el evento load.
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAltaArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxAltaArticulo.Load("https://www.came-educativa.com.ar/upsoazej/2022/03/placeholder-2.png");
            }
        }




        //(5)
        //Ahora configuramos el Load, cuando se carga por primera vez.
        // ACA TENEMOS QUE DARLE EL CONTENIDO A LOS DESPLEGABLES.
        private void frmAltaArticulos_Load(object sender, EventArgs e)
        {

            MarcasNegocio marcasNegocio = new MarcasNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();


            try
            {
                cboMarca.DataSource = marcasNegocio.listar();  // Se establece como fuente de datos del ComboBox 'cboMarca' una lista de marcas obtenida del método 'listar'
                                                              // de la clase MarcaNegocio.

                cboMarca.ValueMember = "Descripcion"; // Se especifica que el valor interno del ComboBox será la propiedad 'Descripcion' de cada marca. (VALOR)
                cboMarca.DisplayMember = "Descripcion"; // Se especifica que el valor interno del ComboBox será la propiedad 'Descripcion' de cada marca. (INTERFAZ)

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Descripcion";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;   
                    txtDescripcion.Text = articulo.Descripcion; 
                    txtUrlImagen.Text = articulo.UrlImagen; 
                    txtPrecio.Text = articulo.Precio.ToString();
                    cboMarca.SelectedValue = articulo.Marca.Descripcion;    
                    cboCategoria.SelectedValue = articulo.Categoria.Descripcion;
                    cargarImagen(articulo.UrlImagen);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); // En caso de error, muestra una ventana con el mensaje de error.
            }


        }

        
        
        //Cuando salgo de este campo que me cargue la imagen.
        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text); //Recordemos que espera un strig.

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio(); 

            // Expresión regular para validar que no haya caracteres especiales.
            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");

            // Expresión regular para validar que el precio solo tenga números y coma como separador decimal.
            Regex precioRegex = new Regex(@"^\d+(,\d+)?$");

            try
            {
                // Si el objeto 'articulo' es nulo (no existe), se crea una nueva instancia.
                if (articulo == null)
                    articulo = new Articulo();

                // Validación del campo de nombre: No debe estar vacío.
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("⚠️ No se ha ingresado ningun NOMBRE ⚠️");
                    return; // Si está vacío, muestra mensaje de advertencia y termina el método.
                }
                // Validación de caracteres especiales en el nombre.
                else if (!regex.IsMatch(txtNombre.Text))
                {
                    MessageBox.Show("⚠️ 'NOMBRE' no permite caracteres especiales ⚠️");
                    return; // Si tiene caracteres no permitidos, muestra advertencia y termina.
                }
                // Si todo es válido, asigna el nombre ingresado a la propiedad Nombre del objeto artículo.
                articulo.Nombre = txtNombre.Text;

                // Validación del código: No debe estar vacío.
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MessageBox.Show("⚠️ No se ha ingresado ningun CODIGO ⚠️");
                    return;
                }
                // Validación de caracteres especiales en el código.
                else if (!regex.IsMatch(txtCodigo.Text))
                {
                    MessageBox.Show("⚠️ 'CODIGO' no permite caracteres especiales ⚠️");
                    return;
                }
                // Asignación del código ingresado a la propiedad Codigo.
                articulo.Codigo = txtCodigo.Text;

                // Validación de caracteres especiales en la descripción.
                if (!regex.IsMatch(txtDescripcion.Text))
                {
                    MessageBox.Show("⚠️ 'DESCRIPCION' no permite caracteres especiales ⚠️");
                    return;
                }
                // Asignación de la descripción.
                articulo.Descripcion = txtDescripcion.Text;

                // Asignación de la URL de la imagen.
                articulo.UrlImagen = txtUrlImagen.Text;

                // Validación del formato del precio: Solo permite números y coma para decimales.
                if (!precioRegex.IsMatch(txtPrecio.Text))
                {
                    MessageBox.Show("⚠️ 'PRECIO' solo permite números y comas ⚠️");
                    return;
                }
                // Conversión del texto del precio a decimal y asignación a la propiedad Precio.
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                // Asigna la marca seleccionada en el ComboBox a la propiedad Marca del artículo.
                articulo.Marca = (Marca)cboMarca.SelectedItem;

                // Asigna la categoría seleccionada en el ComboBox a la propiedad Categoria del artículo.
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

              
                
                
                
                // Si el ID del artículo es distinto de 0, significa que el artículo ya existe, por lo que se modifica.
                if (articulo.ID != 0)
                {
                    negocio.modificar(articulo); // Modifica los datos generales del artículo.
                    negocio.modificarCategoriaArticulo(articulo); // Modifica la categoría del artículo.
                    negocio.modificarMarcaArticulo(articulo); // Modifica la marca del artículo.
                    MessageBox.Show("Modificado exitosamente"); // Muestra mensaje de éxito.
                }
                // Si el ID es 0, es un artículo nuevo, por lo que se agrega a la base de datos.
                else
                {
                    negocio.agregar(articulo); // Agrega el artículo a la BD.
                    
                    negocio.agregarImagen(articulo); // Agrega la imagen del artículo. Recordemos que en mi BD la urlImagen esta en Imagenes no en Articulo.


                    MessageBox.Show("Articulo agregado correctamente"); // Muestra mensaje de éxito.
                }


                //Guardo imagen si la levanto localmente.
                if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP") ) )
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                }





                Close(); // Cierra el formulario después de la operación.
            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra un mensaje con el detalle de la excepción.
                MessageBox.Show(ex.ToString());
            }



        }


        //Subir imagen de manera local.
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            //OpenFileDialog archivo = new OpenFileDialog(); // me genera una ventana de dialogo para elegir la imagen.
            archivo.Filter = "jpg|*.jpg"; // filtrar que tipo de archvio me permite
            if(archivo.ShowDialog() == DialogResult.OK) //ESTO  ME PERMITE CAPTURAR EL ARCHIVO.
            {
                txtUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);


                //Guardo lA IMG
              //  File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);


            }

        }



    }
}
