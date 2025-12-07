namespace UrbanWear
{
    partial class frmEstadisticaVentas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timerParpadeo = new System.Windows.Forms.Timer(this.components);
            this.lblEstadoFiltro = new System.Windows.Forms.Label();
            this.btnBorrarFiltro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstadistica = new System.Windows.Forms.ComboBox();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // timerParpadeo
            // 
            this.timerParpadeo.Enabled = true;
            this.timerParpadeo.Interval = 500;
            this.timerParpadeo.Tick += new System.EventHandler(this.timerParpadeo_Tick);
            // 
            // lblEstadoFiltro
            // 
            this.lblEstadoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblEstadoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoFiltro.Location = new System.Drawing.Point(12, 324);
            this.lblEstadoFiltro.Name = "lblEstadoFiltro";
            this.lblEstadoFiltro.Size = new System.Drawing.Size(273, 53);
            this.lblEstadoFiltro.TabIndex = 19;
            this.lblEstadoFiltro.Text = "label4";
            this.lblEstadoFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBorrarFiltro
            // 
            this.btnBorrarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrarFiltro.Location = new System.Drawing.Point(113, 279);
            this.btnBorrarFiltro.Name = "btnBorrarFiltro";
            this.btnBorrarFiltro.Size = new System.Drawing.Size(180, 31);
            this.btnBorrarFiltro.TabIndex = 18;
            this.btnBorrarFiltro.Text = "Borrar filtro";
            this.btnBorrarFiltro.UseVisualStyleBackColor = true;
            this.btnBorrarFiltro.Click += new System.EventHandler(this.btnBorrarFiltro_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Desde:";
            // 
            // btnFiltro
            // 
            this.btnFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltro.Location = new System.Drawing.Point(113, 224);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(180, 31);
            this.btnFiltro.TabIndex = 15;
            this.btnFiltro.Text = "Aplicar filtro";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(113, 161);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(180, 27);
            this.dtpHasta.TabIndex = 14;
            this.dtpHasta.Value = new System.DateTime(2025, 6, 24, 0, 0, 0, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(113, 99);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(180, 27);
            this.dtpDesde.TabIndex = 13;
            this.dtpDesde.Value = new System.DateTime(2025, 6, 24, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Filtrar por:";
            // 
            // cmbEstadistica
            // 
            this.cmbEstadistica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadistica.FormattingEnabled = true;
            this.cmbEstadistica.Location = new System.Drawing.Point(113, 17);
            this.cmbEstadistica.Name = "cmbEstadistica";
            this.cmbEstadistica.Size = new System.Drawing.Size(180, 27);
            this.cmbEstadistica.TabIndex = 11;
            // 
            // chartVentas
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVentas.Legends.Add(legend2);
            this.chartVentas.Location = new System.Drawing.Point(328, 16);
            this.chartVentas.Name = "chartVentas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVentas.Series.Add(series2);
            this.chartVentas.Size = new System.Drawing.Size(764, 362);
            this.chartVentas.TabIndex = 10;
            this.chartVentas.Text = "chart1";
            // 
            // frmEstadisticaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1114, 395);
            this.Controls.Add(this.lblEstadoFiltro);
            this.Controls.Add(this.btnBorrarFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstadistica);
            this.Controls.Add(this.chartVentas);
            this.Font = new System.Drawing.Font("Leelawadee", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEstadisticaVentas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadistica de ventas";
            this.Load += new System.EventHandler(this.frmEstadisticaVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerParpadeo;
        private System.Windows.Forms.Label lblEstadoFiltro;
        private System.Windows.Forms.Button btnBorrarFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEstadistica;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
    }
}