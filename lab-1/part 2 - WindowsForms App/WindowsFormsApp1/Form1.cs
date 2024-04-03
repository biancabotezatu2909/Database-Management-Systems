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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter daArtists;
        SqlDataAdapter daArtworks;
        DataSet dset;
        BindingSource bsArtists;
        BindingSource bsArtworks;

        SqlCommandBuilder cmdBuilder;

        string queryArtist;
        string queryArtwork;
        public Form1()
        {
            InitializeComponent();
            this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            FillData();
            this.button.Click += new EventHandler(this.button_Click);
           
        }

        void FillData()
        {
            //Sql connection
            conn = new SqlConnection(getConnectionString());

            queryArtist = "SELECT* from Artists";
            queryArtwork = "SELECT* from Artworks";

            //Sql data adapters(for parent table and child table), DataSet
            daArtists = new SqlDataAdapter(queryArtist, conn);
            daArtworks = new SqlDataAdapter(queryArtwork, conn);
            dset = new DataSet();
            daArtists.Fill(dset, "Artists");
            daArtworks.Fill(dset, "Artworks");
            cmdBuilder = new SqlCommandBuilder(daArtworks);

            //Data relation (parent-child reletionship) added to the dset
            dset.Relations.Add("ArtistArtworks",
            dset.Tables["Artists"].Columns["artist_id"],
            dset.Tables["Artworks"].Columns["artist_id"]);

            //this.dataGridView3.DataSource = dset.Tables["Artists"];
            //this.dataGridView4.DataSource = this.dataGridView3.DataSource;
            //this.dataGridView4.DataMember = "ArtistArtworks";

            bsArtists = new BindingSource();
            bsArtists.DataSource = dset.Tables["Artists"];
            bsArtworks = new BindingSource(bsArtists, "ArtistArtworks");
            this.dataGridView3.DataSource = bsArtists;
            this.dataGridView4.DataSource = bsArtworks;
            cmdBuilder.GetUpdateCommand();

        }

        string getConnectionString()
        {
            return "Data Source=LAPTOP-CKSQK932;" + "Initial Catalog=Art Gallery;Integrated Security=true;";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button_Click(object sender, EventArgs e)
        {
            daArtworks.Update(dset, "Artworks");
        }
    }
}
