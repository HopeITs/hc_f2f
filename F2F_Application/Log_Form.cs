using ClosedXML.Excel;
using F2F_Application.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Log_Form : Form
    {
        public Log_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            bs.ListChanged += bs_ListChanged;
        }

        private void bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            NumOfRows1.Text = Log_DataGridView.Rows.Count.ToString();
        }

        Main_Form main_form;
        Log l;
        BindingSource bs = new BindingSource();
        string Original_Filter_String = "";

        private void Log_Form_Load(object sender, EventArgs e)
        {
            try
            {
                l = new Log();

                Bind_Log_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Bind_Log_DataGridView()
        {
            Log_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            DataTable dt = l.Get_Log();
            bs.DataSource = dt;
            Log_DataGridView.ColumnHeadersVisible = false;
            Log_DataGridView.DataSource = null;
            Log_DataGridView.Columns.Clear();
            Log_DataGridView.DataSource = bs;
            Log_DataGridView.ColumnHeadersVisible = true;

            Log_DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NumOfRows1.Text = Log_DataGridView.Rows.Count.ToString();
            SearchToolBar.SetColumns(Log_DataGridView.Columns);
            bs.Filter = Original_Filter_String = bs.Sort = "";

        }

        private void Log_DataGridView_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                bs.Sort = Log_DataGridView.SortString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Log_DataGridView_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                Original_Filter_String = Log_DataGridView.FilterString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Log_DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            NumOfSelected1.Text = Log_DataGridView.SelectedRows.Count.ToString();
        }

        private void SearchToolBar_Search(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(e.ValueToSearch))
                {
                    bs.Filter = Original_Filter_String;
                }
                else
                {
                    string NewFilter = "";


                    if (e.ColumnToSearch != null)
                    {
                        //convert(JobNumber, 'System.String')
                        if (e.WholeWord)
                            NewFilter += "convert(`" + e.ColumnToSearch.Name + "`,'System.String') = '" + e.ValueToSearch + "'";
                        else
                            NewFilter += "convert(`" + e.ColumnToSearch.Name + "`,'System.String') like '%" + e.ValueToSearch + "%'";
                    }
                    else
                    {
                        int VisibleColumnsCount = Log_DataGridView.Columns.GetColumnCount(DataGridViewElementStates.Visible);
                        int i = 0;
                        foreach (DataGridViewColumn C in Log_DataGridView.Columns)
                        {
                            if (C.Visible == true)
                            {
                                if (e.WholeWord)
                                    NewFilter += "convert(`" + C.Name + "`,'System.String') = '" + e.ValueToSearch + "'";
                                else
                                    NewFilter += "convert(`" + C.Name + "`,'System.String') like '%" + e.ValueToSearch + "%'";

                                if (i < VisibleColumnsCount - 1)
                                    NewFilter += " or ";

                                i++;
                            }
                        }
                    }
                    string All_Filters = Original_Filter_String == "" ? NewFilter : Original_Filter_String + " and (" + NewFilter + ")";
                    bs.Filter = All_Filters;
                }
                /*
                bool restartsearch = true;
                int startColumn = 0;
                int startRow = 0;
                if (!e.FromBegin)
                {
                    bool endcol; bool endrow;

                    endcol = Log_DataGridView.CurrentCell.ColumnIndex + 1 >= Log_DataGridView.ColumnCount;
                    endrow = Log_DataGridView.CurrentCell.RowIndex + 1 >= Log_DataGridView.RowCount;

                    if (endcol && endrow)
                    {
                        startColumn = Log_DataGridView.CurrentCell.ColumnIndex;
                        startRow = Log_DataGridView.CurrentCell.RowIndex;
                    }
                    else
                    {
                        startColumn = endcol ? 0 : Log_DataGridView.CurrentCell.ColumnIndex + 1;
                        startRow = Log_DataGridView.CurrentCell.RowIndex + (endcol ? 1 : 0);
                    }
                }
                DataGridViewCell c = Log_DataGridView.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    startRow,
                    startColumn,
                    e.WholeWord,
                    e.CaseSensitive);
                if (c == null && restartsearch)
                {
                    c = Log_DataGridView.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    0,
                    0,
                    e.WholeWord,
                   e.CaseSensitive);
                }

                if (c != null)
                {
                    Log_DataGridView.CurrentCell = c;
                    if (e.FromBegin)
                        SearchToolBar.Items["button_frombegin"].PerformClick();
                }
                else
                    MessageBox.Show("لا يوجد نتائج لعرضها");*/
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Bind_Log_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
