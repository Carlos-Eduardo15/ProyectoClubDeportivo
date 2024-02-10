namespace ClubDeportivo.Formularios
{
    partial class frmSocios
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoIngresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reIngresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarDeCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarPadrónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoIngresoToolStripMenuItem,
            this.reIngresoToolStripMenuItem,
            this.cambiarDeCategoríaToolStripMenuItem,
            this.consultarPadrónToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 92);
            // 
            // nuevoIngresoToolStripMenuItem
            // 
            this.nuevoIngresoToolStripMenuItem.Name = "nuevoIngresoToolStripMenuItem";
            this.nuevoIngresoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.nuevoIngresoToolStripMenuItem.Text = " Nuevo Ingreso";
            // 
            // reIngresoToolStripMenuItem
            // 
            this.reIngresoToolStripMenuItem.Name = "reIngresoToolStripMenuItem";
            this.reIngresoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.reIngresoToolStripMenuItem.Text = "ReIngreso";
            // 
            // cambiarDeCategoríaToolStripMenuItem
            // 
            this.cambiarDeCategoríaToolStripMenuItem.Name = "cambiarDeCategoríaToolStripMenuItem";
            this.cambiarDeCategoríaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cambiarDeCategoríaToolStripMenuItem.Text = " Cambiar de Categoría";
            // 
            // consultarPadrónToolStripMenuItem
            // 
            this.consultarPadrónToolStripMenuItem.Name = "consultarPadrónToolStripMenuItem";
            this.consultarPadrónToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.consultarPadrónToolStripMenuItem.Text = "Consultar Padrón";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(467, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cerrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSocios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmSocios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Socio del Club";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoIngresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reIngresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarDeCategoríaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarPadrónToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}