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
        private KinectSensor sensor;
        //private Skeleton[] esqueletos;
        private Color color_elejido = Color.Black;
        private int grosor = 25;
        private Boolean click = false;
        private double tolerancia = 0.40;
        Graphics g;
        private int[] antx = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] anty= new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<Span> recognitionSpans;
        private SpeechRecognitionEngine speechEngine;
        System.Media.SoundPlayer sonido = new System.Media.SoundPlayer(Application.StartupPath + "/756.wav");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PB_Lienzo2.Parent = PB_Lienzo;
            g = PB_Lienzo2.CreateGraphics();
            PB_Lienzo2.Location = new Point(0, 0);
            PB_Lienzo2.Image = new Bitmap(640, 480);
            CB_TAM.SelectedIndex = 5;
            grosor = Int32.Parse((string)CB_TAM.SelectedItem);
            reconect();
        }

        private void B_conect_Click(object sender, EventArgs e)
        {
            reconect();
        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] esqueletos = new Skeleton[0];
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    esqueletos = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(esqueletos);
                }
            }
            if (esqueletos.Length != 0)
            {
                for (int i = 0; i < esqueletos.Length; i++)
                {
                    int x = (int)(sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(esqueletos[i].Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).X);
                    int y = (int)(sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(esqueletos[i].Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).Y);
                    //x = (int)(Math.Abs(x * escalax) - PB_Lienzo2.Location.X);
                    //y = (int)(Math.Abs(y * escalay) - PB_Lienzo2.Location.Y);
                    if (x != 0 && y != 0)
                    {
                        if (esqueletos[i].Joints[JointType.ShoulderCenter].Position.Z - esqueletos[i].Joints[JointType.HandRight].Position.Z > tolerancia)
                        {
                            Graphics.FromImage(PB_Lienzo2.Image).FillEllipse(new SolidBrush(color_elejido), x - (grosor / 2), y - (grosor / 2), grosor, grosor);
                            if (antx[i] > 0 || anty[i] > 0)
                                Graphics.FromImage(PB_Lienzo2.Image).DrawLine(new Pen(color_elejido, grosor), x, y, antx[i], anty[i]);
                            PB_Lienzo2.Invalidate();
                            Status_kinect.Text = "X: " + x + "   Y: " + y;
                            antx[i] = x;
                            anty[i] = y;
                        }
                        else
                        {
                            
                            g.DrawEllipse(new Pen(color_elejido, 12), new Rectangle((int)((x*((float)PB_Lienzo2.Width/640))), (int)((y*(float)PB_Lienzo2.Height / 480)), 50, 50));
                            antx[i] = 0;
                            anty[i] = 0;
                        }
                    }

                }
            }
        }

        private void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (var frame = e.OpenColorImageFrame())
            {
                if (frame != null)
                {
                    PB_Lienzo.Image = crearbitmap(frame);
                    //PB_Lienzo2.Refresh();
                }
            }
        }

        private Bitmap crearbitmap(ColorImageFrame fotograma)
        {
            byte[] pixeldata = new byte[fotograma.PixelDataLength];
            fotograma.CopyPixelDataTo(pixeldata);
            Bitmap bmap = new Bitmap(fotograma.Width, fotograma.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            System.Drawing.Imaging.BitmapData bmapdata = bmap.LockBits(
                new Rectangle(0, 0, fotograma.Width, fotograma.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly,
                bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(pixeldata, 0, ptr, fotograma.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        private void PB_Lienzo_SizeChanged(object sender, EventArgs e)
        {
            PB_Lienzo2.Refresh();
        }
        private void PB_Lienzo2_MouseMove(object sender, MouseEventArgs e)
        {
            if (click)
            {
                int x= (int)(PB_Lienzo2.PointToClient(Cursor.Position).X * (640.0 / (float)PB_Lienzo2.Width));
                int y= (int)(PB_Lienzo2.PointToClient(Cursor.Position).Y * (480.0 / (float)PB_Lienzo2.Height));
                Graphics.FromImage(PB_Lienzo2.Image).FillEllipse(new SolidBrush(color_elejido), x-(grosor/2),y - (grosor / 2), grosor, grosor);
                if (antx[9] > 0 || anty[9] > 0)
                {
                    Graphics.FromImage(PB_Lienzo2.Image).DrawLine(new Pen(color_elejido, grosor), x, y, antx[9], anty[9]);
                }
                PB_Lienzo2.Invalidate();
                Status_kinect.Text = "X: " + x + "   Y: " + y + "        " + this.Location.X;
                antx[9] = x;
                anty[9] = y;
            }else
            {
                antx[9] = 0;
                anty[9] = 0;
            }
        }
        private static RecognizerInfo GetKinectRecognizer()
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
        private void reconect()
        {
            if (KinectSensor.KinectSensors.Count > 0)
            {
                sensor = KinectSensor.KinectSensors[0];
            }
            else
            {
                return;
            }
            
            try
            {
                sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                sensor.ColorFrameReady += Sensor_ColorFrameReady;
                sensor.SkeletonStream.Enable();
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;
                this.sensor.Start();
            }
            catch (System.IO.IOException)
            {
                this.sensor = null;
                return;
            }
            L_estado.Text = "";
            RecognizerInfo ri = GetKinectRecognizer();

            if (null != ri)
            {
                this.speechEngine = new SpeechRecognitionEngine(ri.Id);
               
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

                var gb = new GrammarBuilder { Culture = ri.Culture };
                gb.Append(directions);

                var g = new Grammar(gb);
                speechEngine.LoadGrammar(g);
                
                speechEngine.SpeechRecognized += SpeechRecognized;

                
                speechEngine.SetInputToAudioStream(
                    sensor.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }

        private void PB_Lienzo2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PB_Lienzo2_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
        }

        private void PB_Lienzo2_MouseUp(object sender, MouseEventArgs e)
        {
            click = false;
        }

        private void CB_TAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            grosor = Int32.Parse((string)CB_TAM.SelectedItem);
        }

        private void Borrador_Click(object sender, EventArgs e)
        {
            PB_Lienzo2.Invalidate();
            PB_Lienzo2.Image = new Bitmap(640, 480);
        }

        private void PB_Lienzo2_Resize(object sender, EventArgs e)
        {
            g = PB_Lienzo2.CreateGraphics();
        }

        private void negro_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Black;
            B_Selec.BackColor = color_elejido;
        }

        private void Gray_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Gray;
            B_Selec.BackColor = color_elejido;
        }

        private void blanco_Click(object sender, EventArgs e)
        {
            color_elejido = Color.White;
            B_Selec.BackColor = color_elejido;
        }

        private void Brown_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Brown;
            B_Selec.BackColor = color_elejido;
        }

        private void Red_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Red;
            B_Selec.BackColor = color_elejido;
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Yellow;
            B_Selec.BackColor = color_elejido;
        }

        private void Pink_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Pink;
            B_Selec.BackColor = color_elejido;
        }

        private void OrangeRed_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Orange;
            B_Selec.BackColor = color_elejido;
        }

        private void RoyalBlue_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Blue;
            B_Selec.BackColor = color_elejido;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Green;
            B_Selec.BackColor = color_elejido;
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            color_elejido = Color.Purple;
            B_Selec.BackColor = color_elejido;
        }
        private void photo()
        {
            Bitmap bmpPicture = new Bitmap(640, 480);
            Graphics img = Graphics.FromImage(bmpPicture);
            //Graphics img = Graphics.FromImage(PB_Lienzo.Image);
            img.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            if (PB_Lienzo.Image != null)
            {
                img.DrawImage(PB_Lienzo.Image, new Point(0, 0));
            }
            else
            {
                img.FillRectangle(new SolidBrush(Color.White), 0, 0, 640, 480);
            }
            img.DrawImage(PB_Lienzo2.Image, new Point(0, 0));
            bmpPicture.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Imagen" + DateTime.Now.ToString("ddmmyyyyhhmmss") + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void B_camara_Click(object sender, EventArgs e)
        {
            photo();

        }
        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            const double ConfidenceThreshold = 0.3;
            if (e.Result.Confidence >= ConfidenceThreshold)
            {
                switch (e.Result.Semantics.Value.ToString())
                {
                    case "PEQUEÑO":
                        CB_TAM.SelectedIndex = 1;
                       break;
                    case "MEDIANO":
                        CB_TAM.SelectedIndex = 5;
                        break;
                    case "GRANDE":
                        CB_TAM.SelectedIndex = 8;
                        break;
                    case "C_ROJO":
                        B_Selec.BackColor = Color.Red;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_NEGRO":
                        B_Selec.BackColor = Color.Black;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_BLANCO":
                        B_Selec.BackColor = Color.White;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_GRIS":
                        B_Selec.BackColor = Color.Gray;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_NARANJA":
                        B_Selec.BackColor = Color.Orange;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_ROSA":
                        B_Selec.BackColor = Color.Pink;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_AMARILLO":
                        B_Selec.BackColor = Color.Yellow;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_AZUL":
                        B_Selec.BackColor = Color.Blue;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_VERDE":
                        B_Selec.BackColor = Color.Green;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "C_MORADO":
                        B_Selec.BackColor = Color.Purple;
                        color_elejido = B_Selec.BackColor;
                        break;
                    case "FOTO":
                        photo();
                        sonido.Play();
                        break;
                    case "BORRAR":
                        PB_Lienzo2.Invalidate();
                        PB_Lienzo2.Image = new Bitmap(640, 480);
                        break;
                }
            }
        }
    }
}
