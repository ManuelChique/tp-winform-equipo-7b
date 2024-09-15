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
using Dominio;
using Negocio;

namespace TPWinForm
{
    public partial class frmAltaMarcas : Form
    {
        private Marca marca = null;
        public frmAltaMarcas()
        {
            InitializeComponent();
        }
        public frmAltaMarcas(Marca marca)
        {
            InitializeComponent();
            this.marca = marca; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void frmAltaMarcas_Load(object sender, EventArgs e)
        {
            try
            {
                if (marca != null)
                {
                    txtDescripcion.Text = marca.Descripcion;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MarcasNegocio negocio = new MarcasNegocio();
            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");

            try
            {
                if (marca == null)
                    marca = new Marca();

                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MessageBox.Show("⚠ No se ingreso ninguna descripcion ⚠");
                    return;
                }
                else if (!regex.IsMatch(txtDescripcion.Text))
                {
                    MessageBox.Show("⚠ La descripcion no permite caracteres especiales ⚠");
                    return;
                }

                marca.Descripcion = txtDescripcion.Text;

                if (marca.ID != 0)
                {
                    negocio.modificarMarca(marca);        
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregarMarcas(marca);
                    MessageBox.Show("Articulo agregado correctamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
