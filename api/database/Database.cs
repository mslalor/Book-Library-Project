using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace api.database
{
    public class Database
    {
        
        private string host { get; set;}

        private string database { get; set;}

        private string username { get; set;}

        private string port { get; set;}

        private string password { get; set;}

        public string cs { get; set;}

        public Database()
        {
            host= "thh2lzgakldp794r.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database="u0enp1sxhpbh5mt9";
            username="s63utysnyhihl3r7";
            port="3306";
            password="g6ba4c85obgxgcha";

           cs= $"server={host};user={username};database={database};port={port}; password={password}";

        }
    
    }
}