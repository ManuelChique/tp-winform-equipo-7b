﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace TPWinForm
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {

            frmArticulos ventana  = new frmArticulos();
            ventana.ShowDialog();

        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas ventana = new frmMarcas();
            ventana.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias ventana = new frmCategorias();
            ventana.ShowDialog();
        }
    }
}
