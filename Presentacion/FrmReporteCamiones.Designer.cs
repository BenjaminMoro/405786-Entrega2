namespace Camiones.Presentacion
{
    partial class FrmReporteCamiones
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sPCONSULTARCAMIONESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCamiones = new Camiones.Reportes.DSCamiones();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSCamionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_CONSULTAR_CAMIONESTableAdapter = new Camiones.Reportes.DSCamionesTableAdapters.SP_CONSULTAR_CAMIONESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARCAMIONESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCamiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCamionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sPCONSULTARCAMIONESBindingSource
            // 
            this.sPCONSULTARCAMIONESBindingSource.DataMember = "SP_CONSULTAR_CAMIONES";
            this.sPCONSULTARCAMIONESBindingSource.DataSource = this.dSCamiones;
            // 
            // dSCamiones
            // 
            this.dSCamiones.DataSetName = "DSCamiones";
            this.dSCamiones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPCONSULTARCAMIONESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Camiones.Reportes.RptProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(658, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSCamionesBindingSource
            // 
            this.dSCamionesBindingSource.DataSource = this.dSCamiones;
            this.dSCamionesBindingSource.Position = 0;
            // 
            // sP_CONSULTAR_CAMIONESTableAdapter
            // 
            this.sP_CONSULTAR_CAMIONESTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteCamiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteCamiones";
            this.Text = "FrmReportesCamiones";
            this.Load += new System.EventHandler(this.FrmReportesCamiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARCAMIONESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCamiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCamionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DSCamiones dSCamiones;
        private System.Windows.Forms.BindingSource dSCamionesBindingSource;
        private System.Windows.Forms.BindingSource sPCONSULTARCAMIONESBindingSource;
        private Reportes.DSCamionesTableAdapters.SP_CONSULTAR_CAMIONESTableAdapter sP_CONSULTAR_CAMIONESTableAdapter;
    }
}