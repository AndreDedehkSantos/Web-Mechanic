
using MySql.Data.MySqlClient;

namespace web_mechanic_api.Dal
{
    abstract public class DalConnect
    {
      protected readonly string connectionString = "Server=localhost;Port=3306;Database=web_mechanic;Uid=root;Pwd=root;charset=utf8;";

      protected MySqlConnection Connect()
      {
        return new MySqlConnection(connectionString);
      }
    }
}