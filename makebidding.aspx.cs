using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class makebidding : System.Web.UI.Page
{
    string connStr = ConfigurationManager.ConnectionStrings["cakelyDB"].ConnectionString;



    protected void Page_Load(object sender, EventArgs e)
    {
        string prodID = Request.QueryString["listID"].ToString();

        listingID.Text = prodID;
    }



    protected void submit_Click(object sender, EventArgs e)
    {
        insert();
        string prodID = Request.QueryString["listID"].ToString();

        Response.Redirect("listing.aspx?listID=" + prodID);
    }

    protected void insert()
    {
        string prodID = Request.QueryString["listID"].ToString();

        var convertDecimal = Convert.ToDecimal(tb_budgetID.Text);
        int result = 0;
        string queryStr = "INSERT INTO listingBid(bakerEmail, listingBidPrice, listingBidStatus, listingBidDesc, listingID, listingDaysToComplete)" //follow DB table name
           + "values (@bakerEmail, @listingBidPrice, @listingBidStatus, @listingBidDesc, @listingID, @listingDaysToComplete)"; //Can put own name

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        //cmd.Parameters.AddWithValue("@listingID", this.Listing_ID);
        cmd.Parameters.AddWithValue("@bakerEmail", tb_bakeremail.Text);
        cmd.Parameters.AddWithValue("@listingBidPrice", convertDecimal);
        cmd.Parameters.AddWithValue("@listingBidStatus", "Pending");
        cmd.Parameters.AddWithValue("@listingBidDesc", message.Text);
        cmd.Parameters.AddWithValue("@listingID", Convert.ToInt32(prodID));
        cmd.Parameters.AddWithValue("@listingDaysToComplete", Convert.ToInt32(tb_days.Text));

        //cmd.Parameters.AddWithValue("@listingBudget", budget);


        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();
    }
}