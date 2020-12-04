using System;
using System.Text;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates.UI
{
    public class MainMenu
    {
        public static int InputNumber()
        {
            int inputNumber;

            while (true)
            {
                try
                {
                    inputNumber = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Not a number. Must enter a number: ");
                }
            }

            return inputNumber;
        }

        public static void InputContinue()
        {
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }

        public static string GetSelections()
        {
            Console.Clear();

            List<string> options = new List<string>()
        {
            "Show all rooms",
            "Search for room",
            "Add room",
            "Show all chores",
            "Search for chore",
            "Add chore",
            "Show all roommates [NOT ADDED]",
            "Search for roommate [NOT ADDED]",
            "Add roommate [NOT ADDED]",
            "Exit"
        };

            for (int i = 0; i < options.Count; i++)
            {
                if (i == 0) Console.WriteLine("Rooms\n------");
                if (i == 3) Console.WriteLine("\nChores\n------");
                if (i == 6) Console.WriteLine("\nRoommates\n------");
                if (i == options.Count - 1) Console.WriteLine(""); 
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

        // Overload for room list
        public static void ShowAll(List<Room> rooms)
        {
            foreach (Room r in rooms)
            {
                Console.WriteLine($"{r.Id} - {r.Name} - Max Occupancy: {r.MaxOccupancy}");
            }
            InputContinue();
        }

        // Overload for chore list
        public static void ShowAll(List<Chore> chores)
        {
            foreach (Chore c in chores)
            {
                Console.WriteLine($"{c.Id} - {c.Name}");
            }
            InputContinue();
        }

        // Overload for rooms
        public static void SearchById(RoomRepository roomRepo)
        {
            Room room = null;
            room = (Room)GetObjById(room, roomRepo);

            Console.WriteLine($"{room.Id} - {room.Name} Max Occupancy: {room.MaxOccupancy}");
            InputContinue();
        }

        // Overload for chores
        public static void SearchById(ChoreRepository choreRepo)
        {
            Chore chore = null;
            chore = (Chore)GetObjById(chore, choreRepo);

            Console.WriteLine($"{chore.Id} - {chore.Name}");
            InputContinue();
        }

        // Helper method to handle getting the specific object by id from a model
        private static IModel GetObjById(IModel incomingObj, IRepository repo)
        {
            while (incomingObj == null)
            {
                Console.Write("Enter ID: ");
                int id = InputNumber();

                incomingObj = repo.GetById(id);
                if (incomingObj == null) Console.Write("No item with that ID is available. ");
            }

            return incomingObj;
        }

        public static void AddRoom(RoomRepository roomRepo)
        {
            Console.Write("Room name: ");
            string name = Console.ReadLine();

            Console.Write("Max occupancy: ");
            int max = InputNumber();

            Room roomToAdd = new Room()
            {
                Name = name,
                MaxOccupancy = max
            };

            roomRepo.Insert(roomToAdd);

            Console.WriteLine($"{roomToAdd.Name} has been added and assigned an ID of {roomToAdd.Id}");
            InputContinue();
        }

        public static void AddChore(ChoreRepository choreRepo)
        {
            Console.Write("Chore name: ");
            string name = Console.ReadLine();

            Chore choreToAdd = new Chore()
            {
                Name = name
            };

            choreRepo.Insert(choreToAdd);

            Console.WriteLine($"{choreToAdd.Name} has been added and assigned an ID of {choreToAdd.Id}");
            InputContinue();
        }
    }
}
