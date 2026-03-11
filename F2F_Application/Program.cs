using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F2F_Application
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main_Form());
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        //CHARSET=utf8 for recognizing Arabic in c#

        public static string ConnectionString_Online = "";
        public static string ConnectionString_Offline = "";

        public static string OnlineDataSource = "mysql.s807.sureserver.com";
        //public static string OfflineDataSource = "PC-ADMIN";
        public static string OfflineDataSource = "localhost";

        public static string ConnectionString;
        public static MySqlConnection MyConn;
        public static MySqlConnection MyFirstConn;
        public static string database = "";

        public static string Selected_Date = "";
        public static string Selected_Time = "";

        public static List<string> User_In_Database;


        public static List<int> Family_Opened = new List<int>();
        public static List<int> Person_Opened = new List<int>();
        public static List<int> Distribution_Opened = new List<int>();

        public static void set_ConnectionString()
        {

            if (Properties.Settings.Default.Selected_F2F != "")
            {
                if(Properties.Settings.Default.Selected_F2F == "J&M")
                    database = "hcsyria_f2f_jesus_mary";
                else if (Properties.Settings.Default.Selected_F2F == "Aleppo")
                    database = "hcsyria_f2f_ajudy";
                else database = "";
            }
            else database = "";


            //database = "hcsyria_f2f_test";
            ConnectionString_Online  = @"Server="     + OnlineDataSource  + ";Port=3306;Database=" + database + ";Uid=hcfamily2family;Password=F2F2018Center;Convert Zero Datetime=True;CHARSET=utf8;Connect Timeout=21600;Allow User Variables=True;sslmode=disabled;";
            ConnectionString_Offline = @"datasource=" + OfflineDataSource + ";port=3306;database=" + database + ";username=jj;password=pp                   ;Convert Zero Datetime=True;CHARSET=utf8;Connect Timeout=21600;Allow User Variables=True;sslmode=disabled;";
            if (Properties.Settings.Default.Online)  //online
                ConnectionString = ConnectionString_Online;
            else         //offline
                ConnectionString = ConnectionString_Offline;
        }

        public static string getConnString()
        {
            return ConnectionString;
        }

        public static bool get_ConnectionString()
        {
            bool status = false;
            if (ConnectionString == ConnectionString_Online)
                status = true;      //online
            else
                status = false;     //offline
            return status;
        }

        public static bool buildConnection()
        { 
            {
                MyConn = new MySqlConnection(ConnectionString);
                if (MyConn.State == System.Data.ConnectionState.Closed)
                {
                    MyConn.Open();
                    return true;
                }
                else return false;
            } 
        }

        public static bool firstbuildConnection()
        {
            try
            {
                MyFirstConn = new MySqlConnection(ConnectionString);
            if (MyFirstConn.State == System.Data.ConnectionState.Closed)
            {
                MyFirstConn.Open();
                return true;
            }
            else return false;
            }
            catch
            {
                return false;
            }
        }

        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }


        public static bool Check_Opened(string Form, int ID)
        {
            bool Opened = false;

            if (Form == "Family")
            {
                if (Family_Opened.IndexOf(ID) != -1)
                    Opened = true;
            }
            else if (Form == "Person")
            {
                if (Person_Opened.IndexOf(ID) != -1)
                    Opened = true;
            }
            else if (Form == "Distribution")
            {
                if (Distribution_Opened.IndexOf(ID) != -1)
                    Opened = true;
            }
            return Opened;
        }

        // Helper method to clean strings
        public static string CleanString(string input)
        { 
            // Trim and replace multiple spaces with single space
            return System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " ");
        }
    }
}
