<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageListeContacts.aspx.cs" Inherits="EvalASPNET.WebForm.PageListeContacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Liste contacts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/css/bootstrap.min.css"
        asp-fallback-href="~/Ressources/Content/bootstrap.min.css"
        asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute" />
    <link rel="stylesheet" href="~/Ressources/Content/site.min.css" asp-append-version="true" />
</head>

<body>

    <form id="form1" runat="server">

        <p id="lienAjouter"><a href="@{'/modifier-contact/0'}" title="Ajouter un contact"><span class="glyphicon glyphicon-plus-sign"></span>Ajouter un contact</a></p>

        <div class="table-responsive">
            <asp:GridView ID="GridViewListeContact" runat="server" class="table">
            
            </asp:GridView>
        </div>

        <asp:Image ID="img1" />
        <asp:Image ID="img2" />
    </form>
</body>
</html>
