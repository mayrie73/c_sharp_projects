using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojo_league.Models;
namespace dojo_league.Factory
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;

        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojoLeaguedb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

               public void Add(Ninja item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO ninjas (name, level, location, description, created_at, updated_at) VALUES (@Name, @level, @location, @description, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Ninja> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas");
            }
        }
        public Ninja FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}
