﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SnakeApp
{
    public partial class Form1 : Form
    {
        public SoundPlayer players = new SoundPlayer();
        public Timer TimerOyun = new Timer();
        public Timer TimerRight = new Timer();
        public Timer TimerLeft = new Timer();
        public Timer TimerUp = new Timer();
        public Timer TimerDown = new Timer();
        public int say = 0;

        public List<Button> SnakeLeght = new List<Button>();
        public Button Snake;
        public Button Meal;
        public int Left = 0;
        public int Top = 40;
        public Form1()
        {
            InitializeComponent();
            players.SoundLocation = "Snake.wav";
            TimerRight.Interval = 200;
            TimerOyun.Interval = 600;
            TimerOyun.Tick += new System.EventHandler(this.TimerOyun_Tick);
            TimerRight.Tick += new System.EventHandler(this.TimerRight_Tick);
            TimerLeft.Interval = 200;
            TimerLeft.Tick += new System.EventHandler(this.TimerLeft_Tick);
            TimerUp.Interval = 200;
            TimerUp.Tick += new System.EventHandler(this.TimerUp_Tick);
            TimerDown.Interval = 200;
            TimerDown.Tick += new System.EventHandler(this.TimerDown_Tick);

            Meals();
            for (int i = 0; i < 6; i++)
            {
                Snake = new Button();
                Snake.Width = 40;
                Snake.Height = 40;
                Snake.BackColor = Color.Green;
                Snake.Left = Left;
                Snake.FlatStyle = FlatStyle.Flat;
                Snake.Top = Top;
                Left += 40;
                this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                Controls.Add(Snake);
                SnakeLeght.Add(Snake);


            }


        }
        private void Snake_KeyUp(object sender, KeyEventArgs e)
        {
            TimerOyun.Start();
            if (e.KeyCode == Keys.Right)
            {
                TimerLeft.Stop();
                TimerUp.Stop();
                TimerDown.Stop();
                TimerRight.Start();



            }
            if (e.KeyCode == Keys.Left)
            {
                TimerLeft.Start();
                TimerUp.Stop();
                TimerDown.Stop();
                TimerRight.Stop();
            }
            if (e.KeyCode == Keys.Up)
            {
                TimerLeft.Stop();
                TimerUp.Start();
                TimerDown.Stop();
                TimerRight.Stop();
            }
            if (e.KeyCode == Keys.Down)
            {
                TimerLeft.Stop();
                TimerUp.Stop();
                TimerDown.Start();
                TimerRight.Stop();

            }
        }
        void Meals()
        {
            say++;
            if (say == 11)
            {
                MessageBox.Show("Aferin");
                this.Hide();
            }
            Random rnd = new Random();
            int MealLeft = rnd.Next(0, this.Width / 40);
            int MealTop = rnd.Next(0, this.Height / 40);
            MealTop = MealTop * 40;
            MealLeft = MealLeft * 40;
                Meal = new Button();
                Meal.Width = 40;
                Meal.Height = 40;
                Meal.BackColor = Color.Red;
                Meal.Left = MealLeft;
                Meal.Top = MealTop;
                Meal.FlatStyle = FlatStyle.Flat;
                Controls.Add(Meal);
           

        }

        private void TimerRight_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                SnakeLeght[i].Top = SnakeLeght[i + 1].Top;
                SnakeLeght[i].Left = SnakeLeght[i + 1].Left;
            }
            int a = 0;
            foreach (var item in SnakeLeght)
            {
                a++;
                if (SnakeLeght.Count == a)
                {
                    item.Left += 40;
                }
            }
            if (SnakeLeght[SnakeLeght.Count - 1].Left > this.Width)
            {
                int AB;
                int AS = this.Height % 40;
                AB = this.Height - AS;
                SnakeLeght[SnakeLeght.Count - 1].Left = 0;
            }
            if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
            {
                players.Play();
                Snake = new Button();
                Snake.Width = 40;
                Snake.Height = 40;
                Snake.BackColor = Color.Green;
                Snake.Left = SnakeLeght[SnakeLeght.Count - 1].Left + 40;
                Snake.FlatStyle = FlatStyle.Flat;
                Snake.Top = SnakeLeght[SnakeLeght.Count - 1].Top;
                this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                Controls.Add(Snake);
                SnakeLeght.Add(Snake);
                Meal.Hide();
                Meals();
            }
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                if (SnakeLeght[SnakeLeght.Count - 1].Top == SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                {
                    MessageBox.Show("Lose");
                    this.Hide();
                    TimerRight.Stop();

                }
            }
        }
        private void TimerLeft_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                SnakeLeght[i].Top = SnakeLeght[i + 1].Top;
                SnakeLeght[i].Left = SnakeLeght[i + 1].Left;
            }
            int a = 0;
            foreach (var item in SnakeLeght)
            {
                a++;
                if (SnakeLeght.Count == a)
                {
                    item.Left -= 40;
                }
            }
            if (SnakeLeght[SnakeLeght.Count - 1].Left < 0)
            {
                int AB;
                int AS = this.Width % 40;
                AB = this.Width - AS;
                SnakeLeght[SnakeLeght.Count - 1].Left = AB - 40;
            }
            if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
            {
                players.Play();
                Snake = new Button();
                Snake.Width = 40;
                Snake.Height = 40;
                Snake.BackColor = Color.Green;
                Snake.Left = SnakeLeght[SnakeLeght.Count - 1].Left - 40;
                Snake.FlatStyle = FlatStyle.Flat;
                Snake.Top = SnakeLeght[SnakeLeght.Count - 1].Top;
                this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                Controls.Add(Snake);
                SnakeLeght.Add(Snake);
                Meal.Hide();
                Meals();
            }
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                if (SnakeLeght[SnakeLeght.Count - 1].Top == SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                {
                    MessageBox.Show("Lose");

                    this.Hide();
                    TimerLeft.Stop();
                }
            }
        }
        private void TimerUp_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                SnakeLeght[i].Top = SnakeLeght[i + 1].Top;
                SnakeLeght[i].Left = SnakeLeght[i + 1].Left;
            }
            int a = 0;
            foreach (var item in SnakeLeght)
            {
                a++;
                if (SnakeLeght.Count == a)
                {
                    item.Top -= 40;
                }
            }
            if (SnakeLeght[SnakeLeght.Count - 1].Top < 0)
            {
                int AB;
                int AS = this.Height % 40;
                AB = this.Height - AS;
                SnakeLeght[SnakeLeght.Count - 1].Top = AB - 40;
            }
            if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
            {
                players.Play();
                Snake = new Button();
                Snake.Width = 40;
                Snake.Height = 40;
                Snake.BackColor = Color.Green;
                Snake.Left = SnakeLeght[SnakeLeght.Count - 1].Left;
                Snake.FlatStyle = FlatStyle.Flat;
                Snake.Top = SnakeLeght[SnakeLeght.Count - 1].Top - 40;
                this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                Controls.Add(Snake);
                SnakeLeght.Add(Snake);
                Meal.Hide();
                Meals();
            }
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                if (SnakeLeght[SnakeLeght.Count - 1].Top == SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                {
                    MessageBox.Show("Lose");
                    this.Hide();

                    TimerUp.Stop();
                }
            }
        }
        private void TimerDown_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                SnakeLeght[i].Top = SnakeLeght[i + 1].Top;
                SnakeLeght[i].Left = SnakeLeght[i + 1].Left;
            }
            int a = 0;
            foreach (var item in SnakeLeght)
            {
                a++;
                if (SnakeLeght.Count == a)
                {
                    item.Top += 40;
                }
            }
            if (SnakeLeght[SnakeLeght.Count - 1].Top > this.Height)
            {
                int AB;
                int AS = this.Height % 40;
                AB = this.Height - AS;
                SnakeLeght[SnakeLeght.Count - 1].Top = 0;
            }

            if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
            {
                players.Play();
                Snake = new Button();
                Snake.Width = 40;
                Snake.Height = 40;
                Snake.BackColor = Color.Green;
                Snake.Left = SnakeLeght[SnakeLeght.Count - 1].Left;
                Snake.FlatStyle = FlatStyle.Flat;
                Snake.Top = SnakeLeght[SnakeLeght.Count - 1].Top + 40;
                this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                Controls.Add(Snake);
                SnakeLeght.Add(Snake);
                Meal.Hide();
                Meals();
            }
            for (int i = 0; i < SnakeLeght.Count - 1; i++)
            {
                if (SnakeLeght[SnakeLeght.Count - 1].Top == SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                {
                    MessageBox.Show("Lose");
                    this.Hide();

                }
            }
        }
        public static int a = 0;
        public static int Deq = 0;
        private void TimerOyun_Tick(object sender, EventArgs e)
        {

            a++;
            if (a == 60)
            {
                Deq++;
                a = 0;
            }
            if (Deq==3)
            {
                TimerLeft.Stop();
                TimerUp.Stop();
                TimerDown.Stop();
                TimerRight.Stop();
                TimerOyun.Stop();
                MessageBox.Show("Oyun bitdi qaqa");
               
                this.Hide();
            }
            label1.Text = "0" + Deq.ToString() + ":" + a.ToString();
        }
    }
}
