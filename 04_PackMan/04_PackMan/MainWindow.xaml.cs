using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _04_PackMan
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 
    public enum Direction { up , down, left, right };
    public partial class MainWindow : Window
    {

        DispatcherTimer timer;
        Dictionary<Ellipse, Direction> enemies;
        List<Shape> borders = new List<Shape>();
        BorderController borderController;
        int counter;
        int generateCounter;

        public MainWindow()
        {
            InitializeComponent();
            enemies = new Dictionary<Ellipse, Direction>();
            timer = new DispatcherTimer();
            generateCounter = 0;


            counter = 0;



            ReadAllBoxes();
            borderController = new BorderController(borders);
            GenerateEnemie();

            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += new EventHandler(MoveEnemies);
            timer.Start();

        }

        public void GenerateEnemie()
        {
            timer.Stop();
            if (!timer.IsEnabled)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Name = "Enemie" + enemies.Count;
                ellipse.Fill = Brushes.Red;
                ellipse.Height = 25;
                ellipse.Width = 25;
                Canvas.SetLeft(ellipse, 225);
                Canvas.SetTop(ellipse, 100);
                boxes.Children.Add(ellipse);

                enemies.Add(ellipse, Direction.down);
            }
            timer.Start();
        }

        public void MoveEnemies(object sender, EventArgs e)
        {

            bool checkValidDirection = false;
            if (generateCounter == 400)
            {
                GenerateEnemie();
                generateCounter = 0;
            }
            generateCounter++;
            if (counter == 25)
            {
                counter = 0;
                checkValidDirection = true;
            }
            counter++;

            Dictionary<Ellipse, Direction> currentEnemies = new Dictionary<Ellipse, Direction>();
            List<Direction> validDirections = new List<Direction>();
            Random r = new Random();

            if (checkValidDirection)
            {
                foreach (KeyValuePair<Ellipse, Direction> enemie in enemies)
                {
                    validDirections.Clear();
                    validDirections = borderController.GetValidDirections(enemie.Key);
                    if (validDirections.Count > 1)
                    {
                        if (enemie.Value == Direction.down && validDirections.Contains(Direction.up))
                        {
                            validDirections.Remove(Direction.up);
                        }
                        else if (enemie.Value == Direction.left && validDirections.Contains(Direction.right))
                        {
                            validDirections.Remove(Direction.right);
                        }
                        else if (enemie.Value == Direction.up && validDirections.Contains(Direction.down))
                        {
                            validDirections.Remove(Direction.down);
                        }
                        else if (enemie.Value == Direction.right && validDirections.Contains(Direction.left))
                        {
                            validDirections.Remove(Direction.left);
                        }
                    }
                   
                   
                    int choose = r.Next(0, validDirections.Count);
                    KeyValuePair<Ellipse, Direction> editEnemie = new KeyValuePair<Ellipse, Direction>(enemie.Key, validDirections[choose]);

                    

                    currentEnemies.Add(editEnemie.Key, editEnemie.Value);

                }

                enemies.Clear();

                foreach (KeyValuePair<Ellipse, Direction> enemie in currentEnemies)
                {
                    enemies.Add(enemie.Key, enemie.Value);
                }

                currentEnemies.Clear();
            }

            foreach (KeyValuePair<Ellipse, Direction> enemie in enemies)
            { 
                DoEnemieMove(enemie);
            }

            



        }

        public void DoEnemieMove(KeyValuePair<Ellipse, Direction> enemie)
        {
            switch (enemie.Value)
            {
                case Direction.down: MoveDown(enemie.Key); break;
                case Direction.up: MoveUp(enemie.Key); break;
                case Direction.right: MoveRight(enemie.Key); break;
                case Direction.left: MoveLeft(enemie.Key); break;
            }
        }

        public void MoveUp(Ellipse e)
        {
            Canvas.SetTop(e, Canvas.GetTop(e) - 1);
        }
        public void MoveDown(Ellipse e)
        {
            Canvas.SetTop(e, Canvas.GetTop(e) + 1);
        }
        public void MoveLeft(Ellipse e)
        {
            Canvas.SetLeft(e, Canvas.GetLeft(e) - 1);
        }

        public void MoveRight(Ellipse e)
        {
            Canvas.SetLeft(e, Canvas.GetLeft(e) + 1);
        }

        public void ReadAllBoxes()
        {
            borders.Clear();
            foreach (Shape item in boxes.Children)
            {

                if (item is Ellipse)
                {

                }
                else if (item is Rectangle)
                {
                    borders.Add(item);
                }

            }
        }

    }

}
