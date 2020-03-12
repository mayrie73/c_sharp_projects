using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using woods.Models;

namespace woods.Factory
{
     public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=woodsdb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO trails(name, description, elevationChange, length, latitude, longitude) VALUES (@name, @description, @elevationChange, @length, @latitude, @longitude)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public List<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails").ToList();
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}
