using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConn;
        private DataSet dataSet;
        private SqlDataAdapter daParent, daChild;
        private BindingSource bsParent, bsChild;

        public Form1()
        {
            InitializeComponent();
            loadConfigFile();
        }

        private void loadConfigFile()
        {
            sqlConn = new SqlConnection(getConnectionString());
            dataSet = new DataSet();

            daParent = new SqlDataAdapter(getParentQuery(), sqlConn);
            SqlCommandBuilder cb = new SqlCommandBuilder(daParent);
            daParent.Fill(dataSet, getParentTable());

            daChild = new SqlDataAdapter(getChildQuery(), sqlConn);
            cb = new SqlCommandBuilder(daChild);
            daChild.Fill(dataSet, getChildTable());

            DataRelation drel = new DataRelation("fk_child_parent",
                dataSet.Tables[getParentTable()].Columns[getPKName()],
                dataSet.Tables[getChildTable()].Columns[getFKName()]);
            dataSet.Relations.Add(drel);

            // create bindings
            bsParent = new BindingSource();
            bsParent.DataSource = dataSet;
            bsParent.DataMember = getParentTable();

            bsChild = new BindingSource();
            bsChild.DataSource = bsParent;
            bsChild.DataMember = "fk_child_parent";

            // populate datagridviews
            parentView.DataSource = bsParent;
            childView.DataSource = bsChild;
        }

        private string getPKName()
        {
            return ConfigurationManager.AppSettings["parent_table_pk"];
        }

        private string getFKName()
        {
            return ConfigurationManager.AppSettings["child_table_fk"];
        }

        private string getParentTable()
        {
            return ConfigurationManager.AppSettings["parent_table"];
        }

        private string getParentQuery()
        {
            return ConfigurationManager.AppSettings["parent_query"];
        }

        private string getChildTable()
        {
            return ConfigurationManager.AppSettings["child_table"];
        }
        private string getChildQuery()
        {
            return ConfigurationManager.AppSettings["child_query"];
        }

        private void updateDb_Click(object sender, EventArgs e)
        {
            // save in the db
           // this.daParent.Update(this.dataSet, getParentTable());
           //try-catch
            this.daChild.Update(this.dataSet, getChildTable());
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString.ToString();
        }
    }
}
