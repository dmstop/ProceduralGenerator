using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProceduralGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Task.Run(RenderProcedural);

            //RenderProcedural();
        }

        void RenderProcedural()
        {
            DateTime dateTimeFrom = DateTime.Now;

            while (true)
            {
                var dateTimeTo = DateTime.Now;
                double elapsedTime = (dateTimeTo - dateTimeFrom).TotalSeconds;
                dateTimeFrom = dateTimeTo;
                
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using var brushB = new SolidBrush(Color.Black);
            using var brushW = new SolidBrush(Color.White);

            //gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.Black);

            for (int h = 0; h < pictureBox1.Height; h++)
            {
                for (int w = 0; w < pictureBox1.Width; w++)
                {
                    int seed = h | w;

                    Random random = new Random(seed);

                    int rand = random.Next(0, 20);

                    g.FillRectangle(rand == 0 ? brushW : brushB, w, h, 1, 1);
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                pictureBox1.Invalidate();
            }
        }

        //{
        //    var dateTimeTo = DateTime.Now;
        //    double elapsedTime = (dateTimeTo - dateTimeFrom).TotalSeconds;
        //    dateTimeFrom = dateTimeTo;

        //    using var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    using var gfx = Graphics.FromImage(bmp);
        //    using var pen = new Pen(Color.White);
        //    using var brushB = new SolidBrush(Color.Black);
        //    using var brushW = new SolidBrush(Color.White);

        //    //gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //    gfx.Clear(Color.Black);

        //    for (int h = 0; h<bmp.Height; h++)
        //    {
        //        for (int w = 0; w<bmp.Width; w++)
        //        {
        //            int seed = h | w;

        //            Random = new Random(seed);

        //            int rand = Random.Next(0, 20);

        //            gfx.FillRectangle(rand == 0 ? brushW : brushB, w, h, 1, 1);
        //        }
        //    }

        //    pictureBox1.Image?.Dispose();
        //    pictureBox1.Image = (Bitmap)bmp.Clone();
        //}

        //void RenderLines()
        //{
        //    using var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    using var gfx = Graphics.FromImage(bmp);
        //    using var pen = new Pen(Color.White);

        //    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //    gfx.Clear(Color.Navy);
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        var pt1 = new Point(Random.Next(bmp.Width), Random.Next(bmp.Height));
        //        var pt2 = new Point(Random.Next(bmp.Width), Random.Next(bmp.Height));
        //        gfx.DrawLine(pen, pt1, pt2);
        //    }


        //    pictureBox1.Image?.Dispose();
        //    pictureBox1.Image = (Bitmap)bmp.Clone();
        //}


    }
}
