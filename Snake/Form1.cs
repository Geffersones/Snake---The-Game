using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        int max_X_pos;
        int max_Y_pos;

        public Form1()
        {
            InitializeComponent();

            new Settings();

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            max_X_pos = pbCanvas.Size.Width / Settings.Width;
            max_Y_pos = pbCanvas.Size.Height / Settings.Height;

            StartGame();
        }

        private void StartGame()
        {
            lblGameOverfc.Visible = false;
            new Settings(); //Settings reset
            Snake.Clear();
            Circle head = new Circle();
            Random random = new Random();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);
            label1.Text = Settings.Score.ToString();
            GenerateFood();
        }
        private void GenerateFood()
        {
            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, max_X_pos);
            food.Y = random.Next(0, max_Y_pos);
        }
        private void UpdateScreen(object sender, EventArgs e)
        {

        }
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (!Settings.GameOver)
            {
                Brush snakeColor;
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColor = Brushes.Red;
                    }
                    else
                    {
                        snakeColor = Brushes.Green;
                    }
                    canvas.FillEllipse(snakeColor,
                   new Rectangle(Snake[i].X * Settings.Width,
                                 Snake[i].Y * Settings.Height,
                                 Settings.Width,
                                 Settings.Height));
                }
                canvas.FillEllipse(Brushes.Brown,
                   new Rectangle(food.X * Settings.Width,
                                 food.Y * Settings.Height,
                                 Settings.Width,
                                 Settings.Height));
            }
        }
        private void MovePlayer()
        {

        }
        private void Die()
        {
            Settings.GameOver = true;
        }
        private void Eat()
        {
            Circle eaten_food = new Circle();
            eaten_food.X = Snake[Snake.Count - 1].X;
            eaten_food.Y = Snake[Snake.Count - 1].Y;
            Snake.Add(eaten_food);
            Settings.Score += Settings.Points;
            label1.Text = Settings.Score.ToString();
            GenerateFood();
        }
    }
}

