using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DrunkenWalk
{
    class DungeonGeneration
    {
        private int[,] mapGrid;
        private int gridHeight;
        private int gridWidth;
        
        private int emptyCount;

        private int currentX;
        private int currentY;

        private Random rand;

        private bool shouldWalk = true;

        public enum MoveDirection { UP = 0, RIGHT, DOWN, LEFT };

        public DungeonGeneration(int height, int width, int gridToEmpty)
        {
            mapGrid = new int[width, height];
            emptyCount = gridToEmpty;
            gridHeight = height;
            gridWidth = width;

            // Timer timer = new Timer(Walk, this, 0, 500);
            
            rand = new Random();
            // pick a random starting position

            currentX = rand.Next(width);
            currentY = rand.Next(height);
            mapGrid[currentX, currentY] = 1;

            Walk(null);
        }

        public void DrawDungeon()
        {
            Console.Clear();
            for ( int i = 0; i < gridHeight; i++ )
            {
                for ( int j = 0; j < gridWidth; j++)
                {
                    if (i == currentY && j == currentX)
                        Console.Write((char)002);
                    else
                        Console.Write(mapGrid[j, i] == 1 ? " " : "#");
                        
                }
                Console.WriteLine();
            }
        }

        public void Move (MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.UP:
                    if (currentY > 0)
                    {
                        if(mapGrid[currentX, currentY - 1] > 0)
                        currentY--;
                    }
                    break;
                case MoveDirection.RIGHT:
                    if (currentX < gridWidth)
                    {
                        if (mapGrid[currentX + 1, currentY] > 0)
                            currentX++;
                    }
                    break;
                case MoveDirection.DOWN:
                    if (currentY < gridHeight)
                    {
                        if (mapGrid[currentX, currentY + 1] > 0)
                            currentY++;
                    }
                    break;
                case MoveDirection.LEFT:
                    if (currentX > 0)
                    {
                        if (mapGrid[currentX - 1, currentY] > 0)
                            currentX--;
                    }
                    break;
            }
            Console.Beep();
        }

        public void Walk(object state)
        {
            while (shouldWalk)
            {
                bool walked = false;
                // 0: north, 1: east, 2: south, 3: west
                int direction = rand.Next(4);
                switch (direction)
                {
                    case 0:
                        if (currentY > 0)
                        {
                            currentY--;
                            walked = true;
                        }
                        break;
                    case 1:
                        if ( currentX < gridWidth-1 )
                        {
                            currentX++;
                            walked = true;
                        }
                        break;
                    case 2:
                        if ( currentY < gridHeight-1 )
                        {
                            currentY++;
                            walked = true;
                        }
                        break;  
                    case 3:
                        if (currentX > 0)
                        {
                            currentX--;
                            walked = true;
                        }
                        break;
                }

                if ( walked )
                {
                    if ( mapGrid[currentX, currentY] == 0)
                    {
                        mapGrid[currentX, currentY] = 1;
                        emptyCount--;
                    }

                    if (emptyCount == 0)
                        shouldWalk = false;
                }
            }
        }
    }
}
