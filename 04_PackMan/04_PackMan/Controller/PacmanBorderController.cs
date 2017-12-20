using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _04_PackMan
{
    class PacmanBorderController
    {
        public List<Shape> borders;
        bool isBoxUp;
        bool isBoxDown;
        bool isBoxLeft;
        bool isBoxRight;
        Direction newDirection,currentDirection;

        public PacmanBorderController(List<Shape> borders,Direction _CurrentDdirection,Direction _NewDirection)
        {
            this.borders = borders;
            
            currentDirection = _CurrentDdirection;
            newDirection = _NewDirection;
            isBoxUp = true;
            isBoxDown = true;
            isBoxLeft = true;
            isBoxRight = true;
        }

        public Direction GetValidDirections(Ellipse pacman)
        {

            double x = Canvas.GetLeft(pacman);
            double y = Canvas.GetTop(pacman);

            double xBox = 0;
            double yBox = 0;
            if (Canvas.GetLeft(pacman) % 25 == 0 && Canvas.GetTop(pacman) % 25 == 0)
            {
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
                        isBoxUp = false;
                    }
                    else if (xBox == x && Canvas.GetTop(box) == y + 25)
                    {
                        isBoxDown = false;
                    }
                    else if (xBox == x - 25 && yBox == y)
                    {
                        isBoxLeft = false;
                    }
                    else if (xBox == x + 25 && yBox == y)
                    {
                        isBoxRight = false;
                    }


                }
                if (isBoxUp && newDirection == Direction.up)
                    return newDirection;
                else if (isBoxDown && newDirection == Direction.down)
                    return newDirection;
                else if (isBoxLeft && newDirection == Direction.left)
                    return newDirection;
                else if (isBoxRight && newDirection == Direction.right)
                    return newDirection;
                else
                {
                    if (!isBoxUp && newDirection == Direction.up)
                    {
                        if (currentDirection == Direction.up && isBoxUp)
                            return Direction.up;
                        if (currentDirection == Direction.down && isBoxDown)
                            return Direction.down;
                        if (currentDirection == Direction.left && isBoxLeft)
                            return Direction.left;
                        if (currentDirection == Direction.right && isBoxRight)
                            return Direction.right;
                        return Direction.none;
                    }
                    if (!isBoxDown && newDirection == Direction.down)
                    {
                        if (currentDirection == Direction.up && isBoxUp)
                            return Direction.up;
                        if (currentDirection == Direction.down && isBoxDown)
                            return Direction.down;
                        if (currentDirection == Direction.left && isBoxLeft)
                            return Direction.left;
                        if (currentDirection == Direction.right && isBoxRight)
                            return Direction.right;
                        return Direction.none;
                    }
                    if (!isBoxLeft && newDirection == Direction.left)
                    {
                        if (currentDirection == Direction.up && isBoxUp)
                            return Direction.up;
                        if (currentDirection == Direction.down && isBoxDown)
                            return Direction.down;
                        if (currentDirection == Direction.left && isBoxLeft)
                            return Direction.left;
                        if (currentDirection == Direction.right && isBoxRight)
                            return Direction.right;
                        return Direction.none;
                    }
                    if (!isBoxRight && newDirection == Direction.right)
                    {
                        if (currentDirection == Direction.up && isBoxUp)
                            return Direction.up;
                        if (currentDirection == Direction.down && isBoxDown)
                            return Direction.down;
                        if (currentDirection == Direction.left && isBoxLeft)
                            return Direction.left;
                        if (currentDirection == Direction.right && isBoxRight)
                            return Direction.right;
                        return Direction.none;
                    }
                }
                return Direction.none;
            }
            return currentDirection;
        }

    }
}

