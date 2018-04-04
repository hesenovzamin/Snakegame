using System;
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
        public List<Button> SnakeLeght = new List<Button>();
        public Button Snake;
        public Button Meal;
        public int Left = 0;
        public int Top = 40;
        public Form1()
        {
            InitializeComponent();
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
        private void Snake_KeyUp(object sender,KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Right)
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
                    int AS = this.Width % 40;
                    AB = this.Width - AS;
                    SnakeLeght[SnakeLeght.Count - 1].Width = AB - 80;
                }
                if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
                {
                    Snake = new Button();
                    Snake.Width = 40;
                    Snake.Height = 40;
                    Snake.BackColor = Color.Green;
                    Snake.Left = SnakeLeght[SnakeLeght.Count-1].Left+40;
                    Snake.FlatStyle = FlatStyle.Flat;
                    Snake.Top = SnakeLeght[SnakeLeght.Count - 1].Top;
                    this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                    Controls.Add(Snake);
                    SnakeLeght.Add(Snake);
                    Meal.Hide();
                    Meals();
                }
                for (int i = 0; i < SnakeLeght.Count-1; i++)
                {
                    if (SnakeLeght[SnakeLeght.Count - 1].Top ==SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                    {
                        MessageBox.Show("Lose");
                        this.Hide();
                    }
                }

            }
            if (e.KeyCode == Keys.Left)
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
                if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
                {
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
                for (int i = 0; i < SnakeLeght.Count-1; i++)
                {
                    if (SnakeLeght[SnakeLeght.Count - 1].Top == SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                    {
                        MessageBox.Show("Lose");
                        this.Hide();
                    }
                }
            }
            if (e.KeyCode == Keys.Up)
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
                if (SnakeLeght[SnakeLeght.Count-1].Top < 0)
                {
                    int AB;
                    int AS = this.Height%40;
                    AB = this.Height - AS;
                    SnakeLeght[SnakeLeght.Count - 1].Top = AB-80;
                }
                if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
                {
                    Snake = new Button();
                    Snake.Width = 40;
                    Snake.Height = 40;
                    Snake.BackColor = Color.Green;
                    Snake.Left = SnakeLeght[SnakeLeght.Count - 1].Left;
                    Snake.FlatStyle = FlatStyle.Flat;
                    Snake.Top = SnakeLeght[SnakeLeght.Count - 1].Top-40;
                    this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                    Controls.Add(Snake);
                    SnakeLeght.Add(Snake);
                    Meal.Hide();
                    Meals();
                }
                for (int i = 0; i < SnakeLeght.Count-1; i++)
                {
                    if (SnakeLeght[SnakeLeght.Count - 1].Top == SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                    {
                        MessageBox.Show("Lose");
                        this.Hide();
                    }
                }
            }
            if (e.KeyCode == Keys.Down)
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
                    SnakeLeght[SnakeLeght.Count - 1].Top = 40;
                }

                if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
                {
                    Snake = new Button();
                    Snake.Width = 40;
                    Snake.Height = 40;
                    Snake.BackColor = Color.Green;
                    Snake.Left = SnakeLeght[SnakeLeght.Count - 1].Left;
                    Snake.FlatStyle = FlatStyle.Flat;
                    Snake.Top = SnakeLeght[SnakeLeght.Count - 1].Top+40;
                    this.Snake.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyUp);
                    Controls.Add(Snake);
                    SnakeLeght.Add(Snake);
                    Meal.Hide();
                    Meals();
                }
                for (int i = 0; i < SnakeLeght.Count-1; i++)
                {
                    if (SnakeLeght[SnakeLeght.Count - 1].Top == SnakeLeght[i].Top && SnakeLeght[SnakeLeght.Count - 1].Left == SnakeLeght[i].Left)
                    {
                        MessageBox.Show("Lose");
              
                    }
                }

            }
        }
        void Meals()
        {
            Random rnd = new Random();
            int MealLeft = rnd.Next(0, this.Width/40);
            int MealTop = rnd.Next(0,this.Height/40);
            MealTop = MealTop * 40;
            MealLeft = MealLeft * 40;
            if (MealLeft % 40 == 0 && MealTop % 40 == 0)
            {
                Meal = new Button();
                Meal.Width = 40;
                Meal.Height = 40;
                Meal.BackColor = Color.Red;
                Meal.Left = MealLeft;
                Meal.Top = MealTop;
                Meal.FlatStyle = FlatStyle.Flat;
                Controls.Add(Meal);
            }
            else
            {
                Meals();
            }
            
        }
      
    }
}
