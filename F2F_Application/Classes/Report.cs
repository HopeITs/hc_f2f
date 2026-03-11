using MySql.Data.MySqlClient;
using System.Data;

namespace F2F_Application.Classes
{
    class Report
    {
        string query, selectQuery, fromQuery, joinQuery, groupbyQuery, notquery, notfromQuery;
        string where, whereMale, whereFemale, whereToddlers, whereChildren, whereYouth, whereElderlies, whereBelow18, whereBelow19,whereYouth60, whereElderlies60;
        public DataTable Get_Distributions(string Date, int Donor, int Partner)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Donor", Donor);
            sc.Parameters.AddWithValue("@Partner", Partner);
            if (Donor == 0 && Partner == 0)
            {
                query = "SELECT DISTINCT(distribution.id), CONCAT(distribution.Name, ' - ', DATE_FORMAT(distribution.date, '%M/%Y')) as 'name'"
                + " FROM distribution "
                + " LEFT JOIN partner_distribution on partner_distribution.distribution_id = distribution.id"
                + " WHERE partner_distribution.listapproved = '1' and partner_distribution.recievedmoneyapproved = '1' AND Year(distribution.date) = Year(STR_TO_DATE(@Date, '%d/%m/%Y'));";
            }
            else if(Donor != 0 && Partner == 0)
            {
                query = "SELECT DISTINCT(distribution.id), CONCAT(distribution.Name, ' - ', DATE_FORMAT(distribution.date, '%M/%Y')) as 'name'"
                + " FROM distribution "
                + " LEFT JOIN partner_distribution on partner_distribution.distribution_id = distribution.id"
                + " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id"
                + " WHERE partner_distribution.listapproved = '1' and partner_donor.donor_id = @Donor and partner_distribution.recievedmoneyapproved = '1' AND Year(distribution.date) = Year(STR_TO_DATE(@Date, '%d/%m/%Y'));";
            }
            else
            {
                query = "SELECT DISTINCT(distribution.id), CONCAT(distribution.Name, ' - ', DATE_FORMAT(distribution.date, '%M/%Y')) as 'name'"
                + " FROM distribution "
                + " LEFT JOIN partner_distribution on partner_distribution.distribution_id = distribution.id"
                + " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id"
                + " WHERE partner_distribution.listapproved = '1' and partner_donor.donor_id = @Donor and partner_donor.partner_id = @Partner and partner_distribution.recievedmoneyapproved = '1' AND Year(distribution.date) = Year(STR_TO_DATE(@Date, '%d/%m/%Y'));";
            }


            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }
        public DataSet Get_Families_Report(string condition)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@condition", condition);
            //sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);
            //sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            //selectQuery = "Select count(DISTINCT person.id) as 'count'";
            //if (Donor_ID != 0 && Partner_ID != 0)
            //{
            //fromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //" LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //" LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //" where partner_donor.partner_id = @Partner_ID and partner_donor.donor_id = @Donor_ID and RecievedMoney = 1  and signature_list.family_id is not null) as f1";
            //notfromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //" LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //" LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //" where partner_donor.partner_id = @Partner_ID and partner_donor.donor_id = @Donor_ID and RecievedMoney = 0  and signature_list.family_id is not null) as f1";
            //}
            //else if (Donor_ID != 0 && Partner_ID == 0)
            //{

            //fromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //" LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //" LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //" where partner_donor.donor_id = @Donor_ID and RecievedMoney = 1 and signature_list.family_id is not null) as f1";
            //notfromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //" LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //" LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //" where partner_donor.donor_id = @Donor_ID and RecievedMoney = 0 and signature_list.family_id is not null) as f1";
            //}
            //else
            //{
            //fromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //" LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //" LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //" where RecievedMoney = 1 and signature_list.family_id is not null) as f1";
            //notfromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //" LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //" LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //" where RecievedMoney = 0 and signature_list.family_id is not null) as f1";
            //}
            //joinQuery = " LEFT JOIN person_family on f1.family_id = person_family.family_id" +
            //" LEFT JOIN person on person.id = person_family.person_id " +
            //" LEFT JOIN person_state on person_state.person_id = person.id" +
            //" LEFT JOIN personstate on person_state.personstate_id = personstate.id" +
            //" LEFT JOIN signature_list on signature_list.family_id = person_family.family_id" + 
            //" LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //" LEFT JOIN distribution on distribution.id = partner_distribution.distribution_id";
            //where = " where person_family.family_id = f1.family_id and LOWER(personstate.type) = LOWER('Active') and person_state.current_state = 1 and f1.family_id is not null ";
            //whereMale = " And person.sex_id = 1";
            //whereFemale = " And person.sex_id = 2";
            //whereToddlers = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 0 and 5;";
            //whereChildren = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 6 and 17;";
            //whereYouth = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 18 and 59;";
            //whereElderlies = " AND (year(CURRENT_DATE) - year(person.DOB)) > 59;";

            ////المستلمين ذكور بين 0-5
            //query = selectQuery + fromQuery + joinQuery + where + whereMale + whereToddlers;
            ////غير المستلمين ذكور بين 0-5
            //query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereToddlers;
            ////المستلمين إناث بين 0-5
            //query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereToddlers;
            ////غير المستلمين إناث بين 0-5
            //query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereToddlers;
            ////المستلمين بين 0-5
            //query += selectQuery + fromQuery + joinQuery + where + whereToddlers;
            ////غير المستلمين بين 0-5
            //query += selectQuery + notfromQuery + joinQuery + where + whereToddlers;

            ////المستلمين ذكور بين 6-17
            //query += selectQuery + fromQuery + joinQuery + where + whereMale + whereChildren;
            ////غير المستلمين ذكور بين 6-17
            //query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereChildren;
            ////المستلمين إناث بين 6-17
            //query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereChildren;
            ////غير المستلمين إناث بين 6-17
            //query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereChildren;
            ////المستلمين بين 6-17
            //query += selectQuery + fromQuery + joinQuery + where + whereChildren;
            ////غير المستلمين بين 6-17
            //query += selectQuery + notfromQuery + joinQuery + where + whereChildren;

            ////المستلمين ذكور بين 18-59
            //query += selectQuery + fromQuery + joinQuery + where + whereMale + whereYouth;
            ////غير المستلمين ذكور بين 18-59
            //query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereYouth;
            ////المستلمين إناث بين 18-59
            //query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereYouth;
            ////غير المستلمين إناث بين 18-59
            //query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereYouth;
            ////المستلمين بين 18-59
            //query += selectQuery + fromQuery + joinQuery + where + whereYouth;
            ////غير المستلمين بين 18-59
            //query += selectQuery + notfromQuery + joinQuery + where + whereYouth;

            ////المستلمين ذكور بين 60 وفوق
            //query += selectQuery + fromQuery + joinQuery + where + whereMale + whereElderlies;
            ////غير المستلمين ذكور بين 60 وفوق
            //query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereElderlies;
            ////المستلمين إناث بين 60 وفوق
            //query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereElderlies;
            ////غير المستلمين إناث بين 60 وفوق
            //query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereElderlies;
            ////المستلمين بين 60 وفوق
            //query += selectQuery + fromQuery + joinQuery + where + whereElderlies;
            ////غير المستلمين بين 6- وفوق
            //query += selectQuery + notfromQuery + joinQuery + where + whereElderlies;

            ////المستلمين ذكور 
            //query += selectQuery + fromQuery + joinQuery + where + whereMale + ';';
            ////غير المستلمين ذكور 
            //query += selectQuery + notfromQuery + joinQuery + where + whereMale + ';';
            ////المستلمين إناث 
            //query += selectQuery + fromQuery + joinQuery + where + whereFemale + ';';
            ////غير المستلمين إناث 
            //query += selectQuery + notfromQuery + joinQuery + where + whereFemale + ';';
            ////المستلمين 
            //query += selectQuery + fromQuery + joinQuery + where + ';';
            ////غير المستلمين 
            //query += selectQuery + notfromQuery + joinQuery + where + ';';

            query = "SELECT "+
                   " العمر," +
                   " `مستفيدين -  ذكور`," +
                   " `غير مستفيدين -  ذكور`," +
                   " `مستفيدين -  إناث`," +
                   " `غير مستفيدين -  إناث`," +
                   " `مستفيدين - الإجمالي`," +
                   " `غير مستفيدين - الإجمالي` FROM (" +
                   "     SELECT " +
                   "         agerange.name AS 'العمر'," +
                   "         SUM(CASE WHEN person.sex_id = 1 AND LOWER(personstate.type) = LOWER('Active') THEN 1 ELSE 0 END) AS 'مستفيدين -  ذكور'," +
                   "         SUM(CASE WHEN person.sex_id = 1 AND LOWER(personstate.type) = LOWER('Disactive') THEN 1 ELSE 0 END) AS 'غير مستفيدين -  ذكور'," +
                   "         SUM(CASE WHEN person.sex_id = 2 AND LOWER(personstate.type) = LOWER('Active') THEN 1 ELSE 0 END) AS 'مستفيدين -  إناث'," +
                   "         SUM(CASE WHEN person.sex_id = 2 AND LOWER(personstate.type) = LOWER('Disactive') THEN 1 ELSE 0 END) AS 'غير مستفيدين -  إناث'," +
                   "         SUM(CASE WHEN LOWER(personstate.type) = LOWER('Active') THEN 1 ELSE 0 END) AS 'مستفيدين - الإجمالي'," +
                   "         SUM(CASE WHEN LOWER(personstate.type) = LOWER('Disactive') THEN 1 ELSE 0 END) AS 'غير مستفيدين - الإجمالي'," +
                   "         agerange.id AS order_col" +
                   "     FROM person" +
                   "     JOIN person_family ON person.id = person_family.person_id" +
                   "     JOIN family ON family.id = person_family.family_id" +
                   "     JOIN family_visit ON family_visit.family_id = family.id" +
                   "     JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                   "     JOIN family_partner ON family_partner.family_id = family.id" +
                   "     JOIN agerange ON (CASE WHEN YEAR(CURDATE()) - YEAR(person.DOB) = 0 THEN 1 ELSE YEAR(CURDATE()) - YEAR(person.DOB) END) BETWEEN agerange.min_age AND agerange.max_age" +
                   "     JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                   "     JOIN person_state ON person_state.person_id = person.id" +
                   "     JOIN personstate ON personstate.id = person_state.personstate_id" +
                   "     WHERE agerange.name <> 'N/A'" +
                   "     AND person_family.family_id = family.id" +
                   "     AND person_state.family_id = family.id" +
                   "         AND person_state.current_state = 1 " + condition +
                   "     GROUP BY" +
                   "         agerange.name, agerange.id" +
                   "     UNION ALL" +
                   "     SELECT" +
                   "         'الإجمالي' AS 'العمر'," +
                   "         SUM(CASE WHEN person.sex_id = 1 AND LOWER(personstate.type) = LOWER('Active') THEN 1 ELSE 0 END) AS 'مستفيدين -  ذكور'," +
                   "         SUM(CASE WHEN person.sex_id = 1 AND LOWER(personstate.type) = LOWER('Disactive') THEN 1 ELSE 0 END) AS 'غير مستفيدين -  ذكور'," +
                   "         SUM(CASE WHEN person.sex_id = 2 AND LOWER(personstate.type) = LOWER('Active') THEN 1 ELSE 0 END) AS 'مستفيدين -  إناث'," +
                   "         SUM(CASE WHEN person.sex_id = 2 AND LOWER(personstate.type) = LOWER('Disactive') THEN 1 ELSE 0 END) AS 'غير مستفيدين -  إناث'," +
                   "         SUM(CASE WHEN LOWER(personstate.type) = LOWER('Active') THEN 1 ELSE 0 END) AS 'مستفيدين - الإجمالي'," +
                   "         SUM(CASE WHEN LOWER(personstate.type) = LOWER('Disactive') THEN 1 ELSE 0 END) AS 'غير مستفيدين - الإجمالي'," +
                   "         9999 AS order_col" +
                   "    FROM person" +
                   "    JOIN person_family ON person.id = person_family.person_id" +
                   "    JOIN family ON family.id = person_family.family_id" +
                   "    JOIN family_visit ON family_visit.family_id = family.id" +
                   "    JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id" +
                   "    JOIN family_partner ON family_partner.family_id = family.id" +
                   "    JOIN agerange ON(CASE WHEN YEAR(CURDATE()) - YEAR(person.DOB) = 0 THEN 1 ELSE YEAR(CURDATE()) - YEAR(person.DOB) END) BETWEEN agerange.min_age AND agerange.max_age" +
                   "    JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id" +
                   "    JOIN person_state ON person_state.person_id = person.id" +
                   "    JOIN personstate ON personstate.id = person_state.personstate_id" +
                   "    WHERE agerange.name <> 'N/A'" +
                   "     AND person_family.family_id = family.id" +
                   "     AND person_state.family_id = family.id" +
                   "         AND person_state.current_state = 1 " + condition +
                   " ) AS combined_results" +
                   " ORDER BY order_col; ";

            
            //groupbyQuery = " GROUP BY f1.family_id;"; 
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }
        public DataSet Get_MemberAgeGender_Report(string VisitName, int Donor_ID, int Partner_ID, int IsSolar, int SolarDonor_ID, int IsRenovation, int RenovationDonor_ID, int Distriburion_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@VisitName", VisitName);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            sc.Parameters.AddWithValue("@IsSolar", IsSolar);
            sc.Parameters.AddWithValue("@SolarDonor_ID", SolarDonor_ID);
            sc.Parameters.AddWithValue("@IsRenovation", IsRenovation);
            sc.Parameters.AddWithValue("@RenovationDonor_ID", RenovationDonor_ID);
            sc.Parameters.AddWithValue("@Distriburion_ID", Distriburion_ID);

            query = "CALL Member_AgeGender(@VisitName,@Donor_ID,@Partner_ID ,@IsSolar, @SolarDonor_ID, @IsRenovation, @RenovationDonor_ID, @Distriburion_ID);";


            query += " Select * from agerange where name <> 'N/A';";
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }
        public DataSet Get_Differ_Report(int Distribution_ID, int Donor_ID, int Partner_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);

            query = "CALL Compare_Distributions(@Distribution_ID,@Donor_ID,@Partner_ID);";
            
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }
        public DataTable Get_Family_Distribution_Codes(int ID)
        {
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@ID", ID);

            if (ID == 0)
            {
                query = "Select family.code as 'العائلات' from family left join f3 on f3.family_id = family.id where f3.family_id is not null order by family.code;";

            }
            else if (ID == -1)
            {
                query = "Select family.code as 'العائلات' from family left join f3 on f3.family_id_1 = family.id where f3.family_id_1 is not null order by family.code;";
            }
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }
        public DataSet Get_Families_Distribution_Report(int Distribution_ID, int Donor_ID, int Partner_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Distribution_ID", Distribution_ID);
            sc.Parameters.AddWithValue("@Donor_ID", Donor_ID);
            sc.Parameters.AddWithValue("@Partner_ID", Partner_ID);
            selectQuery = "Select count(DISTINCT person.id) as 'count'";
            if (Donor_ID != 0 && Partner_ID != 0)
            {
                fromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
                            " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
                            " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
                            " where partner_donor.partner_id = @Partner_ID and partner_donor.donor_id = @Donor_ID and RecievedMoney = 1 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
                notfromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
                            " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
                            " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
                            " where partner_donor.partner_id = @Partner_ID and partner_donor.donor_id = @Donor_ID and RecievedMoney = 0 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
            }
            else if (Donor_ID != 0 && Partner_ID == 0)
            {

                fromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
                            " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
                            " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
                            " where partner_donor.donor_id = @Donor_ID and RecievedMoney = 1 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
                notfromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
                            " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
                            " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
                            " where partner_donor.donor_id = @Donor_ID and RecievedMoney = 0 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
            }
            //else if (Donor_ID == 0 && Partner_ID != 0)
            //{

            //    fromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //                " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //                " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //                " where partner_donor.partner_id = @Partner_ID and RecievedMoney = 1 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
            //    notfromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
            //                " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
            //                " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
            //                " where partner_donor.partner_id = @Partner_ID and RecievedMoney = 0 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
            //}
            else
            {
                fromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
                                            " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
                                            " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
                                            " where RecievedMoney = 1 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
                notfromQuery = " from ( SELECT signature_list.family_id FROM signature_list" +
                            " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
                            " LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id" +
                            " where RecievedMoney = 0 and partner_distribution.distribution_id = @Distribution_ID and signature_list.family_id is not null) as f1";
            }
            joinQuery = " LEFT JOIN person_family on f1.family_id = person_family.family_id" +
                        " LEFT JOIN person on person.id = person_family.person_id " +
                        " LEFT JOIN person_state on person_state.person_id = person.id" +
                        " LEFT JOIN personstate on person_state.personstate_id = personstate.id" +
                        " LEFT JOIN signature_list on signature_list.family_id = person_family.family_id" +
                        " LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id" +
                        " LEFT JOIN distribution on distribution.id = partner_distribution.distribution_id";
            where = " where person_family.family_id = f1.family_id and LOWER(personstate.type) = LOWER('Active') and f1.family_id is not null ";
            whereMale = " And person.sex_id = 1";
            whereFemale = " And person.sex_id = 2";
            whereToddlers = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 0 and 5;";
            whereChildren = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 6 and 17;";
            whereYouth = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 18 and 59;";
            whereElderlies = " AND (year(CURRENT_DATE) - year(person.DOB)) > 59;";
            whereBelow18 = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 0 and 17;";
            whereBelow19 = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 0 and 18;";
            whereYouth60 = " AND (year(CURRENT_DATE) - year(person.DOB)) BETWEEN 18 and 60;";
            whereElderlies60 = " AND (year(CURRENT_DATE) - year(person.DOB)) > 60;";

            //المستلمين ذكور بين 0-5
            query = selectQuery + fromQuery + joinQuery + where + whereMale + whereToddlers;
            //غير المستلمين ذكور بين 0-5
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereToddlers;
            //المستلمين إناث بين 0-5
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereToddlers;
            //غير المستلمين إناث بين 0-5
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereToddlers;
            //المستلمين بين 0-5
            query += selectQuery + fromQuery + joinQuery + where + whereToddlers;
            //غير المستلمين بين 0-5
            query += selectQuery + notfromQuery + joinQuery + where + whereToddlers;

            //المستلمين ذكور بين 6-17
            query += selectQuery + fromQuery + joinQuery + where + whereMale + whereChildren;
            //غير المستلمين ذكور بين 6-17
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereChildren;
            //المستلمين إناث بين 6-17
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereChildren;
            //غير المستلمين إناث بين 6-17
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereChildren;
            //المستلمين بين 6-17
            query += selectQuery + fromQuery + joinQuery + where + whereChildren;
            //غير المستلمين بين 6-17
            query += selectQuery + notfromQuery + joinQuery + where + whereChildren;

            //المستلمين ذكور بين 18-59
            query += selectQuery + fromQuery + joinQuery + where + whereMale + whereYouth;
            //غير المستلمين ذكور بين 18-59
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereYouth;
            //المستلمين إناث بين 18-59
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereYouth;
            //غير المستلمين إناث بين 18-59
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereYouth;
            //المستلمين بين 18-59
            query += selectQuery + fromQuery + joinQuery + where + whereYouth;
            //غير المستلمين بين 18-59
            query += selectQuery + notfromQuery + joinQuery + where + whereYouth;

            //المستلمين ذكور بين 60 وفوق
            query += selectQuery + fromQuery + joinQuery + where + whereMale + whereElderlies;
            //غير المستلمين ذكور بين 60 وفوق
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereElderlies;
            //المستلمين إناث بين 60 وفوق
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereElderlies;
            //غير المستلمين إناث بين 60 وفوق
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereElderlies;
            //المستلمين بين 60 وفوق
            query += selectQuery + fromQuery + joinQuery + where + whereElderlies;
            //غير المستلمين بين 6- وفوق
            query += selectQuery + notfromQuery + joinQuery + where + whereElderlies;

            //المستلمين ذكور 
            query += selectQuery + fromQuery + joinQuery + where + whereMale + ';';
            //غير المستلمين ذكور 
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + ';';
            //المستلمين إناث 
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + ';';
            //غير المستلمين إناث 
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + ';';
            //المستلمين 
            query += selectQuery + fromQuery + joinQuery + where + ';';
            //غير المستلمين 
            query += selectQuery + notfromQuery + joinQuery + where + ';';


            //المستلمين ذكور بين 0-17
            query += selectQuery + fromQuery + joinQuery + where + whereMale + whereBelow18;
            //غير المستلمين ذكور بين 0-17
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereBelow18;
            //المستلمين إناث بين 0-17
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereBelow18;
            //غير المستلمين إناث بين 0-17
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereBelow18;
            //المستلمين بين 0-17
            query += selectQuery + fromQuery + joinQuery + where + whereBelow18;
            //غير المستلمين بين 0-17
            query += selectQuery + notfromQuery + joinQuery + where + whereBelow18;

            //المستلمين ذكور بين 0-18
            query += selectQuery + fromQuery + joinQuery + where + whereMale + whereBelow19;
            //غير المستلمين ذكور بين 0-18
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereBelow19;
            //المستلمين إناث بين 0-18
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereBelow19;
            //غير المستلمين إناث بين 0-18
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereBelow19;
            //المستلمين بين 0-18
            query += selectQuery + fromQuery + joinQuery + where + whereBelow19;
            //غير المستلمين بين 0-18
            query += selectQuery + notfromQuery + joinQuery + where + whereBelow19;

            //6المستلمين ذكور بين 0-18
            query += selectQuery + fromQuery + joinQuery + where + whereMale + whereYouth60;
            //6غير المستلمين ذكور بين 0-18
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereYouth60;
            //6المستلمين إناث بين 0-18
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereYouth60;
            //غير المستلمين إناث بين 60-18
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereYouth60;
            //المستلمين بين 60-18
            query += selectQuery + fromQuery + joinQuery + where + whereYouth60;
            //غير المستلمين بين 60-18
            query += selectQuery + notfromQuery + joinQuery + where + whereYouth60;

            // 6المستلمين ذكور فوق 0 
            query += selectQuery + fromQuery + joinQuery + where + whereMale + whereElderlies60;
            //6غير المستلمين ذكور بين فوق 0 
            query += selectQuery + notfromQuery + joinQuery + where + whereMale + whereElderlies60;
            //6المستلمين إناث بين فوق 0
            query += selectQuery + fromQuery + joinQuery + where + whereFemale + whereElderlies60;
            //غير المستلمين إناث بين 60 فوق
            query += selectQuery + notfromQuery + joinQuery + where + whereFemale + whereElderlies60;
            //المستلمين بين 60 فوق
            query += selectQuery + fromQuery + joinQuery + where + whereElderlies60;
            //غير المستلمين بين 60 فوق
            query += selectQuery + notfromQuery + joinQuery + where + whereElderlies60;

            //groupbyQuery = " GROUP BY f1.family_id;"; 
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }
    }
    
}
