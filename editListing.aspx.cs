using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class editListing : System.Web.UI.Page
{

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

    }

    protected void bind()
    {
        Listings aProd = new Listings();
        // Get Product ID from queryString 
        string prodID = Session["foo"].ToString();

        prod = aProd.getProduct(prodID);

        //Diplay product details on webform
        listingTitleID.Text = prod.Listing_Name;
        //lbl_price.Text = prod.Product_ID;
        descID.Text = prod.Listing_Desc;
        blah.ImageUrl = "" + prod.Listing_Img;
        budgetID.Text = (prod.listingBudget).ToString();
        //listingstatus_lbl.Text = prod.Listing_Status;
    }

    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        string prodID = Session["foo"].ToString();

        int result = 0;
        string image = "";
        string category = "";

        decimal budget = decimal.Parse(budgetID.Text);

        if (FilePhoto.HasFile == true)
        {
            image = "Images\\" + FilePhoto.FileName;
        }



        Listings prod = new Listings(); //tb_ProductCat can change to ddl_ProdCat

        result = updateListing(prodID, listingTitleID.Text, descID.Text, (FilePhoto.FileName).ToString(), budget);

        if (result > 0)
        {
            string saveimg = Server.MapPath("") + "\\" + image;
            FilePhoto.SaveAs(saveimg);

            //loadProductInfo();
            //loadProduct();
            //clear1();

            Response.Write("<script> alert('Update successful');</script>");
            Session.Remove("foo");

            Response.Redirect("listing.aspx?listID=" + prodID);

        }
        else { Response.Write("<script> alert('Update NOT  succesful');</script>"); }
    }

    public int updateListing(string listingID, string ListingTitle, string listingDesc, string file, decimal budget) //added Desc,Category, status and size
    {
        string queryStr = "UPDATE listing SET" +
        //" Product_ID = @productID, " +
        " listingName = @ListingTitle " +
        ", listingDesc = @listingDesc " +
        ", listingImage = @file " +
        ", listingBudget = @budget " +
        //" listingStatus = @listingStatus " +
        " WHERE listingID = @listingID";
        System.Data.SqlClient.SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        //cmd.Parameters.AddWithValue("@listingStatus", status);
        cmd.Parameters.AddWithValue("@listingID", listingID);
        cmd.Parameters.AddWithValue("@ListingTitle", ListingTitle);
        cmd.Parameters.AddWithValue("@listingDesc", listingDesc);
        cmd.Parameters.AddWithValue("@file", "Images/" + file);
        cmd.Parameters.AddWithValue("@budget", budget);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Update
}