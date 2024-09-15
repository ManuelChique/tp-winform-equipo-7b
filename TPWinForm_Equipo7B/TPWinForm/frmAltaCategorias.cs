using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm
{
    public partial class frmAltaCategorias : Form
    {
        private Categoria categoria = null;
        public frmAltaCategorias()
        {
            InitializeComponent();
        }
        public frmAltaCategorias(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");

            try
            {
                if (categoria == null)
                    categoria = new Categoria();

                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MessageBox.Show("⚠️ No se ingreso ninguna DESCRIPCION ⚠️");
                    return;
                }
                else if (!regex.IsMatch(txtDescripcion.Text))
                {
                    MessageBox.Show("⚠️ El contenido no permite caracteres especiales ⚠️");
                    return;
                }

                categoria.Descripcion = txtDescripcion.Text;

                if (categoria.ID != 0)
                {
                    negocio.modificarCategoria(categoria);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregarCategoria(categoria);
                    MessageBox.Show("Articulo agregado correctamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                if (categoria != null)
                {
                    txtDescripcion.Text = categoria.Descripcion;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
