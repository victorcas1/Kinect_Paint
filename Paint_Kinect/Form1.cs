using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using Microsoft.Speech;
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
using System.Windows.Documents;


namespace Paint_Kinect
{
    public partial class Form1 : Form
    {
        private KinectSensor sensor;            //sensor kinect
        private Boolean click = false;          //indica si se esta presionando el boton del raton (se esta dibujando con el raton)
        private double tolerancia = 0.35;       //Separación que debe haber entre la mano y en centro de los hombros para considerar que se esta dibujando
        Graphics g;                             //herramienta para dibujar
        
        //Coordenadas del ultimo punto de dibujo detectado
        private int[] antx = new int[] { 0, 0, 0, 0, 0, 0, 0}; //maximo 6 esqueletos y un ratón
        private int[] anty = new int[] { 0, 0, 0, 0, 0, 0, 0}; //maximo 6 esqueletos y un ratón
        //

        private SpeechRecognitionEngine speechEngine; //variable relacionada con el reconocimiento de voz
        
        // variable sonido: almacena el sonido de la camara de fotos
        System.Media.SoundPlayer sonido = new System.Media.SoundPlayer(Application.StartupPath + "/756.wav");

        Color color1 = Color.Black;     //Color seleccionado por el jugador 1
        Color color2 = Color.Black;     //Color seleccionado por el jugador 2
        int tam1 = 10;                  //Tamaño del pincel seleccionado por el jugador 1
        int tam2 = 10;                  //Tamaño del pincel seleccionado por el jugador 2

        private int jugador_sel = 1;    //Jugador activo (es que que se modificará con los comandos de voz)
        Skeleton[] esqueletos;          //almacena los esquelos detectados por la Kinect (maximo 6)
        int[] esq = { -1, -1 };         //alamacena la posicion que ocupan los esqueletos (para identificar cual es el jugador 1 o 2)
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //Interfaz cargando
        {
            PB_Lienzo2.Parent = PB_Lienzo;                  //Lienzo 2 debe ser hijo de Lienzo para que pueda aplicarse transparencia sobre este último
            PB_Lienzo2.Location = new Point(0, 0);          //Se coloca el lienzo 2 en la posicion (0,0) sobre el Lienzo 1, quedando uno sobre otro (esto se debe a que se ha hecho uno hijo del otro)
            g = PB_Lienzo2.CreateGraphics();                //Se asigna el lienzo2 como fondo para la herramienta de dibujo
            PB_Lienzo2.Image = new Bitmap(640, 480);        //Se debe crear una imagen en el lienzo para poder mantener cada objeto dibujado
            CB_TAM.SelectedIndex = 5;                       //Se selecciona un valor de tamaño por defecto de 10
            actualizar_jugador(1);                          //Configura la interfaz para adaptarla al jugador 1
            reconect();                                     //Inicializa el sensor Kinect
        }
        private void actualizar_jugador(int jugador) {      //Actualiza la interfaz para adaptar los controles al jugador seleccionado
            if (jugador == 1)
            {
                // Se crea un borde sobre el boton 1 de color Azul claro (para diferenciarlo de los demas colores posibles) 
                // y se elimina el borde del boton 2
                B_Selec1.FlatAppearance.BorderSize = 5;
                B_Selec1.FlatAppearance.BorderColor = Color.LightGreen;
                B_Selec2.FlatAppearance.BorderSize = 0;
                B_Selec2.FlatAppearance.BorderColor = Color.White;
                // Se selecciona el valor de tamaño que este usando el usuario dentro del 
                // combobox (para poder modificarlo con el ratón)
                CB_TAM.Text = tam1.ToString();
                jugador_sel = 1;                            //Se indica que el jugador 1 esta seleccionado
            }else if (jugador == 2) {
                // Se crea un borde sobre el boton 2 de color Azul claro (para diferenciarlo de los demas colores posibles) 
                // y se elimina el borde del boton 1
                B_Selec1.FlatAppearance.BorderSize = 0;
                B_Selec1.FlatAppearance.BorderColor = Color.White;
                B_Selec2.FlatAppearance.BorderSize = 5;
                B_Selec2.FlatAppearance.BorderColor = Color.LightGreen;
                // Se selecciona el valor de tamaño que este usando el usuario dentro del 
                // combobox (para poder modificarlo con el ratón)
                CB_TAM.Text = tam2.ToString();
                jugador_sel = 2;                            //Se indica que el jugador 1 esta seleccionado
            }
        }
        private void B_conect_Click(object sender, EventArgs e) //Boton de Conectar pulsado
        {
            reconect();     //Intenta iniciar el sensor Kinect
        }
        private void reconect()                                 //Intenta iniciar el sensor Kinect
        {
            if (KinectSensor.KinectSensors.Count > 0)           //Si hay algun sensor kinect detectado lo asigna a ""
            {
                sensor = KinectSensor.KinectSensors[0];
            }
            else{                                               //Si no hay sensor detectado sale de la funcion
                return;
            }

            try
            {
                //Intenta iniciar un flujo de video de resolucion 640x480 a 30fps
                sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                sensor.ColorFrameReady += Sensor_ColorFrameReady;
                sensor.SkeletonStream.Enable();                 //Habilita la deteccion de esqueletos en la Kinect
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;
                this.sensor.Start();                            //Inicia el envio de datos
            }
            catch (System.IO.IOException)                       //Si hay un error sale de la función
            {
                this.sensor = null;
                return;
            }
            RecognizerInfo ri = GetKinectRecognizer();          //Inicializa el reconocimiento de voz y configura el idioma Español

            if (null != ri)                                     
            {
                this.speechEngine = new SpeechRecognitionEngine(ri.Id);

                //Si se ha configurado correctamente se añaden todos los comandos de la Interfaz

                var directions = new Choices();
                directions.Add(new SemanticResultValue("pequeño", "PEQUEÑO"));
                directions.Add(new SemanticResultValue("mediano", "MEDIANO"));
                directions.Add(new SemanticResultValue("grande", "GRANDE"));
                directions.Add(new SemanticResultValue("foto", "FOTO"));
                directions.Add(new SemanticResultValue("negro", "C_NEGRO"));
                directions.Add(new SemanticResultValue("gris", "C_GRIS"));
                directions.Add(new SemanticResultValue("blanco", "C_BLANCO"));
                directions.Add(new SemanticResultValue("rojo", "C_ROJO"));
                directions.Add(new SemanticResultValue("naranja", "C_NARANJA"));
                directions.Add(new SemanticResultValue("rosa", "C_ROSA"));
                directions.Add(new SemanticResultValue("amarillo", "C_AMARILLO"));
                directions.Add(new SemanticResultValue("azul", "C_AZUL"));
                directions.Add(new SemanticResultValue("verde", "C_VERDE"));
                directions.Add(new SemanticResultValue("morado", "C_MORADO"));
                directions.Add(new SemanticResultValue("borrar", "BORRAR"));
                directions.Add(new SemanticResultValue("ayuda", "AYUDA"));
                directions.Add(new SemanticResultValue("cerrar", "CERRAR"));
                directions.Add(new SemanticResultValue("circulo", "P1"));
                directions.Add(new SemanticResultValue("cuadrado", "P2"));

                var gb = new GrammarBuilder { Culture = ri.Culture };
                gb.Append(directions);

                var g = new Grammar(gb);
                speechEngine.LoadGrammar(g);

                speechEngine.SpeechRecognized += SpeechRecognized;

                //Se configura el flujo de audio de la kinect
                speechEngine.SetInputToAudioStream(sensor.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e) // Nueva transmision de datos de los esqueletos
        {
            esqueletos = new Skeleton[0];           //Elimina esqueletos anteriores
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    //Si se han detectado esqueletos se asiganan a la variable "esqueletos"
                    esqueletos = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(esqueletos);
                }
            }
            if (esqueletos.Length != 0)             //Si hay algun esqueleto detectado
            {
                Color color_elejido = Color.Black;  //Se crea una variable común (color_elegido) para disminuir codigo
                int grosor=10;                      //Se crea una variable común (grosor) para disminuir codigo
                busca();                            //busca cambios con respecto a la posicion de los esqueletos anteriormente
                for (int i = 0; i < esqueletos.Length; i++)
                {
                    //Se recorre cada esqueleto y se guardan las posiciones de la mano derecha mapeadas sobre la camara de video
                    int x = (int)(sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(esqueletos[i].Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).X);
                    int y = (int)(sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(esqueletos[i].Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).Y);
                    
                    if (x != 0 && y != 0)           //Si X e Y no son 0 (ha encontrado la posición de la mano)
                    {
                        if (esq[0] == i)            //Si el esqueleto que se esta procesando es el primero (posicion 0), es porque es el jugador 1
                        {
                            color_elejido = B_Selec1.BackColor; //Se asigna el color del jugador 1
                            grosor = tam1;          //Se asigna el grosor del pincel del jugador 1
                        }
                        else if (esq[1] == i)       //Si el esqueleto que se esta procesando es el Segundo (posicion 1), es porque es el jugador 2
                        {
                            color_elejido = B_Selec2.BackColor; //Se asigna el color del jugador 2
                            grosor = tam2;          //Se asigna el grosor del pincel del jugador 2
                        }
                        //Si se detecta una distancia en el eje Z, entre la mano y el centro de los hombros, superior a tolerancia, se debera dibujar
                        if (esqueletos[i].Joints[JointType.ShoulderCenter].Position.Z - esqueletos[i].Joints[JointType.HandRight].Position.Z > tolerancia)
                        {
                            //como se esta dibujando se debe pintar en el lienzo un punto (elipse) en la posicion de la mano.
                            Graphics.FromImage(PB_Lienzo2.Image).FillEllipse(new SolidBrush(color_elejido), x - (grosor / 2), y - (grosor / 2), grosor, grosor);
                            if (antx[i] > 0 || anty[i] > 0) //Si existe un punto anterior, se dibuja entre este y el actual una linea recta. (Así se evitan saltos y el dibujo se ve mas fluido)
                                //se usa "Graphics.FromImage" para evitar que se limpie el dibujo al refrescar el lienzo.
                                Graphics.FromImage(PB_Lienzo2.Image).DrawLine(new Pen(color_elejido, grosor), x, y, antx[i], anty[i]);
                            PB_Lienzo2.Invalidate();
                            //Ademas se actualizan los valores anteriores con la posicion actual
                            antx[i] = x;
                            anty[i] = y;
                        }
                        else
                        {   //Si no, se dibujará un objeto para marcar la posición que desaparecera al refrescar la pantalla
                            if (esq[0] == i) // si es el jugador 1 dibujara un ciruclo
                            {
                                g.DrawEllipse(new Pen(color_elejido, 12), new Rectangle((int)((x * ((float)PB_Lienzo2.Width / 640))), (int)((y * (float)PB_Lienzo2.Height / 480)), 50, 50));
                            }else
                            {               // si es el jugador 2 dibujara un rectangulo
                                g.DrawRectangle(new Pen(color_elejido, 12), new Rectangle((int)((x * ((float)PB_Lienzo2.Width / 640))), (int)((y * (float)PB_Lienzo2.Height / 480)), 50, 50));
                            }
                            //Ademas como se ha dejado de dibujar, el punto guardado como anterior se resetea.
                            antx[i] = 0;
                            anty[i] = 0;
                        }
                    }

                }
            }
        }
        private void busca(){
            //Esta función recoloca los esqueletos detectados en su posición correspondiente segun el jugador al que pertenezcan
            int []b= { -1,-1};      //inicializa los IDs de los esqueletos a -1 (no existen)
            int num  = 0;           //indica el numero de esqueletos detectados
            for (int i = 0; i < esqueletos.Length; i++)
            {
                //Para cada esqueleto busca si existe una posicion para la mano derecha
                int x = (int)(sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(esqueletos[i].Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).X);
                int y = (int)(sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(esqueletos[i].Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).Y);
                if (x != 0 && y != 0)
                {
                    //Si existe una posición, incrementa el numero de esqueletos detectados y añade su número al array de posiciones
                    b[num] = i;
                    num++;
                }
            }
            //si no hay esqueletos guardados y aparecen nuevos se asignan directamente
            if (esq[0] < 0 & b[0] > 0) {
                esq[0] = b[0];
            }
            if (esq[1] < 0 & b[1] > 0)
            {
                esq[1] = b[1];
            }
            //si se ha detectado un primer esqueleto distinto a alguno que ya existía (es nuevo)
            if (b[0] > 0 && b[0] != esq[0] && b[0] != esq[1]) {
                if (esq[1] == b[1]){    //si el segundo esqueleto detectado es el jugador 2
                   esq[0] = b[0];       //se asigna el nuevo esqueleto detectado al jugador 1
                }else{                 //Si no, se asigna al jugador 2 el nuevo esqueleto
                    esq[1] = b[0];
                }
           }
            //si se ha detectado un segundo esqueleto distinto a alguno que ya existía (es nuevo)
            if (b[1] > 0 && b[1] != esq[0] && b[1] != esq[1])
            {
                if (esq[1] == b[0])     //si el primer esqueleto detectado es el jugador 2
                {
                    esq[0] = b[1];      //se asigna el nuevo esqueleto detectado al jugador 1
                }
                else{                   //Si no, se asigna al jugador 2 el nuevo esqueleto
                    esq[1] = b[1];
                }
            }
        }
        private void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            //Si hay una imagen enviada desde la Kinect se asigna como imagen a Lienzo (fondo del dibujo)
            using (var frame = e.OpenColorImageFrame())
            {
                if (frame != null)
                {
                    //para crear una imagen a partir de un objeto "ColorImageFrame" se ha decidido crear una funcion independiente
                    PB_Lienzo.Image = crearbitmap(frame);
                }
            }
        }

        private Bitmap crearbitmap(ColorImageFrame fotograma)
        {
            //Esta función crea una imagen a partir de un objeto "ColorImageFrame"
            byte[] pixeldata = new byte[fotograma.PixelDataLength];         //Crea un array con una dimension que depende del numero de pixeles del frame
            fotograma.CopyPixelDataTo(pixeldata);                           //Convierte el frame en un array de pixeles
            Bitmap bmap = new Bitmap(fotograma.Width, fotograma.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb); //Crea un mapa de bits con las dimensiones del frame
            System.Drawing.Imaging.BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, fotograma.Width, fotograma.Height),System.Drawing.Imaging.ImageLockMode.WriteOnly,bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            //copia el array de pixeles en el mapa de bits creado
            System.Runtime.InteropServices.Marshal.Copy(pixeldata, 0, ptr, fotograma.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            //Devuelve el mapa de bits
            return bmap;
        }

        private void PB_Lienzo_SizeChanged(object sender, EventArgs e)
        {
            //Si el lienzo sobre el que se dibuja cambia de tamaño se debe refrescar el dibujo (Lienzo 2)
            PB_Lienzo2.Refresh();
        }
        private void PB_Lienzo2_MouseMove(object sender, MouseEventArgs e) //Esta función dibuja usando el ratón
        {
            if (click)      //Si se esta presionando el botón del ratón se dibuja
            {           
                //se crean variables locales de color y tamaño a un valro por defecto
                Color color_elejido = Color.Black;
                int grosor = 24;
                if (jugador_sel == 1)   //Si el jugador seleccionado es el 1
                {
                    //Se asiganan a las anteriores variables los valores de color y tamaño almacenados para el jugador 1
                    color_elejido = B_Selec1.BackColor;
                    grosor = tam1;
                }
                else {                  //Si el jugador seleccionado es el 2
                    //Se asiganan a las anteriores variables los valores de color y tamaño almacenados para el jugador 1
                    color_elejido = B_Selec2.BackColor;
                    grosor = tam2;
                }
                //se crean variables X e Y que corresponden a la posición del cursor sobre el Lienzo de dibujo. (Es necesario mapearlo segun el tamaño del Lienzo)
                int x= (int)(PB_Lienzo2.PointToClient(Cursor.Position).X * (640.0 / (float)PB_Lienzo2.Width));
                int y= (int)(PB_Lienzo2.PointToClient(Cursor.Position).Y * (480.0 / (float)PB_Lienzo2.Height));
                //Se dibuja un dirculo en la posición obtenida (se usa "Graphics.FromImage" de forma que se alamacene el dibujo anterior y se dibuje encima de este. De esta forma no se elimina lo dibujado)
                Graphics.FromImage(PB_Lienzo2.Image).FillEllipse(new SolidBrush(color_elejido), x-(grosor/2),y - (grosor / 2), grosor, grosor);
                if (antx[6] > 0 || anty[6] > 0)     //Si existe un punto anterior registrado
                {
                    //Se dibuja una linea entre el punto anterior y el actual. De esta forma se suaviza el dibujo 
                    Graphics.FromImage(PB_Lienzo2.Image).DrawLine(new Pen(color_elejido, grosor), x, y, antx[6], anty[6]);
                }
                PB_Lienzo2.Invalidate();        //necesario para que no se refresque el dibujo y no se borre
                //Finalmente se guarda el valor actual como ultimo punto registrado
                antx[6] = x;
                anty[6] = y;
            }else
            {
                //si no se esta pulsando el ratón se borra el punto anterior
                antx[6] = 0;
                anty[6] = 0;
            }
        }
        private static RecognizerInfo GetKinectRecognizer()     //configura el motor reconocimiento de voz
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "es-ES".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }
        
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Si se cierra la aplicación se desconecta el sensor
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }

        private void PB_Lienzo2_MouseDown(object sender, MouseEventArgs e)
        {
            //Si se pulsa sobre el lienzo se indica mediante la variable click
            click = true;
        }

        private void PB_Lienzo2_MouseUp(object sender, MouseEventArgs e)
        {
            //Si se deja de pulsar sobre el lienzo se indica mediante la variable click
            click = false;
        }

        private void CB_TAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si se selecciona un tamaño en el combobox
            if (jugador_sel == 1) {     //si esta seleccionado el jugador 1
                tam1 = Int32.Parse((string)CB_TAM.SelectedItem);
            } else {
                tam2= Int32.Parse((string)CB_TAM.SelectedItem);
            }
        }

        private void Borrador_Click(object sender, EventArgs e)
        {
            //Si se pulsa el boton borrar
            PB_Lienzo2.Invalidate();
            PB_Lienzo2.Image = new Bitmap(640, 480); //Crea un nuevo mapa de bits sobre el que dibujar (borrando todo lo anterior)
        }

        private void PB_Lienzo2_Resize(object sender, EventArgs e)
        {
            //Si el lienzo cambia de tamaño se debe asignar a la herramienta grafica el lienzo de nuevo (actualizando el tamaño del area de dibujo)
            g = PB_Lienzo2.CreateGraphics();
        }

        private void negro_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color negro se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Black;
            }
            else
            {
                B_Selec2.BackColor = Color.Black;
            }
        }

        private void Gray_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color gris se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Gray;
            }
            else
            {
                B_Selec2.BackColor = Color.Gray;
            }
        }

        private void blanco_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color blanco se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.White;
            }
            else
            {
                B_Selec2.BackColor = Color.White;
            }
        }

        private void Brown_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color marrón se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Brown;
            }
            else
            {
                B_Selec2.BackColor = Color.Brown;
            }
        }

        private void Red_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color rojo se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Red;
            }
            else
            {
                B_Selec2.BackColor = Color.Red;
            }
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color amarillo se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Yellow;
            }
            else
            {
                B_Selec2.BackColor = Color.Yellow;
            }
        }

        private void Pink_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color rosa se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Pink;
            }
            else
            {
                B_Selec2.BackColor = Color.Pink;
            }
        }

        private void OrangeRed_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color naranja se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Orange;
            }
            else
            {
                B_Selec2.BackColor = Color.Orange;
            }
        }

        private void RoyalBlue_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color azul se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Blue;
            }
            else
            {
                B_Selec2.BackColor = Color.Blue;
            }
        }

        private void Green_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color verde se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Green;
            }
            else
            {
                B_Selec2.BackColor = Color.Green;
            }
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            // Si se pulsa el boton de color morado se comprueba el jugador que esta activo y se modifica el color del mismo
            if (jugador_sel == 1)
            {
                B_Selec1.BackColor = Color.Purple;
            }
            else
            {
                B_Selec2.BackColor = Color.Purple;
            }
        }
        private void photo()
        {
            //realiza una imagen a partir de dos mapas de bits
            Bitmap bmpPicture = new Bitmap(640, 480);       //crea un mapa de bits (donde se dibujará todo)
            Graphics img = Graphics.FromImage(bmpPicture);  //asigna una herramienta de dibujo al mapa de bits
            img.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //se configura la caracteristica de interpolacion de la imagen
            if (PB_Lienzo.Image != null)    //Si existe alguna imagen de fondo (video de la Kinect)
            {
                img.DrawImage(PB_Lienzo.Image, new Point(0, 0));    //Usa la herramienta de dibujo para dibujar el contenido del cuadro de video en el mapa de bits
            }
            else {   //Si no existe ningun fondo de video
                img.FillRectangle(new SolidBrush(Color.White), 0, 0, 640, 480);     //Crea un fondo blanco 
            }
            img.DrawImage(PB_Lienzo2.Image, new Point(0, 0));       //dibuja el contenido del lienzo de dibujo en el mapa de bits
            //Se guarda la imagen creada en el escritorio con un nombre que depende de la fecha y hora (Asi se evita que haya conflictos de nombre)
            try
            {
                bmpPicture.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Imagen" + DateTime.Now.ToString("ddmmyyyyhhmmss") + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.IO.IOException) {
                MessageBox.Show("Error guardando Imagen");
                return;
            }
            sonido.Play();  //reproduce un sonido para indicar que se ha realizado una fotografia
        }

        private void B_camara_Click(object sender, EventArgs e)
        {
            //Si se pulsa el boton de la camara se invoca la funcion Photo
            photo();
        }
        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //se comprueban todos los comandos de voz registrados para ver cual coincide con el captado pro la kinect
            const double ConfidenceThreshold = 0.3;
            if (e.Result.Confidence >= ConfidenceThreshold)
            {
                switch (e.Result.Semantics.Value.ToString())
                {
                    case "PEQUEÑO":
                        //se ha seleccionado el tamaño de pincel pequeño 
                        CB_TAM.SelectedIndex = 1;   //cambia el combobox al valor en la posicion 1
                       break;
                    case "MEDIANO":
                        //se ha seleccionado el tamaño de pincel mediano
                        CB_TAM.SelectedIndex = 5;   //cambia el combobox al valor en la posicion 5
                        break;
                    case "GRANDE":
                        //se ha seleccionado el tamaño de pincel grande
                        CB_TAM.SelectedIndex = 8;   //cambia el combobox al valor en la posicion 8
                        break;
                    case "C_ROJO":
                        //se ha seleccionado el color de pincel rojo
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Red; //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Red; //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_NEGRO":
                        //se ha seleccionado el color de pincel negro
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Black;   //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Black;   //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_BLANCO":
                        //se ha seleccionado el color de pincel blanco
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.White;   //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.White;   //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_GRIS":
                        //se ha seleccionado el color de pincel gris
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Gray;    //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Gray;    //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_NARANJA":
                        //se ha seleccionado el color de pincel naranja
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Orange;  //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Orange;  //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_ROSA":
                        //se ha seleccionado el color de pincel rosa
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Pink;    //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Pink;    //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_AMARILLO":
                        //se ha seleccionado el color de pincel amarillo
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Yellow;  //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Yellow;  //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_AZUL":
                        //se ha seleccionado el color de pincel azul
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Blue;    //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Blue;    //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_VERDE":
                        //se ha seleccionado el color de pincel verde
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Green;   //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Green;   //se actualiza el color del jugador 2
                        }
                        break;
                    case "C_MORADO":
                        //se ha seleccionado el color de pincel morado
                        if (jugador_sel == 1)   //si esta seleccionado el jugador 1
                        {
                            B_Selec1.BackColor = Color.Purple;  //se actualiza el color del jugador 1
                        }
                        else
                        {
                            B_Selec2.BackColor = Color.Purple;  //se actualiza el color del jugador 2
                        }
                        break;
                    case "FOTO":
                        //se ha seleccionado hacer una foto
                        photo();
                        break;
                    case "BORRAR":
                        //se ha seleccionado hacer borrar
                        PB_Lienzo2.Invalidate();
                        PB_Lienzo2.Image = new Bitmap(640, 480);    //Crea un nuevo mapa de bits sobre el que dibujar (borrando todo lo anterior)
                        break;
                    case "AYUDA":
                        //se ha seleccionado ayuda
                        Ayuda.Visible = true;   //hace visible un dialogo de ayuda
                        break;
                    case "CERRAR":
                        //se ha seleccionado cerrar la ayuda
                        Ayuda.Visible = false;  //hace invisible el dialogo de ayuda
                        break;
                    case "P1":
                        //jugador 1 (círculo) seleccionado
                        actualizar_jugador(1);  //configura todos los controles para indicar que se ha seleccionado el juagador 1
                        break;
                    case "P2":
                        //jugador 2 (cuadrado) seleccionado
                        actualizar_jugador(2);  //configura todos los controles para indicar que se ha seleccionado el juagador 1
                        break;
                }
            }
        }

        private void B_Selec1_Click(object sender, EventArgs e)
        {
            //si se pulsa el boton del jugador 1 (circulo) se actualizan todos los controles
            actualizar_jugador(1);
        }

        private void B_Selec2_Click(object sender, EventArgs e)
        {
            //si se pulsa el boton del jugador 2 (cuadrado) se actualizan todos los controles
            actualizar_jugador(2);
        }
    }
}
