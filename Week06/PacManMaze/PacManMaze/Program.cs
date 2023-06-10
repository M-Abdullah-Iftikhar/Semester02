using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PacManMaze.BL;

namespace PacManMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\Study\\OOP\\Week06\\PacManMaze\\Maze.txt";

            GridBL mazeGrid = new GridBL(24, 71, path);

            Player player = new Player(9, 32, mazeGrid);
            Ghost ghost1 = new Ghost(15, 39, 'H', "Left", 0.1F, ' ', mazeGrid);
            Ghost ghost2 = new Ghost(20, 57, 'V', "Up", 0.2F, ' ', mazeGrid);
            Ghost ghost3 = new Ghost(19, 26, 'R', "Up", 1F, ' ', mazeGrid);
            Ghost ghost4 = new Ghost(18, 21, 'C', "Up", 0.5F, ' ', mazeGrid);

            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            enemies.Add(ghost3);
            enemies.Add(ghost4);

            mazeGrid.draw();
            player.draw();

            bool gameRunning = true;

            while(gameRunning)
            {
                Thread.Sleep(50);
                player.printScore();
                player.remove();
                player.move();
                player.draw();

                foreach(Ghost g in enemies)
                {
                    g.remove();
                    g.move();
                    g.draw();
                }

                if(mazeGrid.isStoppingCondition())
                {
                    gameRunning = false;

                }
            }
            Console.ReadKey();


        }
    }
}
