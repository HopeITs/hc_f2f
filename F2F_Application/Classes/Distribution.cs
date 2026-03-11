using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;


namespace F2F_Application.Classes
{
    class Distribution
    {
        string query, Ordered_By, log_query;
        //MySqlCommand sc;

        public DataTable Get_Distribution(int Distribution_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);

            query = "SELECt distribution.*,donor_id from distribution "
                  + "LEFT JOIN partner_distribution on partner_distribution.distribution_id = distribution.id "
                  + "LEFT join partner_donor on partner_donor.id = partner_distribution.partner_donor_id "
                  + "LEFT JOIN donor on donor.id = partner_donor.donor_id where distribution.id = @Distribution_ID ";

            Ordered_By = " ORDER BY date";

            query += Ordered_By;

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataTable Get_All_Distributions(string Date)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Date", Date);

            query = "select id, CONCAT(Name, ' - ', MONTHNAME(date), '/', YEAR(date)) as 'name' from distribution";

            if (Date != "")
            {
                query += " WHERE  Year(date) = Year(STR_TO_DATE(@Date, '%d/%m/%Y'))";
            }

            Ordered_By = " ORDER BY date";

            query += Ordered_By;

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataSet Get_Partner_Distribution(int Partner_ID,int Donor_ID, int Distribution_ID, string Year)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Year", Year);

            query = "CALL `Partner_Distribution`(@Partner_ID, @Donor_ID, @Distribution_ID, @Year);";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public int Insert_Distribuion(string Name, string Date, string Rate, int Default, int SegmentsGroup_ID, string SegmentsGroup_Name, int DonorGroup_ID, string Form_Name)
        {
            int Distribution_ID;

            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Default", Default);
            sc.Parameters.AddWithValue("@SegmentsGroup_ID", SegmentsGroup_ID);
            sc.Parameters.AddWithValue("@SegmentsGroup_Name", SegmentsGroup_Name);
            sc.Parameters.AddWithValue("@DonorGroup_ID", DonorGroup_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "INSERT INTO distribution (name, date, rate, segmentsgroup_id) VALUES (@Name,"
                + " STR_TO_DATE(@Date, '%d/%m/%Y'), @Rate, @SegmentsGroup_ID);";

            query += "set @ID = Last_Insert_ID();";

            if (Default == 1)
            {
                query += "UPDATE segmentsgroup SET IsDefault = '0';";

                query += " UPDATE segmentsgroup SET IsDefault = @Default WHERE id = @SegmentsGroup_ID;";
            }
            //query += "Select id from partner_donor where donor_id = @DonorGroup_ID";
            query += "INSERT INTO partner_distribution (partner_donor_id, distribution_id) SELECT id, @ID from partner_donor where donor_id = @DonorGroup_ID;";

            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            if (Default == 1)
            {
                query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('SegmentsGroup ID = ', @SegmentsGroup_ID), CONCAT('SegmentsGroup Name = ', @SegmentsGroup_Name), 'Set as default', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            }
            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('Distribution ID = ', @ID), CONCAT('Distribution Name = ', @Name), CONCAT('SegmentsGroup ID = ', @SegmentsGroup_ID), '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " SELECT @ID;"
                + " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            Distribution_ID = Convert.ToInt32(sc.ExecuteScalar());
            Program.MyConn.Close();

            return Distribution_ID;

        }

        public void Delete_Distribution(int Distribution_ID, int SegmentsGroup_ID, string Name, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@SegmentsGroup_ID", SegmentsGroup_ID);
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE from distribution where `ID` = @Distribution_ID;";

            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('Distribution Name = ', @Name), CONCAT('SegmentsGroup ID = ', @SegmentsGroup_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Distribution(int Distribution_ID, string Distribution_Name, string Name, string Date, string Rate, int Default, int SegmentsGroup_ID, string SegmentsGroup_Name, int DonorGroup_ID, string Form_Name)
        {

            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Distribution_Name", Distribution_Name); //To be used in log
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Default", Default);
            sc.Parameters.AddWithValue("@SegmentsGroup_ID", SegmentsGroup_ID);
            sc.Parameters.AddWithValue("@SegmentsGroup_Name", SegmentsGroup_Name);
            sc.Parameters.AddWithValue("@DonorGroup_ID", DonorGroup_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (Name != "")
                query += "UPDATE distribution set Name = @Name where id = @Distribution_ID;";

            if (Date != "")
                query += "UPDATE distribution set date = STR_TO_DATE(@Date, '%d/%m/%Y') where id = @Distribution_ID;";

            if (Rate != "")
                query += "UPDATE distribution set Rate = @Rate where id = @Distribution_ID;";

            if (DonorGroup_ID != -1)
            {
                query += "UPDATE partner_donor LEFT JOIN partner_distribution on partner_distribution.partner_donor_id = partner_donor.id LEFT JOIN distribution on distribution.id = partner_distribution.distribution_id set donor_id = @DonorGroup_ID where distribution.id = @Distribution_ID;";
            }

            if (SegmentsGroup_ID != -1)
            {
                if (Default == 1)
                {
                    query += "UPDATE segmentsgroup SET IsDefault = '0';";

                    query += " UPDATE segmentsgroup SET IsDefault = @Default WHERE id = @SegmentsGroup_ID;";
                }

                query += "UPDATE distribution set segmentsgroup_id = @SegmentsGroup_ID where id = @Distribution_ID;";
            }

            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }


            if (SegmentsGroup_ID != -1)
            {
                if (Default == 1)
                {
                    query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('SegmentsGroup ID = ', @SegmentsGroup_ID), CONCAT('SegmentsGroup Name = ', @SegmentsGroup_Name), 'Set as default', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
                }
            }
            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('Distribution Name = ', @Distribution_Name), CONCAT('SegmentsGroup ID = ', @SegmentsGroup_ID), '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();

        }

        public DataTable Check_Distribution_Date(string Date, int Distribution_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);

            query = "SELECT name as 'Name' FROM distribution"
                + " WHERE Month(date) = Month(STR_TO_DATE(@Date, '%d/%m/%Y'))"
                + " and Year(date) = Year(STR_TO_DATE(@Date, '%d/%m/%Y')) ";

            if (Distribution_ID != -1)
            {
                query += " and id <> @Distribution_ID";
            }
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count < 1)
                dt = null;

            Program.MyConn.Close();
            return dt;
        }

        public DataTable Get_NotApproved_Signitaure_List(int Partner_ID,int Donor_ID, int Partner_Distribution_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);
            sc.Parameters.AddWithValue("@Partner_Distribution_ID", Partner_Distribution_ID);

            query = "SET @MaxMembers = (SELECT MAX(segmentsgroup_details.NumberOfMembers)"
                + " FROM segmentsgroup_details"
                + " LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + " LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + " LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + " WHERE partner_distribution.id = @Partner_Distribution_ID);"
                + "SELECT t1.`Family ID`, t1.`رمز العائلة`, t1.`الاسم`, t1.`اسم الاب`, t1.`الكنية`, t1.`الرقم الوطني`, t1.`رقم الهاتف`, t1.`عدد المستفيدين`,"
                + " CASE"
                + "     WHEN t1.`عدد المستفيدين` >= @MaxMembers THEN"
                + "        (SELECT segmentsgroup_details.amount"
                + "         FROM segmentsgroup_details"
                + "        LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + "         WHERE partner_distribution.id = @Partner_Distribution_ID AND segmentsgroup_details.NumberOfMembers = @MaxMembers)"
                + "     ELSE"
                + "         (SELECT segmentsgroup_details.amount"
                + "         FROM segmentsgroup_details"
                + "         LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + "         WHERE partner_distribution.id = @Partner_Distribution_ID AND segmentsgroup_details.NumberOfMembers = t1.`عدد المستفيدين`)"
                + " END AS 'المبلغ'"
                + " FROM"
                + "(SELECT family.id as 'Family ID', family.code as 'رمز العائلة',"
                + " (SELECT person.first_Name " +
 "FROM person_family left join person on person_family.person_id = person.id " +
 "where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'الاسم',"

                 + " (SELECT person.father_name " +
 "FROM person_family left join person on person_family.person_id = person.id " +
 "where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'اسم الاب',"

                 + " (SELECT person.last_name " +
 "FROM person_family left join person on person_family.person_id = person.id " +
 "where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'الكنية',"

                + " (SELECT person.national_Number " +
 "FROM person_family left join person on person_family.person_id = person.id " +
 "where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'الرقم الوطني',"

                + " (select familymembersnumber.NumberOfBeneficiaries from familymembersnumber where familymembersnumber.family_id = family.id order by familymembersnumber.date DESC, familymembersnumber.id DESC limit 1) AS 'عدد المستفيدين' ,"
                + " (case when family.mobile = '' then family.landline else family.mobile End) as 'رقم الهاتف'  "

                + " FROM person LEFT JOIN person_family on person_family.person_id = person.id"
                + " LEFT JOIN family on person_family.family_id = family.id"
                + " LEFT JOIN family_partner on family_partner.family_id = family.id"
                + " LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id"
                + " WHERE partner_donor.partner_id = @Partner_ID and partner_donor.donor_id = @Donor_ID and family_partner.IsActive = '1' GROUP BY family.id) AS t1 ORDER BY `عدد المستفيدين`";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);

            Program.MyConn.Close();
            return dt;
        }

        public DataTable Get_Approved_Signitaure_List(int Partner_ID, int Donor_ID, int Partner_Distribution_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_Distribution_ID", Partner_Distribution_ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);

            query = "SET @MaxMembers = (SELECT MAX(segmentsgroup_details.NumberOfMembers)"
                + " FROM segmentsgroup_details"
                + " LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + " LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + " LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + " LEFT JOIN partner_donor ON partner_donor.id = partner_distribution.partner_donor_id"
                + " WHERE partner_distribution.id = @Partner_Distribution_ID " 
                + " AND partner_donor.donor_id = @Donor_ID "
                + " AND partner_donor.partner_id = @Partner_ID);"
                
                + " SELECT t1.`ID`, t1.`Family ID`" 
                      + ", t1.`رمز العائلة`, t1.`الاسم`, t1.`اسم الاب`, t1.`الكنية`" 
                      + ", t1.`الرقم الوطني`, t1.`عدد المستفيدين`, t1.`رقم الهاتف`"

                + " ,CASE"
                + "     WHEN t1.`عدد المستفيدين` >= @MaxMembers THEN"
                + "        (SELECT segmentsgroup_details.amount"
                + "         FROM segmentsgroup_details"
                + "         LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + "         LEFT JOIN partner_donor ON partner_donor.id = partner_distribution.partner_donor_id"
                + "         WHERE partner_distribution.id = @Partner_Distribution_ID AND segmentsgroup_details.NumberOfMembers = @MaxMembers AND partner_donor.donor_id = @Donor_ID and partner_donor.partner_id = @Partner_ID)"
                + "     ELSE"
                + "         (SELECT segmentsgroup_details.amount"
                + "         FROM segmentsgroup_details"
                + "         LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + "         LEFT JOIN partner_donor ON partner_donor.id = partner_distribution.partner_donor_id"
                + "         WHERE partner_distribution.id = @Partner_Distribution_ID AND partner_donor.donor_id = @Donor_ID and partner_donor.partner_id = @Partner_ID AND segmentsgroup_details.NumberOfMembers = t1.`عدد المستفيدين`)"
                + " END AS 'المبلغ', t1.`RecievedMoney`, t1.`IsDirty`"
                + " FROM"
                + " (SELECT signature_list.id as 'ID', family.id as 'Family ID', family.code as 'رمز العائلة',"

                 + " (SELECT person.first_Name " +
"FROM person_family left join person on person_family.person_id = person.id " +
"where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'الاسم',"

                + " (SELECT person.father_name " +
"FROM person_family left join person on person_family.person_id = person.id " +
"where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'اسم الاب',"

                + " (SELECT person.last_name " +
"FROM person_family left join person on person_family.person_id = person.id " +
"where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'الكنية',"

                + " (SELECT person.national_Number " +
"FROM person_family left join person on person_family.person_id = person.id " +
"where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'الرقم الوطني'," 
                + " signature_list.NumberOfBeneficiaries AS 'عدد المستفيدين',"
                + " (case when family.mobile = '' then family.landline else family.mobile End) as 'رقم الهاتف', "

                + " signature_list.RecievedMoney as 'RecievedMoney', 0 as 'IsDirty'"

                + " FROM signature_list LEFT JOIN family ON signature_list.family_id = family.id"
                + " LEFT JOIN person_family on person_family.family_id = family.id"
                + " LEFT JOIN person on person_family.person_id = person.id"
                + " WHERE signature_list.partner_distribution_id = @Partner_Distribution_ID GROUP BY family.id) as t1 ORDER BY `رمز العائلة`";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);

            Program.MyConn.Close();
            return dt;
        }

        public DataTable Get_AdditionalFamilies_Signitaure_List(int Partner_ID,int Donor_ID, int Partner_Distribution_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);
            sc.Parameters.AddWithValue("@Partner_Distribution_ID", Partner_Distribution_ID);

            query = "SET @MaxMembers = (SELECT MAX(segmentsgroup_details.NumberOfMembers)"
                + " FROM segmentsgroup_details"
                + " LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + " LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + " LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + " WHERE partner_distribution.id = @Partner_Distribution_ID) ;"
                + "SELECT t2.*,"
                + " CASE"
                + "     WHEN t2.NumberOfBeneficiaries >= @MaxMembers THEN"
                + "        (SELECT segmentsgroup_details.amount"
                + "         FROM segmentsgroup_details"
                + "        LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + "         WHERE partner_distribution.id = @Partner_Distribution_ID AND segmentsgroup_details.NumberOfMembers = @MaxMembers)"
                + "     ELSE"
                + "         (SELECT segmentsgroup_details.amount"
                + "         FROM segmentsgroup_details"
                + "         LEFT JOIN segmentsgroup ON segmentsgroup_details.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN distribution ON distribution.segmentsgroup_id = segmentsgroup.id"
                + "         LEFT JOIN partner_distribution ON partner_distribution.distribution_id = distribution.id"
                + "         WHERE partner_distribution.id = @Partner_Distribution_ID AND segmentsgroup_details.NumberOfMembers = t2.NumberOfBeneficiaries)"
                + " END AS 'Amount'"
                + " FROM"
                + "(SELECT family.id as 'Family ID',family.code as 'Family Code',"

                + " (SELECT person.first_Name FROM person_family left join person on person_family.person_id = person.id where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'Reciever_FirstName',"
                + " (SELECT person.father_name FROM person_family left join person on person_family.person_id = person.id where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'Reciever_FatherName',"
                + " (SELECT person.last_name FROM person_family left join person on person_family.person_id = person.id where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'Reciever_LastName',"
                + " (SELECT person.national_Number FROM person_family left join person on person_family.person_id = person.id where person_family.family_id = `Family ID` and person_family.isReceiver = '1') as 'National Number',"
                + " (SELECT COUNT(person_family.id) FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = family.id and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active')) AS 'NumberOfBeneficiaries' ,"
                 + " (case when family.mobile = '' then family.landline else family.mobile End) as 'Mobile Number' "
                + " FROM person LEFT JOIN person_family on person_family.person_id = person.id"
                + " LEFT JOIN family on person_family.family_id = family.id"
                + " LEFT JOIN family_partner on family_partner.family_id = family.id"
                + " LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id"
                + " LEFT JOIN donor on donor.id = partner_donor.donor_id"
                + " LEFT JOIN partner on partner.id = partner_donor.partner_id"
                + " LEFT JOIN (SELECT family.id as family_id"
                + " FROM signature_list LEFT JOIN family ON signature_list.family_id = family.id"
                + " LEFT JOIN person_family on person_family.family_id = family.id"
                + " LEFT JOIN person on person_family.person_id = person.id"
                + " WHERE signature_list.partner_distribution_id = @Partner_Distribution_ID) as t1 on t1.family_id = family.id"

                + " WHERE partner.id = @Partner_ID AND donor.id = @Donor_ID AND family_partner.IsActive = '1' and t1.family_id is null GROUP BY family.id) AS t2 ORDER BY NumberOfBeneficiaries;";


            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);

            Program.MyConn.Close();
            return dt;
        }

        public void Insert_Signitaure_List(string Signature_List_Query, int Partner_Distribution_ID, int Partner_ID, int Distribution_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_Distribution_ID", Partner_Distribution_ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "INSERT INTO signature_list (partner_distribution_id, family_id, NumberOfBeneficiaries) VALUES " + Signature_List_Query + ";";
            query += " UPDATE partner_distribution SET listapproved = '1' WHERE id = @Partner_Distribution_ID;";

            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('Partner ID = ', @Partner_ID), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Signitaure_List(string Signature_List_Query, int Partner_Distribution_ID, int Partner_ID, int Distribution_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Partner_Distribution_ID", Partner_Distribution_ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += Signature_List_Query;
            query += " UPDATE partner_distribution SET recievedmoneyapproved = '1' WHERE id = @Partner_Distribution_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Distribution ID = ', @Distribution_ID), CONCAT('Partner ID = ', @Partner_ID), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public DataTable Get_Work_Schedule(string Year,int donor)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Year", Year);
            sc.Parameters.AddWithValue("@donor", donor);

            query = "CALL `work_schedule`(@Year,@donor);";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);

            Program.MyConn.Close();
            return dt;
        }

        public void Insert_SegmentsGroup(string Name, int Default, string SegmentsGroup_Query, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Default", Default);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (Default == 1)
                query += "UPDATE segmentsgroup SET IsDefault = '0';";

            query += " INSERT INTO segmentsgroup (name, IsDefault)"
                + " VALUES (trim(@Name), @Default);"
                + " SET @segmentsgroup_id = Last_Insert_ID();";

            if (SegmentsGroup_Query != "")
                query += " INSERT INTO segmentsgroup_details (segmentsgroup_id, NumberOfMembers, amount) VALUES " + SegmentsGroup_Query + ";";


            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }


            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('SegmentsGroup ID = ', @segmentsgroup_id), CONCAT('SegmentsGroup Name = ', @Name), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            if (Default == 1)
                query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('SegmentsGroup ID = ', @SegmentsGroup_ID), CONCAT('SegmentsGroup Name = ', @Name), 'Set as default', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";


            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_SegmentsGroup(string EditSegmentsGroup_Query, string Group_Name, int Group_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Group_ID", Group_ID);
            sc.Parameters.AddWithValue("@Group_Name", Group_Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            query += EditSegmentsGroup_Query;

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('SegmentsGroup ID = ', @Group_ID), CONCAT('SegmentsGroup Name = ', @Group_Name), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_DefaultGroup(int Group_ID, string Group_Name, int Default, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Group_ID", Group_ID);
            sc.Parameters.AddWithValue("@Group_Name", Group_Name);
            sc.Parameters.AddWithValue("@Default", Default);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (Default == 1)
                query += "UPDATE segmentsgroup SET IsDefault = '0';";

            query += " UPDATE segmentsgroup SET IsDefault = @Default WHERE id = @Group_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('SegmentsGroup ID = ', @Group_ID), CONCAT('SegmentsGroup Name = ', @Group_Name), 'Set as default', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";


            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_SegmentsGroup(int Group_ID, string Group_Name, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Group_ID", Group_ID);
            sc.Parameters.AddWithValue("@Group_Name", Group_Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE from segmentsgroup where `ID` = @Group_ID;";

            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }
            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('SegmentsGroup ID = ', @Group_ID), CONCAT('SegmentsGroup Name = ', @Group_Name), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

    }
}
