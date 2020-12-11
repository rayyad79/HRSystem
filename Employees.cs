using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using System.Configuration;

namespace HRSystem.Classes
{
    class Employee
    {
        public String EmployeeID;
        public String EmployeeName;
        public String DateofBirth;
        public String Department;
        public String Qualification;
        public String Major;
        public String Gender;
        public String Address;
        public String HireingDate;
        public String VacationYearlyBalance;
        public String Position;
        public String Evaluation;
        public String BasicSalary;
        public String Allowances;
        public String Deductions;
    }
    class EmployeesClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "Employee.XML";


        public String AddNewEmployee(String EmployeeID, String EmployeeName, String Gender, String BirthDate, String Address, String HireingDate, 
                                    String VacationYearlyBalance, String Position, String Department, String Qualification, String Major, String Evaluation, 
                                    string BasicSalary, String Allowances, String Dedctions)
        {

            if (EmployeeID == "" || EmployeeName == "" || Gender == "" || BirthDate == "" || Address == "" || HireingDate == "" ||
                VacationYearlyBalance == "" || Position == "" || Department == "" || Qualification == "" || Major == "" || Evaluation == "" ||
                                     BasicSalary == "" || Allowances == "" || Dedctions == "")
            {
                return "You must fill All Fields!";
            }
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("Employees");
                DataSet ds = new DataSet();
                
                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("Employee    ID");
                    dt.Columns.Add("EmployeeName");
                    dt.Columns.Add("DateofBirth");
                    dt.Columns.Add("Department");
                    dt.Columns.Add("Qualification");
                    dt.Columns.Add("Major");
                    dt.Columns.Add("Gender");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("HireingDate");
                    dt.Columns.Add("VacationYearlyBalance");
                    dt.Columns.Add("Position");
                    dt.Columns.Add("Evaluation");
                    dt.Columns.Add("BasicSalary");
                    dt.Columns.Add("Allowances");
                    dt.Columns.Add("Deductions");

                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["EmployeeID"] = EmployeeID;
                dr["EmployeeName"] = EmployeeName;
                dr["DateofBirth"] = BirthDate;
                dr["Department"] = Department;
                dr["Qualification"] = Qualification;
                dr["Major"] = Major;
                dr["Gender"] = Gender;
                dr["Address"] = Address;
                dr["HireingDate"] = HireingDate;
                dr["VacationYearlyBalance"] = VacationYearlyBalance;
                dr["Position"] = Position;
                dr["Evaluation"] = Evaluation;
                dr["BasicSalary"] = BasicSalary;
                dr["Allowances"] = Allowances;
                dr["Deductions"] = Dedctions;

                ds.Tables[0].Rows.Add(dr);
                ds.Tables[0].AcceptChanges();

                ds.WriteXml(DataBaseXMLFile);
                sResult = "Done Successfully";
            }
            catch (Exception ex) { sResult = ex.Message; }

            return sResult;
        }


        public Employee[] GetEmployees(String EmployeeID = null, String FeildName = null)
        {
            DataSet dsEmployees  = new DataSet();
          //  DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "Employee.XML";
            Employee[] empList   = null;
            if(File.Exists(DataBaseXMLFile))
            {
                dsEmployees.ReadXml(DataBaseXMLFile);
            }
            if(dsEmployees != null)
                if (dsEmployees.Tables.Count > 0)
                {
                    int NoofEmp = dsEmployees.Tables[0].Rows.Count;
                    empList = new Employee[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        empList[i] = new Employee();
                        empList[i].EmployeeID = dsEmployees.Tables[0].Rows[i]["EmployeeID"].ToString();
                        empList[i].EmployeeName = dsEmployees.Tables[0].Rows[i]["EmployeeName"].ToString();
                        empList[i].DateofBirth = dsEmployees.Tables[0].Rows[i]["DateofBirth"].ToString();
                        empList[i].Department = dsEmployees.Tables[0].Rows[i]["Department"].ToString();
                        empList[i].Qualification = dsEmployees.Tables[0].Rows[i]["Qualification"].ToString();
                        empList[i].Major = dsEmployees.Tables[0].Rows[i]["Major"].ToString();
                        empList[i].Gender = dsEmployees.Tables[0].Rows[i]["Gender"].ToString();
                        empList[i].Address = dsEmployees.Tables[0].Rows[i]["Address"].ToString();
                        empList[i].HireingDate = dsEmployees.Tables[0].Rows[i]["HireingDate"].ToString();
                        empList[i].VacationYearlyBalance = dsEmployees.Tables[0].Rows[i]["VacationYearlyBalance"].ToString();
                        empList[i].Position = dsEmployees.Tables[0].Rows[i]["Position"].ToString();
                        empList[i].Evaluation = dsEmployees.Tables[0].Rows[i]["Evaluation"].ToString();
                        empList[i].BasicSalary = dsEmployees.Tables[0].Rows[i]["BasicSalary"].ToString();
                        empList[i].Allowances = dsEmployees.Tables[0].Rows[i]["Allowances"].ToString();
                        empList[i].Deductions = dsEmployees.Tables[0].Rows[i]["Deductions"].ToString();
                    }
                }

            return empList;
        }



      /*  public DataTable dsGetEmployee(String EmployeeID = null, String FeildName = null)
        {
            DataSet dsEmployees = new DataSet();
            
            Employee[] empList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsEmployees.ReadXml(DataBaseXMLFile);
            }
            DataTable dt = new DataTable();
            if(dsEmployees != null)
                if (dsEmployees.Tables.Count > 0)
                {
                    dt = dsEmployees.Tables[0];
                }
            return dt;
        }

        */

        public int DeleteEmployee(String EmployeeID)
        {
            int iResult = 0;
            DataSet dsEmployees = new DataSet();
            
            
            if (File.Exists(DataBaseXMLFile))
            {
                dsEmployees.ReadXml(DataBaseXMLFile);
            }
            DataRow [] DataRowList = dsEmployees.Tables[0].Select(" EmployeeID=" + EmployeeID);
            if (DataRowList.Length > 0)
            {
                dsEmployees.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }

        public Decimal GetEmployeeVacationBalance(String EmployeeID = null, String FeildName = null)
        {
            DataSet dsEmployees = new DataSet();
            
            Decimal dBalance = 0;
            if (File.Exists(DataBaseXMLFile))
            {
                dsEmployees.ReadXml(DataBaseXMLFile);
            }
            if (dsEmployees != null)
            {
                DataRow[] DataRowList = dsEmployees.Tables[0].Select(" EmployeeID=" + EmployeeID);
                if (DataRowList.Length > 0)
                {
                    dBalance = Decimal.Parse(DataRowList[0]["VacationYearlyBalance"].ToString());
                }
            }

            return dBalance;
        }


        public Decimal GetNetSalaryAmount(String EmployeeID, Decimal Allownces , Decimal Deduction)
        {
            DataSet dsEmployees = new DataSet();
            
            Decimal dNetSalary = 0;
            if (File.Exists(DataBaseXMLFile))
            {
                dsEmployees.ReadXml(DataBaseXMLFile);
            }
            if (dsEmployees != null)
            {
                DataRow[] DataRowList = dsEmployees.Tables[0].Select(" EmployeeID=" + EmployeeID);
                if (DataRowList.Length > 0)
                {
                    dNetSalary = Decimal.Parse(DataRowList[0]["BasicSalary"].ToString()) + Decimal.Parse(DataRowList[0]["Allowances"].ToString()) - Decimal.Parse(DataRowList[0]["Deductions"].ToString()) + Allownces - Deduction;
                }
            }

            return dNetSalary;
        }


    }
}
