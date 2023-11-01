<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Template_Project.Page5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/jquery.touchSwipe.min.js"></script>
    <script>
        $(function () {
            $("#form1").swipe(
                {
                    swipe: function (event, direction, distance, duration, fingerCount) {
                        if (direction == "left") {
                            window.location.href = "Fruits.aspx"
                        }
                        else if (direction == "right") {
                            window.location.href = "Desserts.aspx"
                        }
                    },
                    threshold: 100
                });
        });
    </script>
</head>


    <body>
    <style>
        body{
            background-image:url('https://silvermilecapital.com/wp-content/uploads/2022/12/cloud4c-company-contact-1Desktop.jpg'); background-attachment:fixed; background-size:cover;background-repeat:no-repeat;color:white
        }
        a:link{
            font-size:18px;
        }
        a:hover {
            opacity:0.8;
            font-size:20px;
            transition-duration:500ms;
        }


    </style>

    <form id="form1" runat="server" style="height:100vh; width:100vw">
        
        <div class ="row">            
            <div class="col-sm-2 offset-sm-1"  >
                <asp:LinkButton ID="lnkFruits" runat="server" BackColor="Black" BorderStyle="Groove" OnClick="lnkFruits_Click">Fruits</asp:LinkButton>            
            </div>
            <div class="col-sm-2">
                <asp:LinkButton ID="lnkVegetables" runat="server" BackColor="Black" BorderStyle="Groove" OnClick="lnkVegetables_Click">Vegetables</asp:LinkButton>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton ID="lnkMeats" runat="server" BackColor="Black" BorderStyle="Groove" OnClick="lnkMeats_Click">Meats</asp:LinkButton>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton ID="lnkDesserts" runat="server" BackColor="Black" BorderStyle="Groove" OnClick="lnkDesserts_Click">Desserts</asp:LinkButton>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton ID="lnkContactUs" runat="server" BackColor="#9900CC" BorderStyle="Groove" OnClick="lnkContactUs_Click">Contact Us</asp:LinkButton>
            </div>
        </div>

        <br/>

         <div class="row">
            <div class="col-sm-6">
                        <asp:Label ID="Label1" runat="server" Text="Enter your FIRST name:" style ="font-weight:bold"></asp:Label>
            </div>
            <div class="col-sm-6">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </div>             
         </div>
         <br/>
         <div class="row">
            <div class="col-sm-6">
                        <asp:Label ID="Label2" runat="server" Text="Enter your SURNAME:" style ="font-weight:bold"></asp:Label>
            </div>
            <div class="col-sm-6">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </div>
         </div>
         <br/>
         <div class="row">
            <div class="col-sm-6">
                        <asp:Label ID="Label3" runat="server" Text="Enter your email address:" style ="font-weight:bold"></asp:Label>
            </div>
            <div class="col-sm-6">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
         </div>
         <br/>
         <div class="row">
            <div class="col-sm-6">
                        <asp:Label ID="Label4" runat="server" Text="Enter a review:" style ="font-weight:bold"></asp:Label>
            </div>
            <div class="col-sm-6">
                        <asp:TextBox ID="txtComment" runat="server"></asp:TextBox>
            </div>
         </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                     <asp:Label ID="lblConfirmation" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                     <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" BorderStyle ="Groove" BackColor ="Yellow"/>
             </div>
        </div>
    </form>
</body>
</html>
