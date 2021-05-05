using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace EratosthenesSieveShow
{
    public partial class Form1 : Form
    {
        Panel[,] board;
        Pen[] pallete;
        Color[] palleteColor;
        public Form1()
        {
            InitializeComponent();
            board = new Panel[12, 11];
            palleteColor = new Color[] { Color.Blue, Color.Red, Color.Green, Color.Yellow, Color.Orange };
            pallete = new Pen[palleteColor.Length];
            for (int i = 0; i < palleteColor.Length; i++)
                pallete[i] = new Pen(palleteColor[i], 4);
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Panel p;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 11; j++)
                {
                    p = new Panel();
                    p.Dock = DockStyle.Fill;
                    //p.BackgroundImage = BitmapGenerator.GenerateNumberImage(40, 40, i * 11 + j + 1, boardPanel.Margin.Left, Color.White, true);
                    
                    p.BackgroundImage = BitmapGenerator.GenerateDiasbleChessCellBoardImage(40, 40);
                    boardPanel.Controls.Add(p, j, i);
                    board[i, j] = p;
                }
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 11; j++)
                    board[i, j].BackgroundImage = BitmapGenerator.GenerateNumberImage(40, 40, i * 11 + j + 1, boardPanel.Margin.Left, Color.White,Pens.Black, false);
            board[0,0].BackgroundImage = BitmapGenerator.GenerateDiasbleChessCellBoardImage(40, 40);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetBoard();
            bool[] composites = new bool[133];
            int colorPtr = -1;
            for(int i = 2; i < 12; i++)
                if (!composites[i])
                {
                    colorPtr++;
                    DrawNumber(i, Color.White,pallete[colorPtr], true);
                    for (int j = i+i; j < composites.Length; j += i)
                    {
                        if (!composites[j])
                        {
                            DrawNumber(j, palleteColor[colorPtr], pallete[colorPtr], false);
                            composites[j] = true;
                        }
                    }
                    //DrawNumber(i, Color.White,pallete[colorPtr], false);
                }
        }

        private void DrawNumber(int number, Color background, Pen drawColor, bool drawRectangle)
        {
            int n = number - 1;
            int column = n % 11;
            int row = (n - column) / 11;
            board[row, column].BackgroundImage = BitmapGenerator.GenerateNumberImage(40, 40, number, boardPanel.Margin.Left, background, drawColor, drawRectangle);
            Application.DoEvents();
            Thread.Sleep(200);
        }
    }
}