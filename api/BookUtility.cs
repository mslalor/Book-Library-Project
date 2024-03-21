using api.database;
using MySql.Data.MySqlClient;
using api.models;
namespace api
{
    public class BookUtility
    {
          public static List<Book> GetBook()
         {
            List<Book> book = new List<Book>();

            Database db = new Database();

             using var con = new MySqlConnection(db.cs);
             con.Open();
             //books is name of table
             string stm= "select * from books";
    
            using var cmd = new MySqlCommand(stm, con); // we use using so it trashes it when we get done with it
            using MySqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
            {
                book.Add(new Book
                {
                    idbooks = rdr.GetInt32(0),
                    bookName = rdr.GetString(1)
                    //carID = rdr.GetInt32(0),
                    //carMake= rdr.GetString(1),
                    //carModel = rdr.GetString(2),
                    //carMileage = rdr.GetInt32(3),
                    //dateEntered = (rdr[4] is DBNull) ? DateTime.MinValue : rdr.GetDateTime(4),
                    //onHold = rdr.GetBoolean(5),
                    //isDeleted = rdr.GetBoolean(6)
                });
                // Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)} {rdr.GetString(3)} {rdr.GetString(4)} {rdr.GetString(5)}");
            }

            con.Close();
            return book;
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
}


          public static void AddInventory(Inventory inventory)
         {
             Database db = new Database();

             using var con = new MySqlConnection(db.cs);
             con.Open();

             string stm= "INSERT INTO inventory (carID, carMake, carModel, carMileage, dateEntered, onHold, isDeleted) VALUES (@carID, @carMake, @carModel, @carMileage, @dateEntered, @onHold, @isDeleted);";
             using var cmd = new MySqlCommand(stm, con);

             cmd.Parameters.AddWithValue("@carID", inventory.carID);
             cmd.Parameters.AddWithValue("@carMake", inventory.carMake);
             cmd.Parameters.AddWithValue("@carModel", inventory.carModel);
             cmd.Parameters.AddWithValue("@carMileage", inventory.carMileage);
             cmd.Parameters.AddWithValue("@dateEntered", inventory.dateEntered);
             cmd.Parameters.AddWithValue("@onHold", inventory.onHold);
             cmd.Parameters.AddWithValue("@isDeleted", inventory.isDeleted);
             


             cmd.ExecuteNonQuery();

             con.Close();
         }
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