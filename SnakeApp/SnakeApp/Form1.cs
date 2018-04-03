using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeApp
{
    public partial class Form1 : Form
    {
        public List<Button> SnakeLeght = new List<Button>();
        public Button Snake;
        public Button Meal;
        public int Left = 0;
        public int Top = 30;
        public Form1()
        {
            InitializeComponent();
            Meals();
            for (int i = 0; i < 3; i++)
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
                if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
                {
                    Snake.BackColor = Color.Red;
                    Meal.Hide();
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
                    Snake.BackColor = Color.Red;
                    Meal.Hide();
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
                if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
                {
                    Snake.BackColor = Color.Red;
                    Meal.Hide();
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
                if ((Snake.Top == Meal.Top) && (Snake.Left == Meal.Left))
                {
                    Snake.BackColor = Color.Red;
                    Meal.Hide();
                }

            }
        }
        void Meals()
        {
            Random rnd = new Random();
            int MealLeft = rnd.Next(0, this.Width);
            int MealTop = rnd.Next(0,this.Height);
            Meal = new Button();
            Meal.Width = 40;
            Meal.Height = 30;
            Meal.BackColor = Color.Red;
            Meal.Left = MealLeft;
            Meal.Top = MealTop;
            Meal.FlatStyle = FlatStyle.Flat;
            Controls.Add(Meal);
        }
    }
}
