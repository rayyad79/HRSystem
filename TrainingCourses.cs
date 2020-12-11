using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;


namespace HRSystem.Classes
{
    
    class TrainingCourses
    {
        public String TrainingCourseID;
        public String TrainingCourseDescription;
        public DateTime CreationDate;
    }

    class TrainingCoursesClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "TrainingCourses.XML";

        public String AddNewTrainingCourseType(String TrainingCourse_ID, String TrainingCourse_Desc)
        {
            int iResult = 0;
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("TrainingCourses");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("TrainingCourseID");
                    dt.Columns.Add("TrainingCourseDescription");
                    dt.Columns.Add("CreationDate");


                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["TrainingCourseID"] = TrainingCourse_ID;
                dr["TrainingCourseDescription"] = TrainingCourse_Desc;
                dr["CreationDate"] = DateTime.Now.ToString();

                ds.Tables[0].Rows.Add(dr);
                ds.Tables[0].AcceptChanges();

                ds.WriteXml(DataBaseXMLFile);
                sResult = "Done Successfully";
            }
            catch (Exception ex) { sResult = ex.Message; }

            return sResult;
        }

        public TrainingCourses[] GetTrainingCourseType(String TrainingCourseID = null, String FeildName = null)
        {
            DataSet dsDeduction = new DataSet();

            TrainingCourses[] DeductionList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsDeduction.ReadXml(DataBaseXMLFile);
            }
            if (dsDeduction != null)
                if (dsDeduction.Tables.Count > 0)
                {
                    int NoofEmp = dsDeduction.Tables[0].Rows.Count;
                    DeductionList = new TrainingCourses[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        DeductionList[i] = new TrainingCourses();
                        DeductionList[i].TrainingCourseID = dsDeduction.Tables[0].Rows[i]["TrainingCourseID"].ToString();
                        DeductionList[i].TrainingCourseDescription = dsDeduction.Tables[0].Rows[i]["TrainingCourseDescription"].ToString();
                        DeductionList[i].CreationDate = DateTime.Parse(dsDeduction.Tables[0].Rows[i]["CreationDate"].ToString());

                    }
                }

            return DeductionList;
        }



        public DataTable dsGetdsTrainingCoursesTypes(String TrainingCourseID = null, String FeildName = null)
        {
            DataSet dsTrainingCourses = new DataSet();

            if (File.Exists(DataBaseXMLFile))
            {
                dsTrainingCourses.ReadXml(DataBaseXMLFile);
            }
            DataTable dt = new DataTable();
            if (dsTrainingCourses != null)
                if (dsTrainingCourses.Tables.Count > 0)
                {
                    dt = dsTrainingCourses.Tables[0];
                }
            return dt;
        }



        public int DeletedsTrainingCourses(String dsTrainingCourse_ID)
        {
            int iResult = 0;
            DataSet dsdsTrainingCourse = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsdsTrainingCourse.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsdsTrainingCourse.Tables[0].Select(" DeductionID=" + dsTrainingCourse_ID);
            if (DataRowList.Length > 0)
            {
                dsdsTrainingCourse.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}



