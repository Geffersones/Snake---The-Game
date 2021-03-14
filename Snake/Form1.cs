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
            head.X = random.Next(0, max_X_pos);
            head.Y = random.Next(0, max_Y_pos);
            Snake.Add(head);
            label1.Text = Settings.Score.ToString();
            GenerateFood();
        }
        private void GenerateFood()
        {
            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, max_Y_pos); //Это так и задумано
            food.Y = random.Next(0, max_X_pos); //Это так и задумано
        }
        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver)
            {
                if (Input.keyPressed(Keys.Enter))
                    StartGame();
            }
            else
            {
                if (Input.keyPressed(Keys.D) && Settings.direction != Direction.Right)
                {
                    Settings.direction = Direction.Left;
                }
                else if (Input.keyPressed(Keys.A) && Settings.direction != Direction.Left)
                {
                    Settings.direction = Direction.Right;
                }
                else if (Input.keyPressed(Keys.W) && Settings.direction != Direction.Down)
                {
                    Settings.direction = Direction.Up;
                }
                else if (Input.keyPressed(Keys.S) && Settings.direction != Direction.Up)
                {
                    Settings.direction = Direction.Down;
                }

                MovePlayer();
            }

            pbCanvas.Invalidate();
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
                        snakeColor = Brushes.LightGreen;
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
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                        case Direction.Right:
                            Snake[i].X--;
                            break;
                        case Direction.Left:
                            Snake[i].X++;
                            break;
                    }
                    if (Snake[i].X > max_X_pos || Snake[i].X < 0 || Snake[i].Y > max_Y_pos || Snake[i].Y < 0)
                        Die();

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[0].X == Snake[j].X && Snake[0].Y == Snake[j].Y)
                        {
                            Die();
                            break;
                        }
                    }
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                        Eat();


                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
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
            Settings.Speed++;
            gameTimer.Interval = 1000 / Settings.Speed;
            GenerateFood();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}

