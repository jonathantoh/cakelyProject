<%@ Page Title="" Language="C#" MasterPageFile="~/baker.master" AutoEventWireup="true" CodeFile="makebidding.aspx.cs" Inherits="makebidding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <style>
        
.red{
    color:red;
    }
.form-area
{
    background-color: #FAFAFA;
	padding: 10px 40px 60px;
	margin: 10px 0px 60px;
	border: 1px solid GREY;
	}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
  <div class="page-header">
    <h1>Place a Bid on this Project</h1>      
  </div>
  <p>Please complete these steps before bidding on the project</p>      
  <p>Complete your profile</p>      
</div>
    <div class="container">
        	<div class="row">
      <div class="col-md-6 col-md-offset-3">
        <div class="well well-sm">
    <div class="form-area">  

            

        <br style="clear:both">
                    <h3 style="margin-bottom: 25px; text-align: center;">Bidding Details</h3>
        <br />
            <strong>Email</strong>
					<div class="input-group">
      
                      <asp:TextBox ID="tb_bakeremail" type="email" class="form-control" placeholder="Enter your email" required="required" runat="server"></asp:TextBox>


    </div><br />
            <strong>Bid Price</strong>
            
					<div class="input-group">
      <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                      <asp:TextBox ID="tb_budgetID" class="form-control" placeholder="Enter your bid amount here" type="number" required="required" runat="server"></asp:TextBox>


    </div>
            <br />
            <strong>This project will be delivered in</strong>
					<div class="input-group">
      
                      <asp:TextBox ID="tb_days" class="form-control" placeholder="Enter the number of days" type="number" required="required" runat="server"></asp:TextBox><span class="input-group-addon">Days</span>


    </div>
            <br />
                    <div class="form-group">
                        <strong>Describe your proposal</strong>
                       <asp:TextBox class="form-control" type="textarea" runat="server" ID="message" placeholder="What makes you the best candidate for this project?" TextMode="MultiLine" rows="10"/> 
                    </div>
            <asp:Button type="button" id="submit" name="submit" runat="server" Text="Place bid" class="btn btn-primary pull-right" OnClick="submit_Click" />

    </div>
</div>
</div>
                </div>
</div>

        <div class="container">
    
  <p><strong>Listing ID:</strong> <asp:Label ID="listingID" runat="server"></asp:Label></p>      
</div>
</asp:Content>

