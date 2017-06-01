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
            this.PB_Lienzo2 = new System.Windows.Forms.PictureBox();
            this.Colores = new System.Windows.Forms.GroupBox();
            this.Blue = new System.Windows.Forms.Button();
            this.Orange = new System.Windows.Forms.Button();
            this.White = new System.Windows.Forms.Button();
            this.Gray = new System.Windows.Forms.Button();
            this.Pink = new System.Windows.Forms.Button();
            this.Purple = new System.Windows.Forms.Button();
            this.Yellow = new System.Windows.Forms.Button();
            this.Green = new System.Windows.Forms.Button();
            this.Black = new System.Windows.Forms.Button();
            this.Red = new System.Windows.Forms.Button();
            this.B_Selec2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_TAM = new System.Windows.Forms.ComboBox();
            this.Borrador = new System.Windows.Forms.Button();
            this.L_estado = new System.Windows.Forms.Label();
            this.B_camara = new System.Windows.Forms.Button();
            this.B_Selec1 = new System.Windows.Forms.Button();
            this.Ayuda = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Lienzo2)).BeginInit();
            this.Colores.SuspendLayout();
            this.Ayuda.SuspendLayout();
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
            this.PB_Lienzo.Location = new System.Drawing.Point(16, 63);
            this.PB_Lienzo.Name = "PB_Lienzo";
            this.PB_Lienzo.Size = new System.Drawing.Size(809, 408);
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
            this.PB_Lienzo2.Location = new System.Drawing.Point(16, 63);
            this.PB_Lienzo2.Name = "PB_Lienzo2";
            this.PB_Lienzo2.Size = new System.Drawing.Size(809, 408);
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
            this.Colores.Controls.Add(this.Yellow);
            this.Colores.Controls.Add(this.Green);
            this.Colores.Controls.Add(this.Black);
            this.Colores.Controls.Add(this.Red);
            this.Colores.Location = new System.Drawing.Point(395, 4);
            this.Colores.Name = "Colores";
            this.Colores.Size = new System.Drawing.Size(341, 53);
            this.Colores.TabIndex = 4;
            this.Colores.TabStop = false;
            this.Colores.Text = "Colores";
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.Color.RoyalBlue;
            this.Blue.Location = new System.Drawing.Point(136, 17);
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
            this.Orange.Location = new System.Drawing.Point(168, 17);
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
            this.White.Location = new System.Drawing.Point(72, 17);
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
            this.Gray.Location = new System.Drawing.Point(40, 17);
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
            this.Pink.Location = new System.Drawing.Point(104, 17);
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
            this.Purple.Location = new System.Drawing.Point(264, 17);
            this.Purple.Margin = new System.Windows.Forms.Padding(1);
            this.Purple.Name = "Purple";
            this.Purple.Size = new System.Drawing.Size(30, 30);
            this.Purple.TabIndex = 10;
            this.Purple.UseVisualStyleBackColor = false;
            this.Purple.Click += new System.EventHandler(this.Purple_Click);
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.Color.Yellow;
            this.Yellow.Location = new System.Drawing.Point(200, 17);
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
            this.Green.Location = new System.Drawing.Point(296, 17);
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
            this.Black.Location = new System.Drawing.Point(8, 17);
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
            this.Red.Location = new System.Drawing.Point(232, 17);
            this.Red.Margin = new System.Windows.Forms.Padding(1);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(30, 30);
            this.Red.TabIndex = 4;
            this.Red.UseVisualStyleBackColor = false;
            this.Red.Click += new System.EventHandler(this.Red_Click);
            // 
            // B_Selec2
            // 
            this.B_Selec2.BackColor = System.Drawing.Color.Black;
            this.B_Selec2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Selec2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Selec2.ForeColor = System.Drawing.Color.Aquamarine;
            this.B_Selec2.Location = new System.Drawing.Point(755, 21);
            this.B_Selec2.Name = "B_Selec2";
            this.B_Selec2.Size = new System.Drawing.Size(70, 33);
            this.B_Selec2.TabIndex = 0;
            this.B_Selec2.UseVisualStyleBackColor = false;
            this.B_Selec2.Click += new System.EventHandler(this.B_Selec2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(844, 274);
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
            this.CB_TAM.Location = new System.Drawing.Point(842, 301);
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
            this.Borrador.Location = new System.Drawing.Point(839, 176);
            this.Borrador.Margin = new System.Windows.Forms.Padding(1);
            this.Borrador.Name = "Borrador";
            this.Borrador.Size = new System.Drawing.Size(64, 47);
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
            this.B_camara.Location = new System.Drawing.Point(837, 100);
            this.B_camara.Name = "B_camara";
            this.B_camara.Size = new System.Drawing.Size(67, 51);
            this.B_camara.TabIndex = 20;
            this.B_camara.UseVisualStyleBackColor = true;
            this.B_camara.Click += new System.EventHandler(this.B_camara_Click);
            // 
            // B_Selec1
            // 
            this.B_Selec1.BackColor = System.Drawing.Color.Black;
            this.B_Selec1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.B_Selec1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Selec1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Selec1.ForeColor = System.Drawing.Color.Aquamarine;
            this.B_Selec1.Location = new System.Drawing.Point(302, 21);
            this.B_Selec1.Name = "B_Selec1";
            this.B_Selec1.Size = new System.Drawing.Size(74, 33);
            this.B_Selec1.TabIndex = 21;
            this.B_Selec1.UseVisualStyleBackColor = false;
            this.B_Selec1.Click += new System.EventHandler(this.B_Selec1_Click);
            // 
            // Ayuda
            // 
            this.Ayuda.BackColor = System.Drawing.Color.White;
            this.Ayuda.Controls.Add(this.label12);
            this.Ayuda.Controls.Add(this.label11);
            this.Ayuda.Controls.Add(this.label8);
            this.Ayuda.Controls.Add(this.label7);
            this.Ayuda.Controls.Add(this.label6);
            this.Ayuda.Controls.Add(this.label5);
            this.Ayuda.Controls.Add(this.label4);
            this.Ayuda.Controls.Add(this.label3);
            this.Ayuda.Controls.Add(this.label2);
            this.Ayuda.Location = new System.Drawing.Point(223, 100);
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(357, 294);
            this.Ayuda.TabIndex = 22;
            this.Ayuda.TabStop = false;
            this.Ayuda.Text = "Ayuda";
            this.Ayuda.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(23, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Cerrar Ayuda : Cerrar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(243, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 48);
            this.label7.TabIndex = 5;
            this.label7.Text = "Pequeño\r\nMediano\r\nGrande";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(243, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tamaño";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(251, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Foto\r\nBorrar\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(241, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Opciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 160);
            this.label3.TabIndex = 1;
            this.label3.Text = "Negro\r\nGris\r\nBlanco\r\nRosa\r\nAzul\r\nNaranja\r\nAmarillo\r\nRojo\r\nMorado\r\nVerde";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(28, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccionar Colores";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(307, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Circulo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(758, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Cuadrado";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(237, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Jugadores";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(239, 222);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(76, 32);
            this.label12.TabIndex = 8;
            this.label12.Text = "Circulo\r\nCuadrado";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 497);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Ayuda);
            this.Controls.Add(this.B_Selec1);
            this.Controls.Add(this.B_camara);
            this.Controls.Add(this.L_estado);
            this.Controls.Add(this.CB_TAM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Borrador);
            this.Controls.Add(this.Colores);
            this.Controls.Add(this.B_Selec2);
            this.Controls.Add(this.PB_Lienzo2);
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
            this.Ayuda.ResumeLayout(false);
            this.Ayuda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Lienzo;
        private System.Windows.Forms.Button B_conect;
        private System.Windows.Forms.PictureBox PB_Lienzo2;
        private System.Windows.Forms.GroupBox Colores;
        private System.Windows.Forms.Button Blue;
        private System.Windows.Forms.Button Orange;
        private System.Windows.Forms.Button White;
        private System.Windows.Forms.Button Gray;
        private System.Windows.Forms.Button Pink;
        private System.Windows.Forms.Button Purple;
        private System.Windows.Forms.Button B_Selec2;
        private System.Windows.Forms.Button Yellow;
        private System.Windows.Forms.Button Green;
        private System.Windows.Forms.Button Black;
        private System.Windows.Forms.Button Red;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_TAM;
        private System.Windows.Forms.Button Borrador;
        private System.Windows.Forms.Label L_estado;
        private System.Windows.Forms.Button B_camara;
        private System.Windows.Forms.Button B_Selec1;
        private System.Windows.Forms.GroupBox Ayuda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}

