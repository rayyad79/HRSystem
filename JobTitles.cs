using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;

namespace HRSystem.Classes
{
    class JobTitles
    {
        public String JobTitleID;
        public String EmployeeID;
        public String EvauationDescription;
        public DateTime CreationDate;
        public DateTime StartDate;
        public decimal Amount;
    }


    class JobTitleClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "JobTitles.XML";

        public String AddNewJobTitle(String Employee_ID, String JobTitle_ID, String JobTitle_Desc, String StartDate, String Amount)
        {
            int iResult = 0;
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("JobTitles");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("EmployeeID");
                    dt.Columns.Add("JobTitleID");
                    dt.Columns.Add("StartDate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("JobTitleDescription");
                    dt.Columns.Add("CreationDate");


                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["EmployeeID"] = Employee_ID;
                dr["JobTitleID"] = JobTitle_ID;
                dr["JobTitleDescription"] = JobTitle_Desc;
                dr["CreationDate"] = DateTime.Now.ToString();
                dr["StartDate"] = DateTime.Parse(StartDate);
                dr["Amount"] = decimal.Parse(Amount);
                ds.Tables[0].Rows.Add(dr);
                ds.Tables[0].AcceptChanges();

                ds.WriteXml(DataBaseXMLFile);
                sResult = "Done Successfully";
            }
            catch (Exception ex) { sResult = ex.Message; }

            return sResult;
        }

        public JobTitles[] GetJobTitles(String Employee_ID = null, String FeildName = null)
        {
            DataSet dsAllowanceData = new DataSet();
            DataRow[] dsAllowance = null;

            JobTitles[] AllowancesList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsAllowanceData.ReadXml(DataBaseXMLFile);
                dsAllowance = dsAllowanceData.Tables[0].Select(" EmployeeID=" + Employee_ID);//+ "  AllowanceID=" + Vacation_ID);
            }
            if (dsAllowance != null)
                if (dsAllowance.Length > 0)
                {
                    int NoofEmp = dsAllowance.Length;
                    AllowancesList = new JobTitles[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        AllowancesList[i] = new JobTitles();
                        AllowancesList[i].EmployeeID = dsAllowance[i]["EmployeeID"].ToString();
                        AllowancesList[i].JobTitleID = dsAllowance[i]["JobTitleID"].ToString();
                        AllowancesList[i].StartDate = DateTime.Parse(dsAllowance[i]["StartDate"].ToString());
                        AllowancesList[i].Amount = decimal.Parse(dsAllowance[i]["Amount"].ToString());
                        AllowancesList[i].EvauationDescription = dsAllowance[i]["JobTitleDescription"].ToString();
                        AllowancesList[i].CreationDate = DateTime.Parse(dsAllowance[i]["CreationDate"].ToString());

                    }
                }

            return AllowancesList;
        }



        public DataTable dsGetJobTitle(String EmployeeID = null, String FeildName = null)
        {
            DataSet dsAllowances = new DataSet();

            if (File.Exists(DataBaseXMLFile))
            {
                dsAllowances.ReadXml(DataBaseXMLFile);
            }
            DataTable dt = new DataTable();
            if (dsAllowances != null)
                if (dsAllowances.Tables.Count > 0)
                {
                    dt = dsAllowances.Tables[0];
                }
            return dt;
        }



        public int DeleteJobTitle(String Employee_ID, String JobTitle_ID)
        {
            int iResult = 0;
            DataSet dsAllowances = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsAllowances.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsAllowances.Tables[0].Select(" EmployeeID = " + Employee_ID + " and JobTitleID=" + JobTitle_ID);
            if (DataRowList.Length > 0)
            {
                dsAllowances.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}
