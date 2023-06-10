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
            
        }
        public void draw()
        {

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
                    moveHorizontal(mazeGrid);
                }
                setDeltaZero();
            }
        }

        public void moveHorizontal(GridBL mazeGrid)
        {

        }
    }
}
