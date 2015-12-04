using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DrunkenWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DungeonGeneration dungeon = new DungeonGeneration(16, 16, 32);

            const int INTERVAL = 100;

            while(true)
            {
                dungeon.DrawDungeon();
                Thread.Sleep(INTERVAL);

                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    dungeon.Move(DungeonGeneration.MoveDirection.UP);
                }
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    dungeon.Move(DungeonGeneration.MoveDirection.RIGHT);
                }
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    dungeon.Move(DungeonGeneration.MoveDirection.DOWN);
                }
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    dungeon.Move(DungeonGeneration.MoveDirection.LEFT);
                }
            }
        }
    }
}
