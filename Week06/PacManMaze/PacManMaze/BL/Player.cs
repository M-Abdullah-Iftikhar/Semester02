using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace PacManMaze.BL
{
    class Player
    {
        public Player(int X,int Y,GridBL mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.mazeGrid = mazeGrid;
        }

        int X;
        int Y;
        int score;
        GridBL mazeGrid;

       
        public void remove()
        {
            CellBL c = new CellBL(' ', X, Y);
            mazeGrid.setCellInMaze(X, Y,c);
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public void draw()
        {
            CellBL c = new CellBL('P', X, Y);
            mazeGrid.setCellInMaze(X, Y, c);
            Console.SetCursorPosition(X, Y);
            Console.Write('P');
        }
        public void move()
        {
            CellBL curent = mazeGrid.getCellFromMaze(X,Y);
            

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                CellBL next = mazeGrid.getLeftCell(curent);
                moveLeft(curent, next);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                CellBL next = mazeGrid.getRightCell(curent);
                moveRight(curent, next);
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                CellBL next = mazeGrid.getUpCell(curent);
                moveUp(curent, next);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                CellBL next = mazeGrid.getDownCell(curent);
                moveDown(curent, next);
            }
        }
        public void moveUp(CellBL current,CellBL next)
        {
            if(next.getValue() == ' ')
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

        public void printScore()
        {
            Console.SetCursorPosition(100, 3);
            Console.Write("Score is: " + score);
        }
    }
}
