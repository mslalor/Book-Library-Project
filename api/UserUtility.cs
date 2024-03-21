using api.database;
using MySql.Data.MySqlClient;
using api.models;
namespace api
{
    public class UserUtility
    {
          public static List<User> GetUser()
         {
            List<User> user = new List<User>();

            Database db = new Database();

             using var con = new MySqlConnection(db.cs);
             con.Open();
             //books is name of table
             string stm= "select * from users";
    
            using var cmd = new MySqlCommand(stm, con); // we use using so it trashes it when we get done with it
            using MySqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
            {
                user.Add(new User
                {
                    idusers = rdr.GetInt32(0),
                    username = rdr.GetString(1),
                    email = rdr.GetString(2),
                    firstName = rdr.GetString(3),
                    password = rdr.GetString(4),
                    numBooks = rdr.GetInt32(5)
                });
                // Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)} {rdr.GetString(3)} {rdr.GetString(4)} {rdr.GetString(5)}");
            }

            con.Close();
            return user;
         }
/*
public static Book GetInventoryById(int id)
{
    Book newBook = new Book();

    Database db = new Database();

    using var con = new MySqlConnection(db.cs);
    con.Open();

    //string stm = "SELECT * FROM inventory";
    string stm = "SELECT * FROM books ORDER BY dateEntered ASC;";

    using var cmd = new MySqlCommand(stm, con);
    cmd.Parameters.AddWithValue("@id", id);

    using MySqlDataReader rdr = cmd.ExecuteReader();

    if (rdr.Read())
    {
        newInventory.carID = rdr.GetInt32("carID");
        newInventory.carMake= rdr.GetString("carMake");
        newInventory.carModel = rdr.GetString("carModel");
        newInventory.carMileage = rdr.GetInt32("carMileage");
        newInventory.dateEntered = rdr.GetDateTime("dateEntered");
        newInventory.onHold = rdr.GetBoolean("onHold");
        newInventory.isDeleted = rdr.GetBoolean("isDeleted");
       
    }

    con.Close();
    return newInventory;
}*/


          public static void AddUser(User user)
         {
             Database db = new Database();

             using var con = new MySqlConnection(db.cs);
             con.Open();

             string stm= "INSERT INTO users (idusers, username, email, firstName, password, numBooks) VALUES (@idusers, @username, @email, @firstName, @password, @numBooks);";
             using var cmd = new MySqlCommand(stm, con);

             cmd.Parameters.AddWithValue("@idusers", user.idusers);
             cmd.Parameters.AddWithValue("@username", user.username);
             cmd.Parameters.AddWithValue("@email", user.email);
             cmd.Parameters.AddWithValue("@firstName", user.firstName);
             cmd.Parameters.AddWithValue("@password", user.password);
             cmd.Parameters.AddWithValue("@numBooks", user.numBooks);
             


             cmd.ExecuteNonQuery();

             con.Close();
         }
         /*
        public static void DeleteInventory(int carID)
        {
            Database db = new Database();

            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = "UPDATE inventory SET isDeleted = true WHERE carID = @carID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@carID", carID);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void HoldInventory(int carID)
        {
            Database db = new Database();

            using var con = new MySqlConnection(db.cs);
            con.Open();

            string fetchStm = "SELECT onHold FROM inventory WHERE carID = @carID";
            using var fetchCmd = new MySqlCommand(fetchStm, con);
            fetchCmd.Parameters.AddWithValue("@carID", carID);

            bool currentOnHold = false;

            using (MySqlDataReader fetchReader = fetchCmd.ExecuteReader())
        {
            if (fetchReader.Read())
            {
                currentOnHold = fetchReader.GetBoolean("onHold");
            }
        }
            string updateStm = "UPDATE inventory SET onHold = @onHold WHERE carID = @carID";
            using var updateCmd = new MySqlCommand(updateStm, con);
            updateCmd.Parameters.AddWithValue("@carID", carID);
            updateCmd.Parameters.AddWithValue("@onHold", !currentOnHold);

            updateCmd.ExecuteNonQuery();

            con.Close();
        }*/
    }
}