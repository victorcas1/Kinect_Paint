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

namespace Paint_Kinect
{
    public partial class Form1 : Form
    {
        private KinectSensor sensor;
        //private Skeleton[] esqueletos;
        private float escalay;
        private float escalax;
        private Color color_elejido = Color.Red;
        private int grosor = 25;
        private Boolean click = false;
        private double tolerancia = 0.40;
        Graphics g;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PB_Lienzo2.Parent = PB_Lienzo;
            g = PB_Lienzo2.CreateGraphics();
            PB_Lienzo2.Location = new Point(0, 0);
            PB_Lienzo2.Image = new Bitmap(PB_Lienzo.Width, PB_Lienzo.Height);
            this.escalax = (float)PB_Lienzo.Width / 640;
            this.escalay = (float)PB_Lienzo.Height / 480;
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
                foreach (Skeleton skel in esqueletos)
                {
                    float x = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skel.Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).X;
                    float y = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skel.Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30).Y;
                    x = (int)(Math.Abs(x * escalax) - PB_Lienzo2.Location.X);
                    y = (int)(Math.Abs(y * escalay) - PB_Lienzo2.Location.Y);
                    Status_kinect.Text = "X: " + x + "   Y: " + y;
                    if (x != 0 && y != 0)
                    {
                        if (skel.Joints[JointType.ShoulderCenter].Position.Z - skel.Joints[JointType.HandRight].Position.Z > tolerancia)
                        {
                            Graphics.FromImage(PB_Lienzo2.Image).FillEllipse(new SolidBrush(color_elejido), x, y, grosor, grosor);
                            PB_Lienzo2.Invalidate();
                        }
                        else
                        {
                            g.DrawEllipse(new Pen(color_elejido, 12), new Rectangle((int)(x - (25)), (int)(y - (25)), 50, 50));
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
            this.escalax = (float)PB_Lienzo.Width / 640;
            this.escalay = (float)PB_Lienzo.Height / 480;
            PB_Lienzo2.Refresh();
        }
        private void PB_Lienzo2_MouseMove(object sender, MouseEventArgs e)
        {
            if (click)
            {
                Graphics.FromImage(PB_Lienzo2.Image).FillEllipse(new SolidBrush(color_elejido), Cursor.Position.X - PB_Lienzo.Location.X - this.Location.X-17, Cursor.Position.Y - PB_Lienzo.Location.Y - this.Location.Y-40, grosor, grosor);
                PB_Lienzo2.Invalidate();
                Status_kinect.Text = "X: " + Cursor.Position.X + "   Y: " + PB_Lienzo.Location.X + "        " + this.Location.X;
            }
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
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.ColorFrameReady += Sensor_ColorFrameReady;
            sensor.SkeletonStream.Enable();
            this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;
            try
            {
                this.sensor.Start();
            }
            catch (System.IO.IOException)
            {
                this.sensor = null;
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
    }
}
