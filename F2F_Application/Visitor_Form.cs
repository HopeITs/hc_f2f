using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Visitor_Form : MaterialForm
    {
        public Visitor_Form(Main_Form main_form)
        {
            InitializeComponent();

            this.main_form = main_form;
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);
        }

        Main_Form main_form;
        Visitor v; Categories c;
        Thread myTh;
        bool DataApproved = false;
        bool UserMode;

        private void Visitors_Form_Load(object sender, EventArgs e)
        {
            try
            {
                v = new Visitor(); c = new Categories();
                Bind_Visitor_DataGridView();
                Bind_Partner_Combobox(false);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Bind_Partner_Combobox(bool KeepSelection)
        {
            int SelectedValue = -1;
            if (Partner_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Partner_ComboBox.SelectedValue.ToString());

            DataTable dt;
            dt = c.Select_Table("partner", "", false, false);

            Partner_ComboBox.DataSource = dt;
            Partner_ComboBox.DisplayMember = "Name";
            Partner_ComboBox.ValueMember = "ID";
            if (KeepSelection && SelectedValue != -1)
                Partner_ComboBox.SelectedValue = SelectedValue;
            else
                Partner_ComboBox.SelectedIndex = -1;

            Partner_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

            this.Partner.DataSource = dt;
            this.Partner.DisplayMember = "name";
            this.Partner.ValueMember = "id";
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;

        }

        private void Bind_Visitor_DataGridView()
        {
            UserMode = false;
            DataTable dt;

            dt = v.Get_Visitor();

            Visitor_DataGridView.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Visitor_DataGridView.Rows.Add();
                Visitor_DataGridView.Rows[i].Cells["VisitorID"].Value = dt.Rows[i].Field<int>("id");
                Visitor_DataGridView.Rows[i].Cells["VisitorName"].Value = dt.Rows[i].Field<string>("name");
                if (dt.Rows[i]["partner_id"] != DBNull.Value)
                    Visitor_DataGridView.Rows[i].Cells["Partner"].Value = dt.Rows[i].Field<int>("partner_id");

            }
            UserMode = true;
        }

        private void Visitor_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DrawMode = DrawMode.OwnerDrawVariable;
                cb.DrawItem -= ComboBox_DrawItem;
                cb.DrawItem += ComboBox_DrawItem;
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background.
            e.DrawBackground();

            SolidBrush brush = new SolidBrush(Color.FromArgb(42, 158, 158));

            if (e.Index >= 0)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }

                object Ob = ((ComboBox)sender).Items[e.Index];
                // Draw the text.
                e.Graphics.DrawString(((ComboBox)sender).GetItemText(((ComboBox)sender).Items[e.Index]), e.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            }
        }
    }
}
