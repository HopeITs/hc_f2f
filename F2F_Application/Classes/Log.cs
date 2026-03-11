using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2F_Application.Classes
{
    class Log
    {
        string query;
        public DataTable Get_Log()
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            query = "SELECT log.title AS 'نوع العملية', log.affected_id AS 'IDs', log.details as 'Names', log.additionaldetails AS 'تفاصيل إضافية', log.form_name AS 'الواجهة', log.user AS 'المستخدم',log.date AS 'تاريخ العملية' FROM log;";
            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();

            return dt;
        }

        public DataSet Get_Users_Statistic(string FromDate, string ToDate)
        {
            //check connection//
            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            sc.Parameters.AddWithValue("@FromDate", FromDate);
            sc.Parameters.AddWithValue("@ToDate", ToDate);

            query = @"
                    DROP TABLE IF EXISTS firstupdate;
                    DROP TABLE IF EXISTS noquery;
                    DROP TABLE IF EXISTS insertedfamilies;
                    DROP TABLE IF EXISTS insertedmembers;
                    DROP TABLE IF EXISTS updatedfamilies;
                    DROP TABLE IF EXISTS updatedmembers;
                    DROP TABLE IF EXISTS inserted;
                    DROP TABLE IF EXISTS updated;
        
                    CREATE TABLE firstupdate 
                    SELECT
                    MIN(log.id) AS 'id',
                    log.title,
                    log.affected_id
                    FROM
                    log				
                    WHERE
                    log.title = 'UPDATE' AND log.details NOT LIKE '%Visit%' AND(log.Form_Name = 'Family_Form' OR log.Form_name = 'Person_Form') 
                    GROUP BY
                    log.Form_Name, log.affected_id;

        
                    CREATE TABLE noquery 
                    SELECT
                    log.id,
                    log.title,
                    log.affected_id
                    FROM
                    log
                    WHERE log.query = 'No query - From excel';
       
                    CREATE TABLE insertedfamilies
                    SELECT user,
                    COUNT(*) AS 'count'              
                    FROM (SELECT log.title, log.affected_id, log.form_name, log.user 
                    FROM log
                    LEFT JOIN family ON family.id = SUBSTRING_INDEX(log.affected_id, ' ', -1)
                                         
                    WHERE log.form_name = 'Family_Form' AND log.details NOT LIKE '%Visit%'
                    AND log.title = 'INSERT' AND log.query <> 'No query - From excel'
                    AND log.date >= STR_TO_DATE(@FromDate, '%d/%m/%Y') AND log.date <= STR_TO_DATE(@ToDate, '%d/%m/%Y') 
                    AND family.id IS NOT null GROUP BY log.form_name, log.affected_id) AS t1 GROUP BY user;


                    CREATE TABLE insertedmembers
                    SELECT user,
                    COUNT(*) AS 'count'              
                    FROM (SELECT log.title, log.affected_id, log.form_name, log.user 
                    FROM log
                    LEFT JOIN person ON person.id = SUBSTRING_INDEX(log.affected_id, ' ', -1)
                                          
                    WHERE log.form_name = 'Person_Form'
                    AND log.title = 'INSERT' AND log.query <> 'No query - From excel'
                    AND log.date >= STR_TO_DATE(@FromDate, '%d/%m/%Y') AND log.date <= STR_TO_DATE(@ToDate, '%d/%m/%Y') 
                    AND person.id IS NOT null GROUP BY log.form_name, log.affected_id) AS t1 GROUP BY user;

                    CREATE TABLE updatedfamilies
                    SELECT user,
                    COUNT(*) AS 'count'
                    FROM (SELECT log.title, log.affected_id, log.form_name, log.user 
                    FROM log 
                    LEFT JOIN family ON family.id = SUBSTRING_INDEX(log.affected_id, ' ', -1)
                     
                    LEFT JOIN noquery ON log.affected_id = noquery.affected_id
                    LEFT JOIN firstupdate ON firstupdate.id = log.id
                    WHERE log.form_name = 'Family_Form' AND log.details NOT LIKE '%Visit%'
                    AND log.title = 'UPDATE'
                    AND log.date >= STR_TO_DATE(@FromDate, '%d/%m/%Y') AND log.date <= STR_TO_DATE(@ToDate, '%d/%m/%Y') 
                    AND noquery.affected_id IS NOT null
                    AND firstupdate.id IS NOT null
                    AND family.id IS NOT null
                    GROUP BY log.form_name, log.affected_id) AS t2 GROUP BY user;


                    
                    CREATE TABLE updatedmembers
                    SELECT user,
                    COUNT(*) AS 'count'
                    FROM (SELECT log.title, log.affected_id, log.form_name, log.user 
                    FROM log 
                    LEFT JOIN person ON person.id = SUBSTRING_INDEX(log.affected_id, ' ', -1)
                     
                    LEFT JOIN noquery ON log.affected_id = noquery.affected_id
                    LEFT JOIN firstupdate ON firstupdate.id = log.id
                    WHERE log.form_name = 'Person_Form'
                    AND log.title = 'UPDATE'
                    AND log.date >= STR_TO_DATE(@FromDate, '%d/%m/%Y') AND log.date <= STR_TO_DATE(@ToDate, '%d/%m/%Y') 
                    AND noquery.affected_id IS NOT null
                    AND firstupdate.id IS NOT null
                    AND person.id IS NOT null
                    GROUP BY log.form_name, log.affected_id) AS t2 GROUP BY user;


                    CREATE TABLE inserted
                    SELECT ifnull(insertedfamilies.user, insertedmembers.user) as 'user', insertedfamilies.count as 'insertedfamilies', insertedmembers.count as 'insertedmembers'
                    FROM 
                    insertedfamilies LEFT JOIN insertedmembers ON insertedfamilies.user = insertedmembers.user
                    UNION
                    SELECT ifnull(insertedfamilies.user, insertedmembers.user) as 'user', insertedfamilies.count as 'insertedfamilies', insertedmembers.count as 'insertedmembers'
                    FROM 
                    insertedfamilies RIGHT JOIN insertedmembers ON insertedfamilies.user = insertedmembers.user;



                    CREATE TABLE updated
                    SELECT ifnull(updatedfamilies.user, updatedmembers.user) as 'user', updatedfamilies.count as 'updatedfamilies', updatedmembers.count as 'updatedmembers'
                    FROM 
                    updatedfamilies LEFT JOIN updatedmembers ON updatedfamilies.user = updatedmembers.user
                    UNION
                    SELECT ifnull(updatedfamilies.user, updatedmembers.user) as 'user', updatedfamilies.count as 'updatedfamilies', updatedmembers.count as 'updatedmembers'
                    FROM 
                    updatedfamilies RIGHT JOIN updatedmembers ON updatedfamilies.user = updatedmembers.user;


                    SELECT ifnull(inserted.user,updated.user) AS 'اسم المستخدم',ifnull(inserted.insertedfamilies,0) + ifnull(updated.updatedfamilies,0) as 'مجموع العائلات', ifnull(inserted.insertedfamilies,0) AS 'العائلات المدخلة حديثاً', ifnull(updated.updatedfamilies,0) AS 'العائلات المعدلة', ifnull(inserted.insertedmembers,0)  + ifnull(updated.updatedmembers,0) as 'مجموع الأفراد',  ifnull(inserted.insertedmembers,0) AS 'الأفراد المدخلين حديثاً', ifnull(updated.updatedmembers,0) AS 'الأفراد المعدلين'
                    FROM inserted LEFT JOIN updated ON inserted.user = updated.user 
                    UNION 
                    SELECT ifnull(inserted.user,updated.user) AS 'اسم المستخدم',ifnull(inserted.insertedfamilies,0) + ifnull(updated.updatedfamilies,0) as 'مجموع العائلات', ifnull(inserted.insertedfamilies,0) AS 'العائلات المدخلة حديثاً', ifnull(updated.updatedfamilies,0) AS 'العائلات المعدلة', ifnull(inserted.insertedmembers,0)  + ifnull(updated.updatedmembers,0) as 'مجموع الأفراد',  ifnull(inserted.insertedmembers,0) AS 'الأفراد المدخلين حديثاً', ifnull(updated.updatedmembers,0) AS 'الأفراد المعدلين'
                    FROM inserted RIGHT JOIN updated ON inserted.user = updated.user;


                    SELECT ifnull(sum(insertedfamilies),0) as 'TotalInsertedF' from inserted ;
                    SELECT ifnull(sum(updatedfamilies),0) as 'TotalUpdatedF' from updated ;
                    SELECT ifnull(sum(insertedmembers),0) as 'TotalInsertedM' from inserted ;
                    SELECT ifnull(sum(updatedmembers),0) as 'TotalUpdatedM' from updated ;

                    DROP TABLE IF EXISTS firstupdate;
                    DROP TABLE IF EXISTS noquery;
                    DROP TABLE IF EXISTS insertedfamilies;
                    DROP TABLE IF EXISTS insertedmembers;
                    DROP TABLE IF EXISTS updatedfamilies;
                    DROP TABLE IF EXISTS updatedmembers;
                    DROP TABLE IF EXISTS inserted;
                    DROP TABLE IF EXISTS updated;";

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
