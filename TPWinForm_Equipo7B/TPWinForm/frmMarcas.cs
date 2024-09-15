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
    public partial class frmMarcas : Form
    {
        private List<Marca> listaMarca;
        
        public frmMarcas()
        {
            InitializeComponent();
            txtFiltroMarca.KeyPress += txtFiltroMarca_KeyPress;
        }

        private void cargar()
        {
            //Aca invoco la lectura a la BD...
            MarcasNegocio negocio = new MarcasNegocio();

            try
            {
                listaMarca = negocio.listar(); // Asigna los datos obtenidos de la base de datos a listaArticulo

                dgvMarcas.DataSource = listaMarca; // Asigna listaArticulo como origen de datos para el DataGridView         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargar();       
        }

        private void btnAgregarMarcas_Click(object sender, EventArgs e)
        {
            frmAltaMarcas ventana = new frmAltaMarcas();
            ventana.ShowDialog();
            cargar();
        }

        private void btnEliminarMarcas_Click(object sender, EventArgs e)
        {
            MarcasNegocio negocio = new MarcasNegocio();
            Marca seleccionada;

            try
            {
                DialogResult respuesta = MessageBox.Show("Confirme nuevamente si quiere eliminarlo.", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    if (dgvMarcas.CurrentRow != null)
                    {
                        seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                        negocio.eliminarMarca(seleccionada.ID);
                        cargar();
                    }
                    else
                    {
                        MessageBox.Show("No se ha seleccionado ninguna marca para eliminar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltroMarca_TextChanged(object sender, EventArgs e)
        {
            List<Marca> listaFiltrada;
            string filtro = txtFiltroMarca.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaMarca.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaMarca;
            }
            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = listaFiltrada;         
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                //current row (la fila actual) // dataBoundItem (dame el objeto enlazado).
                Marca seleccionado = (Marca)dgvMarcas.CurrentRow.DataBoundItem;        
            }
        }

        private void txtFiltroMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter presionado es un dígito numérico
            if (char.IsDigit(e.KeyChar))
            {
                // Si es un dígito numérico, cancelar el evento KeyPress para evitar que se escriba en el TextBox
                e.Handled = true;
            }
        }

        private void btnModificarMarcas_Click(object sender, EventArgs e)
        {
            if(dgvMarcas.CurrentRow != null)
            {
                Marca seleccionada;
                seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

                frmAltaMarcas modificar = new frmAltaMarcas(seleccionada);
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna marca para modificar");
            }
        }
    } 
}

