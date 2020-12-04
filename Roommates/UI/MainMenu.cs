using Roommates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roommates.UI
{
    public class MainMenu
    {
        public static string GetSelections()
        {
            Console.Clear();

            List<string> options = new List<string>()
        {
            "Show all rooms",
            "Search for room",
            "Add a room",
            "Exit"
        };

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Select an option > ");

                    string input = Console.ReadLine();
                    int index = int.Parse(input) - 1;
                    return options[index];
                }
                catch (Exception)
                {

                    continue;
                }
            }
        }

        public static void ShowAllRooms(List<Room> rooms)
        {
            foreach (Room r in rooms)
            {
                Console.WriteLine($"{r.Id} - {r.Name} Max Occupancy({r.MaxOccupancy})");
            } 
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }

        public static void SearchForRoom()
        {
            int id;

            Console.Write("Room Id: ");
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Write("Not a number. Must enter a number: ");
                id = int.Parse(Console.ReadLine());
            }
        }
    }
}
