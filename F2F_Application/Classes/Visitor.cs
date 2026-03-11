using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace F2F_Application.Classes
{
    class Visitor
    {
        string query;
        public DataTable Get_Visitor()
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();


            query = "select * from visitor where 1";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;

        }


    }
}
