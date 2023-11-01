<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Desserts.aspx.cs" Inherits="Template_Project.Page4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Desserts</title>
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
                            window.location.href = "ContactUs.aspx"
                        }
                        else if (direction == "right") {
                            window.location.href = "Meats.aspx"
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
            background-image:url('https://static.vecteezy.com/system/resources/previews/011/062/537/original/dessert-food-background-free-vector.jpg'); background-attachment:fixed; background-size:cover;background-repeat:no-repeat
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
                <asp:LinkButton ID="lnkDesserts" runat="server" BackColor="#9900CC" BorderStyle="Groove" OnClick="lnkDesserts_Click">Desserts</asp:LinkButton>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton ID="lnkContactUs" runat="server" BackColor="Black" BorderStyle="Groove" OnClick="lnkContactUs_Click">Contact Us</asp:LinkButton>
            </div>
        </div>
        
        <div style="font-family:'Cascadia Mono'; color:white; background-color:black">
            <asp:GridView ID="grdDesserts" runat="server" Width="100%" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="nameOfFood" HeaderText="Name Of Food" />
                    <asp:BoundField DataField="weightOfFood" HeaderText="Weight Of Food" />
                    <asp:BoundField DataField="kiloCalories" HeaderText="Calories" />
                    <asp:BoundField DataField="picture" HeaderText="Picture" />
                    <asp:BoundField DataField="dessertsCalBtn" HeaderText="CALORIES TOTAL" />
                </Columns>
            </asp:GridView>
        </div>

        <br />

        <div style="margin-left:auto; margin-right:auto; text-align:center; font-family:'Cascadia Mono'; color:black; font-weight:bold">
            <asp:Label ID="lblCalTotal" runat="server" Text="Calories Total: 0"></asp:Label>
        </div>
        <div style="margin-left:auto; margin-right:auto; text-align:center; font-family:'Cascadia Mono'">
            <asp:Button ID="btnClearCal" runat="server" Text="Clear Calories Count" OnClick="btnClearCal_Click" BorderStyle ="Groove" BackColor ="Brown" />
        </div>

    </form>
</body>
</html>
