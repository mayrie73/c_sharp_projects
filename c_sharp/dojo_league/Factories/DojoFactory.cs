using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojo_league.Models;
namespace dojo_league.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;

        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojoleaguedb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

               public void Add(Dojo item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO dojos (name, location, information, created_at, updated_at) VALUES (@Name, @location, @information, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Dojo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
            }
        }
        public Dojo FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}