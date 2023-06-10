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
           CellBL c = mazeGrid.findPacman();
            c.setValue(' ');
        }
        public void draw()
        {

        }
        public void move()
        {

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeft(X, Y);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {

                moveRight(X, Y);
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp(X, Y);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {

                moveDown(X, Y);
            }
        }
        public void moveUp(CellBL current,CellBL next)
        {

        }
        public void moveDown(CellBL current, CellBL next)
        {

        }
        public void moveRight(CellBL current, CellBL next)
        {

        }
        public void moveLeft(CellBL current, CellBL next)
        {

        }

        public void printScore()
        {

        }
    }
}
