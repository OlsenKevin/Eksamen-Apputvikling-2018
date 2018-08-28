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
    public partial class _event : System.Web.UI.Page
    {
        
        DataSet ds;
        MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            // kobler til DB
            String cs = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            MySqlConnection dbconn = new MySqlConnection(cs);
            dbconn.Open();
            // henter ut fra databasen
            String sql = "select event_id AS id, event_navn AS e_navn, host_navn as h_navn from event INNER JOIN host ON event.host_id = host.host_id";
            MySqlCommand cmd = new MySqlCommand(sql, dbconn);
            da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            ds = new DataSet("TESTE");
            da.Fill(ds, "event");

            String divcontent = "";

            //bruker foreach for å skrive ut alle eventene, et event pr rad i tabellen
            foreach (DataRow radevent in ds.Tables["event"].Rows)
            {
               divcontent += addevent(radevent);
            }
            //Skriver all HTML kode, som i addevent, til event.aspx som viser det på nettsiden
            eventoppsett.InnerHtml = divcontent;
        }

        //addevent skriver ut alle event på siden
        public string addevent(DataRow eventinfo)
        {
            String e_id = Convert.ToString(eventinfo["id"]);     
            String e_navn = Convert.ToString(eventinfo["e_navn"]);
            String h_navn = Convert.ToString(eventinfo["h_navn"]);

        String divdesign = @"<div class='col-md-4 col-xs-12 col-sm-6 search-result'>
		<div class='well well-lg'>

          <h3>" + e_navn + @"</h3>
          <p>
		  <ul class='meta-search'>
			      
                   <li> <h5> Arrangør: </h5>  <i class='fas fa-users'></i> <span>" + h_navn + @"</span></li>
			</ul>
		  </p>
          <a href='turnering.aspx?e_id="+e_id+ @"' class='btn btn-primary title='visturneringer'>Vis turnering</a>
              </div>
        </div>";

            return divdesign;
        }


    }
}