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
    public partial class About : Page
    {
        DataSet ds;
        MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            // kobler til DB
            String cs = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            MySqlConnection dbconn = new MySqlConnection(cs);
            dbconn.Open();
            // henter ut alle felt fra gjestebok
            String sql = "select lag_id, lag_navn, lag_nr, turnering_id from lag";
            MySqlCommand cmd = new MySqlCommand(sql, dbconn);
            da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            ds = new DataSet("TEST");
            da.Fill(ds, "lag");
            Response.Write(ds.Tables["lag"].Rows.Count);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            // merk at GridView er bundet til ds
            // tilstand fungerer fordi data alltid lastes på nytt!
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}