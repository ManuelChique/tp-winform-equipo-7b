
namespace TPWinForm
{
    partial class frmCategorias
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
            this.btnEliminarCategorias = new System.Windows.Forms.Button();
            this.btnModificarCategorias = new System.Windows.Forms.Button();
            this.btnAgregarCategorias = new System.Windows.Forms.Button();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtFiltroCategoria = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarCategorias
            // 
            this.btnEliminarCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCategorias.Location = new System.Drawing.Point(252, 351);
            this.btnEliminarCategorias.Name = "btnEliminarCategorias";
            this.btnEliminarCategorias.Size = new System.Drawing.Size(111, 37);
            this.btnEliminarCategorias.TabIndex = 19;
            this.btnEliminarCategorias.Text = "Eliminar";
            this.btnEliminarCategorias.UseVisualStyleBackColor = true;
            this.btnEliminarCategorias.Click += new System.EventHandler(this.btnEliminarCategorias_Click);
            // 
            // btnModificarCategorias
            // 
            this.btnModificarCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarCategorias.Location = new System.Drawing.Point(135, 351);
            this.btnModificarCategorias.Name = "btnModificarCategorias";
            this.btnModificarCategorias.Size = new System.Drawing.Size(111, 37);
            this.btnModificarCategorias.TabIndex = 18;
            this.btnModificarCategorias.Text = "Modificar";
            this.btnModificarCategorias.UseVisualStyleBackColor = true;
            this.btnModificarCategorias.Click += new System.EventHandler(this.btnModificarCategorias_Click);
            // 
            // btnAgregarCategorias
            // 
            this.btnAgregarCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCategorias.Location = new System.Drawing.Point(18, 351);
            this.btnAgregarCategorias.Name = "btnAgregarCategorias";
            this.btnAgregarCategorias.Size = new System.Drawing.Size(111, 37);
            this.btnAgregarCategorias.TabIndex = 17;
            this.btnAgregarCategorias.Text = "Agregar";
            this.btnAgregarCategorias.UseVisualStyleBackColor = true;
            this.btnAgregarCategorias.Click += new System.EventHandler(this.btnAgregarCategorias_Click);
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(18, 101);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowHeadersWidth = 51;
            this.dgvCategorias.Size = new System.Drawing.Size(547, 244);
            this.dgvCategorias.TabIndex = 16;
            this.dgvCategorias.SelectionChanged += new System.EventHandler(this.dgvCategorias_SelectionChanged);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.BackColor = System.Drawing.SystemColors.Control;
            this.lblCategoria.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(14, 56);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(199, 24);
            this.lblCategoria.TabIndex = 25;
            this.lblCategoria.Text = "Buscar Categoria :";
            // 
            // txtFiltroCategoria
            // 
            this.txtFiltroCategoria.Location = new System.Drawing.Point(219, 60);
            this.txtFiltroCategoria.Name = "txtFiltroCategoria";
            this.txtFiltroCategoria.Size = new System.Drawing.Size(176, 20);
            this.txtFiltroCategoria.TabIndex = 26;
            this.txtFiltroCategoria.TextChanged += new System.EventHandler(this.txtFiltroCategoria_TextChanged);
            this.txtFiltroCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroCategoria_KeyPress);
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.txtFiltroCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.btnEliminarCategorias);
            this.Controls.Add(this.btnModificarCategorias);
            this.Controls.Add(this.btnAgregarCategorias);
            this.Controls.Add(this.dgvCategorias);
            this.MaximumSize = new System.Drawing.Size(816, 486);
            this.MinimumSize = new System.Drawing.Size(816, 486);
            this.Name = "frmCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEliminarCategorias;
        private System.Windows.Forms.Button btnModificarCategorias;
        private System.Windows.Forms.Button btnAgregarCategorias;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtFiltroCategoria;
    }
}