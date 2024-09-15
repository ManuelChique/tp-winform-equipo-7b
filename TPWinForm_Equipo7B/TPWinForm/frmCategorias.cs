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

namespace TPWinForm
{
    public partial class frmCategorias : Form
    {
        private List<Categoria> listaCategorias;

        public frmCategorias()
        {
            InitializeComponent();
            txtFiltroCategoria.KeyPress += txtFiltroCategoria_KeyPress;
        }

        private void cargar()
        {
            //Aca invoco la lectura a la BD...
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                listaCategorias = negocio.listar(); // Asigna los datos obtenidos de la base de datos a listaArticulo

                dgvCategorias.DataSource = listaCategorias; // Asigna listaArticulo como origen de datos para el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregarCategorias_Click(object sender, EventArgs e)
        {
            frmAltaCategorias ventana = new frmAltaCategorias();
            ventana.ShowDialog();
            cargar();
        }

        private void btnEliminarCategorias_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria seleccionada;

            try
            {
                DialogResult respuesta = MessageBox.Show("Confirme nuevamente si quiere eliminarlo.", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    if(dgvCategorias.CurrentRow != null)
                    {
                        seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                        negocio.eliminarCategoria(seleccionada.ID);
                        cargar();
                    }
                    else
                    {
                        MessageBox.Show("No se ha seleccionado ninguna categoria para eliminar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }         
        
        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                //current row (la fila actual) // dataBoundItem (dame el objeto enlazado).
                Categoria seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            }
        }

        private void txtFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> listaFiltrada;
            string filtro = txtFiltroCategoria.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaCategorias.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaCategorias;
            }
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = listaFiltrada;
        }

        private void txtFiltroCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter presionado es un dígito numérico
            if (char.IsDigit(e.KeyChar))
            {
                // Si es un dígito numérico, cancelar el evento KeyPress para evitar que se escriba en el TextBox
                e.Handled = true;
            }
        }

        private void btnModificarCategorias_Click(object sender, EventArgs e)
        {
            if(dgvCategorias.CurrentRow != null)
            {
                Categoria seleccionada;
                seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                frmAltaCategorias modificar = new frmAltaCategorias(seleccionada);
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna categoria para modificar");
            }
        }
    }
}
