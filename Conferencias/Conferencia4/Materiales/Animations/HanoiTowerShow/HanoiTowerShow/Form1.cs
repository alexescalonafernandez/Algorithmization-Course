using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace HanoiTowerShow
{
    public partial class Form1 : Form
    {
        Stack<int> a, b, c;
        object stopLock = new object();
        object finishLock = new object();
        bool stop, finish;

        public bool Stop
        {
            get
            {
                lock (stopLock)
                {
                    return stop;
                }
            }
            set
            {
                lock (stopLock)
                {
                    stop = value;
                }
            }
        }

        public bool Finish
        {
            get
            {
                lock (finishLock)
                {
                    return finish;
                }
            }
            set
            {
                lock (finishLock)
                {
                    finish = value;
                }
            }
        }

        int counter, disks;
        PictureBox[] pictures;
        Dictionary<int, Brush> pallete;
        public Form1()
        {
            InitializeComponent();
            pallete = new Dictionary<int, Brush>();
            pallete.Add(100, Brushes.Blue);
            pallete.Add(90, Brushes.Red);
            pallete.Add(80, Brushes.Green);
            pallete.Add(70, Brushes.Yellow);
            pallete.Add(60, Brushes.Brown);
            pallete.Add(50, Brushes.Pink);
            pallete.Add(40, Brushes.Gray);
            pallete.Add(30, Brushes.Gold);
            a = new Stack<int>();
            b = new Stack<int>();
            c = new Stack<int>();
            disks = -1;
            pictures = new PictureBox[8];
            PictureBox pictureBox;
            for (int i = 7; i >= 0; i--)
            {
                pictureBox = new PictureBox();
                pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
                pictureBox.Size = new System.Drawing.Size(86, 50);
                pictures[i] = pictureBox;
                panel1.Controls.Add(pictureBox);
            }
            pictureBox1.Image = BitmapGenerator.GenerateHanoiTower(new int[0], new int[0], new int[0], pallete);
            finish = true;
        }

        private void Initialize()
        {
            a.Clear();
            b.Clear();
            c.Clear();
            counter = 0;
            int n = 100;
            int limit = 100 - (disks * 10);
            while(n >= limit)
            {
                a.Push(n);
                n-=10;
            }
            pictureBox1.Image = BitmapGenerator.GenerateHanoiTower(a.ToArray(), b.ToArray(), c.ToArray(),pallete);
            pictures[disks].Image = BitmapGenerator.GenerateNumberImage(pictures[disks].Width, pictures[disks].Height, counter);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = false;
            Stop = false;
            Finish = false;
            for (int i = 0; i < 8 && !Stop; i++)
            {
                disks = i;
                Initialize();
                Application.DoEvents();
                Thread.Sleep(500);
                AtoC(disks + 1);
            }
            Finish = true;
            startToolStripMenuItem.Enabled = true;
        }

        private void DrawStacks()
        {
            pictureBox1.Image = BitmapGenerator.GenerateHanoiTower(a.ToArray(), b.ToArray(), c.ToArray(), pallete);
            counter++;
            pictures[disks].Image = BitmapGenerator.GenerateNumberImage(pictures[disks].Width, pictures[disks].Height, counter);
            Application.DoEvents();
            Thread.Sleep(900);
        }

        private void AtoC(long n)
        {
            if (!Stop)
            {
                if (n == 1)
                {
                    c.Push(a.Pop());
                    DrawStacks();
                }
                else
                {
                    AtoB(n - 1);
                    AtoC(1);
                    BtoC(n - 1);
                }
            }
        }

        private void AtoB(long n)
        {
            if (!Stop)
            {
                if (n == 1)
                {
                    b.Push(a.Pop());
                    DrawStacks();
                }
                else
                {
                    AtoC(n - 1);
                    AtoB(1);
                    CtoB(n - 1);
                }
            }
        }

        private void CtoA(long n)
        {
            if (!Stop)
            {
                if (n == 1)
                {
                    a.Push(c.Pop());
                    DrawStacks();
                }
                else
                {
                    CtoB(n - 1);
                    CtoA(1);
                    BtoA(n - 1);
                }
            }
        }

        private void CtoB(long n)
        {
            if (!Stop)
            {
                if (n == 1)
                {
                    b.Push(c.Pop());
                    DrawStacks();
                }
                else
                {
                    CtoA(n - 1);
                    CtoB(1);
                    AtoB(n - 1);
                }
            }
        }

        private void BtoA(long n)
        {
            if (!Stop)
            {
                if (n == 1)
                {
                    a.Push(b.Pop());
                    DrawStacks();
                }
                else
                {
                    BtoC(n - 1);
                    BtoA(1);
                    CtoA(n - 1);
                }
            }
        }

        private void BtoC(long n)
        {
            if (!Stop)
            {
                if (n == 1)
                {
                    c.Push(b.Pop());
                    DrawStacks();
                }
                else
                {
                    BtoA(n - 1);
                    BtoC(1);
                    AtoC(n - 1);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop = true;
        }

        private void seeAllSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop = true;
            Thread t = new Thread(new ThreadStart(ShowStatistic));
            t.IsBackground = true;
            t.Start();
            
        }

        private void ShowStatistic()
        {
            while (!Finish)
            {
                Thread.Sleep(500);
            }
            pictureBox1.Image = BitmapGenerator.GenerateHanoiTower(new int[0], new int[0], new int[0], pallete);
            int pow;
            for(int i = 1; i <=8;i++ )
            {
                pow = (int)Math.Pow(2, i);
                pow--;
                pictures[i - 1].Image = BitmapGenerator.GenerateNumberImage(pictures[i - 1].Width, pictures[i - 1].Height, pow);
            }
        }
    }
}