
namespace ClubDeportivo.Formularios
{
    partial class frmSociosFallecidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSociosFallecidos));
            this.dgvDefunciones = new System.Windows.Forms.DataGridView();
            this.num_socio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagos_historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_defuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pago_defuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beneficiario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefunciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDefunciones
            // 
            this.dgvDefunciones.AllowUserToAddRows = false;
            this.dgvDefunciones.AllowUserToDeleteRows = false;
            this.dgvDefunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefunciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num_socio,
            this.nombre,
            this.fecha_nacimiento,
            this.pagos_historico,
            this.fecha_defuncion,
            this.pago_defuncion,
            this.beneficiario});
            this.dgvDefunciones.Location = new System.Drawing.Point(12, 72);
            this.dgvDefunciones.Name = "dgvDefunciones";
            this.dgvDefunciones.ReadOnly = true;
            this.dgvDefunciones.Size = new System.Drawing.Size(759, 311);
            this.dgvDefunciones.TabIndex = 0;
            // 
            // num_socio
            // 
            this.num_socio.DataPropertyName = "id_socio";
            this.num_socio.HeaderText = "Número de socio";
            this.num_socio.Name = "num_socio";
            this.num_socio.ReadOnly = true;
            this.num_socio.Width = 55;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre_completo";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 150;
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.DataPropertyName = "fecha_nacimiento";
            this.fecha_nacimiento.HeaderText = "Fecha de nacimiento";
            this.fecha_nacimiento.MinimumWidth = 70;
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.ReadOnly = true;
            this.fecha_nacimiento.Width = 70;
            // 
            // pagos_historico
            // 
            dataGridViewCellStyle1.Format = "C2";
            this.pagos_historico.DefaultCellStyle = dataGridViewCellStyle1;
            this.pagos_historico.HeaderText = "Monto acumulado";
            this.pagos_historico.Name = "pagos_historico";
            this.pagos_historico.ReadOnly = true;
            // 
            // fecha_defuncion
            // 
            this.fecha_defuncion.DataPropertyName = "fecha_defuncion";
            this.fecha_defuncion.HeaderText = "Fecha de defunción";
            this.fecha_defuncion.MinimumWidth = 70;
            this.fecha_defuncion.Name = "fecha_defuncion";
            this.fecha_defuncion.ReadOnly = true;
            this.fecha_defuncion.Width = 70;
            // 
            // pago_defuncion
            // 
            this.pago_defuncion.DataPropertyName = "monto";
            dataGridViewCellStyle2.Format = "C2";
            this.pago_defuncion.DefaultCellStyle = dataGridViewCellStyle2;
            this.pago_defuncion.HeaderText = "Pago por defunción";
            this.pago_defuncion.Name = "pago_defuncion";
            this.pago_defuncion.ReadOnly = true;
            // 
            // beneficiario
            // 
            this.beneficiario.DataPropertyName = "beneficiario";
            this.beneficiario.HeaderText = "Beneficiario(a)";
            this.beneficiario.Name = "beneficiario";
            this.beneficiario.ReadOnly = true;
            this.beneficiario.Width = 170;
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Location = new System.Drawing.Point(669, 389);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(101, 23);
            this.btnGenerarPDF.TabIndex = 1;
            this.btnGenerarPDF.Text = "Generar PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista de socios fallecidos";
            // 
            // frmSociosFallecidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 424);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarPDF);
            this.Controls.Add(this.dgvDefunciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSociosFallecidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Socios Fallecidos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefunciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDefunciones;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_socio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagos_historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_defuncion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pago_defuncion;
        private System.Windows.Forms.DataGridViewTextBoxColumn beneficiario;
        private System.Windows.Forms.Label label1;
    }
}