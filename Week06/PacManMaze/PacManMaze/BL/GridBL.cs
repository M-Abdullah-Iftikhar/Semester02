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
        public GridBL(int rowSize, int columnSize, string path)
        {
            this.rowSize = rowSize;
            this.columnSize = columnSize;
            maze = new CellBL[rowSize, columnSize];
            constructMaze(rowSize, columnSize);

        }

        private CellBL[,] maze;
        int rowSize;
        int columnSize;

        public  void constructMaze(int rowSize, int columnSize)
        {
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < columnSize; y++)
                {
                    char a;
                    if (x == 0 || x == (rowSize - 1) || y == 0 || y == (columnSize - 1))
                    {
                        a = '#';
                    }
                    else
                    {
                        a = ' ';
                    }
                    CellBL c = new CellBL(a,x,y);
                    maze[x, y] = c;
                }
            }
        }

       
        public  void setCellInMaze(int X,int Y,CellBL c)
        {
            maze[Y, X] = c;
        }
        public CellBL getCellFromMaze(int X, int Y)
        {
            return this.maze[Y, X];
        }
        public CellBL getLeftCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return this.maze[Y, X - 1];
        }
        public CellBL getRightCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return this.maze[Y, X + 1];
        }
        public  CellBL getUpCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return this.maze[Y - 1, X];
        }
        public CellBL getDownCell(CellBL c)
        {
            int X = c.getX();
            int Y = c.getY();
            return maze[Y + 1, X];
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
