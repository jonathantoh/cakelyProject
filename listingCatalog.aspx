<%@ Page Title="" Language="C#" MasterPageFile="~/cust.master" AutoEventWireup="true" CodeFile="listingCatalog.aspx.cs" Inherits="listingCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .table {
    border-radius: 5px;
    width: 50%;
    margin: 0px auto;
    float: none;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%-- <strong>    <span class="auto-style3">Listings<br />
    </span>
    
    </strong>
    <table class="auto-style4">
            <tr>
                <td class="auto-style6">Listing Name:</td>
                <td>
                    <asp:TextBox ID="tb_Name" runat="server" CssClass="auto-style5"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style8">
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" style="height: 29px" Text="Search" />
                </td>
            </tr>
        </table>
    --%>
    
     <br />
     <br />




    <div class="container">
         <div class="row">
    <div class="col-md-6">
      <div class="input-group">
            <asp:TextBox ID="tb_Name" class="form-control"  runat="server" type="text" name="" placeholder="Search..."></asp:TextBox>
        <%--<input type="text" class="form-control" placeholder="Search" id="txtSearch"/>--%>
        <div class="input-group-btn">
            <asp:LinkButton ID="searchbtn" 
                runat="server" 
                CssClass="btn btn-primary"    
                OnClick="btnSearch_Click">
    <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
</asp:LinkButton>
            <%--<asp:Button ID="searchbtn" class="btn btn-primary"  OnClick="btnSearch_Click" runat="server" Text="Submit"></asp:Button>--%>

        </div>
      </div>
    </div>
     
    <a href="addListing.aspx" style="float:right" class="btn btn-primary btn-lg">Add listing</a>
        </div>
        </div> 
    <br />
    <div class="container">
         
  <div class="jumbotron">
    <h1>Listings</h1> 
    <p>Cakely is the most popular HTML, CSS, and JS framework for developing
    responsive, mobile-first projects on the web.</p> 
  </div>
</div>

<%--
<div class="container">
     <div class="row">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" CellPadding="5" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <div class="col-sm-4"><!--THUMBNAIL#2-->
            <table class="table table-bordered">
                <tr>
                    <td>
                     
                        <asp:ImageButton ID="img_Products" runat="server" ImageUrl='<%# Eval("Listing_Img") %>' onClick ="img_Products_Click" Height="215px" Width="246px"/>

                    </td>
                    
                </tr>
                <tr>
                    <td>
         
                        <strong><asp:Label ID="lbl_ProdName" runat="server" Text='<%# Eval("Listing_Name") %>'></asp:Label></strong>
                        <br />

                    
                           <asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("Listing_Desc") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>                        
                        <br />                       
                    </td>
                </tr>
            </table>
            <asp:Label ID="lbl_ProdID" runat="server" Text='<%# Eval("Listing_ID") %>'></asp:Label>
            <br />
           </div>

        </ItemTemplate> 
        <SeparatorTemplate >
                                                  <table width="5">
                                                       <tr>
                                                           <td>&nbsp;</td>
                                                       </tr>
                                                   </table>
                                                </SeparatorTemplate>  
    </asp:DataList>
    
    </div>
    </div>  --%>


    <div class="container">
        <div id="errormsg" runat="server" class="jumbotron">
    <p>No biddings found</p> 
  </div>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Flow"  OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <div class="col-md-4">
                  <div class="well dash-box"><!--THUMBNAIL#2-->
            
                     
                        <asp:ImageButton ID="img_Products" runat="server" ImageUrl='<%# Eval("Listing_Img") %>' onClick ="img_Products_Click" Height="215px" Width="246px"/>

                    
         <br />
                        <strong><asp:Label ID="lbl_ProdName" runat="server" Text='<%# Eval("Listing_Name") %>'></asp:Label></strong>
                      <span id="status_span" runat="server" style="padding:5px;font-size:30px;">
                      <asp:Label ID="lbl_status" runat="server" Text='<%# Eval("Listing_Status") %>'></asp:Label>
              </span>     
                        
                      <br />

                    
                           <strong>Budget $<asp:Label ID="lbl_budget" runat="server" Text='<%# Eval("listingBudget") %>'></asp:Label></strong>
                           <br /><asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("Listing_Desc") %>'></asp:Label>
                   

            <asp:Label ID="lbl_ProdID" runat="server" Text='<%# Eval("Listing_ID") %>'></asp:Label>
            <br />
           </div>
</div>
        </ItemTemplate> 
        
    </asp:DataList>

         </div>
</asp:Content>

