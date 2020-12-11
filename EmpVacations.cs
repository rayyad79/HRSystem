using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
namespace HRSystem.Classes
{
    class EmpVacations
    {
        public String VacationID;
        public string VacationType;
        public String EmployeeID;
        public DateTime FromDate;
        public DateTime ToDate;
        public DateTime CreationDate;
    }


    class EmpVacationsClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "EmpVacations.XML";

        public String AddNewVacation(String Vacation_ID, String Vacation_Type, String Employee_ID, DateTime From_Date, DateTime To_Date)
        {
            if(Vacation_ID == "" ||  Vacation_Type  == "" ||  Employee_ID.ToString() == "" ||  From_Date.ToString() == "" || To_Date.ToString() == "")
            {
                return "You must fill all fields!" ;
            }
            int iResult = 0;
            String sResult = "";
            EmployeesClass oEmp = new EmployeesClass();

            decimal dVacBalance = oEmp.GetEmployeeVacationBalance(Employee_ID);

            if (dVacBalance <= 0)
            {
                return "Employee doesnt have vacation balance!";
            }

            try
            {
                DataTable dt = new DataTable("EmpVacations");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("VacationID");
                    dt.Columns.Add("VacationType");
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
                dr["VacationID"] = Vacation_ID;
                dr["VacationType"] = Vacation_Type;
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

        public EmpVacations[] GetEmployeeVacations(String Employee_ID = null, String Vacation_ID = null)
        {
            DataSet dsEmpVacationsData = new DataSet();
            DataRow[] dsEmpVacations = null;

            EmpVacations[] EmpVacationsList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsEmpVacationsData.ReadXml(DataBaseXMLFile);
                dsEmpVacations = dsEmpVacationsData.Tables[0].Select(" EmployeeID=" + Employee_ID);// + "  VacationID=" + Vacation_ID);
            }
            if (dsEmpVacations != null)
                if (dsEmpVacations.Length > 0)
                {
                    int NoofEmp = dsEmpVacations.Length;
                    EmpVacationsList = new EmpVacations[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        EmpVacationsList[i] = new EmpVacations();
                        EmpVacationsList[i].EmployeeID = dsEmpVacations[i]["DeductionID"].ToString();
                        EmpVacationsList[i].VacationID= dsEmpVacations[i]["DeductionDescription"].ToString();
                        EmpVacationsList[i].VacationType = dsEmpVacations[i]["VacationType"].ToString();
                        EmpVacationsList[i].FromDate = DateTime.Parse(dsEmpVacations[i]["DeductionID"].ToString());
                        EmpVacationsList[i].ToDate = DateTime.Parse(dsEmpVacations[i]["DeductionDescription"].ToString());
                        EmpVacationsList[i].CreationDate = DateTime.Parse(dsEmpVacations[i]["CreationDate"].ToString());

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



        public int DeleteDEmployeeVacation(String VacationID, String EmployeeID)
        {
            int iResult = 0;
            DataSet dsEmpVacations = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsEmpVacations.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsEmpVacations.Tables[0].Select(" VacationID=" + VacationID + " and EmployeeID = " + EmployeeID);
            if (DataRowList.Length > 0)
            {
                dsEmpVacations.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}

