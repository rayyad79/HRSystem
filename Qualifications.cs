﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;

namespace HRSystem.Classes
{
    class Qualifications
    {
        public String QualificationID;
        public String EmployeeID;
        public String EvauationDescription;
        public DateTime CreationDate;
        public DateTime StartDate;
        public decimal Amount;
    }


    class QualificationClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "Qualifications.XML";

        public String AddNewQualification(String Employee_ID, String Qualification_ID, String Qualification_Desc, String StartDate, String Amount)
        {
            int iResult = 0;
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("Qualifications");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("EmployeeID");
                    dt.Columns.Add("QualificationID");
                    dt.Columns.Add("StartDate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("QualificationDescription");
                    dt.Columns.Add("CreationDate");


                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["EmployeeID"] = Employee_ID;
                dr["QualificationID"] = Qualification_ID;
                dr["QualificationDescription"] = Qualification_Desc;
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

        public Qualifications[] GetQualifications(String Employee_ID = null, String FeildName = null)
        {
            DataSet dsAllowanceData = new DataSet();
            DataRow[] dsAllowance = null;

            Qualifications[] AllowancesList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsAllowanceData.ReadXml(DataBaseXMLFile);
                dsAllowance = dsAllowanceData.Tables[0].Select(" EmployeeID=" + Employee_ID);//+ "  AllowanceID=" + Vacation_ID);
            }
            if (dsAllowance != null)
                if (dsAllowance.Length > 0)
                {
                    int NoofEmp = dsAllowance.Length;
                    AllowancesList = new Qualifications[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        AllowancesList[i] = new Qualifications();
                        AllowancesList[i].EmployeeID = dsAllowance[i]["EmployeeID"].ToString();
                        AllowancesList[i].QualificationID = dsAllowance[i]["QualificationID"].ToString();
                        AllowancesList[i].StartDate = DateTime.Parse(dsAllowance[i]["StartDate"].ToString());
                        AllowancesList[i].Amount = decimal.Parse(dsAllowance[i]["Amount"].ToString());
                        AllowancesList[i].EvauationDescription = dsAllowance[i]["QualificationDescription"].ToString();
                        AllowancesList[i].CreationDate = DateTime.Parse(dsAllowance[i]["CreationDate"].ToString());

                    }
                }

            return AllowancesList;
        }



        public DataTable dsGetQualification(String EmployeeID = null, String FeildName = null)
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



        public int DeleteQualification(String Employee_ID, String Qualification_ID)
        {
            int iResult = 0;
            DataSet dsAllowances = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsAllowances.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsAllowances.Tables[0].Select(" EmployeeID = " + Employee_ID + " and QualificationID=" + Qualification_ID);
            if (DataRowList.Length > 0)
            {
                dsAllowances.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}
