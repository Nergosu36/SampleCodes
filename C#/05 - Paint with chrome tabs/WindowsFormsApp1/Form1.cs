using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using EasyTabs;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //TabControl tabs;
        Graphics g;
        Bitmap b;
        Pen pen;
        REKT figure = new REKT();
        int pointx;
        int pointy;
        int spointx;
        int spointy;
        int epointx;
        int epointy;
        bool moving;
        class REKT
        {
            virtual public void draw(Bitmap b, Graphics g, Pen p, int sX, int sY, int eX, int eY, int pX, int pY)
            {

            }
        }
        class REKTangle: REKT
        {
            int tspointx;
            int tspointy;
            override public void draw(Bitmap b, Graphics g, Pen p, int sX, int sY, int eX, int eY, int pX, int pY)
            {
                tspointx = sX;
                tspointy = sY;
                if ((eX - sX) < 0)
                    tspointx = eX;
                if ((eY - sY) < 0)
                    tspointy = eY;
                g.DrawRectangle(p, tspointx, tspointy, Math.Abs(eX - sX), Math.Abs(eY - sY));
                g = Graphics.FromImage(b);
                g.DrawRectangle(p, tspointx, tspointy, Math.Abs(eX - sX), Math.Abs(eY - sY));
            }
        }
        class REKTline : REKT
        {
            override public void draw(Bitmap b,  Graphics g, Pen p, int sX, int sY, int eX, int eY, int pX, int pY)
            {
                g.DrawLine(p, sX, sY, eX, eY);
                g = Graphics.FromImage(b);
                g.DrawLine(p, sX, sY, eX, eY);
            }
        }
        class REKTfree : REKT
        {
            override public void draw(Bitmap b,  Graphics g, Pen p, int sX, int sY, int eX, int eY, int pX, int pY)
            {
                g.DrawLine(p, new Point(pX, pY), new Point(pX+1, pY+1));
                g = Graphics.FromImage(b);
                g.DrawLine(p, new Point(pX, pY), new Point(pX + 1, pY + 1));
            }
        }
        public static char type;
         
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            b = new Bitmap(1920,1080);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            figure.draw(b,g, pen, spointx, spointy, epointx, epointy, pointx, pointy);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            spointx = e.X;
            spointy = e.Y;
            pointx = e.X;
            pointy = e.Y;
            panel1.Cursor = Cursors.Cross;
            b.SetResolution(panel1.Width, panel1.Height);
            panel1.Size = new Size(ClientSize.Width, ClientSize.Height);
            g = panel1.CreateGraphics();
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && pointx!=-1 && pointy!=-1)
            {
                pointx = e.X;
                pointy = e.Y;
                if (figure is REKTfree)
                {
                    panel1_Paint(this, null);
                }
                panel1.BackgroundImage = b;
            }

        }
        private void PanelOnResize(object sender, EventArgs e)
        {
           panel1.Invalidate();
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            epointx = e.X;
            epointy = e.Y;
            panel1_Paint(this, null);
            pointx = -1;
            pointy = -1;
            panel1.Cursor = Cursors.Default;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            figure = new REKTangle();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            figure = new REKTline();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            figure = new REKTfree();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = ".";
            dialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                b.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = ".";
            openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                b = new Bitmap(filePath, true);
                panel1.BackgroundImage = b;
            }
        }
    }
}
