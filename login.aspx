﻿<%@ Page Title="" Language="C#" MasterPageFile="~/cust.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="style/style.css />
    <meta charset="utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<title>Bootstrap Simple Login Form with Blue Background</title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
<style type="text/css">
	body {
		color: #fff;
		background: white;
        color: grey;
	}
	.form-control {
		min-height: 41px;
		background: #f2f2f2;
		box-shadow: none !important;
		border: transparent;
	}
	.form-control:focus {
		background: #e2e2e2;
	}
	.form-control, .btn {        
        border-radius: 2px;
    }
	.login-form {
		width: 350px;
		margin: 30px auto;
		text-align: center;
	}
	.login-form h2 {
        margin: 10px 0 25px;
    }
    .login-form form {
		color: #7a7a7a;
		border-radius: 3px;
    	margin-bottom: 15px;
        background: #fff;
        box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        padding: 30px;
    }
    .login-form .btn {        
        font-size: 16px;
        font-weight: bold;
		background: #3598dc;
		border: none;
        outline: none !important;
    }
	.login-form .btn:hover, .login-form .btn:focus {
		background: #2389cd;
	}
	.login-form a {
		color: grey;
		text-decoration: underline;
	}
	.login-form a:hover {
		text-decoration: none;
	}
	.login-form form a {
		color: #7a7a7a;
		text-decoration: none;
	}
	.login-form form a:hover {
		text-decoration: underline;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel runat="server" DefaultButton="btn_submit">
    <div class="login-form">
        <h2 class="text-center"><asp:Image ID="Image1" ImageUrl="images/boxwear-resize.png" Height="57px" Width="154px" runat="server" />
        </h2>   
        <div class="form-group has-error">
        	<asp:TextBox class="form-control" name="email" ID="txtusername" placeholder="Enter Email" runat="server"></asp:TextBox>
        </div>
		<div class="form-group">
            <asp:TextBox ID="txtpassword" name="password" placeholder="Enter Password" class="form-control" runat="server" TextMode="Password" required="required"></asp:TextBox>
        </div>        
        <div class="form-group">
            <asp:Button ID="btn_submit" CssClass="btn btn-primary" runat="server" Text="Sign In" OnClick="btn_submit_Click" />
        </div>
        <p><a href="#">Lost your Password?</a></p>
        <p class="text-center small">Don't have an account? <a href="registration.aspx">Sign up here!</a></p>
    </div>
        </asp:Panel>
</asp:Content>
