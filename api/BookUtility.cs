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
                    username = rdr.GetString(1),
                    isbn = rdr.GetString(2),
                    author = rdr.GetString(3),
                    title = rdr.GetString(4),
                    img = rdr.GetString(5),
                    status = rdr.GetString(6),
                    renter = rdr.GetString(7),
                    renterEmail = rdr.GetString(8)
                    //dateRented = (rdr[4] is DBNull) ? DateTime.MinValue : rdr.GetDateTime(6)
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

*/
          public static void AddBook(Book book)
         {
             Database db = new Database();

             using var con = new MySqlConnection(db.cs);
             con.Open();

             string stm= "INSERT INTO books (idbooks, username, isbn, author, title, img, status, renter, renterEmail) VALUES (@idbooks, @username, @isbn, @author, @title, @img, @status, @renter, @renterEmail);";
             using var cmd = new MySqlCommand(stm, con);

             cmd.Parameters.AddWithValue("@idbooks", book.idbooks);
             cmd.Parameters.AddWithValue("@username", book.username);
             cmd.Parameters.AddWithValue("@isbn", book.isbn);
             cmd.Parameters.AddWithValue("@author", book.author);
             cmd.Parameters.AddWithValue("@title", book.title);
             cmd.Parameters.AddWithValue("@img", book.img);
             cmd.Parameters.AddWithValue("@status", book.status);
             cmd.Parameters.AddWithValue("@renter", book.renter);
             cmd.Parameters.AddWithValue("@renterEmail", book.renterEmail);
             //cmd.Parameters.AddWithValue("@dateRented", book.dateRented);
             


             cmd.ExecuteNonQuery();

             con.Close();
         }

         public static void UpdateBook (int idbooks, Book book)
        {
            Database db = new Database();

            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = "UPDATE books SET status = @status, renter = @renter, renterEmail = @renterEmail  WHERE idbooks = @idbooks";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@status", book.status);
            cmd.Parameters.AddWithValue("@renter", book.renter);
            cmd.Parameters.AddWithValue("@renterEmail", book.renterEmail);
            cmd.Parameters.AddWithValue("@idbooks", idbooks);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        // public static void UpdateBook (Book book)
        // {
        //     Database db = new Database();

        //     using var con = new MySqlConnection(db.cs);
        //     con.Open();

        //     string stm = "UPDATE books SET status = @status, renterEmail = @renterEmail WHERE idbooks = @idbooks";
        //     using var cmd = new MySqlCommand(stm, con);

        //     cmd.Parameters.AddWithValue("@status", book.status);
        //     //cmd.Parameters.AddWithValue("@idbooks", book.renter);
        //     cmd.Parameters.AddWithValue("@idbooks", book.renterEmail);
        //     cmd.Parameters.AddWithValue("@idbooks", book.idbooks);

        //     cmd.ExecuteNonQuery();

        //     con.Close();
        // }


        
        public static void DeleteBook(int idbooks)
        {
            Database db = new Database();

            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = "DELETE FROM books WHERE idbooks = @idbooks";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@idbooks", idbooks);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        /*
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