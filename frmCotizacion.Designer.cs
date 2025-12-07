namespace UrbanWear
{
    partial class frmCotizacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblUltimaActualizacion = new System.Windows.Forms.Label();
            this.lblDolarBlue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.lblUltimaActualizacion);
            this.groupBox1.Controls.Add(this.lblDolarBlue);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 405);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::UrbanWear.Properties.Resources._22_abr_2025__08_14_44_p_m2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Location = new System.Drawing.Point(490, 288);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(251, 39);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUltimaActualizacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaActualizacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(363, 216);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(378, 35);
            this.lblUltimaActualizacion.TabIndex = 1;
            this.lblUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDolarBlue
            // 
            this.lblDolarBlue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDolarBlue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDolarBlue.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDolarBlue.Location = new System.Drawing.Point(12, 21);
            this.lblDolarBlue.Name = "lblDolarBlue";
            this.lblDolarBlue.Size = new System.Drawing.Size(729, 178);
            this.lblDolarBlue.TabIndex = 0;
            this.lblDolarBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(781, 428);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Leelawadee", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCotizacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cotizacion del día";
            this.Load += new System.EventHandler(this.frmCotizacion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDolarBlue;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblUltimaActualizacion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}