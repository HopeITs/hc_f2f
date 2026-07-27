using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace F2F_Application.Classes
{
    class Person
    {
        string query, log_query;
        //MySqlCommand sc;

        public int Insert_Person(int Family_ID, int Visit_ID, string FirstName, string FatherName, string LastName, string EName, string EFatherName, string ELastName,
            int IsReciever, int Relation_ID, string DOB, int Sex_ID, int Nationality_ID,
            int MaritalStatus_ID,
            string NationalityNumber,
            int State_ID, string Stateyear, int StateAddress,string StateAddressNote, int? aidsource_29, int AidAmount_29, int aidperiod_29, string aidnote_29,
            int? hasdisease, int ExpensesAmount_9, int Expensestype_9, int aidsource_21, int AidAmount_21, int aidperiod_21, int aidsource_1, int AidAmount_1, int aidperiod_1, int aidsource_13, int AidAmount_13, int aidperiod_13,
            string OperationName_2, int OperationValue_2, string OperationName_1, int OperationValue_1, int ExpensesAmount_5, int Expensestype_5,
            int aidsource_8, int AidAmount_8, int aidperiod_8, int ExpensesAmount_4, int Expensestype_4, 
            int aidsource_6, int AidAmount_6, int aidperiod_6, int ExpensesAmount_24, int Expensestype_24,
            int? haswork, int? isMP, int? isAid10, int aidsource_10, int AidAmount_10, int aidperiod_10, int IsEducated,
            int education_id_1, string EducationNote, int educationfield_id_1, int educationtype_id_1, 
            int education_id_2, string EducationNote2, int educationfield_id_2, int educationtype_id_2,
            int IsStudent, int ExpensesAmount_8, int Expensestype_8, int ExpensesAmount_2, int Expensestype_2, int aidsource_2, int AidAmount_2, int aidperiod_2, int aidsource_23, int AidAmount_23, int aidperiod_23, string Note, string PersonNote,
            int Needs_0, int Needs_1, int Needs_2, int Needs_3, int Needs_4, int Needs_5, int Needs_6, int Needs_7, int Needs_8, int Needs_9, int Needs_10, int Needs_12, string NeedsSpecialCourses , string NeedsNote,
            string WorkExp_Query, string MP_Query, string Disease_Query, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_ID", Visit_ID);

            sc.Parameters.AddWithValue("@FirstName", FirstName);
            sc.Parameters.AddWithValue("@FatherName", FatherName);
            sc.Parameters.AddWithValue("@LastName", LastName);
            if (EName == null)
            {
                sc.Parameters.AddWithValue("@EName", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@EName", EName);
            }
            if (EFatherName == null)
            {
                sc.Parameters.AddWithValue("@EFatherName", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@EFatherName", EFatherName);
            }
            if (ELastName == null)
            {
                sc.Parameters.AddWithValue("@ELastName", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@ELastName", ELastName);
            }
            if (Note == null)
            {
                sc.Parameters.AddWithValue("@Note", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@Note", Note);
            }

            sc.Parameters.AddWithValue("@NationalityNumber", NationalityNumber);
            sc.Parameters.AddWithValue("@MaritalStatus_ID", MaritalStatus_ID);
            sc.Parameters.AddWithValue("@IsReciever", IsReciever);
            sc.Parameters.AddWithValue("@Relation_ID", Relation_ID);
            if (string.IsNullOrWhiteSpace(DOB))
            {
                sc.Parameters.AddWithValue("@DOB", DBNull.Value);
            }
            else
            {
                sc.Parameters.AddWithValue("@DOB", DOB);
            }
            sc.Parameters.AddWithValue("@Sex_ID", Sex_ID);
            sc.Parameters.AddWithValue("@Nationality_ID", Nationality_ID);
            sc.Parameters.AddWithValue("@State_ID", State_ID);
            sc.Parameters.AddWithValue("@Stateyear", Stateyear);
            sc.Parameters.AddWithValue("@StateAddress", StateAddress);
            sc.Parameters.AddWithValue("@StateAddressNote", StateAddressNote);
            sc.Parameters.AddWithValue("@aidsource_29", aidsource_29);
            sc.Parameters.AddWithValue("@AidAmount_29", AidAmount_29);
            sc.Parameters.AddWithValue("@aidperiod_29", aidperiod_29);
            sc.Parameters.AddWithValue("@aidnote_29", aidnote_29);

            sc.Parameters.AddWithValue("@IsEducated", IsEducated);
            sc.Parameters.AddWithValue("@education_id_1", education_id_1);
            sc.Parameters.AddWithValue("@education_id_2", education_id_2);
            sc.Parameters.AddWithValue("@educationfield_id_1", educationfield_id_1);
            sc.Parameters.AddWithValue("@educationfield_id_2", educationfield_id_2);
            sc.Parameters.AddWithValue("@EducationNote", EducationNote);
            sc.Parameters.AddWithValue("@EducationNote2", EducationNote2);
            sc.Parameters.AddWithValue("@educationtype_id_1", educationtype_id_1);
            sc.Parameters.AddWithValue("@educationtype_id_2", educationtype_id_2);
            
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            int Person_ID;

            
            query = " START TRANSACTION;"
                + " INSERT INTO person (first_Name, father_name, last_name, first_name_e, father_name_e, last_name_e,"
                + " DOB,sex_id, nationality_id, national_Number,isEducated,education_id,educationnote,educationfield_id,educationtype_id,education_id_2,educationnote2,educationfield_id_2,educationtype_id_2,Note)"
                + " VALUES (@FirstName, @FatherName, @LastName, @EName, @EFatherName, @ELastName,"
                + " @DOB, @Sex_ID, @Nationality_ID, @NationalityNumber,@isEducated,@education_id_1,@EducationNote,@educationfield_id_1,@educationtype_id_1,@education_id_2,@EducationNote2,@educationfield_id_2,@educationtype_id_2,@Note);"
                + " SET @person_id = Last_Insert_ID();";
            
            query += " INSERT INTO person_family (family_id, person_id, relation_id, isReceiver) " +
                                        " VALUES (@Family_ID, @person_id, @Relation_ID, @IsReciever);";

            query += " INSERT INTO person_state (family_id, person_id, personstate_id, personstate_year" +
                ", stateaddress_id,State_Note, aidsource_29, aid_amount_29, aidperiod_29, aid_note_29, date, current_state ) " +
                " VALUES (@Family_ID, @person_id, @State_ID , @Stateyear" +
                ", @StateAddress,@StateAddressNote, @aidsource_29, @AidAmount_29, @aidperiod_29, @aidnote_29, DATE(NOW()), '1');";

            query += " INSERT INTO person_maritalstatus (person_id, maritalstatus_id, date, current_state ) " +
                " VALUES (@person_id, @MaritalStatus_ID ,DATE(NOW()), '1');";

            if (WorkExp_Query != "")
                query += " INSERT INTO person_workexp (person_id, workexp_id, workfor_id, worktype_id, workposition_id, experience_id, workexpamount , workname, workplace_id, expenses_amount_6, expensestype_6,expensesAmperNumber_7,expenses_amount_7, expenses_amount_15, expensestype_15, expenses_amount_16, expensestype_16, expenses_amount_17, expensestype_17, expenses_amount_23, expensestype_23, workexpnote) VALUES " + WorkExp_Query + ";";

            if (MP_Query != "")
                query += " INSERT INTO person_mp_aid (person_id, mp_fundyear, aidsource_5_mp, aid_amount_5_mp, aidperiod_5_mp, aidsource_17_mp, aid_amount_17_mp, aidperiod_17_mp, aidsource_22_mp, aid_amount_22_mp, aidperiod_22_mp, expenses_amount_12_mp, expensestype_12_mp) VALUES " + MP_Query + ";";
            

            if (Disease_Query != "")
                query += " INSERT INTO person_disease (person_id, disease_id, disease_note) VALUES " + Disease_Query + ";";
            query += " INSERT INTO familymembersnumber (family_id, NumberOfBeneficiaries, NumberOfAllMembers, Note, date) VALUES "
                 + " (@Family_ID, "
                 + " (SELECT COUNT(person_family.id) AS 'NumberOfBeneficiaries' FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active')),"
                 + " (SELECT COUNT(person_family.id) AS 'NumberOfAllMembers' FROM person_family WHERE person_family.family_id = @Family_ID),"
                 + " CONCAT('New person added Name:', @Name, ' ', @LastName, 'ID: ', @person_id),"
                 + " DATE(NOW()));";


            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'INSERT',  CONCAT('Person ID = ', @person_id), CONCAT('Person Name = ', @FirstName), CONCAT('Family ID = ', @Family_ID), '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " SELECT @person_id;"
                + " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            Person_ID = Convert.ToInt32(sc.ExecuteScalar());
            Program.MyConn.Close();

            return Person_ID;
        }

        public DataSet SearchPersonVisit(int Person_ID, int Visit_ID)
        {
            //check connection//
            Program.buildConnection();
            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);
            sc.Parameters.AddWithValue("@Visit_ID", Visit_ID); //To be used in log
            query = "Select person_visitdetails.* from person_visitdetails where person_id = @Person_ID and family_visit_id= @Visit_ID;";
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public void Update_Person(int Person_ID, string Person_Name, int Family_ID
            , string General_Query, string Education_Query, string Receiver_Query
            //, int Visit_ID 
            //, string Expenses_Query, string Aid_Query, string Military_Query
            //, string WorkExp_Query, string MP_Query, string Disease_Query,string Needs_Query
            , string Form_Name)
        {
            //check connection//
            Program.buildConnection();
            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);
            sc.Parameters.AddWithValue("@Person_Name", Person_Name); //To be used in log
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);
            //sc.Parameters.AddWithValue("@Visit_ID", Visit_ID);
            
            query = " START TRANSACTION;";
            //DataSet ds = SearchPersonVisit(Person_ID, Visit_ID);
            //if(ds.Tables[0].Rows.Count == 0)
            //{
            //    query += "insert into person_visitdetails (person_id,family_visit_id) values(@Person_ID,@Visit_ID);";
            //}

            if (General_Query != "")
            {
                query += General_Query;
            }

            if(Receiver_Query != "")
            {
                query += Receiver_Query;
            }

            if (Education_Query != "")
            {
                query += Education_Query;
            }

            //if (Expenses_Query != "")
            //{
            //    query += Expenses_Query;
            //}
            //if (Aid_Query != "")
            //{
            //    query += Aid_Query;
            //}
            //if (Military_Query != "")
            //{
            //    query += Military_Query;
            //}
            //if (WorkExp_Query != "")
            //{
            //    query += WorkExp_Query;
            //}
            //if (MP_Query != "")
            //{
            //    query += MP_Query;
            //}
            //if (Disease_Query != "")
            //{
            //    query += Disease_Query;
            //}
            //if (Needs_Query != "")
            //{
            //    query += Needs_Query;
            //}
            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Person ID = ', @Person_ID), CONCAT('Person Name = ', @Person_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Update_PersonDetails(int Person_ID, int Visit_ID, string Person_Name, int Family_ID
    , string General_Query, string Receiver_Query, string Expenses_Query, string Aid_Query, string Military_Query
    , string WorkExp_Query, string MP_Query, string Education_Query, string Disease_Query, string Needs_Query
    , string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);
            sc.Parameters.AddWithValue("@Person_Name", Person_Name); //To be used in log
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_ID", Visit_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);

            query = " START TRANSACTION;";
            DataSet ds = SearchPersonVisit(Person_ID, Visit_ID);
            if (ds.Tables[0].Rows.Count == 0)
            {
                query += "insert into person_visitdetails (person_id,family_visit_id) values(@Person_ID,@Visit_ID);";
            }

            if (General_Query != "")
            {
                query += General_Query;
            }

            if (Receiver_Query != "")
            {
                query += Receiver_Query;
            }
            if (Education_Query != "")
            {
                query += Education_Query;
            }
            if (Expenses_Query != "")
            {
                query += Expenses_Query;
            }
            if (Aid_Query != "")
            {
                query += Aid_Query;
            }
            if (Military_Query != "")
            {
                query += Military_Query;
            }
            if (WorkExp_Query != "")
            {
                query += WorkExp_Query;
            }
            if (MP_Query != "")
            {
                query += MP_Query;
            }
            if (Disease_Query != "")
            {
                query += Disease_Query;
            }
            if (Needs_Query != "")
            {
                query += Needs_Query;
            }
            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'UPDATE', CONCAT('Person ID = ', @Person_ID), CONCAT('Person Name = ', @Person_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";

            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public void Delete_Person(int Person_ID, string Person_Name, int Family_ID, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);
            sc.Parameters.AddWithValue("@Person_Name", Person_Name);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);


            query = " START TRANSACTION;";
            query += "DELETE FROM person WHERE id = @Person_ID;";
            query += " INSERT INTO familymembersnumber (family_id, NumberOfBeneficiaries, NumberOfAllMembers, Note, date) VALUES "
                    + " (@Family_ID, "
                    + " (SELECT COUNT(person_family.id) AS 'NumberOfBeneficiaries' FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @Family_ID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active')),"
                    + " (SELECT COUNT(person_family.id) AS 'NumberOfAllMembers' FROM person_family WHERE person_family.family_id = @Family_ID),"
                    + " CONCAT('Person Deleted Person_ID: ', @Person_ID),"
                    + " DATE(NOW()));";
            
            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'DELETE', CONCAT('Person ID = ', @Person_ID), CONCAT('Person Name = ', @Person_Name), CONCAT('Family ID = ', @Family_ID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }

        public DataSet Get_Person(int Person_ID, int? Family_ID, int? Visit_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Visit_ID", Visit_ID);
            query = "Select person.* " +
                ", person_state.* , CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END as 'personstate' " +
                "  from person " +
                "  left join person_state on person_state.person_id = person.id " +
                "  left join personstate on personstate.id = person_state.personstate_id " +
                "  where person.id = @Person_ID " +
                "  and person_state.current_state = 1 " +
                "  and person_state.family_id = @Family_ID;";

            query += "Select family.code as 'code' from family where family.id = @Family_ID;";
            query += "SELECT person_disease.id as 'id', person_disease.disease_id as 'disease_id',person_disease.disease_Note as 'disease_Note' , disease.diseasecategory_id as 'diseasecategory_id' ,family_visit.visit_name FROM person_disease LEFT JOIN disease ON disease.id = person_disease.disease_id left join family_visit on family_visit.id = person_disease.visit_id  where person_disease.person_id = @Person_ID;";
            query += "Select person_workexp.*, family_visit.visit_name from person_workexp left join family_visit on family_visit.id = person_workexp.visit_id  where person_workexp.person_id = @Person_ID;";
            query += "Select person_mp_aid.*, family_visit.visit_name from person_mp_aid left join family_visit on family_visit.id = person_mp_aid.visit_id where person_mp_aid.person_id = @Person_ID;";
            query += "Select * from family_visit where family_visit.id = @Visit_ID;";
            query += "Select person_family.relation_id , person_family.IsReceiver from person_family where person_family.person_id = @Person_ID and person_family.family_id= @Family_ID;";
            //query += "Select person_state.personstate_id , personstate.name as 'personstate' from person_state where person_state.person_id = @Person_ID and current_state = 1;";
            query += "Select * from person_visitdetails left join person_family on person_family.person_id = person_visitdetails.person_id left join family_visit on family_visit.family_id = person_family.family_id where person_visitdetails.person_id = @Person_ID and person_visitdetails.family_visit_id = @Visit_ID;";
            query += "Select * from person_maritalstatus where person_maritalstatus.person_id = @Person_ID and person_maritalstatus.current_state = 1;";

            //query = "SELECT person.*, family.code as 'code',"
            //    + " person_family.relation_id as 'relation_id', person_family.IsReceiver as 'IsReceiver', person_state.personstate_id as 'personstate_id', person_state.State_Note as 'State_Note', personstate.Name as 'personstate'"
            //    + " FROM person LEFT JOIN person_family on person.id = person_family.person_id"
            //    + " LEFT JOIN family on person_family.family_id = family.id"
            //    + " LEFT JOIN person_state on person.id = person_state.person_id"
            //    + " LEFT JOIN personstate ON person_state.personstate_id = personstate.id"
            //    + " WHERE person.id = @Person_ID and person_state.current_state = '1';";

            //query += "SELECT * FROM person_workexp WHERE person_id = @Person_ID;";

            //query += "SELECT * FROM person_education WHERE person_id = @Person_ID;";

            //query += "SELECT person_disease.*, diseasecategory.id as 'diseasecategory_id' FROM person_disease LEFT JOIN disease  ON person_disease.disease_id = disease.id LEFT JOIN diseasecategory ON disease.diseasecategory_id = diseasecategory.id WHERE person_id = @Person_ID;";


            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataSet ds = new DataSet();

            da.Fill(ds);
            Program.MyFirstConn.Close();

            return ds;
        }

        public DataTable Get_PersonState_History(int Person_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);

            query = " SELECT CONCAT(person.first_Name , ' ' , person.last_name) as 'الاسم'" 
                + ", CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END as 'الحالة'"
                  
                + ", person_state.personstate_year as 'سنة الحالة'" 
                + ", (select stateaddress.name from stateaddress where stateaddress.id = person_state.stateaddress_id limit 1) as 'مكان الإقامة'"
                + ", (case aidsource_29 when 29 then 'نعم' when 0 then 'لا' else 'N/A' END) as 'هل يساعدك?'" 
                + ", person_state.aid_amount_29 as 'قيمة المساعدة'" 
                + ", (select aidperiod.name from aidperiod where aidperiod.id = person_state.aidperiod_29 limit 1) as 'مدة المساعدة'" 
                + ", person_state.aid_note_29 as 'السبب'" 
                   
                + ", person_state.State_Note as 'ملاحظات'" 
                + ", person_state.date as 'تاريخ التعديل'" 
                
                //", (select relation.name from person_family " +
                //        " left join relation on person_family.relation_id = relation.id" +
                //        " where person_family.person_id = @Person_ID limit 1) as 'العلاقة'"

                + " FROM person_state LEFT JOIN person ON person_state.person_id = person.id"
                + " LEFT JOIN personstate ON person_state.personstate_id = personstate.id" 
                + " WHERE person.id = @Person_ID ORDER by person_state.date;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }
        public DataTable Get_PersonMaritalState_History(int Person_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);

            query = "SELECT CONCAT(person.first_Name , ' ' , person.last_name) as 'الاسم'" + 
                ", maritalstatus.name as 'الحالة الاجتماعية'" +
                ", person_maritalstatus.date as 'تاريخ التعديل'"

                + " FROM person_maritalstatus LEFT JOIN person ON person_maritalstatus.person_id = person.id"  
                + " LEFT JOIN maritalstatus ON person_maritalstatus.maritalstatus_id = maritalstatus.id"
                + " WHERE person.id = @Person_ID ORDER by person_maritalstatus.date;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public void Check_PersonVisitDetails(int Family_ID, int Person_ID, int Visit_ID)
        {
            //check connection//
            Program.buildConnection();
            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);
            sc.Parameters.AddWithValue("@Visit_ID", Visit_ID);

            query = @"SELECT count(person_visitdetails.id) 
 FROM family_visit 
 LEFT JOIN `person_visitdetails` on family_visit.id = person_visitdetails.family_visit_id 
 where person_visitdetails.person_id = @Person_ID
 and person_visitdetails.family_visit_id = @Visit_ID
 and family_visit.family_id = @Family_ID;";

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
                    query = @" INSERT INTO `person_visitdetails` (`person_id`, `family_visit_id`, `hasdisease`
, `haschronic_medicine`, `expenses_amount_9`, `expensestype_9`, `haschronic_medicine_aid`, `aidsource_21`, `aid_amount_21`, `aidperiod_21`
, `aid_1`, `aidsource_1`, `aid_amount_1`, `aidperiod_1`, `aid_13`, `aidsource_13`, `aid_amount_13`, `aidperiod_13`
, `operation_name_2`, `operation_value_2`, `operation_name_1`, `operation_value_1`, `expenses_amount_5`, `expensestype_5`
, `aid_8`, `aidsource_8`, `aid_amount_8`, `aidperiod_8`, `expenses_amount_4`, `expensestype_4`
, `aid_6`, `aidsource_6`, `aid_amount_6`, `aidperiod_6`, `expenses_amount_24`, `expensestype_24`
, `haswork`, `hasmicroproject`, `aid_10`, `aidsource_10`, `aid_amount_10`, `aidperiod_10`, `isStudent`
, `expenses_amount_8`, `expensestype_8`, `expenses_amount_2`, `expensestype_2`, `aidsource_2`, `aid_amount_2`, `aidperiod_2`
, `aidsource_23`, `aid_amount_23`, `aidperiod_23`, `person_note`
, `needs/0`, `needs/1`, `needs/2`, `needs/3`, `needs/4`, `needs/5`, `needs/6`, `needs/7`, `needs/8`, `needs/9`, `needs/10`, `needs/11`, `needs/12`
, `needs_special_courses`, `needs_note`, `note`) 
VALUES (@Person_ID, @Visit_ID, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL); ";

                    MySqlCommand sc1 = new MySqlCommand();
                    sc1.Parameters.AddWithValue("@Visit_ID", Visit_ID);
                    sc1.Parameters.AddWithValue("@Person_ID", Person_ID);
                    sc1.CommandText = query;
                    sc1.Connection = Program.MyConn;
                    sc1.ExecuteNonQuery();
                }
            } 
            Program.MyConn.Close();
        }

        public DataTable Check_Nationality_Number(string NationalityNumber, int Person_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@NationalityNumber", NationalityNumber);
            sc.Parameters.AddWithValue("@NationalityNumberNoZeros", NationalityNumber.TrimStart(new Char[] { '0' }));
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);
             
            query = "SELECT Concat(first_Name ,' ', father_name, ' ', last_name) as 'Name', person_family.family_id as 'Family_ID',personstate.type as 'personstate_type', person_family.person_id as 'Person_ID' " +
                " FROM person " +
                " left join person_family on person.id = person_family.person_id " +
                " left join family on family.id = person_family.family_id " +
                " LEFT JOIN person_state on (person_state.person_id = person.id) and (person_state.family_id = family.id) " +
                " left join personstate on personstate.id = person_state.personstate_id " +
                " WHERE (national_Number = @NationalityNumber or national_Number = @NationalityNumberNoZeros)";
            //query = "SELECT Concat(first_Name ,' ', father_name, ' ', last_name) as 'Name', person_family.family_id as 'Family_ID' FROM person left join person_family on person_family.person_id = person.id left join family on person_family.family_id = family.id WHERE (national_Number = @NationalityNumber or national_Number = @NationalityNumberNoZeros)";

            if (Person_ID != -1)
            {
                query += " and person.id <> @Person_ID";
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

        public DataTable Check_Receiver(int Family_ID, int Person_ID)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@Family_ID", Family_ID);
            sc.Parameters.AddWithValue("@Person_ID", Person_ID);

            query = "SELECT Concat(first_Name ,' ', father_name, ' ', last_name) as 'Name' " +
                " FROM person " +
                " JOIN person_family ON person_family.person_id = person.id " +
                " WHERE person_family.family_id = @Family_ID " +
                " and person_family.IsReceiver = '1'";
          //query = "SELECT Concat(first_Name ,' ', father_name, ' ', father_name) as 'Name' FROM person JOIN family ON person.family_id = family.id WHERE person.family_id = @Family_ID and person.IsReceiver = '1'";

            if (Person_ID != -1)
            {
                query += " and person.id <> @Person_ID ";
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

        public void Move_Person(int PersonID, string PersonName, int OldFamilyID, string OldFamilyCode, int NewFamilyID, string NewFamilyCode, string Form_Name)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@PersonID", PersonID);
            sc.Parameters.AddWithValue("@PersonName", PersonName);
            sc.Parameters.AddWithValue("@OldFamilyID", OldFamilyID);
            sc.Parameters.AddWithValue("@OldFamilyCode", OldFamilyCode);
            sc.Parameters.AddWithValue("@NewFamilyID", NewFamilyID);
            sc.Parameters.AddWithValue("@NewFamilyCode", NewFamilyCode);
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);
            
            query = " START TRANSACTION;";
            query += "UPDATE person_family SET person_family.family_id = @NewFamilyID WHERE person_family.person_id = @PersonID AND person_family.family_id = @OldFamilyID;";
            query += "UPDATE person_state SET person_state.current_state = 0 WHERE person_state.person_id = @PersonID AND person_state.family_id = @OldFamilyID;";
            query += "INSERT INTO person_state (family_id,person_id,personstate_id,current_state) values (@NewFamilyID ,@PersonID ,1,1);";
            query += " INSERT INTO familymembersnumber (family_id, NumberOfBeneficiaries, NumberOfAllMembers, Note, date) VALUES "
                + " (@OldFamilyID, "
                + " (SELECT COUNT(person_family.id) AS 'NumberOfBeneficiaries' FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @OldFamilyID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active')),"
                + " (SELECT COUNT(person_family.id) AS 'NumberOfAllMembers' FROM person_family WHERE person_family.family_id = @OldFamilyID),"
                + " CONCAT('Person Moved Name:', @PersonName,' to family ', @NewFamilyCode),"
                + " DATE(NOW()));";
            query += " INSERT INTO familymembersnumber (family_id, NumberOfBeneficiaries, NumberOfAllMembers, Note, date) VALUES "
                + " (@NewFamilyID, "
                + " (SELECT COUNT(person_family.id) AS 'NumberOfBeneficiaries' FROM person_family JOIN person_state JOIN personstate on person_family.person_id = person_state.person_id and person_state.personstate_id = personstate.id WHERE person_family.family_id = @NewFamilyID and person_state.current_state = '1' and LOWER(personstate.type) = LOWER('Active')),"
                + " (SELECT COUNT(person_family.id) AS 'NumberOfAllMembers' FROM person_family WHERE person_family.family_id = @NewFamilyID),"
                + " CONCAT('Person Moved Name:', @PersonName, ' from family ', @OldFamilyCode),"
                + " DATE(NOW()));";
            
            log_query = Regex.Replace(query, "'", "''");
            foreach (MySqlParameter p in sc.Parameters)
            {
                log_query = Regex.Replace(log_query, p.ParameterName, p.Value == null ? "" : Regex.Replace(p.Value.ToString(), "'", "''"));
            }

            query += " INSERT INTO log (form_name, title, affected_id, details, additionaldetails, query, date, user) VALUES (@Form_Name, 'MOVE', CONCAT('Person ID = ', @PersonID), CONCAT('Person Name = ', @PersonName), CONCAT('Moved From Family ID = ', @OldFamilyID, ' - To Family ID = ', @NewFamilyID) , '" + log_query + "', DATE(NOW()), '" + Properties.Settings.Default.Username + "');";
            query += " COMMIT;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;
            sc.ExecuteNonQuery();
            Program.MyConn.Close();
        }
    }
}
