using System;
using System.Collections.Generic;
using Roommates.Repositories;
using Roommates.UI;

namespace Roommates
{
    public class Program
    {
        //  This is the address of the database.
        //  We define it here as a constant since it will never change.
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            // Get the connection string to allow our methods to use the database
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);
            ChoreRepository choreRepo = new ChoreRepository(CONNECTION_STRING);       

            bool runProgram = true;
            while (runProgram)
            {
                string selection = MainMenu.GetSelections();

                switch (selection)
                {
                    case ("Show all rooms"):                   
                        MainMenu.ShowAll(roomRepo.GetAll());
                        break;
                    case ("Search for room"):
                        MainMenu.SearchForRoom(roomRepo);
                        break;
                    case ("Add room"):
                        MainMenu.AddRoom(roomRepo);
                        break;
                    case ("Show all chores"):
                        MainMenu.ShowAll(choreRepo.GetAll());
                        break;
                    case ("Search for chore"):

                        break;
                    case ("Add chore"):

                        break;
                    case ("Exit"):
                        runProgram = false;
                        break;
                }
            }
        }
    }
}
