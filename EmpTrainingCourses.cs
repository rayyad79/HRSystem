using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using System.Xml;

namespace HRSystem.Classes
{
    class EmpTrainingCourses
    {
        public String EmpTrainingID;
        public string TrainingCourseName;
        public String EmployeeID;
        public DateTime FromDate;
        public DateTime ToDate;
        public DateTime CreationDate;
    }

    class EmpTrainingCoursesClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "EmpTrainingCourses.XML";

        public String AddNewTrainingCourse(String EmpTraining_ID, String TrainingCourse_Name, String Employee_ID, DateTime From_Date, DateTime To_Date)
        {
            if(EmpTraining_ID == "" || TrainingCourse_Name == "" ||  Employee_ID == "" ||  From_Date.ToString()  == "" ||  To_Date.ToString() == "")
            {
                return "You must fill all fields!";
            }
            int iResult = 0;
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("EmpTrainingCourses");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("EmpTrainingID");
                    dt.Columns.Add("TrainingCourseName");
                    dt.Columns.Add("EmployeeID");
                    dt.Columns.Add("FromDate");
                    dt.Columns.Add("ToDate");
                    dt.Columns.Add("CreationDate");


                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["EmpTrainingID"] = EmpTraining_ID;
                dr["TrainingCourseName"] = TrainingCourse_Name;
                dr["EmployeeID"] = Employee_ID;
                dr["FromDate"] = From_Date;
                dr["ToDate"] = To_Date;
                dr["CreationDate"] = DateTime.Now.ToString();

                ds.Tables[0].Rows.Add(dr);
                ds.Tables[0].AcceptChanges();

                ds.WriteXml(DataBaseXMLFile);
                sResult = "Done Successfully";
            }
            catch (Exception ex) { sResult = ex.Message; }

            return sResult;
        }

        public EmpVacations[] GetEmployeeTrainingCourses(String Employee_ID = null, String TrainingCourse_ID = null)
        {
            DataSet dsEmpTrainingCoursesData = new DataSet();
            DataRow[] dsEmpTrainingCourses = null;

          


            EmpVacations[] EmpVacationsList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsEmpTrainingCoursesData.ReadXml(DataBaseXMLFile);
                dsEmpTrainingCourses = dsEmpTrainingCoursesData.Tables[0].Select(" EmployeeID=" + Employee_ID + "  TrainingCourseID=" + TrainingCourse_ID);

            }
            if (dsEmpTrainingCourses != null)
                if (dsEmpTrainingCourses.Length > 0)
                {
                    int NoofEmp = dsEmpTrainingCourses.Length;
                    EmpVacationsList = new EmpVacations[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        EmpVacationsList[i] = new EmpVacations();
                        EmpVacationsList[i].EmployeeID = dsEmpTrainingCourses[i]["DeductionID"].ToString();
                        EmpVacationsList[i].VacationID = dsEmpTrainingCourses[i]["DeductionDescription"].ToString();
                        EmpVacationsList[i].VacationType = dsEmpTrainingCourses[i]["VacationType"].ToString();
                        EmpVacationsList[i].FromDate = DateTime.Parse(dsEmpTrainingCourses[i]["DeductionID"].ToString());
                        EmpVacationsList[i].ToDate = DateTime.Parse(dsEmpTrainingCourses[i]["DeductionDescription"].ToString());
                        EmpVacationsList[i].CreationDate = DateTime.Parse(dsEmpTrainingCourses[i]["CreationDate"].ToString());

                    }
                }

            return EmpVacationsList;
        }



        public DataTable GetEmployeeVacations111(String EmployeeID = null, String FeildName = null)
        {
            DataSet dsDeductions = new DataSet();

            if (File.Exists(DataBaseXMLFile))
            {
                dsDeductions.ReadXml(DataBaseXMLFile);
            }
            DataTable dt = new DataTable();
            if (dsDeductions != null)
                if (dsDeductions.Tables.Count > 0)
                {
                    dt = dsDeductions.Tables[0];
                }
            return dt;
        }



        public int DeleteEmployeeTrainingCourse(String TrainingCourse_ID, String Employee_ID)
        {
            int iResult = 0;
            DataSet dsEmpTrainingCourses = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsEmpTrainingCourses.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsEmpTrainingCourses.Tables[0].Select(" TrainingCourseID=" + TrainingCourse_ID + "and  EmployeeID = " + Employee_ID);
            if (DataRowList.Length > 0)
            {
                dsEmpTrainingCourses.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}

