<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1_4_gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="~/Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="GuessButton">
    <div>
        <h1>Gissa det hemliga talet</h1>
        <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100"></asp:Label>
        <asp:TextBox ID="userGuessBox" runat="server" TextMode="SingleLine"></asp:TextBox>

        <%-- Validering --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet får inte vara tomt" Text="*" Display="Dynamic" ControlToValidate="userGuessBox"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ange ett tal mellan 1 och 100" Type="Integer" MaximumValue="100" MinimumValue="1" ControlToValidate="userGuessBox" Text="*" Display="Dynamic"></asp:RangeValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        <%-- Gissa-knapp --%>
        <asp:Button ID="GuessButton" runat="server" Text="Gissa" OnClick="GuessButton_Click" />

        <%-- Här placeras de kontroller som inte skall vara synliga från start --%>
        <asp:PlaceHolder ID="LabelPlaceHolder" runat="server" Visible="false">
            <asp:Label ID="MadeGuessesLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="LastGuessLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="SecretNumberLabel" runat="server" Text=""></asp:Label>
        </asp:PlaceHolder>
        
        <asp:Button ID="newNumberButton" runat="server" Text="Nytt hemligt nummer" OnClick="newNumberButton_Click" Visible="False" CausesValidation="False" />

    </div>
    </form>
    <script src="Scripts/MyScript.js"></script>
</body>
</html>
