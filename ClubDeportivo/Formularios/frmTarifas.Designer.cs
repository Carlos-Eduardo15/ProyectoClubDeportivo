namespace ClubDeportivo.Formularios
{
    partial class frmTarifas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCasaClub = new System.Windows.Forms.TabPage();
            this.btnActualizarTarifaCC = new System.Windows.Forms.Button();
            this.dgvTarifasCC = new System.Windows.Forms.DataGridView();
            this.id_tarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto_tarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_tarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMontoCC = new System.Windows.Forms.TextBox();
            this.txtConceptoCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGuardarTarifaCC = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTarifasAM = new System.Windows.Forms.DataGridView();
            this.id_tarifa_am = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto_tarifa_am = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_tarifa_am = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizarTarifaAM = new System.Windows.Forms.Button();
            this.txtMontoAM = new System.Windows.Forms.TextBox();
            this.txtConceptoAM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardarTarifaAM = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ttMonto = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tpCasaClub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasCC)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasAM)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCasaClub);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.tabControl1.Location = new System.Drawing.Point(-1, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 431);
            this.tabControl1.TabIndex = 0;
            // 
            // tpCasaClub
            // 
            this.tpCasaClub.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpCasaClub.Controls.Add(this.btnActualizarTarifaCC);
            this.tpCasaClub.Controls.Add(this.dgvTarifasCC);
            this.tpCasaClub.Controls.Add(this.txtMontoCC);
            this.tpCasaClub.Controls.Add(this.txtConceptoCC);
            this.tpCasaClub.Controls.Add(this.label3);
            this.tpCasaClub.Controls.Add(this.label2);
            this.tpCasaClub.Controls.Add(this.label1);
            this.tpCasaClub.Controls.Add(this.button2);
            this.tpCasaClub.Controls.Add(this.btnGuardarTarifaCC);
            this.tpCasaClub.Location = new System.Drawing.Point(4, 26);
            this.tpCasaClub.Name = "tpCasaClub";
            this.tpCasaClub.Padding = new System.Windows.Forms.Padding(3);
            this.tpCasaClub.Size = new System.Drawing.Size(457, 401);
            this.tpCasaClub.TabIndex = 0;
            this.tpCasaClub.Text = "Casa Club";
            this.tpCasaClub.Click += new System.EventHandler(this.tpCasaClub_Click_1);
            // 
            // btnActualizarTarifaCC
            // 
            this.btnActualizarTarifaCC.Location = new System.Drawing.Point(154, 160);
            this.btnActualizarTarifaCC.Name = "btnActualizarTarifaCC";
            this.btnActualizarTarifaCC.Size = new System.Drawing.Size(121, 34);
            this.btnActualizarTarifaCC.TabIndex = 8;
            this.btnActualizarTarifaCC.Text = "Actualizar datos";
            this.btnActualizarTarifaCC.UseVisualStyleBackColor = true;
            this.btnActualizarTarifaCC.Click += new System.EventHandler(this.btnActualizarTarifaCC_Click);
            // 
            // dgvTarifasCC
            // 
            this.dgvTarifasCC.AllowUserToAddRows = false;
            this.dgvTarifasCC.AllowUserToDeleteRows = false;
            this.dgvTarifasCC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTarifasCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifasCC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_tarifa,
            this.concepto_tarifa,
            this.monto_tarifa});
            this.dgvTarifasCC.Location = new System.Drawing.Point(25, 209);
            this.dgvTarifasCC.Name = "dgvTarifasCC";
            this.dgvTarifasCC.ReadOnly = true;
            this.dgvTarifasCC.Size = new System.Drawing.Size(405, 166);
            this.dgvTarifasCC.TabIndex = 7;
            this.dgvTarifasCC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarifasCC_CellContentClick);
            // 
            // id_tarifa
            // 
            this.id_tarifa.DataPropertyName = "id_tarifa";
            this.id_tarifa.HeaderText = "ID";
            this.id_tarifa.Name = "id_tarifa";
            this.id_tarifa.ReadOnly = true;
            this.id_tarifa.Width = 40;
            // 
            // concepto_tarifa
            // 
            this.concepto_tarifa.DataPropertyName = "concepto";
            this.concepto_tarifa.HeaderText = "Concepto";
            this.concepto_tarifa.Name = "concepto_tarifa";
            this.concepto_tarifa.ReadOnly = true;
            this.concepto_tarifa.Width = 220;
            // 
            // monto_tarifa
            // 
            this.monto_tarifa.DataPropertyName = "monto";
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = "0";
            this.monto_tarifa.DefaultCellStyle = dataGridViewCellStyle8;
            this.monto_tarifa.HeaderText = "Monto";
            this.monto_tarifa.Name = "monto_tarifa";
            this.monto_tarifa.ReadOnly = true;
            // 
            // txtMontoCC
            // 
            this.txtMontoCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoCC.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.txtMontoCC.Location = new System.Drawing.Point(119, 103);
            this.txtMontoCC.Name = "txtMontoCC";
            this.txtMontoCC.Size = new System.Drawing.Size(90, 24);
            this.txtMontoCC.TabIndex = 6;
            this.txtMontoCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoCC_KeyPress);
            // 
            // txtConceptoCC
            // 
            this.txtConceptoCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConceptoCC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConceptoCC.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.txtConceptoCC.Location = new System.Drawing.Point(119, 64);
            this.txtConceptoCC.Name = "txtConceptoCC";
            this.txtConceptoCC.Size = new System.Drawing.Size(311, 24);
            this.txtConceptoCC.TabIndex = 5;
            this.txtConceptoCC.TextChanged += new System.EventHandler(this.txtConcepto_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.label3.Location = new System.Drawing.Point(40, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Concepto: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F);
            this.label1.Location = new System.Drawing.Point(163, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nueva tarifa";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(290, 160);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(3);
            this.button2.Size = new System.Drawing.Size(140, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cerrar el formulario";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnGuardarTarifaCC
            // 
            this.btnGuardarTarifaCC.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarTarifaCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarTarifaCC.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGuardarTarifaCC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnGuardarTarifaCC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnGuardarTarifaCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTarifaCC.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTarifaCC.Location = new System.Drawing.Point(25, 160);
            this.btnGuardarTarifaCC.Name = "btnGuardarTarifaCC";
            this.btnGuardarTarifaCC.Padding = new System.Windows.Forms.Padding(3);
            this.btnGuardarTarifaCC.Size = new System.Drawing.Size(113, 34);
            this.btnGuardarTarifaCC.TabIndex = 0;
            this.btnGuardarTarifaCC.Text = "Guardar datos";
            this.btnGuardarTarifaCC.UseVisualStyleBackColor = false;
            this.btnGuardarTarifaCC.Click += new System.EventHandler(this.btnGuardarTarifaCC_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.dgvTarifasAM);
            this.tabPage2.Controls.Add(this.btnActualizarTarifaAM);
            this.tabPage2.Controls.Add(this.txtMontoAM);
            this.tabPage2.Controls.Add(this.txtConceptoAM);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnGuardarTarifaAM);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ayuda Mutua";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // dgvTarifasAM
            // 
            this.dgvTarifasAM.AllowUserToAddRows = false;
            this.dgvTarifasAM.AllowUserToDeleteRows = false;
            this.dgvTarifasAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifasAM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_tarifa_am,
            this.concepto_tarifa_am,
            this.monto_tarifa_am});
            this.dgvTarifasAM.Location = new System.Drawing.Point(24, 210);
            this.dgvTarifasAM.Name = "dgvTarifasAM";
            this.dgvTarifasAM.ReadOnly = true;
            this.dgvTarifasAM.Size = new System.Drawing.Size(408, 171);
            this.dgvTarifasAM.TabIndex = 11;
            this.dgvTarifasAM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarifasAM_CellContentClick);
            // 
            // id_tarifa_am
            // 
            this.id_tarifa_am.DataPropertyName = "id_tarifa";
            this.id_tarifa_am.HeaderText = "ID";
            this.id_tarifa_am.Name = "id_tarifa_am";
            this.id_tarifa_am.ReadOnly = true;
            this.id_tarifa_am.Width = 45;
            // 
            // concepto_tarifa_am
            // 
            this.concepto_tarifa_am.DataPropertyName = "concepto";
            this.concepto_tarifa_am.HeaderText = "Concepto";
            this.concepto_tarifa_am.Name = "concepto_tarifa_am";
            this.concepto_tarifa_am.ReadOnly = true;
            this.concepto_tarifa_am.Width = 220;
            // 
            // monto_tarifa_am
            // 
            this.monto_tarifa_am.DataPropertyName = "monto";
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = "0";
            this.monto_tarifa_am.DefaultCellStyle = dataGridViewCellStyle7;
            this.monto_tarifa_am.HeaderText = "Monto";
            this.monto_tarifa_am.Name = "monto_tarifa_am";
            this.monto_tarifa_am.ReadOnly = true;
            // 
            // btnActualizarTarifaAM
            // 
            this.btnActualizarTarifaAM.Location = new System.Drawing.Point(153, 159);
            this.btnActualizarTarifaAM.Name = "btnActualizarTarifaAM";
            this.btnActualizarTarifaAM.Size = new System.Drawing.Size(123, 35);
            this.btnActualizarTarifaAM.TabIndex = 10;
            this.btnActualizarTarifaAM.Text = "Actualizar datos";
            this.btnActualizarTarifaAM.UseVisualStyleBackColor = true;
            this.btnActualizarTarifaAM.Click += new System.EventHandler(this.btnActualizarTarifaAM_Click);
            // 
            // txtMontoAM
            // 
            this.txtMontoAM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoAM.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.txtMontoAM.Location = new System.Drawing.Point(120, 104);
            this.txtMontoAM.Name = "txtMontoAM";
            this.txtMontoAM.Size = new System.Drawing.Size(92, 24);
            this.txtMontoAM.TabIndex = 8;
            this.txtMontoAM.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtMontoAM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoAM_KeyPress);
            // 
            // txtConceptoAM
            // 
            this.txtConceptoAM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConceptoAM.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.txtConceptoAM.Location = new System.Drawing.Point(120, 65);
            this.txtConceptoAM.Name = "txtConceptoAM";
            this.txtConceptoAM.Size = new System.Drawing.Size(312, 24);
            this.txtConceptoAM.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.label6.Location = new System.Drawing.Point(41, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Monto: ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F);
            this.label5.Location = new System.Drawing.Point(25, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Concepto: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F);
            this.label4.Location = new System.Drawing.Point(163, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nueva tarifa";
            // 
            // btnGuardarTarifaAM
            // 
            this.btnGuardarTarifaAM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarTarifaAM.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGuardarTarifaAM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnGuardarTarifaAM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnGuardarTarifaAM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTarifaAM.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnGuardarTarifaAM.Location = new System.Drawing.Point(26, 160);
            this.btnGuardarTarifaAM.Name = "btnGuardarTarifaAM";
            this.btnGuardarTarifaAM.Padding = new System.Windows.Forms.Padding(3);
            this.btnGuardarTarifaAM.Size = new System.Drawing.Size(114, 35);
            this.btnGuardarTarifaAM.TabIndex = 3;
            this.btnGuardarTarifaAM.Text = "Guardar datos";
            this.btnGuardarTarifaAM.UseVisualStyleBackColor = true;
            this.btnGuardarTarifaAM.Click += new System.EventHandler(this.btnGuardarTarifaAM_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(290, 160);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(3);
            this.button4.Size = new System.Drawing.Size(141, 35);
            this.button4.TabIndex = 2;
            this.button4.Text = "Cerrar el formulario";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ttMonto
            // 
            this.ttMonto.Tag = "";
            this.ttMonto.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.ttMonto.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // frmTarifas
            // 
            this.AccessibleName = "";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 430);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTarifas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifas de Pago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTarifas_FormClosing);
            this.Load += new System.EventHandler(this.frmTarifas_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpCasaClub.ResumeLayout(false);
            this.tpCasaClub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasCC)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasAM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCasaClub;
        private System.Windows.Forms.Button btnGuardarTarifaCC;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGuardarTarifaAM;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoCC;
        private System.Windows.Forms.TextBox txtConceptoCC;
        private System.Windows.Forms.TextBox txtMontoAM;
        private System.Windows.Forms.TextBox txtConceptoAM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTarifasCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto_tarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_tarifa;
        private System.Windows.Forms.Button btnActualizarTarifaCC;
        private System.Windows.Forms.Button btnActualizarTarifaAM;
        private System.Windows.Forms.DataGridView dgvTarifasAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tarifa_am;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto_tarifa_am;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_tarifa_am;
        private System.Windows.Forms.ToolTip ttMonto;
    }
}