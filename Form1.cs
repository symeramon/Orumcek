using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Point> loc = new List<Point>();
        Label lbltakip = new Label();
        Label oyunculbl = new Label();
        Image i = Properties.Resources.spiddeer;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
            Random r = new Random();
            Label lbl = new Label();
            oyunculbl.Move += Oyunculbl_Move;
            oyunculbl.Height = 10;
            oyunculbl.Width = 10;
            oyunculbl.BackColor = Color.Black;
            lbltakip.Height = 5;
            lbltakip.Width = 5;
            lbltakip.Move += Lbltakip_Move;
            //lbltakip.AutoSize = true;
            //lbltakip.Image = i;
            for (int i = 0; i < 70; i++)
            {
                bool trumu = false;
                Point pt = new Point();
                pt.X = r.Next(0, 530);
                pt.Y = r.Next(0, 600);
                foreach (Point pot in loc)
                {
                    if (pot.X == pt.X)
                    {
                        trumu = true;
                        break;
                    }
                }
                if (trumu == false)
                {
                    loc.Add(pt);
                }

            }
            foreach (Point poi in loc)
            {
                //lbl.Text = "x";
                lbl.Height = 1;
                lbl.Width = 1;
                lbl.Location = poi;
                lbl.BackColor = Color.Transparent;
                this.Controls.Add(lbl);
            }
            this.Controls.Add(lbltakip);
            this.Controls.Add(oyunculbl);
        }

        private void Oyunculbl_Move(object sender, EventArgs e)
        {

        }

        //       private void Form1_MouseMove(object sender, MouseEventArgs e)
        //       {
        //           Random rd = new Random();

        //           Graphics gr = this.CreateGraphics();
        //           gr.Clear(this.BackColor);
        //           foreach (Point poi in loc)
        //           {

        //               if (poi.X <=e.X+rd.Next(90,150) && poi.Y <=e.Y+ rd.Next(90, 150) && poi.X > e.X - rd.Next(90, 150) && poi.Y > e.Y - rd.Next(90, 150)) 
        //               {
        //using (Pen pen = new Pen(Color.Black))
        //                   {
        //                   pen.Width = 2;

        //                   gr.DrawLine(pen, (int)poi.X, (int)poi.Y, (int)e.X, (int)e.Y);
        //                   }
        //               }
        //           }
        //       }

        private Brush PickBrush()//random renk için
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
        private void Lbltakip_Move(object sender, EventArgs e)
        {
            Random rd = new Random();

            Graphics gr = this.CreateGraphics();
            gr.Clear(this.BackColor);
            foreach (Point poi in loc)
            {
                if (poi.X <= (sender as Label).Location.X + rd.Next(90, 150) && poi.Y <= (sender as Label).Location.Y + rd.Next(90, 150) && poi.X > (sender as Label).Location.X - rd.Next(90, 150) && poi.Y > (sender as Label).Location.Y - rd.Next(90, 150))
                {
                    using (Pen pen = new Pen(Color.Black))
                    {
                        pen.Width = 2;

                        gr.DrawLine(pen, (int)poi.X, (int)poi.Y, (int)(sender as Label).Location.X, (int)(sender as Label).Location.Y);
                    }

                }
            }
        }
        Point vector = new Point();
        int frames = 15;

        public void TransitionMouseTo(int x, int y, int durationSecs)
        {
           

            

            vector.X = (x - lbltakip.Location.X) / frames;
            vector.Y = (y - lbltakip.Location.Y) / frames;

            timer3.Start();
        }
        int timersayi = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timersayi += 1;
            if (timersayi < sayi)
            {

                //if (Cursor.Position.Y > (this.Top / 2))
                //{
                //    lbltakip.Top -= 5;
                //}
                //if (Cursor.Position.X > (this.Left /2))
                //{
                //    lbltakip.Left += 5;
                //}

                //Label yazi = new Label(); mouse hareketinin altını çizer
                //yazi.Tag = 0;
                //yazi.Location = mousedot[timersayi];
                //yazi.Height = 10;
                //yazi.Width = 10;
                //yazi.BackColor = Color.Black;
                //this.Controls.Add(yazi);
            }
            else
            {
                timer1.Stop();
            }

        }
        List<Point> mousedot = new List<Point>();
        int sayi = 0;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            timer1.Start();
            //        Point locationOnForm = (sender as Label).FindForm().PointToClient(
            //(sender as Label).Parent.PointToScreen((sender as Label).Location));
            Point mousept = new Point();
            mousept.X = e.Location.X;
            mousept.Y = e.Location.Y;
            mousedot.Add(mousept);
            sayi += 1;
            //TransitionMouseTo(Cursor.Position.X, Cursor.Position.Y, 15);

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //this.Controls.Clear();
            //timer1.Stop();
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
            {
                oyunculbl.Left -= 5;
            }
            if (e.KeyData == Keys.Right)
            {
                oyunculbl.Left += 5;
            }
            //if (e.KeyData == Keys.Up && e.KeyData == Keys.Right)
            //{
            //    oyunculbl.Left += 5;
            //    oyunculbl.Top -= 5;

            //}
            if (e.KeyData == Keys.Up)
            {
                oyunculbl.Top -= 5;
            }
            if (e.KeyData == Keys.Down)
            {
                oyunculbl.Top += 5;
            }
        }
        Random x = new Random();
        Boolean bl = false;
        Label lbl;
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (bl == false)
            {
                Point pt = new Point();
                pt.X = x.Next(0, 530);
                pt.Y = x.Next(0, 600);
                lbl = new Label();
                lbl.Disposed += Lbl_Disposed;
                lbl.MouseEnter += Lbl_MouseEnter;
                lbl.Height = 30;
                lbl.Width = 30;
                lbl.Location = pt;
                lbl.BackColor = Color.Black;
                this.Controls.Add(lbl);
                TransitionMouseTo(lbl.Location.X, lbl.Location.Y, 10);
                bl = true;
            }
            else
            {
                lbl.Dispose();
                //this.Controls.Clear();

                bl = false;
            }

        }

        private void Lbl_Disposed(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        int point = 0;
        int pointuser = 0;
        private void Lbl_MouseEnter(object sender, EventArgs e)
        {
            pointuser += 1;
            label2.Text = pointuser.ToString();
            (sender as Label).Dispose();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
                Point pos = lbltakip.Location;

                pos.X += vector.X;
                pos.Y += vector.Y;

                lbltakip.Location = pos;
            //if ((lbltakip.Left + lbltakip.Width >= lbl.Left && lbltakip.Left <= (lbl.Left + lbl.Width)) && (lbltakip.Top + lbltakip.Height >= (lbl.Top + this.Top-5) && lbltakip.Top <= lbl.Top + lbl.Height))
           
           
                if ((lbltakip.Left + lbltakip.Width>lbl.Left) && !((lbltakip.Left + lbltakip.Width) > (lbl.Left + lbl.Width))&& (lbltakip.Top + lbltakip.Height > lbl.Top) && !((lbltakip.Top + lbltakip.Height) > (lbl.Top + lbl.Height)))
                {
                    point += 1;
                    label1.Text = point.ToString();
                    lbl.Dispose();
                    timer3.Stop();
                }


            //if ()
            //{
            //    point += 1;
            //    label1.Text = point.ToString();
            //    lbl.Dispose();
            //    timer3.Stop();
            //}
            //if ((lbltakip.Left + lbltakip.Width >= lbl.Left && lbltakip.Left <= (lbl.Left + lbl.Width)) && (lbltakip.Top + lbltakip.Height >= (lbl.Top + this.Top - 5) && lbltakip.Top <= lbl.Top + lbl.Height))
            //{

            //    //button1.top - button1.height <= (ctrl.height +  ctrl.top)-button1.height && ctrl.left + ctrl.width >= button1.left && ctrl.left <= button1.left + button1.width
            //}
            //Thread.Sleep((durationSecs / frames) * 100);

        }
    }
}