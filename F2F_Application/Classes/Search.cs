using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace F2F_Application.Classes
{
    class Search
    {
        string query;

        public DataTable Get_Families(string FilterQuery, List<string> AdditionalColumnsTables, List<string> AdditionalColumnsTables_ArabicName)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            string WhereQuery = "";
            string GroupQuery = "";
            bool aidAmountAdded = false;
            string SelectQuery = "SELECT family_visit.id as 'Family_Visit_ID'" +
                ", family.id as 'Family ID'" +
                ", IFNULL(family.code, ' ') as 'رمز العائلة'" +
                ", family_visit.visit_name as 'الزيارة'" +
                ", `visitstate`.`name` as 'حالة الزيارة'" +

                ", (SELECT CONCAT(person.first_Name, ' ', person.father_name, ' ', person.last_name) " +
                            "FROM person LEFT JOIN person_family ON person_family.person_id = person.id " +
                            "WHERE person_family.isReceiver = '1' AND person_family.family_id = `Family ID`) as 'المستلم'" +

                ",GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'" +
                ",MAX(case WHEN donor.name like 'F2F' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '" +
                ",MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '" +
                //",GROUP_CONCAT(DISTINCT(donor.name)) as 'الممول'" +
                ",GROUP_CONCAT(DISTINCT(partnergroups.name)) as 'المجموعة'" +
                ",GROUP_CONCAT(DISTINCT(CASE WHEN family_partner.IsActive = 1 THEN 'فعالة' ELSE 'غير فعالة' END)) AS 'الحالة'" +

                ",(SELECT(case family.InEvaluation WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'تظهر في التقييم؟'" +
                ",IFNULL(parish.name, ' ') as 'الطائفة'" +
                ",(case family.Complaint WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل يوجد شكوى؟'" +
                ",IFNULL(family.family_number, ' ') as 'رقم دفتر العائلة'" +
                ",(select familymembersnumber.NumberOfAllMembers from familymembersnumber where familymembersnumber.family_id = family.id order by familymembersnumber.date DESC, familymembersnumber.id DESC limit 1) as 'عدد أفراد الأسرة'" +
                ",(select familymembersnumber.NumberOfBeneficiaries from familymembersnumber where familymembersnumber.family_id = family.id order by familymembersnumber.date DESC, familymembersnumber.id DESC limit 1) as 'عدد المستفيدين'" +
                "," + Family.NumberOfWorkersSql("family.id") + " as 'عدد العاملين'" +

                ",IFNULL(family.landline, ' ') as 'الهاتف الأرضي'" +
                ",IFNULL(family.mobile, ' ') as 'رقم الموبايل'" +
                ",IFNULL(street.name, ' ') as 'المنطقة'" +
                ",IFNULL(family.address, ' ') as 'العنوان'" +
                ",IFNULL(hometype.name, ' ') as 'السكن'" +
                ",(case family.LivingWithFamily WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل تسكن مع عائلة أخرى؟'" +
                ",IFNULL(family_visitdetails.rooms_number, ' ') as 'عدد الغرف'" +
                ",IFNULL(beds.name, ' ') as 'عدد الأسرّة'" +
                ",IFNULL(livingroom.name, ' ') as 'غرفة المعيشة'" +
                                ",(case family_visitdetails.SellingFurniture WHEN 1 then 'نعم' WHEN 0 then 'لا' ELSE '' END) as 'هل تبيع أغراض المنزل؟'" +

                ",(case family_visitdetails.asset_3 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل يوجد سيارة؟'" +
                ",(case family_visitdetails.isAsset WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل يوجد ممتلكات إضافية؟'" +
                ",(case family_visitdetails.hasincome WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ' ' END) as 'هل يوجد دخل ثابت؟'" +

                ",IFNULL(family.PDM, ' ') as 'PDM'" +
                ",IFNULL(family.pdmby, ' ') as 'PDM By'" +
                ",IFNULL(family.pdmdate, ' ') as 'PDM Date'" +
                ",IFNULL(family.PVM, ' ') as 'PVM'" +
                ",IFNULL(family.pvmby, ' ') as 'PVM By'" +
                ",IFNULL(family.pvmdate, ' ') as 'PVM Date'" +
                ",IFNULL(`family_visitdetails`.`family_note`, ' ') as 'ملاحظة الزيارة'" +
                ",IFNULL(`family`.`Note`, ' ')  as 'ملاحظات العائلة'" +
                ",IFNULL(`family`.`partnernote`, ' ') as 'ملاحظات الشريك'" +
                ",IFNULL(`family`.`complaintnote`, ' ') as 'ملاحظات الشكوى'" +
                ",IFNULL(`family`.`evaluationnote`, ' ') as 'ملاحظات التقييم'";

            //string FromQuery = " FROM family_visitdetails"
            //     + " LEFT JOIN family_visit on family_visit.id = family_visitdetails.family_visit_id"
            //     + " LEFT JOIN family on family.id = family_visit.family_id "
            //     + " LEFt JOIN parish on parish.id = family.parish_id"
            //     + " LEFT join street on street.id = family.street_id"
            //     + " LEFT join hometype on hometype.id = family_visitdetails.hometype_id"
            //     + " LEFT JOIN parish parish_id_home on parish_id_home.id = family_visitdetails.parish_id_home"
            //     + " LEFT JOIN isdisplaced on isdisplaced.id = family_visitdetails.isdisplaced_id"
            //     + " LEFT JOIN beds on beds.id = family_visitdetails.beds_id"
            //     + " LEFT JOIN livingroom on livingroom.id = family_visitdetails.livingroom_id"
            //     + " LEFT JOIN foodaverage on foodaverage.id = family_visitdetails.expenses_1";

            string FromQuery = " FROM family"
                 + " LEFT JOIN person_family on person_family.family_id = family.id"
                 + " LEFT JOIN family_visit on family_visit.family_id = family.id"
                 + " LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id "
                 + " LEFT JOIN visitstate on family_visit.visitstate_id = visitstate.id "

                 + " LEFT JOIN family_partner on family_partner.family_id = family.id "
                 + " LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id "
                 + " LEFT JOIN partner on partner.id = partner_donor.partner_id "
                 + " LEFT JOIN donor on donor.id = partner_donor.donor_id "
                 + " LEFT JOIN partnergroups on partnergroups.id = partner.partnergroup_id "
                 + " LEFT JOIN parish on parish.id = family.parish_id"
                 + " LEFT JOIN street on street.id = family.street_id"
                 + " LEFT join hometype on hometype.id = family_visitdetails.hometype_id"
                 + " LEFT JOIN parish parish_id_home on parish_id_home.id = family_visitdetails.parish_id_home"
                 + " LEFT JOIN isdisplaced on isdisplaced.id = family_visitdetails.isdisplaced_id"
                 + " LEFT JOIN beds on beds.id = family_visitdetails.beds_id"
                 + " LEFT JOIN livingroom on livingroom.id = family_visitdetails.livingroom_id"
                 + " LEFT JOIN foodaverage on foodaverage.id = family_visitdetails.expenses_1";

            WhereQuery += " WHERE family_visit.id in (SELECT MAX(vid) FROM ( "
                       + " SELECT family.id as fid, family_visit.id as vid "
                       + " FROM family LEFT JOIN family_visit ON family_visit.family_id = family.id "
                       + " where family_visit.visit_name LIKE '%M%') as familyvisit GROUP BY fid) or family_visit.id is NULL";

            // family_visit.visitstate_id = 3 

            //+ " LEFT JOIN family_partner ON family_partner.family_id = family.id"
            //+ " LEFT JOIN partner ON family_partner.partner_id = partner.id"
            //+ " LEFT JOIN partnergroups on partner.partnergroup_id = partnergroups.id";
            //+" LEFT JOIN familymembersnumber on familymembersnumber.family_id = family.id where familymembersnumber.family_id = family.id";
            //+" LEFT JOIN family_income on family_income.family_id = family.id left join income on family_income.income_id = income.id";
            //+ " LEFT JOIN income on income.id = family_income.income_id";
            //string FromQuery = "FROM"
            //    + "hcsyria_f2f_test.family left JOIN hcsyria_f2f_test.parish on parish.id = family.parish_id"
            //    + "LEFT join hcsyria_f2f_test.street on street.id = family.street_id"
            //    + "LEFT join hcsyria_f2f_test.hometype on hometype.id = family.hometype_id"
            //    + "LEFT JOIN hcsyria_f2f_test.parish parish_id_home on parish_id_home.id = family.parish_id_home"
            //    + "LEFT JOIN hcsyria_f2f_test.isdisplaced on isdisplaced.id = family.isDisplaced_id"
            //    + "LEFT JOIN hcsyria_f2f_test.beds on beds.id = family.beds_id"
            //    + "LEFT JOIN hcsyria_f2f_test.livingroom on livingroom.id = family.livingroom_id;";
            //string SelectQuery = "SELECT family.id as 'Family ID',family.code as 'رمز العائلة',"
            //    + "(SELECT CONCAT(person.first_Name, ' ', person.father_name, ' ', person.last_name) FROM person LEFT JOIN person_family ON person_family.person_id = person.id LEFT JOIN family ON family.id = person_family.family_id  WHERE person_family.isReceiver = '1' AND family.id = `Family ID`)as 'المستلم',"
            //    + " GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك', GROUP_CONCAT(DISTINCT(partnergroups.name)) as 'المجموعة', GROUP_CONCAT(DISTINCT(CASE WHEN family_partner.IsActive = 1 THEN 'فعالة' ELSE 'غير فعالة' END)) AS 'الحالة', (CASE WHEN family.InEvaluation = 1 then 'نعم' else 'لا' END) AS 'تظهر في التقييم', (CASE WHEN family.approved = 1 then 'نعم' else 'لا' END) AS 'مدققة بالكامل',(CASE WHEN family.PDM = 1 then family.pdmdate else ' ' END) AS 'PDM',(CASE WHEN family.PDM = 1 then family.pdmby else ' ' END) AS 'PDM by',(CASE WHEN family.PVM = 1 then family.pvmdate else ' ' END) AS 'PVM',(CASE WHEN family.PVM = 1 then family.pvmby else ' ' END) AS 'PVM by',"
            //    + " (case when family.LivingWithFamily = 0 then 'لا' else (case when f.code is null then 'نعم' else f.code end)end) as 'تسكن مع عائلة أخرى',"
            //    + " (SELECT COUNT(person_family.id) FROM person_family WHERE person_family.family_id = family.id) as 'عدد الأفراد',"
            //    + " (SELECT COUNT(person_family.id) FROM person_family LEFT JOIN person ON person_family.person_id = person.id LEFT JOIN person_state ON person_state.person_id = person.id LEFT JOIN personstate ON person_state.personstate_id = personstate.id WHERE person_family.family_id = family.id AND person_state.current_state = '1' AND LOWER(personstate.type) = LOWER('Active')) as 'عدد المستفيدين',"
            //    + " street.name as 'موقع المنزل', family.address as 'شرح الموقع',"
            //    + " isdisplaced.name as 'النزوح', hometype.name as 'السكن الحالي', family.landline as 'رقم الهاتف', family.mobile as 'رقم الموبايل',"
            //    + " family.Note as 'ملاحظات الفريق', familyvisitstate.name as 'حالة الزيارة',"
            //    + " MAX(family_visit.Visit_date) as 'تاريخ آخر زيارة',"
            //    + " family.entredby AS 'مدخل البيانات', family.dateofentry as 'تاريخ إدخال البيانات'";
            //string FromQuery = " FROM"
            //    + " family LEFT JOIN family_partner ON family_partner.family_id = family.id"
            //    + " LEFT JOIN partner ON family_partner.partner_id = partner.id"
            //    + " LEFT JOIN partnergroups on partner.partnergroup_id = partnergroups.id"
            //    + " LEFT JOIN person_family ON person_family.family_id = family.id"
            //    + " LEFT JOIN person on person_family.person_id = person.id"
            //    + " LEFT JOIN street ON family.street_id = street.id"
            //    + " LEFT JOIN isdisplaced ON family.isDisplaced_id = isdisplaced.id"
            //    + " LEFT JOIN hometype ON family.hometype_id = hometype.id"
            //    + " LEFT JOIN familyvisitstate ON family.familyvisitstate_id = familyvisitstate.id"
            //    + " LEFT JOIN family_visit ON family_visit.family_id = family.id"
            //    + " LEFT JOIN family f ON family.id = f.living_with_family_id"
            //    + " LEFT JOIN parish ON family.parish_id = parish.id"
            //    + " LEFT JOIN beds ON family.beds_id = beds.id"
            //    + " LEFT JOIN livingroom ON family.livingroom_id = livingroom.id"
            //    + " LEFT JOIN family_buildingcondition ON family_buildingcondition.family_id = family.id"
            //    + " LEFT JOIN buildingcondition ON family_buildingcondition.buildingcondition_id = buildingcondition.id"
            //    + " LEFT JOIN family_electricaldavices ON family_electricaldavices.family_id = family.id"
            //    + " LEFT JOIN electricaldavices ON family_electricaldavices.electricaldavices_id = electricaldavices.id"
            //    + " LEFT JOIN family_income ON family_income.family_id = family.id"
            //    + " LEFT JOIN income ON family_income.income_id = income.id"
            //    + " LEFT JOIN family_expenses ON family_expenses.family_id = family.id"
            //    + " LEFT JOIN family_asset ON family_asset.family_id = family.id"
            //    + " LEFT JOIN asset ON family_asset.asset_id = asset.id"
            //    + " LEFT JOIN family_aid ON family_aid.family_id = family.id"
            //    + " LEFT JOIN aid ON family_aid.aid_id = aid.id"
            //    + " LEFT JOIN aidsource ON family_aid.aidsource_id = aidsource.id"
            //    + " LEFT JOIN aidperiod ON family_aid.aidperid_id = aidperiod.id"
            //    + " LEFT JOIN expenses ON family_expenses.expenses_id = expenses.id"
            //    + " LEFT JOIN expensestype ON family_expenses.expensestype_id = expensestype.id"
            //    + " LEFT JOIN family_loss ON family_loss.family_id = family.id"
            //    + " LEFT JOIN loss ON family_loss.loss_id = loss.id";

            if (AdditionalColumnsTables.Count != 0)
            {
                for (int i = 0; i < AdditionalColumnsTables.Count; i++)
                {
                    string tableName = AdditionalColumnsTables[i];
                    string tableName_ArabciName = AdditionalColumnsTables_ArabicName[i];
                    //SelectQuery += "," + "GROUP_CONCAT(DISTINCT(" + tableName + ".name)) as '" + tableName_ArabciName + "'";
                    
                    if (tableName == "personstate")
                    {
                        SelectQuery += ",GROUP_CONCAT(DISTINCT(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END)) as '" + tableName_ArabciName + "'";
                    }
                    else
                    {
                        SelectQuery += "," + "GROUP_CONCAT(DISTINCT(" + tableName + ".name)) as '" + tableName_ArabciName + "'";
                    }
                    
                    switch (tableName)
                    {
                        case "asset":
                            {
                                SelectQuery += "," + "(SELECT Count(family_asset.id) as 'عدد المنازل' from family_asset join family on family.id = family_asset.family_id left join asset on asset.id = family_asset.asset_id WHERE family_asset.asset_id = asset.id and family_id = family.id)";
                                //SelectQuery += "," + "(SELECT SUM(family_asset.income_4) FROM family_asset LEFT JOIN asset ON family_asset.asset_id = asset.id WHERE family_asset.family_id = family.id" + Get_AddFilter(FilterQuery, "asset.id") + ") as 'مجموع الممتلكات'";
                            }
                            break;

                        //case "income":
                        //    {
                        //        SelectQuery += "," + "(SELECT income.name from income left join family_income on family_income.income_id = income.id on family_income.family_id = family.id" + Get_AddFilter(FilterQuery, "income.id") + ") as 'الدخل الثابت للأسرة'";
                        //    }
                        //    break;

                            //case "cartype":
                            //    {
                            //        SelectQuery += "," + "(SELECT cartype.name FROM cartype left join family_cars where family_cars.id = cartype.id " + Get_AddFilter(FilterQuery, "cartype.id") + ") as 'نوع السيارة'";
                            //    }
                            //    break;

                            //case "expenses":
                            //    {
                            //        SelectQuery += "," + "(SELECT ROUND(SUM(CASE WHEN expensestype.name = 'سنوي' THEN family_expenses.amount / 12 ELSE family_expenses.amount END)) FROM family_expenses LEFT JOIN expenses ON family_expenses.expenses_id = expenses.id LEFT JOIN expensestype ON expensestype.ID = family_expenses.expensestype_id WHERE family_expenses.family_id = family.id" + Get_AddFilter(FilterQuery, "expenses.id") + ") as 'مجموع المصاريف الشهرية'";
                            //    }
                            //    break;

                            //case "aid":
                            //case "aidperiod":
                            //case "aidsource":
                            //    {
                            //        if (!aidAmountAdded)
                            //        {
                            //            SelectQuery += "," + "(SELECT SUM(family_aid.amount) FROM family_aid LEFT JOIN aid ON family_aid.aid_id = aid.id LEFT JOIN aidperiod ON family_aid.aidperid_id = aidperiod.id LEFT JOIN aidsource ON family_aid.aidsource_id = aidsource.id WHERE family_aid.family_id = family.id" + Get_AddFilter(FilterQuery, "aid.id") + Get_AddFilter(FilterQuery, "aidsource.id") + Get_AddFilter(FilterQuery, "aidperiod.id") + ") as 'مجموع المساعدات'";
                            //            aidAmountAdded = true;
                            //        }
                            //    }
                            //    break;

                            //case "loss":
                            //    {
                            //        SelectQuery += "," + "(SELECT SUM(family_loss.L_number) FROM family_loss LEFT JOIN loss ON family_loss.loss_id = loss.id WHERE family_loss.family_id = family.id" + Get_AddFilter(FilterQuery, "loss.id") + ") as 'مجموع الخسارات'";
                            //    }
                            //    break;
                    }
                }

                if (!String.IsNullOrWhiteSpace(FilterQuery))
                {
                    WhereQuery += " where 1 and " + FilterQuery;
                }

            }
            GroupQuery += " Group By family.id";

            //string GroupByQuery = "GROUP BY hcsyria_f2f_test.family.id";
            string OrderBy = " order by family.code";

            query = SelectQuery + FromQuery + WhereQuery + GroupQuery + OrderBy;
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        private string Get_AddFilter(string FilterQuery, string Name)
        {
            string AddFilter = "";
            if (FilterQuery.Contains(Name))
            {
                string toFind1 = Name;
                string toFind2 = ")";
                int start = FilterQuery.IndexOf(toFind1) + toFind1.Length;
                int end = FilterQuery.IndexOf(toFind2, start);
                AddFilter = " AND " + Name + FilterQuery.Substring(start, end - start) + ")";
            }

            return AddFilter;
        }

        public DataTable Get_Persons(string FilterQuery, List<string> AdditionalColumnsTables, List<string> AdditionalColumnsTables_ArabicName)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            string SelectQuery = @"SELECT  
    person.id as 'Person ID'    
    ,family_visit.id as 'Visit ID' 
    ,family.id as 'Family ID' 
    ,family.code as 'رمز العائلة'
    ,family_visit.visit_name as 'الزيارة'
    ,visitstate.name as 'حالة الزيارة'
    ,CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي'

    ,case when person_family.isReceiver = 1 THEN 
        (SELECT CONCAT(person.first_Name, ' ', person.father_name, ' ', person.last_name) 
        FROM person LEFT join person_family ON person_family.person_id = person.id 
        LEFT JOIN relation ON person_family.relation_id = relation.id 
        WHERE person_family.family_id = family.id 
        AND relation.name = 'زوج/ة' limit 1
        ) END AS 'الزوج/ة'

    , IFNULL(person_family.isReceiver,' ') as 'رب الأسرة'
    , IFNULL(relation.name,' ') as 'الصفة الأسرية'

    , IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as  'حالة الفرد'
    , IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة'
    , IFNULL(stateaddress.name, ' ') as 'مكان الإقامة'
    , IFNULL(person_state.State_Note, ' ') as 'وصف المكان'
    ,IFNULL(person.DOB,' ') as 'المواليد'
    ,(CASE year(CURDATE()) - year(person.DOB)  WHEN 0 THEN 1 ELSE year(CURDATE()) - year(person.DOB) END) as 'العمر'
    ,IFNULL(sex.name,' ') as 'الجنس'
    ,IFNULL(nationality.name,' ') as 'الجنسية'
    ,IFNULL(person.national_Number,' ') as 'الرقم الوطني'

    , (select maritalstatus.name 
        from person_maritalstatus 
        LEFT JOIN maritalstatus on maritalstatus.id = person_maritalstatus.maritalstatus_id 
        where person_maritalstatus.person_id = person.id 
        and current_state = 1 limit 1) as 'الحالة الاجتماعية'

    ,(case person_visitdetails.hasdisease WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل لديه أمراض؟'
    ,(case person_visitdetails.haschronic_medicine WHEN 0 then 'لا' WHEN 9 then 'نعم' ELSE '' END) as 'هل لديه ادوية دورية مزمنة؟'
    ,(case person_visitdetails.haswork WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل لديه عمل؟'
    ,(case person_visitdetails.hasmicroproject WHEN 0 then 'لا' WHEN 1 then 'نعم'  ELSE '' END) as 'هل استفاد من مشاريع صغيرة؟'
    ,(case person_visitdetails.aid_10 WHEN 0 then 'لا' WHEN 10 then 'نعم' ELSE '' END) as 'هل تلقى مساعدة بدل عسكرية؟'
    ,(case person.isEducated WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل متعلم؟'
    ,(case person_visitdetails.isStudent WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل طالب؟' ";


            //+ "  person_family.person_id as 'Person ID'" 
            //+ ", person_family.family_id as 'Family ID' "  
            //+ ", family.code as 'رمز العائلة'"
            //+ ", person_visitdetails.family_visit_id as 'Visit ID'"
            //+ ", family_visit.visit_name as 'الزيارة'"
            //+ ", CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي'"
            //+ ", case when person_family.isReceiver = 1 THEN "
            //        + " (SELECT CONCAT(person.first_Name, ' ', person.last_name) "
            //        + " FROM person LEFT join person_family ON person_family.person_id = person.id "
            //        + " LEFT JOIN relation ON person_family.relation_id = relation.id "
            //        + " WHERE person_family.family_id = family.id "
            //        + " AND relation.name = 'زوج/ة' limit 1" 
            //        + ") END AS 'الزوج/ة'"
            //+ ", IFNULL(relation.name, ' ') as 'الصفة الأسرية'"
            //+ ", IFNULL(person.DOB, ' ') as 'المواليد'"
            //+ ", (CASE year(CURDATE()) - year(person.DOB)  WHEN 0 THEN 1 ELSE year(CURDATE()) - year(person.DOB) END) as 'العمر'"
            //+ ", IFNULL(sex.name, ' ') as 'الجنس'"
            //+ ", IFNULL(nationality.name, ' ') as 'الجنسية'"
            //+ @", (select maritalstatus.name 
            //    from person_maritalstatus 
            //    LEFT JOIN maritalstatus on maritalstatus.id = person_maritalstatus.maritalstatus_id 
            //    where person_maritalstatus.person_id = person.id 
            //    and current_state = 1 limit 1) as 'الحالة الاجتماعية'"
            //+ ",IFNULL(person.national_Number, ' ') as 'الرقم الوطني'"
            //+ ",IFNULL(personstate.name, ' ') as 'حالة الفرد'"
            //+ ",IFNULL(person_state.personstate_address, ' ') as 'مكان الإقامة'"
            //+ ",(case person_visitdetails.hasdisease WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل لديه أمراض؟'"
            //+ ",(case person_visitdetails.haschronic_medicine WHEN 0 then 'لا' WHEN 9 then 'نعم' ELSE '' END) as 'هل لديه ادوية دورية مزمنة؟'"
            //+ ",(case person_visitdetails.haswork WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل لديه عمل؟'"
            //+ ",(case person_visitdetails.hasmicroproject WHEN 0 then 'لا' WHEN 15 then 'نعم'  ELSE '' END) as 'هل استفاد من مشاريع صغيرة؟'"
            //+ ",(case person_visitdetails.aid_10 WHEN 0 then 'لا' WHEN 10 then 'نعم' ELSE '' END) as 'هل تلقى مساعدة بدل عسكرية؟'"
            //+ ",(case person.isEducated WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل متعلم؟'"
            //+ ",(case person_visitdetails.isStudent WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل طالب؟'";


            string FromQuery = @"
    FROM person 
    LEFT JOIN person_family on person_family.person_id = person.id
    LEFT JOIN family on family.id = person_family.family_id  
    LEFT JOIN family_visit on family_visit.family_id = family.id
    LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id
    LEFT JOIN person_visitdetails on (person_visitdetails.person_id = person.id) 
                                 and (person_visitdetails.family_visit_id = family_visit.id)
    LEFT JOIN visitstate on family_visit.visitstate_id = visitstate.id 
    LEFT JOIN relation on relation.id= person_family.relation_id
    LEFT JOIN sex on sex.id= person.sex_id
    LEFT JOIN nationality on nationality.id= person.nationality_id 
    LEFT JOIN person_state on (person_state.person_id = person.id) and (person_state.family_id = family.id)
    LEFT JOIN personstate on personstate.id= person_state.personstate_id
    LEFT JOIN person_disease on person_disease.person_id = person.id
    LEFT JOIN disease on disease.id = person_disease.disease_id
    LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id
";
            //= " From person_family " 
            //+ " LEFT JOIN person on person.id = person_family.person_id "
            //+ " LEFT JOIN family on family.id = person_family.family_id"
            //+ " LEFT JOIN person_visitdetails on person_visitdetails.person_id = person.id"
            //+ " LEFT JOIN family_visit on family_visit.id = person_visitdetails.family_visit_id" 
            //+ " LEFT JOIN person_disease on person_disease.person_id = person.id"
            //+ " LEFT JOIN person_state on person_state.person_id = person_family.person_id"
            //+ " LEFT JOIN personstate on personstate.id = person_state.personstate_id" 
            //+ " LEFT JOIN person_maritalstatus on person_maritalstatus.person_id = person.id"
            //+ " LEFT JOIN relation on relation.id = person_family.relation_id"
            //+ " LEFT JOIN sex on sex.id = person.sex_id"
            //+ " LEFT JOIN nationality on nationality.id = person.nationality_id" 
            //+ " LEFT JOIN education on education.id = person.education_id";
             
            string WhereQuery = " WHERE person_state.current_state = '1'"
                        + " and family_visit.id in (SELECT MAX(vid) FROM("
                        + " SELECT family.id as fid, family_visit.id as vid "
                        + " FROM family LEFT JOIN family_visit ON family_visit.family_id = family.id "
                        + " where family_visit.visit_name LIKE '%M%') as familyvisit "
                        + " GROUP BY fid) " 
                        + " or family_visit.id is NULL";

            // family_visit.visitstate_id = 3 and

            //string SelectQuery = "SELECT person.id as 'Person ID', family.id as 'Family ID', CONCAT(person.first_Name, ' ', person.father_name, ' ', person.last_name) as 'اسم الشخص',"
            //    + " case when person_family.IsReceiver = 1 THEN"
            //    + " (SELECT GROUP_CONCAT(CONCAT(person.first_Name, ' ', person.last_name)) FROM person LEFT join person_family ON person_family.person_id = person.id LEFT JOIN relation ON person_family.relation_id = relation.id WHERE"
            //    + " person_family.family_id = family.id AND relation.name = 'زوج/ة')"
            //    + " END AS 'الزوج/ة',"
            //    + " family.code as 'العائلة', parish.name as 'الطائفة', person.national_Number as 'الرقم الوطني',"
            //    + " nationality.name as 'الجنسية', person.DOB as 'تاريخ الميلاد',"
            //    + " ( CASE year(CURDATE()) - year(person.DOB)  WHEN 0 THEN 1 ELSE year(CURDATE()) - year(person.DOB) END) as 'العمر',"
            //    + " maritalstatus.name as 'الحالة الإجتماعية', relation.name as 'الصفة الأسرية', personstate.name as 'حالة المستفيد',"
            //    + " (case person_family.IsReceiver when 0 then 'لا' else 'نعم' END) as 'المستلم',"
            //    + " (case person.IsEducated when 0 then 'لا' when 1 then 'نعم' END) as 'متعلم',"
            //    + " (case person.IsStudent when 0 then 'لا' when 1 then 'نعم' END) as 'طالب',"
            //    + "person.note as 'ملاحظات الفريق'";
            //      string FromQuery = " FROM person LEFT JOIN nationality ON person.nationality_id = nationality.id"
            //    + " LEFT JOIN maritalstatus ON person.maritalstatus_id = maritalstatus.id"
            //    + " LEFT JOIN person_family ON person_family.person_id = person.id"
            //    + " LEFT JOIN family ON person_family.family_id = family.id"
            //    + " LEFT JOIN parish ON parish.id = family.parish_id"
            //    + " LEFT JOIN relation ON person_family.relation_id = relation.id"
            //    + " LEFT JOIN person_state ON person_state.person_id = person.id"
            //    + " LEFT JOIN personstate ON person_state.personstate_id = personstate.id"
            //    + " LEFT JOIN sex ON person.sex_id = sex.id"
            //    + " LEFT JOIN person_education ON person_education.person_id = person.id"
            //    + " LEFT JOIN education ON person_education.education_id = education.id"
            //    + " LEFT JOIN educationtype ON person_education.educationtype_id = educationtype.id"
            //    + " LEFT JOIN person_workexp ON person_workexp.person_id = person.id"
            //    + " LEFT JOIN workexp ON person_workexp.workexp_id = workexp.id"
            //    + " LEFT JOIN workplace ON person_workexp.workplace_id = workplace.id"
            //    + " LEFT JOIN workfor ON person_workexp.workfor_id = workfor.id"
            //    + " LEFT JOIN workposition ON person_workexp.workposition_id = workposition.id"
            //    + " LEFT JOIN experience ON person_workexp.experience_id = experience.id"
            //    + " LEFT JOIN person_disease ON person.id = person_disease.person_id"
            //    + " LEFT JOIN disease ON disease.id = person_disease.disease_id"
            //    + " LEFT JOIN diseasecategory on disease.diseasecategory_id = diseasecategory.id";
            //string WhereQuery = "";


            if (AdditionalColumnsTables.Count != 0)
            {
                for (int i = 0; i < AdditionalColumnsTables.Count; i++)
                {
                    string tableName = AdditionalColumnsTables[i];
                    string tableName_ArabciName = AdditionalColumnsTables_ArabicName[i];
                    if (tableName == "personstate")
                    {
                        SelectQuery += ",GROUP_CONCAT(DISTINCT(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END)) as '" + tableName_ArabciName + "'";
                    }
                    else
                    {
                        SelectQuery += "," + "GROUP_CONCAT(DISTINCT(" + tableName + ".name)) as '" + tableName_ArabciName + "'";
                    }

                    switch (tableName)
                    {
                        case "disease":
                            {
                                SelectQuery += "," + "( SELECT GROUP_CONCAT(CASE disease.IsFatal WHEN 1 THEN 'Yes' Else 'No' END) FROM person_disease LEFT JOIN disease ON person_disease.disease_id = disease.id LEFT JOIN diseasecategory ON diseasecategory.id = disease.diseasecategory_id WHERE person_disease.person_id = person.id" + Get_AddFilter(FilterQuery, "disease.id") + Get_AddFilter(FilterQuery, "diseasecategory.id") + ") AS 'مرض مميت'";
                                SelectQuery += "," + "( SELECT GROUP_CONCAT(CASE disease.isdisability WHEN 1 THEN 'Yes' Else 'No' END) FROM person_disease LEFT JOIN disease ON person_disease.disease_id = disease.id LEFT JOIN diseasecategory ON diseasecategory.id = disease.diseasecategory_id WHERE person_disease.person_id = person.id" + Get_AddFilter(FilterQuery, "disease.id") + Get_AddFilter(FilterQuery, "diseasecategory.id") + ") AS 'احتياجات خاصة'";
                            }
                            break;
                      
                    }
                }

                if (!String.IsNullOrWhiteSpace(FilterQuery))
                {
                    WhereQuery += " and " + FilterQuery;
                }
            }

            string GroupByQuery = " Group by person_family.id "; // " group by person.id ";
            string OrderBy = " order by family.code ";
               
            query = SelectQuery + FromQuery + WhereQuery + GroupByQuery + OrderBy;
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataTable Get_Partners()
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            query = "SELECT partner.id as 'Partner ID', partner.logo as 'Logo', partner.name as 'الشريك', partnergroups.name as 'المجموعة',"
                + " (SELECT CASE count(family_partner.partner_donor_id) WHEN 0 THEN null ELSE count(family_partner.partner_donor_id) END FROM family_partner LEFT JOIN partner_donor on family_partner.partner_donor_id = partner_donor.id where partner_donor.partner_id = partner.id and family_partner.IsActive = 1) as 'عدد العائلات الفعالة',"
                + " (SELECT CASE count(family_partner.partner_donor_id) WHEN 0 THEN null ELSE count(family_partner.partner_donor_id) END FROM family_partner LEFT JOIN partner_donor on family_partner.partner_donor_id = partner_donor.id where partner_donor.partner_id = partner.id and family_partner.IsActive = 0) as 'عدد العائلات غير الفعالة',"
                + " (SELECT CASE COUNT(family.id) WHEN 0 THEN null ELSE COUNT(family.id) END FROM family LEFT JOIN family_partner ON family_partner.family_id = family.id "
                + " LEFT JOIN partner_donor on family_partner.partner_donor_id = partner_donor.id"
                + " WHERE partner_donor.partner_id = partner.id AND family.InEvaluation = '1') as 'عدد العائلات الداخلة في التقييم',"
                + " (SELECT CASE COUNT(family.id) WHEN 0 THEN null ELSE COUNT(family.id) END FROM family LEFT JOIN family_partner ON family_partner.family_id = family.id "
                + " LEFT JOIN partner_donor on family_partner.partner_donor_id = partner_donor.id"
                + " WHERE partner_donor.partner_id = partner.id AND family.InEvaluation = '0') as 'عدد العائلات غير الداخلة في التقييم',"
                + " (SELECT CASE COUNT(family_partner.id) WHEN 0 THEN null ELSE COUNT(family_partner.id) END FROM family_partner"
                + " LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id"
                + "  WHERE partner_donor.partner_id = partner.id) as 'عدد العائلات الكلي',"

                + " (SELECT COUNT(t1.partner_distribution_id) FROM partner_distribution LEFT JOIN"
                + " (SELECT partner_donor.partner_id as partner_id, partner_distribution.id as partner_distribution_id, MAX(partner_distribution_date.date) as max_date FROM partner_distribution LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id LEFT JOIN partner_distribution_date ON partner_distribution.id = partner_distribution_date.partner_distribution_id"
                + " GROUP BY partner_distribution.id) as t1"
                + " ON partner_distribution.id = t1.partner_distribution_id"
                + " WHERE"
                + " (t1.max_date >= DATE(NOW()) OR t1.max_date is null) AND t1.partner_id = partner.id GROUP BY t1.partner_id) as 'توزيعات قادمة',"


                + " (SELECT COUNT(t1.partner_distribution_id) FROM partner_distribution LEFT JOIN"
                + " (SELECT partner_donor.partner_id as partner_id, partner_distribution.id as partner_distribution_id, MAX(partner_distribution_date.date) as max_date FROM partner_distribution LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id LEFT JOIN partner_distribution_date ON partner_distribution.id = partner_distribution_date.partner_distribution_id"
                + "  GROUP BY partner_distribution.id) as t1"
                + " ON partner_distribution.id = t1.partner_distribution_id"
                + " WHERE"
                + " t1.max_date < DATE(NOW()) and(partner_distribution.recievedmoneyapproved = '0' or partner_distribution.admincost = '0') AND t1.partner_id = partner.id GROUP BY t1.partner_id) as 'توزيعات تمت ولم يتم تعبئة كامل البيانات المتعلقة بها',"


                + " (SELECT COUNT(t1.partner_distribution_id) FROM partner_distribution LEFT JOIN"
                + " (SELECT partner_donor.partner_id as partner_id, partner_distribution.id as partner_distribution_id, MAX(partner_distribution_date.date) as max_date FROM partner_distribution LEFT JOIN partner_donor on partner_donor.id = partner_distribution.partner_donor_id LEFT JOIN partner_distribution_date ON partner_distribution.id = partner_distribution_date.partner_distribution_id"
                + "  GROUP BY partner_distribution.id) as t1"
                + " ON partner_distribution.id = t1.partner_distribution_id"
                + " WHERE"
                + " t1.max_date < DATE(NOW()) and partner_distribution.recievedmoneyapproved = '1' and partner_distribution.admincost <> '0' AND t1.partner_id = partner.id GROUP BY t1.partner_id) as 'توزيعات تمت'"

                + " FROM partner LEFT JOIN partnergroups ON partner.partnergroup_id = partnergroups.id GROUP BY partner.id;";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;


        }

        public DataTable Get_Distribution()
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            //query = "CALL `Search_Distributions`();";

            query = "CALL `Partner_Distribution`(-1, 0,-1, '');";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataTable Get_Families_Visit(string visitname, string category, bool showResult)
        {
            //check connection//
            Program.buildConnection();
            query = "";
            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@visitname", visitname);
            sc.Parameters.AddWithValue("@category", category);
            if(category == "N/A")
            {
                query = "SELECT family.code as 'رمز العائلة'" + 
                    ",GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'" +
                    ",MAX(case WHEN donor.name like 'F2F' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '" +
                    ",MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '" 
                    //",GROUP_CONCAT(DISTINCT(donor.name)) as 'الممول'" +
                    //",GROUP_CONCAT(DISTINCT(CASE WHEN family_partner.IsActive = 1 THEN 'فعالة' ELSE 'غير فعالة' END)) AS 'الحالة'" 
                   + " ,family_visit.visit_name as 'الزيارة',"

                   + " family_visit.id as 'visit_id', "
                   + " family.id as 'family_id', "

                   + " visitstate.name as 'حالة الزيارة',"
                   + " IFNULL(visitor1.name, ' ') as 'متطوع 1',"
                   + " IFNULL(visitor2.name, ' ') as 'متطوع 2',"
                   + " family_visit.othervisitors as 'متطوعون آخرون',"
                   + " IFNULL(parish_id.name, ' ') as 'الطائفة',"
                   + " hometype.name as 'الملكية',"
                   + " family_visitdetails.expenses_amount_6_12_home as 'قيمة القرض/الرهن',"
                   + " expensestype_6_12_home.name as 'نوع القرض/الرهن',"
                   + " family_visitdetails.home_description as 'وصف المكان',"
                   + " IFNULL(parish_id_home.name, ' ') as 'طائفة المنزل',"
                   + " aidsource_5_3_home.name as 'جهة المساعدة (قرض/آجار)',"
                   + " family_visitdetails.aid_amount_5_3_home as 'قيمة المساعدة (قرض/آجار)',"
                   + " aidperiod_5_3_home.name as 'مدة المساعدة (قرض/آجار)',"
                   + " family_visitdetails.heirs_number as 'عدد الورثة',"
                   + " isdisplaced.name as 'النزوح',"
                   + " family_visitdetails.rooms_number as 'عدد الغرف',"
                   + " (case family_visitdetails.expenses_7_home WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ' ' END) as 'هل يوجد اشتراك أمبير',"
                   + " IFNULL(family_visitdetails.amper_number_7_home, ' ') as 'عدد الأمبيرات',"
                   + " IFNULL(family_visitdetails.expenses_amount_7_home, ' ') as 'قيمة مصروف الأمبير',"
                   + " (SELECT(case family_visitdetails.aid_4 WHEN 0 then 'لا' WHEN 4 then 'نعم' ELSE ' ' END)) as 'هل يوجد بدل أمبير',"
                   + " IFNULL(aidsource_4.name, ' ') as 'مصدر مساعدة بدل أمبير',"
                   + " IFNULL(family_visitdetails.aid_amount_4, ' ') as 'قيمة مساعدة بدل أمبير',"
                   + " IFNULL(aidperiod_4.name, ' ') as 'مدة مساعدة بدل أمبير',"
                   + " (case family_visitdetails.expenses_16_home WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل يوجد بطارية',"
                   + " (case family_visitdetails.expenses_17_home WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل يوجد طاقة',"
                   + " IFNULL(family_visitdetails.amper_number_17_home, ' ') as 'عدد امبيرات الطاقة',"
                   + " (case family_visitdetails.aid_16 WHEN 0 then 'لا' WHEN 16 then 'نعم' ELSE '' END) as 'هل يوجد بدل طاقة',"
                   + " IFNULL(aidsource_16.name, ' ') as 'مصدر المساعدة بدل طاقة',"
                   + " IFNULL(family_visitdetails.aid_amount_16, ' ') as '    قيمة المساعدة بدل طاقة',"
                   + " IFNULL(aidperiod_16.name, ' ') as 'مدة المساعدة بدل طاقة',"
                   + " (case family_visitdetails.isElectricity WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل تصل الكهرباء؟',"
                   + " family_visitdetails.electricity_note as 'ملاحظة الكهرباء',"
                   + " (case family_visitdetails.electricaldevices_1 WHEN 0 then 'لا يوجد' WHEN 1 then 'يوجد' when 2 THEN 'معطل' ELSE ' ' END) as 'حالة البراد',"
                   + " (case family_visitdetails.electricaldevices_2 WHEN 0 then 'لا يوجد' WHEN 1 then 'يوجد' when 2 THEN 'معطل' ELSE ' ' END) as 'حالة الغسالة',"
                   + " (case family_visitdetails.electricaldevices_3 WHEN 0 then 'لا يوجد' WHEN 1 then 'يوجد' when 2 THEN 'معطل' ELSE ' ' END) as 'حالة الفرن',"
                   + " (case family_visitdetails.`heating_cooling_devices/1` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ' ' END) as 'هل يوجد مدفاة كهربائية',"
                   + " (case family_visitdetails.`heating_cooling_devices/2` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ' ' END) as 'هل يوجد مروحة',"
                   + " (case family_visitdetails.`heating_cooling_devices/3` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ' ' END) as 'هل يوجد مدفاة مازوت',"
                   + " (case family_visitdetails.`heating_cooling_devices/4` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ' ' END) as 'هل يوجد مكيف',"
                   + " IFNULL(family_visitdetails.buildingcondition_1, ' ') as 'رطوبة',"
                   + " IFNULL(family_visitdetails.buildingcondition_2, ' ') as 'تشققات او فتحات في السقف',"
                   + " IFNULL(family_visitdetails.buildingcondition_3, ' ') as 'زجاج المنزل مكسور او مشعور',"
                   + " IFNULL(family_visitdetails.buildingcondition_5, ' ') as ' التمديدات الكهربائية',"
                   + " IFNULL(family_visitdetails.buildingcondition_8, ' ') as 'التمديدات الصحية',"
                   + " IFNULL(beds.name, ' ') as 'عدد الأسرّة',"
                   + " IFNULL(livingroom.name, ' ') as 'غرفة المعيشة',"

                   //cars
                   + " (case family_visitdetails.asset_3 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل يوجد سيارة؟',"
                   + @"(case family_visitdetails.asset_3 WHEN 1 then cars_details.cars_info
                        else '' end) AS 'تفاصيل السيارة' ,"

                   //assets
                   + " (case family_visitdetails.isAsset WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل يوجد ممتلكات إضافية؟',"
                   + @"(case family_visitdetails.isAsset WHEN 1 then assets_details.assets_info
                        else '' end) AS 'تفاصيل الملك' ,"

                   + " (case family_visitdetails.expenses_1 WHEN 1 then 'تحت المعدل' WHEN 2 then 'معدل' WHEN 3 then 'فوق المعدل' ELSE '' END) as 'مصروف طعام',"
                   + " family_visitdetails.expenses_amount_3 as 'مصروف فواتير الهاتف',"
                   + " family_visitdetails.expenses_amount_19 as 'مصروف فواتير المياه',"
                   + " family_visitdetails.expenses_amount_20 as 'مصروف منظفات',"
                   + " family_visitdetails.expenses_amount_2_home as 'مصروف مواصلات',"
                   + " family_visitdetails.expenses_amount_11 as 'مصروف ديون',"
                   + " family_visitdetails.expenses_amount_21 as 'مصروف دخان',"
                   + " family_visitdetails.expenses_amount_22 as 'مصروف حيوانات أليفة',"
                   + " (case family_visitdetails.expenses_10 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'مصاريف أخرى',"
                   + " family_visitdetails.expenses_amount_10 as 'قيمة المصاريف الأخرى',"

                   + " (case family_visitdetails.SellingFurniture WHEN 1 then 'نعم' WHEN 0 then 'لا' ELSE '' END) as 'هل تبيع أغراض المنزل؟',"
                   + " (case `family_visitdetails`.`SellingFurniture_type_id/1` WHEN 1 then 'نعم' WHEN 0 then 'لا' ELSE '' END) as 'أغراض أساسية',"
                   + " (case family_visitdetails.`SellingFurniture_type_id/2` WHEN 1 then 'نعم' WHEN 0 then 'لا' ELSE '' END) as 'أغراض ثانوية',"
                   + " (case family_visitdetails.income_11 WHEN 1 then 'يوجد ويصرف' WHEN 2 then 'يوجد ولا يصرف' when 3 THEN 'لا يوجد مدخرات' ELSE ' ' END) as 'هل تصرف من المدخرات؟',"

                   //income//
                   + " (case family_visitdetails.hasincome WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ' ' END) as 'هل يوجد دخل ثابت؟',"
                   + @"(case family_visitdetails.hasincome WHEN 1 then income_details.income_info
                        else '' end) AS 'تفاصيل الدخل' ,"

                   + " (case family_visitdetails.income_12 WHEN 0 then 'لا' WHEN 12 then 'نعم' ELSE '' END) as 'هل يوجد مساعدة أصدقاء / أقارب؟',"
                   + " IFNULL(income_relation_id_12.name, ' ') as 'الصفة الأسرية',"
                   + " IFNULL(family_visitdetails.income_address_12, ' ') as 'مكان الإقامة',"
                   + " family_visitdetails.aid_amount_30 as 'قيمة مساعدة الأقارب',"
                   + " aidperiod_30.name as 'مدة مساعدة الأقارب',"
                   + " (select(case `family_visitdetails`.`aid_11` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'مساعدة سلة غذائية؟',"
                   + " aidsource_11.name as 'سلة غذائية/مصدر مساعدة',"
                   + " family_visitdetails.aid_amount_11 as 'سلة غذائية/قيمة مساعدة',"
                   + " aidperiod_11.name as 'سلة غذائية/مدة مساعدة',"
                   + " family_visitdetails.aid_note_11 as 'سلة غذائية/ملاحظة',"
                   + " (select(case `family_visitdetails`.`aid_12` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'مساعدة منظفات؟',"
                   + " aidsource_12.name as 'منظفات/مصدر مساعدة',"
                   + " family_visitdetails.aid_amount_12 as 'منظفات/قيمة مساعدة',"
                   + " aidperiod_12.name as 'منظفات/مدة مساعدة',"
                   + " family_visitdetails.aid_note_12 as 'منظفات/ملاحظة',"
                   + " (select(case `family_visitdetails`.`aid_20` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'مساعدة طعام؟',"
                   + " aidsource_20.name as 'طعام/مصدر مساعدة',"
                   + " family_visitdetails.aid_amount_20 as 'طعام/قيمة مساعدة',"
                   + " aidperiod_20.name as 'طعام/مدة مساعدة',"
                   + " family_visitdetails.aid_note_20 as 'طعام/ملاحظة',"
                   + " (select(case `family_visitdetails`.`aid_19` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'مساعدة رواتب مسنين؟',"
                   + " aidsource_19.name as 'رواتب مسنين/مصدر مساعدة',"
                   + " family_visitdetails.aid_amount_19 as 'رواتب مسنين/قيمة مساعدة',"
                   + " aidperiod_19.name as 'رواتب مسنين/مدة مساعدة',"
                   + " family_visitdetails.aid_note_19 as 'رواتب مسنين/ملاحظة ',"
                   + " (select(case `family_visitdetails`.`aid_14` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'مساعدة بدل محروقات؟',"
                   + " aidsource_14.name as 'محروقات/مصدر مساعدة',"
                   + " family_visitdetails.aid_amount_14 as 'محروقات/قيمة مساعدة',"
                   + " aidperiod_14.name as 'محروقات/مدة مساعدة',"
                   + " (select(case `family_visitdetails`.`aid_17_home` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'مساعدة ترميم؟',"
                   + " aidsource_17_home.name as 'ترميم/مصدر مساعدة',"
                   + " family_visitdetails.aid_amount_17_home as 'ترميم/قيمة مساعدة',"
                   + " aidperiod_17_home.name as 'ترميم/مدة مساعدة',"
                   + " family_visitdetails.aid_note_17_home as 'ترميم/ملاحظة',"
                   + " (select(case `family_visitdetails`.`aid_16_home` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END)) as 'مساعدة أخرى؟',"
                   + " aidsource_16_home.name as 'أخرى/مصدر مساعدة',"
                   + " family_visitdetails.aid_amount_16_home as 'أخرى/قيمة مساعدة',"
                   + " aidperiod_16_home.name as 'أخرى/مدة مساعدة',"
                   + " family_visitdetails.aid_note_16_home as 'أخرى/ملاحظة',"
                   + " family_visitdetails.family_note as 'ملاحظة العائلة'"

                   + " FROM family_visitdetails "
                   + " LEFT JOIN family_visit on family_visit.id = family_visitdetails.family_visit_id"
                   + " LEFT JOIN family on family.id = family_visit.family_id"
                   + " LEFT JOIN family_partner on family_partner.family_id = family.id"
                   + " LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id"
                   + " LEFT JOIN partner on partner.id = partner_donor.partner_id"
                   + " LEFT JOIN donor on donor.id = partner_donor.donor_id"
                   + " LEFT JOIN visitor visitor1 on visitor1.id = family_visit.visitor1_id"
                   + " LEFT JOIN visitor visitor2 on visitor2.id = family_visit.visitor2_id"
                   + " LEFT JOIN visittype on visittype.id = family_visit.visittype_id"
                   + " LEFT JOIN visitstate on visitstate.id = family_visit.visitstate_id"
                   + " LEFT join hometype on hometype.id = family_visitdetails.hometype_id"
                   + " LEFT JOIN isdisplaced on isdisplaced.id = family_visitdetails.isdisplaced_id"
                   + " LEFT JOIN beds on beds.id = family_visitdetails.beds_id"
                   + " LEFT JOIN livingroom on livingroom.id = family_visitdetails.livingroom_id"
                   + " LEFT JOIN foodaverage on foodaverage.id = family_visitdetails.expenses_1"
                   + " LEFT JOIN aidsource aidsource_5_3_home on aidsource_5_3_home.id = family_visitdetails.aidsource_5_3_home"
                   + " LEFT JOIN aidperiod aidperiod_5_3_home on aidperiod_5_3_home.id = family_visitdetails.aidperiod_5_3_home"
                   + " LEFT JOIN aidsource aidsource_4 on aidsource_4.id = family_visitdetails.aidsource_4"
                   + " LEFT JOIN aidperiod aidperiod_4 on aidperiod_4.id = family_visitdetails.aidperiod_4"
                   + " LEFT JOIN aidsource aidsource_14 on aidsource_14.id = family_visitdetails.aidsource_14"
                   + " LEFT JOIN aidperiod aidperiod_14 on aidperiod_14.id = family_visitdetails.aidperiod_14"
                   + " LEFT JOIN aidsource aidsource_16 on aidsource_16.id = family_visitdetails.aidsource_16"
                   + " LEFT JOIN aidperiod aidperiod_16 on aidperiod_16.id = family_visitdetails.aidperiod_16"
                   + " LEFT JOIN aidsource aidsource_11 on aidsource_11.id = family_visitdetails.aidsource_11"
                   + " LEFT JOIN aidperiod aidperiod_11 on aidperiod_11.id = family_visitdetails.aidperiod_11"
                   + " LEFT JOIN aidsource aidsource_12 on aidsource_12.id = family_visitdetails.aidsource_12"
                   + " LEFT JOIN aidperiod aidperiod_12 on aidperiod_12.id = family_visitdetails.aidperiod_12"
                   + " LEFT JOIN aidsource aidsource_20 on aidsource_20.id = family_visitdetails.aidsource_20"
                   + " LEFT JOIN aidperiod aidperiod_20 on aidperiod_20.id = family_visitdetails.aidperiod_20"
                   + " LEFT JOIN aidsource aidsource_19 on aidsource_19.id = family_visitdetails.aidsource_19"
                   + " LEFT JOIN aidperiod aidperiod_19 on aidperiod_19.id = family_visitdetails.aidperiod_19"
                   + " LEFT JOIN aidperiod aidperiod_30 on aidperiod_30.id = family_visitdetails.aidperiod_30"
                   + " LEFT JOIN aidsource aidsource_16_home on aidsource_16_home.id = family_visitdetails.aidsource_16_home"
                   + " LEFT JOIN aidperiod aidperiod_16_home on aidperiod_16_home.id = family_visitdetails.aidperiod_16_home"
                   + " LEFT JOIN aidsource aidsource_17_home on aidsource_17_home.id = family_visitdetails.aidsource_17_home"
                   + " LEFT JOIN aidperiod aidperiod_17_home on aidperiod_17_home.id = family_visitdetails.aidperiod_17_home"
                   + " LEFT JOIN parish parish_id on parish_id.id = family.parish_id"
                   + " LEFT JOIN parish parish_id_home on parish_id_home.id = family_visitdetails.parish_id_home"
                   + " LEFT JOIN expensestype expensestype_6_12_home on expensestype_6_12_home.id = family_visitdetails.expensestype_6_12_home"
                   + " LEFT JOIN expensestype expensestype_6_home2 on expensestype_6_home2.id = family_visitdetails.expensestype_6_home2"
                   + " LEFT JOIN relation income_relation_id_12 on income_relation_id_12.id = family_visitdetails.income_relation_id_12"

                   //+ " LEFT JOIN family_assets on family_assets.visit_id = family_visit.id"
                   //+ " LEFT JOIN asset on asset.id = family_assets.asset_id"
                   //+ " LEFT JOIN hometype asset_hometype on asset_hometype.id = family_assets.hometype_id_asset"

                   //+ " LEFT JOIN family_cars on family_cars.visit_id = family_visit.id"
                   //+ " LEFT JOIN hometype car_hometype on car_hometype.id = family_cars.asset_hometype_id"
                   //+ " LEFT JOIN expensestype car_expensestype on car_expensestype.id = family_cars.expensestype_18"

                   //+ " LEFT JOIN family_income on family_income.visit_id = family_visit.id"
                   //+ " LEFT JOIN income on income.id = family_income.income_id"

                   + @" LEFT JOIN(
                SELECT family_assets.family_id, family_assets.visit_id
                       , GROUP_CONCAT(CONCAT(IFNULL(asset_hometype.name, '')
                       , ' - ' , IFNULL(family_assets.expenses_amount_6_asset, 'N/A')
                       , ' - ' , IFNULL(family_assets.expenses_amount_12_asset, 'N/A')
                       , ' - ' , IFNULL(family_assets.income_4, 'N/A')
                       , ' - ' , IFNULL(family_assets.asset_heirs_number, 'N/A')
                       , ' - ' , IFNULL(family_assets.asset_address, 'N/A')
                       , ' - ' , (case family_assets.isLoss WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'N/A' END)
                       , ' - ' , IFNULL(family_assets.isLoss_note, 'N/A')) SEPARATOR ', ') AS assets_info
                FROM family_assets
                LEFT JOIN asset on asset.id = family_assets.asset_id 
                LEFT JOIN hometype asset_hometype on asset_hometype.id = family_assets.hometype_id_asset 
                GROUP BY family_assets.family_id,visit_id
            ) assets_details ON assets_details.family_id = family.id and assets_details.visit_id = family_visit.id "
            
                               + @" LEFT JOIN(
                SELECT family_cars.family_id, family_cars.visit_id
                       , GROUP_CONCAT(CONCAT(IFNULL(car_hometype.name, '')
                       , ' - ' , IFNULL(family_cars.asset_note, 'N/A')
                       , ' - ' , IFNULL(family_cars.asset_release, 'N/A')
                       , ' - ' , (case family_cars.asset_type WHEN 1 then 'عمومي' WHEN 2 then 'خاص' ELSE 'N/A' END)
                       , ' - ' , IFNULL(car_expensestype.name, 'N/A') 
                       , ' - ' , IFNULL(family_cars.expenses_amount_18, 'N/A')
                       , ' - ' , (case family_cars.loss_4 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'N/A' END)
                       , ' - ' , IFNULL(family_cars.loss_note_4, 'N/A')) SEPARATOR ', ') AS cars_info
                FROM family_cars
                LEFT JOIN hometype car_hometype on car_hometype.id = family_cars.asset_hometype_id 
                LEFT JOIN expensestype car_expensestype on car_expensestype.id = family_cars.expensestype_18 
                GROUP BY family_cars.family_id,visit_id
            ) cars_details ON cars_details.family_id = family.id and cars_details.visit_id = family_visit.id "
            
                               + @" LEFT JOIN(
                SELECT family_income.family_id, family_income.visit_id
                       , GROUP_CONCAT(CONCAT(IFNULL(income.name, '')
                       , ' - ', IFNULL(family_income.income_amount, '')
                       , ' - ', IFNULL(family_income.income_note, '')) SEPARATOR ', ') AS income_info
                FROM family_income
                LEFT JOIN income ON income.id = family_income.income_id
                GROUP BY family_income.family_id,visit_id
            ) income_details ON income_details.family_id = family.id and income_details.visit_id = family_visit.id "
            
                               + " WHERE family_visit.visit_name like @visitname"
                               + " Group By family.code"
                               + " ORDER BY family.code";
            }
            else if(category == "الممتلكات")
            {
                if (!showResult)
                {
                    query = @"SELECT family.code as 'رمز العائلة'
                    ,GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'
                    ,MAX(case WHEN donor.name like 'F2F' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '
                    ,MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '
                    ,family_visit.visit_name as 'الزيارة'
                    ,family_visit.id as 'visit_id'
                    ,family.id as 'family_id'
                    ,visitstate.name as 'حالة الزيارة'
                    ,IFNULL(visitor1.name, 'N/A') as 'متطوع 1'
                    ,IFNULL(visitor2.name, 'N/A') as 'متطوع 2'
                    ,family_visit.othervisitors as 'متطوعون آخرون'
                    ,IFNULL(parish.name, 'N/A') as 'الطائفة'
                    ,IFNULL(asset.name, 'N/A') as 'الملك'
                    ,IFNULL(asset_hometype.name, 'N/A') as 'نوع الملك'
                    ,IFNULL(family_assets.expenses_amount_6_asset, 'N/A') as 'قيمة القسط'
                    ,IFNULL(family_assets.expenses_amount_12_asset, 'N/A') as 'قيمة القرض'
                    ,(case family_assets.isLoss WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'N/A' END) as 'الملك مؤجر؟'
                    ,IFNULL(family_assets.asset_heirs_number, 'N/A') as 'عدد الورثة'
                    ,IFNULL(family_assets.asset_address, 'N/A') as 'الموقع'
                    ,(case family_assets.isLoss WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'N/A' END) as 'تمت خسارتها؟'
                    ,IFNULL(family_assets.isLoss_note, 'N/A') as 'ملاحظة الخسارة'

                    FROM 
                        family_assets
                        LEFT JOIN family ON family.id = family_assets.family_id
                        LEFT JOIN family_visit ON family_visit.id = family_assets.visit_id
                        LEFT JOIN family_partner ON family_partner.family_id = family.id
                        LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner ON partner.id = partner_donor.partner_id
                        LEFT JOIN donor ON donor.id = partner_donor.donor_id
                        LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id
                        LEFT JOIN parish ON parish.id = family.parish_id
                        LEFT JOIN asset on asset.id = family_assets.asset_id 
                        LEFT JOIN hometype asset_hometype on asset_hometype.id = family_assets.hometype_id_asset
                        LEFT JOIN visitor visitor1 on visitor1.id = family_visit.visitor1_id
                        LEFT JOIN visitor visitor2 on visitor2.id = family_visit.visitor2_id
                    WHERE family_visit.visit_name LIKE '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, family.id, family_visit.id,  asset.name, family_assets.isLoss, family_assets.isLoss_note,family_assets.asset_heirs_number,family_assets.asset_address,family_assets.income_4,family_assets.hometype_id_asset ORDER BY family.code, asset.name; ";
                }
                else
                {
                    query = @"SELECT 
                    family.code as 'رمز العائلة',
                    GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                    MAX(CASE 
                            WHEN donor.name LIKE 'F2F' THEN 
                                CASE 
                                    WHEN family_partner.IsActive = 1 AND donor.name LIKE 'F2F' THEN 'فعالة' 
                                    ELSE 'غير فعالة' 
                                END 
                            ELSE '' 
                        END) as 'الممول F2F ',
                    MAX(CASE 
                            WHEN donor.name LIKE 'MPC' THEN 
                                CASE 
                                    WHEN family_partner.IsActive = 1 AND donor.name LIKE 'MPC' THEN 'فعالة' 
                                    ELSE 'غير فعالة' 
                                END 
                            ELSE '' 
                        END) as 'الممول MPC ',
                    family_visit.visit_name as 'الزيارة',
                    family_visit.id as 'visit_id',
                    family.id as 'family_id',
                    visitstate.name as 'حالة الزيارة',
                    IFNULL(visitor1.name, 'N/A') as 'متطوع 1',
                    IFNULL(visitor2.name, 'N/A') as 'متطوع 2',
                    family_visit.othervisitors as 'متطوعون آخرون',
                    IFNULL(parish.name, 'N/A') as 'الطائفة',
                    COUNT(DISTINCT asset.id) as 'عدد الممتلكات',
                    GROUP_CONCAT(DISTINCT asset.name SEPARATOR ', ') as 'الملك',
                    GROUP_CONCAT(DISTINCT asset_hometype.name SEPARATOR ', ') as 'نوع الملك',
                    GROUP_CONCAT(DISTINCT family_assets.expenses_amount_6_asset SEPARATOR ', ') as 'قيمة القسط',
                    GROUP_CONCAT(DISTINCT family_assets.expenses_amount_12_asset SEPARATOR ', ') as 'قيمة القرض',
                    GROUP_CONCAT(DISTINCT CASE family_assets.income_4 
                            WHEN 0 THEN 'لا' 
                            WHEN 1 THEN 'نعم' 
                            ELSE 'N/A' 
                        END SEPARATOR ', ') as 'الملك مؤجر ؟',
                    GROUP_CONCAT(DISTINCT family_assets.asset_heirs_number SEPARATOR ', ') as 'عدد الورثة',
                    GROUP_CONCAT(DISTINCT family_assets.asset_address SEPARATOR ', ') as 'الموقع',
                    GROUP_CONCAT(DISTINCT CASE family_assets.isLoss 
                            WHEN 0 THEN 'لا' 
                            WHEN 1 THEN 'نعم' 
                            ELSE 'N/A' 
                        END SEPARATOR ', ') as 'تمت خسارتها؟',
                    GROUP_CONCAT(DISTINCT family_assets.isLoss_note SEPARATOR ', ') as 'ملاحظة الخسارة'
                FROM 
                    family_assets
                    LEFT JOIN family ON family.id = family_assets.family_id
                    LEFT JOIN family_visit ON family_visit.id = family_assets.visit_id
                    LEFT JOIN family_partner ON family_partner.family_id = family.id
                    LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                    LEFT JOIN partner ON partner.id = partner_donor.partner_id
                    LEFT JOIN donor ON donor.id = partner_donor.donor_id
                    LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id
                    LEFT JOIN parish ON parish.id = family.parish_id
                    LEFT JOIN asset on asset.id = family_assets.asset_id 
                    LEFT JOIN hometype asset_hometype on asset_hometype.id = family_assets.hometype_id_asset
                    LEFT JOIN visitor visitor1 on visitor1.id = family_visit.visitor1_id
                    LEFT JOIN visitor visitor2 on visitor2.id = family_visit.visitor2_id
                WHERE 
                    family_visit.visit_name LIKE '" + visitname + "' GROUP BY family.code,  family_visit.visit_name, visitstate.name, family.id, family_visit.id ORDER BY family.code, asset.name; ";
                }
            }
            else if(category == "السيارات")
            {
                if (!showResult)
                {
                    query = @"SELECT family.code as 'رمز العائلة'
                    ,GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'
                    ,MAX(case WHEN donor.name like 'F2F' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '
                    ,MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '
                    ,family_visit.visit_name as 'الزيارة'
                    ,family_visit.id as 'visit_id'
                    ,family.id as 'family_id'
                    ,visitstate.name as 'حالة الزيارة'
                    ,IFNULL(visitor1.name, 'N/A') as 'متطوع 1'
                    ,IFNULL(visitor2.name, 'N/A') as 'متطوع 2'
                    ,family_visit.othervisitors as 'متطوعون آخرون'
                    ,IFNULL(parish.name, 'N/A') as 'الطائفة'
                    ,IFNULL(asset_hometype.name, 'N/A') as 'نوع الملك'
                    ,IFNULL(family_cars.asset_note, 'N/A') as 'وصف السيارة'
                    ,IFNULL(family_cars.asset_release, 'N/A') as 'سنة الإصدار'
                    ,(case family_cars.asset_type WHEN 1 then 'عمومي' WHEN 2 then 'خاص' ELSE 'N/A' END) as 'نوع السيارة'
                    ,IFNULL(family_cars.expenses_amount_18, 'N/A') as 'قيمة مصروف البنزين'
                    ,(case family_cars.expensestype_18 WHEN 1 then 'شهري' WHEN 1 then 'سنوي' ELSE 'N/A' END) as 'نوع مصروف البنزين'
                    ,(case family_cars.loss_4 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'N/A' END) as 'تمت خسارتها؟'
                    ,IFNULL(family_cars.loss_note_4, 'N/A') as 'سبب الخسارة'

                    FROM 
                        family_cars
                        LEFT JOIN family ON family.id = family_cars.family_id
                        LEFT JOIN family_visit ON family_visit.id = family_cars.visit_id
                        LEFT JOIN family_partner ON family_partner.family_id = family.id
                        LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner ON partner.id = partner_donor.partner_id
                        LEFT JOIN donor ON donor.id = partner_donor.donor_id
                        LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id
                        LEFT JOIN parish ON parish.id = family.parish_id
                        LEFT JOIN hometype asset_hometype on asset_hometype.id = family_cars.asset_hometype_id
                        LEFT JOIN visitor visitor1 on visitor1.id = family_visit.visitor1_id
                        LEFT JOIN visitor visitor2 on visitor2.id = family_visit.visitor2_id
                        LEFT JOIN expensestype on expensestype.id = family_cars.expensestype_18 
                    WHERE family_visit.visit_name LIKE '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, family.id, family_visit.id, family_cars.asset_note, family_cars.asset_release,family_cars.expensestype_18,family_cars.expenses_amount_18,family_cars.loss_4,family_cars.loss_note_4 ORDER BY family.code; ";
                }
                else
                {
                    query = @"SELECT family.code as 'رمز العائلة'
                    ,GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'
                    ,MAX(case WHEN donor.name like 'F2F' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '
                    ,MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '
                    ,family_visit.visit_name as 'الزيارة'
                    ,family_visit.id as 'visit_id'
                    ,family.id as 'family_id'
                    ,visitstate.name as 'حالة الزيارة'
                    ,IFNULL(visitor1.name, 'N/A') as 'متطوع 1'
                    ,IFNULL(visitor2.name, 'N/A') as 'متطوع 2'
                    ,family_visit.othervisitors as 'متطوعون آخرون'
                    ,IFNULL(parish.name, 'N/A') as 'الطائفة'
                    ,COUNT(DISTINCT family_cars.id) as 'عدد السيارات'
                    ,GROUP_CONCAT(DISTINCT asset_hometype.name SEPARATOR ', ') as 'نوع الملك'
                    ,GROUP_CONCAT(DISTINCT family_cars.asset_note SEPARATOR ', ') as 'وصف السيارة'
                    ,GROUP_CONCAT(DISTINCT case family_cars.asset_type WHEN 1 then 'عمومي' WHEN 2 then 'خاص' ELSE 'N/A' END SEPARATOR ', ') as 'نوع السيارة'
                    ,GROUP_CONCAT(DISTINCT family_cars.expenses_amount_18 SEPARATOR ', ') as 'قيمة مصروف البنزين'
                    ,GROUP_CONCAT(DISTINCT case family_cars.expensestype_18 WHEN 1 then 'شهري' WHEN 2 then 'سنوي' ELSE 'N/A' END SEPARATOR ', ') as 'نوع مصروف البنزين'        
                    ,GROUP_CONCAT(DISTINCT family_cars.loss_4 SEPARATOR ', ') as 'تمت خسارتها؟'  
                    ,GROUP_CONCAT(DISTINCT family_cars.loss_note_4 SEPARATOR ', ') as 'سبب الخسارة'

                    FROM 
                        family_cars
                        LEFT JOIN family ON family.id = family_cars.family_id
                        LEFT JOIN family_visit ON family_visit.id = family_cars.visit_id
                        LEFT JOIN family_partner ON family_partner.family_id = family.id
                        LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner ON partner.id = partner_donor.partner_id
                        LEFT JOIN donor ON donor.id = partner_donor.donor_id
                        LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id
                        LEFT JOIN parish ON parish.id = family.parish_id
                        LEFT JOIN hometype asset_hometype on asset_hometype.id = family_cars.asset_hometype_id
                        LEFT JOIN visitor visitor1 on visitor1.id = family_visit.visitor1_id
                        LEFT JOIN visitor visitor2 on visitor2.id = family_visit.visitor2_id
                        LEFT JOIN expensestype on expensestype.id = family_cars.expensestype_18 
                    WHERE family_visit.visit_name LIKE '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, family.id, family_visit.id ORDER BY family.code; ";
                }
            }
            else if(category == "الدخل")
            {
                if (!showResult)
                {
                    query = @"SELECT family.code as 'رمز العائلة'
                    ,GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'
                    ,MAX(case WHEN donor.name like 'F2F' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '
                    ,MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '
                    ,family_visit.visit_name as 'الزيارة'
                    ,family_visit.id as 'visit_id'
                    ,family.id as 'family_id'
                    ,visitstate.name as 'حالة الزيارة'
                    ,IFNULL(visitor1.name, 'N/A') as 'متطوع 1'
                    ,IFNULL(visitor2.name, 'N/A') as 'متطوع 2'
                    ,family_visit.othervisitors as 'متطوعون آخرون'
                    ,IFNULL(parish.name, 'N/A') as 'الطائفة'
                    ,IFNULL(income.name, 'N/A') as 'الدخل'
                    ,IFNULL(family_income.income_amount, 'N/A') as 'قيمة الدخل'
                    ,IFNULL(family_income.income_note, 'N/A') as 'ملاحظة الدخل'
                    
                    FROM 
                        family_income
                        LEFT JOIN family ON family.id = family_income.family_id
                        LEFT JOIN family_visit ON family_visit.id = family_income.visit_id
                        LEFT JOIN family_partner ON family_partner.family_id = family.id
                        LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner ON partner.id = partner_donor.partner_id
                        LEFT JOIN donor ON donor.id = partner_donor.donor_id
                        LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id
                        LEFT JOIN parish ON parish.id = family.parish_id
                        LEFT JOIN visitor visitor1 on visitor1.id = family_visit.visitor1_id
                        LEFT JOIN visitor visitor2 on visitor2.id = family_visit.visitor2_id
                        LEFT JOIN income on family_income.income_id = income.id 
                    WHERE family_visit.visit_name LIKE '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, family.id, family_visit.id, income.name, family_income.income_amount,family_income.income_note ORDER BY family.code, income.name; ";
                }
                else
                {
                    query = @"SELECT family.code as 'رمز العائلة'
                    ,GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'
                    ,MAX(case WHEN donor.name like 'F2F' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '
                    ,MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '
                    ,family_visit.visit_name as 'الزيارة'
                    ,family_visit.id as 'visit_id'
                    ,family.id as 'family_id'
                    ,visitstate.name as 'حالة الزيارة'
                    ,IFNULL(visitor1.name, 'N/A') as 'متطوع 1'
                    ,IFNULL(visitor2.name, 'N/A') as 'متطوع 2'
                    ,family_visit.othervisitors as 'متطوعون آخرون'
                    ,IFNULL(parish.name, 'N/A') as 'الطائفة'
                    ,COUNT(DISTINCT family_income.id) as 'عدد مصادر الدخل'
                    ,GROUP_CONCAT(DISTINCT income.name SEPARATOR ', ') as 'الدخل'
                    ,GROUP_CONCAT(DISTINCT family_income.income_amount SEPARATOR ', ') as 'قيمة الدخل'
                    ,GROUP_CONCAT(DISTINCT family_income.income_note SEPARATOR ', ') as 'ملاحظة الدخل'

                    FROM 
                        family_income
                        LEFT JOIN family ON family.id = family_income.family_id
                        LEFT JOIN family_visit ON family_visit.id = family_income.visit_id
                        LEFT JOIN family_partner ON family_partner.family_id = family.id
                        LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner ON partner.id = partner_donor.partner_id
                        LEFT JOIN donor ON donor.id = partner_donor.donor_id
                        LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id
                        LEFT JOIN parish ON parish.id = family.parish_id
                        LEFT JOIN visitor visitor1 on visitor1.id = family_visit.visitor1_id
                        LEFT JOIN visitor visitor2 on visitor2.id = family_visit.visitor2_id
                        LEFT JOIN income on income.id = family_income.income_id
                    WHERE family_visit.visit_name LIKE '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, family.id, family_visit.id ORDER BY family.code; ";
                }
            }

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataTable Get_Person_Visit(string visitname, string category, bool showResult)
        {
            //check connection//
            Program.buildConnection();
             query = "";
            MySqlCommand sc = new MySqlCommand();
            sc.CommandTimeout = 1000;
            sc.Parameters.AddWithValue("@visitname", visitname);
            sc.Parameters.AddWithValue("@category", category);
            sc.Parameters.AddWithValue("@result", showResult);
            //        , GROUP_CONCAT(Concat(IFNULL(disease.name, 'المرض')
            //, ' - ', IFNULL(person_disease.disease_Note, 'وصف المرض'))) as 'تفاصيل المرض' 
            //        ,GROUP_CONCAT(Concat(IFNULL(workexp.name, 'العمل')
            //, ' - ', IFNULL(workposition.name, 'صفة الشخص')
            //, ' - ', IFNULL(person_workexp.workexpamount, 'الأجر الشهري')
            //, ' - ', IFNULL(work_type.name, 'نوع العمل')
            //, ' - ', IFNULL(experience.name, 'سنوات الخبرة')
            //, ' - ', IFNULL(workfor.name, 'جهة العمل')
            //, ' - ', IFNULL(person_workexp.workname, 'اسم المحل')
            //, ' - ', IFNULL(workplace.name, 'نوع المحل')
            //, ' - ', IFNULL(person_workexp.expenses_amount_6, 'مصروف الآجار')
            //, ' - ', IFNULL(expensestype_6.name, 'نوع مصروف الآجار')
            //, ' - ', IFNULL(person_workexp.workexpnote, 'الوصف')
            //, ' - ', (case person_workexp.expenses_7 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة أمبير؟' END)
            //, ' - ', IFNULL(person_workexp.expenses_amount_7, 'مصروف الأمبير')
            //, ' - ', IFNULL(person_workexp.expensesAmperNumber_7, 'عدد الأمبيرات')

            //, ' - ', (case person_workexp.expenses_15 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة مولدة؟' END)
            //, ' - ' , IFNULL(person_workexp.expenses_amount_15, 'مصروف مولدة')
            //, ' - ' , IFNULL(expensestype_15.name, 'نوع مصروف المولدة')

            //, ' - ' , (case person_workexp.expenses_16 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة بطارية؟' END) 
            //, ' - ' , IFNULL(person_workexp.expenses_amount_16, 'مصروف مولدة')
            //, ' - ' , IFNULL(expensestype_16.name, 'نوع مصروف المولدة')

            //, ' - ' , (case person_workexp.expenses_17 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة طاقة؟' END) 
            //, ' - ' , IFNULL(person_workexp.expenses_amount_17, 'مصروف مولدة')
            //, ' - ' , IFNULL(expensestype_17.name, 'نوع مصروف المولدة')

            //, ' - ' , (case person_workexp.expenses_23 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة كهرباء؟' END) 
            //, ' - ' , IFNULL(person_workexp.expenses_amount_23, 'مصروف مولدة')
            //, ' - ' , IFNULL(expensestype_23.name, 'نوع مصروف المولدة')
            //) ) as 'تفاصيل العمل'

            //         ,GROUP_CONCAT(Concat(IFNULL(person_mp_aid.mp_fundyear, 'سنة التمويل')
            //, ' - ', IFNULL(aidsource_5_mp.name, 'مصدر مساعدة الآجار')
            //, ' - ', IFNULL(person_mp_aid.aid_amount_5_mp, 'قيمة مساعدة الآجار')
            //, ' - ', IFNULL(aidperiod_5_mp.name, 'مدة مساعدة الآجار')

            //, ' - ', IFNULL(aidsource_17_mp.name, 'مصدر مساعدة ترميم')
            //, ' - ', IFNULL(person_mp_aid.aid_amount_17_mp, 'قيمة مساعدة ترميم')
            //, ' - ', IFNULL(aidperiod_17_mp.name, 'مدة مساعدة ترميم')

            //, ' - ', IFNULL(aidsource_22_mp.name, 'مصدر مساعدة عدة/بضاعة')
            //, ' - ', IFNULL(person_mp_aid.aid_amount_22_mp, 'قيمة مساعدة عدة/بضاعة')
            //, ' - ', IFNULL(aidperiod_22_mp.name, 'مدة مساعدة عدة/بضاعة')

            //, ' - ', IFNULL(person_mp_aid.expenses_amount_12_mp, 'مصروف الأقساط')
            //, ' - ', IFNULL(expensestype_12_mp.name, 'نوع مصروف الأقساط') 
            //)) as 'تفاصيل مشروع صغير' 
            //            ,IFNULL(personstate.name, ' ') as 'حالة الفرد'
            //,IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة'
            //,IFNULL(person_state.personstate_address, ' ') as 'مكان الإقامة'
            //,(case person_state.aidsource_29 WHEN 0 then 'لا' WHEN 29 then 'نعم' ELSE ''  END) as 'هل يوجد مساعدة أولاد؟'
            //,IFNULL(person_state.aid_amount_29, ' ') as 'قيمة مساعدة الأولاد'
            //,IFNULL(aidperiod_29.name, ' ') as 'مدة مساعدة الأولاد'
            //,IFNULL(person_state.aid_note_29, ' ') as 'ملاحظة المساعدة'
            if (category == "N/A")
            {
                query = @"SELECT family.code as 'رمز العائلة'
                        ,GROUP_CONCAT(DISTINCT(partner.name)) as 'الشريك'
                        ,MAX(case WHEN donor.name like 'F2F' THEN(case WHEN family_partner.IsActive = 1 and donor.name like 'F2F' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول  F2F '
                        ,MAX(case WHEN donor.name like 'MPC' THEN (case WHEN family_partner.IsActive = 1 and donor.name like 'MPC' Then 'فعالة' else 'غير فعالة' END) ELSE '' END) as 'الممول MPC '
                        ,family_visit.visit_name as 'الزيارة'
                        ,visitstate.name as 'حالة الزيارة'
                        ,CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي'
                        ,person.id as 'person_id'
                        ,family_visit.id as 'visit_id'
                        ,family.id as 'family_id'
 
    ,(case person_family.isReceiver WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'رب الأسرة'

    ,IFNULL(relation.name,' ') as 'الصفة الأسرية'
    ,IFNULL(person.DOB,' ') as 'المواليد'
    ,IFNULL(sex.name,' ') as 'الجنس'
    ,IFNULL(nationality.name,' ') as 'الجنسية'
    ,IFNULL(person.national_Number,' ') as 'الرقم الوطني'
                  
    , (select maritalstatus.name 
        from person_maritalstatus 
        LEFT JOIN maritalstatus on maritalstatus.id = person_maritalstatus.maritalstatus_id 
        where person_maritalstatus.person_id = person.id 
        and current_state = 1 limit 1) as 'الحالة الاجتماعية'

    , IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END,' ') as 'حالة الفرد'
    , IFNULL(person_state.personstate_year,' ') as 'سنة الحالة'
    , IFNULL(stateaddress.name,' ') as 'مكان الإقامة'
    , (case person_state.aidsource_29 WHEN 0 then 'لا' WHEN 29 then 'نعم' ELSE '' END) as 'هل يقدم مساعدة؟'
    , IFNULL(person_state.aid_amount_29,' ') as 'قيمة المساعدة' 
    , IFNULL(aidperiod_29.name,' ') as 'مدة المساعدة'
    , IFNULL(person_state.aid_note_29, ' ') as 'ملاحظة المساعدة'  
 
    ,(case person_visitdetails.hasdisease WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE ''  END) as 'هل لديه أمراض؟'
    ,disease_details.disease_info AS 'تفاصيل المرض'

    ,(case person_visitdetails.haschronic_medicine WHEN 0 then 'لا' WHEN 9 then 'نعم' ELSE '' END) as 'هل لديه ادوية دورية مزمنة؟'
    ,IFNULL(person_visitdetails.expenses_amount_9,' ') as 'مصروف الأدوية'
    ,IFNULL(expensestype_9.name,' ') as 'نوع مصروف الأدوية'
    ,IFNULL(aidsource_21.name,' ') as 'مصدر مساعدة علب الدواء'
    ,IFNULL(person_visitdetails.aid_amount_21,' ') as 'قيمة مساعدة علب الدواء'
    ,IFNULL(aidperiod_21.name,' ') as 'مدة مساعدة علب الدواء'
    ,(case person_visitdetails.aid_1 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'مساعدة قيمة دواء؟'
    ,IFNULL(aidsource_1.name,' ')as 'مصدر مساعدة الدواء'
    ,IFNULL(person_visitdetails.aid_amount_1,' ') as 'قيمة مساعدة الدواء'
    ,IFNULL(aidperiod_1.name,' ')as 'مدة مساعدة الدواء'
    ,(case person_visitdetails.aid_13 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'مساعدة عمليات جراحية؟'
    ,IFNULL(aidsource_13.name,' ')as 'مصدر مساعدة العمليات'
    ,IFNULL(person_visitdetails.aid_amount_13,' ') as 'قيمة مساعدة العمليات'
    ,IFNULL(aidperiod_13.name,' ') as 'مدة مساعدة العمليات'
    ,IFNULL(person_visitdetails.operation_name_1,' ') as 'ما هي المستلزمات؟'
    ,IFNULL(person_visitdetails.operation_value_1,' ') as 'ما هي قيمة المستلزمات؟'
    ,IFNULL(person_visitdetails.operation_name_2,' ') as 'ما هي العملية'
    ,IFNULL(person_visitdetails.operation_value_2,' ') as 'ما هي قيمة العملية'
    ,IFNULL(person_visitdetails.expenses_amount_5,' ') as 'مصروف الحليب'
    ,IFNULL(expensestype_5.name,' ') as 'نوع مصروف الحليب'
    ,(case person_visitdetails.aid_8 WHEN 0 then 'لا' WHEN 8 then 'نعم' ELSE '' END) as 'مساعدة الحليب؟'
    ,IFNULL(aidsource_8.name,' ') as ' مصدر مساعدة الحليب'
    ,IFNULL(person_visitdetails.aid_amount_8,' ') as 'قيمة مساعدة الحليب'
    ,IFNULL(aidperiod_8.name,' ') as 'مدة مساعدة الحليب'
    ,IFNULL(person_visitdetails.expenses_amount_4,' ') as 'مصروف الحفاضات'
    ,IFNULL(expensestype_4.name,' ') as 'نوع مصروف الحفاضات'
    ,(case person_visitdetails.aid_6 WHEN 0 then 'لا' WHEN 6 then 'نعم' ELSE '' END) as 'مساعدة الحفاضات'
    ,IFNULL(aidsource_6.name,' ') as ' مصدر مساعدة الحفاضات'
    ,IFNULL(person_visitdetails.aid_amount_6,' ') as 'قيمة مساعدة الحفاضات'
    ,IFNULL(aidperiod_6.name,' ') as 'مدة مساعدة الحفاضات'
    ,IFNULL(person_visitdetails.expenses_amount_24,' ') as 'مصروف مقدم الرعاية'
    ,IFNULL(expensestype_24.name,' ') as 'نوع مصروف مقدم الرعاية'
    
    ,(case person_visitdetails.haswork WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل لديه عمل؟'
    ,work_details.work_info AS 'تفاصيل العمل'
    ,(case person_visitdetails.hasmicroproject WHEN 0 then 'لا' WHEN 1 then 'نعم'  ELSE '' END) as 'هل استفاد من مشاريع صغيرة؟'
    ,mp_details.mp_info AS 'تفاصيل المشروع'
    ,(case person_visitdetails.aid_10 WHEN 0 then 'لا' WHEN 10 then 'نعم' ELSE '' END) as 'مساعدة بدل عسكرية؟'
    ,IFNULL(aidsource_10.name,' ')as ' مصدر مساعدة بدل العسكرية'
    ,IFNULL(person_visitdetails.aid_amount_10,' ') as 'قيمة مساعدة بدل العسكرية'
    ,IFNULL(aidperiod_10.name,' ')as 'مدة مساعدة بدل العسكرية'
    ,(case person.isEducated WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل متعلم؟'
    ,IFNULL(education.name,' ') as 'الدراسة1'
    ,IFNULL(person.educationnote,' ')as 'اسم المدرسة1/الجامعة1'
    ,IFNULL(educationtype.name,' ')as 'نوع الدراسة1'
    ,IFNULL(education_id_2.name,' ')as 'الدراسة2'
    ,IFNULL(person.educationnote2,' ')as 'اسم المدرسة2/الجامعة2'
    ,IFNULL(educationtype_id_2.name,' ')as 'نوع الدراسة2'
    ,(case person_visitdetails.isStudent WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'هل طالب؟'
    ,IFNULL(person_visitdetails.expenses_amount_8,' ') as 'مصروف أقساط'
    ,IFNULL(expensestype_8.name,' ')as 'نوع مصروف الأقساط'
    ,IFNULL(person_visitdetails.expenses_amount_2,' ') as 'مصروف مواصلات'
    ,IFNULL(expensestype_2.name,' ')as 'نوع مصروف مواصلات'
    ,IFNULL(aidsource_2.name,' ')as ' مصدر مساعدة الأقساط'
    ,IFNULL(person_visitdetails.aid_amount_2,' ') as 'قيمة مساعدة الأقساط' 
    ,IFNULL(aidperiod_2.name,' ')as 'مدة مساعدة الأقساط'
    ,IFNULL(aidsource_23.name,' ')as ' مصدر مساعدة المواصلات'
    ,IFNULL(person_visitdetails.aid_amount_23,' ') as 'قيمة مساعدة المواصلات'
    ,IFNULL(aidperiod_23.name,' ')as 'مدة مساعدة المواصلات'
    ,person_visitdetails.person_note as 'ملاحظة الفرد'
    ,(case `person_visitdetails`.`needs/1` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'حاجات اجتماعية'
    ,(case `person_visitdetails`.`needs/2` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'دورات تعليمية متخصصة'
    ,person_visitdetails.needs_special_courses as 'ملاحظة الدورات التعليمية'
    ,(case `person_visitdetails`.`needs/3` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'ICDL'
    ,(case `person_visitdetails`.`needs/4` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'English'
    ,(case `person_visitdetails`.`needs/5` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'تدريب مهني'
    ,(case `person_visitdetails`.`needs/6` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'أجهزة دراسية'
    ,(case `person_visitdetails`.`needs/7` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'مكان ملائم للدراسة'
    ,(case `person_visitdetails`.`needs/8` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'دورات لغات'
    ,(case `person_visitdetails`.`needs/9` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'دعم المواهب'
    ,(case `person_visitdetails`.`needs/10` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'دعم نفسي'
    ,(case `person_visitdetails`.`needs/12` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'مساحة للإبداع'
    ,(case `person_visitdetails`.`needs/0` WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'غير ذلك'
    ,person_visitdetails.needs_note as 'ملاحظات غير ذلك'

    from person 
    LEFT JOIN person_family on person_family.person_id = person.id
    LEFT JOIN family on family.id = person_family.family_id  
    LEFT JOIN family_visit on family_visit.family_id = family.id
 LEFT JOIN family_partner on family_partner.family_id = family.id
                          LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id
                          LEFT JOIN partner on partner.id = partner_donor.partner_id
                        LEFT JOIN donor on donor.id = partner_donor.donor_id
    LEFT JOIN visitstate on visitstate.id = family_visit.visitstate_id 
    LEFT JOIN family_visitdetails on family_visitdetails.family_visit_id = family_visit.id
    LEFT JOIN person_visitdetails on (person_visitdetails.person_id = person.id) 
                                 and (person_visitdetails.family_visit_id = family_visit.id)

    LEFT JOIN relation on relation.id= person_family.relation_id
    LEFT JOIN sex on sex.id= person.sex_id
    LEFT JOIN nationality on nationality.id= person.nationality_id

LEFT JOIN (
    SELECT person_disease.person_id,person_disease.visit_id
           ,GROUP_CONCAT( CONCAT(IFNULL(disease.name, 'المرض')
    , ' - ', IFNULL(person_disease.disease_Note, 'وصف المرض')) SEPARATOR ', ') AS disease_info

    FROM person_disease 
    LEFT JOIN disease ON disease.id = person_disease.disease_id

    GROUP BY person_disease.person_id,visit_id
) disease_details ON disease_details.person_id = person.id and disease_details.visit_id = family_visit.id

LEFT JOIN (
    SELECT person_id  , visit_id
          ,GROUP_CONCAT( Concat(IFNULL(workexp.name,'العمل')
    , ' - ' , IFNULL(workposition.name, 'صفة الشخص')
    , ' - ' , IFNULL(workexp_new.workexpamount, 'الأجر الشهري')
    , ' - ' , IFNULL(work_type.name, 'نوع العمل')
    , ' - ' , IFNULL(experience.name, 'سنوات الخبرة')
    , ' - ' , IFNULL(workfor.name, 'جهة العمل')
    , ' - ' , IFNULL(workexp_new.workname, 'اسم المحل')
    , ' - ' , IFNULL(workplace.name, 'نوع المحل')
    , ' - ' , IFNULL(workexp_new.expenses_amount_6, 'مصروف الآجار')
    , ' - ' , IFNULL(expensestype_6.name, 'نوع مصروف الآجار') 
    , ' - ' , IFNULL(workexp_new.workexpnote, 'الوصف')
    , ' - ' , (case workexp_new.expenses_7 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة أمبير؟' END) 
    , ' - ' , IFNULL(workexp_new.expenses_amount_7, 'مصروف الأمبير')
    , ' - ' , IFNULL(workexp_new.expensesAmperNumber_7, 'عدد الأمبيرات')
 
    , ' - ' , (case workexp_new.expenses_15 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة مولدة؟' END) 
    , ' - ' , IFNULL(workexp_new.expenses_amount_15, 'مصروف مولدة')
    , ' - ' , IFNULL(expensestype_15.name, 'نوع مصروف المولدة')

    , ' - ' , (case workexp_new.expenses_16 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة بطارية؟' END) 
    , ' - ' , IFNULL(workexp_new.expenses_amount_16, 'مصروف مولدة')
    , ' - ' , IFNULL(expensestype_16.name, 'نوع مصروف المولدة')

    , ' - ' , (case workexp_new.expenses_17 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة طاقة؟' END) 
    , ' - ' , IFNULL(workexp_new.expenses_amount_17, 'مصروف مولدة')
    , ' - ' , IFNULL(expensestype_17.name, 'نوع مصروف المولدة')

    , ' - ' , (case workexp_new.expenses_23 WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE 'طريقة الإنارة كهرباء؟' END) 
    , ' - ' , IFNULL(workexp_new.expenses_amount_23, 'مصروف مولدة')
    , ' - ' , IFNULL(expensestype_23.name, 'نوع مصروف المولدة')

    ) ) as work_info

    FROM person_workexp workexp_new
    LEFT JOIN workexp on workexp.id = workexp_new.workexp_id
    LEFT JOIN workposition on workposition.id = workexp_new.workposition_id
    LEFT JOIN work_type on work_type.id = workexp_new.worktype_id
    LEFT JOIN experience on experience.id = workexp_new.experience_id
    LEFT JOIN workfor on  workfor.id = workexp_new.workfor_id
    LEFT JOIN workplace on workplace.id = workexp_new.workplace_id 
    LEFT JOIN expensestype expensestype_6 on expensestype_6.id = workexp_new.expensestype_6
    LEFT JOIN expensestype expensestype_15 on expensestype_15.id = workexp_new.expensestype_15
    LEFT JOIN expensestype expensestype_16 on expensestype_16.id = workexp_new.expensestype_16
    LEFT JOIN expensestype expensestype_17 on expensestype_17.id = workexp_new.expensestype_17
    LEFT JOIN expensestype expensestype_23 on expensestype_23.id = workexp_new.expensestype_23    

    GROUP BY person_id,visit_id
) AS work_details ON work_details.person_id = person.id and work_details.visit_id = family_visit.id


LEFT JOIN (
    SELECT person_id, visit_id
            ,GROUP_CONCAT(Concat(IFNULL(mp_aid.mp_fundyear, 'سنة التمويل')
    , ' - ', IFNULL(aidsource_5_mp.name, 'مصدر مساعدة الآجار')
    , ' - ', IFNULL(mp_aid.aid_amount_5_mp, 'قيمة مساعدة الآجار')
    , ' - ', IFNULL(aidperiod_5_mp.name, 'مدة مساعدة الآجار')

    , ' - ', IFNULL(aidsource_17_mp.name, 'مصدر مساعدة ترميم')
    , ' - ', IFNULL(mp_aid.aid_amount_17_mp, 'قيمة مساعدة ترميم')
    , ' - ', IFNULL(aidperiod_17_mp.name, 'مدة مساعدة ترميم')

    , ' - ', IFNULL(aidsource_22_mp.name, 'مصدر مساعدة عدة/بضاعة')
    , ' - ', IFNULL(mp_aid.aid_amount_22_mp, 'قيمة مساعدة عدة/بضاعة')
    , ' - ', IFNULL(aidperiod_22_mp.name, 'مدة مساعدة عدة/بضاعة')

    , ' - ', IFNULL(mp_aid.expenses_amount_12_mp, 'مصروف الأقساط')
    , ' - ', IFNULL(expensestype_12_mp.name, 'نوع مصروف الأقساط')

    )) as mp_info
    FROM person_mp_aid mp_aid 
    LEFT JOIN aidsource aidsource_5_mp on aidsource_5_mp.id = mp_aid.aidsource_5_mp
    LEFT JOIN aidperiod aidperiod_5_mp on aidperiod_5_mp.id = mp_aid.aidperiod_5_mp
    LEFT JOIN aidsource aidsource_17_mp on aidsource_17_mp.id = mp_aid.aidsource_17_mp
    LEFT JOIN aidperiod aidperiod_17_mp on aidperiod_17_mp.id = mp_aid.aidperiod_17_mp
    LEFT JOIN aidsource aidsource_22_mp on aidsource_22_mp.id = mp_aid.aidsource_22_mp
    LEFT JOIN aidperiod aidperiod_22_mp on aidperiod_22_mp.id = mp_aid.aidperiod_22_mp
    LEFT JOIN expensestype expensestype_12_mp on expensestype_12_mp.id = mp_aid.expensestype_12_mp

    GROUP BY person_id ,visit_id
) AS mp_details ON mp_details.person_id = person.id and mp_details.visit_id = family_visit.id
  
    LEFT JOIN person_state on (person_state.person_id = person.id) and (person_state.family_id = family.id)
    LEFT JOIN personstate on personstate.id= person_state.personstate_id
    LEFT JOIN aidperiod aidperiod_29 on aidperiod_29.id= person_state.aidperiod_29

    LEFT JOIN expensestype expensestype_9 on expensestype_9.id = person_visitdetails.expensestype_9
    LEFT JOIN aidsource aidsource_21 on aidsource_21.id= person_visitdetails.aidsource_21
    LEFT JOIN aidperiod aidperiod_21 on aidperiod_21.id= person_visitdetails.aidperiod_21
    LEFT JOIN aidsource aidsource_1 on aidsource_1.id= person_visitdetails.aidsource_1
    LEFT JOIN aidperiod aidperiod_1 on aidperiod_1.id= person_visitdetails.aidperiod_1
    LEFT JOIN aidsource aidsource_13 on aidsource_13.id= person_visitdetails.aidsource_13
    LEFT JOIN aidperiod aidperiod_13 on aidperiod_13.id= person_visitdetails.aidperiod_13
    LEFT JOIN expensestype expensestype_5 on expensestype_5.id = person_visitdetails.expensestype_5
    LEFT JOIN aidsource aidsource_8 on aidsource_8.id= person_visitdetails.aidsource_8
    LEFT JOIN aidperiod aidperiod_8 on aidperiod_8.id= person_visitdetails.aidperiod_8
    LEFT JOIN expensestype expensestype_4 on expensestype_4.id = person_visitdetails.expensestype_4
    LEFT JOIN aidsource aidsource_6 on aidsource_6.id= person_visitdetails.aidsource_6
    LEFT JOIN aidperiod aidperiod_6 on aidperiod_6.id= person_visitdetails.aidperiod_6
    LEFT JOIN expensestype expensestype_24 on expensestype_24.id = person_visitdetails.expensestype_24
    LEFT JOIN aidsource aidsource_10 on aidsource_10.id= person_visitdetails.aidsource_10
    LEFT JOIN aidperiod aidperiod_10 on aidperiod_10.id= person_visitdetails.aidperiod_10
    LEFT JOIN aidsource aidsource_2 on aidsource_2.id= person_visitdetails.aidsource_2
    LEFT JOIN aidperiod aidperiod_2 on aidperiod_2.id= person_visitdetails.aidperiod_2
    LEFT JOIN aidsource aidsource_23 on aidsource_23.id= person_visitdetails.aidsource_23
    LEFT JOIN aidperiod aidperiod_23 on aidperiod_23.id= person_visitdetails.aidperiod_23

    LEFT JOIN education on education.id = person.education_id
    LEFT JOIN educationtype on educationtype.id = person.educationtype_id
    LEFT JOIN education education_id_2 on education_id_2.id = person.education_id_2
    LEFT JOIN educationtype educationtype_id_2 on educationtype_id_2.id = person.educationtype_id_2
    LEFT JOIN expensestype expensestype_8 on expensestype_8.id = person_visitdetails.expensestype_8
    LEFT JOIN expensestype expensestype_2 on expensestype_2.id = person_visitdetails.expensestype_2
    LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id
    where person_state.current_state = '1'
    and   family_visit.visit_name like @visitname

    Group by person_family.id
    order by family.code;";
            }
            else if(category == "المرض")
            {
                if (!showResult)
                {
                    query = @"SELECT 
    family.code as 'رمز العائلة',
    GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
    MAX(CASE 
        WHEN donor.name = 'F2F' THEN
            CASE 
                WHEN family_partner.IsActive = 1 THEN 'فعالة'
                ELSE 'غير فعالة'
            END
        ELSE '' END) as 'الممول F2F',
    MAX(CASE 
        WHEN donor.name = 'MPC' THEN
            CASE 
                WHEN family_partner.IsActive = 1 THEN 'فعالة'
                ELSE 'غير فعالة'
            END
        ELSE '' END) as 'الممول MPC',
    family_visit.visit_name as 'الزيارة',
    visitstate.name as 'حالة الزيارة',
    CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
    person.id as 'person_id',
    family_visit.id as 'visit_id',
    family.id as 'family_id',
    disease.name as 'المرض',
    diseasecategory.name as 'صنف المرض',
    CASE 
        WHEN disease.isfatal = 0 THEN 'لا'
        WHEN disease.isfatal = 1 THEN 'نعم'
        ELSE '' END as 'Is fatal',
    CASE 
        WHEN disease.isdisability = 0 THEN 'لا'
        WHEN disease.isdisability = 1 THEN 'نعم'
        ELSE '' END as 'Is Disability',
    person_disease.disease_Note as 'ملاحظة عن المرض',
    CASE 
        WHEN person_family.isReceiver = 0 THEN 'لا'
        WHEN person_family.isReceiver = 1 THEN 'نعم'
        ELSE '' END as 'رب الأسرة',
    IFNULL(relation.name, ' ') as 'الصفة الأسرية',
    IFNULL(person.DOB, ' ') as 'المواليد',
    IFNULL(sex.name, ' ') as 'الجنس',
    IFNULL(person.national_Number, ' ') as 'الرقم الوطني',
    IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد',
    IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة',
    IFNULL(stateaddress.name, ' ') as 'مكان الإقامة'
FROM 
    person_disease
    LEFT JOIN person ON person.id = person_disease.person_id
    LEFT JOIN disease ON disease.id = person_disease.disease_id
    LEFT JOIN diseasecategory ON disease.diseasecategory_id = diseasecategory.id
    LEFT JOIN person_family ON person.id = person_family.person_id
    LEFT JOIN family ON person_family.family_id = family.id
    LEFT JOIN family_visit ON person_disease.visit_id = family_visit.id
    LEFT JOIN family_partner ON family_partner.family_id = family.id
    LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
    LEFT JOIN partner ON partner.id = partner_donor.partner_id
    LEFT JOIN donor ON donor.id = partner_donor.donor_id
    LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id 
    LEFT JOIN person_state ON person_state.person_id = person.id AND person_state.family_id = family.id
    LEFT JOIN personstate ON personstate.id = person_state.personstate_id
    LEFT JOIN relation ON relation.id = person_family.relation_id
    LEFT JOIN sex ON sex.id = person.sex_id
    LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id
WHERE 
    person_state.current_state = 1
    AND family_visit.visit_name LIKE '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, person.id, family_visit.id, family.id, disease.name, diseasecategory.name, person_disease.disease_Note, person_family.isReceiver, relation.name, person.DOB, sex.name, person.national_Number, personstate.name, person_state.personstate_year, person_state.stateaddress_id ORDER BY family.code, disease.name; ";
                }
                else
                {
                    query = @"SELECT 
    family.code as 'رمز العائلة',
    GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
    MAX(CASE 
        WHEN donor.name = 'F2F' THEN
            CASE 
                WHEN family_partner.IsActive = 1 THEN 'فعالة'
                ELSE 'غير فعالة'
            END
        ELSE '' END) as 'الممول F2F',
    MAX(CASE 
        WHEN donor.name = 'MPC' THEN
            CASE 
                WHEN family_partner.IsActive = 1 THEN 'فعالة'
                ELSE 'غير فعالة'
            END
        ELSE '' END) as 'الممول MPC',
    family_visit.visit_name as 'الزيارة',
    visitstate.name as 'حالة الزيارة',
    CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
    person.id as 'person_id',
    family_visit.id as 'visit_id',
    family.id as 'family_id',
    COUNT(DISTINCT disease.id) as 'عدد الأمراض',
    GROUP_CONCAT(DISTINCT disease.name SEPARATOR ', ') as 'الأمراض',
    GROUP_CONCAT(DISTINCT diseasecategory.name SEPARATOR ', ') as 'أصناف الأمراض',
    COUNT(DISTINCT CASE WHEN disease.isfatal = 1 THEN disease.id END) as 'عدد is Fatal',
    COUNT(DISTINCT CASE WHEN disease.isdisability = 1 THEN disease.id END) as 'عدد is Disability',
    GROUP_CONCAT(DISTINCT person_disease.disease_Note SEPARATOR ', ') as 'ملاحظات عن الأمراض',
    CASE 
        WHEN person_family.isReceiver = 0 THEN 'لا'
        WHEN person_family.isReceiver = 1 THEN 'نعم'
        ELSE '' END as 'رب الأسرة',
    IFNULL(relation.name, ' ') as 'الصفة الأسرية',
    IFNULL(person.DOB, ' ') as 'المواليد',
    IFNULL(sex.name, ' ') as 'الجنس',
    IFNULL(person.national_Number, ' ') as 'الرقم الوطني',
    IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد',
    IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة',
    IFNULL(stateaddress.name, ' ') as 'مكان الإقامة' 
FROM 
    person_disease
    LEFT JOIN person ON person.id = person_disease.person_id
    LEFT JOIN disease ON disease.id = person_disease.disease_id
    LEFT JOIN diseasecategory ON disease.diseasecategory_id = diseasecategory.id
    LEFT JOIN person_family ON person.id = person_family.person_id
    LEFT JOIN family ON person_family.family_id = family.id
    LEFT JOIN family_visit ON person_disease.visit_id = family_visit.id
    LEFT JOIN family_partner ON family_partner.family_id = family.id
    LEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id
    LEFT JOIN partner ON partner.id = partner_donor.partner_id
    LEFT JOIN donor ON donor.id = partner_donor.donor_id
    LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id 
    LEFT JOIN person_state ON person_state.person_id = person.id AND person_state.family_id = family.id
    LEFT JOIN personstate ON personstate.id = person_state.personstate_id
    LEFT JOIN relation ON relation.id = person_family.relation_id
    LEFT JOIN sex ON sex.id = person.sex_id
    LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id
WHERE 
    person_state.current_state = 1
    AND family_visit.visit_name LIKE '" + visitname + "'GROUP BY family.code, family_visit.visit_name, visitstate.name, person.id, family_visit.id, family.id, person_family.id, person.first_name, person.father_name, person.last_name, relation.name, person.DOB, sex.name, person.national_Number, personstate.name, person_state.personstate_year, person_state.stateaddress_id ORDER BY family.code, disease.name, diseasecategory.name; ";
                }
            }
            else if (category == "العمل")
            {
                if (!showResult)
                {
                    query = @"SELECT 
                        family.code as 'رمز العائلة',
                        GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                        MAX(CASE 
                            WHEN donor.name = 'F2F' THEN
                                CASE 
                                    WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                    ELSE 'غير فعالة'
                                END
                            ELSE '' END) as 'الممول F2F',
                        MAX(CASE 
                            WHEN donor.name = 'MPC' THEN
                                CASE 
                                    WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                    ELSE 'غير فعالة'
                                END
                            ELSE '' END) as 'الممول MPC',
                        family_visit.visit_name as 'الزيارة',
                        visitstate.name as 'حالة الزيارة',
                        CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
                        person.id as 'person_id',
                        family_visit.id as 'visit_id',
                        family.id as 'family_id'
                        ,workexp.name as 'العمل'
                        ,workposition.name as  'صفة الشخص'
                        ,person_workexp.workexpamount as  'الأجر الشهري'
                        ,work_type.name as  'نوع العمل'
                        ,experience.name as 'سنوات الخبرة'
                        ,workfor.name as 'جهة العمل'
                        ,person_workexp.workname as 'اسم المحل'
                        ,workplace.name as 'نوع المحل'
                        ,person_workexp.expenses_amount_6 as 'مصروف الآجار'
                        ,expensestype_6.name as 'نوع مصروف الآجار'
                        ,person_workexp.workexpnote as 'الوصف'
                        ,(case person_workexp.expenses_7 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة أمبير؟'
                        ,person_workexp.expenses_amount_7 as 'مصروف الأمبير'
                        ,person_workexp.expensesAmperNumber_7 as 'عدد الأمبيرات'
                        ,(case person_workexp.expenses_15 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة مولدة؟'
                        ,person_workexp.expenses_amount_15 as 'مصروف مولدة'
                        ,expensestype_15.name as 'نوع مصروف المولدة'
                        ,(case person_workexp.expenses_16 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة بطارية؟'
                        ,person_workexp.expenses_amount_16 as 'مصروف مولدة'
                        ,expensestype_16.name as 'نوع مصروف المولدة'
                        ,(case person_workexp.expenses_17 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة طاقة؟'
                        ,person_workexp.expenses_amount_17 as 'مصروف مولدة'
                        ,expensestype_17.name as 'نوع مصروف المولدة'
                        ,(case person_workexp.expenses_23 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة كهرباء؟' 
                        ,person_workexp.expenses_amount_23 as 'مصروف مولدة'
                        ,expensestype_23.name as 'نوع مصروف المولدة'
                         ,(case person_family.isReceiver WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'رب الأسرة'
                        ,IFNULL(relation.name, ' ') as 'الصفة الأسرية'
                        ,IFNULL(person.DOB, ' ') as 'المواليد'
                        ,IFNULL(sex.name, ' ') as 'الجنس'
                        ,IFNULL(person.national_Number, ' ') as 'الرقم الوطني'

                        , IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد'
                        , IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة'
                        , IFNULL(stateaddress.name, ' ') as 'مكان الإقامة'


                        FROM `person_workexp`
	                    LEFT JOIN person on person.id = person_workexp.person_id
	                    LEFT JOIN workexp on workexp.id = person_workexp.workexp_id
                        LEFT JOIN workposition on workposition.id = person_workexp.workposition_id
                        LEFT JOIN work_type on work_type.id = person_workexp.worktype_id
                        LEFT JOIN experience on experience.id = person_workexp.experience_id
                        LEFT JOIN workfor on  workfor.id = person_workexp.workfor_id
                        LEFT JOIN workplace on workplace.id = person_workexp.workplace_id 
                        LEFT JOIN expensestype expensestype_6 on expensestype_6.id = person_workexp.expensestype_6
                        LEFT JOIN expensestype expensestype_15 on expensestype_15.id = person_workexp.expensestype_15
                        LEFT JOIN expensestype expensestype_16 on expensestype_16.id = person_workexp.expensestype_16
                        LEFT JOIN expensestype expensestype_17 on expensestype_17.id = person_workexp.expensestype_17
                        LEFT JOIN expensestype expensestype_23 on expensestype_23.id = person_workexp.expensestype_23
	                    LEFT JOIN person_family on person.id = person_family.person_id
	                    LEFT JOIN family on person_family.family_id = family.id
	                    LEFT JOIN family_visit on person_workexp.visit_id = family_visit.id
                       
                        LEFT JOIN family_partner on family_partner.family_id = family.id
                        LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner on partner.id = partner_donor.partner_id
                        LEFT JOIN donor on donor.id = partner_donor.donor_id
	                    LEFT JOIN visitstate on visitstate.id = family_visit.visitstate_id 
	                    LEFT JOIN person_state on (person_state.person_id = person.id) and (person_state.family_id = family.id)
	                    LEFT JOIN personstate on personstate.id= person_state.personstate_id
	                    LEFT JOIN relation on relation.id= person_family.relation_id
	                    LEFT JOIN sex on sex.id= person.sex_id
                        LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id
                         where person_state.current_state = 1


                         and family_visit.visit_name like '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, person.id, family_visit.id, family.id, workexp.name, workposition.name,work_type.name,experience.name,workfor.name ,workplace.name,person_workexp.workname,person_workexp.workexpamount, person_family.isReceiver, relation.name, person.DOB, sex.name, person.national_Number, personstate.name, person_state.personstate_year, person_state.stateaddress_id ORDER BY family.code, workexp.name;";
                }
                else
                {
                    query = @"SELECT 
    family.code as 'رمز العائلة',
    GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
    MAX(CASE 
        WHEN donor.name = 'F2F' THEN
            CASE 
                WHEN family_partner.IsActive = 1 THEN 'فعالة'
                ELSE 'غير فعالة'
            END
        ELSE ''
    END) as 'الممول F2F',
    MAX(CASE 
        WHEN donor.name = 'MPC' THEN
            CASE 
                WHEN family_partner.IsActive = 1 THEN 'فعالة'
                ELSE 'غير فعالة'
            END
        ELSE ''
    END) as 'الممول MPC',
    family_visit.visit_name as 'الزيارة',
    visitstate.name as 'حالة الزيارة',
    CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
    person.id as 'person_id',
    family_visit.id as 'visit_id',
    family.id as 'family_id',
    COUNT(DISTINCT workexp.name) as 'عدد الأعمال',
    GROUP_CONCAT(DISTINCT workexp.name SEPARATOR ', ') as 'العمل',
    GROUP_CONCAT(DISTINCT workposition.name SEPARATOR ', ') as 'صفة الشخص',
    GROUP_CONCAT(DISTINCT person_workexp.workexpamount SEPARATOR ', ') as 'الأجر الشهري',
    GROUP_CONCAT(DISTINCT work_type.name SEPARATOR ', ') as 'نوع العمل',
    GROUP_CONCAT(DISTINCT experience.name SEPARATOR ', ') as 'سنوات الخبرة',
    GROUP_CONCAT(DISTINCT workfor.name SEPARATOR ', ') as 'جهة العمل',
    GROUP_CONCAT(DISTINCT person_workexp.workname SEPARATOR ', ') as 'اسم المحل',
    GROUP_CONCAT(DISTINCT workplace.name SEPARATOR ', ')as 'نوع المحل',
    -- COUNT(DISTINCT CASE WHEN work_type.id = 2 THEN work_type.id ELSE NULL END) as 'عدد صاحب عمل/حر',
    -- COUNT(DISTINCT CASE WHEN work_type.id = 1 THEN work_type.id ELSE NULL END) as 'عدد عامل',
    GROUP_CONCAT(DISTINCT person_workexp.expenses_amount_6 SEPARATOR ', ') as 'مصروف الآجار',
    GROUP_CONCAT(DISTINCT expensestype_6.name SEPARATOR ', ') as 'نوع مصروف الآجار',
    GROUP_CONCAT(DISTINCT person_workexp.workexpnote SEPARATOR ', ') as 'الوصف',
    GROUP_CONCAT(case person_workexp.expenses_7 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة أمبير؟',
    GROUP_CONCAT(DISTINCT person_workexp.expenses_amount_7 SEPARATOR ', ') as 'مصروف الأمبير',
    GROUP_CONCAT(DISTINCT person_workexp.expensesAmperNumber_7 SEPARATOR ', ') as 'عدد الأمبيرات',
 
    GROUP_CONCAT(case person_workexp.expenses_15 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة مولدة؟',
    GROUP_CONCAT(DISTINCT person_workexp.expenses_amount_15 SEPARATOR ', ')as 'مصروف مولدة',
    GROUP_CONCAT(DISTINCT expensestype_15.name SEPARATOR ', ') as 'نوع مصروف المولدة',

    GROUP_CONCAT(case person_workexp.expenses_16 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة بطارية؟' ,
    GROUP_CONCAT(DISTINCT person_workexp.expenses_amount_16 SEPARATOR ', ') as 'مصروف مولدة',
    GROUP_CONCAT(DISTINCT expensestype_16.name SEPARATOR ', ') as 'نوع مصروف المولدة',

    GROUP_CONCAT(case person_workexp.expenses_17 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة طاقة؟',
    GROUP_CONCAT(DISTINCT person_workexp.expenses_amount_17 SEPARATOR ', ') as 'مصروف مولدة',
    GROUP_CONCAT(DISTINCT expensestype_17.name SEPARATOR ', ') as 'نوع مصروف المولدة',

    GROUP_CONCAT(case person_workexp.expenses_23 WHEN 0 then 'لا' WHEN 1 then 'نعم' END) as 'طريقة الإنارة كهرباء؟',
    GROUP_CONCAT(DISTINCT person_workexp.expenses_amount_23 SEPARATOR ', ') as 'مصروف مولدة',
    GROUP_CONCAT(DISTINCT expensestype_23.name SEPARATOR ', ') as 'نوع مصروف المولدة',
    CASE 
        WHEN person_family.isReceiver = 0 THEN 'لا'
        WHEN person_family.isReceiver = 1 THEN 'نعم'
        ELSE ''
    END as 'رب الأسرة',
    IFNULL(relation.name, ' ') as 'الصفة الأسرية',
    IFNULL(person.DOB, ' ') as 'المواليد',
    IFNULL(sex.name, ' ') as 'الجنس',
    IFNULL(person.national_Number, ' ') as 'الرقم الوطني',
    IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد',
    IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة',
    IFNULL(stateaddress.name, ' ') as 'مكان الإقامة' 
    FROM `person_workexp`
	                    LEFT JOIN person on person.id = person_workexp.person_id
	                    LEFT JOIN workexp on workexp.id = person_workexp.workexp_id
                        LEFT JOIN workposition on workposition.id = person_workexp.workposition_id
                        LEFT JOIN work_type on work_type.id = person_workexp.worktype_id
                        LEFT JOIN experience on experience.id = person_workexp.experience_id
                        LEFT JOIN workfor on  workfor.id = person_workexp.workfor_id
                        LEFT JOIN workplace on workplace.id = person_workexp.workplace_id 
                        LEFT JOIN expensestype expensestype_6 on expensestype_6.id = person_workexp.expensestype_6
                        LEFT JOIN expensestype expensestype_15 on expensestype_15.id = person_workexp.expensestype_15
                        LEFT JOIN expensestype expensestype_16 on expensestype_16.id = person_workexp.expensestype_16
                        LEFT JOIN expensestype expensestype_17 on expensestype_17.id = person_workexp.expensestype_17
                        LEFT JOIN expensestype expensestype_23 on expensestype_23.id = person_workexp.expensestype_23
	                    LEFT JOIN person_family on person.id = person_family.person_id
	                    LEFT JOIN family on person_family.family_id = family.id
	                    LEFT JOIN family_visit on person_workexp.visit_id = family_visit.id
                        LEFT JOIN family_partner on family_partner.family_id = family.id
                        LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner on partner.id = partner_donor.partner_id
                        LEFT JOIN donor on donor.id = partner_donor.donor_id
	                    LEFT JOIN visitstate on visitstate.id = family_visit.visitstate_id 
	                    LEFT JOIN person_state on (person_state.person_id = person.id) and (person_state.family_id = family.id)
	                    LEFT JOIN personstate on personstate.id= person_state.personstate_id
	                    LEFT JOIN relation on relation.id= person_family.relation_id
	                    LEFT JOIN sex on sex.id= person.sex_id
                        LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id
                         where person_state.current_state = 1


                         and family_visit.visit_name like '" + visitname + "'group by person_family.id order by family.code, workexp.name; ";
                }
            }
            else if (category == "مشاريع صغيرة")
            {
                if (!showResult)
                {
                    query = @"SELECT 
                        family.code as 'رمز العائلة',
                        GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                        MAX(CASE 
                            WHEN donor.name = 'F2F' THEN
                                CASE 
                                    WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                    ELSE 'غير فعالة'
                                END
                            ELSE '' END) as 'الممول F2F',
                        MAX(CASE 
                            WHEN donor.name = 'MPC' THEN
                                CASE 
                                    WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                    ELSE 'غير فعالة'
                                END
                            ELSE '' END) as 'الممول MPC',
                        family_visit.visit_name as 'الزيارة',
                        visitstate.name as 'حالة الزيارة',
                        CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
                        person.id as 'person_id',
                        family_visit.id as 'visit_id',
                        family.id as 'family_id',
                        mp_aid.mp_fundyear as 'سنة التمويل',
                        aidsource_5_mp.name as 'مصدر مساعدة الآجار',
                        mp_aid.aid_amount_5_mp as 'قيمة مساعدة الآجار',
                        aidperiod_5_mp.name as 'مدة مساعدة الآجار',
                        aidsource_17_mp.name as 'مصدر مساعدة ترميم',
                        mp_aid.aid_amount_17_mp as 'قيمة مساعدة ترميم',
                        aidperiod_17_mp.name as 'مدة مساعدة ترميم',
                        aidsource_22_mp.name as 'مصدر مساعدة عدة/بضاعة',
                        mp_aid.aid_amount_22_mp as 'قيمة مساعدة عدة/بضاعة',
                        aidperiod_22_mp.name as 'مدة مساعدة عدة/بضاعة',
                        mp_aid.expenses_amount_12_mp as 'مصروف الأقساط',
                        expensestype_12_mp.name as'نوع مصروف الأقساط',
                        (case person_family.isReceiver WHEN 0 then 'لا' WHEN 1 then 'نعم' ELSE '' END) as 'رب الأسرة',
                        IFNULL(relation.name, ' ') as 'الصفة الأسرية',
                        IFNULL(person.DOB, ' ') as 'المواليد',
                        IFNULL(sex.name, ' ') as 'الجنس',
                        IFNULL(person.national_Number, ' ') as 'الرقم الوطني',
                        IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد',
                        IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة',
                        IFNULL(stateaddress.name, ' ') as 'مكان الإقامة'


                        FROM person_mp_aid mp_aid 
                        LEFT JOIN person on person.id = mp_aid.person_id
                        LEFT JOIN aidsource aidsource_5_mp on aidsource_5_mp.id = mp_aid.aidsource_5_mp
                        LEFT JOIN aidperiod aidperiod_5_mp on aidperiod_5_mp.id = mp_aid.aidperiod_5_mp
                        LEFT JOIN aidsource aidsource_17_mp on aidsource_17_mp.id = mp_aid.aidsource_17_mp
                        LEFT JOIN aidperiod aidperiod_17_mp on aidperiod_17_mp.id = mp_aid.aidperiod_17_mp
                        LEFT JOIN aidsource aidsource_22_mp on aidsource_22_mp.id = mp_aid.aidsource_22_mp
                        LEFT JOIN aidperiod aidperiod_22_mp on aidperiod_22_mp.id = mp_aid.aidperiod_22_mp
                        LEFT JOIN expensestype expensestype_12_mp on expensestype_12_mp.id = mp_aid.expensestype_12_mp
	                    LEFT JOIN person_family on person.id = person_family.person_id
	                    LEFT JOIN family on person_family.family_id = family.id
	                    LEFT JOIN family_visit on mp_aid.visit_id = family_visit.id
                       
                        LEFT JOIN family_partner on family_partner.family_id = family.id
                        LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner on partner.id = partner_donor.partner_id
                        LEFT JOIN donor on donor.id = partner_donor.donor_id
	                    LEFT JOIN visitstate on visitstate.id = family_visit.visitstate_id 
	                    LEFT JOIN person_state on (person_state.person_id = person.id) and (person_state.family_id = family.id)
	                    LEFT JOIN personstate on personstate.id= person_state.personstate_id
	                    LEFT JOIN relation on relation.id= person_family.relation_id
	                    LEFT JOIN sex on sex.id= person.sex_id
                        LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id
                         where person_state.current_state = 1


                         and family_visit.visit_name like '" + visitname + "' GROUP BY family.code, family_visit.visit_name, visitstate.name, person.id, family_visit.id, family.id, mp_aid.mp_fundyear, aidsource_5_mp.name,mp_aid.aid_amount_5_mp,mp_aid.aidperiod_5_mp,aidsource_17_mp.name,mp_aid.aid_amount_17_mp,mp_aid.aidperiod_17_mp,aidsource_22_mp.name,mp_aid.aid_amount_22_mp,mp_aid.aidperiod_22_mp,expensestype_12_mp.name,mp_aid.expenses_amount_12_mp, person_family.isReceiver, relation.name, person.DOB, sex.name, person.national_Number, personstate.name, person_state.personstate_year, person_state.stateaddress_id ORDER BY family.code, mp_aid.id;";
                }
                else
                {
                    query = @"SELECT 
                        family.code as 'رمز العائلة',
                        GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                        MAX(CASE 
                            WHEN donor.name = 'F2F' THEN
                                CASE 
                                    WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                    ELSE 'غير فعالة'
                                END
                            ELSE ''
                        END) as 'الممول F2F',
                        MAX(CASE 
                            WHEN donor.name = 'MPC' THEN
                                CASE 
                                    WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                    ELSE 'غير فعالة'
                                END
                            ELSE ''
                        END) as 'الممول MPC',
                        family_visit.visit_name as 'الزيارة',
                        visitstate.name as 'حالة الزيارة',
                        CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
                        person.id as 'person_id',
                        family_visit.id as 'visit_id',
                        family.id as 'family_id',
                        COUNT(DISTINCT mp_aid.id) as 'عدد المشاريع',
                        GROUP_CONCAT(DISTINCT mp_aid.mp_fundyear SEPARATOR ', ') as 'سنة التمويل',
                        GROUP_CONCAT(DISTINCT aidsource_5_mp.name SEPARATOR ', ') as 'مصدر مساعدة الآجار',
                        GROUP_CONCAT(DISTINCT mp_aid.aid_amount_5_mp SEPARATOR ', ') as 'قيمة مساعدة الآجار',
                        GROUP_CONCAT(DISTINCT aidperiod_5_mp.name SEPARATOR ', ') as 'مدة مساعدة الآجار',
                        GROUP_CONCAT(DISTINCT aidsource_17_mp.name SEPARATOR ', ') as 'مصدر مساعدة الترميم',
                        GROUP_CONCAT(DISTINCT mp_aid.aid_amount_17_mp SEPARATOR ', ') as 'قيمة مساعدة الترميم',
                        GROUP_CONCAT(DISTINCT aidperiod_17_mp.name SEPARATOR ', ') as 'مدة مساعدة الترميم',
                        GROUP_CONCAT(DISTINCT aidsource_22_mp.name SEPARATOR ', ') as 'مصدر مساعدة عدة/بضاعة',
                        GROUP_CONCAT(DISTINCT mp_aid.aid_amount_22_mp SEPARATOR ', ') as 'قيمة مساعدة عدة/بضاعة',
                        GROUP_CONCAT(DISTINCT aidperiod_22_mp.name SEPARATOR ', ') as 'مدة مساعدة عدة/بضاعة',
                        GROUP_CONCAT(DISTINCT mp_aid.expenses_amount_12_mp SEPARATOR ', ') as 'مصروف الأقساط',
                        GROUP_CONCAT(DISTINCT expensestype_12_mp.name SEPARATOR ', ') as 'نوع مصروف الأقساط',
                        CASE 
                            WHEN person_family.isReceiver = 0 THEN 'لا'
                            WHEN person_family.isReceiver = 1 THEN 'نعم'
                            ELSE ''
                        END as 'رب الأسرة',
                        IFNULL(relation.name, ' ') as 'الصفة الأسرية',
                        IFNULL(person.DOB, ' ') as 'المواليد',
                        IFNULL(sex.name, ' ') as 'الجنس',
                        IFNULL(person.national_Number, ' ') as 'الرقم الوطني',
                        IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد',
                        IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة',
                        IFNULL(stateaddress.name, ' ') as 'مكان الإقامة' 
                        FROM person_mp_aid mp_aid 
                        LEFT JOIN person on person.id = mp_aid.person_id
                        LEFT JOIN aidsource aidsource_5_mp on aidsource_5_mp.id = mp_aid.aidsource_5_mp
                        LEFT JOIN aidperiod aidperiod_5_mp on aidperiod_5_mp.id = mp_aid.aidperiod_5_mp
                        LEFT JOIN aidsource aidsource_17_mp on aidsource_17_mp.id = mp_aid.aidsource_17_mp
                        LEFT JOIN aidperiod aidperiod_17_mp on aidperiod_17_mp.id = mp_aid.aidperiod_17_mp
                        LEFT JOIN aidsource aidsource_22_mp on aidsource_22_mp.id = mp_aid.aidsource_22_mp
                        LEFT JOIN aidperiod aidperiod_22_mp on aidperiod_22_mp.id = mp_aid.aidperiod_22_mp
                        LEFT JOIN expensestype expensestype_12_mp on expensestype_12_mp.id = mp_aid.expensestype_12_mp
	                    LEFT JOIN person_family on person.id = person_family.person_id
	                    LEFT JOIN family on person_family.family_id = family.id
	                    LEFT JOIN family_visit on mp_aid.visit_id = family_visit.id
                        LEFT JOIN family_partner on family_partner.family_id = family.id
                        LEFT JOIN partner_donor on partner_donor.id = family_partner.partner_donor_id
                        LEFT JOIN partner on partner.id = partner_donor.partner_id
                        LEFT JOIN donor on donor.id = partner_donor.donor_id
	                    LEFT JOIN visitstate on visitstate.id = family_visit.visitstate_id 
	                    LEFT JOIN person_state on (person_state.person_id = person.id) and (person_state.family_id = family.id)
	                    LEFT JOIN personstate on personstate.id= person_state.personstate_id
	                    LEFT JOIN relation on relation.id= person_family.relation_id
	                    LEFT JOIN sex on sex.id= person.sex_id
                        LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id

                         where person_state.current_state = 1


                         and family_visit.visit_name like '" + visitname + "'group by person_family.id order by family.code; ";
                }
            }
            else if (category == "حالة الفرد")
            {
                if (!showResult)
                {
                    query = @"SELECT 
                            family.code as 'رمز العائلة',
                            GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                            MAX(CASE 
                                WHEN donor.name = 'F2F' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول F2F',
                            MAX(CASE 
                                WHEN donor.name = 'MPC' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول MPC',
                            CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
                            person.id as 'person_id',
                            family_visit.id as 'visit_id',
                            family.id as 'family_id',
                            family_visit.visit_name as 'الزيارة',
                            `visitstate`.`name` as 'حالة الزيارة',
                            IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد',
                            IFNULL(person_state.personstate_year, ' ') as 'سنة الحالة',
                            IFNULL(stateaddress.name, ' ') as 'مكان الإقامة',
                            CASE 
                                WHEN person_family.isReceiver = 0 THEN 'لا'
                                WHEN person_family.isReceiver = 1 THEN 'نعم'
                                ELSE ''
                            END as 'رب الأسرة',
                            IFNULL(relation.name, ' ') as 'الصفة الأسرية',
                            IFNULL(person.DOB, ' ') as 'المواليد',
                            IFNULL(sex.name, ' ') as 'الجنس',
                            IFNULL(person.national_Number, ' ') as 'الرقم الوطني'
                            FROM person_state
                            LEFT JOIN person ON person.id = person_state.person_id
                            LEFT JOIN person_family ON person.id = person_family.person_id
                            LEFT JOIN family ON person_family.family_id = family.id
                            LEFT JOIN family_visit ON family_visit.family_id = family.id
                            LEFT JOIN personstate ON personstate.id = person_state.personstate_id
                            LEFT JOIN relation ON relation.id = person_family.relation_id
                            LEFT JOIN sex ON sex.id = person.sex_id
                            LEFT JOIN family_partner ON person_family.family_id = family_partner.family_id
                            LEFT JOIN partner_donor ON family_partner.partner_donor_id = partner_donor.id
                            LEFT JOIN donor ON partner_donor.donor_id = donor.id 
                            LEFT JOIN partner ON partner_donor.partner_id = partner.id
                            LEFT JOIN visitstate ON visitstate.id = family_visit.visitstate_id
                            LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id

                            GROUP BY family.code, person.id,family.id, person_family.isReceiver, relation.name, person.DOB, sex.name, person.national_Number, personstate.name, person_state.personstate_year, person_state.stateaddress_id
                            ORDER BY family.code;";
                }
                else
                {
                    query = @"SELECT 
                            family.code as 'رمز العائلة',
                            GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                            MAX(CASE 
                                WHEN donor.name = 'F2F' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول F2F',
                            MAX(CASE 
                                WHEN donor.name = 'MPC' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول MPC',
                            CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
                            person.id as 'person_id',
                            family.id as 'family_id',
                            IFNULL(CASE WHEN personstate.name = 'N/A' THEN 'رب الأسرة' ELSE personstate.name END, ' ') as 'حالة الفرد الحالية',
                            IF(person_state.personstate_year = '0', '', person_state.personstate_year) as 'سنة الحالة الحالية',
                            IF(person_state.stateaddress_id = '0', '', stateaddress.name) as 'مكان الإقامة الحالية',
                            (
                                SELECT GROUP_CONCAT(CASE WHEN ss.name = 'N/A' THEN 'رب الأسرة' ELSE ss.name END SEPARATOR ', ')
                                FROM person_state ps
                                LEFT JOIN personstate ss ON ss.id = ps.personstate_id
                                WHERE ps.person_id = person_state.person_id
                                AND ps.family_id = family.id
                                GROUP BY ps.person_id 
                                ORDER BY ps.date DESC
                            ) as 'تاريخ الحالات',
                            (
                                SELECT GROUP_CONCAT(ps.date SEPARATOR ', ') 
                                FROM person_state ps
                                LEFT JOIN personstate ss ON ss.id = ps.personstate_id
                                WHERE ps.person_id = person_state.person_id
                                AND ps.family_id = family.id
                                GROUP BY ps.person_id 
                                ORDER BY ps.date DESC
                            ) as 'سنة تاريخ الحالات',
                            COUNT(CASE WHEN person_state.personstate_id = 2 THEN 1 ELSE NULL END) as 'عدد حالات مسافر',
                            COUNT(CASE WHEN person_state.personstate_id = 12 THEN 1 ELSE NULL END) as 'عدد حالات مسافر داخل القطر',
                            COUNT(CASE WHEN person_state.personstate_id = 8 THEN 1 ELSE NULL END) as 'عدد حالات عسكري',
                            COUNT(CASE WHEN person_state.personstate_id = 7 THEN 1 ELSE NULL END) as 'عدد حالات زواج'
                        FROM person 
                        LEFT JOIN person_family ON person.id = person_family.person_id
                        LEFT JOIN family ON person_family.family_id = family.id
                        LEFT JOIN person_state ON (person_state.person_id = person.id) AND (person_state.family_id = family.id)
                        LEFT JOIN personstate ON personstate.id = person_state.personstate_id
                        LEFT JOIN relation ON relation.id = person_family.relation_id
                        LEFT JOIN sex ON sex.id = person.sex_id
                        LEFT JOIN family_partner ON person_family.family_id = family_partner.family_id
                        LEFT JOIN partner_donor ON family_partner.partner_donor_id = partner_donor.id
                        LEFT JOIN donor ON partner_donor.donor_id = donor.id 
                        LEFT JOIN partner ON partner_donor.partner_id = partner.id  
                        LEFT JOIN stateaddress on stateaddress.id = person_state.stateaddress_id

                        WHERE 
                            person_state.current_state = 1 
                        GROUP BY 
                            family.code, 
                            person.id, 
                            family.id, 
                            person_family.isReceiver, 
                            relation.name, 
                            person.DOB, 
                            sex.name, 
                            person.national_Number, 
                            personstate.name, 
                            person_state.personstate_year, 
                            person_state.stateaddress_id 
                        ORDER BY 
                            family.code;";
                }
            }
            else if (category == "الحالة الاجتماعية")
            {
                if (!showResult)
                {
                    query = @"SELECT 
                            family.code as 'رمز العائلة',
                            GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                            MAX(CASE 
                                WHEN donor.name = 'F2F' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول F2F',
                            MAX(CASE 
                                WHEN donor.name = 'MPC' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول MPC',
                            CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
                            person.id as 'person_id',
                            family.id as 'family_id',
                            IFNULL(maritalstatus.name, ' ') as 'حالة الفرد',
                            IFNULL(person_maritalstatus.date, ' ') as 'سنة الحالة',
                            CASE 
                                WHEN person_family.isReceiver = 0 THEN 'لا'
                                WHEN person_family.isReceiver = 1 THEN 'نعم'
                                ELSE ''
                            END as 'رب الأسرة',
                            IFNULL(relation.name, ' ') as 'الصفة الأسرية',
                            IFNULL(person.DOB, ' ') as 'المواليد',
                            IFNULL(sex.name, ' ') as 'الجنس',
                            IFNULL(person.national_Number, ' ') as 'الرقم الوطني'
                            FROM person_maritalstatus
                            LEFT JOIN person ON person.id = person_maritalstatus.person_id
                            LEFT JOIN maritalstatus ON maritalstatus.id = person_maritalstatus.maritalstatus_id
                            LEFT JOIN person_family ON person.id = person_family.person_id
                            LEFT JOIN family ON person_family.family_id = family.id
                            LEFT JOIN relation ON relation.id = person_family.relation_id
                            LEFT JOIN sex ON sex.id = person.sex_id
                            LEFT JOIN family_partner ON person_family.family_id = family_partner.family_id
                            LEFT JOIN partner_donor ON family_partner.partner_donor_id = partner_donor.id
                            LEFT JOIN donor ON partner_donor.donor_id = donor.id 
                            LEFT JOIN partner ON partner_donor.partner_id = partner.id
                            GROUP BY family.code, person.id,family.id, person_family.isReceiver, relation.name, person.DOB, sex.name, person.national_Number, maritalstatus.name, person_maritalstatus.date
                            ORDER BY family.code;";
                }
                else
                {
                    query = @"SELECT 
                            family.code as 'رمز العائلة',
                            GROUP_CONCAT(DISTINCT partner.name) as 'الشريك',
                            MAX(CASE 
                                WHEN donor.name = 'F2F' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول F2F',
                            MAX(CASE 
                                WHEN donor.name = 'MPC' THEN
                                    CASE 
                                        WHEN family_partner.IsActive = 1 THEN 'فعالة'
                                        ELSE 'غير فعالة'
                                    END
                                ELSE '' END) as 'الممول MPC',
                            CONCAT(person.first_name, ' ', person.father_name, ' ', person.last_name) as 'الاسم الثلاثي',
                            person.id as 'person_id',
                            family.id as 'family_id',
                            IFNULL(maritalstatus.name, ' ') as 'الحالة الاجتماعية الحالية للفرد',
                            IF(person_maritalstatus.date = '0', '', person_maritalstatus.date) as 'سنة الحالة الحالية',
                            (
                                SELECT GROUP_CONCAT(ss.name SEPARATOR ', ')
                                FROM person_maritalstatus ps
                                LEFT JOIN maritalstatus ss ON ss.id = ps.maritalstatus_id
                                WHERE ps.person_id = person_maritalstatus.person_id
                                GROUP BY ps.person_id 
                                ORDER BY ps.date DESC
                            ) as 'تاريخ الحالات',
                            (
                                SELECT GROUP_CONCAT(ps.date SEPARATOR ', ') 
                                FROM person_maritalstatus ps
                                LEFT JOIN maritalstatus ss ON ss.id = ps.maritalstatus_id
                                WHERE ps.person_id = person_maritalstatus.person_id
                                GROUP BY ps.person_id 
                                ORDER BY ps.date DESC
                            ) as 'سنة تاريخ الحالات',
                            CASE 
                                WHEN person_family.isReceiver = 0 THEN 'لا'
                                WHEN person_family.isReceiver = 1 THEN 'نعم'
                                ELSE ''
                            END as 'رب الأسرة',
                            IFNULL(relation.name, ' ') as 'الصفة الأسرية',
                            IFNULL(person.DOB, ' ') as 'المواليد',
                            IFNULL(sex.name, ' ') as 'الجنس',
                            IFNULL(person.national_Number, ' ') as 'الرقم الوطني'
                        FROM person 
                        LEFT JOIN person_family ON person.id = person_family.person_id
                        LEFT JOIN family ON person_family.family_id = family.id
                        LEFT JOIN person_maritalstatus ON person_maritalstatus.person_id = person.id
                        LEFT JOIN maritalstatus ON maritalstatus.id = person_maritalstatus.maritalstatus_id
                        LEFT JOIN relation ON relation.id = person_family.relation_id
                        LEFT JOIN sex ON sex.id = person.sex_id
                        LEFT JOIN family_partner ON person_family.family_id = family_partner.family_id
                        LEFT JOIN partner_donor ON family_partner.partner_donor_id = partner_donor.id
                        LEFT JOIN donor ON partner_donor.donor_id = donor.id 
                        LEFT JOIN partner ON partner_donor.partner_id = partner.id
                        WHERE 
                            person_maritalstatus.current_state = 1
                        GROUP BY 
                            family.code, 
                            person.id, 
                            family.id, 
                            person_family.isReceiver, 
                            relation.name, 
                            person.DOB, 
                            sex.name, 
                            person.national_Number, 
                            maritalstatus.name, 
                            person_maritalstatus.date
                        ORDER BY 
                            family.code;";
                }
            }
            //    Group by person.id 

            // LEFT JOIN person_disease on person_disease.person_id = person.id
            // LEFT JOIN disease on disease.id = person_disease.disease_id

            //LEFT JOIN person_mp_aid on person_mp_aid.person_id = person.id
            //LEFT JOIN aidsource aidsource_5_mp on aidsource_5_mp.id = person_mp_aid.aidsource_5_mp
            //LEFT JOIN aidperiod aidperiod_5_mp on aidperiod_5_mp.id = person_mp_aid.aidperiod_5_mp
            //LEFT JOIN aidsource aidsource_17_mp on aidsource_17_mp.id = person_mp_aid.aidsource_17_mp
            //LEFT JOIN aidperiod aidperiod_17_mp on aidperiod_17_mp.id = person_mp_aid.aidperiod_17_mp
            //LEFT JOIN aidsource aidsource_22_mp on aidsource_22_mp.id = person_mp_aid.aidsource_22_mp
            //LEFT JOIN aidperiod aidperiod_22_mp on aidperiod_22_mp.id = person_mp_aid.aidperiod_22_mp
            //LEFT JOIN expensestype expensestype_12_mp on expensestype_12_mp.id = person_mp_aid.expensestype_12_mp

            //LEFT JOIN person_workexp on person_workexp.person_id = person.id
            //LEFT JOIN workexp on workexp.id = person_workexp.workexp_id
            //LEFT JOIN workposition on workposition.id = person_workexp.workposition_id
            //LEFT JOIN work_type on work_type.id = person_workexp.worktype_id
            //LEFT JOIN experience on experience.id = person_workexp.experience_id
            //LEFT JOIN workfor on  workfor.id = person_workexp.workfor_id
            //LEFT JOIN workplace on workplace.id = person_workexp.workplace_id 
            //LEFT JOIN expensestype expensestype_6 on expensestype_6.id = person_workexp.expensestype_6
            //LEFT JOIN expensestype expensestype_15 on expensestype_15.id = person_workexp.expensestype_15
            //LEFT JOIN expensestype expensestype_16 on expensestype_16.id = person_workexp.expensestype_16
            //LEFT JOIN expensestype expensestype_17 on expensestype_17.id = person_workexp.expensestype_17
            //LEFT JOIN expensestype expensestype_23 on expensestype_23.id = person_workexp.expensestype_23

            //LEFT JOIN person_state on person_state.person_id = person.id
            //LEFT JOIN personstate on personstate.id = person_state.personstate_id
            //LEFT JOIN aidperiod aidperiod_29 on aidperiod_29.id = person_state.aidperiod_29

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
