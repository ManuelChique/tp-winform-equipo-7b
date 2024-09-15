
namespace TPWinForm
{
    partial class frmMarcas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.lblMarcas = new System.Windows.Forms.Label();
            this.btnAgregarMarcas = new System.Windows.Forms.Button();
            this.btnModificarMarcas = new System.Windows.Forms.Button();
            this.btnEliminarMarcas = new System.Windows.Forms.Button();
            this.txtFiltroMarca = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(18, 101);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.RowHeadersWidth = 51;
            this.dgvMarcas.Size = new System.Drawing.Size(547, 244);
            this.dgvMarcas.TabIndex = 1;
            this.dgvMarcas.SelectionChanged += new System.EventHandler(this.dgvMarcas_SelectionChanged);
            // 
            // lblMarcas
            // 
            this.lblMarcas.AutoSize = true;
            this.lblMarcas.BackColor = System.Drawing.SystemColors.Control;
            this.lblMarcas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcas.Location = new System.Drawing.Point(14, 56);
            this.lblMarcas.Name = "lblMarcas";
            this.lblMarcas.Size = new System.Drawing.Size(156, 24);
            this.lblMarcas.TabIndex = 2;
            this.lblMarcas.Text = "Buscar Marca:";
            // 
            // btnAgregarMarcas
            // 
            this.btnAgregarMarcas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMarcas.Location = new System.Drawing.Point(18, 351);
            this.btnAgregarMarcas.Name = "btnAgregarMarcas";
            this.btnAgregarMarcas.Size = new System.Drawing.Size(111, 37);
            this.btnAgregarMarcas.TabIndex = 3;
            this.btnAgregarMarcas.Text = "Agregar";
            this.btnAgregarMarcas.UseVisualStyleBackColor = true;
            this.btnAgregarMarcas.Click += new System.EventHandler(this.btnAgregarMarcas_Click);
            // 
            // btnModificarMarcas
            // 
            this.btnModificarMarcas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarMarcas.Location = new System.Drawing.Point(135, 351);
            this.btnModificarMarcas.Name = "btnModificarMarcas";
            this.btnModificarMarcas.Size = new System.Drawing.Size(111, 37);
            this.btnModificarMarcas.TabIndex = 4;
            this.btnModificarMarcas.Text = "Modificar";
            this.btnModificarMarcas.UseVisualStyleBackColor = true;
            this.btnModificarMarcas.Click += new System.EventHandler(this.btnModificarMarcas_Click);
            // 
            // btnEliminarMarcas
            // 
            this.btnEliminarMarcas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarMarcas.Location = new System.Drawing.Point(252, 351);
            this.btnEliminarMarcas.Name = "btnEliminarMarcas";
            this.btnEliminarMarcas.Size = new System.Drawing.Size(111, 37);
            this.btnEliminarMarcas.TabIndex = 5;
            this.btnEliminarMarcas.Text = "Eliminar";
            this.btnEliminarMarcas.UseVisualStyleBackColor = true;
            this.btnEliminarMarcas.Click += new System.EventHandler(this.btnEliminarMarcas_Click);
            // 
            // txtFiltroMarca
            // 
            this.txtFiltroMarca.Location = new System.Drawing.Point(176, 60);
            this.txtFiltroMarca.Name = "txtFiltroMarca";
            this.txtFiltroMarca.Size = new System.Drawing.Size(211, 20);
            this.txtFiltroMarca.TabIndex = 11;
            this.txtFiltroMarca.TextChanged += new System.EventHandler(this.txtFiltroMarca_TextChanged);
            this.txtFiltroMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroMarca_KeyPress);
            // 
            // frmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.txtFiltroMarca);
            this.Controls.Add(this.btnEliminarMarcas);
            this.Controls.Add(this.btnModificarMarcas);
            this.Controls.Add(this.btnAgregarMarcas);
            this.Controls.Add(this.lblMarcas);
            this.Controls.Add(this.dgvMarcas);
            this.MaximumSize = new System.Drawing.Size(816, 486);
            this.MinimumSize = new System.Drawing.Size(816, 486);
            this.Name = "frmMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcas";
            this.Load += new System.EventHandler(this.frmMarcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.Label lblMarcas;
        private System.Windows.Forms.Button btnAgregarMarcas;
        private System.Windows.Forms.Button btnModificarMarcas;
        private System.Windows.Forms.Button btnEliminarMarcas;
        private System.Windows.Forms.TextBox txtFiltroMarca;
    }
}