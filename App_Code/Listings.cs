using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Listings
/// </summary>
public class Listings
{
    private int _ListingID = 0;
    private string _ListingName = string.Empty;
    private string _ListingDesc = "";
    private string _ListingImage = "";
    private string _ListingStatus = "";
    private decimal _ListingBudget = 0.00m;
    private string _ListingCust = "";


    //listingbids
    private string _bakerEmail, _listingBidStatus, _listingBidDesc  = "";
    private int _listingBidID, _listingDaysToComplete = 0;
    private decimal _listingBidPrice = 0.00m;

    string connStr = ConfigurationManager.ConnectionStrings["cakelyDB"].ConnectionString;

    public Listings()
    {

    }

    public Listings(int prod_ID, string prod_Name, string prod_Desc, string prod_img, string status, decimal listingBidPrice, string custEmail)
    {
        this._ListingID = prod_ID;
        this._ListingName = prod_Name;
        this._ListingDesc = prod_Desc;
        this._ListingImage = prod_img;
        this._ListingStatus = status;
        this._ListingBudget = listingBidPrice;
        this._ListingCust = custEmail;



    }

    public Listings(int prod_ID, string prod_Name, decimal prod_Desc, string prod_img, string prod_Desc1, int prod_img1)
    {
        this._listingBidID = prod_ID;
        this._bakerEmail = prod_Name;
        this._listingBidPrice = prod_Desc;
        this._listingBidStatus = prod_img;
        this._listingBidDesc = prod_Desc1;
        this._listingDaysToComplete = prod_img1;

    }

    public int Listing_ID
    {
        get { return _ListingID; }
        set { _ListingID = value; }
    }
    public string Listing_Name
    {
        get { return _ListingName; }
        set { _ListingName = value; }
    }
    public string Listing_Desc
    {
        get { return _ListingDesc; }
        set { _ListingDesc = value; }
    }
    public string Listing_Img
    {
        get { return _ListingImage; }
        set { _ListingImage = value; }
    }
    public string Listing_Status
    {
        get { return _ListingStatus; }
        set { _ListingStatus = value; }
    }
    public string Listing_Cust
    {
        get { return _ListingCust; }
        set { _ListingCust = value; }
    }

    public decimal listingBudget
    {
        get { return _ListingBudget; }
        set { _ListingBudget = value; }
    }
    //bids
    //private string _bakerEmail, _listingBidPrice, _listingBidStatus, _listingBidDesc, _listingDaysToComplete = "";
    //private int _listingBidID = 0;

    public int ListingBid_ID
    {
        get { return _listingBidID; }
        set { _listingBidID = value; }
    }
    public string BakerEmail
    {
        get { return _bakerEmail; }
        set { _bakerEmail = value; }
    }
    public decimal ListingBidPrice
    {
        get { return _listingBidPrice; }
        set { _listingBidPrice = value; }
    }
    public string ListingBidStatus
    {
        get { return _listingBidStatus; }
        set { _listingBidStatus = value; }
    }

    public string ListingBidDesc
    {
        get { return _listingBidDesc; }
        set { _listingBidDesc = value; }
    }
    public int ListingDaysToComplete
    {
        get { return _listingDaysToComplete; }
        set { _listingDaysToComplete = value; }
    }



    public Listings getProduct(string prodID)
    {
        Listings prodDetail = null;


        string prod_Name, prod_Desc, prod_Image, status, custEmail;
        int listID = 0;
        decimal listingBudgett = 0.00m;

        string queryStr = "SELECT * FROM listing WHERE listingID = @listingID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@listingID", prodID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();


        //Check if there are any resultsets
        if (dr.Read())
        {
            listID = int.Parse(dr["listingID"].ToString());
            prod_Name = dr["listingName"].ToString();
            prod_Desc = dr["listingDesc"].ToString();
            prod_Image = dr["listingImage"].ToString();
            status = dr["listingStatus"].ToString();
            custEmail = dr["custEmail"].ToString();

            listingBudgett = decimal.Parse(dr["listingBudget"].ToString());


            prodDetail = new Listings(listID, prod_Name, prod_Desc, prod_Image, status, listingBudgett, custEmail); //Changes prod_Brand
        }
        else
        {
            prodDetail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return prodDetail;
    }

    public List<Listings> getProductMen()
    {
        List<Listings> prodList = new List<Listings>();


        string prod_Name, prod_Desc, prod_Image, status, custEmail;
        int prod_ID = 0;
        decimal listingBudgett = 0.00m;
        string queryStr = "SELECT * FROM listing ORDER BY listingID DESC";


        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();


        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            prod_ID = int.Parse(dr["listingID"].ToString());
            prod_Name = dr["listingName"].ToString();
            prod_Desc = dr["listingDesc"].ToString();
            prod_Image = dr["listingImage"].ToString();
            status = dr["listingStatus"].ToString();
            custEmail = dr["custEmail"].ToString();

            listingBudgett = decimal.Parse(dr["listingBudget"].ToString());
            //prod_Category = dr["OutfitCategory"].ToString();
            ////prod_Brand = dr["OutfitBrand"].ToString();
            //unit_Price = decimal.Parse(dr["OutfitPrice"].ToString());
            //stock_Level = dr["OutfitStatus"].ToString();
            //stock_Quantity = int.Parse(dr["OutfitQuantity"].ToString());
            //prod_Size = dr["OutfitSize"].ToString();

            Listings a = new Listings(prod_ID, prod_Name, prod_Desc, prod_Image, status, listingBudgett, custEmail); //Changes prod_Brand
            prodList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }

    public List<Listings> getProductAllByProductName(string productName)
    {
        List<Listings> prodList = new List<Listings>();


        string prod_Name, prod_Desc, prod_Image, status, custEmail;
        int prod_ID = 0;
        decimal listingBudgett = 0.00m;
        string queryStr = "SELECT * FROM listing WHERE listingName LIKE '" + productName + "%' ORDER BY listingID DESC";


        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();


        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            prod_ID = int.Parse(dr["listingID"].ToString());
            prod_Name = dr["listingName"].ToString();
            prod_Desc = dr["listingDesc"].ToString();
            prod_Image = dr["listingImage"].ToString();
            status = dr["listingStatus"].ToString();
            custEmail = dr["custEmail"].ToString();

            listingBudgett = decimal.Parse(dr["listingBudget"].ToString());
            //prod_Category = dr["OutfitCategory"].ToString();
            ////prod_Brand = dr["OutfitBrand"].ToString();
            //unit_Price = decimal.Parse(dr["OutfitPrice"].ToString());
            //stock_Level = dr["OutfitStatus"].ToString();
            //stock_Quantity = int.Parse(dr["OutfitQuantity"].ToString());
            //prod_Size = dr["OutfitSize"].ToString();

            Listings a = new Listings(prod_ID, prod_Name, prod_Desc, prod_Image, status, listingBudgett, custEmail); //Changes prod_Brand
            prodList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }

    public int ListingInsert(string listingName, string listingDesc, string img, decimal budget, string custEmail)
    {
        string msg = null;
        int result = 0;

        string queryStr = "INSERT INTO listing(listingName, listingDesc, listingImage, listingStatus, listingBudget, custEmail)" //follow DB table name
           + "values (@listingName, @listingDesc, @listingImage, @listingStatus, @listingBudget, @custEmail)"; //Can put own name

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        //cmd.Parameters.AddWithValue("@listingID", this.Listing_ID);
        cmd.Parameters.AddWithValue("@listingName", listingName);
        cmd.Parameters.AddWithValue("@listingDesc", listingDesc);
        cmd.Parameters.AddWithValue("@listingImage", "Images/" + img);
        cmd.Parameters.AddWithValue("@listingStatus", "Open");
        cmd.Parameters.AddWithValue("@custEmail", custEmail);

        cmd.Parameters.AddWithValue("@listingBudget", budget);
        //cmd.Parameters.AddWithValue("@listingBudget", budget);


        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();


        return result;
    } //end of insert

    //LISTING bids
    
    public List<Listings> getListingBids(string listingID)
    {
        List<Listings> prodList = new List<Listings>();


        string bakerEmail, listingBidStatus, listingBidDesc;
        int listingBidID = 0;
        decimal listingBidPrice = 0.00m;
        int listingDaysToComplete = 0;

        string queryStr = "SELECT * FROM listingBid WHERE listingID = '" + listingID + "'";


        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();


        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            listingBidID = int.Parse(dr["listingBidID"].ToString());
            bakerEmail = dr["bakerEmail"].ToString();
            listingBidPrice = decimal.Parse(dr["listingBidPrice"].ToString());
            listingBidStatus = dr["listingBidStatus"].ToString();
            listingBidDesc = dr["listingBidDesc"].ToString();
            listingDaysToComplete = int.Parse(dr["listingDaysToComplete"].ToString());


            //prod_Category = dr["OutfitCategory"].ToString();
            ////prod_Brand = dr["OutfitBrand"].ToString();
            //unit_Price = decimal.Parse(dr["OutfitPrice"].ToString());
            //stock_Level = dr["OutfitStatus"].ToString();
            //stock_Quantity = int.Parse(dr["OutfitQuantity"].ToString());
            //prod_Size = dr["OutfitSize"].ToString();

            Listings a = new Listings(listingBidID, bakerEmail, listingBidPrice, listingBidStatus, listingBidDesc, listingDaysToComplete); //Changes prod_Brand
            prodList.Add(a);
        }
        conn.Close();
        dr.Close();
        dr.Dispose();

        return prodList;
    }
}