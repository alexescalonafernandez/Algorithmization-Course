using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace BishopShow
{
    public partial class Form1 : Form
    {
        object stopLock = new object();
        object finishLock = new object();
        bool[,] cellColor;
        Panel[,] board;
        bool[] mark;
        int maxCol, solutions;
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

        public Form1()
        {
            InitializeComponent();
            cellColor = new bool[8, 8];
            board = new Panel[8, 8];
            mark = new bool[8];
            finish = true;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            bool color = true;
            Panel p;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    p = new Panel();
                    p.Bounds = new Rectangle(j * 60, i * 60, 60, 60);
                    p.BackgroundImage = BitmapGenerator.GenerateDiasbleChessCellBoardImage(60, 60);
                    boardPanel.Controls.Add(p);
                    cellColor[i, j] = color;
                    board[i, j] = p;
                    color = !color;
                }
                color = !color;
                p = new Panel();
                p.Bounds = new Rectangle(0, i * 60, 100, 60);
                p.BorderStyle = BorderStyle.FixedSingle;
                p.BackgroundImage = BitmapGenerator.GenerateChessCellBoardImage(true, 100, 60);
                statisticPanel.Controls.Add(p);
            }
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    board[i, j].BackgroundImage = BitmapGenerator.GenerateDiasbleChessCellBoardImage(60, 60);
                mark[i] = false;
                statisticPanel.Controls[i].BackgroundImage = BitmapGenerator.GenerateChessCellBoardImage(true, 100, 60);
            }
        }

        private void EnableCells(int dimension)
        {
            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                    board[i, j].BackgroundImage = BitmapGenerator.GenerateChessCellBoardImage(cellColor[i, j], 60, 60);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Bishop Exercise - Generating Solutions";
            startToolStripMenuItem.Enabled = false;
            Stop = false;
            Finish = false;
            ResetBoard();
            for (int i = 0; i < 8 && !Stop; i++)
            {
                maxCol = i + 1;
                solutions = 0;
                EnableCells(maxCol);
                for (int j = 0; j < maxCol&&!Stop; j++)
                {
                    board[maxCol - 1, j].BackgroundImage = BitmapGenerator.GenerateBishopCellImage(60, 60, cellColor[maxCol - 1, j]);
                    Application.DoEvents();
                    Thread.Sleep(100);
                    solutions++;
                    statisticPanel.Controls[maxCol - 1].BackgroundImage = BitmapGenerator.GenerateNumberImage(100, 60, solutions);
                    Application.DoEvents();
                    Thread.Sleep(100);
                    MarkCells(maxCol - 1, j);
                }
                if (i > 1)
                {
                    for (int j = 1; j < maxCol -1 && !Stop; j++)
                    {
                        board[0, j].BackgroundImage = BitmapGenerator.GenerateBishopCellImage(60, 60, cellColor[0, j]);
                        Application.DoEvents();
                        Thread.Sleep(100);
                        solutions++;
                        statisticPanel.Controls[maxCol - 1].BackgroundImage = BitmapGenerator.GenerateNumberImage(100, 60, solutions);
                        Application.DoEvents();
                        Thread.Sleep(100);
                        MarkCells(0, j);
                    }
                }
            }
            startToolStripMenuItem.Enabled = true;
            Finish = true;
            Text = "Bishop Exercise";
        }

        private void MarkCells(int row, int col)
        {
            int[] rincrement = new int[] { 1, 1, -1, -1 };
            int[] cincrement = new int[] { 1, -1, 1, -1 };
            int r, c;
            for (int i = 0; i < 4 && !Stop; i++)
            {
                r = row;
                c = col;
                while (ValidCell(r + rincrement[i], c + cincrement[i]) && !Stop)
                {
                    r += rincrement[i];
                    c += cincrement[i];
                    board[r, c].BackgroundImage = BitmapGenerator.GenerateXImage(60, 60, cellColor[r, c]);
                    Application.DoEvents();
                    Thread.Sleep(250);
                }
            }
        }

        private bool ValidCell(int row, int col)
        {
            return row >= 0 && row < maxCol && col >= 0 && col < maxCol;
        }

        private void seeSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Finish)
                Text = "Bishop Exercise - Stoping Generating Solutions";
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
            Text = "Bishop Exercise";
            ResetBoard();
            int[] solutions = new int[9];
            solutions[1] = 1;
            solutions[2] = 2;
            for (int i = 3; i < 9; i++)
                solutions[i] = i + (i - 2);
            for (int i = 0; i < 8; i++)
                statisticPanel.Controls[i].BackgroundImage = BitmapGenerator.GenerateNumberImage(100, 60, solutions[i + 1]);
        }
    }
}