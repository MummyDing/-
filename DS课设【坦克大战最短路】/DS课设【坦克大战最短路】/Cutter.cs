using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS课设_坦克大战最短路_
{
    public partial class Cutter : Form
    {
        public Point downPoint = new Point();
        public Point upPoint = new Point();
        public bool isDraw = false;
         
        public Cutter()
        {
            InitializeComponent();
        }

        private void Cutter_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDraw==false&&MainForm.isCutDraw)
            {
                isDraw = true;
                downPoint.X = e.X;
                downPoint.Y = e.Y;
            }
       
        }

        private void Cutter_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDraw && MainForm.isCutDraw)
            {
                Point p1 = new Point();
                Point p2 = new Point();
                if (downPoint.X < e.X)
                {
                    p1.X = downPoint.X;
                    p2.X = e.X;
                }
                else
                {
                    p1.X = e.X;
                    p2.X = downPoint.X;
                }
                if (downPoint.Y < e.Y)
                {
                    p1.Y = downPoint.Y;
                    p2.Y = e.Y;
                }
                else
                {
                    p1.Y = e.Y;
                    p2.Y = downPoint.Y;
                }
                Bitmap bmp = (Bitmap)MainForm.CatchBmp.Clone();
                Graphics g = Graphics.FromImage(bmp);
                g.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(p1.X, p1.Y, Math.Abs(e.X - downPoint.X), Math.Abs(downPoint.Y - e.Y)));
                g.Dispose();
                Graphics g1 = this.CreateGraphics();
                g1.DrawImage(bmp, new Point(0, 0));
            }
        }

        private void Cutter_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDraw == true && MainForm.isCutDraw)
            {
                Point p1 = new Point();
                Point p2 = new Point();
                if (downPoint.X < e.X)
                {
                    p1.X = downPoint.X;
                    p2.X = e.X;
                }
                else
                {
                    p1.X = e.X;
                    p2.X = downPoint.X;
                }
                if (downPoint.Y < e.Y)
                {
                    p1.Y = downPoint.Y;
                    p2.Y = e.Y;
                }
                else
                {
                    p1.Y = e.Y;
                    p2.Y = downPoint.Y;
                }

                isDraw = false;
                int width = Math.Abs(p2.X - p1.X);
                int  height = Math.Abs(p2.Y - p1.Y);
                Rectangle sizeRect = new Rectangle(new Point(p1.X, p1.Y), new Size(width, height));
                Bitmap  catchedBmp = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(catchedBmp);
                g.DrawImage(MainForm.CatchBmp, new Rectangle(new Point(0, 0), new Size(width, height)), sizeRect, GraphicsUnit.Pixel);
                Clipboard.SetImage(catchedBmp);

                MainForm.isCutDraw = false;
                this.Visible = false;
            }
        }
    }
}
