using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenWalk
{
    class RogueDungeon
    {
        private Room[,] rooms;

        private const int GRID_SIZE = 3;

        public RogueDungeon ()
        {
            rooms = new Room[GRID_SIZE, GRID_SIZE];
            for (int y = 0; y < GRID_SIZE; y++)
            {
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    rooms[x, y] = new Room();
                }
            }
        }
        // 3 * 3 array of rooms
        // each room has a flagg indicating if its connected
        // pick a random room to start with and mark connected
        // while there are unconnected rooms, try to conect them to a random connected neighbour
        // add n random connections

        // Draw rooms onto map
        // draw corrodors between connected rooms
        // DOOR BIT
        // place stairs up in the first room
        // place stairs down in the last room in step5
    }
}
