using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;


namespace F2F_Application.Classes
{
    class Family
    {
        internal static string NumberOfWorkersSql(string familyIdExpression)
        {
            return "(SELECT COUNT(DISTINCT(person_workexp.person_id)) FROM person JOIN person_family JOIN person_state JOIN personstate JOIN person_workexp " +
                "ON person.id = person_family.person_id AND person.id = person_state.person_id AND person_state.personstate_id = personstate.id AND person_workexp.person_id = person.id " +
                "WHERE person_family.family_id = " + familyIdExpression + " AND person_state.current_state = '1' AND LOWER(personstate.type) = LOWER('Active') " +
                "AND person_state.family_id = " + familyIdExpression + ")";
        }

        string query, log_query;
        //MySqlCommand sc;

        //, int ExpensesAmount_10, int aidamount_11, int aidamount_20, int aidamount_19, int expenses_amount_6_12_home, int ExpensesAmount_2_Home, int ExpensesAmount_3, int ExpensesAmount_21, int ExpensesAmount_19, int ExpensesAmount_22,
        //        int ExpensesAmount_20, int ExpensesAmount_11, int HeirsNumber, int aidamount_5_3_home, int expenses_amount_7_Home, int AmperNumber_7_Home,
        //        int aidamount_4, int aidsource_4, int aidperiod_4, int aidsource_16, int aidperiod_16, int SellingFurniture_type_1, int SellingFurniture_type_2, int AmperNumber_17_Home, int aidamount_16, int aidamount_14, int aidamount_12, int aidamount_17_Home, int aidamount_16_Home,
        //        string Expenses_10, int Expenses_1, int expensestype_6_12_home_ID, int ParishHomeID, int aidsource_5_3_home_ID, int aidperiod_5_3_home_ID, int Beds_ID, int LivingRoom_ID,  int HeatingCooling_1, int HeatingCooling_2, int HeatingCooling_3, int HeatingCooling_4,
        //        int? Income_11, int? Expenses_7_Home, int? Expenses_17_Home, int? Expenses_16_Home, int? Electricity, int? LivingWithCode, int? LivingWithCode2, int? SellingFurniture, int? ElectricalDevices_1, int? ElectricalDevices_2, int? ElectricalDevices_3, int? BuildingCond_1, int? BuildingCond_2, int? BuildingCond_3, int? BuildingCond_5, int? BuildingCond_8,
        //        int? aidsource_11, int? aidsource_20, int? aidsource_19, int? aidsource_14, int? aidsource_12, int? aidsource_16_Home, int? aidsource_17_Home,
        //        int? aidperiod_11, int? aidperiod_20, int? aidperiod_19, int? aidperiod_14, int? aidperiod_12, int? aidperiod_16_Home, int? aidperiod_17_Home,
        //        int? IncomeRelation_12,int? aidamount_30, int? aidperiod_30, string Asset_Query, string CarAsset_Query, string Income_Query
        //       ,int EntredBy, int EntredBy2, string OtherVisitors, string DateOfEntry
        //       ,string home_description, string ElectricityNote, string NoteAid_11, string NoteAid_19, string NoteAid_20, string NoteAid_12, string NoteAid_17_home, string NoteAid_16_home,
        //       ,string income_address_12, int RoomsNumber
        //       ,string FamilyNote             , int IsDisplaced_ID, int HomeType_ID 

        public int Insert_Family(string Code, string FamilyNumber
            , decimal LocationLatitude, decimal LocationLongtitude, string Address, int Floor, int BuildingNumber
            , string Note, string PartnerNote , string ComplaintNote, string EvaluationNote
            , int LivingWithFamily, string LivingWithNote, string LivingWithNote2
            , string LandLine, string MobileNumber 
            , int InEvaluation, string InEvaluationBy,string EvaluationDate
            , int Approved, string ApprovedBy, string ApprovalDate
            , int PDM, string PDMBy, string PDMDate
            , int PVM, string PVMBy, string PVMDate 
            , int Complaint , string ComplaintBy, string ComplaintDate
            , int Parish_ID, int Street_ID
            , string Partner_Query,string LivingWith_Query, string Form_Name)
        {
            int Family_ID;
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Code", Code);
            sc.Parameters.AddWithValue("@FamilyNumber", FamilyNumber);
            sc.Parameters.AddWithValue("@LocationLatitude", LocationLatitude);
            sc.Parameters.AddWithValue("@LocationLongtitude", LocationLongtitude);
            sc.Parameters.AddWithValue("@Address", Address); 
            sc.Parameters.AddWithValue("@BuildingNumber", BuildingNumber);
            sc.Parameters.AddWithValue("@Floor", Floor);
             
            sc.Parameters.AddWithValue("@Note", Note);
            sc.Parameters.AddWithValue("@PartnerNote", PartnerNote);
            sc.Parameters.AddWithValue("@ComplaintNote", ComplaintNote);
            sc.Parameters.AddWithValue("@EvaluationNote", EvaluationNote);

            sc.Parameters.AddWithValue("@LivingWithFamily", LivingWithFamily);
            sc.Parameters.AddWithValue("@LivingWithNote", LivingWithNote);
            sc.Parameters.AddWithValue("@LivingWithNote2", LivingWithNote2);
            
            sc.Parameters.AddWithValue("@LandLine", LandLine);
            sc.Parameters.AddWithValue("@MobileNumber", MobileNumber);

            sc.Parameters.AddWithValue("@InEvaluationBy", InEvaluationBy);
            sc.Parameters.AddWithValue("@InEvaluation", InEvaluation);
            sc.Parameters.AddWithValue("@EvaluationDate", EvaluationDate);
             
            sc.Parameters.AddWithValue("@Approved", Approved);
            sc.Parameters.AddWithValue("@ApprovedBy", ApprovedBy);
            sc.Parameters.AddWithValue("@ApprovalDate", ApprovalDate);

            sc.Parameters.AddWithValue("@PDM", PDM);
            sc.Parameters.AddWithValue("@PDMBy", PDMBy);
            sc.Parameters.AddWithValue("@PDMDate", PDMDate);
             
            sc.Parameters.AddWithValue("@PVM", PVM);
            sc.Parameters.AddWithValue("@PVMBy", PVMBy);
            sc.Parameters.AddWithValue("@PVMDate", PVMDate);

            sc.Parameters.AddWithValue("@Complaint", Complaint);
            sc.Parameters.AddWithValue("@ComplaintBy", ComplaintBy);
            sc.Parameters.AddWithValue("@ComplaintDate", ComplaintDate);

            sc.Parameters.AddWithValue("@Parish_ID", Parish_ID); 
            sc.Parameters.AddWithValue("@Street_ID", Street_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            //if (LivingWithCode == null) sc.Parameters.AddWithValue("@LivingWithCode", DBNull.Value); 
            //else sc.Parameters.AddWithValue("@LivingWithCode", LivingWithCode);
            //if (LivingWithCode2 == null) sc.Parameters.AddWithValue("@LivingWithCode2", DBNull.Value);
            //else sc.Parameters.AddWithValue("@LivingWithCode2", LivingWithCode2);  
            //query += "CALL Update_Living_With(@LivingWithFamily,@family_id,@LivingWithCode,@LivingWithNote);";

            query = @"START TRANSACTION; 
 INSERT INTO family (code, family_number, location_latitude, location_longitude, Note, partnernote ,complaintnote,evaluationnote 
 , LivingWithFamily , address, building_number, floor, landLine, mobile, InEvaluation, InEvaluationBy,evaluationdate
 , approvedby, approvaldate, pdmby, pdmdate, pvmby, pvmdate ,complaintby,complaintdate,  PDM, PVM, Complaint
 , Approved, parish_id, street_id) 
 VALUES ( trim(@Code), trim(@FamilyNumber),@LocationLatitude ,@LocationLongtitude, @Note, @PartnerNote, @ComplaintNote,@EvaluationNote
 , @LivingWithFamily, trim(@Address), @BuildingNumber, @Floor, trim(@LandLine), trim(@MobileNumber), @InEvaluation, @InEvaluationBy,@EvaluationDate
 , @ApprovedBy, @ApprovalDate, @PDMBy, @PDMDate, @PVMBy, @PVMDate ,@ComplaintBy,@ComplaintDate , @PDM, @PVM
 , @Complaint, @Approved, @Parish_ID, @Street_ID); 
 SET @family_id = Last_Insert_ID();";

            if (Partner_Query != "")
            {
                //query += " INSERT INTO partner_donor (partner_id,donor_id) VALUES " + Partner_Query + ";";
                //query += " SET @partner_donor_id = Last_Insert_ID();";
                query += " INSERT INTO family_partner (family_id, partner_donor_id, IsActive) VALUES " + Partner_Query + ";";
            } 

            if (LivingWith_Query != "")
                query += LivingWith_Query;

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(Regex.Replace(p.Value.ToString(), "'", "''"), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT', CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Code), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " SELECT @family_id;"
                + " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            Family_ID = Convert.ToInt32(sc.ExecuteScalar());
            Program.MyConn.Close();

            return Family_ID;
        }

        public void Update_Family(int Family_ID,string Family_Code
            , string General_Query, string Partner_Query, string LivingWith_Query 
            //, string FamilyVisitState, string Income_Query, string Aid_Query, string Expenses_Query
            //, string Asset_Query, string CarAsset_Query, string BuildingCondition_Query,string LivingCondition_Query
            //, string ElectricalDevices_Query, string Lighting_Query
            , string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Code", Family_Code);//To be used in log 
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);
             
            //sc.Parameters.AddWithValue("@Code", Code);
            //sc.Parameters.AddWithValue("@FamilyNumber", FamilyNumber);
            //sc.Parameters.AddWithValue("@Note", Note);
            //sc.Parameters.AddWithValue("@PartnerNote", PartnerNote);
            //sc.Parameters.AddWithValue("@Parish_ID", Parish_ID);
            //sc.Parameters.AddWithValue("@FamilyVisitState", FamilyVisitState);
            //sc.Parameters.AddWithValue("@VisitWillNotReason", VisitWillNotReason);
            //sc.Parameters.AddWithValue("@Street_ID", Street_ID);
            //sc.Parameters.AddWithValue("@Addres", Addres);
            //sc.Parameters.AddWithValue("@IsDisplaced_ID", IsDisplaced_ID);
            //sc.Parameters.AddWithValue("@HomeType_ID", HomeType_ID);
            //sc.Parameters.AddWithValue("@Beds_ID", Beds_ID);
            //sc.Parameters.AddWithValue("@LivingWithFamily", LivingWithFamily);
            //if (LivingWithCode == null)
            //  sc.Parameters.AddWithValue("@LivingWithCode", DBNull.Value);
            //else sc.Parameters.AddWithValue("@LivingWithCode", LivingWithCode);
            //sc.Parameters.AddWithValue("@LivingWithNote", LivingWithNote);
            //sc.Parameters.AddWithValue("@SellingFurnitureNote", SellingFurnitureNote);
            //sc.Parameters.AddWithValue("@LivingRoom_ID", LivingRoom_ID);
            //sc.Parameters.AddWithValue("@LandLine", LandLine);
            //sc.Parameters.AddWithValue("@MobileNumber", MobileNumber);
            //sc.Parameters.AddWithValue("@InEvaluation", InEvaluation);

            query = " START TRANSACTION;";

            if(General_Query != null)
            {
                query += General_Query;
            }
            
            if (Partner_Query != null)
                query += Partner_Query;

            if (LivingWith_Query != null)
                query += LivingWith_Query;
            
            //if (FamilyVisitState != "" || VisitWillNotReason != "")
            //{
            //    query += "UPDATE family SET familyvisitstate_id = (SELECT id FROM familyvisitstate WHERE familyvisitstate.name = @FamilyVisitState),"
            //        + " Visist_WillNot_Reason = @VisitWillNotReason"
            //        + " where id = @Family_ID;";
            //    if (FamilyVisitState == "رفض" || FamilyVisitState == "لن يزار")
            //        query += "DELETE FROM family_visit WHERE family_visit.family_id = @Family_ID;";
            //}

            //if (Income_Query != null)
            //    query += Income_Query;
            //if (Aid_Query != null)
            //    query += Aid_Query;
            //if (Expenses_Query != null)
            //    query += Expenses_Query;
            //if (Asset_Query != null)
            //    query += Asset_Query;
            //if (CarAsset_Query != null)
            //    query += CarAsset_Query;
            //if (BuildingCondition_Query != null)
            //    query += BuildingCondition_Query;
            //if (LivingCondition_Query != null)
            //    query += LivingCondition_Query;
            //if (ElectricalDevices_Query != null)
            //    query += ElectricalDevices_Query;
            //if (Lighting_Query != null)
            //    query += Lighting_Query;

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Family_Code), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_FamilyDetails(int Family_ID, string Family_Code
    , string General_Query, string Partner_Query, string LivingWith_Query
    , string FamilyVisitState, string Income_Query, string Aid_Query, string Expenses_Query
    , string Asset_Query, string CarAsset_Query, string BuildingCondition_Query, string LivingCondition_Query
    , string ElectricalDevices_Query, string Lighting_Query
    , string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Code", Family_Code);//To be used in log 
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);  

            query = " START TRANSACTION;"; 
            if (General_Query != null) 
                query += General_Query;

            if (Partner_Query != null)
                query += Partner_Query;

            if (LivingWith_Query != null)
                query += LivingWith_Query;
             
            if (Income_Query != null)
                query += Income_Query;

            if (Aid_Query != null)
                query += Aid_Query;
            
            if (Expenses_Query != null)
                query += Expenses_Query;
            
            if (Asset_Query != null)
                query += Asset_Query;
            
            if (CarAsset_Query != null)
                query += CarAsset_Query;
            
            if (BuildingCondition_Query != null)
                query += BuildingCondition_Query;
            
            if (LivingCondition_Query != null)
                query += LivingCondition_Query;
            
            if (ElectricalDevices_Query != null)
                query += ElectricalDevices_Query;
            
            if (Lighting_Query != null)
                query += Lighting_Query;

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Family_Code), '', '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_Family(int Family_ID, string Code, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Code", Code);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += " DELETE person FROM person JOIN person_family ON person_family.person_id = person.id WHERE person_family.Family_ID = @Family_ID;";
            query += " DELETE FROM family WHERE id = @Family_ID;";

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Code), '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";
             
            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_LivingWith(int? Family_ID,string Family_Note, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Note", Family_Note);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            query += " DELETE FROM family_livingwith WHERE (family_livingwith.family_id1 = @Family_ID and family_livingwith.note = @Family_Note ) or (family_livingwith.family_id2 = @Family_ID and family_livingwith.note = @Family_Note);";
            
            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE',  CONCAT('Family_ID = ', '@Family_ID'), '', '' , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";


            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public DataSet Get_Family(int Family_ID,int Visit_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_ID", Visit_ID);

            //query = "SELECT family.*, familyvisitstate.name as 'VisitState',"
            //               + " ( SELECT CONCAT(person.first_Name, ' ',person.last_name) FROM family LEFT JOIN person_family ON person_family.family_id = family.id LEFT JOIN person ON person.id = person_family.person_id WHERE person_family.family_id = @Family_ID AND isReceiver	= '1') as 'Receiver_Name',"
            //               + " (SELECT COUNT(person_family.id)  FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active'))  AS 'NumberOfBeneficiaries'"
            //               + " FROM family LEFT JOIN familyvisitstate on family.familyvisitstate_id = familyvisitstate.id"
            //               + " WHERE family.id = @Family_ID;";
            //               + " (SELECT COUNT(person_family.id)  FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active'))  AS 'NumberOfBeneficiaries'"
            //               + " FROM family LEFT JOIN familyvisitstate on family.familyvisitstate_id = familyvisitstate.id"
            //               + " WHERE family.id = @Family_ID;";
            //query += "SELECT visitor.id as 'visitor1' FROM visitor left join family on family.`visitor1_id` = visitor.id where family.`visitor1_id` = visitor.id and family.id = @Family_ID;" +
            //         "SELECT visitor.id as 'visitor2' FROM visitor left join family on family.`visitor2_id` = visitor.id where family.`visitor2_id` = visitor.id and family.id = @Family_ID;" +
            //         "SELECT visitor.name as 'othervisitors' FROM visitor join family on family.othervisitors = visitor.id where family.othervisitors = visitor.id;";
            //query += "SELECT visitor.name as 'othervisitors' FROM visitor join family_visit on family_visit.othervisitors = visitor.id where family_visit.othervisitors = visitor.id;";
            //query += "SELECT * FROM family_income WHERE family_id = @Family_ID;";
            //query += "SELECT * FROM family_aid WHERE family_id = @Family_ID;";
            //query += "SELECT * FROM family_expenses WHERE family_id = @Family_ID;";
            //query += "SELECT * FROM family_loss WHERE family_id = @Family_ID;";
            //query += "SELECT * FROM family_buildingcondition WHERE family_id = @Family_ID;";
            //query += "SELECT family_electricaldavices.*, electricaldavices.name FROM family_electricaldavices JOIN electricaldavices ON family_electricaldavices.electricaldavices_id = electricaldavices.id WHERE family_id = @Family_ID;";

            query = "SELECT * from family WHERE id = @Family_ID;";
            query += "SELECT concat(first_name,' ',last_name) as 'Receiver_Name' " +
                " from person left join person_family on person_family.person_id = person.id " +
                " where person_family.family_id = @Family_ID and person_family.isReceiver=1 " +
                " order by person_family.id desc limit 1;";

            query += "SELECT family_assets.* ,  family_visit.visit_name FROM family_assets  left join family_visit on family_visit.id = family_assets.visit_id  WHERE family_assets.family_id = @Family_ID;";
            query += "SELECT family_cars.* ,    family_visit.visit_name FROM family_cars    left join family_visit on family_visit.id = family_cars.visit_id    WHERE family_cars.family_id = @Family_ID;";
            query += "SELECT family_income.* ,  family_visit.visit_name FROM family_income  left join family_visit on family_visit.id = family_income.visit_id  WHERE family_income.family_id = @Family_ID;";
            query += "SELECT family_partner.id, family_partner.partner_donor_id ,partner_donor.donor_id , partner_donor.partner_id, isActive from partner_donor"
                  + " LEFT JOIN family_partner on family_partner.partner_donor_id = partner_donor.id"
                  + " WHERE family_partner.family_id = @Family_ID;";
            query += "SELECT * FROM family_visit where family_id = @Family_ID and id = @Visit_ID and visit_name LIKE '%M%' order by family_visit.id DESC limit 1;";
            query += "SELECT visitstate.name as 'visitstate' FROM visitstate join family_visit on family_visit.visitstate_id = visitstate.id WHERE visitstate.id = family_visit.visitstate_id;";
            query += "Select NumberOfBeneficiaries as 'NumberOfBeneficiaries' , NumberOfAllMembers as 'NumberOfAllMembers' from familymembersnumber where family_id = @Family_ID order by  familymembersnumber.id DESC, familymembersnumber.date desc limit 1;";
            query += "SELECT * FROM `family_visitdetails` left join family_visit on family_visit.id = family_visitdetails.family_visit_id  where family_visit_id = @Visit_ID and family_visit.visitstate_id = 3;";

            //query += "CALL family_marks(@Family_ID,@Visit_ID,'');";
            query += "select Final_Mark from tmarks where `Family_ID` = @Family_ID and `Visit_ID` = @Visit_ID;";

            //query += "Select Final_Mark from family_marks " +
            //    " left join person_family on person_family.family_id = family_marks.Family_ID " +
            //    " where family_marks.Family_ID =  @Family_ID;";

            query += "CALL Update_Living_With(@Family_ID);";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public DataSet Get_FamilyLastVisit(int Family_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            query = "SELECT * FROM family_visit " +
                "where family_id = @Family_ID " +
                "and visitstate_id = 3 " +
                "and visit_name LIKE '%M%' " +
                "order by family_visit.id DESC limit 1;";
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public DataSet Get_Family_Members(int Family_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);

            string Base_Query = "SELECT person.id as 'Person ID' " 
                + ", CONCAT(person.first_Name, ' ', person.father_name, ' ', person.last_name) as 'اسم الشخص'"
                + ", person.national_Number as 'الرقم الوطني'"
                + ", person.DOB as 'تاريخ الميلاد'" 
                + ", ( CASE year(CURDATE()) - year(person.DOB)  WHEN 0 THEN 1 ELSE year(CURDATE()) - year(person.DOB) END) as 'العمر'"
                + ", maritalstatus.name as 'الحالة الإجتماعية'" 
                + ", sex.name as 'الجنس'" 
                + ", relation.name as 'العلاقة'" 
                + ", CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END as 'حالة المستفيد'"
                + ", (case person_family.IsReceiver when 0 then 'لا' else 'نعم' END) as 'المستلم'"
                + ", ( SELECT GROUP_CONCAT((disease.name)) " +
                                " FROM person " +
                                " LEFT JOIN person_disease ON person_disease.person_id = person.id " +
                                " LEFT JOIN disease ON disease.id = person_disease.disease_id " +
                                " WHERE person.id = `Person ID`) AS 'الأمراض'"

                + ", (CASE WHEN person_visitdetails.IsStudent = 1 THEN 'نعم' ELSE 'لا' END) as 'طالب'" 
                + ", ( SELECT GROUP_CONCAT(DISTINCT(workexp.name)) " +
                                " FROM person " +
                                " LEFT JOIN person_workexp ON person_workexp.person_id = person.id " +
                                " LEFT JOIN workexp ON workexp.id = person_workexp.workexp_id " +
                                " WHERE person.id = `Person ID`) AS 'العمل'" 
                + ", person_visitdetails.person_note as 'ملاحظات الفريق'"
                //+ ", GROUP_CONCAT(DISTINCT(workexp.name)) as 'العمل'"
                //+ " CASE WHEN SUM(person_workexp.amount) IS NULL THEN 0 ELSE ROUND(SUM(person_workexp.amount)) END AS 'الدخل المصرح عنه'"
                //+ " CASE WHEN SUM(( CASE WHEN person_workexp.amount > workexp.Average THEN person_workexp.amount ELSE workexp.Average END)) IS NULL THEN 0"
                //+ " ELSE ROUND(SUM((CASE WHEN person_workexp.amount > workexp.Average THEN person_workexp.amount ELSE workexp.Average * workposition.multiplication_factor * workplace.multiplication_factor * experience.multiplication_factor * workfor.multiplication_factor END)"
                //+ " )) END AS 'الدخل المحتسب'"

                + " FROM person "
                + " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id"
                + " LEFT JOIN person_family on person_family.person_id = person.id"
                + " LEFT JOIN family ON family.id = person_family.family_id"
                + " LEFT JOIN relation ON person_family.relation_id = relation.id"

                + " LEFT JOIN nationality ON person.nationality_id = nationality.id"
                + " LEFT JOIN sex ON person.sex_id = sex.id"
                
                + " LEFT JOIN person_state ON person_state.person_id = person.id"
                + " LEFT JOIN personstate on personstate.id = person_state.personstate_id" 

                + " LEFT JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id"
                + " LEFT JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id" ;

                        query = " SELECT"
                + " (SELECT COUNT(person_family.id) FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active') and person_state.family_id = @Family_ID)  AS 'NumberOfBeneficiaries',"
                + " " + NumberOfWorkersSql("@Family_ID") + " AS 'NumberOfWorkers',"
                + " (SELECT COUNT(person.id) FROM person JOIN person_family JOIN person_visitdetails JOIN person_state JOIN personstate ON person.id = person_family.person_id and person.id = person_visitdetails.person_id and person.id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and person_visitdetails.isStudent = '1' and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active') and person_state.family_id = @Family_ID) AS 'NumberOfStudents',"
                + " (SELECT COUNT(person.id) FROM person JOIN person_family JOIN person_state JOIN personstate ON person.id = person_family.person_id and person.id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and year(DATE(NOW())) - year(person.DOB) > '60' and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active') and person_state.family_id = @Family_ID)  AS 'NumberOfOld',"
                + " (SELECT COUNT(DISTINCT person.id) FROM person JOIN person_family JOIN person_state JOIN personstate JOIN person_disease ON person.id = person_family.person_id and person.id = person_disease.person_id and person.id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active') and person_state.family_id = @Family_ID) AS 'NumberOfPatient';";
            
            query += Base_Query + " WHERE family.id = @Family_ID " +
                " AND person_state.family_id = @Family_ID " +
                " and person_state.current_state = '1' " +
                " AND person_maritalstatus.current_state = '1' " + 
                " GROUP BY person.id;";


            //+ " LEFT JOIN person_workexp ON person.id = person_workexp.person_id"
            //+ " LEFT JOIN workexp ON workexp.id = person_workexp.workexp_id"
            //+ " LEFT JOIN workposition ON workposition.id = person_workexp.workposition_id"
            //+ " LEFT JOIN workplace ON workplace.id = person_workexp.workplace_id"
            //+ " LEFT JOIN experience ON experience.id = person_workexp.experience_id"
            //+ " LEFT JOIN workfor ON workfor.id = person_workexp.workfor_id"
            //+ " LEFT JOIN hcsyria_f2f_test.family ON person_family.family_id = family.id"
            //+ " LEFT JOIN hcsyria_f2f_test.family_partner ON family_partner.family_id = family.id"
            //+ " LEFT JOIN hcsyria_f2f_test.partner ON family_partner.partner_id = partner.id" 
            //+ " LEFT JOIN hcsyria_f2f_test.personstate ON person_state.personstate_id = personstate.id" 
            //query = "SELECT"
            //    + " (SELECT COUNT(person.id) FROM person LEFT JOIN personstate on personstate.id = person.personstate_id left join person_family on person_family.person_id = person.id WHERE person_family.family_id = @Family_ID and person.isBeneficiary = 1 AND LOWER(personstate.type) = LOWER('Active')) as 'NumberOfBeneficiaries',"
            //    + " (SELECT COUNT(person_workexp.person_id) FROM person JOIN personstate JOIN person_workexp on person.personstate_id = personstate.id AND person_workexp.person_id = person.id WHERE person.family_id = @Family_ID AND LOWER(personstate.type) = LOWER('Active')) AS 'NumberOfWorkers',"
            //    + " (SELECT COUNT(person.id) FROM person JOIN personstate ON personstate.id = person.personstate_id WHERE person.family_id = @Family_ID and person.isstudent = '1' and LOWER(personstate.type) = LOWER('Active')) AS 'NumberOfStudents',"
            //    + " (SELECT COUNT(person.id) FROM person JOIN personstate ON personstate.id = person.personstate_id WHERE person.family_id = @Family_ID and year(DATE(NOW())) - year(person.DOB) > '60' and LOWER(personstate.type) = LOWER('Active')) AS 'NumberOfOld',"
            //    + "(SELECT COUNT(DISTINCT person.id) FROM person JOIN personstate JOIN person_disease ON person.id = person_disease.person_id WHERE person.family_id = @Family_ID and LOWER(personstate.type) = LOWER('Active')) AS 'NumberOfPatient';";
            //query += Base_Query + " WHERE family.id = @Family_ID AND person_state.current_state = '1' AND LOWER(personstate.type) = LOWER('Active') GROUP BY person.id;";
            //query += Base_Query + " WHERE family.id = @Family_ID AND person_state.current_state = '1' AND LOWER(personstate.type) = LOWER('Disactive') GROUP BY person.id;";


            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public DataTable Get_FamilyMembers_History(int Family_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);

            query = "SELECT familymembersnumber.NumberOfBeneficiaries as 'عدد المستفيدين', familymembersnumber.NumberOfAllMembers as 'عدد أفراد العائلة', familymembersnumber.Note as 'سبب التعديل',  familymembersnumber.date as 'تاريخ التعديل'"
                + " FROM familymembersnumber "
                + " WHERE familymembersnumber.family_id = @Family_ID ORDER by familymembersnumber.date;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataTable Get_Family_Distribution_History(int Family_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);

            query = "SELECT distribution.name AS 'Distribution', partner.name AS 'Partner', DATE_FORMAT(distribution.date, '%M/%Y') AS 'Date'"
                + " FROM signature_list LEFT JOIN partner_distribution on partner_distribution.id = signature_list.partner_distribution_id"
                + " LEFT JOIN distribution ON distribution.id = partner_distribution.distribution_id"
                + " LEFT JOIN partner_donor ON partner_donor.id = partner_distribution.partner_donor_id"
                + " LEFT JOIN partner ON partner.id = partner_donor.partner_id"
                + " WHERE signature_list.family_id = @Family_ID AND signature_list.RecievedMoney = '1' ORDER BY distribution.date";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public void Calculate_Family_Marks()
        {            
            //Added By Judy
            //check connection//
            Program.buildConnection();
            MySqlCommand sc = new MySqlCommand();
            query = "CALL family_marks(-1,-1,'');";
            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery(); 
            Program.MyFirstConn.Close();
        }
        public DataSet Get_Family_Marks(string VisitName, int markType)
        {
            ////check connection//
            //Program.buildConnection(); 
            //MySqlCommand sc = new MySqlCommand();
            //sc.Parameters.AddWithValue("@VisitName", VisitName); 
            ////Added By Judy
            //query = "CALL family_marks(-1,-1,@VisitName);";
            //sc.CommandText = query;
            //sc.Connection = Program.MyConn;
            //sc.ExecuteNonQuery();
              
            if (markType == 0)
            {
                query = " select Family_ID as 'ID'" +
  ", Family_Code as 'رمز العائلة'" +
  ", Visit_Name as 'الزيارة'" +
  ", Visit_ID as 'Visit_ID'" +
  ", Parish as 'الطائفة'" +
  ", Num_of_Members as 'عدد الأفراد'" +
  ", Final_Mark as 'العلامة النهائية' " +
  "  from tmarks "; //for small report
            }
            else query = " select * from tmarks "; //for all report

            query += " where Visit_Name like @VisitName ;";
            MySqlCommand sc = new MySqlCommand();
            sc.CommandText = query;
            sc.Parameters.AddWithValue("@VisitName", VisitName); 
            sc.Connection = Program.MyConn;
            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Program.MyFirstConn.Close();
            return ds;
        }
        
        public DataTable Check_FamilyCode(string Code, int Family_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Code", Code);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);

            query = "SELECT * FROM family WHERE LOWER(family.code) = LOWER(@Code)";

            if (Family_ID != -1)
            {
                query += " and family.id <> @Family_ID";
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

        public void Check_FamilyVisitDetails(int Family_ID,int Visit_ID)
        {
            //check connection//
            Program.buildConnection(); 
            MySqlCommand sc = new MySqlCommand(); 
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_ID", Visit_ID);

            query = @"SELECT count(family_visitdetails.id) 
FROM family_visit LEFT JOIN `family_visitdetails` on family_visit.id = family_visitdetails.family_visit_id
where family_visit.family_id = @Family_ID and family_visit.id = @Visit_ID"; 
            sc.CommandText = query;
            sc.Connection = Program.MyConn; 
            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            if (dt.Rows.Count < 1)
                dt = null;
            else
            {
                int is_family_visit_details = -1;
                int.TryParse(dt.Rows[0][0].ToString(), out is_family_visit_details);

                if (is_family_visit_details == 0) //no visit details rows
                {
                    query = @" INSERT INTO `family_visitdetails` 
(`id`, `family_visit_id`, `hometype_id`, `expenses_amount_6_12_home`, `expensestype_6_12_home`
, `aidsource_5_3_home`, `aid_amount_5_3_home`, `aidperiod_5_3_home`, `parish_id_home`, `heirs_number`
, `expenses_amount_6_home2`, `expensestype_6_home2`, `home_description`, `isdisplaced_id`, `rooms_number`
, `expenses_7_home`, `amper_number_7_home`, `expenses_amount_7_home`, `aid_4`, `aidsource_4`
, `aid_amount_4`, `aidperiod_4`, `expenses_16_home`, `expenses_17_home`, `amper_number_17_home`
, `aid_16`, `aidsource_16`, `aid_amount_16`, `aidperiod_16`, `isElectricity`, `electricity_note`
, `electricaldevices_1`, `electricaldevices_2`, `electricaldevices_3`
, `heating_cooling_devices/1`, `heating_cooling_devices/2`, `heating_cooling_devices/3`
, `heating_cooling_devices/4`, `aid_14`, `aidsource_14`, `aid_amount_14`, `aidperiod_14`
, `buildingcondition_1`, `buildingcondition_2`, `buildingcondition_3`, `buildingcondition_5`
, `buildingcondition_8`, `beds_id`, `livingroom_id`, `asset_3`, `isAsset`, `expenses_1`
, `expenses_amount_3`, `expenses_amount_19`, `expenses_amount_20`, `expenses_amount_2_home`
, `expenses_amount_11`, `expenses_amount_21`, `expenses_amount_22`, `expenses_10`, `expenses_amount_10`
, `SellingFurniture`, `SellingFurniture_type_id/1`, `SellingFurniture_type_id/2`, `income_11`, `hasincome`
, `income_12`, `income_relation_id_12`, `income_address_12`, `aid_amount_30`, `aidperiod_30`, `aid_11`
, `aidsource_11`, `aid_amount_11`, `aidperiod_11`, `aid_note_11`, `aid_12`, `aidsource_12`, `aid_amount_12`
, `aidperiod_12`, `aid_note_12`, `aid_20`, `aidsource_20`, `aid_amount_20`, `aidperiod_20`, `aid_note_20`
, `aid_19`, `aidsource_19`, `aid_amount_19`, `aidperiod_19`, `aid_note_19`, `aid_17_home`
, `aidsource_17_home`, `aid_amount_17_home`, `aidperiod_17_home`, `aid_note_17_home`, `aid_16_home`
, `aidsource_16_home`, `aid_amount_16_home`, `aidperiod_16_home`, `aid_note_16_home`, `family_note`) 
 VALUES 
( NULL, @Visit_ID 
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL); ";

                    MySqlCommand sc1 = new MySqlCommand();
                    sc1.Parameters.AddWithValue("@Visit_ID", Visit_ID); 
                    sc1.CommandText = query;
                    sc1.Connection = Program.MyConn;
                    sc1.ExecuteNonQuery();
                }
            }

            Program.MyConn.Close();
        }

        public DataTable Get_LivingWith(int Family_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);

            query = "select family.id as 'ID', family.code as 'Name' from family where family.id != @Family_ID ";
            query += " ORDER BY family.code;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public void Update_Family_Evaluation(int Family_ID, string Family_Code, int InEvaluation, string inEvaluationReason, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Code", Family_Code);
            sc.Parameters.AddWithValue("@InEvaluation", InEvaluation);
            sc.Parameters.AddWithValue("@inEvaluationReason", inEvaluationReason);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (InEvaluation == 1)
            {
                query += " UPDATE family SET InEvaluation = @InEvaluation, InEvaluationBy = '" + Properties.Settings.Default.Username + "', evaluationdate = DATE(NOW()) WHERE id = @Family_ID;";
            }
            else
            {
                query += " UPDATE family SET InEvaluation = @InEvaluation, InEvaluationBy = '' , approvaldate = null  WHERE id = @Family_ID;";

            }

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'EVALUATION',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Family_Code), CONCAT('Approved = ', @InEvaluation) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
        public void Update_Family_Approval(int Family_ID, string Family_Code, int Approved, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Code", Family_Code);
            sc.Parameters.AddWithValue("@Approved", Approved);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (Approved == 1)
            {
                query += " UPDATE family SET Approved = @Approved, approvedby = '" + Properties.Settings.Default.Username + "', approvaldate = DATE(NOW()) WHERE id = @Family_ID;";
            }
            else
            {
                query += " UPDATE family SET Approved = @Approved, approvedby = '', approvaldate = null WHERE id = @Family_ID;";

            }

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'APPROVE',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Family_Code), CONCAT('Approved = ', @Approved) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
        public void Update_Family_PDM(int Family_ID, string Family_Code, int PDM, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Code", Family_Code);
            sc.Parameters.AddWithValue("@PDM", PDM);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (PDM == 1)
            {
                query += " UPDATE family SET PDM = @PDM, pdmby = '" + Properties.Settings.Default.Username + "', pdmdate = DATE(NOW()) WHERE id = @Family_ID;";
            }
            else
            {
                query += " UPDATE family SET PDM = @PDM, pdmby = '', pdmdate = null WHERE id = @Family_ID;";

            }

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'PDM',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Family_Code), CONCAT('PDM = ', @PDM) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
        public void Update_Family_PVM(int Family_ID, string Family_Code, int PVM, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Code", Family_Code);
            sc.Parameters.AddWithValue("@PVM", PVM);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (PVM == 1)
            {
                query += " UPDATE family SET PVM = @PVM, pvmby = '" + Properties.Settings.Default.Username + "', pvmdate = DATE(NOW()) WHERE id = @Family_ID;";
            }
            else
            {
                query += " UPDATE family SET PVM = @PVM, pvmby = '', pvmdate = null WHERE id = @Family_ID;";

            }

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'PVM',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Family_Code), CONCAT('PVM = ', @PVM) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
        public void Update_Family_Complaint(int Family_ID, string Family_Code, int Complaint, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Family_Code", Family_Code);
            sc.Parameters.AddWithValue("@Complaint", Complaint);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";

            if (Complaint == 1)
            {
                query += " UPDATE family SET Complaint = @Complaint, complaintby = '" + Properties.Settings.Default.Username + "', complaintdate = DATE(NOW()) WHERE id = @Family_ID;";
            }
            else
            {
                query += " UPDATE family SET Complaint = @Complaint, complaintby = '', complaintdate = null WHERE id = @Family_ID;";
            }

            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'Complaint',  CONCAT('Family ID = ', @Family_ID), CONCAT('Family Code = ', @Family_Code), CONCAT('Complaint = ', @Complaint) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }


        public DataSet Get_Family_Locations()
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            query = "SELECT code, location_latitude as 'latitude' , location_longitude as 'longitude' FROM family;";
            

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public DataSet Get_Family_Statistics()
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            query = "SELECT cast(COUNT(Family_Code) as varchar(255)) AS 'disease' FROM precalculated_marks WHERE Num_of_WithFatalorDisability > 0; ";
            query += "SELECT cast(COUNT(Family_Code) as varchar(255)) AS 'foodAvg' FROM precalculated_marks WHERE Food_Avg LIKE 'Under average';";
            query += "SELECT cast(COUNT(Family_Code) as varchar(255)) AS 'hometype' FROM precalculated_marks WHERE STRCMP( Home_Type , 'ملك') = " + 1 + "  || STRCMP( Home_Type , 'إعارة') = " + 1 + "|| STRCMP( Home_Type , 'ورثة') =  "+1+ "; ";
            query += "SELECT cast(COUNT(Family_Code) as varchar(255)) AS 'receiverAge' FROM precalculated_marks WHERE ReceiverAge >= 60; ";
            query += "SELECT cast(COUNT(Family_Code) as varchar(255)) AS 'workers' FROM precalculated_marks WHERE Num_of_Workers = 0; ";
            query += "SELECT cast(COUNT(Family_Code) as varchar(255)) AS 'students' FROM precalculated_marks WHERE Num_of_Students = 0; ";

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
