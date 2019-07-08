using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addListing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        int result = 0;
        string image = "";
        string category = "";

        decimal budget = decimal.Parse(budgetID.Text);

        if (FilePhoto.HasFile == true)
        {
            image = "Images\\" + FilePhoto.FileName;
        }


        string custEmail = Session["user"].ToString();

        Listings prod = new Listings(); //tb_ProductCat can change to ddl_ProdCat

        result = prod.ListingInsert(listingTitleID.Text, descID.Text, (FilePhoto.FileName).ToString(), budget, custEmail);

        if (result > 0)
        {
            string saveimg = Server.MapPath("") + "\\" + image;
            FilePhoto.SaveAs(saveimg);

            //loadProductInfo();
            //loadProduct();
            //clear1();

            Response.Write("<script> alert('Insert successful');</script>");
        }
        else { Response.Write("<script> alert('Insert NOT  succesful');</script>"); }
    }
}