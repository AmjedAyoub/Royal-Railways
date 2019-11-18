using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Configuration;

namespace RRS
{
    static class Program
    {
        public static pic xpic;
        public static SqlConnection xsql;
        public static string xsrc;
        public static Form1 xf;
        public static Start xstart;
        public static Signup xsignup;
        public static Newemp xnewemp;
        public static Map xmap;
        public static Deleteemp xdelemp;
        public static Home xhome;
        public static Aboutus xabout;
        public static Customer xcust;
        public static Employee xemp;
        public static Admin xadm;
        public static Contactus xcontact;
        public static Guest xguest;
        public static Addtrain xaddtr;
        public static Deletetrain xdeltr;
        public static Addtrip xaddtrp;
        public static Viewtrip xvtrip;
        public static Canceltrip xctrp;
        public static Viewcustrip xcvt;
        public static Cusbook xbook;
        public static Form2 xf2;
        public static PrintOneWay xone;
        public static PrintReturn xtwo;
        public static Auttrip xconf;
        public static Msg xmsg;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            xsql=new System.Data.SqlClient.SqlConnection();
            xsql.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Amjad Ayoub\Desktop\RRS\RRS\Database1.mdf;Integrated Security=True;User Instance=True";//@" Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oweis\Desktop\RRS\RRS\Database1.mdf;Integrated Security=True;User Instance=True";
            xsrc = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Amjad Ayoub\Desktop\RRS\RRS\Database1.mdf;Integrated Security=True;User Instance=True";//@" Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\oweis\Desktop\RRS\RRS\Database1.mdf;Integrated Security=True;User Instance=True";
            xstart = new Start();
            xsignup = new Signup();
            xf = new Form1();
            xnewemp = new Newemp();
            xmap = new Map();
            xdelemp = new Deleteemp();
            xhome = new Home();
            xabout = new Aboutus();
            xcust = new Customer();
            xemp = new Employee();
            xadm = new Admin();
            xcontact = new Contactus();
            xguest = new Guest();
            xaddtr = new Addtrain();
            xdeltr = new Deletetrain();
            xaddtrp = new Addtrip();
            xvtrip = new Viewtrip();
            xctrp = new Canceltrip();
            xcvt = new Viewcustrip();
            xbook = new Cusbook();
            xf2 = new Form2();
            xone = new PrintOneWay();
            xtwo = new PrintReturn();
            xconf = new Auttrip();
            xmsg = new Msg();
            xpic = new pic();
            Application.Run(new Form1());
        }
    }
}
