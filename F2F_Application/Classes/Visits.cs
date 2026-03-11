using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace F2F_Application.Classes
{
    class Visits
    {

        string query, log_query;

        public void Insert_Visit(int Family_ID, string VisitType, string Visit_Name, string Visite_State, string Scedualed_Visit_date, string Visit_date, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@VisitType", VisitType);
            sc.Parameters.AddWithValue("@Visit_Name", Visit_Name);
            sc.Parameters.AddWithValue("@Visite_State", Visite_State);
            if (string.IsNullOrWhiteSpace(Scedualed_Visit_date))
            {
                sc.Parameters.AddWithValue("@Scedualed_Visit_date", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@Scedualed_Visit_date", Scedualed_Visit_date);
            }
            if (string.IsNullOrWhiteSpace(Visit_date))
            {
                sc.Parameters.AddWithValue("@Visit_date", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@Visit_date", Visit_date);
            }
            //sc.Parameters.AddWithValue("@Scedualed_Visit_date", Scedualed_Visit_date);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "INSERT  INTO `family_visit`( `family_id`, `visittype_id`, `visit_name`, `visitstate_id`, `Scedualed_Visit_date`, `Visit_date`)"
                  + " SELECT @Family_ID, (SELECT id FROM visittype WHERE NAME = @VisitType), @Visit_Name, (SELECT id FROM visitstate WHERE name = @Visite_State), @Scedualed_Visit_date,@Visit_date;";

            //+ " SELECT @Family_ID, (SELECT id FROM visittype WHERE NAME = @VisitType), @Visit_Name, (SELECT id FROM visitstate WHERE name = @Visite_State), STR_TO_DATE(@Scedualed_Visit_date, '%d/%m/%Y',STR_TO_DATE(@Visit_date, '%d/%m/%Y');";


            query += "SET @family_visit_id = Last_Insert_ID();";
            query += "INSERT INTO `family_visitdetails`(`family_visit_id`) VALUES (@family_visit_id);";
            query += "SET @family_visitdetails_id = Last_Insert_ID();";
            query += "UPDATE family_visitdetails AS fv" +
                    " INNER JOIN family_visitdetails AS fv1 " +
                    " ON fv1.family_visit_id = (SELECT family_visit.id FROM family_visit WHERE family_visit.id < @family_visit_id and family_id = @Family_ID ORDER by family_visit.id desc LIMIT 1)" +
                    " set fv.hometype_id = fv1.hometype_id, " +
                    "fv.expenses_amount_6_12_home = fv1.expenses_amount_6_12_home," +
                    "fv.`expensestype_6_12_home` = fv1.`expensestype_6_12_home`," +
                    "fv.`aidsource_5_3_home` = fv1.`aidsource_5_3_home`," +
                    "fv.`aid_amount_5_3_home` = fv1.`aid_amount_5_3_home`," +
                    "fv.`aidperiod_5_3_home` = fv1.`aidperiod_5_3_home`," +
                    "fv.`parish_id_home` = fv1.`parish_id_home`," +
                    "fv.`heirs_number` = fv1.`heirs_number`," +
                    "fv.`expenses_amount_6_home2` = fv1.`expenses_amount_6_home2`," +
                    "fv.`expensestype_6_home2` = fv1.`expensestype_6_home2`," +
                    "fv.`home_description` = fv1.`home_description`," +
                    "fv.`isdisplaced_id` = fv1.`isdisplaced_id`," +
                    "fv.`rooms_number` = fv1.`rooms_number`," +
                    "fv.`expenses_7_home` = fv1.`expenses_7_home`," +
                    "fv.`amper_number_7_home` = fv1.`amper_number_7_home`," +
                    "fv.`expenses_amount_7_home` = fv1.`expenses_amount_7_home`," +
                    "fv.`aid_4` = fv1.`aid_4`," +
                    "fv.`aidsource_4` = fv1.`aidsource_4`," +
                    "fv.`aid_amount_4` = fv1.`aid_amount_4`," +
                    "fv.`aidperiod_4` = fv1.`aidperiod_4`," +
                    "fv.`expenses_16_home` = fv1.`expenses_16_home`," +
                    "fv.`expenses_17_home` = fv1.`expenses_17_home`," +
                    "fv.`amper_number_17_home` = fv1.`amper_number_17_home`," +
                    "fv.`aid_16` = fv1.`aid_16`," +
                    "fv.`aidsource_16` = fv1.`aidsource_16`," +
                    "fv.`aid_amount_16` = fv1.`aid_amount_16`," +
                    "fv.`aidperiod_16` = fv1.`aidperiod_16`," +
                    "fv.`isElectricity` = fv1.`isElectricity`," +
                    "fv.`electricity_note` = fv1.`electricity_note`," +
                    "fv.`electricaldevices_1` = fv1.`electricaldevices_1`," +
                    "fv.`electricaldevices_2` = fv1.`electricaldevices_2`," +
                    "fv.`electricaldevices_3` = fv1.`electricaldevices_3`," +
                    "fv.`heating_cooling_devices/1` = fv1.`heating_cooling_devices/1`," +
                    "fv.`heating_cooling_devices/2` = fv1.`heating_cooling_devices/2`," +
                    "fv.`heating_cooling_devices/3` = fv1.`heating_cooling_devices/3`," +
                    "fv.`heating_cooling_devices/4` = fv1.`heating_cooling_devices/4`," +
                    "fv.`aid_14` = fv1.`aid_14`," +
                    "fv.`aidsource_14` = fv1.`aidsource_14`," +
                    "fv.`aid_amount_14` = fv1.`aid_amount_14`," +
                    "fv.`aidperiod_14` = fv1.`aidperiod_14`," +
                    "fv.`buildingcondition_1` = fv1.`buildingcondition_1`," +
                    "fv.`buildingcondition_2` = fv1.`buildingcondition_2`," +
                    "fv.`buildingcondition_3` = fv1.`buildingcondition_3`," +
                    "fv.`buildingcondition_5` = fv1.`buildingcondition_5`," +
                    "fv.`buildingcondition_8` = fv1.`buildingcondition_8`," +
                    "fv.`beds_id` = fv1.`beds_id`," +
                    "fv.`livingroom_id` = fv1.`livingroom_id`," +
                    "fv.asset_3 = fv1.asset_3," +
                    "fv.isAsset = fv1.isAsset," +
                    "fv.`expenses_1` = fv1.`expenses_1`," +
                    "fv.`expenses_amount_3` = fv1.`expenses_amount_3`," +
                    "fv.`expenses_amount_19` = fv1.`expenses_amount_19`," +
                    "fv.`expenses_amount_20` = fv1.`expenses_amount_20`," +
                    "fv.`expenses_amount_2_home` = fv1.`expenses_amount_2_home`," +
                    "fv.`expenses_amount_11` = fv1.`expenses_amount_11`," +
                    "fv.`expenses_amount_21` = fv1.`expenses_amount_21`," +
                    "fv.`expenses_amount_22` = fv1.`expenses_amount_22`," +
                    "fv.`expenses_10` = fv1.`expenses_10`," +
                    "fv.`expenses_amount_10` = fv1.`expenses_amount_10`," +
                    "fv.`SellingFurniture` = fv1.`SellingFurniture`," +
                    "fv.`SellingFurniture_type_id/1` = fv1.`SellingFurniture_type_id/1`," +
                    "fv.`SellingFurniture_type_id/2` = fv1.`SellingFurniture_type_id/2`," +
                    "fv.`income_11` = fv1.`income_11`," +
                    "fv.`hasincome` = fv1.`hasincome`," +
                    "fv.`income_12` = fv1.`income_12`," +
                    "fv.`income_relation_id_12` = fv1.`income_relation_id_12`," +
                    "fv.`income_address_12` = fv1.`income_address_12`," +
                    "fv.`aid_amount_30` = fv1.`aid_amount_30`," +
                    "fv.`aidperiod_30` = fv1.`aidperiod_30`," +
                    "fv.`aid_11` = fv1.`aid_11`," +
                    "fv.`aidsource_11` = fv1.`aidsource_11`," +
                    "fv.`aid_amount_11` = fv1.`aid_amount_11`," +
                    "fv.`aidperiod_11` = fv1.`aidperiod_11`," +
                    "fv.`aid_12` = fv1.`aid_12`," +
                    "fv.`aidsource_12` = fv1.`aidsource_12`," +
                    "fv.`aid_amount_12` = fv1.`aid_amount_12`," +
                    "fv.`aidperiod_12` = fv1.`aidperiod_12`," +
                    "fv.`aid_20` = fv1.`aid_20`," +
                    "fv.`aidsource_20` = fv1.`aidsource_20`," +
                    "fv.`aid_amount_20` = fv1.`aid_amount_20`," +
                    "fv.`aidperiod_20` = fv1.`aidperiod_20`," +
                    "fv.`aid_19` = fv1.`aid_19`," +
                    "fv.`aidsource_19` = fv1.`aidsource_19`," +
                    "fv.`aid_amount_19` = fv1.`aid_amount_19`," +
                    "fv.`aidperiod_19` = fv1.`aidperiod_19`," +
                    "fv.`aid_17_home` = fv1.`aid_17_home`," +
                    "fv.`aidsource_17_home` = fv1.`aidsource_17_home`," +
                    "fv.`aid_amount_17_home` = fv1.`aid_amount_17_home`," +
                    "fv.`aidperiod_17_home` = fv1.`aidperiod_17_home`," +
                    "fv.`aid_note_17_home` = fv1.`aid_note_17_home`," +
                    "fv.`aid_16_home` = fv1.`aid_16_home`," +
                    "fv.`aidsource_16_home` = fv1.`aidsource_16_home`," +
                    "fv.`aid_amount_16_home` = fv1.`aid_amount_16_home`," +
                    "fv.`aidperiod_16_home` = fv1.`aidperiod_16_home`," +
                    "fv.`aid_note_16_home` = fv1.`aid_note_16_home`," +
                    "fv.`family_note` = fv1.`family_note`" +
                    "where fv.family_visit_id = @family_visit_id; ";
         
            //"(SELECT family_visit.id FROM family_visit WHERE family_visit.id < @family_visit_id and family_id = @Family_ID ORDER by family_visit.id desc LIMIT 1);";
            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('Family_Visit ID = ',@family_visit_id), CONCAT('Visit Name = ', @Visit_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
         
        //سيتم استخدام هذه التابع مؤقتاً لتسريع ادخال بيانات زيارة M&E 
        // تاريخ جدولة و اتمام اي زيارة هو نفسه بشكل تلقائي والفريق الزائر هو فريق الكنيسة

        public void Insert_Temporary_ME_Visit(int Family_ID, string VisitType, string Visit_Name, string Visite_State, string Scedualed_Visit_date, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@VisitType", VisitType);
            sc.Parameters.AddWithValue("@Visit_Name", Visit_Name);
            sc.Parameters.AddWithValue("@Visite_State", Visite_State);
            if (string.IsNullOrWhiteSpace(Scedualed_Visit_date))
            {
                sc.Parameters.AddWithValue("@Scedualed_Visit_date", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@Scedualed_Visit_date", Scedualed_Visit_date);
            }
            //sc.Parameters.AddWithValue("@Scedualed_Visit_date", Scedualed_Visit_date);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "INSERT  INTO `family_visit`( `family_id`, `visittype_id`, `visit_name`, `visitstate_id`, `Scedualed_Visit_date`, `visit_date`)"
                    + " SELECT @Family_ID, (SELECT id FROM visittype WHERE NAME = @VisitType), @Visit_Name, (SELECT id FROM visitstate WHERE name = @Visite_State), STR_TO_DATE(@Scedualed_Visit_date, '%d/%m/%Y'), STR_TO_DATE(@Scedualed_Visit_date, '%d/%m/%Y');"
            + " SET @family_visit_id = Last_Insert_ID();";
            //query += "INSERT INTO family_visit_visitor (family_visit_id, visitor_id) SELECT @family_visit_id, visitor.id from visitor WHERE visitor.name = 'فريق الكنيسة';";

            //query += "UPDATE family SET family.familyvisitstate_id = (SELECT (CASE WHEN @NumOfVisits < 1 THEN (SELECT id FROM familyvisitstate WHERE familyvisitstate.name = 'لم يزار بعد') ELSE (SELECT id FROM familyvisitstate WHERE familyvisitstate.name = 'مزار') END)) WHERE family.id = @Family_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('Family_Visit ID = ',@family_visit_id), CONCAT('Visit Name = ', @Visit_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
         
        public DataSet Get_Family_Visits(int Family_ID, string Visit_Type)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);

            query = "";

            if (Visit_Type == "All" || Visit_Type == "ME")
            {
                //Added By Mai
                query += " SELECT family_visit.* " +
                         " FROM family_visit " +
                         " LEFT JOIN visitstate ON family_visit.visitstate_id = visitstate.id  " +
                         " WHERE family_visit.family_id = @Family_ID " +
                         " AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'M&E') " +
                         " GROUP BY family_visit.id" +
                         " Order By family_visit.visit_name ASC; ";

                //query += "SELECT family_visit.*, visitstate.name as 'visitstate', family_visit.Scedualed_Visit_date as 'Scedualed_Visit_date', family_visit.Visit_date as 'visit_date',  GROUP_CONCAT(visitor.name) as 'Visit_Team' "
                //    + " FROM family_visit LEFT JOIN visitstate ON family_visit.visitstate_id = visitstate.id  LEFT JOIN family_visit_visitor ON family_visit_visitor.family_visit_id = family_visit.id LEFT JOIN visitor ON visitor.id = family_visit_visitor.visitor_id"
                //    + " WHERE family_visit.family_id = @Family_ID AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'M&E') GROUP BY family_visit.id;";
            }

            if (Visit_Type == "All" || Visit_Type == "Story")
                //Added By Mai
                query += " SELECT family_visit.*, family_visit.visitstate_id as 'visitstate', family_visit.Scedualed_Visit_date as 'Scedualed_Visit_date', family_visit.Visit_date as 'visit_date'"
                      + " FROM family_visit"
                      + " WHERE family_visit.family_id = @Family_ID AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'Story') GROUP BY family_visit.id;";
            //    query += " SELECT family_visit.*, visitstate.name as 'visitstate', family_visit.Scedualed_Visit_date as 'Scedualed_Visit_date', family_visit.Visit_date as 'visit_date', GROUP_CONCAT(visitor.name) as 'Visit_Team'"
            //        + " FROM family_visit LEFT JOIN visitstate ON family_visit.visitstate_id = visitstate.id LEFT JOIN family_visit_visitor ON family_visit_visitor.family_visit_id = family_visit.id LEFT JOIN visitor ON visitor.id = family_visit_visitor.visitor_id"
            //+ " WHERE family_visit.family_id = @Family_ID AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'Story') GROUP BY family_visit.id;";
            

            if (Visit_Type == "All" || Visit_Type == "Video")
                //Added By Mai
                query += " SELECT family_visit.*, family_visit.visitstate_id as 'visitstate', family_visit.Scedualed_Visit_date as 'Scedualed_Visit_date', family_visit.Visit_date as 'visit_date'"
                      + " FROM family_visit LEFT JOIN visitstate ON family_visit.visitstate_id = visitstate.id"
                      + " WHERE family_visit.family_id = @Family_ID AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'Video') GROUP BY family_visit.id;";
            //   query += " SELECT family_visit.*, visitstate.name as 'visitstate', family_visit.Scedualed_Visit_date as 'Scedualed_Visit_date', family_visit.Visit_date as 'visit_date', GROUP_CONCAT(visitor.name) as 'Visit_Team'"
            //       + " FROM family_visit LEFT JOIN visitstate ON family_visit.visitstate_id = visitstate.id  LEFT JOIN family_visit_visitor ON family_visit_visitor.family_visit_id = family_visit.id LEFT JOIN visitor ON visitor.id = family_visit_visitor.visitor_id"
            //+ " WHERE family_visit.family_id = @Family_ID AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'Video') GROUP BY family_visit.id;";
            
            if (Visit_Type == "All" || Visit_Type == "Followup")
                //Added By Mai
                query += " SELECT family_visit.*, family_visit.visitstate_id as 'visitstate', family_visit.Scedualed_Visit_date as 'Scedualed_Visit_date', family_visit.Visit_date as 'visit_date'"
                      + " FROM family_visit LEFT JOIN visitstate ON family_visit.visitstate_id = visitstate.id"
                      + " WHERE family_visit.family_id = @Family_ID AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'Follow-up') GROUP BY family_visit.id;";
            // query += " SELECT family_visit.*, visitstate.name as 'visitstate', family_visit.Scedualed_Visit_date as 'Scedualed_Visit_date', family_visit.Visit_date as 'visit_date', GROUP_CONCAT(visitor.name) as 'Visit_Team'"
            //     + " FROM family_visit LEFT JOIN visitstate ON family_visit.visitstate_id = visitstate.id LEFT JOIN family_visit_visitor ON family_visit_visitor.family_visit_id = family_visit.id LEFT JOIN visitor ON visitor.id = family_visit_visitor.visitor_id"
            //+ " WHERE family_visit.family_id = @Family_ID AND family_visit.visittype_id = (SELECT id FROM visittype WHERE visittype.name = 'Follow-up') GROUP BY family_visit.id;";

            //query += " SELECT * from visitor;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        //Added By Mai
        public void Update_ME_Visit(int Family_Visit_ID, int Family_ID, string Visit_Name,int Visit_State, string Schedualed_Date, string Visit_date, string Reason, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_Visit_ID", Family_Visit_ID);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_Name", Visit_Name);
            sc.Parameters.AddWithValue("@Visit_State", Visit_State);

            if (string.IsNullOrWhiteSpace(Schedualed_Date))
            {
                sc.Parameters.AddWithValue("@Schedualed_Date", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@Schedualed_Date", Schedualed_Date);
            }
            if (string.IsNullOrWhiteSpace(Visit_date))
            {
                sc.Parameters.AddWithValue("@Visit_date", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@Visit_date", Visit_date);
            }
            sc.Parameters.AddWithValue("@Reason", Reason);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "UPDATE family_visit SET family_visit.Scedualed_Visit_date = @Schedualed_Date,family_visit.Visit_date = @Visit_date,family_visit.canceled_reason = @Reason, family_visit.visitstate_id = @Visit_State WHERE family_visit.id = @Family_Visit_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE',  CONCAT('Family_Visit ID = ',@Family_Visit_ID), CONCAT('Visit Name = ', @Visit_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Visite_Schedualed_Date(int Family_Visit_ID, int Family_ID, string Visit_Name, string NewDate, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_Visit_ID", Family_Visit_ID);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_Name", Visit_Name);
            if (string.IsNullOrWhiteSpace(NewDate))
            {
                sc.Parameters.AddWithValue("@NewDate", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@NewDate", NewDate);
            }
            ///sc.Parameters.AddWithValue("@NewDate", NewDate);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "UPDATE family_visit SET family_visit.Scedualed_Visit_date = STR_TO_DATE(@NewDate, '%d/%m/%Y') WHERE family_visit.id = @Family_Visit_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE',  CONCAT('Family_Visit ID = ',@Family_Visit_ID), CONCAT('Visit Name = ', @Visit_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        //سيتم استخدام هذه التابع مؤقتاً لتسريع تعديل بيانات زيارة M&E 
        // تاريخ جدولة و اتمام اي زيارة هو نفسه بشكل تلقائي

        public void Update_Temporary_ME_Visit_Schedualed_Date(int Family_Visit_ID, int Family_ID, string Visit_Name, string NewDate, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_Visit_ID", Family_Visit_ID);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_Name", Visit_Name);
            if (string.IsNullOrWhiteSpace(NewDate))
            {
                sc.Parameters.AddWithValue("@NewDate", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@NewDate", NewDate);
            }
            //sc.Parameters.AddWithValue("@NewDate", NewDate);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            //query += "UPDATE family_visit SET family_visit.Scedualed_Visit_date = STR_TO_DATE(@NewDate, '%d/%m/%Y'),"
            query += "UPDATE family_visit SET family_visit.Scedualed_Visit_date = @NewDate,"
                //+ "family_visit.visit_date = STR_TO_DATE(@NewDate, '%d/%m/%Y')"
                + "family_visit.visit_date = @NewDate, '%d/%m/%Y'"
                + " WHERE family_visit.id = @Family_Visit_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE',  CONCAT('Family_Visit ID = ',@Family_Visit_ID), CONCAT('Visit Name = ', @Visit_Name), CONCAT('Family ID = ', @Family_ID), '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_Visit(int Family_Visit_ID, int Family_ID, string Visit_Name, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_Visit_ID", Family_Visit_ID);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_Name", Visit_Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += "DELETE FROM family_visit WHERE id = @Family_Visit_ID;";
            //query += "DELETE FROM family_visitdetails WHERE family_visit_id = @Family_Visit_ID;";
            query += " SET @NumOfVisits = (SELECT COUNT(id) FROM family_visit WHERE family_visit.family_id = @Family_ID AND family_visit.visitstate_id = (SELECT id FROM visitstate WHERE name = 'تمت'));";
            //query += " UPDATE family SET family.familyvisitstate_id = (SELECT (CASE WHEN @NumOfVisits < 1 THEN (SELECT id FROM familyvisitstate WHERE familyvisitstate.name = 'لم يزار بعد') ELSE (SELECT id FROM familyvisitstate WHERE familyvisitstate.name = 'مزار') END)) WHERE family.id = @Family_ID;";


            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('Family_Visit ID = ',@Family_Visit_ID), CONCAT('Visit Name = ', @Visit_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";


            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_Visit_Details(int Family_Visit_ID, int Visit_State, string Visit_Date, string Canceled_Reason, string Story, string Link1, string Link2, string Link3, int Visitor1, int Visitor2, int Family_ID, string Visit_Name, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_Visit_ID", Family_Visit_ID);
            sc.Parameters.AddWithValue("@Visit_State", Visit_State);
            sc.Parameters.AddWithValue("@Visitor1", Visitor1);
            sc.Parameters.AddWithValue("@Visitor2", Visitor2);
            if (string.IsNullOrWhiteSpace(Visit_Date))
            {
                sc.Parameters.AddWithValue("@Visit_Date", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@Visit_Date", Visit_Date);
            }
            //sc.Parameters.AddWithValue("@Visit_Date", Visit_Date);
            sc.Parameters.AddWithValue("@Canceled_Reason", Canceled_Reason);
            sc.Parameters.AddWithValue("@Story", Story);
            sc.Parameters.AddWithValue("@Link1", Link1);
            sc.Parameters.AddWithValue("@Link2", Link2);
            sc.Parameters.AddWithValue("@Link3", Link3);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_Name", Visit_Name);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);


            query = " START TRANSACTION;";

            if (Visit_State != -1 || Visit_Date != "" || Canceled_Reason != "")
                query += " UPDATE family_visit SET family_visit.visitstate_id = @Visit_State,"
                    //+ " family_visit.visit_date = STR_TO_DATE(@Visit_Date, '%d/%m/%Y'),"
                    + " family_visit.Visit_date = @Visit_Date,"
                    + " family_visit.canceled_reason = @Canceled_Reason, family_visit.story = @Story, family_visit.link1 = @Link1, family_visit.link2 = @Link2, family_visit.link3 = @Link3,"
                    + " family_visit.visitor1_id = @Visitor1,family_visit.visitor2_id = @Visitor2"
                    + " WHERE family_visit.id = @Family_Visit_ID;";

            query += "SET @NumOfVisits = (SELECT COUNT(id) FROM family_visit WHERE family_visit.family_id = @Family_ID AND family_visit.visitstate_id = (SELECT id FROM visitstate WHERE name = 'تمت'));";
            //query += "UPDATE family SET family.familyvisitstate_id = (SELECT (CASE WHEN @NumOfVisits < 1 THEN (SELECT id FROM familyvisitstate WHERE familyvisitstate.name = 'لم يزار بعد') ELSE (SELECT id FROM familyvisitstate WHERE familyvisitstate.name = 'مزار') END)) WHERE family.id = @Family_ID;";

            //query += Team_Query;

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Family_Visit ID = ',@Family_Visit_ID), CONCAT('Visit Name = ', @Visit_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
    
    
        
    }
}
