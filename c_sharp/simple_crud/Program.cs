using System;
using DbConnection;

namespace simple_crud
{
    class Program
    {
        public static void read()
        {
            string query = "SELECT * FROM users";
            var users = DbConnector.Query(query);
            foreach (var user in users)
            {
                Console.WriteLine(user["id"] + " " + user["first_name"] + " " + user["last_name"] + " " + user["favorite_number"]);
            }
        }
        public static void create()
        {
            Console.WriteLine("What's your First Name");
            string first_name = '"' + Console.ReadLine() + '"';
            Console.WriteLine("What's your Last Name");
            string last_name = '"' + Console.ReadLine() + '"';
            Console.WriteLine("What's your Favorite Number");
            string num = Console.ReadLine();
            string query = $"INSERT into users(first_name, last_name, favorite_number) VALUES({first_name}, {last_name}, {num})";
            Console.WriteLine(query);
            DbConnector.Execute(query);
            read();
        }
        public static void update()
        {
            Console.WriteLine("Enter id");
            string id = Console.ReadLine();
            Console.WriteLine("Enter First Name");
            string first_name = Console.ReadLine();
            string fString = '"' + first_name + '"';
            Console.WriteLine("Enter Last Name");
            string last_name = Console.ReadLine();
            string lString = '"' + last_name + '"';
            Console.WriteLine("Enter Favorite Number");
            string favorite_number = Console.ReadLine();
            string updateQuery = $"UPDATE users SET first_name = {fString}, last_name = {lString}, favorite_number = {favorite_number} WHERE id = {id}";
            DbConnector.Execute(updateQuery);
            read();
        }
        public static void remove()
        {
            Console.WriteLine("Enter id of user you want to delete");
            string id = Console.ReadLine();
            string removeQuery = $"DELETE FROM users WHERE id = {id}";
            DbConnector.Execute(removeQuery);
            read();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            read();
            //create();
            //update();
            remove();
        }
    }
}
