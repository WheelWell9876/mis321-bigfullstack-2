namespace Bigproject
{
    public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString()
        {
            string server = "u6354r3es4optspf.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";

            string database = "p6nr5re8fmcvgnki"; 

            string port = "3306";

            string username = "zjqdq3uq049s70gx";

            string password = "cnm3s0owd9agt556";

            cs = $@"server = {server}; username = {username}; database = {database}; port = {port}; password = {password};";
        }
    }
}