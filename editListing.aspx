<%@ Page Title="" Language="C#" MasterPageFile="~/cust.master" AutoEventWireup="true" CodeFile="editListing.aspx.cs" Inherits="editListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
<link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet">
<style>
* {
  box-sizing: border-box;
}

body {
  background-color: #f1f1f1;
}

#regForm {
  background-color: #ffffff;
  margin: 100px auto;
  font-family: Raleway;
  padding: 40px;
  width: 70%;
  min-width: 300px;
}

h1 {
  text-align: center;  
}

input {
  padding: 10px;
  width: 100%;
  font-size: 17px;
  font-family: Raleway;
  border: 1px solid #aaaaaa;
}

/* Mark input boxes that gets an error on validation: */
input.invalid {
  background-color: #ffdddd;
}

/* Hide all steps by default: */
.tab {
  display: none;
}

button {
  background-color: #4CAF50;
  color: #ffffff;
  border: none;
  padding: 10px 20px;
  font-size: 17px;
  font-family: Raleway;
  cursor: pointer;
}

button:hover {
  opacity: 0.8;
}

.btn_Insert1 {
  background-color: #4CAF50;
  color: #ffffff;
  border: none;
  padding: 10px 20px;
  font-size: 17px;
  font-family: Raleway;
  cursor: pointer;
}

.btn_Insert1:hover {
  opacity: 0.8;
}

#prevBtn {
  background-color: #bbbbbb;
}

/* Make circles that indicate the steps of the form: */
.step {
  height: 15px;
  width: 15px;
  margin: 0 2px;
  background-color: #bbbbbb;
  border: none;  
  border-radius: 50%;
  display: inline-block;
  opacity: 0.5;
}

.step.active {
  opacity: 1;
}

/* Mark the steps that are finished and valid: */
.step.finish {
  background-color: #4CAF50;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="regForm">
        <a href="listingCatalog.aspx" style="float:right" class="btn btn-primary btn-lg">View listing</a>
  <strong><h1>Edit Listing</h1></strong>
  <!-- One "tab" for each step in the form: -->
  <h2>STEP 1: Upload Photos</h2>
      <div class="row">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
          
				<div class="col-xs-8"><asp:FileUpload ID="FilePhoto" runat="server" CssClass="fileupload" onchange="readURL(this)" /><br /></div>
				<div class="col-xs-4">
                    <asp:Image id="blah" runat="server" width="50%" alt="your image" /></div>
			</div>  

     
    

    <h2>STEP 2: Choose a category</h2>
      <br />
       <p class="btn-group" data-toggle="buttons">
      <label class="btn btn-light">
        <input type="radio" name="options" id="option1"> Birthday
      </label>
      <label class="btn btn-light">
        <input type="radio" name="options" id="option2"> Wedding
      </label>
      <label class="btn btn-light">
        <input type="radio" name="options" id="option3"> Cupcake/Muffin
      </label>
</p>

    
<h2>STEP 3: Basic details</h2>
    <div class="form-group">
			<p><asp:TextBox ID="listingTitleID" class="form-control" placeholder="Listing Title" MaxLength='50' required="required" runat="server"></asp:TextBox></p>
			<p><asp:TextBox ID="descID" runat="server" placeholder="Describe your listing here..." class="form-control" rows="8" required="required" TextMode="MultiLine" />
                </p>
                <div class="input-group">
      <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                      <asp:TextBox ID="budgetID" class="form-control" placeholder="Budget" type="number" required="required" runat="server"></asp:TextBox>

    </div>
			    	
        </div>
  </div>
  <%--<div class="tab">Login Info:
    <p><input placeholder="Username..." oninput="this.className = ''" name="uname"></p>
    <p><input placeholder="Password..." oninput="this.className = ''" name="pword" type="password"></p>
  </div>--%>

        <div id="myDIV">
            <asp:Button ID="btn_Insert" Onclick="btn_Insert_Click" class="btn_Insert1" runat="server" Text="Save Details" />
        </div>


<script>

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#filePhoto").change(function () {
    readURL(this);
});


</script>
</asp:Content>

