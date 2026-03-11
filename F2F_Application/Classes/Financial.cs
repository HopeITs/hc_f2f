using MySql.Data.MySqlClient;
using System.Data;


namespace F2F_Application.Classes
{
    class Financial
    {
        string query;

        public DataSet Get_Financial_Report(int Distribution_ID, bool PerGroup)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);

            if (PerGroup)
            {
                query = "CALL `Financial_Report`(@Distribution_ID,1);";
            }
            else if (!PerGroup)
            {
                query = "CALL `Financial_Report`(@Distribution_ID,0);";
            }

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public DataTable Get_Approved_Distributions(string Date,int Donor)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Donor", Donor);
            if(Donor == 0)
            {
                query = "SELECT DISTINCT(distribution.id), CONCAT(distribution.Name, ' - ', DATE_FORMAT(distribution.date, '%M/%Y')) as 'name'"
                + " FROM distribution "
                + " LEFT JOIN partner_distribution on partner_distribution.distribution_id = distribution.id"
                + " WHERE partner_distribution.listapproved = '1' and partner_distribution.recievedmoneyapproved = '1' AND Year(distribution.date) = Year(STR_TO_DATE(@Date, '%d/%m/%Y'));";
            }
            else
            {
                query = "SELECT DISTINCT(distribution.id), CONCAT(distribution.Name, ' - ', DATE_FORMAT(distribution.date, '%M/%Y')) as 'name'"
                + " FROM distribution "
                + " LEFT JOIN partner_distribution on partner_distribution.distribution_id = distribution.id"
                + " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id"
                + " WHERE partner_distribution.listapproved = '1' and partner_donor.donor_id = @Donor and partner_distribution.recievedmoneyapproved = '1' AND Year(distribution.date) = Year(STR_TO_DATE(@Date, '%d/%m/%Y'));";
            }
            

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
