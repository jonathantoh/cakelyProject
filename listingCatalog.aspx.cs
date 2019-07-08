using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class listingCatalog : System.Web.UI.Page
{

    Listings prod = null;
    Listings aProd = new Listings();
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cakelyDB"].ToString());

    Listings prodItem = new Listings();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        string cmdstr = "Select * from listing";
        SqlCommand cmd = new SqlCommand(cmdstr, conn);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        conn.Open();
        adp.Fill(ds);


        List<Listings> prodList = new List<Listings>();

        prodList = prodItem.getProductMen();

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
            Label hf = (Label)item.FindControl("lbl_status");
            string hff = hf.Text;

            if (hff == "Open") // Checking file is null or not. 
            {
                Label btn = item.FindControl("lbl_status") as Label;

                if (btn != null)
                {
                    btn.Style.Add("outline", "1px solid green;");
                    btn.Style.Add("color", "green;");
                    btn.Style.Add("padding", "5px;");
                    btn.Style.Add("font-size", "20px;");


                }
            }
            else
            {
                Label btn = item.FindControl("lbl_status") as Label;

                if (btn != null)
                {
                    btn.Style.Add("outline", "1px solid red;");
                    btn.Style.Add("color", "red;");
                    btn.Style.Add("padding", "5px;");
                    btn.Style.Add("font-size", "20px;");


                }

            }
        }

    }


    //search function
    protected void bind2()
    {
        string txtName = tb_Name.Text;
        //string cmdstr = "Select * from Outfits";
        //SqlCommand cmd = new SqlCommand(cmdstr, conn);
        //SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //conn.Open();
        //adp.Fill(ds);


        List<Listings> prodList = new List<Listings>();

        prodList = prodItem.getProductAllByProductName(txtName);

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
            Label hf = (Label)item.FindControl("lbl_status");
            string hff = hf.Text;

            if (hff == "Open") // Checking file is null or not. 
            {
                Label btn = item.FindControl("lbl_status") as Label;

                if (btn != null)
                {
                    btn.Style.Add("outline", "1px solid green;");
                    btn.Style.Add("color", "green;");
                    btn.Style.Add("padding", "5px;");
                    btn.Style.Add("font-size", "20px;");


                }
            }
            else
            {
                Label btn = item.FindControl("lbl_status") as Label;

                if (btn != null)
                {
                    btn.Style.Add("outline", "1px solid red;");
                    btn.Style.Add("color", "red;");
                    btn.Style.Add("padding", "5px;");
                    btn.Style.Add("font-size", "20px;");


                }

            }
        }
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.SelectedIndex = e.Item.ItemIndex;
        bind();
        string prodID = ((Label)DataList1.SelectedItem.FindControl("lbl_ProdID")).Text;
        string queryString = "?listID=" + prodID;
        Response.Redirect("listing.aspx?listID=" + prodID);
    }

    protected void img_Products_Click(object sender, ImageClickEventArgs e)
    {



    }

    //search function
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bind2();
    }
}