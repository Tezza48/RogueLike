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
            }
        }
    }
}
