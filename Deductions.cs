using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;

namespace HRSystem.Classes
{
    class Deductions
    {
        public String DeductionID;
        public String EmployeeID;
        public String DeductionDescription;
        public DateTime CreationDate;
        public DateTime StartDate;
        public decimal Amount;
    }

    class DeductionsClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "Deductions.XML";

        public String AddNewDeduction(String Employee_ID, String Deduction_ID, String Deduction_Desc, String StartDate, String Amount)
        {
            int iResult = 0;
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("Deduction");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("EmployeeID");
                    dt.Columns.Add("DeductionID");
                    dt.Columns.Add("StartDate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("DeductionDescription");
                    dt.Columns.Add("CreationDate");


                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["EmployeeID"] = Employee_ID;
                dr["DeductionID"] = Deduction_ID;
                dr["DeductionDescription"] = Deduction_Desc;
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

        public Deductions[] GetDeductions(String Employee_ID = null, String FeildName = null)
        {
            DataSet dsDeductionData = new DataSet();
            DataRow[] dsDeduction = null;

            Deductions[] DeductionsList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsDeductionData.ReadXml(DataBaseXMLFile);
                dsDeduction = dsDeductionData.Tables[0].Select(" EmployeeID=" + Employee_ID);//+ "  DeductionID=" + Vacation_ID);
            }
            if (dsDeduction != null)
                if (dsDeduction.Length > 0)
                {
                    int NoofEmp = dsDeduction.Length;
                    DeductionsList = new Deductions[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        DeductionsList[i] = new Deductions();
                        DeductionsList[i].EmployeeID = dsDeduction[i]["EmployeeID"].ToString();
                        DeductionsList[i].DeductionID = dsDeduction[i]["DeductionID"].ToString();
                        DeductionsList[i].StartDate = DateTime.Parse(dsDeduction[i]["StartDate"].ToString());
                        DeductionsList[i].Amount = decimal.Parse(dsDeduction[i]["Amount"].ToString());
                        DeductionsList[i].DeductionDescription = dsDeduction[i]["DeductionsDescription"].ToString();
                        DeductionsList[i].CreationDate = DateTime.Parse(dsDeduction[i]["CreationDate"].ToString());

                    }
                }

            return DeductionsList;
        }



        public DataTable dsGetDeduction(String EmployeeID = null, String FeildName = null)
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



        public int DeleteDeduction(String Employee_ID, String Deduction_ID)
        {
            int iResult = 0;
            DataSet dsDeductions = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsDeductions.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsDeductions.Tables[0].Select(" EmployeeID = " + Employee_ID + " and DeductionID=" + Deduction_ID);
            if (DataRowList.Length > 0)
            {
                dsDeductions.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}
