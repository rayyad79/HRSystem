using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using System.Reflection;
using System.Reflection.Emit;


namespace HRSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EmployeeAllowances dEmpAllowances = new EmployeeAllowances();
            Type myType = (typeof(Classes.AllowancesClass));
            // Get the public methods.
            MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("\nThe number of public methods is {0}.", myArrayMethodInfo.Length);
            // Display all the methods.
            DisplayMethodInfo(myArrayMethodInfo, "1");
            // Get the nonpublic methods.
            MethodInfo[] myArrayMethodInfo1 = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("\nThe number of protected methods is {0}.", myArrayMethodInfo1.Length);
            // Display information for all methods.
            DisplayMethodInfo(myArrayMethodInfo1, "2");		

        }

        public static void DisplayMethodInfo(MethodInfo[] myArrayMethodInfo, String flag)
        {
            // Display information for all methods.
            for (int i = 0; i < myArrayMethodInfo.Length; i++)
            {
                MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
               // Console.WriteLine("\nThe name of the method is {0}.", myMethodInfo.Name);
                MessageBox.Show(myMethodInfo.Name + " ***** " + flag);
            }
        }

        void saveToXml()
        {
           // if(File.Exists())
        }

    }
}
