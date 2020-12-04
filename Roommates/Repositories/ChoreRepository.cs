using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Roommates.Models;

namespace Roommates.Repositories
{
    public class ChoreRepository : BaseRepository
    {
        // When we instantiate ChoreRepository, pass connection string from the base class into it
        public ChoreRepository(string connectionString) : base(connectionString) { }
        
        public List<Chore> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // What's the SQL command we want to run?
                    cmd.CommandText = "SELECT Id, Name FROM Chore";

                    // Execute the SQL in the database and get a "reader" so we can access the data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // create a list to hold the retrieved data
                    List<Chore> chores = new List<Chore>();

                    // while there is data to read, get that data, create a chore object, then add it to the list
                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int nameColumnPosition = reader.GetOrdinal("Name");
                        string nameValue = reader.GetString(nameColumnPosition);

                        // once we have those values, instantiate the new chore object
                        Chore chore = new Chore
                        {
                            Id = idValue,
                            Name = nameValue
                        };

                        chores.Add(chore);
                    }
                    reader.Close();

                    return chores;
                }
            }
        }

        public Chore GetById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Name FROM Chore WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Chore chore = null;

                    // We're only getting a single chore back, so no need for a while loop
                    if (reader.Read())
                    {
                        chore = new Chore
                        {
                            Id = id,
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                    }

                    reader.Close();

                    return chore;
                }
            }
        }
    }
}
