using F2F_Application.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartArea = System.Windows.Forms.DataVisualization.Charting.ChartArea;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;
using Legend = System.Windows.Forms.DataVisualization.Charting.Legend;
using System.Windows.Forms.DataVisualization.Charting;
using F2F_Application.Properties;
using static F2F_Application.Classes.Statistics;
using ClosedXML.Excel;
using System.IO;
using ClosedXML.Excel.Drawings;
using NPOI.HSSF.UserModel; // For working with .xls files
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.SS.UserModel.Charts;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace F2F_Application
{
    public partial class Statistics_Form : Form
    {
        public Statistics_Form(Main_Form main_form, string v)
        {
            InitializeComponent();
            this.main_form = main_form;
            
        }

        Main_Form main_form;
        Categories c;
        Statistics s;

        private List<string> X_Axis_list;
        private List<double> xValues = new List<double>();
        private List<double> yValues = new List<double>();
        private List<Color> colors = new List<Color>();
        private string condition = "";
        private string conditionAid = "";
        private string conditionPerson = "";
        private string numberType = "COUNT";

        Microsoft.Office.Interop.Excel.Application excelApp;
        Excel._Worksheet worksheet;
        Excel.Workbook workbook;

        private void custimizeDesign()
        {
            panelFamilySubmenu.Visible = false;
            panelIndividualSubmenu.Visible = false;
        }
        //Family
        private void LoadGeneralInfoChartData()
        {
            try
            {
                System.Threading.Thread.Sleep(1000); // Simulate loading time
                Invoke(new System.Action(() =>
                {
                    Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(), Aidtype_ComboBox.SelectedItem.ToString());
                    Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                    Set_Charts_Controls();
                    LoadLivingWithFamilyChart();
                    LoadMemberInsideFamilyChart();
                    LoadFamilyInsideParishChart();
                }));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void LoadPowerInfoData()
        {
            try
            {
                System.Threading.Thread.Sleep(1000); // Simulate loading time
                Invoke(new System.Action(() =>
                {
                    //CreateExcelFile();
                    Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(), Aidtype_ComboBox.SelectedItem.ToString());
                    Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                    Set_Charts_Controls();
                    GetData();
                    LoadHasAmperChart();
                    LoadHasAmperAidChart();
                    LoadHasSolarPowerChart();
                    LoadHasBatteryChart();
                    LoadHasElectricityChart();
                    LoadAidsourceAmperChart();
                    LoadAidsourcePowerChart();
                    
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            
        }
        
        public void LoadAidInfoData()
        {
            try
            {
                System.Threading.Thread.Sleep(1000); // Simulate loading time
                Invoke(new System.Action(() =>
                {
                    //CreateExcelFile();
                    Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(), Aidtype_ComboBox.SelectedItem.ToString());
                    Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                    Set_Charts_Controls();

                    GetData();
                    LoadAidNameCountChart();
                    LoadAidSourceCountChart();
                    LoadMemberInsideFamilyAidChart();
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        public void LoadLivingWithFamilyChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            LivingWithFamilyData data = executor.GetLivingWithFamilyData(condition);
            GetData();

            // Set up ChartArea
            ChartArea chartArea = new ChartArea("MainChartArea");

            LivingWith_Chart.ChartAreas.Add(chartArea);
            LivingWith_Chart.ChartAreas[0].AxisX.Interval = 1;
            LivingWith_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "#,#";
            // Set up the chart
            Series series = new Series
            {
                Name = "LivingWithFamily",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Doughnut
            };

            LivingWith_Chart.Series.Add(series);

            // Add data points
            series.Points.AddXY("لا", data.NoCount);
            series.Points.AddXY("نعم", data.YesCount);
            series.LabelForeColor = System.Drawing.Color.White; // Change label color if needed
            // Optional: Customize the chart's appearance
            if (LivingWith_Chart.Legends.Count > 0)
            {
                LivingWith_Chart.Legends[0].Enabled = true;
                LivingWith_Chart.Legends[0].Docking = Docking.Top;
                LivingWith_Chart.Legends[0].Alignment = StringAlignment.Center;
            }
            LivingWith_Chart.Invalidate();

            worksheet.Cells[1, 7] = "لا";
            worksheet.Cells[1, 8] = "نعم";

            worksheet.Cells[2, 7] = data.NoCount;
            worksheet.Cells[2, 8] = data.YesCount;
            Excel.Range dataRange3 = worksheet.Range["G1", "H" + (3).ToString()];
            // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
            Excel.ChartObjects xlCharts3 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartObject3 = (Excel.ChartObject)xlCharts3.Add(1300, 50, 400, 300);
            Excel.Chart excelChart3 = chartObject3.Chart;
            excelChart3.SetSourceData(dataRange3);
            excelChart3.ChartType = Excel.XlChartType.xlPie;

            // Add a title to FamilyInsideParish_Chart
            excelChart3.HasTitle = true;
            excelChart3.ChartTitle.Text = "عائلة تسكن مع عائلة أخرى ";
        }

        public void LoadMemberInsideFamilyChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<MemberInsideFamilyData> dataList = executor.GetMemberInsideFamilyData(condition,numberType);

            MemberInsideFamily_Chart.ChartAreas.Clear();
            MemberInsideFamily_Chart.Series.Clear();
            GetData();
          
            if(dataList.Count != 0)
            {
                ChartArea chartAreaMember = new ChartArea();

                // Set axis

                chartAreaMember.AxisY.Title = "عدد العائلات";
                chartAreaMember.AxisX.Title = "عدد الأفراد";

                // Optionally customize other axis properties
                chartAreaMember.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaMember.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaMember.AxisX.LabelStyle.Angle = 45; // Rotate X-axis labels if needed
                                                             // Change the major grid line color
                chartAreaMember.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaMember.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaMember.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaMember.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines
                                                                                            // Add ChartArea to the chart
                MemberInsideFamily_Chart.ChartAreas.Add(chartAreaMember);
                chartAreaMember.AxisY.Maximum = int.Parse(TotalFamilyCount_Label.Text) + 1000;

                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.Int32,
                    Name = "FamilyCountSeries",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                MemberInsideFamily_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    series.Points.AddXY(data.MemberCount, data.FamilyCount);
                }

                // Add table headers for Chart 2 data
                worksheet.Cells[1, 4] = "عدد الأفراد";
                worksheet.Cells[1, 5] = "عدد العائلات";
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 4] = Convert.ToInt32(dataList[i].MemberCount);
                    worksheet.Cells[i + 2, 5] = dataList[i].FamilyCount;
                }

                // Create a range for the data
                Excel.Range dataRange2 = worksheet.Range["D1", "E" + (dataList.Count + 1).ToString()];


                // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
                Excel.ChartObjects xlCharts2 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject2 = (Excel.ChartObject)xlCharts2.Add(800, 50, 400, 300);
                Excel.Chart excelChart2 = chartObject2.Chart;
                excelChart2.SetSourceData(dataRange2);
                excelChart2.ChartType = Excel.XlChartType.xlColumnClustered;
                // Explicitly set the x-axis values if necessary
                excelChart2.SeriesCollection(1).XValues = worksheet.get_Range("D2:D12");
                // Add a title to FamilyInsideParish_Chart
                excelChart2.HasTitle = true;
                excelChart2.ChartTitle.Text = "توزع العائلات حسب عدد الافراد المقيمين فيها ";
            }
            
        }

        public void LoadFamilyInsideParishChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<FamilyInsideParishData> dataList = executor.GetFamilyInsideParishData(condition,numberType);

            FamilyInsideParish_Chart.ChartAreas.Clear();
            FamilyInsideParish_Chart.Series.Clear();

            if(dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد العائلات";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalFamilyCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "الطوائف";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                FamilyInsideParish_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    Name = "FamilyCountSeries",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                FamilyInsideParish_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    FamilyInsideParish_Chart.Series["FamilyCountSeries"].Points.AddXY(data.ParishName, data.FamilyCount);
                }

                // Add table headers
                worksheet.Cells[1, 1] = "الطوائف";
                worksheet.Cells[1, 2] = "عدد العائلات";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = dataList[i].ParishName;
                    worksheet.Cells[i + 2, 2] = dataList[i].FamilyCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["A1", "B" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(300, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد العائلات وفقاً للطوائف";
            }
            
        }

        public void LoadHasAmperChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            HasAmperData data = executor.GetHasAmperData(condition);
         
            // Set up ChartArea
            ChartArea chartArea = new ChartArea("MainChartArea");

            HasAmper_Chart.ChartAreas.Add(chartArea);
            HasAmper_Chart.ChartAreas[0].AxisX.Interval = 1;
            HasAmper_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "#,#";
            // Set up the chart
            Series series = new Series
            {
                Name = "HasAmper",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Doughnut
            };

            HasAmper_Chart.Series.Add(series);

            // Add data points
            series.Points.AddXY("لا", data.NoCount);
            series.Points.AddXY("نعم", data.YesCount);
            series.LabelForeColor = System.Drawing.Color.White; // Change label color if needed
            // Optional: Customize the chart's appearance
            if (HasAmper_Chart.Legends.Count > 0)
            {
                HasAmper_Chart.Legends[0].Enabled = true;
                HasAmper_Chart.Legends[0].Docking = Docking.Top;
                HasAmper_Chart.Legends[0].Alignment = StringAlignment.Center;
            }
            HasAmper_Chart.Invalidate();

            worksheet.Cells[1, 1] = "لا";
            worksheet.Cells[1, 2] = "نعم";

            worksheet.Cells[2, 1] = data.NoCount;
            worksheet.Cells[2, 2] = data.YesCount;
            Excel.Range dataRange1 = worksheet.Range["A1", "B" + (3).ToString()];
            // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
            Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(300, 50, 400, 300);
            Excel.Chart excelChart1 = chartObject1.Chart;
            excelChart1.SetSourceData(dataRange1);
            excelChart1.ChartType = Excel.XlChartType.xlPie;

            // Add a title to FamilyInsideParish_Chart
            excelChart1.HasTitle = true;
            excelChart1.ChartTitle.Text = "العائلات التي لديها اشتراك أمبير ";
        }

        public void LoadHasAmperAidChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            HasAmperAidData data = executor.GetHasAmperAidData(condition);

            // Set up ChartArea
            ChartArea chartArea = new ChartArea("MainChartArea");

            HasAmperAid_Chart.ChartAreas.Add(chartArea);
            HasAmperAid_Chart.ChartAreas[0].AxisX.Interval = 1;
            HasAmperAid_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "#,#";
            // Set up the chart
            Series series = new Series
            {
                Name = "HasAmperAid",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Doughnut
            };

            HasAmperAid_Chart.Series.Add(series);

            // Add data points
            series.Points.AddXY("لا", data.NoCount);
            series.Points.AddXY("نعم", data.YesCount);
            series.LabelForeColor = System.Drawing.Color.White; // Change label color if needed
            // Optional: Customize the chart's appearance
            if (HasAmper_Chart.Legends.Count > 0)
            {
                HasAmperAid_Chart.Legends[0].Enabled = true;
                HasAmperAid_Chart.Legends[0].Docking = Docking.Top;
                HasAmperAid_Chart.Legends[0].Alignment = StringAlignment.Center;
            }
            HasAmperAid_Chart.Invalidate();

            worksheet.Cells[1, 4] = "لا";
            worksheet.Cells[1, 5] = "نعم";

            worksheet.Cells[2, 4] = data.NoCount;
            worksheet.Cells[2, 5] = data.YesCount;
            Excel.Range dataRange2 = worksheet.Range["D1", "E" + (3).ToString()];
            // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
            Excel.ChartObjects xlCharts2 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartObject2 = (Excel.ChartObject)xlCharts2.Add(800, 50, 400, 300);
            Excel.Chart excelChart2 = chartObject2.Chart;
            excelChart2.SetSourceData(dataRange2);
            excelChart2.ChartType = Excel.XlChartType.xlPie;

            // Add a title to FamilyInsideParish_Chart
            excelChart2.HasTitle = true;
            excelChart2.ChartTitle.Text = "العائلات التي لديها مساعدة بدل أمبير ";
        }

        public void LoadHasSolarPowerChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            HasSolarPowerData data = executor.GetHasSolarPowerData(condition);

            // Set up ChartArea
            ChartArea chartArea = new ChartArea("MainChartArea");

            HasSolarPower_Chart.ChartAreas.Add(chartArea);
            HasSolarPower_Chart.ChartAreas[0].AxisX.Interval = 1;
            HasSolarPower_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "#,#";
            // Set up the chart
            Series series = new Series
            {
                Name = "HasSolarPower",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Doughnut
            };

            HasSolarPower_Chart.Series.Add(series);

            // Add data points
            series.Points.AddXY("لا", data.NoCount);
            series.Points.AddXY("نعم", data.YesCount);
            series.LabelForeColor = System.Drawing.Color.White; // Change label color if needed
            // Optional: Customize the chart's appearance
            if (HasAmper_Chart.Legends.Count > 0)
            {
                HasSolarPower_Chart.Legends[0].Enabled = true;
                HasSolarPower_Chart.Legends[0].Docking = Docking.Top;
                HasSolarPower_Chart.Legends[0].Alignment = StringAlignment.Center;
            }
            HasSolarPower_Chart.Invalidate();

            worksheet.Cells[1, 7] = "لا";
            worksheet.Cells[1, 8] = "نعم";

            worksheet.Cells[2, 7] = data.NoCount;
            worksheet.Cells[2, 8] = data.YesCount;
            Excel.Range dataRange3 = worksheet.Range["G1", "H" + (3).ToString()];
            // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
            Excel.ChartObjects xlCharts3 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartObject3 = (Excel.ChartObject)xlCharts3.Add(1300, 50, 400, 300);
            Excel.Chart excelChart3 = chartObject3.Chart;
            excelChart3.SetSourceData(dataRange3);
            excelChart3.ChartType = Excel.XlChartType.xlPie;

            // Add a title to FamilyInsideParish_Chart
            excelChart3.HasTitle = true;
            excelChart3.ChartTitle.Text = "العائلات التي لديها طاقة شمسية ";
        }

        public void LoadHasBatteryChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            HasBatteryData data = executor.GetHasBatteryData(condition);

            // Set up ChartArea
            ChartArea chartArea = new ChartArea("MainChartArea");

            HasBattery_Chart.ChartAreas.Add(chartArea);
            HasBattery_Chart.ChartAreas[0].AxisX.Interval = 1;
            HasBattery_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "#,#";
            // Set up the chart
            Series series = new Series
            {
                Name = "HasBattery",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Doughnut
            };

            HasBattery_Chart.Series.Add(series);

            // Add data points
            series.Points.AddXY("لا", data.NoCount);
            series.Points.AddXY("نعم", data.YesCount);
            series.LabelForeColor = System.Drawing.Color.White; // Change label color if needed
            // Optional: Customize the chart's appearance
            if (HasBattery_Chart.Legends.Count > 0)
            {
                HasBattery_Chart.Legends[0].Enabled = true;
                HasBattery_Chart.Legends[0].Docking = Docking.Top;
                HasBattery_Chart.Legends[0].Alignment = StringAlignment.Center;
            }
            HasBattery_Chart.Invalidate();

            worksheet.Cells[1, 10] = "لا";
            worksheet.Cells[1, 11] = "نعم";

            worksheet.Cells[2, 10] = data.NoCount;
            worksheet.Cells[2, 11] = data.YesCount;
            Excel.Range dataRange3 = worksheet.Range["J1", "K" + (3).ToString()];
            // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
            Excel.ChartObjects xlCharts3 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartObject3 = (Excel.ChartObject)xlCharts3.Add(1800, 50, 400, 300);
            Excel.Chart excelChart3 = chartObject3.Chart;
            excelChart3.SetSourceData(dataRange3);
            excelChart3.ChartType = Excel.XlChartType.xlPie;

            // Add a title to FamilyInsideParish_Chart
            excelChart3.HasTitle = true;
            excelChart3.ChartTitle.Text = "العائلات التي لديها بطارية ";
        }

        public void LoadHasElectricityChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            HasElectricityData data = executor.GetHasElectricityData(condition);

            // Set up ChartArea
            ChartArea chartArea = new ChartArea("MainChartArea");

            HasElectricity_Chart.ChartAreas.Add(chartArea);
            HasElectricity_Chart.ChartAreas[0].AxisX.Interval = 1;
            HasElectricity_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "#,#";
            // Set up the chart
            Series series = new Series
            {
                Name = "HasElectricity",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Doughnut
            };

            HasElectricity_Chart.Series.Add(series);

            // Add data points
            series.Points.AddXY("لا", data.NoCount);
            series.Points.AddXY("نعم", data.YesCount);
            series.LabelForeColor = System.Drawing.Color.White; // Change label color if needed
            // Optional: Customize the chart's appearance
            if (HasElectricity_Chart.Legends.Count > 0)
            {
                HasElectricity_Chart.Legends[0].Enabled = true;
                HasElectricity_Chart.Legends[0].Docking = Docking.Top;
                HasElectricity_Chart.Legends[0].Alignment = StringAlignment.Center;
            }
            HasElectricity_Chart.Invalidate();

            worksheet.Cells[1, 13] = "لا";
            worksheet.Cells[1, 14] = "نعم";

            worksheet.Cells[2, 13] = data.NoCount;
            worksheet.Cells[2, 14] = data.YesCount;
            Excel.Range dataRange3 = worksheet.Range["M1", "N" + (3).ToString()];
            // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
            Excel.ChartObjects xlCharts3 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartObject3 = (Excel.ChartObject)xlCharts3.Add(2300, 50, 400, 300);
            Excel.Chart excelChart3 = chartObject3.Chart;
            excelChart3.SetSourceData(dataRange3);
            excelChart3.ChartType = Excel.XlChartType.xlPie;

            // Add a title to FamilyInsideParish_Chart
            excelChart3.HasTitle = true;
            excelChart3.ChartTitle.Text = "العائلات التي تصلها كهرباء الدولة ";
        }

        public void LoadAidsourceAmperChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<AidsourceAmper> dataList = executor.GetAidsourceAmperData(condition, numberType);

            AidSourceAmper_Chart.ChartAreas.Clear();
            AidSourceAmper_Chart.Series.Clear();

            if(dataList.Count != 0)
            {
                ChartArea chartAreaAidsource = new ChartArea();

                // Set axis

                chartAreaAidsource.AxisY.Title = "عدد العائلات";
                chartAreaAidsource.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaAidsource.AxisX.Title = "جهة المساعدة";
                chartAreaAidsource.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaAidsource.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaAidsource.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaAidsource.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaAidsource.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaAidsource.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaAidsource.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaAidsource.AxisX.IsLabelAutoFit = false;
                chartAreaAidsource.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaAidsource.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                AidSourceAmper_Chart.ChartAreas.Add(chartAreaAidsource);


                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    Name = "FamilyCountSeries",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                AidSourceAmper_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    AidSourceAmper_Chart.Series["FamilyCountSeries"].Points.AddXY(data.AidsourceName, data.FamilyCount);
                }

                // Add table headers
                worksheet.Cells[30, 1] = "جهات المساعدة";
                worksheet.Cells[30, 2] = "عدد العائلات";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 30, 1] = dataList[i].AidsourceName;
                    worksheet.Cells[i + 30, 2] = dataList[i].FamilyCount;
                }
                // Create a range for the data
                Excel.Range dataRange6 = worksheet.Range["A30", "B" + (30 + dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts6 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject6 = (Excel.ChartObject)xlCharts6.Add(300, 400, 400, 300);
                Excel.Chart excelChart6 = chartObject6.Chart;
                excelChart6.SetSourceData(dataRange6);
                excelChart6.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart6.HasTitle = true;
                excelChart6.ChartTitle.Text = "اهم جهات المساعدة كبدل أمبير";
            }
        }

        public void LoadAidsourcePowerChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<AidsourcePower> dataList = executor.GetAidsourcePowerData(condition, numberType);

            AidSourceSolar_Chart.ChartAreas.Clear();
            AidSourceSolar_Chart.Series.Clear();

            if(dataList.Count != 0)
            {
                ChartArea chartAreaAidsource = new ChartArea();

                // Set axis

                chartAreaAidsource.AxisY.Title = "عدد العائلات";
                chartAreaAidsource.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaAidsource.AxisX.Title = "جهة المساعدة";
                chartAreaAidsource.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaAidsource.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaAidsource.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaAidsource.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaAidsource.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaAidsource.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaAidsource.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaAidsource.AxisX.IsLabelAutoFit = false;
                chartAreaAidsource.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaAidsource.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                AidSourceSolar_Chart.ChartAreas.Add(chartAreaAidsource);


                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    Name = "FamilyCountSeries",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                AidSourceSolar_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    AidSourceSolar_Chart.Series["FamilyCountSeries"].Points.AddXY(data.AidsourceName, data.FamilyCount);
                }

                // Add table headers
                worksheet.Cells[52, 1] = "جهات المساعدة";
                worksheet.Cells[52, 2] = "عدد العائلات";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 52, 1] = dataList[i].AidsourceName;
                    worksheet.Cells[i + 52, 2] = dataList[i].FamilyCount;
                }
                // Create a range for the data
                Excel.Range dataRange7 = worksheet.Range["A52", "B" + (52 + dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts7 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject7 = (Excel.ChartObject)xlCharts7.Add(300, 750, 400, 300);
                Excel.Chart excelChart7 = chartObject7.Chart;
                excelChart7.SetSourceData(dataRange7);
                excelChart7.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart7.HasTitle = true;
                excelChart7.ChartTitle.Text = "اهم جهات المساعدة طاقة شمسية";
            }
        }

        public void GetData()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            Data data = executor.GetData(condition,conditionPerson,numberType);
            Data aiddata = executor.GetAidData(conditionAid, numberType, Aidtype_ComboBox.SelectedItem.ToString());
            TotalFamilyCount_Label.Text = data.TotalFamilyCount.ToString();
            BeneficiariesAverage_Label.Text = data.BeneficiariesAverage.ToString();
            YearlyPowerCost_Label.Text = data.YearlyPowerCost.ToString("N");
            AverageAgeAid_Label.Text = aiddata.AverageAgeAids.ToString();
            AveragAgePerson_Label.Text = data.AverageAgePerson.ToString();
            TotalMemberCount_Label.Text = data.TotalMemberCount.ToString();
            TotalMicroBeneficiary_Label.Text = data.TotalMicroBenef.ToString();
        }

        public void LoadAidNameCountChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<AidnameCount> dataList = executor.GetAidnameCountData(condition, numberType, Aidtype_ComboBox.SelectedItem.ToString());

            AidName_Chart.ChartAreas.Clear();
            AidName_Chart.Series.Clear();

            if(dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد العائلات";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalFamilyCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "المساعدة";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                AidName_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    Name = "AidName",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                AidName_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    AidName_Chart.Series["AidName"].Points.AddXY(data.AidName, data.FamilyCount);
                }

                // Add table headers
                worksheet.Cells[1, 1] = "نوع المساعدة";
                worksheet.Cells[1, 2] = "عدد العائلات";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = dataList[i].AidName;
                    worksheet.Cells[i + 2, 2] = dataList[i].FamilyCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["A1", "B" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(400, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد العائلات وفقاً لنوع المساعدة";
            }

            
        }
        
        public void LoadAidSourceCountChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<AidSourceCount> dataList = executor.GetAidSourceCountData(condition, numberType, Aidtype_ComboBox.SelectedItem.ToString());

            AidSource_Chart.ChartAreas.Clear();
            AidSource_Chart.Series.Clear();
            if (dataList.Count != 0)
            {

                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد العائلات";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalFamilyCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "جهة المساعدة";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                AidSource_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    Name = "AidSource",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                AidSource_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    AidSource_Chart.Series["AidSource"].Points.AddXY(data.AidSource, data.FamilyCount);
                }

                // Add table headers
                worksheet.Cells[1, 4] = " جهة المساعدة";
                worksheet.Cells[1, 5] = "عدد العائلات";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 4] = dataList[i].AidSource;
                    worksheet.Cells[i + 2, 5] = dataList[i].FamilyCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["D1", "E" + (dataList.Count + 1).ToString()];

                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(900, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد العائلات وفقاً  لجهة المساعدة";
                if (Aidtype_ComboBox.SelectedItem == "N/A" || Aidtype_ComboBox.SelectedItem == "سلة غذائية")
                    label26.Text = " (جهات المساعدة (سلة غذائية";
                else if (Aidtype_ComboBox.SelectedItem == "وجبات طعام")
                    label26.Text = " (جهات المساعدة (وجبات طعام";
                else if (Aidtype_ComboBox.SelectedItem == "منظفات")
                    label26.Text = " (جهات المساعدة (منظفات";
                else if (Aidtype_ComboBox.SelectedItem == "رواتب مسنين")
                    label26.Text = " (جهات المساعدة (رواتب مسنين";
                else if (Aidtype_ComboBox.SelectedItem == "ترميم")
                    label26.Text = " (جهات المساعدة (ترميم";
                else if (Aidtype_ComboBox.SelectedItem == "بدل محروقات")
                    label26.Text = " (جهات المساعدة (بدل محروقات";
                else if (Aidtype_ComboBox.SelectedItem == "مساعدة أصدقاء")
                    label26.Text = " (جهات المساعدة (مساعدة أصدقاء";
            }
        }

        public void LoadMemberInsideFamilyAidChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<MemberInsideFamilyData> dataList = executor.GetMemberInsideFamilyAidData(condition, numberType,Aidtype_ComboBox.SelectedItem.ToString());

            MemberInsideFamilyAid_Chart.ChartAreas.Clear();
            MemberInsideFamilyAid_Chart.Series.Clear();
            GetData();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaMember = new ChartArea();


                // Set axis

                chartAreaMember.AxisY.Title = "عدد العائلات";
                chartAreaMember.AxisX.Title = "عدد الأفراد";

                // Optionally customize other axis properties
                chartAreaMember.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaMember.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaMember.AxisX.LabelStyle.Angle = 45; // Rotate X-axis labels if needed
                                                             // Change the major grid line color
                chartAreaMember.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaMember.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaMember.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaMember.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines
                                                                                            // Add ChartArea to the chart
                MemberInsideFamilyAid_Chart.ChartAreas.Add(chartAreaMember);
                chartAreaMember.AxisY.Maximum = int.Parse(TotalFamilyCount_Label.Text) + 1000;

                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.Int32,
                    Name = "FamilyCountSeries",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                MemberInsideFamilyAid_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    series.Points.AddXY(data.MemberCount, data.FamilyCount);
                }

                // Add table headers for Chart 2 data
                worksheet.Cells[1, 7] = "عدد الأفراد";
                worksheet.Cells[1, 8] = "عدد العائلات";
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 7] = Convert.ToInt32(dataList[i].MemberCount);
                    worksheet.Cells[i + 2, 8] = dataList[i].FamilyCount;
                }

                // Create a range for the data
                Excel.Range dataRange2 = worksheet.Range["G1", "H" + (dataList.Count + 1).ToString()];


                // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
                Excel.ChartObjects xlCharts2 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject2 = (Excel.ChartObject)xlCharts2.Add(1400, 50, 400, 300);
                Excel.Chart excelChart2 = chartObject2.Chart;
                excelChart2.SetSourceData(dataRange2);
                excelChart2.ChartType = Excel.XlChartType.xlColumnClustered;
                excelChart2.SeriesCollection(1).XValues = worksheet.get_Range("G2:G12");

                // Add a title to FamilyInsideParish_Chart
                excelChart2.HasTitle = true;
                excelChart2.ChartTitle.Text = "توزع العائلات حسب عدد الافراد المقيمين فيها ";

                if (Aidtype_ComboBox.SelectedItem == "N/A" || Aidtype_ComboBox.SelectedItem == "سلة غذائية")
                    label27.Text = " (توزع العائلات حسب عدد الافراد المقيمين فيها (سلة غذائية";
                else if (Aidtype_ComboBox.SelectedItem == "وجبات طعام")
                    label27.Text = " (توزع العائلات حسب عدد الافراد المقيمين فيها (وجبات طعام";
                else if (Aidtype_ComboBox.SelectedItem == "منظفات")
                    label27.Text = " (توزع العائلات حسب عدد الافراد المقيمين فيها  (منظفات";
                else if (Aidtype_ComboBox.SelectedItem == "رواتب مسنين")
                    label27.Text = " (توزع العائلات حسب عدد الافراد المقيمين فيها (رواتب مسنين";
                else if (Aidtype_ComboBox.SelectedItem == "ترميم")
                    label27.Text = " (توزع العائلات حسب عدد الافراد المقيمين فيها (ترميم";
                else if (Aidtype_ComboBox.SelectedItem == "بدل محروقات")
                    label27.Text = " (توزع العائلات حسب عدد الافراد المقيمين فيها (بدل محروقات";
                else if (Aidtype_ComboBox.SelectedItem == "مساعدة أصدقاء")
                    label27.Text = " (توزع العائلات حسب عدد الافراد المقيمين فيها (مساعدة أصدقاء";
            }
        }

        //Person
        private void LoadPersonGeneralInfoChartData()
        {
            try
            {
                System.Threading.Thread.Sleep(1000); // Simulate loading time
                Invoke(new System.Action(() =>
                {
                    Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(), Aidtype_ComboBox.SelectedItem.ToString());
                    Check_PersonConditions(PersonState_ComboBox.SelectedIndex, Sex_ComboBox.SelectedIndex, AgeRange_ComboBox.Text, PersonMaritalStatus_ComboBox.SelectedIndex,FromDate_ComboBox.Text,ToDate_ComboBox.Text);
                    Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                    Set_Charts_Controls();
                    GetData();
                    LoadPersonGenderChart();
                    LoadPersonStateChart();
                    LoadPersonStateTypeChart();
                    LoadPersonAgeGenderChart();
                    LoadPersonMPAidSourceChart();
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void LoadPersonWorkInfoChartData()
        {
            try
            {
                System.Threading.Thread.Sleep(1000); // Simulate loading time
                Invoke(new System.Action(() =>
                {
                    Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(), Aidtype_ComboBox.SelectedItem.ToString());
                    Check_PersonConditions(PersonState_ComboBox.SelectedIndex, Sex_ComboBox.SelectedIndex, AgeRange_ComboBox.Text, PersonMaritalStatus_ComboBox.SelectedIndex,FromDate_ComboBox.Text, ToDate_ComboBox.Text);
                    Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                    Set_Charts_Controls();
                    GetData();
                    LoadPersonWorkChart();
                    LoadPersonWorkPositionChart();
                    LoadPersonTopWorkNameChart();
                    LoadPersonMPAidSourceChart();
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void LoadPersonDiseaseInfoChartData()
        {
            try
            {
                System.Threading.Thread.Sleep(1000); // Simulate loading time
                Invoke(new System.Action(() =>
                {
                    Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(), Aidtype_ComboBox.SelectedItem.ToString());
                    Check_PersonConditions(PersonState_ComboBox.SelectedIndex, Sex_ComboBox.SelectedIndex, AgeRange_ComboBox.Text, PersonMaritalStatus_ComboBox.SelectedIndex, FromDate_ComboBox.Text, ToDate_ComboBox.Text);
                    Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                    Set_Charts_Controls();
                    GetData();
                    LoadPersonDiseaseCatChartData();
                    LoadPersonDiseaseNameChartData();
                    LoadPersonDiseaseAidChartData();
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void LoadPersonMigrationInfoChartData()
        {
            try
            {
                System.Threading.Thread.Sleep(1000); // Simulate loading time
                Invoke(new System.Action(() =>
                {
                    Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(), Aidtype_ComboBox.SelectedItem.ToString());
                    Check_PersonConditions(PersonState_ComboBox.SelectedIndex, Sex_ComboBox.SelectedIndex, AgeRange_ComboBox.Text, PersonMaritalStatus_ComboBox.SelectedIndex, FromDate_ComboBox.Text, ToDate_ComboBox.Text);
                    Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                    Set_Charts_Controls();
                    GetData();
                    LoadPersonMigrateYearChartData();
                    LoadPersonMigrateCountryChartData();
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void LoadPersonGenderChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            PersonGenderData data = executor.GetPersonGenderData(condition,conditionPerson,numberType);
            PersonGender_Chart.ChartAreas.Clear();
            PersonGender_Chart.Series.Clear();

            
                // Set up ChartArea
                ChartArea chartArea = new ChartArea("MainChartArea");

                PersonGender_Chart.ChartAreas.Add(chartArea);
                PersonGender_Chart.ChartAreas[0].AxisX.Interval = 1;
                PersonGender_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "#,#";
                // Set up the chart
                Series series = new Series
                {
                    Name = "PersonGender",
                    IsValueShownAsLabel = true,
                    ChartType = SeriesChartType.Doughnut
                };

                PersonGender_Chart.Series.Add(series);

                // Add data points
                series.Points.AddXY("ذكر", data.MaleCount);
                series.Points.AddXY("أنثى", data.FemaleCount);
                series.LabelForeColor = System.Drawing.Color.White; // Change label color if needed
                                                                    // Optional: Customize the chart's appearance
                if (LivingWith_Chart.Legends.Count > 0)
                {
                    PersonGender_Chart.Legends[0].Enabled = true;
                    PersonGender_Chart.Legends[0].Docking = Docking.Top;
                    PersonGender_Chart.Legends[0].Alignment = StringAlignment.Center;
                }
                PersonGender_Chart.Invalidate();

                worksheet.Cells[1, 1] = "ذكر";
                worksheet.Cells[1, 2] = "أنثى";

                worksheet.Cells[2, 1] = data.MaleCount;
                worksheet.Cells[2, 2] = data.FemaleCount;
                Excel.Range dataRange1 = worksheet.Range["A1", "B" + (3).ToString()];
                // Add a chart to the worksheet for MemberInsideFamily_Chart(Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(600, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlPie;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
         
            
        }

        public void LoadPersonStateChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonStateData> dataList = executor.GetPersonStateData(condition,conditionPerson, numberType);
            PersonState_Chart.ChartAreas.Clear();
            PersonState_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد الأفراد";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "حالات الفرد";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonState_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    Name = "PersonState",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                PersonState_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    PersonState_Chart.Series["PersonState"].Points.AddXY(data.StateName, data.MemberCount);
                }

                // Add table headers
                worksheet.Cells[1, 4] = "حالات الفرد";
                worksheet.Cells[1, 5] = "عدد الأفراد";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 4] = dataList[i].StateName;
                    worksheet.Cells[i + 2, 5] = dataList[i].MemberCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["D1", "E" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(1100, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد الأفراد وفقاً للحالات";
            }
            
        }
        
        public void LoadPersonStateTypeChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonStateTypeData> dataList = executor.GetPersonStateTypeData(condition, conditionPerson, numberType);
            PersonStateType_Chart.ChartAreas.Clear();
            PersonStateType_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                NoDataPI1_Label.Visible = false;
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد الأفراد";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "حالات الفرد";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonStateType_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                Series series = new Series
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    Name = "PersonStateType",
                    IsVisibleInLegend = false, // This hides the series name from the legend
                    IsValueShownAsLabel = true // Show the FamilyCount inside the columns
                };
                PersonStateType_Chart.Series.Add(series);

                // Customize the appearance of the labels
                series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points
                foreach (var data in dataList)
                {
                    PersonStateType_Chart.Series["PersonStateType"].Points.AddXY(data.StatusName, data.MemberCount);
                }

                // Add table headers
                worksheet.Cells[1, 7] = "حالات الفرد";
                worksheet.Cells[1, 8] = "عدد الأفراد";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 7] = dataList[i].StatusName;
                    worksheet.Cells[i + 2, 8] = dataList[i].MemberCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["G1", "H" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(1600, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد الأفراد وفقاً للاستفادة";
            }
            else NoDataPI1_Label.Visible = true;
        }

        public void LoadPersonAgeGenderChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonAgeGenderData> dataList = executor.GetPersonAgeGenderData(condition, conditionPerson, numberType);
            PersonAgeGender_Chart.ChartAreas.Clear();
            PersonAgeGender_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                NoDataPI2_Label.Visible = false;
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد الأفراد";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "الشرائح العمرية";
                //chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonAgeGender_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series maleSeries = new Series("Male");
                Series femaleSeries = new Series("Female");

                // Set both series to column type
                maleSeries.ChartType = SeriesChartType.Column;
                femaleSeries.ChartType = SeriesChartType.Column;

                maleSeries.IsVisibleInLegend = true; // This hides the series name from the legend
                maleSeries.IsValueShownAsLabel = true; // Show the FamilyCount inside the columns

                femaleSeries.IsVisibleInLegend = true; // This hides the series name from the legend
                femaleSeries.IsValueShownAsLabel = true; // Show the FamilyCount inside the columns


                PersonAgeGender_Chart.Series.Add(maleSeries);
                PersonAgeGender_Chart.Series.Add(femaleSeries);

                // Customize the appearance of the labels
                maleSeries.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                maleSeries.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                maleSeries.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                femaleSeries.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                femaleSeries.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                femaleSeries.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonAgeGender_Chart.Series["Male"].Points.AddXY(dataList[i].AgerangeName, dataList[i].MaleCount);
                    PersonAgeGender_Chart.Series["Female"].Points.AddXY(dataList[i].AgerangeName, dataList[i].FemaleCount);
                }

                // Add table headers
                worksheet.Cells[1, 10] = "الشرائح العمرية";
                worksheet.Cells[1, 11] = "عدد الذكور";
                worksheet.Cells[1, 12] = "عدد الإناث";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 10] = dataList[i].AgerangeName;
                    worksheet.Cells[i + 2, 11] = dataList[i].MaleCount;
                    worksheet.Cells[i + 2, 12] = dataList[i].FemaleCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["J1", "L" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(2100, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد الأفراد وفقاً للشرائح العمرية";
            }
            else NoDataPI2_Label.Visible = true;
        }

        //WORK
        public void LoadPersonWorkChart()
        {
                MySQLQueryExecutor executor = new MySQLQueryExecutor();
                List<PersonWorkData> dataList = executor.GetPersonWorkData(condition, conditionPerson, numberType);
                PersonWork_Chart.ChartAreas.Clear();
                PersonWork_Chart.Series.Clear();
                if (dataList.Count != 0)
                {
                    ChartArea chartAreaFamily = new ChartArea();

                    // Set axis

                    chartAreaFamily.AxisY.Title = "عدد الأفراد";
                    chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                    chartAreaFamily.AxisX.Title = "العمل";
                    //chartAreaFamily.AxisX.Interval = .5;
                    // Change the major grid line color
                    chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                    chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                    // Optional: Change the minor grid line color (if minor grid lines are enabled)
                    chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                    chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                    // Optionally customize other axis properties
                    chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                    chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                    chartAreaFamily.AxisX.IsLabelAutoFit = false;
                    chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                    chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                    // Add ChartArea to the chart
                    PersonWork_Chart.ChartAreas.Add(chartAreaFamily);


                    // Create and configure Series
                    // Create Male and Female series
                    Series maleSeries = new Series("Male");
                    Series femaleSeries = new Series("Female");

                    // Set both series to column type
                    maleSeries.ChartType = SeriesChartType.Column;
                    femaleSeries.ChartType = SeriesChartType.Column;

                    maleSeries.IsVisibleInLegend = true; // This hides the series name from the legend
                    maleSeries.IsValueShownAsLabel = true; // Show the FamilyCount inside the columns

                    femaleSeries.IsVisibleInLegend = true; // This hides the series name from the legend
                    femaleSeries.IsValueShownAsLabel = true; // Show the FamilyCount inside the columns


                PersonWork_Chart.Series.Add(maleSeries);
                PersonWork_Chart.Series.Add(femaleSeries);

                    // Customize the appearance of the labels
                    maleSeries.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                    maleSeries.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                    maleSeries.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                    femaleSeries.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                    femaleSeries.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                    femaleSeries.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                    // Add data points

                    for (int i = 0; i < dataList.Count; i++)
                    {
                        PersonWork_Chart.Series["Male"].Points.AddXY(dataList[i].workingStatus, dataList[i].MaleCount);
                        PersonWork_Chart.Series["Female"].Points.AddXY(dataList[i].workingStatus, dataList[i].FemaleCount);
                    }

                    // Add table headers
                    worksheet.Cells[1, 1] = "العمل";
                    worksheet.Cells[1, 2] = "عدد الذكور";
                    worksheet.Cells[1, 3] = "عدد الإناث";

                    // Populate the worksheet with the data
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1] = dataList[i].workingStatus;
                        worksheet.Cells[i + 2, 2] = dataList[i].MaleCount;
                        worksheet.Cells[i + 2, 3] = dataList[i].FemaleCount;
                    }
                    // Create a range for the data
                    Excel.Range dataRange1 = worksheet.Range["A1", "C3"];
                    // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                    Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                    Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(700, 50, 400, 300);
                    Excel.Chart excelChart1 = chartObject1.Chart;
                    excelChart1.SetSourceData(dataRange1);
                    excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                    // Add a title to FamilyInsideParish_Chart
                    excelChart1.HasTitle = true;
                    excelChart1.ChartTitle.Text = "عدد الأفراد وفقاً للعمل";
                }
        }

        public void LoadPersonWorkPositionChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonWorkPositionData> dataList = executor.GetPersonWorkPositionData(condition, conditionPerson, numberType);
            PersonWorkPosition_Chart.ChartAreas.Clear();
            PersonWorkPosition_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد الأفراد";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "نوع العامل";
                //chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonWorkPosition_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("Work");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Column;

                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonWorkPosition_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonWorkPosition_Chart.Series["Work"].Points.AddXY(dataList[i].workingPosition, dataList[i].Count);
                }

                // Add table headers
                worksheet.Cells[1, 5] = "نوع العامل";
                worksheet.Cells[1, 6] = "العدد";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 5] = dataList[i].workingPosition;
                    worksheet.Cells[i + 2, 6] = dataList[i].Count;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["E1", "F4"];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(1200, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد الأفراد وفقاً لطبيعة العامل";
            }
        }

        public void LoadPersonTopWorkNameChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonWorkNameData> dataList = executor.GetPersonWorkNameData(condition, conditionPerson, numberType);
            PersonTopWorkName_Chart.ChartAreas.Clear();
            PersonTopWorkName_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد الأفراد";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "المهنة";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonTopWorkName_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("Work");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Column;

                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonTopWorkName_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonTopWorkName_Chart.Series["Work"].Points.AddXY(dataList[i].WorkName, dataList[i].MemberCount);
                }

                // Add table headers
                worksheet.Cells[1, 8] = "المهنة";
                worksheet.Cells[1, 9] = "العدد";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 8] = dataList[i].WorkName;
                    worksheet.Cells[i + 2, 9] = dataList[i].MemberCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["H1", "I" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(1700, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد الأفراد وفقاً للمهنة";
            }
        }

        public void LoadPersonMPAidSourceChart()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonMPAIDSourceData> dataList = executor.GetPersonMPAidSourceData(condition, conditionPerson, numberType);
            PersonMPAidSource_Chart.ChartAreas.Clear();
            PersonMPAidSource_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد مرات المساعدة";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalFamilyCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "جهة المساعدة";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonMPAidSource_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("MPSource");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Column;

                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonMPAidSource_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonMPAidSource_Chart.Series["MPSource"].Points.AddXY(dataList[i].AidName, dataList[i].Count);
                }

                // Add table headers
                worksheet.Cells[1, 11] = "جهة المساعدة";
                worksheet.Cells[1, 12] = "عدد المرات";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 11] = dataList[i].AidName;
                    worksheet.Cells[i + 2, 12] = dataList[i].Count;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["K1", "L" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(2200, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد المساعدات وفقاً لجهات المساعدة";
            }
        }


        //Disease
        public void LoadPersonDiseaseCatChartData()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonDiseaseCatData> dataList = executor.GetPersonDiseaseCatData(condition, conditionPerson, numberType);
            PersonDiseaseCat_Chart.ChartAreas.Clear();
            PersonDiseaseCat_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد المرضى";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "نوع المرض";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonDiseaseCat_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("DiseaseCategory");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Column;

                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonDiseaseCat_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonDiseaseCat_Chart.Series["DiseaseCategory"].Points.AddXY(dataList[i].DiseaseType, dataList[i].Count);
                }

                // Add table headers
                worksheet.Cells[1, 1] = "نوع المرض";
                worksheet.Cells[1, 2] = "عدد المرضى";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = dataList[i].DiseaseType;
                    worksheet.Cells[i + 2, 2] = dataList[i].Count;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["A1", "B" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(500, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد المساعدات وفقاً لجهات المساعدة";
            }
        }

        public void LoadPersonDiseaseNameChartData()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonDiseaseNameData> dataList = executor.GetPersonDiseaseNameData(condition, conditionPerson, numberType);
            PersonDiseaseName_Chart.ChartAreas.Clear();
            PersonDiseaseName_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد المرضى";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = " المرض";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonDiseaseName_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("DiseaseName");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Column;

                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonDiseaseName_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonDiseaseName_Chart.Series["DiseaseName"].Points.AddXY(dataList[i].DiseaseName, dataList[i].MemberCount);
                }

                // Add table headers
                worksheet.Cells[1, 4] = " المرض";
                worksheet.Cells[1, 5] = "عدد المرضى";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 4] = dataList[i].DiseaseName;
                    worksheet.Cells[i + 2, 5] = dataList[i].MemberCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["D1", "E" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(1000, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "اكثر 10 مهن شائعة";
            }
        }

        public void LoadPersonDiseaseAidChartData()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonDiseaseAidData> dataList = executor.GetPersonDiseaseAidData(condition, conditionPerson, numberType);
            PersonDiseaseAid_Chart.ChartAreas.Clear();
            PersonDiseaseAid_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد المساعدات";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = " المساعدة";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonDiseaseAid_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("DiseaseAid");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Column;

                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonDiseaseAid_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonDiseaseAid_Chart.Series["DiseaseAid"].Points.AddXY(dataList[i].AidName, dataList[i].MemberCount);
                }

                // Add table headers
                worksheet.Cells[1, 7] = " المرض";
                worksheet.Cells[1, 8] = "عدد المرضى";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 7] = dataList[i].AidName;
                    worksheet.Cells[i + 2, 8] = dataList[i].MemberCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["G1", "H" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(1500, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد المساعدات علب أدوية - مبلغ أدوية";
            }
        }

        //Migration
        public void LoadPersonMigrateYearChartData()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonMigrateYearData> dataList = executor.GetPersonMigrateYearData(condition, conditionPerson, numberType);
            PersonMigrateYear_Chart.ChartAreas.Clear();
            PersonMigrateYear_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد الأفراد";
                chartAreaFamily.AxisX.Title = "السنة";
                chartAreaFamily.AxisX.Interval = 1;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonMigrateYear_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("MigrationYear");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Line;
                Series.XValueType = ChartValueType.String; // X axis value type as string (for years)
                Series.YValueType = ChartValueType.Double;  // Y axis value type as integer (for counts)
                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonMigrateYear_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonMigrateYear_Chart.Series["MigrationYear"].Points.AddXY(dataList[i].Year, dataList[i].MemberCount);
                }

                // Add table headers
                worksheet.Cells[1, 1] = "السنة";
                worksheet.Cells[1, 2] = "عدد الأفراد";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = dataList[i].Year;
                    worksheet.Cells[i + 2, 2] = dataList[i].MemberCount;
                }
               
              
                //Excel.Range dataRange1 = worksheet.Range["A1", "B" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(300, 50, 600, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                //excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlLine;
                Excel.Range xValues = worksheet.get_Range("A2", "A21");  // X-Values
                Excel.Range yValues = worksheet.get_Range("B2", "B21");  // Y-Values
                Excel.Series series = (Excel.Series)excelChart1.SeriesCollection().NewSeries();
                series.XValues = xValues;
                series.Values = yValues;
                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "عدد الأفراد حسب سنوات الهجرة";
            }
        }

        public void LoadPersonMigrateCountryChartData()
        {
            MySQLQueryExecutor executor = new MySQLQueryExecutor();
            List<PersonMigrateCountryData> dataList = executor.GetPersonMigrateCountryData(condition, conditionPerson, numberType);
            PersonMigrateCountry_Chart.ChartAreas.Clear();
            PersonMigrateCountry_Chart.Series.Clear();
            if (dataList.Count != 0)
            {
                ChartArea chartAreaFamily = new ChartArea();

                // Set axis

                chartAreaFamily.AxisY.Title = "عدد الأفراد";
                chartAreaFamily.AxisY.Maximum = int.Parse(TotalMemberCount_Label.Text) + 1000; // Set the maximum value for the Y-axis
                chartAreaFamily.AxisX.Title = "البلد";
                chartAreaFamily.AxisX.Interval = .5;
                // Change the major grid line color
                chartAreaFamily.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;  // X-axis major grid lines
                chartAreaFamily.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis major grid lines

                // Optional: Change the minor grid line color (if minor grid lines are enabled)
                chartAreaFamily.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray; // X-axis minor grid lines
                chartAreaFamily.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray; // Y-axis minor grid lines


                // Optionally customize other axis properties
                chartAreaFamily.AxisX.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisY.TitleFont = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold);
                chartAreaFamily.AxisX.IsLabelAutoFit = false;
                chartAreaFamily.AxisX.LabelStyle.Font = new Font("Somar", 10);
                chartAreaFamily.AxisX.LabelStyle.Angle = -45; // Rotate X-axis labels if needed

                // Add ChartArea to the chart
                PersonMigrateCountry_Chart.ChartAreas.Add(chartAreaFamily);


                // Create and configure Series
                // Create Male and Female series
                Series Series = new Series("MigrationCountry");

                // Set both series to column type
                Series.ChartType = SeriesChartType.Column;

                Series.IsVisibleInLegend = false;
                Series.IsValueShownAsLabel = true;


                PersonMigrateCountry_Chart.Series.Add(Series);

                // Customize the appearance of the labels
                Series.LabelForeColor = System.Drawing.Color.Black; // Change label color if needed
                Series.LabelBackColor = System.Drawing.Color.White; // Change label color if needed
                Series.Font = new System.Drawing.Font("Somar", 10, System.Drawing.FontStyle.Bold); // Customize font

                // Add data points

                for (int i = 0; i < dataList.Count; i++)
                {
                    PersonMigrateCountry_Chart.Series["MigrationCountry"].Points.AddXY(dataList[i].CountryName, dataList[i].MemberCount);
                }

                // Add table headers
                worksheet.Cells[1, 4] = "البلد";
                worksheet.Cells[1, 5] = "عدد الأفراد";

                // Populate the worksheet with the data
                for (int i = 0; i < dataList.Count; i++)
                {
                    worksheet.Cells[i + 2, 4] = dataList[i].CountryName;
                    worksheet.Cells[i + 2, 5] = dataList[i].MemberCount;
                }
                // Create a range for the data
                Excel.Range dataRange1 = worksheet.Range["D1", "E" + (dataList.Count + 1).ToString()];
                // Add a chart to the worksheet for FamilyInsideParish_Chart (Column Chart)
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject1 = (Excel.ChartObject)xlCharts1.Add(1000, 50, 400, 300);
                Excel.Chart excelChart1 = chartObject1.Chart;
                excelChart1.SetSourceData(dataRange1);
                excelChart1.ChartType = Excel.XlChartType.xlColumnClustered;

                // Add a title to FamilyInsideParish_Chart
                excelChart1.HasTitle = true;
                excelChart1.ChartTitle.Text = "أكثر 10 دول هاجر إليها الأفراد";
            }
        }

        private void HideSubMenu(string menu)
        {
            if(menu == "Family")
            {
                if (panelFamilySubmenu.Visible == true)
                {
                    panelFamilySubmenu.Visible = false;
                    btnFamily.Text = "⯈ العائلة";
                }
                else
                {
                    panelFamilySubmenu.Visible = true;
                    btnFamily.Text = "⯆ العائلة";
                }
            }
            else
            {
                if (panelIndividualSubmenu.Visible == true)
                {
                    panelIndividualSubmenu.Visible = false;
                    btnPerson.Text = "⯈ الأفراد";
                }
                else
                {
                    panelIndividualSubmenu.Visible = true;
                    btnPerson.Text = "⯆ الأفراد";
                }
            }
        }

        private void ShowSubMenu(Panel subMenu, string menu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu(menu);
                subMenu.Visible = true;
            }
           else
            {
                HideSubMenu(menu);
                subMenu.Visible = false;
            }
               
        }

        private async void btnFamily_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[3].Height = 0;
            ShowSubMenu(panelFamilySubmenu,"Family");
            Excel_Button.Visible = false;
            Apply_Button.Visible = false;
        }

       

        private void btnFamilyGeneralInfo_Click(object sender, EventArgs e)
        {
            //HideSubMenu();
        }

        private async void btnFamilyPower_Click(object sender, EventArgs e)
        {
            //HideSubMenu();
            tableLayoutPanel1.RowStyles[3].Height = 0;
            Set_Controls();
            excelApp.Quit();
            CreateExcelFile();
            ShowLoader(true);

            // Load chart data based on selection (simulate loading time)
            await Task.Run(() => {
                LoadPowerInfoData();
                
            });
            // Hide loader
            ShowLoader(false);
            ShowTableLayoutPanel("PowerInfo_Panel", ContainerPanel);
            //PowerInfo_Panel.Visible = true;
        }

        private async void btnFamilyAid_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[3].Height = 0;
            Set_Controls();
            excelApp.Quit();
            CreateExcelFile();
            ShowLoader(true);
            label25.Visible = true;
            Aidtype_ComboBox.Visible = true;

            // Load chart data based on selection (simulate loading time)
            await Task.Run(() => {
                LoadAidInfoData();
            });
            // Hide loader
            ShowLoader(false);
            ShowTableLayoutPanel("AidInfo_Panel", ContainerPanel);
        }

        private void btnFamilyEarthquack_Click(object sender, EventArgs e)
        {
            //HideSubMenu();
        }

        private void Bind_ComboBoxes(bool KeepSelection)
        {
            string query = "";

            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            //select DISTINCT(`visit_name`) as 'name' , ROW_NUMBER() OVER(ORDER BY visit_name) AS 'id' FROM `family_visit` WHERE `visittype_id` = 3 and visit_name<> 'M&E - 0' GROUP by visit_name order by visit_name;
            query += "SELECT 'N/A' AS id, 'N/A' AS visit_name UNION ALL SELECT f.visit_name as 'name', (@i := @i + 1) AS 'id' " +
                        "FROM(SELECT DISTINCT(`visit_name`) FROM family_visit WHERE `visittype_id` = 3 and visit_name <> 'M&E - 0' GROUP BY family_visit.visit_name) as f,(SELECT @i:= 0) params;" +
                        "Select donor.name from donor;";
           

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);

            DataTable dt = new DataTable();
            da.Fill(dt); 
            DataTable dt0 = dt;
            Bind_ComboBox(Visit_ComboBox, dt0, KeepSelection);
            
            Program.MyFirstConn.Close();
        }

        private void Bind_ComboBox(ComboBox Combox_Name, DataTable dt, bool KeepSelection)
        {
            int SelectedValue = 0;

            if (Combox_Name.SelectedValue != null)
                SelectedValue = int.Parse(Combox_Name.SelectedValue.ToString());

            Combox_Name.DataSource = dt;
            Combox_Name.DisplayMember = "name";
            Combox_Name.ValueMember = "id";

            if (KeepSelection && SelectedValue != 0)
                Combox_Name.SelectedValue = SelectedValue;
            else
                Combox_Name.SelectedIndex = 0;

            Combox_Name.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            
        }
        
        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Religion_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Visit_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Donor_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void State_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private async void Statistics_Form_Load(object sender, EventArgs e)
        {
            try {
                c = new Categories();
                s = new Statistics();
                Bind_ComboBoxes(false);
                Bind_Other_ComboBoxes("Religion");
                Bind_Other_ComboBoxes("State");
                Bind_Other_ComboBoxes("NumType");
                Bind_Other_ComboBoxes("AidType");
                Bind_Person_ComboBox();

                // Start Excel and get Application object
                CreateExcelFile();
               
                tableLayoutPanel1.RowStyles[3].Height = 0;

               
                Set_Controls();
                Set_Charts_Controls();
                personFilterLayoutPanel.Visible = false;
                
                
                Check_Conditions(Religion_ComboBox.SelectedItem.ToString(), Visit_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedIndex, State_ComboBox.SelectedItem.ToString(),Aidtype_ComboBox.SelectedItem.ToString());
                Check_NumberType(NumType_ComboBox.SelectedItem.ToString());
                //// Display loader
                //ShowLoader(true);

                //// Load chart data based on selection (simulate loading time)
                //await Task.Run(() => {
                //    LoadGeneralInfoChartData();

                //});
                //// Hide loader
                ShowLoader(false);
                //ShowTableLayoutPanel("FamilyInfo_Panel", ContainerPanel);
                custimizeDesign();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        // Function to show/hide TableLayoutPanel based on its name
        private void ShowTableLayoutPanel(string panelName, Control container)
        {
            bool panelFound = false;

            // Iterate through all controls in the specified container
            foreach (Control control in container.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    if (tableLayoutPanel.Name == panelName)
                    {
                        tableLayoutPanel.Visible = true;
                        panelFound = true;
                    }
                    else
                    {
                        tableLayoutPanel.Visible = false;
                    }
                }
            }

            if (!panelFound)
            {
                MessageBox.Show($"TableLayoutPanel with name '{panelName}' not found in the specified container.", "Panel Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        


        private void CreateExcelFile()
        {
            excelApp = new Excel.Application();
            // Create a new workbook
            workbook = excelApp.Workbooks.Add();
            worksheet = workbook.Sheets[1];
        }

        private void Set_Controls()
        {
            Visit_ComboBox.SelectedIndex = 0;
            Donor_ComboBox.SelectedIndex = 0;
            State_ComboBox.SelectedIndex = 0;
            Religion_ComboBox.SelectedIndex = 0;
            NumType_ComboBox.SelectedIndex = 0;
            Aidtype_ComboBox.SelectedIndex = 0;
            Sex_ComboBox.SelectedIndex = 0;
            AgeRange_ComboBox.SelectedIndex = 0;
            PersonState_ComboBox.SelectedIndex = 0;
            PersonMaritalStatus_ComboBox.SelectedIndex = 0;
            Excel_Button.Visible = false;
            Apply_Button.Visible = false;
            foreach (Control control in ContainerPanel.Controls)
            {
                if (control is TableLayoutPanel tableLayoutPanel)
                {
                    tableLayoutPanel.Visible = false;
                }
            }
            label25.Visible = false;
            Aidtype_ComboBox.Visible = false;
            label43.Visible = false;
            label44.Visible = false;
            FromDate_ComboBox.Visible = false;
            ToDate_ComboBox.Visible = false;

        }
        public void Set_Charts_Controls()
        {
            // Clear any existing series
            FamilyInsideParish_Chart.Series.Clear();
            FamilyInsideParish_Chart.ChartAreas.Clear();
            MemberInsideFamily_Chart.Series.Clear();
            MemberInsideFamily_Chart.ChartAreas.Clear();
            LivingWith_Chart.Series.Clear();
            LivingWith_Chart.ChartAreas.Clear();

            HasAmperAid_Chart.Series.Clear();
            HasAmperAid_Chart.ChartAreas.Clear();
            HasAmper_Chart.Series.Clear();
            HasAmper_Chart.ChartAreas.Clear();
            HasBattery_Chart.Series.Clear();
            HasBattery_Chart.ChartAreas.Clear();
            HasSolarPower_Chart.Series.Clear();
            HasSolarPower_Chart.ChartAreas.Clear();
            HasElectricity_Chart.Series.Clear();
            HasElectricity_Chart.ChartAreas.Clear();
            AidSourceAmper_Chart.Series.Clear();
            AidSourceAmper_Chart.ChartAreas.Clear();
            AidSourceSolar_Chart.Series.Clear();
            AidSourceSolar_Chart.ChartAreas.Clear();

            AidName_Chart.Series.Clear();
            AidName_Chart.ChartAreas.Clear();
            AidSource_Chart.Series.Clear();
            AidSource_Chart.ChartAreas.Clear();

            PersonGender_Chart.Series.Clear();
            PersonGender_Chart.ChartAreas.Clear();
            PersonState_Chart.Series.Clear();
            PersonState_Chart.ChartAreas.Clear();
            PersonStateType_Chart.Series.Clear();
            PersonStateType_Chart.ChartAreas.Clear();

            PersonWork_Chart.Series.Clear();
            PersonWork_Chart.ChartAreas.Clear();
            PersonWorkPosition_Chart.Series.Clear();
            PersonWorkPosition_Chart.ChartAreas.Clear();
            PersonTopWorkName_Chart.Series.Clear();
            PersonTopWorkName_Chart.ChartAreas.Clear();
            PersonMPAidSource_Chart.Series.Clear();
            PersonMPAidSource_Chart.ChartAreas.Clear();

            PersonDiseaseCat_Chart.Series.Clear();
            PersonDiseaseCat_Chart.ChartAreas.Clear();
            PersonDiseaseName_Chart.Series.Clear();
            PersonDiseaseName_Chart.ChartAreas.Clear();
            PersonDiseaseAid_Chart.ChartAreas.Clear();
            PersonDiseaseAid_Chart.Series.Clear();

            PersonMigrateCountry_Chart.Series.Clear();
            PersonMigrateCountry_Chart.ChartAreas.Clear();
            PersonMigrateYear_Chart.Series.Clear();
            PersonMigrateYear_Chart.ChartAreas.Clear();

        }
        public void Check_NumberType(string numbertype)
        {
            numberType = numbertype;
        }

        public void Check_Conditions(string Religion, string Visit, int Donor , string State, string AidType)
        {
            condition = " where 1 ";
            conditionAid = "where 1";
            if (Religion != "N/A")
            {
                if(Religion == "مسيحي")
                    condition += " and family.parish_id <> 12 ";
                else condition += " and family.parish_id = 12 ";
            }
            if (Visit != "N/A")
            {
                condition += " and family_visit.visit_name like '" + Visit + "'";
            }
            if (Donor != 0)
            {
                condition += " and donor.id = '" + Donor + "'";
            }
            //Family State
            if (State != "N/A")
            {
                if(State == "فعالة")
                    condition += " and family_partner.IsActive = 1";
                else condition += " and family_partner.IsActive = 0";
            }
            if (AidType != "N/A")
            {
                if (AidType == "سلة غذائية")
                    conditionAid += " AND family_visitdetails.aidsource_11 <> 0 AND family_visitdetails.aidsource_11 IS NOT NULL ";
                else if (AidType == "طعام")
                    conditionAid += " and family_visitdetails.aidsource_20 <> 0 AND family_visitdetails.aidsource_20 IS NOT NULL ";
                else if (AidType == "رواتب مسنين")
                    conditionAid += " AND family_visitdetails.aidsource_19 <> 0 AND family_visitdetails.aidsource_19 IS NOT NULL ";
                else if (AidType == "منظفات")
                    conditionAid += " and family_visitdetails.aidsource_12 <> 0 AND family_visitdetails.aidsource_12 IS NOT NULL ";
                else if (AidType == "بدل محروقات")
                    conditionAid += " and family_visitdetails.aidsource_14 <> 0 AND family_visitdetails.aidsource_14 IS NOT NULL ";
                else if (AidType == "ترميم")
                    conditionAid += " and family_visitdetails.aidsource_17_home <> 0 AND family_visitdetails.aidsource_17_home IS NOT NULL ";
                else if (AidType == "مساعدة أصدقاء")
                    conditionAid += " and family_visitdetails.income_relation_id_12 <> 0 AND family_visitdetails.income_relation_id_12 IS NOT NULL ";
                if (Religion != "N/A")
                {
                    if (Religion == "مسيحي")
                        conditionAid += " and family.parish_id <> 12 ";
                    else conditionAid += " and family.parish_id = 12 ";
                }
                if (Visit != "N/A")
                {
                    conditionAid += " and family_visit.visit_name like '" + Visit + "' ";
                }
                if (Donor != 0)
                {
                    conditionAid += " and donor.id = '" + Donor + "' ";
                }
                //Family State
                if (State != "N/A")
                {
                    if (State == "فعالة")
                        conditionAid += " and family_partner.IsActive = 1 ";
                    else conditionAid += " and family_partner.IsActive = 0 ";
                }
            }
        }

        public void Check_PersonConditions(int State, int Sex, string Agerange, int Maritalstatus,string FromDate , string ToDate)
        {
            conditionPerson = "";
            if (State != 0)
            {
                conditionPerson += " and personstate.id = '"+ State + "' ";
            }
            if (Sex != 0)
            {
                conditionPerson += " and person.sex_id = '" + Sex + "'";
            }
            if (Agerange != "N/A")
            {
                if (Agerange != ">= 60")
                    conditionPerson += " and (YEAR(CURRENT_DATE) - YEAR(person.DOB)) between substring_index(" + Agerange + ", '-', 1) and substring_index(" + Agerange + ", '-', -1)";
                else conditionPerson += " and (YEAR(CURRENT_DATE) - YEAR(person.DOB)) " + Agerange;
            }
            //Family State
            if (Maritalstatus != 0)
            {
                conditionPerson += " and maritalstatus.id = '" + Maritalstatus + "' ";
            }
            if( (FromDate != "N/A") && (ToDate != "N/A"))
            {
                if (int.Parse(ToDate) >= int.Parse(FromDate))
                {
                    conditionPerson += " AND person_state.personstate_year between " + FromDate + " And " + ToDate + " ";
                }
                else
                {
                    MessageBox.Show("يجب أن يكون تاريخ البداية أصغر من تاريخ النهاية");
                    ToDate_ComboBox.SelectedIndex = 0;
                    FromDate_ComboBox.SelectedIndex = 0;
                }
                if (int.Parse(ToDate_ComboBox.Text) >= int.Parse(FromDate_ComboBox.Text))
                {
                    if (int.Parse(ToDate_ComboBox.Text) - int.Parse(FromDate_ComboBox.Text) > 20)
                    {
                        MessageBox.Show("ستقتصر نتائج البحث على قبل 20 سنة من تاريخ النهاية وذلك لسهولة العرض!!");
                    }
                }
            }
        }


        private void Bind_Other_ComboBoxes(string type)
        {
            if (type == "Religion")
            {
                Religion_ComboBox.Items.Add("N/A");
                Religion_ComboBox.Items.Add("مسيحي");
                Religion_ComboBox.Items.Add("مسلم");
            }
            else if (type == "State")
            {
                State_ComboBox.Items.Add("N/A");
                State_ComboBox.Items.Add("فعالة");
                State_ComboBox.Items.Add("غير فعالة");
            }
            else if(type == "AidType")
            {
                Aidtype_ComboBox.Items.Add("N/A");
                Aidtype_ComboBox.Items.Add("مساعدة أصدقاء");
                Aidtype_ComboBox.Items.Add("سلة غذائية");
                Aidtype_ComboBox.Items.Add("وجبات طعام");
                Aidtype_ComboBox.Items.Add("منظفات");
                Aidtype_ComboBox.Items.Add("رواتب مسنين");
                Aidtype_ComboBox.Items.Add("بدل محروقات");
                Aidtype_ComboBox.Items.Add("ترميم");
            }
            else if (type == "NumType")
            {
                NumType_ComboBox.Items.Add("COUNT");
                //NumType_ComboBox.Items.Add("AVG");
                //NumType_ComboBox.Items.Add("MIN");
                //NumType_ComboBox.Items.Add("MAX");
                //NumType_ComboBox.Items.Add("FLOUR");
                //NumType_ComboBox.Items.Add("CEIL");
            }
            //Religion_ComboBox.SelectedIndex = 0;
            //State_ComboBox.SelectedIndex = 0;
        }

        private void Bind_Person_ComboBox()
        {
            int SelectedDonorValue = 0;
            int SelectedSexValue = 0;
            int SelectedMaritalValue = 0;
            int SelectedPersonStateValue = 0;
            int SelectedAgeRangeValue = 0;
            int SelectedFromDateValue = 0;
            int SelectedToDateValue = 0;

            if (Donor_ComboBox.SelectedValue != null)
                SelectedDonorValue = int.Parse(Donor_ComboBox.SelectedValue.ToString());
            Donor_ComboBox.Items.Add("N/A");
            DataTable dt = c.Select_Table("donor_statis", "", false, false);
            Donor_ComboBox.DisplayMember = "name";
            Donor_ComboBox.ValueMember = "id";
            Donor_ComboBox.DataSource = dt;

            if (SelectedDonorValue != 0)
                Donor_ComboBox.SelectedValue = SelectedDonorValue;
            else
                Donor_ComboBox.SelectedIndex = 0;
            
            if (Sex_ComboBox.SelectedValue != null)
                SelectedSexValue = int.Parse(Sex_ComboBox.SelectedValue.ToString());
            DataTable dt1 = c.Select_Table("sex_statis", "", false, false);
            Sex_ComboBox.DisplayMember = "name";
            Sex_ComboBox.ValueMember = "id";
            Sex_ComboBox.DataSource = dt1;

            if (SelectedSexValue != 0)
                Sex_ComboBox.SelectedValue = SelectedSexValue;
            

            if (PersonMaritalStatus_ComboBox.SelectedValue != null)
                SelectedMaritalValue = int.Parse(PersonMaritalStatus_ComboBox.SelectedValue.ToString());
            DataTable dt2 = c.Select_Table("maritalstatus_statis", "", false, false);
            PersonMaritalStatus_ComboBox.DisplayMember = "name";
            PersonMaritalStatus_ComboBox.ValueMember = "id";
            PersonMaritalStatus_ComboBox.DataSource = dt2;

            if (SelectedMaritalValue != 0)
                PersonMaritalStatus_ComboBox.SelectedValue = SelectedMaritalValue;
            


            if (PersonState_ComboBox.SelectedValue != null)
                SelectedPersonStateValue = int.Parse(PersonState_ComboBox.SelectedValue.ToString());
            
            DataTable dt3 = c.Select_Table("personstate_statis", "", false, false);
            PersonState_ComboBox.DisplayMember = "name";
            PersonState_ComboBox.ValueMember = "id";
            PersonState_ComboBox.DataSource = dt3;

            if (SelectedPersonStateValue != 0)
                PersonState_ComboBox.SelectedValue = SelectedPersonStateValue;
            
            if (AgeRange_ComboBox.SelectedValue != null)
                SelectedAgeRangeValue = int.Parse(AgeRange_ComboBox.SelectedValue.ToString());

            DataTable dt4 = c.Select_Table("agerange_statis", "", false, false);
            AgeRange_ComboBox.DisplayMember = "name";
            AgeRange_ComboBox.ValueMember = "id";
            AgeRange_ComboBox.DataSource = dt4;

            if (SelectedAgeRangeValue != 0)
                AgeRange_ComboBox.SelectedValue = SelectedAgeRangeValue;
            FromDate_ComboBox.Items.Add("N/A");
            ToDate_ComboBox.Items.Add("N/A");

            if (FromDate_ComboBox.SelectedValue != null)
                SelectedFromDateValue = int.Parse(FromDate_ComboBox.SelectedValue.ToString());
            if (ToDate_ComboBox.SelectedValue != null)
                SelectedToDateValue = int.Parse(ToDate_ComboBox.SelectedValue.ToString());

            DataTable dt5 = c.Select_Table("migration_date", "", false, false);
            FromDate_ComboBox.DisplayMember = "name";
            FromDate_ComboBox.ValueMember = "id";
            FromDate_ComboBox.DataSource = dt5;

            DataTable dt6 = c.Select_Table("migration_date", "", false, false);
            ToDate_ComboBox.DisplayMember = "name";
            ToDate_ComboBox.ValueMember = "id";
            ToDate_ComboBox.DataSource = dt6;

            
            if (SelectedFromDateValue != 0)
                FromDate_ComboBox.SelectedValue = SelectedFromDateValue;

            if (SelectedToDateValue != 0)
                ToDate_ComboBox.SelectedValue = SelectedToDateValue;

        }

        private void Visit_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void Religion_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void ShowLoader(bool isVisible)
        {
            Loading_Panel.Visible = isVisible;
            //FamilyInfo_Panel.Visible = !isVisible;
            Apply_Button.Visible = !isVisible;
            Excel_Button.Visible = !isVisible;

        }

        private void Donor_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void State_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Excel_Button_Click(object sender, EventArgs e)
        {
            // Save the workbook
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Save Chart Data as Excel";
            saveFileDialog.FileName = "ChartData.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Data and chart exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Make Excel visible after saving the file
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            excelApp.Quit();
            //CreateExcelFile();
        }

        private async void Apply_Btn_Click(object sender, EventArgs e)
        {
            
            // Load chart data based on selection (simulate loading time)
            if (FamilyInfo_Panel.Visible)
            {
                // Display loader
                ShowLoader(true);
                await Task.Run(() => {
                    CreateExcelFile();
                    LoadGeneralInfoChartData();
                });
                // Hide loader
                ShowLoader(false);
                ShowTableLayoutPanel("FamilyInfo_Panel", ContainerPanel);
            }
            else if (PowerInfo_Panel.Visible)
            {
                // Display loader
                ShowLoader(true);
                await Task.Run(() => {
                    CreateExcelFile();
                    LoadPowerInfoData();
                });
                // Hide loader
                ShowLoader(false);
                ShowTableLayoutPanel("PowerInfo_Panel", ContainerPanel);
            }
            else if (AidInfo_Panel.Visible)
            {
                // Display loader
                ShowLoader(true);
                await Task.Run(() => {
                    CreateExcelFile();
                    LoadAidInfoData();
                });
                // Hide loader
                ShowLoader(false);
                ShowTableLayoutPanel("AidInfo_Panel", ContainerPanel);
            }
            else if (PersonInfo_Panel.Visible)
            {
                // Display loader
                ShowLoader(true);
                await Task.Run(() => {
                    CreateExcelFile();
                    LoadPersonGeneralInfoChartData();
                });
                // Hide loader
                ShowLoader(false);
                ShowTableLayoutPanel("PersonInfo_Panel", ContainerPanel);
            }
            else if (WorkInfo_Panel.Visible)
            {
                // Display loader
                ShowLoader(true);
                await Task.Run(() => {
                    CreateExcelFile();
                    LoadPersonWorkInfoChartData();
                });
                // Hide loader
                ShowLoader(false);
                ShowTableLayoutPanel("WorkInfo_Panel", ContainerPanel);
            }
            else if (DiseaseInfo_Panel.Visible)
            {
                // Display loader
                ShowLoader(true);
                await Task.Run(() => {
                    CreateExcelFile();
                    LoadPersonDiseaseInfoChartData();
                });
                // Hide loader
                ShowLoader(false);
                ShowTableLayoutPanel("DiseaseInfo_Panel", ContainerPanel);
            }
            else if (MigrateInfo_Panel.Visible)
            {
                // Display loader
                ShowLoader(true);
                await Task.Run(() => {
                    CreateExcelFile(); 
                    LoadPersonMigrationInfoChartData();
                });
                // Hide loader
                ShowLoader(false);
                ShowTableLayoutPanel("MigrateInfo_Panel", ContainerPanel);
            }


        }

        private void Apply_Btn_MouseEnter(object sender, EventArgs e)
        {
            //Export_Btn.BackgroundImage = F2F_Application.Properties.Resources.button2_1;
        }

        private void Apply_Btn_MouseLeave(object sender, EventArgs e)
        {
            //Export_Btn.BackgroundImage = F2F_Application.Properties.Resources.button2;
        }
        private void CloseExcelFile()
        {
            if (worksheet != null)
            {
                Marshal.ReleaseComObject(worksheet);
                worksheet = null;
            }

            if (workbook != null)
            {
                workbook.Close(false); // Close without saving changes
                Marshal.ReleaseComObject(workbook);
                workbook = null;
            }

            if (excelApp != null)
            {
                excelApp.Quit(); // Quit the Excel application
                Marshal.ReleaseComObject(excelApp);
                excelApp = null;
            }

            // Force garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

       

        private async void btnGeneralInfo_Click(object sender, EventArgs e)
        {
            Set_Controls();
            excelApp.Quit();
            CreateExcelFile();
            personFilterLayoutPanel.Visible = false;

            tableLayoutPanel1.RowStyles[3].Height = 0;
            ShowLoader(true);

            // Load chart data based on selection (simulate loading time)
            await Task.Run(() => {
                LoadGeneralInfoChartData();
            });
            // Hide loader
            ShowLoader(false);
            ShowTableLayoutPanel("FamilyInfo_Panel", ContainerPanel);
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelIndividualSubmenu, "Individual");
            personFilterLayoutPanel.Visible = true;
            tableLayoutPanel1.RowStyles[3].Height = 42;
            label25.Visible = false;
            Aidtype_ComboBox.Visible = false;
            Set_Controls();
            Excel_Button.Visible = false;
            Apply_Button.Visible = false;
        }

        private void Aidtype_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private async void btnPersonGeneralInfo_Click(object sender, EventArgs e)
        {
            Set_Controls();
            excelApp.Quit();
            CreateExcelFile();
            //personFilterLayoutPanel.Visible = true;

            tableLayoutPanel1.RowStyles[3].Height = 42;
            ShowLoader(true);

            // Load chart data based on selection (simulate loading time)
            await Task.Run(() => {
                LoadPersonGeneralInfoChartData();
            });
            // Hide loader
            ShowLoader(false);
            ShowTableLayoutPanel("PersonInfo_Panel", ContainerPanel);
        }

        private void PersonState_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Sex_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void AgeRange_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void PersonMaritalStatus_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private async void btnPersonWork_Click(object sender, EventArgs e)
        {
            Set_Controls();
            excelApp.Quit();
            CreateExcelFile();
            ShowLoader(true);
            tableLayoutPanel1.RowStyles[3].Height = 42;
            // Load chart data based on selection (simulate loading time)
            await Task.Run(() => {
                LoadPersonWorkInfoChartData();
            });
            // Hide loader
            ShowLoader(false);
            ShowTableLayoutPanel("WorkInfo_Panel", ContainerPanel);
        }

        private async void btnPersonMigration_Click(object sender, EventArgs e)
        {
            Set_Controls();
            excelApp.Quit();
            CreateExcelFile();
            //personFilterLayoutPanel.Visible = true;

            tableLayoutPanel1.RowStyles[3].Height = 42;
            ShowLoader(true);

            // Load chart data based on selection (simulate loading time)
            await Task.Run(() => {
                LoadPersonMigrationInfoChartData();
            });
            // Hide loader
            ShowTableLayoutPanel("MigrateInfo_Panel", ContainerPanel);
            
            label43.Visible = true;
            label44.Visible = true;
            FromDate_ComboBox.Visible = true;
            ToDate_ComboBox.Visible = true;
           
            ShowLoader(false);
        }

        private async void btnPersonHealth_Click(object sender, EventArgs e)
        {
            Set_Controls();
            excelApp.Quit();
            CreateExcelFile();
            ShowLoader(true);
            tableLayoutPanel1.RowStyles[3].Height = 42;
            // Load chart data based on selection (simulate loading time)
            await Task.Run(() => {
                LoadPersonDiseaseInfoChartData();
            });
            // Hide loader
            ShowLoader(false);
            ShowTableLayoutPanel("DiseaseInfo_Panel", ContainerPanel);
        }

        private void Aidtype_ComboBox_DrawItem_1(object sender, DrawItemEventArgs e)
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

        private void FromDate_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void ToDate_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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
