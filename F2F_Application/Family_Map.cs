using F2F_Application.Classes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
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
    public partial class Family_Map : Form
    {

        Family f;
        GMapOverlay markers;

        public Family_Map()
        {
            markers = new GMapOverlay("markers");
            f = new Family();


            InitializeComponent();
            initializaFamilyMap();
            AddFamilyMapMarkers();
            //FillFamilyStatistics();
        }

        private void initializaFamilyMap()
        {
            FamilyMap.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            FamilyMap.SetPositionByKeywords("Aleppo, Syria");
            FamilyMap.ShowCenter = false;
            FamilyMap.IgnoreMarkerOnMouseWheel = true;
            FamilyMap.MinZoom = 0;
            FamilyMap.MaxZoom = 24;
            FamilyMap.Zoom = 3;
            FamilyMap.MarkersEnabled = true;
            FamilyMap.DragButton = MouseButtons.Left;
        }

        private void AddFamilyMapMarkers()
        {
            try
            {
                DataSet ds = f.Get_Family_Locations();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["latitude"] != DBNull.Value && ds.Tables[0].Rows[i]["longitude"] != DBNull.Value && ds.Tables[0].Rows[i].Field<decimal>("latitude") != 0 && ds.Tables[0].Rows[i].Field<decimal>("longitude") != 0)
                    {
                        double latitude = ds.Tables[0].Rows[i].Field<decimal>("latitude") == null ? 0 : double.Parse(ds.Tables[0].Rows[i].Field<decimal>("latitude").ToString());
                        double longtitude = ds.Tables[0].Rows[i].Field<decimal>("longitude") == null ? 0 : double.Parse(ds.Tables[0].Rows[i].Field<decimal>("longitude").ToString());
                        string code = ds.Tables[0].Rows[i].Field<string>("code");

                        GMapMarker marker = new GMarkerGoogle(
                            new PointLatLng(latitude, longtitude),
                            GMarkerGoogleType.red_dot);
                        marker.ToolTip = new GMapRoundedToolTip(marker);
                        marker.ToolTipText = code;
                        markers.Markers.Add(marker);
                    }
                }
                FamilyMap.Overlays.Add(markers);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        //private void FillFamilyStatistics()
        //{
        //    DataSet ds = f.Get_Family_Statistics();
        //    disease.Text = ds.Tables[0].Rows[0].Field<string>("disease");
        //    foodavg.Text = ds.Tables[1].Rows[0].Field<string>("foodAvg");
        //    hometype.Text = ds.Tables[2].Rows[0].Field<string>("hometype");
        //    receiverage.Text = ds.Tables[3].Rows[0].Field<string>("receiverAge");
        //    workers.Text = ds.Tables[4].Rows[0].Field<string>("workers");
        //    students.Text = ds.Tables[5].Rows[0].Field<string>("students");
        //}


    }
}
