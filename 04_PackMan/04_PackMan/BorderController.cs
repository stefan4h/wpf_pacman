using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _04_PackMan
{
    class BorderController
    {
        public List<Shape> borders;

        public BorderController(List<Shape> borders)
        {
            this.borders = borders;
        }

        public bool IsBorderLeft(Ellipse e)
        {
            double x = Canvas.GetLeft(e);
            double y = Canvas.GetTop(e);

            foreach (Shape block in borders)
            {
                if (x == Canvas.GetLeft(block) + 25)   
                {
                    if (y == Canvas.GetTop(block) + 25)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public bool IsBorderRight(Ellipse e)
        {
            double x = Canvas.GetLeft(e);
            double y = Canvas.GetTop(e);

            foreach (Shape block in borders)
            {
                if (x == Canvas.GetLeft(block) + 25)
                {
                    if (y == Canvas.GetTop(block) - 25)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsBorderTop(Ellipse e)
        {
            double x = Canvas.GetLeft(e);
            double y = Canvas.GetTop(e);

            foreach (Shape block in borders)
            {
                if (x == Canvas.GetLeft(block))
                {
                    if (y == Canvas.GetTop(block) - 25)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsBorderBottom(Ellipse e)
        {
            double x = Canvas.GetLeft(e);
            double y = Canvas.GetTop(e);

            foreach (Shape block in borders)
            {
                if (x == Canvas.GetLeft(block))
                {
                    if (y == Canvas.GetTop(block) - 25)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public List<Direction> GetValidDirections(KeyValuePair<Ellipse, Direction> enemie)
        {

            List<Direction> validDirections = new List<Direction>();

            switch (enemie.Value)
            {
                case Direction.down:

                    if (!this.IsBorderLeft(enemie.Key))
                    {
                        validDirections.Add(Direction.left);
                    }

                    if (!this.IsBorderRight(enemie.Key))
                    {
                        validDirections.Add(Direction.right);
                    }

                    if (!this.IsBorderBottom(enemie.Key))
                    {
                        validDirections.Add(Direction.down);
                    }

                    break;
                case Direction.up:
                    if (!this.IsBorderTop(enemie.Key))
                    {
                        validDirections.Add(Direction.up);
                    }

                    if (!this.IsBorderLeft(enemie.Key))
                    {
                        validDirections.Add(Direction.left);
                    }

                    if (!this.IsBorderRight(enemie.Key))
                    {
                        validDirections.Add(Direction.right);
                    }

                    break;
                case Direction.right:

                    if (!this.IsBorderTop(enemie.Key))
                    {
                        validDirections.Add(Direction.up);
                    }

                    if (!this.IsBorderBottom(enemie.Key))
                    {
                        validDirections.Add(Direction.down);
                    }

                    if (!this.IsBorderRight(enemie.Key))
                    {
                        validDirections.Add(Direction.right);
                    }
                    break;
                case Direction.left:

                    if (!this.IsBorderTop(enemie.Key))
                    {
                        validDirections.Add(Direction.up);
                    }

                    if (!this.IsBorderBottom(enemie.Key))
                    {
                        validDirections.Add(Direction.down);
                    }

                    if (!this.IsBorderLeft(enemie.Key))
                    {
                        validDirections.Add(Direction.left);
                    }

                    break;
            }

            return validDirections;
        }

    }
}
