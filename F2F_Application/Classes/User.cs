using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace F2F_Application.Classes
{
    class User
    {
        string query, log_query, condition;
        //MySqlCommand sc;

        public DataTable Check_User(string Username, string Password)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Username", Username);
            sc.Parameters.AddWithValue("@Password", Password);

            query = "select user.ID, user.Username, user.Password, user.ProfilePicture, role.name as 'Role', user.islogedin, user.pc_name"
                + " from user JOIN role on user.Role_id = role.id"
                + " where 1 and user.Username like @UserName and user.Password like @Password ";


            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataTable Get_Version()
        {
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            query = "SELECT l_version FROM version WHERE id = 1;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public void Update_Version(string NewVersion)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@NewVersion", NewVersion);


            query = " START TRANSACTION;";
            query += "UPDATE version SET l_version = @NewVersion WHERE id = 1;";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Logedin(int UserID, int Old_UserID, int LogedIn, string PCName)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@UserID", UserID);
            sc.Parameters.AddWithValue("@Old_UserID", Old_UserID);
            sc.Parameters.AddWithValue("@LogedIn", LogedIn);
            sc.Parameters.AddWithValue("@PCName", PCName);

            query = " START TRANSACTION;";
            query += "UPDATE user SET islogedin = @LogedIn, pc_name = @PCName WHERE id = @UserID;";
            if (Old_UserID > 0)
                query += "UPDATE user SET islogedin = 0, pc_name = '' WHERE id = @Old_UserID;";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public byte[] Select_ProfilePicture(int ID)
        {
            byte[] arr = null;
            //check connection//
            Program.buildConnection();
            query = "select ProfilePicture from `user` where ID = " + ID + " ";
            
            MySqlCommand sc = new MySqlCommand(query, Program.MyConn);
            var da = new MySqlDataAdapter(sc);
            var dt = new DataTable();
            da.Fill(dt);
            byte[] query_array = dt.Rows[0].Field<byte[]>(0);
            if (query_array != null && query_array.Length > 0)
            {
                MySqlDataReader reader = sc.ExecuteReader();
                reader.Read();
                arr = (byte[])reader[0];
                reader.Close();
            }
            Program.MyConn.Close();
            return arr;
        }

        public void Insert_User(string Username, string Password, int Role_ID, byte[] ProfilePicture, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Username", Username);
            sc.Parameters.AddWithValue("@Password", Password);
            sc.Parameters.AddWithValue("@Role_ID", Role_ID);
            sc.Parameters.AddWithValue("@PicArr", ProfilePicture);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "INSERT  INTO `user`( `Username`, `Password`, `Role_id`, `ProfilePicture`) VALUES"
                    + " (@Username, @Password, @Role_ID, @PicArr);";

            query += "set @User_ID = Last_Insert_ID();";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('User ID = ', @User_ID), CONCAT('Username = ', @Username), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_User(int ID, string Username, string Password, int Role_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Username", Username);
            sc.Parameters.AddWithValue("@Password", Password);
            sc.Parameters.AddWithValue("@Role_ID", Role_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);


            query = " START TRANSACTION;";
            query += "UPDATE `user` SET `Username`= @Username, `Password`= @Password, `Role_ID`= @Role_ID"
                + " WHERE ID = @ID;";


            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('User ID = ', @ID), CONCAT('Username = ', @Username), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Profile_Pic(int ID, string Username, byte[] Pic, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Username", Username);
            sc.Parameters.AddWithValue("@PicArr", Pic);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "UPDATE `user` SET ProfilePicture = @PicArr WHERE ID = @ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('User ID = ', @ID), CONCAT('Username = ', @Username), 'Profile Pic' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_User(int ID, string Username, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Username", Username);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE from `user` where `ID` = @ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('User ID = ', @ID), CONCAT('Username = ', @Username), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public DataTable Select_Users(bool L0_Admin)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();


            query = "select user.ID, user.Username, user.Password, role.id as 'Role_id', user.ProfilePicture as 'Picture' from user join role on user.role_id = role.id where 1";
            string condition = "";

            if (!L0_Admin)
            {
                condition += " and (role.name <> 'L0_Admin' and role.name <> 'Admin') or user.Username = '" + Properties.Settings.Default.Username + "'";
            }
            query += condition;



            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;

        }

        public DataTable Select_Roles(string Role)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            query = "select * from role where 1";
            if (Role != "L0_Admin")
            {
                condition += " and role.name <> 'L0_Admin'";
                if (Role != "Admin")
                {
                    condition += "and role.name <> 'Admin'";
                }
            }
            query += condition;

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public void Send_FeedBack(string Message)
        {
            MailMessage msgMail = new MailMessage();
            msgMail.From = new MailAddress("feedback.userapp@hcsyria.org");
            msgMail.To.Add("sary.zainoun@hcsyria.org");
            msgMail.To.Add("judy.dadaghlian@hcsyria.org");
            msgMail.Subject = "User Feedback - F2F App. V" + Application.ProductVersion;
            msgMail.Body = Message;

            SmtpClient mailClient = new SmtpClient("mail.s807.sureserver.com", 587);
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = new NetworkCredential("feedback.userapp@hcsyria.org", "JS2021program");
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            mailClient.Send(msgMail);
            msgMail.Dispose();
        }
    }
}
