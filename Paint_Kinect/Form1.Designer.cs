namespace Paint_Kinect
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PB_Lienzo = new System.Windows.Forms.PictureBox();
            this.B_conect = new System.Windows.Forms.Button();
            this.Status_kinect = new System.Windows.Forms.Label();
            this.PB_Lienzo2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo2)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Lienzo
            // 
            this.PB_Lienzo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Lienzo.BackColor = System.Drawing.Color.White;
            this.PB_Lienzo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_Lienzo.Cursor = System.Windows.Forms.Cursors.Default;
            this.PB_Lienzo.Location = new System.Drawing.Point(12, 56);
            this.PB_Lienzo.Name = "PB_Lienzo";
            this.PB_Lienzo.Size = new System.Drawing.Size(782, 415);
            this.PB_Lienzo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Lienzo.TabIndex = 0;
            this.PB_Lienzo.TabStop = false;
            this.PB_Lienzo.SizeChanged += new System.EventHandler(this.PB_Lienzo_SizeChanged);
            // 
            // B_conect
            // 
            this.B_conect.Location = new System.Drawing.Point(13, 13);
            this.B_conect.Name = "B_conect";
            this.B_conect.Size = new System.Drawing.Size(75, 23);
            this.B_conect.TabIndex = 1;
            this.B_conect.Text = "Conectar";
            this.B_conect.UseVisualStyleBackColor = true;
            this.B_conect.Click += new System.EventHandler(this.B_conect_Click);
            // 
            // Status_kinect
            // 
            this.Status_kinect.AutoSize = true;
            this.Status_kinect.Location = new System.Drawing.Point(13, 478);
            this.Status_kinect.Name = "Status_kinect";
            this.Status_kinect.Size = new System.Drawing.Size(0, 13);
            this.Status_kinect.TabIndex = 2;
            // 
            // PB_Lienzo2
            // 
            this.PB_Lienzo2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Lienzo2.BackColor = System.Drawing.Color.Transparent;
            this.PB_Lienzo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_Lienzo2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_Lienzo2.ErrorImage = null;
            this.PB_Lienzo2.InitialImage = null;
            this.PB_Lienzo2.Location = new System.Drawing.Point(12, 56);
            this.PB_Lienzo2.Name = "PB_Lienzo2";
            this.PB_Lienzo2.Size = new System.Drawing.Size(782, 415);
            this.PB_Lienzo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Lienzo2.TabIndex = 3;
            this.PB_Lienzo2.TabStop = false;
            this.PB_Lienzo2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Lienzo2_MouseDown);
            this.PB_Lienzo2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Lienzo2_MouseMove);
            this.PB_Lienzo2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_Lienzo2_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 497);
            this.Controls.Add(this.PB_Lienzo2);
            this.Controls.Add(this.Status_kinect);
            this.Controls.Add(this.B_conect);
            this.Controls.Add(this.PB_Lienzo);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kinect Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Lienzo;
        private System.Windows.Forms.Button B_conect;
        private System.Windows.Forms.Label Status_kinect;
        private System.Windows.Forms.PictureBox PB_Lienzo2;
    }
}

