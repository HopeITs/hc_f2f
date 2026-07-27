using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using F2F_Application.Classes;
using MySql.Data.MySqlClient;
using static F2F_Application.Classes.Statistics;

namespace F2F_Application
{
    internal class MySQLQueryExecutor
    {
        //Family General Info
        internal Statistics.LivingWithFamilyData GetLivingWithFamilyData(string condition)
        {
            Program.buildConnection();
            LivingWithFamilyData data = new LivingWithFamilyData();

            string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا'," +
                           "   SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم'" +
                           "   FROM (" +
                           "   SELECT DISTINCT family.id, family.LivingWithFamily ,family.parish_id" +
                           "   FROM family" +
                           "   LEFT JOIN family_visit ON family_visit.family_id = family.id" +
                           "   LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                           "   LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                           "   LEFT JOIN donor ON donor.id = partner_donor.donor_id" + condition + 
                           "   ) AS family ;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data.NoCount = reader.GetInt32("لا");
                    data.YesCount = reader.GetInt32("نعم");
                }

                return data;
            }
        }
 
        internal List<Statistics.MemberInsideFamilyData> GetMemberInsideFamilyData(string condition ,string numbertype)
        {
            Program.buildConnection();
            List<MemberInsideFamilyData> dataList = new List<MemberInsideFamilyData>();
            //string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا', SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم' " +
            //                " FROM family" +
            //                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
            //                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
            //                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
            //                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
            //                  condition;

            string query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
                " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
                " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
                " GROUP BY numofmembers_marks.numbers;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int numberOfMembers = Convert.ToInt32(reader["numbers"]);
                    int familyCount = Convert.ToInt32(reader["family_count"]);
                    dataList.Add(new MemberInsideFamilyData { MemberCount = numberOfMembers, FamilyCount = familyCount });
                }
                return dataList;
            }
        }

        internal List<Statistics.FamilyInsideParishData> GetFamilyInsideParishData(string condition, string numbertype)
        {
            Program.buildConnection();
            List<FamilyInsideParishData> dataList = new List<FamilyInsideParishData>();
          
            string query = " SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(parish.name, 'N/A') AS parish" +
                           " FROM family LEFT JOIN parish on parish.id = family.parish_id" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id " +
                           " LEFT JOIN family_visit on family_visit.family_id = family.id " + condition +
                           " GROUP BY parish.name;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string parishes = reader["parish"].ToString() ;
                    int familyCount = Convert.ToInt32(reader["family_count"]);
                    dataList.Add(new FamilyInsideParishData { ParishName = parishes, FamilyCount = familyCount });
                }
                return dataList;
            }
        }

        internal Statistics.Data GetData(string condition, string conditionPerson , string numbertype)
        {
            Program.buildConnection();
            Data data = new Data();

            string query = "SELECT " + numbertype + "(DISTINCT family.id) as TotalFamilyCount from family" +
                            " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                            " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                            " LEFT JOIN donor on donor.id = partner_donor.donor_id " + condition + ";";
            string query1 = "SELECT COUNT(DISTINCT person_family.person_id) / COUNT(DISTINCT family.id) as 'BeneficiariesAverage' " +
                        " FROM person_family" +
                        " LEFT JOIN person on person.id = person_family.person_id" +
                        " LEFT JOIN family on family.id = person_family.family_id" +
                        " LEFT JOIN person_state on person_state.person_id = person.id" +
                        " LEFT JOIN personstate on personstate.id = person_state.personstate_id" +
                        " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                        " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                        " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                        " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                        " LEFT JOIN parish on parish.id = family.parish_id " + condition + 
                        " and personstate.type LIKE 'Active';";
            string query2 = "SELECT SUM(DISTINCT family_visitdetails.amper_number_7_home) * 85000 * 52 as 'YearlyPowerCost' " +
                            " FROM family_visitdetails" +
                            " LEFT JOIN family_visit on family_visit.id = family_visitdetails.family_visit_id " +
                            " LEFT JOIN family on family.id = family_visit.family_id" +
                            " LEFT JOIN aidsource on aidsource.id = family_visitdetails.aidsource_16" +
                            " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish on parish.id = family.parish_id" +
                            " LEFT JOIN donor on donor.id = partner_donor.donor_id " + condition + ";";
            
            
            string query3 = @"SELECT AVG(YEAR(CURRENT_DATE) - YEAR(person.DOB)) AS AverageAgeAids  
                                FROM family_visitdetails
                                LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id  
                                LEFT JOIN person_visitdetails ON person_visitdetails.family_visit_id = family_visit.id  
                                LEFT JOIN person ON person.id = person_visitdetails.person_id  
                                LEFT JOIN person_family ON person_family.person_id = person.id 
                                LEFT JOIN family ON family.id = person_family.family_id  
                                LEFT JOIN family_partner ON family_partner.family_id = family.id
                                LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                                LEFT JOIN donor ON donor.id = partner_donor.donor_id
                                LEFT JOIN person_state ON person_state.person_id = person.id
                                LEFT JOIN personstate ON personstate.id = person_state.personstate_id 
                                " + condition + " AND personstate.type LIKE 'Active' AND person_state.current_state = 1;";

            string query4 = "SELECT AVG(YEAR(CURRENT_DATE) - YEAR(person.DOB)) as AverageAgePerson" +
                            " FROM person " +
                            " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id" +
                            " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" +
                            " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                            " LEFT JOIN family on family.id = family_visit.family_id" +
                            " LEFT JOIN person_family on person_family.family_id = family.id" +
                            " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                            " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                            " LEFT JOIN person_state ON person_state.person_id = person.id" +
                            " LEFT JOIN personstate on person_state.personstate_id = personstate.id" +
                            " LEFT JOIN person_maritalstatus on person_maritalstatus.person_id = person.id" +
                            " LEFT JOIN maritalstatus on maritalstatus.id = person_maritalstatus.maritalstatus_id"
                            + condition + conditionPerson + ";";

            string query5 = "Select Count(person.id) as TotalMemberCount from person";

            string query6 = "Select " + numbertype + "(DISTINCT person.id) as 'TotalMicroBenef'" +
                            " FROM person " +
                            " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id" +
                            " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" +
                            " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                            " LEFT JOIN family on family.id = family_visit.family_id" +
                            " LEFT JOIN person_family on person_family.family_id = family.id" +
                            " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                            " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                            " LEFT JOIN person_state ON person_state.person_id = person.id" +
                            " LEFT JOIN personstate on person_state.personstate_id = personstate.id" +
                            " LEFT JOIN person_maritalstatus on person_maritalstatus.person_id = person.id" +
                            " LEFT JOIN maritalstatus on maritalstatus.id = person_maritalstatus.maritalstatus_id"
                            + condition + conditionPerson + " and person_visitdetails.hasmicroproject = 1 ;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                MySqlCommand cmd3 = new MySqlCommand(query3, conn);
                MySqlCommand cmd4 = new MySqlCommand(query4, conn);
                MySqlCommand cmd5 = new MySqlCommand(query5, conn);
                MySqlCommand cmd6 = new MySqlCommand(query6, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("TotalFamilyCount")))
                            data.TotalFamilyCount = reader.GetInt32("TotalFamilyCount");
                    }
                }
                reader.Close();

                MySqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    if (reader1.Read())
                    {
                        if (!reader1.IsDBNull(reader1.GetOrdinal("BeneficiariesAverage")))
                            data.BeneficiariesAverage = reader1.GetInt32("BeneficiariesAverage");
                    }
                }
                reader1.Close();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.HasRows)
                {
                    if (reader2.Read())
                    {
                        if (!reader2.IsDBNull(reader2.GetOrdinal("YearlyPowerCost")))
                            data.YearlyPowerCost = reader2.GetInt32("YearlyPowerCost");
                    }
                }
                reader2.Close();
                MySqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.HasRows)
                {
                    if (reader3.Read())
                    {
                        if (!reader3.IsDBNull(reader3.GetOrdinal("AverageAgeAids")))
                        {
                            data.AverageAgeAids = reader3.GetInt32("AverageAgeAids");
                        }
                    }
                }
                reader3.Close();

                MySqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.HasRows)
                {
                    while (reader4.Read())
                    {
                        if (!reader4.IsDBNull(reader4.GetOrdinal("AverageAgePerson"))){
                            data.AverageAgePerson = reader4.GetInt32("AverageAgePerson");
                        }
                    }
                }
                reader4.Close();

                MySqlDataReader reader5 = cmd5.ExecuteReader();
                if (reader5.HasRows)
                {
                    if (reader5.Read())
                    {
                        if (!reader5.IsDBNull(reader5.GetOrdinal("TotalMemberCount")))
                        {
                            data.TotalMemberCount = reader5.GetInt32("TotalMemberCount");
                        }
                    }
                }
                reader5.Close();

                MySqlDataReader reader6 = cmd6.ExecuteReader();
                if (reader6.HasRows)
                {
                    if (reader6.Read())
                    {
                        if (!reader6.IsDBNull(reader6.GetOrdinal("TotalMicroBenef")))
                        {
                            data.TotalMicroBenef = reader6.GetInt32("TotalMicroBenef");
                        }
                    }
                }
                reader6.Close();

                return data;
            }
        }
        

        //Power Info
        internal Statistics.HasAmperData GetHasAmperData(string condition)
        {
            Program.buildConnection();
            HasAmperData data = new HasAmperData();

            //string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا', SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم' " +
            //                " FROM family" +
            //                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
            //                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
            //                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
            //                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
            //                  condition;

            string query = @" SELECT SUM(CASE WHEN family_visitdetails.expenses_7_home = 0 THEN 1 ELSE 0 END) AS 'لا',
                              SUM(CASE WHEN family_visitdetails.expenses_7_home = 1 THEN 1 ELSE 0 END) AS 'نعم'
                              FROM(
                              SELECT DISTINCT family.id, family_visitdetails.expenses_7_home, family.parish_id
                              FROM family
                              LEFT JOIN family_visit ON family_visit.family_id = family.id
                              LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id
                              LEFT JOIN family_partner ON family_partner.family_id = family.id
                              LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                              LEFT JOIN donor ON donor.id = partner_donor.donor_id " + condition +
                              ") AS family_visitdetails; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data.NoCount = reader.GetInt32("لا");
                    data.YesCount = reader.GetInt32("نعم");
                }

                return data;
            }
        }

        internal Statistics.HasSolarPowerData GetHasSolarPowerData(string condition)
        {
            Program.buildConnection();
            HasSolarPowerData data = new HasSolarPowerData();

            //string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا', SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم' " +
            //                " FROM family" +
            //                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
            //                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
            //                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
            //                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
            //                  condition;

            string query = @" SELECT SUM(CASE WHEN family_visitdetails.expenses_17_home = 0 THEN 1 ELSE 0 END) AS 'لا',
                              SUM(CASE WHEN family_visitdetails.expenses_17_home = 1 THEN 1 ELSE 0 END) AS 'نعم'
                              FROM(
                              SELECT DISTINCT family.id, family_visitdetails.expenses_17_home, family.parish_id
                              FROM family
                              LEFT JOIN family_visit ON family_visit.family_id = family.id
                              LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id
                              LEFT JOIN family_partner ON family_partner.family_id = family.id
                              LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                              LEFT JOIN donor ON donor.id = partner_donor.donor_id " + condition +
                              ") AS family_visitdetails; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data.NoCount = reader.GetInt32("لا");
                    data.YesCount = reader.GetInt32("نعم");
                }

                return data;
            }
        }

        internal Statistics.HasBatteryData GetHasBatteryData(string condition)
        {
            Program.buildConnection();
            HasBatteryData data = new HasBatteryData();

            //string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا', SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم' " +
            //                " FROM family" +
            //                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
            //                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
            //                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
            //                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
            //                  condition;

            string query = @" SELECT SUM(CASE WHEN family_visitdetails.expenses_16_home = 0 THEN 1 ELSE 0 END) AS 'لا',
                              SUM(CASE WHEN family_visitdetails.expenses_16_home = 1 THEN 1 ELSE 0 END) AS 'نعم'
                              FROM(
                              SELECT DISTINCT family.id, family_visitdetails.expenses_16_home, family.parish_id
                              FROM family
                              LEFT JOIN family_visit ON family_visit.family_id = family.id
                              LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id
                              LEFT JOIN family_partner ON family_partner.family_id = family.id
                              LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                              LEFT JOIN donor ON donor.id = partner_donor.donor_id " + condition +
                              ") AS family_visitdetails; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data.NoCount = reader.GetInt32("لا");
                    data.YesCount = reader.GetInt32("نعم");
                }

                return data;
            }
        }

        internal Statistics.HasElectricityData GetHasElectricityData(string condition)
        {
            Program.buildConnection();
            HasElectricityData data = new HasElectricityData();

            //string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا', SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم' " +
            //                " FROM family" +
            //                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
            //                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
            //                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
            //                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
            //                  condition;

            string query = @" SELECT SUM(CASE WHEN family_visitdetails.isElectricity = 0 THEN 1 ELSE 0 END) AS 'لا',
                              SUM(CASE WHEN family_visitdetails.isElectricity = 1 THEN 1 ELSE 0 END) AS 'نعم'
                              FROM(
                              SELECT DISTINCT family.id, family_visitdetails.isElectricity, family.parish_id
                              FROM family
                              LEFT JOIN family_visit ON family_visit.family_id = family.id
                              LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id
                              LEFT JOIN family_partner ON family_partner.family_id = family.id
                              LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                              LEFT JOIN donor ON donor.id = partner_donor.donor_id " + condition +
                              ") AS family_visitdetails; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data.NoCount = reader.GetInt32("لا");
                    data.YesCount = reader.GetInt32("نعم");
                }

                return data;
            }
        }

        internal Statistics.HasAmperAidData GetHasAmperAidData(string condition)
        {
            Program.buildConnection();
            HasAmperAidData data = new HasAmperAidData();

            //string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا', SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم' " +
            //                " FROM family" +
            //                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
            //                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
            //                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
            //                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
            //                  condition;

            string query = @" SELECT SUM(CASE WHEN family_visitdetails.aid_4 = 0 THEN 1 ELSE 0 END) AS 'لا',
                              SUM(CASE WHEN family_visitdetails.aid_4 = 4 THEN 1 ELSE 0 END) AS 'نعم'
                              FROM(
                              SELECT DISTINCT family.id, family_visitdetails.aid_4, family.parish_id
                              FROM family
                              LEFT JOIN family_visit ON family_visit.family_id = family.id
                              LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id
                              LEFT JOIN family_partner ON family_partner.family_id = family.id
                              LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                              LEFT JOIN donor ON donor.id = partner_donor.donor_id " + condition +
                              ") AS family_visitdetails; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data.NoCount = reader.GetInt32("لا");
                    data.YesCount = reader.GetInt32("نعم");
                }

                return data;
            }
        }

        internal List<Statistics.AidsourceAmper> GetAidsourceAmperData(string condition, string numbertype)
        {
            Program.buildConnection();
            List<AidsourceAmper> dataList = new List<AidsourceAmper>();

            string query = " SELECT COALESCE(" + numbertype + "(DISTINCT family_visitdetails.id), 0) AS family_count, COALESCE(aidsource.name, 'NULL') AS aidsource" +
                           " FROM family_visitdetails" +
                           " LEFT JOIN family_visit on family_visit.id = family_visitdetails.family_visit_id " +
                           " LEFT JOIN family on family.id = family_visit.family_id" +
                           " LEFT JOIN aidsource on aidsource.id = family_visitdetails.aidsource_4" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN parish on parish.id = family.parish_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id " + condition +
                           " GROUP BY aidsource.name Order BY COUNT(family_visitdetails.id) DESC;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sources = reader["aidsource"].ToString();
                    int familyCount = Convert.ToInt32(reader["family_count"]);
                    dataList.Add(new AidsourceAmper { AidsourceName = sources, FamilyCount = familyCount });
                }
                return dataList;
            }
        }

        internal List<Statistics.AidsourcePower> GetAidsourcePowerData(string condition, string numbertype)
        {
            Program.buildConnection();
            List<AidsourcePower> dataList = new List<AidsourcePower>();

            string query = " SELECT COALESCE(" + numbertype + "(DISTINCT family_visitdetails.id), 0) AS family_count, COALESCE(aidsource.name, 'NULL') AS aidsource" +
                           " FROM family_visitdetails" +
                           " LEFT JOIN family_visit on family_visit.id = family_visitdetails.family_visit_id " +
                           " LEFT JOIN family on family.id = family_visit.family_id" +
                           " LEFT JOIN aidsource on aidsource.id = family_visitdetails.aidsource_16" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN parish on parish.id = family.parish_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id " + condition +
                           " GROUP BY aidsource.name Order BY COUNT(family_visitdetails.id) DESC;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sources = reader["aidsource"].ToString();
                    int familyCount = Convert.ToInt32(reader["family_count"]);
                    dataList.Add(new AidsourcePower { AidsourceName = sources, FamilyCount = familyCount });
                }
                return dataList;
            }
        }

        //Aid Info
        internal Statistics.Data GetAidData(string condition, string numbertype, string aidtype)
        {
            Program.buildConnection();
            Data data = new Data();

            string query = @"SELECT COALESCE(AVG(YEAR(CURRENT_DATE) - YEAR(person.DOB)), 0) AS AverageAgeAids  
                                FROM family_visitdetails
                                LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id  
                                LEFT JOIN person_visitdetails ON person_visitdetails.family_visit_id = family_visit.id  
                                LEFT JOIN person ON person.id = person_visitdetails.person_id  
                                LEFT JOIN person_family ON person_family.person_id = person.id 
                                LEFT JOIN family ON family.id = person_family.family_id  
                                LEFT JOIN family_partner ON family_partner.family_id = family.id
                                LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                                LEFT JOIN donor ON donor.id = partner_donor.donor_id
                                LEFT JOIN person_state ON person_state.person_id = person.id
                                LEFT JOIN personstate ON personstate.id = person_state.personstate_id 
                                LEFT JOIN parish ON parish.id = family.parish_id 
                                " + condition + " AND personstate.type LIKE 'Active' AND person_state.current_state = 1";
            if (aidtype == "سلة غذائية")
            {
                query += " and family_visitdetails.aidsource_11 <> 0 " +
                            " AND family_visitdetails.aidsource_11 IS NOT NULL;";
            }
            else if (aidtype == "وجبات طعام")
            {
                query += " and family_visitdetails.aidsource_20 <> 0 " +
                            " AND family_visitdetails.aidsource_20 IS NOT NULL;";
            }
            else if (aidtype == "رواتب مسنين")
            {
                query += " and family_visitdetails.aidsource_20 <> 0 " +
                            " AND family_visitdetails.aidsource_20 IS NOT NULL;";
            }
            else if (aidtype == "منظفات")
            {
                query += " and family_visitdetails.aidsource_12 <> 0 " +
                            " AND family_visitdetails.aidsource_12 IS NOT NULL;";
            }
            else if (aidtype == "بدل محروقات")
            {
                query += " and family_visitdetails.aidsource_14 <> 0 " +
                            " AND family_visitdetails.aidsource_14 IS NOT NULL;";
            }
            else if (aidtype == "ترميم")
            {
                query += " and family_visitdetails.aidsource_17_home <> 0 " +
                            " AND family_visitdetails.aidsource_17_home IS NOT NULL;";
            }
            else if (aidtype == "مساعدة أصدقاء")
            {
                query += " and family_visitdetails.income_relation_id_12 <> 0 " +
                            " AND family_visitdetails.income_relation_id_12 IS NOT NULL;";
            }
            
                using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data.AverageAgeAids = reader.GetInt32("AverageAgeAids");
                }
                reader.Close();
                return data;
            }
        }

        internal List<Statistics.AidnameCount> GetAidnameCountData(string condition, string numbertype, string aidtype)
        {
            Program.buildConnection();
            List<AidnameCount> dataList = new List<AidnameCount>();
            string query = "";
            if (aidtype == "N/A")
            {
                query = " SELECT 'سلة غذائية' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_11" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id"
                            + condition +
                            " and family_visitdetails.aidsource_11 <> 0 " +
                            " AND family_visitdetails.aidsource_11 IS NOT NULL" +
                            " UNION ALL" +
                            " SELECT 'منظفات' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_12" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_12 <> 0 " +
                            " AND family_visitdetails.aidsource_12 IS NOT NULL" +
                            " UNION ALL" +
                            " SELECT " +
                            "     'طعام' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_20" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id"
                            + condition +
                            " and family_visitdetails.aidsource_20 <> 0 " +
                            " AND family_visitdetails.aidsource_20 IS NOT NULL" +
                            " UNION ALL" +
                            " SELECT" +
                            "     'رواتب مسنين' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_19" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_19 <> 0 " +
                            " AND family_visitdetails.aidsource_19 IS NOT NULL" +
                            " UNION ALL" +
                            " SELECT" +
                            "     'ترميم' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_17_home" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_17_home <> 0 " +
                            " AND family_visitdetails.aidsource_17_home IS NOT NULL" +
                            " UNION ALL" +
                            " SELECT" +
                            "     'بدل محروقات' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_14" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_14 <> 0 " +
                            " AND family_visitdetails.aidsource_14 IS NOT NULL" +
                            " UNION ALL" +
                            " SELECT" +
                            "     'مساعدة أصدقاء' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.income_relation_id_12" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.income_relation_id_12 <> 0 " +
                            " AND family_visitdetails.income_relation_id_12 IS NOT NULL";
            }
            else if (aidtype == "سلة غذائية")
                query = " SELECT 'سلة غذائية' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_11" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id"
                            + condition +
                            " and family_visitdetails.aidsource_11 <> 0 " +
                            " AND family_visitdetails.aidsource_11 IS NOT NULL;";
            else if (aidtype == "وجبات طعام")
                query = " SELECT " +
                            "     'وجبات طعام' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_20" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id"
                            + condition +
                            " and family_visitdetails.aidsource_20 <> 0 " +
                            " AND family_visitdetails.aidsource_20 IS NOT NULL;";
            else if (aidtype == "رواتب مسنين")
                query = " SELECT" +
                            "     'رواتب مسنين' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_19" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_19 <> 0 " +
                            " AND family_visitdetails.aidsource_19 IS NOT NULL;";
            else if (aidtype == "منظفات")
                query = " SELECT 'منظفات' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_12" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_12 <> 0 " +
                            " AND family_visitdetails.aidsource_12 IS NOT NULL;";
            else if (aidtype == "بدل محروقات")
                query = " SELECT" +
                            "     'بدل محروقات' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_14" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_14 <> 0 " +
                            " AND family_visitdetails.aidsource_14 IS NOT NULL;";
            else if (aidtype == "ترميم")
                query = " SELECT" +
                            "     'ترميم' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_17_home" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_17_home <> 0 " +
                            " AND family_visitdetails.aidsource_17_home IS NOT NULL;";
            else if (aidtype == "مساعدة أصدقاء")
                query = " SELECT" +
                            "     'مساعدة أصدقاء' AS aid_name," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.income_relation_id_12" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.income_relation_id_12 <> 0 " +
                            " AND family_visitdetails.income_relation_id_12 IS NOT NULL;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string aid = reader["aid_name"].ToString();
                    int familyCount = Convert.ToInt32(reader["family_count"]);
                    dataList.Add(new AidnameCount { AidName = aid, FamilyCount = familyCount });
                }
                reader.Close();
                return dataList;
            }
        }

        internal List<Statistics.AidSourceCount> GetAidSourceCountData(string condition, string numbertype, string aidtype)
        {
            Program.buildConnection();
            List<AidSourceCount> dataList = new List<AidSourceCount>();
            string query = "";
            if (aidtype == "سلة غذائية" || aidtype == "N/A")
                query = " SELECT COALESCE(aidsource.name, 'N/A') AS aidsource," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_11" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id"
                            + condition +
                            " and family_visitdetails.aidsource_11 <> 0 " +
                            " AND family_visitdetails.aidsource_11 IS NOT NULL" +
                            " GROUP BY aidsource.name; ";
            else if (aidtype == "وجبات طعام")
                query = " SELECT COALESCE(aidsource.name, 'N/A') AS aidsource, " +
                             numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_20" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id"
                            + condition +
                            " and family_visitdetails.aidsource_20 <> 0 " +
                            " AND family_visitdetails.aidsource_20 IS NOT NULL" +
                            " GROUP BY aidsource.name; ";
            else if (aidtype == "رواتب مسنين")
                query = " SELECT COALESCE(aidsource.name, 'N/A') AS aidsource," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_19" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_19 <> 0 " +
                            " AND family_visitdetails.aidsource_19 IS NOT NULL" +
                            " GROUP BY aidsource.name; ";
            else if (aidtype == "منظفات")
                query = " SELECT COALESCE(aidsource.name, 'N/A') AS aidsource," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_12" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_12 <> 0 " +
                            " AND family_visitdetails.aidsource_12 IS NOT NULL" +
                            " GROUP BY aidsource.name; ";
            else if (aidtype == "بدل محروقات")
                query = " SELECT COALESCE(aidsource.name, 'N/A') AS aidsource," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_14" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_14 <> 0 " +
                            " AND family_visitdetails.aidsource_14 IS NOT NULL" +
                            " GROUP BY aidsource.name; ";
            else if (aidtype == "ترميم")
                query = " SELECT COALESCE(aidsource.name, 'N/A') AS aidsource," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.aidsource_17_home" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.aidsource_17_home <> 0 " +
                            " AND family_visitdetails.aidsource_17_home IS NOT NULL" +
                            " GROUP BY aidsource.name; ";
            else if (aidtype == "مساعدة أصدقاء")
                query = " SELECT COALESCE(aidsource.name, 'N/A') AS aidsource," + numbertype + "(DISTINCT family.id) AS family_count" +
                            " FROM family_visitdetails" +
                            " LEFT JOIN aidsource ON aidsource.id = family_visitdetails.income_relation_id_12" +
                            " LEFT JOIN family_visit ON family_visit.id = family_visitdetails.family_visit_id" +
                            " LEFT JOIN family ON family.id = family_visit.family_id" +
                            " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                            " LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                            " LEFT JOIN parish ON parish.id = family.parish_id" +
                            " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                            condition +
                            " and family_visitdetails.income_relation_id_12 <> 0 " +
                            " AND family_visitdetails.income_relation_id_12 IS NOT NULL" +
                            " GROUP BY aidsource.name; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string aidSource = reader["aidsource"].ToString();
                    int familyCount = Convert.ToInt32(reader["family_count"]);
                    dataList.Add(new AidSourceCount { AidSource = aidSource, FamilyCount = familyCount });
                }
                return dataList;
            }
        }

        internal List<Statistics.MemberInsideFamilyData> GetMemberInsideFamilyAidData(string condition, string numbertype, string aidtype)
        {
            Program.buildConnection();
            List<MemberInsideFamilyData> dataList = new List<MemberInsideFamilyData>();
            //string query = " SELECT SUM(CASE WHEN family.LivingWithFamily = 0 THEN 1 ELSE 0 END) AS 'لا', SUM(CASE WHEN family.LivingWithFamily = 1 THEN 1 ELSE 0 END) AS 'نعم' " +
            //                " FROM family" +
            //                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
            //                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
            //                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
            //                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
            //                  condition;
            string query = "";
            if (aidtype == "N/A" || aidtype == "سلة غذائية")
            {
                query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
                " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
                " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
                " and family_visitdetails.aidsource_11 <> 0 AND family_visitdetails.aidsource_11 IS NOT NULL" +
                " GROUP BY numofmembers_marks.numbers;";
            }
            else if (aidtype == "وجبات طعام")
            {
                query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
                " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
                " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
                " and family_visitdetails.aidsource_20 <> 0 AND family_visitdetails.aidsource_20 IS NOT NULL" +
                " GROUP BY numofmembers_marks.numbers;";
            }
            else if (aidtype == "رواتب مسنين")
            {
                query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
                " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
                " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
                " and family_visitdetails.aidsource_19 <> 0 AND family_visitdetails.aidsource_19 IS NOT NULL" +
                " GROUP BY numofmembers_marks.numbers;";
            }
            else if (aidtype == "منظفات")
            {
                query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
                " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
                " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
                " and family_visitdetails.aidsource_12 <> 0 AND family_visitdetails.aidsource_12 IS NOT NULL" +
                " GROUP BY numofmembers_marks.numbers;";
            }
            else if (aidtype == "بدل محروقات")
            {
                query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
                " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
                " LEFT JOIN family_visit on family_visit.family_id = family.id" +
                " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
                " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
                " and family_visitdetails.aidsource_14 <> 0 AND family_visitdetails.aidsource_14 IS NOT NULL" +
                " GROUP BY numofmembers_marks.numbers;";
            }
            else if (aidtype == "ترميم")
            {
                query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
               " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
               " LEFT JOIN family_visit on family_visit.family_id = family.id" +
               " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
               " LEFT JOIN family_partner on family_partner.family_id = family.id" +
               " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
               " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
               " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
               " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
               " and family_visitdetails.aidsource_17_home <> 0 AND family_visitdetails.aidsource_17_home IS NOT NULL" +
               " GROUP BY numofmembers_marks.numbers;";
            }
            else if (aidtype == "مساعدة أصدقاء")
            {
                query = "SELECT COALESCE(" + numbertype + "(DISTINCT family.id), 0) AS family_count, COALESCE(numofmembers_marks.numbers, 0) AS numbers" +
               " FROM person_family LEFT JOIN family ON family.id = person_family.family_id" +
               " LEFT JOIN family_visit on family_visit.family_id = family.id" +
               " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
               " LEFT JOIN family_partner on family_partner.family_id = family.id" +
               " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
               " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
               " LEFT JOIN numofmembers_marks ON numofmembers_marks.numbers = (" +
               " SELECT COUNT(*) FROM person_family WHERE person_family.family_id = family.id )" + condition +
               " and family_visitdetails.income_relation_id_12 <> 0 AND family_visitdetails.income_relation_id_12 IS NOT NULL" +
               " GROUP BY numofmembers_marks.numbers;";
            }

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int numberOfMembers = Convert.ToInt32(reader["numbers"]);
                    int familyCount = Convert.ToInt32(reader["family_count"]);
                    dataList.Add(new MemberInsideFamilyData { MemberCount = numberOfMembers, FamilyCount = familyCount });
                }
                return dataList;
            }
        }


        //Person General
        internal Statistics.PersonGenderData GetPersonGenderData(string condition,string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            PersonGenderData data = new PersonGenderData();
            
            string query = " SELECT " +
                            " COUNT(DISTINCT CASE WHEN person.sex_id = 1 THEN person.id ELSE NULL END) AS 'ذكر',"+
                            " COUNT(DISTINCT CASE WHEN person.sex_id = 2 THEN person.id ELSE NULL END) AS 'أنثى'" +
                           " FROM person " +
                           " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id" +
                           " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" +
                           " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family on family.id = family_visit.family_id" +
                           " LEFT JOIN person_family on person_family.family_id = family.id" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                           " LEFT JOIN person_state ON person_state.person_id = person.id" +
                           " LEFT JOIN personstate on person_state.personstate_id = personstate.id" +
                           " LEFT JOIN person_maritalstatus on person_maritalstatus.person_id = person.id" +
                           " LEFT JOIN maritalstatus on maritalstatus.id = person_maritalstatus.maritalstatus_id"
                           + condition + conditionPerson + ";";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data.MaleCount = reader.GetInt32("ذكر");
                    data.FemaleCount = reader.GetInt32("أنثى");
                }

                return data;
            }
        }

        internal List<Statistics.PersonStateData> GetPersonStateData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonStateData> dataList = new List<PersonStateData>();

            string query = " SELECT " + numbertype + "(DISTINCT person.id) AS member_count, CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE COALESCE(personstate.name, 'N/A') END AS state" +
                           " FROM person " +
                           " LEFT JOIN person_family on person_family.person_id = person.id" +
                           " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id" +
                           " LEFT JOIN family on family.id = person_family.family_id" +
                           " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" +
                           " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER JOIN personstate on person_state.personstate_id = personstate.id" +
                           " INNER JOIN person_maritalstatus on person_maritalstatus.person_id = person.id" +
                           " INNER JOIN maritalstatus on person_maritalstatus.maritalstatus_id = maritalstatus.id "
                            + condition + conditionPerson + " GROUP BY personstate.name order by "+ numbertype + "(DISTINCT person.id) desc; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader =  cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string states = reader["state"].ToString();
                        int MemberCount = Convert.ToInt32(reader["member_count"]);
                        dataList.Add(new PersonStateData { StateName = states, MemberCount = MemberCount });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonStateTypeData> GetPersonStateTypeData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonStateTypeData> dataList = new List<PersonStateTypeData>();

            string query = " SELECT 'مستفيد' AS 'status', " + numbertype + "(DISTINCT CASE WHEN personstate.type = 'Active' THEN person.id ELSE NULL END) AS member_count" +
                           " FROM person " +
                           " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id" +
                           " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" +
                           " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family on family.id = family_visit.family_id" +
                           " LEFT JOIN person_family on person_family.family_id = family.id" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER  JOIN personstate on person_state.personstate_id = personstate.id" +
                           " INNER  JOIN person_maritalstatus on person_maritalstatus.person_id = person.id" +
                           " INNER  JOIN maritalstatus on person_maritalstatus.maritalstatus_id = maritalstatus.id"
                            + condition + conditionPerson + " and personstate.type = 'Active'" +
                            " UNION ALL " +
                            " SELECT 'غير مستفيد' AS 'status', " + numbertype + "(DISTINCT CASE WHEN personstate.type = 'Disactive' THEN person.id ELSE NULL END) AS member_count" +
                           " FROM person " +
                           " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id" +
                           " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" +
                           " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family on family.id = family_visit.family_id" +
                           " LEFT JOIN person_family on person_family.family_id = family.id" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER  JOIN personstate on person_state.personstate_id = personstate.id" +
                           " INNER  JOIN person_maritalstatus on person_maritalstatus.person_id = person.id" +
                           " INNER  JOIN maritalstatus on person_maritalstatus.maritalstatus_id = maritalstatus.id"
                            + condition + conditionPerson + " and personstate.type = 'Disactive';"; 

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string status = reader["status"].ToString();
                        int count = Convert.ToInt32(reader["member_count"]);
                        dataList.Add(new PersonStateTypeData { StatusName = status, MemberCount = count });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonAgeGenderData> GetPersonAgeGenderData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonAgeGenderData> dataList = new List<PersonAgeGenderData>();

            string query = " SELECT IFNULL(agerange.name,'NULL') as 'name', " + numbertype + "(DISTINCT CASE WHEN person.sex_id = 1 THEN person.id ELSE NULL END) AS male_count," 
                           + numbertype + "(DISTINCT CASE WHEN person.sex_id = 2 THEN person.id ELSE NULL END) AS female_count " +
                           " FROM person " +
                           " LEFT JOIN agerange ON  (YEAR(CURRENT_DATE) - YEAR(person.DOB)) between agerange.min_age AND IFNULL(agerange.max_age, 200)" +
                           " LEFT JOIN person_family on person_family.person_id = person.id" +
                           " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id" +
                           " LEFT JOIN family on family.id = person_family.family_id" +
                           " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" +
                           " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family_partner on family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor on partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor on donor.id = partner_donor.donor_id" +
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER JOIN personstate on person_state.personstate_id = personstate.id" +
                           " INNER JOIN person_maritalstatus on person_maritalstatus.person_id = person.id" +
                           " INNER JOIN maritalstatus on person_maritalstatus.maritalstatus_id = maritalstatus.id"
                            + condition + conditionPerson + " AND agerange.id <> 0 GROUP BY agerange.name order by agerange.id; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string agerange_name = reader["name"].ToString();
                        int male_count = Convert.ToInt32(reader["male_count"]);
                        int female_count = Convert.ToInt32(reader["female_count"]);
                        dataList.Add(new PersonAgeGenderData { AgerangeName = agerange_name, MaleCount = male_count ,FemaleCount = female_count});
                    }
                }
                return dataList;
            }
        }

        //Person Work

        internal List<Statistics.PersonWorkData> GetPersonWorkData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonWorkData> dataList = new List<PersonWorkData>();

            string query = " SELECT "+
                           " workingStatus," +
                           numbertype + "(DISTINCT CASE WHEN person.sex_id = 1 THEN person.id ELSE NULL END) AS male_count," +
                           numbertype + "(DISTINCT CASE WHEN person.sex_id = 2 THEN person.id ELSE NULL END) AS female_count" +
                           " FROM person" +
                           " LEFT JOIN(" +
                           "     SELECT person.id AS person_id," +
                           "            CASE WHEN person_visitdetails.haswork = 1 THEN 'عاملين' ELSE 'غير عاملين' END AS workingStatus" +
                           "     FROM person" +
                           "     LEFT JOIN person_visitdetails ON person_visitdetails.person_id = person.id" +
                           " ) AS workStatus ON person.id = workStatus.person_id" +
                           " LEFT JOIN person_family ON person_family.person_id = person.id" +
                           " LEFT JOIN family ON family.id = person_family.family_id" +
                           " LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           " LEFT JOIN family_visitdetails ON family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                           " LEFT JOIN person_visitdetails ON person_visitdetails.person_id = person.id" + 
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER JOIN personstate ON person_state.personstate_id = personstate.id" +
                           " INNER JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id" +
                           " INNER JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id" 
                           + condition + conditionPerson + " AND personstate.type = 'Active' AND person_visitdetails.haswork = 1" +
                           " GROUP BY workingStatus; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string workingStatus = reader["workingStatus"].ToString();
                        int male_count = Convert.ToInt32(reader["male_count"]);
                        int female_count = Convert.ToInt32(reader["female_count"]);
                        dataList.Add(new PersonWorkData { workingStatus = workingStatus, MaleCount = male_count, FemaleCount = female_count });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonWorkPositionData> GetPersonWorkPositionData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonWorkPositionData> dataList = new List<PersonWorkPositionData>();

            string query = " SELECT " +
                           " workingPosition," +
                            numbertype + "(DISTINCT person.id) AS count" +
                           " FROM person" +
                           " LEFT JOIN(" +
                           "     SELECT person.id AS person_id," +
                           "            CASE WHEN person_workexp.workposition_id in (2,3,6) THEN 'صاحب عمل' " +
                           "            when person_workexp.workposition_id in (1,4,5) THEN 'عامل' ELSE 'N/A' END AS workingPosition" +           
                           "     FROM person" +
                           "     LEFT JOIN person_workexp on person_workexp.person_id = person.id" +
                           "     LEFT JOIN workposition ON workposition.id = person_workexp.workposition_id" +
                           " ) AS workingPosition ON person.id = workingPosition.person_id" +
                           " LEFT JOIN person_family ON person_family.person_id = person.id" +
                           " LEFT JOIN family ON family.id = person_family.family_id" +
                           " LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           " LEFT JOIN family_visitdetails ON family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER JOIN personstate ON person_state.personstate_id = personstate.id" +
                           " INNER JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id" +
                           " INNER JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id" +
                           " LEFT JOIN person_workexp on person_workexp.person_id = person.id" +
                           " LEFT JOIN workposition on workposition.id = person_workexp.workposition_id"+
                           " LEFT JOIN person_visitdetails ON person_visitdetails.person_id = person.id" 
                           + condition + conditionPerson + " AND personstate.type = 'Active' AND person_visitdetails.haswork = 1 " +
                           " GROUP BY workingPosition; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string workingPosition = reader["workingPosition"].ToString();
                        int Count = Convert.ToInt32(reader["count"]);
                        dataList.Add(new PersonWorkPositionData { workingPosition = workingPosition, Count = Count });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonWorkNameData> GetPersonWorkNameData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonWorkNameData> dataList = new List<PersonWorkNameData>();

            string query = " SELECT " +
                           " workexp.name as 'WorkName', " +
                           numbertype + "(DISTINCT person.id) AS MemberCount" + 
                           " FROM person" +
                           " LEFT JOIN person_family ON person_family.person_id = person.id" +
                           " LEFT JOIN family ON family.id = person_family.family_id" +
                           " LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           " LEFT JOIN family_visitdetails ON family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER JOIN personstate ON person_state.personstate_id = personstate.id" +
                           " INNER JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id" +
                           " INNER JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id" +
                           " LEFT JOIN person_workexp on person_workexp.person_id = person.id" +
                           " LEFT JOIN workexp on workexp.id = person_workexp.workexp_id"
                           + condition + conditionPerson + " AND workexp.id != 0 " +
                           " GROUP BY workexp.name ORDER BY "+ numbertype +"(DISTINCT person.id) DESC limit 10; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string WorkName = reader["WorkName"].ToString();
                        int Count = Convert.ToInt32(reader["MemberCount"]);
                        dataList.Add(new PersonWorkNameData { WorkName = WorkName, MemberCount = Count });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonMPAIDSourceData> GetPersonMPAidSourceData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonMPAIDSourceData> dataList = new List<PersonMPAIDSourceData>();

            string query = " SELECT " +
                           " aidsource.name AS AidName, " + numbertype + "(DISTINCT person_mp_aid.id) as Count" +
                           " FROM person" +
                           " LEFT JOIN person_family ON person_family.person_id = person.id" +
                           " LEFT JOIN family ON family.id = person_family.family_id" +
                           " LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           " LEFT JOIN family_visitdetails ON family_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                           " LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN person_state ON person_state.person_id = person.id" +
                           " LEFT JOIN person_mp_aid on  person_mp_aid.person_id = person.id" +
                           " LEFT JOIN person_visitdetails on  person_visitdetails.family_visit_id = family_visit.id" +
                           " INNER JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id" +
                           " INNER JOIN donor ON donor.id = partner_donor.donor_id" +
                           " INNER JOIN parish ON parish.id = family.parish_id" +
                           " INNER JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id" +
                           " INNER JOIN personstate ON person_state.personstate_id = personstate.id" +
                           " INNER JOIN aidsource on aidsource.id in (person_mp_aid.aidsource_5_mp,person_mp_aid.aidsource_17_mp,person_mp_aid.aidsource_22_mp)"
                           + condition + conditionPerson + " AND person_visitdetails.hasmicroproject = 1 " +
                           " GROUP BY aidsource.name ORDER BY " + numbertype + "(DISTINCT person_mp_aid.id) DESC;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string AidName = reader["AidName"].ToString();
                        int Count = Convert.ToInt32(reader["Count"]);
                        dataList.Add(new PersonMPAIDSourceData { AidName = AidName, Count = Count });
                    }
                }
                return dataList;
            }
        }

        //Person Disease

        internal List<Statistics.PersonDiseaseCatData> GetPersonDiseaseCatData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonDiseaseCatData> dataList = new List<PersonDiseaseCatData>();

            //string query = " SELECT DiseaseType, " +
            //               numbertype + "(DISTINCT person.id) AS Count" +
            //               " FROM person" +
            //               " LEFT JOIN (" +
            //               " SELECT person_disease.person_id AS person_id," +
            //               " CASE WHEN disease.isfatal = 1 THEN 'مميت'" +
            //               " when disease.isdisability = 1 THEN 'ذوي احتياج' END AS DiseaseType" +
            //               " FROM person_disease" +
            //               " LEFT JOIN disease ON disease.id = person_disease.disease_id" +
            //               " ) AS DiseaseType ON person.id = DiseaseType.person_id" +
            //               " LEFT JOIN person_family ON person_family.person_id = person.id" +
            //               " LEFT JOIN family ON family.id = person_family.family_id" +
            //               " LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
            //               " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
            //               " LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id" +
            //               " LEFT JOIN person_state ON person_state.person_id = person.id" +
            //               " LEFT JOIN person_visitdetails on  person_visitdetails.family_visit_id = family_visit.id" +
            //               " LEFT JOIN person_disease on person_disease.person_id = person.id" +
            //               " INNER JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id" +
            //               " INNER JOIN donor ON donor.id = partner_donor.donor_id" +
            //               " INNER JOIN parish ON parish.id = family.parish_id" +
            //               " INNER JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id" +
            //               " INNER JOIN personstate ON person_state.personstate_id = personstate.id" +
            //               " INNER JOIN disease on disease.id = person_disease.disease_id "
            //               + condition + conditionPerson + " AND person_visitdetails.hasdisease = 1 AND DiseaseType IS NOT NULL GROUP BY DiseaseType;";

            string query = 
                           " SELECT dt.DiseaseType, " + numbertype + "(DISTINCT person.id) AS Count" +
                           " FROM person"+
                           " LEFT JOIN (" +
                           " SELECT pd.person_id, " +
                           "            CASE" +
                           "               WHEN d.isfatal = 1 THEN 'مميت'" +
                           "               WHEN d.isdisability = 1 THEN 'ذوي احتياج'" +
                           "            END AS DiseaseType" +
                           "     FROM disease d" +
                           "     LEFT JOIN person_disease pd ON pd.disease_id = d.id" +
                           ") dt ON person.id = dt.person_id" +
                           " LEFT JOIN person_family pf ON pf.person_id = person.id" +
                           " LEFT JOIN family ON family.id = pf.family_id" +
                           " LEFT JOIN family_visit fv ON fv.family_id = pf.family_id" +
                           " LEFT JOIN family_partner fp ON fp.family_id = family.id" +
                           " LEFT JOIN partner_donor pd ON pd.partner_id = fp.partner_donor_id" +
                           " LEFT JOIN person_state ps ON ps.person_id = person.id" +
                           " LEFT JOIN person_visitdetails pvd ON pvd.family_visit_id = fv.id" +
                           " INNER JOIN person_maritalstatus pms ON pms.person_id = person.id" +
                           " INNER JOIN donor dnr ON dnr.id = pd.donor_id" +
                           " INNER JOIN parish pr ON pr.id = family.parish_id" +
                           " INNER JOIN maritalstatus ms ON ms.id = pms.maritalstatus_id" +
                           " INNER JOIN personstate pst ON ps.personstate_id = pst.id"
                            + condition + conditionPerson + " AND pvd.hasdisease = 1 AND dt.DiseaseType IS NOT NULL GROUP BY dt.DiseaseType; ";
         
            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string DiseaseType = reader["DiseaseType"].ToString();
                        int Count = Convert.ToInt32(reader["Count"]);
                        dataList.Add(new PersonDiseaseCatData { DiseaseType = DiseaseType, Count = Count });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonDiseaseNameData> GetPersonDiseaseNameData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonDiseaseNameData> dataList = new List<PersonDiseaseNameData>();

            string query = " SELECT " +
                           " disease.name as 'DiseaseName', " +
                           numbertype + "(DISTINCT person.id) AS MemberCount" +
                           " FROM person" +
                           " LEFT JOIN person_family ON person_family.person_id = person.id" +
                           " LEFT JOIN family ON family.id = person_family.family_id" +
                           " LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           " LEFT JOIN family_partner ON family_partner.family_id = family.id" +
                           " LEFT JOIN parish ON parish.id = family.parish_id" +
                           " LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id" +
                           " LEFT JOIN donor ON donor.id = partner_donor.donor_id" +
                           " INNER JOIN person_state ON person_state.person_id = person.id" +
                           " INNER JOIN person_disease on person_disease.person_id = person.id " +
                           " INNER JOIN personstate ON person_state.personstate_id = personstate.id" +
                           " INNER JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id" +
                           " INNER JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id" +
                           " LEFT JOIN disease on disease.id = person_disease.disease_id"
                           + condition + conditionPerson + " AND disease.id != 0 " +
                           " GROUP BY disease.name ORDER BY " + numbertype + "(DISTINCT person.id) DESC limit 10; ";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string DiseaseName = reader["DiseaseName"].ToString();
                        int Count = Convert.ToInt32(reader["MemberCount"]);
                        dataList.Add(new PersonDiseaseNameData { DiseaseName = DiseaseName, MemberCount = Count });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonDiseaseAidData> GetPersonDiseaseAidData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonDiseaseAidData> dataList = new List<PersonDiseaseAidData>();

            string query = "SELECT AidName, " + numbertype + "(DISTINCT person.id) AS Count " +
                           "  FROM person " +
                           "  LEFT JOIN " +
                           "  ( SELECT person_visitdetails.person_id AS person_id, CASE WHEN person_visitdetails.aidsource_21 <> 0 THEN 'علب أدوية' when person_visitdetails.aidsource_1 <> 0 THEN 'مبلغ أدوية' END AS AidName " +
                           "   FROM person_visitdetails" +
                           "  ) AS AidName ON person.id = AidName.person_id " +
                           "  LEFT JOIN person_family ON person_family.person_id = person.id " +
                           "  LEFT JOIN family ON family.id = person_family.family_id " +
                           "  LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           "  LEFT JOIN family_partner ON family_partner.family_id = family.id " +
                           "  LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id " +
                           "  LEFT JOIN person_state ON person_state.person_id = person.id" +
                           "  LEFT JOIN person_visitdetails on  person_visitdetails.family_visit_id = family_visit.id" +
                           "  LEFT JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id " +
                           "  LEFT JOIN donor ON donor.id = partner_donor.donor_id " +
                           "  LEFT JOIN parish ON parish.id = family.parish_id " +
                           "  LEFT JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id " +
                           "  LEFT JOIN personstate ON person_state.personstate_id = personstate.id" +
                              condition + conditionPerson + " AND person_visitdetails.hasdisease = 1 AND AidName IS NOT NULL GROUP BY AidName;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string AidName = reader["AidName"].ToString();
                        int Count = Convert.ToInt32(reader["Count"]);
                        dataList.Add(new PersonDiseaseAidData { AidName = AidName, MemberCount = Count });
                    }
                }
                return dataList;
            }
        }

        //Person Migration

        internal List<Statistics.PersonMigrateYearData> GetPersonMigrateYearData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonMigrateYearData> dataList = new List<PersonMigrateYearData>();

            string query = "SELECT " + numbertype + "(Distinct person_state.person_id) AS Count, person_state.personstate_year as Year" +
                           "  FROM person " +
                           "  LEFT JOIN person_family ON person_family.person_id = person.id " +
                           "  LEFT JOIN family ON family.id = person_family.family_id " +
                           "  LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           "  LEFT JOIN family_partner ON family_partner.family_id = family.id " +
                           "  LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id " +
                           "  LEFT JOIN person_state ON person_state.person_id = person.id" +
                           "  LEFT JOIN person_visitdetails on  person_visitdetails.family_visit_id = family_visit.id" +
                           "  LEFT JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id " +
                           "  LEFT JOIN donor ON donor.id = partner_donor.donor_id " +
                           "  LEFT JOIN parish ON parish.id = family.parish_id " +
                           "  LEFT JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id " +
                           "  LEFT JOIN personstate ON person_state.personstate_id = personstate.id" +
                              condition + conditionPerson + " AND person_state.personstate_id in (2,12) " +
                           " AND person_state.current_state = 1 AND person_state.personstate_year <> 0" +
                           " GROUP BY person_state.personstate_year ORDER BY person_state.personstate_year DESC Limit 20" +
                           " ;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string Year = reader["Year"].ToString();
                        int Count = Convert.ToInt32(reader["Count"]);
                        dataList.Add(new PersonMigrateYearData { Year = Year, MemberCount = Count });
                    }
                }
                return dataList;
            }
        }

        internal List<Statistics.PersonMigrateCountryData> GetPersonMigrateCountryData(string condition, string conditionPerson, string numbertype)
        {
            Program.buildConnection();
            List<PersonMigrateCountryData> dataList = new List<PersonMigrateCountryData>();

            string query = " SELECT " + numbertype + "(Distinct person_state.person_id) AS Count, stateaddress.name as Country" +
                           " FROM person " +
                           " LEFT JOIN person_family ON person_family.person_id = person.id " +
                           " LEFT JOIN family ON family.id = person_family.family_id " +
                           " LEFT JOIN family_visit ON family_visit.family_id = person_family.family_id" +
                           " LEFT JOIN family_partner ON family_partner.family_id = family.id " +
                           " LEFT JOIN partner_donor ON partner_donor.partner_id = family_partner.partner_donor_id " +
                           " LEFT JOIN person_state ON person_state.person_id = person.id" +
                           " LEFT JOIN person_visitdetails on  person_visitdetails.family_visit_id = family_visit.id" +
                           " LEFT JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id " +
                           " LEFT JOIN donor ON donor.id = partner_donor.donor_id " +
                           " LEFT JOIN parish ON parish.id = family.parish_id " +
                           " LEFT JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id " +
                           " LEFT JOIN personstate ON person_state.personstate_id = personstate.id" +
                           " LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id" +
                              condition + conditionPerson + " AND person_state.personstate_id in (2,12) " +
                           " AND person_state.current_state = 1 " +
                           " GROUP BY person_state.stateaddress_id" +
                           " ORDER BY " + numbertype + "(Distinct person_state.person_id) DESC Limit 10;";

            using (MySqlConnection conn = new MySqlConnection(Program.getConnString()))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string Country = reader["Country"].ToString();
                        int Count = Convert.ToInt32(reader["Count"]);
                        dataList.Add(new PersonMigrateCountryData { CountryName = Country, MemberCount = Count });
                    }
                }
                return dataList;
            }
        }
    }
}
