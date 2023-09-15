namespace Camiones.Presentacion
{
    partial class FrmCargas
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstCamiones = new System.Windows.Forms.ListBox();
            this.dgvCargas = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBajar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSubir = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOcupado = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrar Cargas";
            // 
            // lstCamiones
            // 
            this.lstCamiones.FormattingEnabled = true;
            this.lstCamiones.Location = new System.Drawing.Point(12, 56);
            this.lstCamiones.Name = "lstCamiones";
            this.lstCamiones.Size = new System.Drawing.Size(199, 459);
            this.lstCamiones.TabIndex = 1;
            this.lstCamiones.SelectedIndexChanged += new System.EventHandler(this.lstCamiones_SelectedIndexChanged);
            // 
            // dgvCargas
            // 
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.AllowUserToDeleteRows = false;
            this.dgvCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColPeso,
            this.ColTipo,
            this.ColBajar});
            this.dgvCargas.Location = new System.Drawing.Point(239, 84);
            this.dgvCargas.Name = "dgvCargas";
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.Size = new System.Drawing.Size(444, 353);
            this.dgvCargas.TabIndex = 2;
            this.dgvCargas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellContentClick);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            // 
            // ColPeso
            // 
            this.ColPeso.HeaderText = "Peso";
            this.ColPeso.Name = "ColPeso";
            this.ColPeso.ReadOnly = true;
            // 
            // ColTipo
            // 
            this.ColTipo.HeaderText = "Tipo";
            this.ColTipo.Name = "ColTipo";
            this.ColTipo.ReadOnly = true;
            // 
            // ColBajar
            // 
            this.ColBajar.HeaderText = "Bajar";
            this.ColBajar.Name = "ColBajar";
            this.ColBajar.ReadOnly = true;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(554, 57);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(129, 23);
            this.btnSubir.TabIndex = 3;
            this.btnSubir.Text = "Subir";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(427, 58);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 21);
            this.cboTipo.TabIndex = 4;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(239, 58);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(182, 20);
            this.txtPeso.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(402, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Peso Ocupado del Camion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(487, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Peso Maximo:";
            // 
            // txtOcupado
            // 
            this.txtOcupado.Enabled = false;
            this.txtOcupado.Location = new System.Drawing.Point(588, 452);
            this.txtOcupado.Name = "txtOcupado";
            this.txtOcupado.Size = new System.Drawing.Size(95, 20);
            this.txtOcupado.TabIndex = 8;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(588, 486);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(95, 20);
            this.txtTotal.TabIndex = 9;
            // 
            // FrmCargas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 523);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtOcupado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.dgvCargas);
            this.Controls.Add(this.lstCamiones);
            this.Controls.Add(this.label1);
            this.Name = "FrmCargas";
            this.Text = "FrmCargas";
            this.Load += new System.EventHandler(this.FrmCargas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstCamiones;
        private System.Windows.Forms.DataGridView dgvCargas;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOcupado;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipo;
        private System.Windows.Forms.DataGridViewButtonColumn ColBajar;
    }
}