using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edytor
{
    public partial class Form1 : Form
    {
        enum Tools {None, Line, Elipse, Square};
        Tools tool = Tools.None;
        Graphics graphics;
        Pen pen = new Pen(Color.Red,1);
        int x0, y0,x1,y1;
        bool mouseButton = false;
        Bitmap bitmap;
        //public ToolStripComboBox("red");

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);


        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            tool = Tools.None;
            //graphics.Clear();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            tool = Tools.Line;
            //graphics.DrawLine(pen, 10,10,100,100);
        }

        private void btnElipse_Click(object sender, EventArgs e)
        {
            tool = Tools.Elipse;
            //graphics.DrawEllipse(pen, 100,100,50,50);
        }
        private void btnSquare_Click(object sender, EventArgs e)
        {
            tool = Tools.Square;
        }

        
    
        private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = colorBox.SelectedItem.ToString();
            switch (item)
            {
                case "red": pen.Color = Color.Red; break;
                case "blue": pen.Color = Color.Blue; break;
                case "green": pen.Color = Color.Green; break;
                case "yellow": pen.Color = Color.Yellow; break;
                case "black": pen.Color = Color.Black; break;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool != Tools.None && Control.MouseButtons == MouseButtons.Left)
            {
                mouseButton = true;
                x0 = e.X; y0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((tool != Tools.None) && (mouseButton))
            {
                x1 = e.X;
                y1 = e.Y;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((tool != Tools.None) && mouseButton)
            {
                switch (tool)
                {
                    case Tools.Line:
                        graphics.DrawLine(pen, x0, y0, e.X, e.Y);
                        break;
                    case Tools.Elipse:
                        graphics.DrawEllipse(pen, x0, y0, e.X - x0, e.Y - y0);
                        break;
                    case Tools.Square:
                        graphics.DrawRectangle(pen, x0, y0, Math.Abs(x0 - x1), Math.Abs(y0 - y1));
                        break;
                }
                mouseButton = false;
                pictureBox1.Image = bitmap;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if ((tool != Tools.None) && mouseButton)
            {
                switch (tool)
                {
                    case Tools.Line:
                        e.Graphics.DrawLine(pen, x0, y0, x1, y1);
                        break;
                    case Tools.Elipse:
                        e.Graphics.DrawEllipse(pen, x0, y0, x1 - x0, y1 - y0);
                        break;
                    case Tools.Square:
                        int minx = Math.Min(x0, x1);
                        int miny = Math.Min(y0, y1);
                        int width = Math.Abs(x0 - y1);
                        int height = Math.Abs(y0 - x1);
                        e.Graphics.DrawRectangle(pen, minx, miny, width, height);
                        break;
                }
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Yellow;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Green;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Black;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       

        private void btnSecret_Click(object sender, EventArgs e)
        {
            graphics.DrawEllipse(pen, 300, 310, 100, 100);
            graphics.DrawEllipse(pen, 400, 310, 100, 100);
            graphics.DrawEllipse(pen, 350, 100, 100, 230);
            graphics.DrawLine(pen, 363, 140, 437, 140);
            graphics.DrawLine(pen, 400, 100, 400, 140);
        }
    }
}

