using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace db_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conString = "Data Source=LAPTOP-CKSQK932;" + "Initial Catalog=Art Gallery;Integrated Security=true;";
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            // Sql Command
            string str = "SELECT* FROM Artists";
            SqlCommand cmd = new SqlCommand(str, con);

            //Sql Data Reader
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}, {1}", reader[0], reader[1]);
                }
                con.Close();
            }

            //Sql Data Adapter, DataSet
            SqlDataAdapter daArtisti = new SqlDataAdapter(str, con);
            DataSet dset = new DataSet();
            // populate dset ffrom the data adapter
            daArtisti.Fill(dset, "Artists");
            foreach(DataRow pRow in dset.Tables["Artists"].Rows)
            {
                Console.WriteLine("{0}, {1}", pRow["artist_id"], pRow["artist_name"]);
            }

            //---------------------------------------
            // Sql Command
            string str2 = "SELECT* FROM Artworks";
            SqlCommand cmd2 = new SqlCommand(str2, con);

            //Sql Data Reader
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}, {1}", reader[0], reader[1]);
                }
                con.Close();
            }

            //Sql Data Adapter, DataSet
            SqlDataAdapter daArtworks = new SqlDataAdapter(str2, con);
            DataSet dset2 = new DataSet();
            // populate dset ffrom the data adapter
            daArtisti.Fill(dset2, "Artworks");
            foreach (DataRow pRow in dset2.Tables["Artworks"].Rows)
            {
                Console.WriteLine("{0}, {1}", pRow["artwork_id"], pRow["title"]);
            }
        }
    }
}
