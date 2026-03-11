using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace F2F_Application.Classes
{
    class Categories
    {
        string query, condition, Ordered_By, log_query;

        public DataSet Select_Tables(List<string> Tables, bool WithNA)
        {
            query = "";
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i] == "partner-donor")
                {
                    //query += "SELECT partner_id as 'ID', partner.name as 'Name'"
                    //    + " From partner_donor"
                    //    + " LEFT JOIN partner on partner.id = partner_donor.partner_id "
                    //    + " LEFT JOIN donor on donor.id = partner_donor.donor_id"
                    //    + " Where partner_donor.donor_id = "+ Tables[i]+".id; ";
                }
                else
                {
                    query += "select id as 'ID', name as 'Name' from " + Tables[i] + " where 1";

                    if (!WithNA)
                    {
                        query += " AND id <> 0";
                    }

                    if (Tables[i] == "electricaldavices")
                    {
                        query += " AND id <> 0";
                    }



                    if (Tables[i] == "relation")
                        query += " ORDER BY name = 'N/A' desc, name = 'زوج/ة' desc, id asc;";
                    else
                        query += " ORDER BY id;";
                }
               
            }

            Program.buildConnection();
            MySqlDataAdapter Ad = new MySqlDataAdapter(query, Program.MyConn);
            DataSet ds = new DataSet();
            Ad.Fill(ds);
            Program.MyConn.Close();
            return ds;
        }

        public DataTable Select_Table(string Table, string Where, bool WithNA, bool EditMode)
        {
            if (Table == "disease")
            {
                query = "select disease.*, diseasecategory.name as 'Category'"
                    + " from disease join diseasecategory on disease.diseasecategory_id = diseasecategory.id";

                condition = " where 1";

                if (Where != "")
                    condition += " AND " + Where;

                if (!WithNA)
                {
                    condition += " AND disease.id <> 0";
                }

                Ordered_By = " ORDER BY disease.id";
            }
            else if (Table == "family")
            {
                query = "select id, code from family ORDER BY code;";
            }
            else if (Table == "donor_statis")
            {
                query = "select * from donor";
            }
            else if (Table == "sex_statis")
            {
                query = "select * from sex";
            }
            else if (Table == "maritalstatus_statis")
            {
                query = "select * from maritalstatus";
            }
            else if (Table == "maritalstatus_statis")
            {
                query = "select * from maritalstatus";
            }
            else if (Table == "personstate_statis")
            {
                query = "select * from personstate";
            }
            else if (Table == "agerange_statis")
            {
                query = "select * from agerange";
            }
            else if (Table == "migration_date")
            {
                query = @"SELECT 0 AS id, 'N/A' AS name UNION ALL SELECT (@i := @i + 1) AS id, f.personstate_year as name
                          FROM (Select DISTINCT(person_state.personstate_year) FROM person_state
                          WHERE person_state.personstate_year <> 0 AND person_state.personstate_year <> '' ORDER BY person_state.personstate_year DESC
                          ) as f,(SELECT @i:= 0) params; ";
            }
            else if (Table == "partner_donor")
            {
                condition = " where 1";

                if (Where != "")
                    condition += " AND " + Where;
                query = "select partner_donor.id as 'id',partner.name as 'Partner', donor.name as 'Donor'" +
                    " from partner_donor left join partner on partner_donor.partner_id = partner.id left join donor on partner_donor.donor_id = donor.id";
                Ordered_By = " ORDER BY id";
            }
            else
            {
                query = "select * from " + Table + "";


                condition = " where 1";

                if (Where != "")
                    condition += " AND " + Where;

                if (!WithNA && Table != "donor_statis")
                {
                    condition += " AND id <> 0";
                }

                if (Table == "electricaldavices")
                {
                    condition += " AND id <> 0";
                }


                if (EditMode)
                {
                    condition += " AND name NOT IN ('ابن/ة', 'زوج/ة', 'منفصل', 'مطلق', 'أرمل', 'عسكري', 'حكومي')";
                }

                Ordered_By = " ORDER BY id";
            }



            query += condition;
            query += Ordered_By;

            Program.buildConnection();
            MySqlDataAdapter Ad = new MySqlDataAdapter(query, Program.MyConn);
            DataTable dt = new DataTable();
            Ad.Fill(dt);
            Program.MyConn.Close();
            return dt;
        }

        public DataSet CheckIfExist (string Table, string partner,string donor,string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@partner", partner);
            sc.Parameters.AddWithValue("@donor", donor);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);
            
            query = "select id from partner_donor where partner_id = @partner and  donor_id =  @donor;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public void Insert_Into_Tabel(string Table, string Name, string EName, string state_type, int diseasecategory_id, int IsFatal, int IsDisability, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@EName", EName);
            sc.Parameters.AddWithValue("@state_type", state_type);
            sc.Parameters.AddWithValue("@diseasecategory_id", diseasecategory_id);
            sc.Parameters.AddWithValue("@IsFatal", IsFatal);
            sc.Parameters.AddWithValue("@IsDisability", IsDisability);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            if (Table == "disease")
            {
                query += "INSERT INTO disease (name, name_en, diseasecategory_id, isfatal, isdisability) VALUES (@Name, @EName, @diseasecategory_id, @IsFatal, @IsDisability);";
            }
            else if (Table == "personstate")
            {
                query += "INSERT INTO personstate (name, name_en, type) VALUES (@Name, @EName, @state_type);";
            }
            else if (Table == "partner_donor")
            {
                query += "INSERT INTO partner_donor (partner_id, donor_id) VALUES (@Name, @EName);";
            }
            else
            {
                query += "INSERT INTO " + Table + " (name, name_en) VALUES (@Name,  @EName);";
            }

            query += " set @ID = Last_Insert_ID();";


            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(Regex.Replace(p.Value.ToString(), "'", "''"), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('" + Table + " ID = ', @ID), CONCAT('Name = ', @Name), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Table(string Table, int ID, string Name, string EName, string state_type, int diseasecategory_id, int IsFatal, int IsDisability, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@EName", EName);
            sc.Parameters.AddWithValue("@state_type", state_type);
            sc.Parameters.AddWithValue("@diseasecategory_id", diseasecategory_id);
            sc.Parameters.AddWithValue("@IsFatal", IsFatal);
            sc.Parameters.AddWithValue("@IsDisability", IsDisability);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);


            query = " START TRANSACTION;";
            if (Table == "disease")
            {
                query += "UPDATE disease SET name = @Name, name_en = @EName, diseasecategory_id = @diseasecategory_id, isfatal = @IsFatal, isdisability = @IsDisability WHERE id = @ID;";
            }
            else if (Table == "personstate")
            {
                query += "UPDATE personstate SET name = @Name , name_en = @EName, type = @state_type WHERE id = @ID;";
            }
            else
            {
                query += "UPDATE " + Table + " SET name = @Name, name_en = @EName WHERE id = @ID;";
            }


            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('" + Table + " ID = ', @ID), CONCAT('Name = ', @Name), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();

        }

        public void Delete_From_table(string Table, int ID, string Name, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE from " + Table + " where `ID` = @ID;";

            log_query = Regex.Replace(query, "'", "''");

            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES ('" + Form_Name + "', 'DELETE', CONCAT('" + Table + " ID = ', @ID), CONCAT('Name = ', @Name), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
    }
}
