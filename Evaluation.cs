using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;

namespace HRSystem.Classes
{
    class Evaluations
    {
        public String EvaluationID;
        public String EmployeeID;
        public String EvauationDescription;
        public DateTime CreationDate;
        public DateTime StartDate;
        public decimal Amount;
    }


    class EvaluationClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "Evaluations.XML";

        public String AddNewEvaluation(String Employee_ID, String Evaluation_ID, String Evaluation_Desc, String StartDate, String Amount)
        {
            int iResult = 0;
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("Evaluations");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("EmployeeID");
                    dt.Columns.Add("EvaluationID");
                    dt.Columns.Add("StartDate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("EvaluationDescription");
                    dt.Columns.Add("CreationDate");


                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["EmployeeID"] = Employee_ID;
                dr["EvaluationID"] = Evaluation_ID;
                dr["EvaluationDescription"] = Evaluation_Desc;
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

        public Evaluations[] GetEvaluations(String Employee_ID = null, String FeildName = null)
        {
            DataSet dsAllowanceData = new DataSet();
            DataRow[] dsAllowance = null;

            Evaluations[] AllowancesList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsAllowanceData.ReadXml(DataBaseXMLFile);
                dsAllowance = dsAllowanceData.Tables[0].Select(" EmployeeID=" + Employee_ID);//+ "  AllowanceID=" + Vacation_ID);
            }
            if (dsAllowance != null)
                if (dsAllowance.Length > 0)
                {
                    int NoofEmp = dsAllowance.Length;
                    AllowancesList = new Evaluations[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        AllowancesList[i] = new Evaluations();
                        AllowancesList[i].EmployeeID = dsAllowance[i]["EmployeeID"].ToString();
                        AllowancesList[i].EvaluationID = dsAllowance[i]["EvaluationID"].ToString();
                        AllowancesList[i].StartDate = DateTime.Parse(dsAllowance[i]["StartDate"].ToString());
                        AllowancesList[i].Amount = decimal.Parse(dsAllowance[i]["Amount"].ToString());
                        AllowancesList[i].EvauationDescription = dsAllowance[i]["EvaluationDescription"].ToString();
                        AllowancesList[i].CreationDate = DateTime.Parse(dsAllowance[i]["CreationDate"].ToString());

                    }
                }

            return AllowancesList;
        }



        public DataTable dsGetEvaluation(String EmployeeID = null, String FeildName = null)
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



        public int DeleteEvaluation(String Employee_ID, String Evaluation_ID)
        {
            int iResult = 0;
            DataSet dsAllowances = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsAllowances.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsAllowances.Tables[0].Select(" EmployeeID = " + Employee_ID + " and EvaluationID=" + Evaluation_ID);
            if (DataRowList.Length > 0)
            {
                dsAllowances.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}
