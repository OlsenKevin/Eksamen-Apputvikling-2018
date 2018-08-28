using System;

using MySql.Data.MySqlClient;
using System.Data;


// fil for diverse metoder som kan brukers mot vår database.
namespace eksamen2018wf
{
    public class database
    {
      
        MySqlConnection con;

        // for å koble til database
        public database()
        {
            con = new MySqlConnection("Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG");
        }

        // for å kjøre spørring
        public void Kjorsporring(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // for å fylle et datasett
        public DataTable Fylldataset(string sql)
        {
       
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            return dt;

        }
        // for å returnere en id
        public string returnid(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            String id = cmd.ExecuteScalar().ToString();
            con.Close();

            return id;
        }
        // for å telle antall rader
        public int antallRader(string sql)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            return dt.Rows.Count;
        }



    }
}