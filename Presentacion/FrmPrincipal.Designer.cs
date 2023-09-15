namespace Camiones.Presentacion
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoCamionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subirCargaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.transporteToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // transporteToolStripMenuItem
            // 
            this.transporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCamionToolStripMenuItem,
            this.subirCargaToolStripMenuItem,
            this.consToolStripMenuItem});
            this.transporteToolStripMenuItem.Name = "transporteToolStripMenuItem";
            this.transporteToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.transporteToolStripMenuItem.Text = "Transporte";
            // 
            // nuevoCamionToolStripMenuItem
            // 
            this.nuevoCamionToolStripMenuItem.Name = "nuevoCamionToolStripMenuItem";
            this.nuevoCamionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.nuevoCamionToolStripMenuItem.Text = "Camiones";
            this.nuevoCamionToolStripMenuItem.Click += new System.EventHandler(this.nuevoCamionToolStripMenuItem_Click);
            // 
            // subirCargaToolStripMenuItem
            // 
            this.subirCargaToolStripMenuItem.Name = "subirCargaToolStripMenuItem";
            this.subirCargaToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.subirCargaToolStripMenuItem.Text = "Cargas";
            this.subirCargaToolStripMenuItem.Click += new System.EventHandler(this.subirCargaToolStripMenuItem_Click);
            // 
            // consToolStripMenuItem
            // 
            this.consToolStripMenuItem.Name = "consToolStripMenuItem";
            this.consToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.consToolStripMenuItem.Text = "Consultar";
            this.consToolStripMenuItem.Click += new System.EventHandler(this.consToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.camionesToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // camionesToolStripMenuItem
            // 
            this.camionesToolStripMenuItem.Name = "camionesToolStripMenuItem";
            this.camionesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.camionesToolStripMenuItem.Text = "Camiones";
            this.camionesToolStripMenuItem.Click += new System.EventHandler(this.camionesToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoCamionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subirCargaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camionesToolStripMenuItem;
    }
}