using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace F2F_Application.Classes
{
    class Partner
    {
        string query, log_query;
        //MySqlCommand sc;

        public DataTable Select_Partners()
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            query = "select partner.ID, partner.name, partner.name_en, partner.logo, partnergroups.id as 'partnergroup_id' FROM partner LEFT JOIN partnergroups ON partner.partnergroup_id = partnergroups.id  where 1;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;

        }

        public void Update_Partner(int ID, string Name, string Name_EN, int Partnergroup_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Name_EN", Name_EN);
            sc.Parameters.AddWithValue("@Partnergroup_ID", Partnergroup_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "UPDATE `partner` SET `name`= @Name, `name_en` = @Name_EN" +
                ",`Partnergroup_id`= @Partnergroup_ID" +
                " WHERE ID = @ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Partner ID = ', @ID), CONCAT('Partner Name = ', @Name), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Partner_Logo(int ID, string Name, byte[] Logo, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);
            sc.Parameters.Add(new MySqlParameter("@PicArr", Logo));

            query = " START TRANSACTION;";
            query += "UPDATE `partner` SET " +
                " Logo = @PicArr" +
                " WHERE ID = @ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Partner ID = ', @ID), CONCAT('Partner Name = ', @Name), 'Logo' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Insert_Partner(string Name, string Name_EN, int Partnergroup_ID, byte[] ProfilePicture, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Name_EN", Name_EN);
            sc.Parameters.AddWithValue("@Partnergroup_ID", Partnergroup_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);
            sc.Parameters.Add(new MySqlParameter("@PicArr", ProfilePicture));

            query = " START TRANSACTION;";
            query += "INSERT  INTO `partner`( `name`, `name_en`, `partnergroup_id`, `logo`) VALUES"
                    + " (@Name, @Name_EN, @Partnergroup_ID, @PicArr);";

            query += "set @Partner_ID = Last_Insert_ID();";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }


            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('Partner ID = ', @Partner_ID), CONCAT('Partner Name = ', @Name), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_Partner(int ID, string Name, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE from `partner` where `ID` = @ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }


            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('Partner ID = ', @ID), CONCAT('Partner Name = ', @Name), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public DataTable Get_Partner_Unregistred_Distribution(int PartnerDonor_ID, string Year)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@PartnerDonor_ID", PartnerDonor_ID);
            sc.Parameters.AddWithValue("@Year", Year);

            //query = "SELECT distribution.id, distribution.name, DATE_FORMAT(distribution.date, '%M/%Y') as 'date' FROM distribution LEFT JOIN "
            //    + " (SELECT distribution.id FROM partner"
            //    + " LEFT JOIN partner_distribution ON partner.id = partner_distribution.partner_id"
            //    + " LEFT JOIN distribution ON distribution.id = partner_distribution.distribution_id"
            //    + " WHERE partner_distribution.partner_id = @Partner_ID) as t1"
            //    + " ON distribution.id = t1.id"
            //    + " WHERE year(distribution.date) = @Year and  t1.id IS null";

            //query = "SELECT distribution.id, distribution.name ,partner_distribution.partner_donor_id,DATE_FORMAT(distribution.date, '%M/%Y') as 'date' FROM distribution LEFT JOIN(SELECT distribution.id"
            //+ " FROM partner_donor LEFT JOIN partner_distribution ON partner_distribution.partner_donor_id = partner_donor.id"
            //+ " LEFT JOIN distribution ON distribution.id = partner_distribution.distribution_id"
            //+ " LEFT JOIN partner on partner.id = partner_donor.partner_id"
            //+ " LEFT JOIN donor on donor.id = partner_donor.donor_id"
            //+ " WHERE partner_donor.partner_id = @Partner_ID and partner_donor.donor_id = @Donor_ID) as t1"
            //+ " ON distribution.id = t1.id"
            //+ " LEFT JOIN partner_distribution on partner_distribution.distribution_id = distribution.id"
            //+ " WHERE year(distribution.date) = @Year and t1.id IS null";
            //query = "SELECT distribution.id, distribution.name, DATE_FORMAT(distribution.date, '%M/%Y') as 'date' FROM distribution LEFT JOIN "
            //    + " (SELECT distribution.id FROM partner_donor"
            //    + " LEFT JOIN partner_distribution ON partner_donor.id = partner_distribution.partner_donor_id"
            //    + " LEFT JOIN distribution ON distribution.id = partner_distribution.distribution_id"
            //    + " WHERE partner_distribution.partner_donor_id = (select id from partner_donor where partner_id = @Partner_ID and donor_id = @Donor_ID) ) as t1"
            //    + " ON distribution.id = t1.id"
            //    + " WHERE year(distribution.date) = @Year and  t1.id IS null";
            //query = "SELECT distribution.id, distribution.name, DATE_FORMAT(distribution.date, '%M/%Y') as 'date' FROM distribution LEFT JOIN(SELECT distribution.id FROM partner_donor LEFT JOIN partner_distribution on partner_distribution.partner_donor_id = partner_donor.id LEFT JOIN distribution on distribution.id = partner_distribution.distribution_id WHERE partner_distribution.partner_donor_id = @PartnerDonor_ID) as t1 ON distribution.id = t1.id WHERE year(distribution.date) = @Year and t1.id IS null";
            query = "SELECT distribution.id, distribution.name, DATE_FORMAT(distribution.date, '%M/%Y') as 'date' FROM distribution LEFT JOIN "
                + " (SELECT distribution.id FROM partner_donor"
                + " LEFT JOIN partner_distribution ON partner_donor.id = partner_distribution.partner_donor_id"
                + " LEFT JOIN distribution ON distribution.id = partner_distribution.distribution_id"
                + " WHERE partner_distribution.partner_donor_id = @PartnerDonor_ID and year(distribution.date) = @Year) as t1"
                + " ON distribution.id = t1.id"
                + " WHERE year(distribution.date) = @Year and  t1.id IS null";
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public void Add_Partner_Distribution(string Distribution_Query, List<int> Distributions_ID, int PartnerDonorID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@PartnerDonorID", PartnerDonorID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            query += " INSERT INTO partner_distribution (partner_donor_id, distribution_id) VALUES " + Distribution_Query + ";";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }
            for (int i = 0; i < Distributions_ID.Count; i++)
                query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('Distribution ID = ', '" + Distributions_ID[i] + "'), CONCAT('PartnerDonor ID = ', @PartnerDonorID), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Insert_Partner_Distribution_Date(int Partner_ID, int Distribution_ID, int Partner_Distribution_ID, string Date, string Time, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Partner_Distribution_ID", Partner_Distribution_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Time", Time);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "INSERT INTO partner_distribution_date (partner_distribution_id, Date, time) VALUES (@Partner_Distribution_ID,"
                + " STR_TO_DATE(@Date, '%d/%m/%Y'), @Time);";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT',  CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('Partner ID = ', @Partner_ID), 'Date' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public DataTable Get_Partner_Distribution_Dates(int Partner_Distribution_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_Distribution_ID", Partner_Distribution_ID);

            query = "SELECT partner_distribution_date.* FROM partner_distribution_date"
                + " WHERE partner_distribution_date.partner_distribution_id = @Partner_Distribution_ID;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataTable Get_Partner_Donor_ID(int Partner_ID, int Donor_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);

            query = "SELECT partner_donor.id as id FROM partner_donor"
                + " WHERE partner_donor.partner_id = @Partner_ID and partner_donor.donor_id = @Donor_ID;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public void Update_Partner_Distribution_Date(int ID, int Partner_ID, int Distribution_ID, string Date, string Time, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Time", Time);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "UPDATE partner_distribution_date SET date = STR_TO_DATE(@Date, '%d/%m/%Y'),"
                + " time = @Time WHERE id = @ID;";


            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('Partner ID = ', @Partner_ID) , 'Date', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_Partner_Distribution_Date(int ID, int Partner_ID, int Distribution_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE from `partner_distribution_date` where `ID` = @ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('Partner ID = ', @Partner_ID) , 'Date', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_Partner_Distribution(int Partner_Donor_ID, int Distribution_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_Donor_ID", Partner_Donor_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE from partner_distribution where partner_donor_id = @Partner_Donor_ID and distribution_id = @Distribution_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }


            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('PartnerDonor ID = ', @Partner_Donor_ID), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Partner_Partner_Distribution_AdminCost_Delivered(int Partner_Donor_ID, int Distribution_ID, float Admin_Cost, float Delivered, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_Donor_ID", Partner_Donor_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Admin_Cost", Admin_Cost);
            sc.Parameters.AddWithValue("@Delivered", Delivered);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "UPDATE partner_distribution SET admincost = @Admin_Cost, delivered = @Delivered"
                + " WHERE partner_donor_id = @Partner_Donor_ID and distribution_id = @Distribution_ID;";


            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('PartnerDonor ID = ', @Partner_Donor_ID), 'Admin Cost / Delivered' , '" + log_query + "',  DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public DataTable Get_Partner_Distribution_ID(string Partner_Name,string Donor_Name, string Distribution_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_Name", Partner_Name);
            sc.Parameters.AddWithValue("@Donor_Name", Donor_Name);
            sc.Parameters.AddWithValue("@Distribution_Name", Distribution_Name);

            //query = "SELECT partner.id as 'partner_id', distribution.id as 'distribution_id' , partner_distribution.id as 'partner_distribution_id' FROM"
            //    + " partner LEFT JOIN partner_distribution on partner_distribution.partner_id = partner.id"
            //    + " LEFT JOIN distribution on partner_distribution.distribution_id = distribution.id"
            //    + " WHERE partner.name = '" + Partner_Name + "' and distribution.name = '" + Distribution_Name + "';";

            query = "SELECT partner_donor.id as 'partner_donor_id', distribution.id as 'distribution_id' , partner_distribution.id as 'partner_distribution_id' FROM"
                + " partner_donor LEFT JOIN partner_distribution on partner_distribution.partner_donor_id = partner_donor.id"
                + " LEFT JOIN distribution on partner_distribution.distribution_id = distribution.id"
                + " LEFT JOIN partner on partner.id = partner_donor.partner_id"
                + " LEFT JOIN donor on donor.id = partner_donor.donor_id"
                + " WHERE partner.name = '" + Partner_Name + "' and distribution.name = '" + Distribution_Name + "' and donor.name = '" + Donor_Name + "';";

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
