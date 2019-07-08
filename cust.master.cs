using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cust : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            //Customer custDetails = null;
            //Customer cust = new Customer();
            string custEmail = Session["user"].ToString();
            //custDetails = cust.getUser(custEmail);
            welcome.Text = "Welcome, " + custEmail;

            lbtnLogout.Visible = true;
        }
        else if (Session["user"] == null)
        {
            lbtnLogout.Visible = false;
        }
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("user");
        Session.Remove("order");
        Response.Redirect("~/home.aspx");
    }
}
