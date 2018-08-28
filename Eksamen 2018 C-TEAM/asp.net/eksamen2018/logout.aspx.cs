using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eksamen2018
{
    public partial class logout : System.Web.UI.Page
    {
        //Enkel funksjon for å logge ut brukeren.
        protected void Page_Load(object sender, EventArgs e)    
        {
            Session.Clear();
            Response.Redirect("logginn.aspx");
        }
    }
}