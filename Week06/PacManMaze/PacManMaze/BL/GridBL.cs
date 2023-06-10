using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace PacManMaze.BL
{
    class GridBL
    {
        public GridBL(int rowSize,int columnSize,string path)
        {
            this.rowSize = rowSize;
            this.columnSize = columnSize;
            maze = new CellBL[rowSize, columnSize];

        }

        CellBL[,] maze;
        int rowSize;
        int columnSize;

        public CellBL getLeftCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return maze[X, Y - 1];
        }
        public CellBL getRightCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return maze[X, Y + 1];
        }
        public CellBL getUpCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return maze[X - 1, Y];
        }
        public CellBL getDownCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return maze[X + 1, Y];
        }
        public CellBL findPacman()
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y].getValue() == 'P')
                    {
                        return maze[x, y];
                    }
                }
            }
            return null;

        }

        public void draw()
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    
                    char character = maze[x, y].getValue();
                    Console.SetCursorPosition(y, x);
                    Console.Write(character);
                }
                
            }
           
        }
        public bool isStoppingCondition()
        {
            if (Keyboard.IsKeyPressed(Key.Escape))
            {

                return true;
            }
            else
                return false;
        }




    }
}
