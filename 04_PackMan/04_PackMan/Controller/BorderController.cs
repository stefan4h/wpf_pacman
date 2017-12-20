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
        List<Direction> validDirections;

        public BorderController(List<Shape> borders)
        {
            this.borders = borders;
            validDirections = new List<Direction>();
        }

        public List<Direction> GetValidDirections(Ellipse enemie)
        {
            validDirections.Clear();    
            double x = Canvas.GetLeft(enemie);
            double y = Canvas.GetTop(enemie);

            double xBox = 0;
            double yBox = 0;
            bool isBoxUp = false;
            bool isBoxDown = false;
            bool isBoxLeft = false;
            bool isBoxRight = false;

            foreach (Shape box in borders)
            {
                xBox = Canvas.GetLeft(box);
                yBox = Canvas.GetTop(box);
                if (xBox.Equals(Double.NaN))
                    xBox = 0;
                if (yBox.Equals(Double.NaN))
                    yBox = 0;

                if (xBox == x && yBox == y - 25)
                {
                    isBoxUp = true;
                }
                else if (xBox == x && Canvas.GetTop(box) == y + 25)
                {
                    isBoxDown = true;
                }
                else if(xBox == x - 25 && yBox == y)
                {
                    isBoxLeft = true;
                }
                else if (xBox == x + 25 && yBox == y)
                {
                    isBoxRight = true;
                }

                
            }
            if (!isBoxUp)
                validDirections.Add(Direction.up);
            if (!isBoxDown)
                validDirections.Add(Direction.down);
            if (!isBoxLeft)
                validDirections.Add(Direction.left);
            if (!isBoxRight)
                validDirections.Add(Direction.right);
           

            return validDirections;
        }

    }
}
