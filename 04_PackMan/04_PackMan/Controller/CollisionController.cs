using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _04_PackMan
{
    class CollisionController
    {
        private Dictionary<Ellipse,Direction> enemieList;


        public CollisionController(Dictionary<Ellipse, Direction> _enemieList)
        {
            enemieList = _enemieList;
        }


        public bool HasCrashed(Ellipse pacman)
        {
            double x = Canvas.GetLeft(pacman);
            double y = Canvas.GetTop(pacman);

            double xEnem = 0;
            double yEnem = 0;

            foreach (KeyValuePair<Ellipse, Direction> enemie in enemieList)
            {
                xEnem = Canvas.GetLeft(enemie.Key);
                yEnem = Canvas.GetTop(enemie.Key);
                if (xEnem.Equals(Double.NaN))
                    xEnem = 0;
                if (yEnem.Equals(Double.NaN))
                    yEnem = 0;

                for (int i = 0; i < 25; i++)
                {
                    for (int k = 0; k < 25; k++)
                    {
                        if (x == (xEnem + i) && y == (yEnem + k))
                            return true;
                    }
                }
                for (int i = 25; i > -1; i--)
                {
                    for (int k = 25; k > -1; k--)
                    {
                        if (x == (xEnem - i) && y == (yEnem - k))
                            return true;
                    }
                }

            }
            return false;
        }
    }
 }

