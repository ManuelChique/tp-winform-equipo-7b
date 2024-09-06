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

namespace TPWinForm
{
    public partial class frmArticulos : Form
    {

        private List<Articulo> listaArticulo; //instancio mi lista de articulo para poder darle uso dentro de mis metodos.


        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
        }
        
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxArticulo.Load("https://www.came-educativa.com.ar/upsoazej/2022/03/placeholder-2.png");
            }


        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Codigo"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulo = negocio.listar(); // Asigno los datos obtenidos de mi BD a listaArticulo  
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();

                if(listaArticulo.Count > 0)
                {
                    cargarImagen(listaArticulo[0].UrlImagen);// Cargo la Picture del primer articulo.
                }


            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString());
            }

        }

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

        //Cuando  cambio la seleccion de la grilla, quiero cambiar la imagen correspondiente.
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
          if(dgvArticulos.CurrentRow != null)
            {
                //Current row(la fila actual) // dataBoundItem (dame el objeto enlazado).
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }
        }




    }
}
