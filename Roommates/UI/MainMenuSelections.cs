using Roommates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roommates.UI
{
    public static class MainMenu
    {
        public static void ShowAllRooms(List<Room> rooms)
        {
            foreach (Room r in rooms)
            {
                Console.WriteLine($"{r.Id} - {r.Name} Max Occupancy({r.MaxOccupancy})");
            } 
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
