using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManMaze.BL
{
    class Ghost
    {
        public Ghost (int X,int Y, char ghostChar, string ghostDirection,float speed,char previousItem,GridBL mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.ghostDirection = ghostDirection;
            this.ghostChar = ghostChar;
            this.speed = speed;
            this.previousItem = previousItem;
            this.mazeGrid = mazeGrid;

        }
        public int X;
        public int Y;
        public string ghostDirection;
        public char ghostChar;
        public float speed;
        public char previousItem;
        public float deltaChange;
        public GridBL mazeGrid;
    
        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
        public string getDirection()
        {
            return ghostDirection;
        }

        public void remove()
        {
            CellBL c = new CellBL(' ', X, Y);
            mazeGrid.setCellInMaze(X, Y, c);
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public void draw()
        {
            CellBL c = new CellBL('H', X, Y);
            mazeGrid.setCellInMaze(X, Y, c);
            Console.SetCursorPosition(X, Y);
            Console.Write('H');
        }

        public char getCharacter()
        {
            return ghostChar;
        }

        public void changeDelta()
        {
            deltaChange = deltaChange + speed;
        }
        public float getDelta()
        {
            return deltaChange;
        }
        public void setDeltaZero()
        {
            deltaChange = 0;
        }


        public void move()
        {
            changeDelta();

            if(Math.Floor(getDelta()) == 1)
            {
                if(ghostChar == 'H')
                {
                    moveHorizontal();
                }
                else 
                {
                    moveVertical();
                }
                setDeltaZero();
            }
        }

        public void moveUp(CellBL current, CellBL next)
        {
            if (next.getValue() == ' ')
            {
                this.Y = Y - 1;
            }

        }
        public void moveDown(CellBL current, CellBL next)
        {
            if (next.getValue() == ' ')
            {
                this.Y = Y + 1;
            }
        }
        public void moveRight(CellBL current, CellBL next)
        {
            if (next.getValue() == ' ')
            {
                this.X = X + 1;
            }
        }
        public void moveLeft(CellBL current, CellBL next)
        {
            if (next.getValue() == ' ')
            {
                this.X = X - 1;
            }
        }


        public void moveHorizontal()
        {
            CellBL curent = mazeGrid.getCellFromMaze(X, Y);
            if (ghostDirection == "Left")
            {
                CellBL next = mazeGrid.getLeftCell(curent);
                moveLeft(curent, next);
                if (next.getValue() != ' ')
                {
                    ghostDirection = "Right";
                }
            }
            else if (ghostDirection == "Right")
            {
                CellBL next = mazeGrid.getRightCell(curent);
                moveRight(curent, next);
                if (next.getValue() != ' ')
                {
                    ghostDirection = "Left";
                }
            }
        }

        public void moveVertical()
        {
            CellBL curent = mazeGrid.getCellFromMaze(X, Y);
            if (ghostDirection == "Up")
            {
                CellBL next = mazeGrid.getUpCell(curent);
                moveUp(curent, next);
                if (next.getValue() != ' ')
                {
                    ghostDirection = "Down";
                }
            }
            else if (ghostDirection == "Down")
            {
                CellBL next = mazeGrid.getDownCell(curent);
                moveDown(curent, next);
                if (next.getValue() != ' ')
                {
                    ghostDirection = "Up";
                }
            }
        }
    }
}
