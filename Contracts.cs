using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;

namespace HRSystem.Classes
{
    class Contracts
    {
        public String ContractID;
        public String EmployeeID;
        public String ContractDescription;
        public DateTime CreationDate;
        public DateTime StartDate;
        public decimal Amount;
    }

    class ContractsClass
    {
        String DataBaseXMLFile = ConfigurationSettings.AppSettings["FilesLocation"] + "Contracts.XML";

        public String AddNewContract(String Employee_ID, String Contract_ID, String Contract_Desc, String StartDate, String Amount)
        {
            if (Employee_ID == "" || Contract_ID == "" || Contract_Desc == "" || StartDate == "" || Amount == "")
            {
                return "You must fill all fields!";
            }
            int iResult = 0;
            String sResult = "";

            try
            {
                DataTable dt = new DataTable("Contract");
                DataSet ds = new DataSet();

                if (!File.Exists(DataBaseXMLFile))
                {
                    dt.Columns.Add("EmployeeID");
                    dt.Columns.Add("ContractID");
                    dt.Columns.Add("StartDate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("ContractDescription");
                    dt.Columns.Add("CreationDate");


                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(DataBaseXMLFile);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr["EmployeeID"] = Employee_ID;
                dr["ContractID"] = Contract_ID;
                dr["ContractDescription"] = Contract_Desc;
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

        public Contracts[] GetContracts(String Employee_ID = null, String FeildName = null)
        {
            DataSet dsContractData = new DataSet();
            DataRow[] dsContract = null;

            Contracts[] ContractsList = null;
            if (File.Exists(DataBaseXMLFile))
            {
                dsContractData.ReadXml(DataBaseXMLFile);
                dsContract = dsContractData.Tables[0].Select(" EmployeeID=" + Employee_ID);//+ "  ContractID=" + Vacation_ID);
            }
            if (dsContract != null)
                if (dsContract.Length > 0)
                {
                    int NoofEmp = dsContract.Length;
                    ContractsList = new Contracts[NoofEmp];

                    for (int i = 0; i < NoofEmp; i++)
                    {
                        ContractsList[i] = new Contracts();
                        ContractsList[i].EmployeeID = dsContract[i]["EmployeeID"].ToString();
                        ContractsList[i].ContractID = dsContract[i]["ContractID"].ToString();
                        ContractsList[i].StartDate = DateTime.Parse(dsContract[i]["StartDate"].ToString());
                        ContractsList[i].Amount = decimal.Parse(dsContract[i]["Amount"].ToString());
                        ContractsList[i].ContractDescription = dsContract[i]["ContractsDescription"].ToString();
                        ContractsList[i].CreationDate = DateTime.Parse(dsContract[i]["CreationDate"].ToString());

                    }
                }

            return ContractsList;
        }



        public DataTable dsGetContract(String EmployeeID = null, String FeildName = null)
        {
            DataSet dsContracts = new DataSet();

            if (File.Exists(DataBaseXMLFile))
            {
                dsContracts.ReadXml(DataBaseXMLFile);
            }
            DataTable dt = new DataTable();
            if (dsContracts != null)
                if (dsContracts.Tables.Count > 0)
                {
                    dt = dsContracts.Tables[0];
                }
            return dt;
        }



        public int DeleteContract(String Employee_ID, String Contract_ID)
        {
            int iResult = 0;
            DataSet dsContracts = new DataSet();


            if (File.Exists(DataBaseXMLFile))
            {
                dsContracts.ReadXml(DataBaseXMLFile);
            }
            DataRow[] DataRowList = dsContracts.Tables[0].Select(" EmployeeID = " + Employee_ID + " and ContractID=" + Contract_ID);
            if (DataRowList.Length > 0)
            {
                dsContracts.Tables[0].Rows.Remove(DataRowList[0]);
                iResult = 1;
            }
            return iResult;
        }


    }
}
