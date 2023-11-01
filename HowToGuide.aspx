<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HowToGuide.aspx.cs" Inherits="Template_Project.UnusedPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How To Guide</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/jquery.touchSwipe.min.js"></script>
    <script>
        $(function () {
            $('#form1').swipe(
                {
                    tap: function () { },
                    doubleTap: function () {
                        window.location.href = "Fruits.aspx"
                    }
                }

            );
        });
    </script>
</head>
<body style="background-color:black">
    <form id="form1" runat="server" style="height:100vh; width:100vw">

        <div class ="jumbotron" style="background-color:rebeccapurple">
            <h1 style="text-align:center; font-family:'Berlin Sans FB'; color:white"><u>HOW TO USE THE APP</u></h1>
        </div>

        <br />
        <h3 style="text-align:center; color:red; font-family:'Berlin Sans FB'; color:white">How To Navigate</h3>
        <p style="text-align:center; color:white">
            Swipe left to go back on links.<br />
            Swipe right to go forward on links
        </p>

        <hr style="background-color:aliceblue"/>

        <br />
        <h3 style="text-align:center; color:red; font-family:'Berlin Sans FB'; color:white">How To Add/Clear Total Calories</h3>
        <p style="text-align:center; color:white">How To Add: Tap on "Fruits Calories" found in column 'CALORIES TOTAL'. <br />
            How To Clear: Tap on "Clear Calories Count" button to clear the total calories.
        </p>

        <hr style="background-color:aliceblue"/>

        <br />
        <h3 style="text-align:center; color:red; font-family:'Berlin Sans FB'; color:white">How To Contact Us</h3>
        <p style="text-align:center; color:white">
            Contact us at: "mr.kieranburns@gmail.com" <br />
            OR <br />
            Go To Contact Us Page(Final page) <br />
            Provide a Forename,
            Surname,
            Email Address and
            an App Review. <br />
        </p>

        <br />
        <br />
        <br />
        <br />

        <div class ="jumbotron" style="background-color:rebeccapurple">
            <h2 style="color:White; font-weight:bold; text-align:center; font-family:'Berlin Sans FB'"><u>DOUBLE TAP TO CONTINUE</u></h2>
        </div>

    </form>
</body>
</html>
