using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace eksamen2018
{
    public class database
    {
        // kobler til databasen
        MySqlConnection con;

        public database()
        {
            con = new MySqlConnection("Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG");
        }
        public void Kjorsporring(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable Fylldataset(string sql)
        {
            // hele tilkobling til databasen, som sier at den skal selecte alt fra databasen og sjekke om det finnes et brukernavn og passord som
            // er det samme som t1 og t2 sin teks. t1 og t2 er tekstboksene til brukernavn og passord i logginn filen
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

        //returnid returnerer enkelt en id utifra en spørring
        public string returnid(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
           String id = cmd.ExecuteScalar().ToString();
            con.Close();

            return id;
        }

        //antallRader teller hvor mange rader som returneres utifra en spørring
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