using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Odbc;
using Npgsql;

namespace HelloWorldAzureAPI.Controllers
{
    public class ExercisesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var cs = Properties.Settings.Default.PostgresConnection;
            var connection = new NpgsqlConnection("Host=LTW72D45N72.prd.manulifeusa.com;Username=postgres;Password=admin;Database=postgres");
            /*string connstring = String.Format("Server={0};" +
                     "User Id={1};Password={2};Database={3};",
                     "10.44.10.81", "postgres",
                     "admin", "postgres");*/


            // Create the ODBC connection using the unique name you specified when 
            // creating your DSN. If desired you may input less information at the
            // DSN entry stage and put more in the "DSN=" line below.
            //OdbcConnection connection = new OdbcConnection(conn);
            // "DSN=MyDSN;UID=Admin;PWD=Test" (UID = User name, PWD = password.)


            // Open the ODBC connection to the PostgreSQL database and display
            // the connection state (status).
            //connection.Open();
            connection.Open();
            var cmd = new NpgsqlCommand();
            System.Console.WriteLine("State: " + connection.State.ToString());


            // Create an ODBC SQL command that will be executed below. Any SQL 
            // command that is valid with PostgreSQL is valid here (I think, 
            // but am not 100 percent sure. Every SQL command I've tried works).
            string query = "SELECT data->'fields'->'name' AS name FROM muscles m1 where data->'fields'->'name' is not null";
            //OdbcCommand command = new OdbcCommand(query, connection);
            cmd.Connection = connection;
            cmd.CommandText = query;

            // Execute the SQL command and return a reader for navigating the results.
            var reader = cmd.ExecuteReader();


            // This loop will output the entire contents of the results, iterating
            // through each row and through each field of the row.
            int i = 0;
            //int counter = 0;

           /* while (reader.Read())
            {
                //get rows
                counter++;
            }*/
            string[] result = new string[16];
            while (reader.Read() == true)
            {
                Console.WriteLine("New Row:");
                Console.WriteLine(reader.GetString(0));
                result[i] = reader.GetString(0);
                /*for (int i = 0; i < reader.FieldCount; i++)
                {
                    //result[i] = (string) reader.GetString(i);
                    Console.WriteLine(reader.ToString());
                }*/
                i++;
            }

            // Close the reader and connection (commands are not closed).
            reader.Close();
            connection.Close();
            return result;
            //return new string[] { "value4", "value5" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}