﻿namespace Paint_Kinect
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Colores = new System.Windows.Forms.GroupBox();
            this.Blue = new System.Windows.Forms.Button();
            this.Orange = new System.Windows.Forms.Button();
            this.White = new System.Windows.Forms.Button();
            this.Gray = new System.Windows.Forms.Button();
            this.Pink = new System.Windows.Forms.Button();
            this.Purple = new System.Windows.Forms.Button();
            this.B_Selec = new System.Windows.Forms.Button();
            this.Yellow = new System.Windows.Forms.Button();
            this.Green = new System.Windows.Forms.Button();
            this.Black = new System.Windows.Forms.Button();
            this.Red = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_TAM = new System.Windows.Forms.ComboBox();
            this.Borrador = new System.Windows.Forms.Button();
            this.L_estado = new System.Windows.Forms.Label();
            this.B_camara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo2)).BeginInit();
            this.Colores.SuspendLayout();
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
            this.PB_Lienzo.Size = new System.Drawing.Size(792, 415);
            this.PB_Lienzo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Lienzo.TabIndex = 0;
            this.PB_Lienzo.TabStop = false;
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
            this.PB_Lienzo2.Size = new System.Drawing.Size(792, 415);
            this.PB_Lienzo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Lienzo2.TabIndex = 3;
            this.PB_Lienzo2.TabStop = false;
            this.PB_Lienzo2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Lienzo2_MouseDown);
            this.PB_Lienzo2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Lienzo2_MouseMove);
            this.PB_Lienzo2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_Lienzo2_MouseUp);
            this.PB_Lienzo2.Resize += new System.EventHandler(this.PB_Lienzo2_Resize);
            // 
            // Colores
            // 
            this.Colores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Colores.BackColor = System.Drawing.Color.Transparent;
            this.Colores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Colores.Controls.Add(this.Blue);
            this.Colores.Controls.Add(this.Orange);
            this.Colores.Controls.Add(this.White);
            this.Colores.Controls.Add(this.Gray);
            this.Colores.Controls.Add(this.Pink);
            this.Colores.Controls.Add(this.Purple);
            this.Colores.Controls.Add(this.B_Selec);
            this.Colores.Controls.Add(this.Yellow);
            this.Colores.Controls.Add(this.Green);
            this.Colores.Controls.Add(this.Black);
            this.Colores.Controls.Add(this.Red);
            this.Colores.Location = new System.Drawing.Point(828, 56);
            this.Colores.Name = "Colores";
            this.Colores.Size = new System.Drawing.Size(82, 244);
            this.Colores.TabIndex = 4;
            this.Colores.TabStop = false;
            this.Colores.Text = "Colores";
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.Color.RoyalBlue;
            this.Blue.Location = new System.Drawing.Point(8, 205);
            this.Blue.Margin = new System.Windows.Forms.Padding(1);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(30, 30);
            this.Blue.TabIndex = 19;
            this.Blue.UseVisualStyleBackColor = false;
            this.Blue.Click += new System.EventHandler(this.RoyalBlue_Click);
            // 
            // Orange
            // 
            this.Orange.BackColor = System.Drawing.Color.Orange;
            this.Orange.Location = new System.Drawing.Point(45, 109);
            this.Orange.Margin = new System.Windows.Forms.Padding(1);
            this.Orange.Name = "Orange";
            this.Orange.Size = new System.Drawing.Size(30, 30);
            this.Orange.TabIndex = 15;
            this.Orange.UseVisualStyleBackColor = false;
            this.Orange.Click += new System.EventHandler(this.OrangeRed_Click);
            // 
            // White
            // 
            this.White.BackColor = System.Drawing.Color.White;
            this.White.Location = new System.Drawing.Point(8, 109);
            this.White.Margin = new System.Windows.Forms.Padding(1);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(30, 30);
            this.White.TabIndex = 11;
            this.White.UseVisualStyleBackColor = false;
            this.White.Click += new System.EventHandler(this.blanco_Click);
            // 
            // Gray
            // 
            this.Gray.BackColor = System.Drawing.Color.Gray;
            this.Gray.Location = new System.Drawing.Point(45, 77);
            this.Gray.Margin = new System.Windows.Forms.Padding(1);
            this.Gray.Name = "Gray";
            this.Gray.Size = new System.Drawing.Size(30, 30);
            this.Gray.TabIndex = 12;
            this.Gray.UseVisualStyleBackColor = false;
            this.Gray.Click += new System.EventHandler(this.Gray_Click);
            // 
            // Pink
            // 
            this.Pink.BackColor = System.Drawing.Color.Pink;
            this.Pink.Location = new System.Drawing.Point(8, 173);
            this.Pink.Margin = new System.Windows.Forms.Padding(1);
            this.Pink.Name = "Pink";
            this.Pink.Size = new System.Drawing.Size(30, 30);
            this.Pink.TabIndex = 14;
            this.Pink.UseVisualStyleBackColor = false;
            this.Pink.Click += new System.EventHandler(this.Pink_Click);
            // 
            // Purple
            // 
            this.Purple.BackColor = System.Drawing.Color.Purple;
            this.Purple.Location = new System.Drawing.Point(45, 205);
            this.Purple.Margin = new System.Windows.Forms.Padding(1);
            this.Purple.Name = "Purple";
            this.Purple.Size = new System.Drawing.Size(30, 30);
            this.Purple.TabIndex = 10;
            this.Purple.UseVisualStyleBackColor = false;
            this.Purple.Click += new System.EventHandler(this.Purple_Click);
            // 
            // B_Selec
            // 
            this.B_Selec.BackColor = System.Drawing.Color.Black;
            this.B_Selec.Enabled = false;
            this.B_Selec.Location = new System.Drawing.Point(6, 20);
            this.B_Selec.Name = "B_Selec";
            this.B_Selec.Size = new System.Drawing.Size(70, 53);
            this.B_Selec.TabIndex = 0;
            this.B_Selec.UseVisualStyleBackColor = false;
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.Color.Yellow;
            this.Yellow.Location = new System.Drawing.Point(45, 141);
            this.Yellow.Margin = new System.Windows.Forms.Padding(1);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(30, 30);
            this.Yellow.TabIndex = 5;
            this.Yellow.UseVisualStyleBackColor = false;
            this.Yellow.Click += new System.EventHandler(this.Yellow_Click);
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.Color.Green;
            this.Green.Location = new System.Drawing.Point(45, 173);
            this.Green.Margin = new System.Windows.Forms.Padding(1);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(30, 30);
            this.Green.TabIndex = 7;
            this.Green.UseVisualStyleBackColor = false;
            this.Green.Click += new System.EventHandler(this.Green_Click);
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.Color.Black;
            this.Black.Location = new System.Drawing.Point(8, 77);
            this.Black.Margin = new System.Windows.Forms.Padding(1);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(30, 30);
            this.Black.TabIndex = 1;
            this.Black.UseVisualStyleBackColor = false;
            this.Black.Click += new System.EventHandler(this.negro_Click);
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.Red;
            this.Red.Location = new System.Drawing.Point(8, 141);
            this.Red.Margin = new System.Windows.Forms.Padding(1);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(30, 30);
            this.Red.TabIndex = 4;
            this.Red.UseVisualStyleBackColor = false;
            this.Red.Click += new System.EventHandler(this.Red_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(836, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tamaño";
            // 
            // CB_TAM
            // 
            this.CB_TAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_TAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TAM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_TAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_TAM.FormattingEnabled = true;
            this.CB_TAM.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "6",
            "8",
            "10",
            "14",
            "18",
            "24",
            "32",
            "60",
            "80",
            "100"});
            this.CB_TAM.Location = new System.Drawing.Point(834, 450);
            this.CB_TAM.MaxDropDownItems = 100;
            this.CB_TAM.Name = "CB_TAM";
            this.CB_TAM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_TAM.Size = new System.Drawing.Size(65, 26);
            this.CB_TAM.TabIndex = 18;
            this.CB_TAM.SelectedIndexChanged += new System.EventHandler(this.CB_TAM_SelectedIndexChanged);
            // 
            // Borrador
            // 
            this.Borrador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Borrador.BackColor = System.Drawing.Color.Transparent;
            this.Borrador.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Borrador.BackgroundImage")));
            this.Borrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Borrador.Location = new System.Drawing.Point(828, 347);
            this.Borrador.Margin = new System.Windows.Forms.Padding(1);
            this.Borrador.Name = "Borrador";
            this.Borrador.Size = new System.Drawing.Size(82, 47);
            this.Borrador.TabIndex = 14;
            this.Borrador.UseVisualStyleBackColor = false;
            this.Borrador.Click += new System.EventHandler(this.Borrador_Click);
            // 
            // L_estado
            // 
            this.L_estado.AutoSize = true;
            this.L_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_estado.ForeColor = System.Drawing.Color.Red;
            this.L_estado.Location = new System.Drawing.Point(94, 16);
            this.L_estado.Name = "L_estado";
            this.L_estado.Size = new System.Drawing.Size(173, 20);
            this.L_estado.TabIndex = 19;
            this.L_estado.Text = "Kinect no Detectada";
            // 
            // B_camara
            // 
            this.B_camara.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_camara.BackgroundImage")));
            this.B_camara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_camara.Location = new System.Drawing.Point(737, 2);
            this.B_camara.Name = "B_camara";
            this.B_camara.Size = new System.Drawing.Size(67, 51);
            this.B_camara.TabIndex = 20;
            this.B_camara.UseVisualStyleBackColor = true;
            this.B_camara.Click += new System.EventHandler(this.B_camara_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 497);
            this.Controls.Add(this.B_camara);
            this.Controls.Add(this.L_estado);
            this.Controls.Add(this.CB_TAM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Borrador);
            this.Controls.Add(this.Colores);
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
            this.Colores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Lienzo;
        private System.Windows.Forms.Button B_conect;
        private System.Windows.Forms.Label Status_kinect;
        private System.Windows.Forms.PictureBox PB_Lienzo2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox Colores;
        private System.Windows.Forms.Button Blue;
        private System.Windows.Forms.Button Orange;
        private System.Windows.Forms.Button White;
        private System.Windows.Forms.Button Gray;
        private System.Windows.Forms.Button Pink;
        private System.Windows.Forms.Button Purple;
        private System.Windows.Forms.Button B_Selec;
        private System.Windows.Forms.Button Yellow;
        private System.Windows.Forms.Button Green;
        private System.Windows.Forms.Button Black;
        private System.Windows.Forms.Button Red;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_TAM;
        private System.Windows.Forms.Button Borrador;
        private System.Windows.Forms.Label L_estado;
        private System.Windows.Forms.Button B_camara;
    }
}

