using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class listing : System.Web.UI.Page
{
    decimal totalbp;
    Listings prod = null;
    Listings aProd = new Listings();
    Listings prodItem = new Listings();

    string connStr = ConfigurationManager.ConnectionStrings["cakelyDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bind();
        }

        // Store the value in invisible fields
        //lbl_Price.Text = prod.Product_Price.ToString();
        //lbl_stocks.Visible = false;

        //if ((lbl_Cat.Text == "Shirt") || (lbl_Cat.Text == "Pants"))
        //{
        //    DropDownList1.Visible = true;
        //    DropDownList2.Visible = false;
        //}
        //else
        //{
        //    DropDownList2.Visible = true;
        //    DropDownList1.Visible = false;
        //}

        //if (prod.Product_Quantity <= 0)
        //{
        //    lbl_stocks.Visible = true;
        //    Btn_Add.Visible = false;
        //}

    }

    protected void bind()
    {
        Listings aProd = new Listings();
        // Get Product ID from queryString 
        string prodID = Request.QueryString["listID"].ToString();
        prod = aProd.getProduct(prodID);

        //Diplay product details on webform
        lbl_listingname.Text = prod.Listing_Name;
        Label1.Text = prod.Listing_Name;
        //lbl_price.Text = prod.Product_ID;
        lbl_desc.Text = prod.Listing_Desc;
        img_Products.ImageUrl = "" + prod.Listing_Img;
        Image1.ImageUrl = "" + prod.Listing_Img;
        listingID.Text = prodID;
        lbl_price.Text = (prod.listingBudget).ToString();
        listingstatus_lbl.Text = prod.Listing_Status;
        custEmaillbl.Text = prod.Listing_Cust;

        if (listingstatus_lbl.Text == "Open")
        {
            status_span.Style.Add("outline", "1px solid green;");
            status_span.Style.Add("color", "green;");
        }else
        {
            status_span.Style.Add("outline", "1px solid red;");
            status_span.Style.Add("color", "red;");
            bid_btn.Visible = false;
        }



        List<Listings> prodList = new List<Listings>();

        prodList = prodItem.getListingBids(prodID);

        DataList1.DataSource = prodList;
        DataList1.DataBind();

        if (DataList1.Items.Count > 0)
        {
            errormsg.Visible = false;
            // your code
        }
        else
        {
            errormsg.Visible = true;
        }

        foreach (DataListItem item in DataList1.Items)
        {
            Label hf = (Label)item.FindControl("lbl_ProdID");
            string hff = hf.Text;

            //Label bidprice = (Label)item.FindControl("bidprice");
            //string bps = bidprice.Text;
            //decimal bp = Convert.ToDecimal(bps);

            int e = DataList1.Items.Count;

            //totalbp =+ bp;

            totalbp += Convert.ToDecimal(((Label)(item.FindControl("bidprice"))).Text);
            totalbp = totalbp / e;
            totalbp = Math.Round(totalbp, 2);
            Label2.Text = totalbp.ToString();
            Label3.Text = e.ToString();

            if (hff!="Pending") // Checking file is null or not. 
            {
                Button btn = item.FindControl("accept_btn") as Button;
                Button btn2 = item.FindControl("decline_btn") as Button;

                if (btn != null)
                {
                    btn.Visible = false;
                    btn2.Visible = false;
                }
            }
        }


    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //DataList1.SelectedIndex = e.Item.ItemIndex;
        //bind();
        //string prodID = ((Label)DataList1.SelectedItem.FindControl("Label2")).Text;
        //string queryString = "?listID=" + prodID;
        //Response.Redirect("listing.aspx?listID=" + prodID);
    }

    protected void bid_btn_Click(object sender, EventArgs e)
    {
        string prodID = Request.QueryString["listID"].ToString();
        string queryString = "?listID=" + prodID;
        Response.Redirect("makebidding.aspx?listID=" + prodID);
    }

    protected void accept_btn_Click(object sender, EventArgs e)
    {

        string prodID = Request.QueryString["listID"].ToString();
        string queryString = "?listID=" + prodID;

        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblId = (Label)item.FindControl("ListingBid_ID_lbl");
        string ID = lblId.Text;


        //string prodID = ((Label)DataList1.SelectedItem.FindControl("ListingBid_ID_lbl")).Text;
        int n = declineAllMethod(prodID, "Declined");


        int m = acceptDeclineMethod(ID, "Accepted");

        int p = closeBidding(prodID, "Close"); 

            
        Response.Redirect("listing.aspx?listID=" + prodID);

    }

    protected void decline_btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblId = (Label)item.FindControl("ListingBid_ID_lbl");
        string ID = lblId.Text;


        //string prodID = ((Label)DataList1.SelectedItem.FindControl("ListingBid_ID_lbl")).Text;

        int m = acceptDeclineMethod(ID, "Declined");

        string prodID = Request.QueryString["listID"].ToString();
        string queryString = "?listID=" + prodID;
        Response.Redirect("listing.aspx?listID=" + prodID);
    }

    public int acceptDeclineMethod(string listingBidID, string status) //added Desc,Category, status and size
    {
        string queryStr = "UPDATE listingBid SET" +
        //" Product_ID = @productID, " +
        " listingBidStatus = @listingBidStatus " +
        " WHERE listingBidID = @listingBidID";
        System.Data.SqlClient.SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@listingBidStatus", status);
        cmd.Parameters.AddWithValue("@listingBidID", listingBidID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Update


    public int declineAllMethod(string listingID, string status) //added Desc,Category, status and size
    {
        string queryStr = "UPDATE listingBid SET" +
        //" Product_ID = @productID, " +
        " listingBidStatus = @listingBidStatus " +
        " WHERE listingID = @listingID";
        System.Data.SqlClient.SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@listingBidStatus", status);
        cmd.Parameters.AddWithValue("@listingID", listingID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Update

    public int closeBidding(string listingID, string status) //added Desc,Category, status and size
    {
        string queryStr = "UPDATE listing SET" +
        //" Product_ID = @productID, " +
        " listingStatus = @listingStatus " +
        " WHERE listingID = @listingID";
        System.Data.SqlClient.SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@listingStatus", status);
        cmd.Parameters.AddWithValue("@listingID", listingID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Update

    protected void edit_btn_Click(object sender, EventArgs e)
    {
        string prodID = Request.QueryString["listID"].ToString();

        Session["foo"] = prodID;
        Response.Redirect("editListing.aspx");
    }
}