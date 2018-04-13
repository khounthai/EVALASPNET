<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageAccueil.aspx.cs" Inherits="EvalASPNET.WebForm.PageAccueil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ucontact</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/css/bootstrap.min.css"
        asp-fallback-href="~/Ressources/Content/bootstrap.min.css"
        asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute" />
    <link rel="stylesheet" href="~/Ressources/Content/site.min.css" asp-append-version="true" />

</head>
<body>
    <div id="accueil">
        <div id="hello" class="container" style="background: url('../Ressources/imgs/contact-bluewin.jpg') center center; background-size: cover;">
            <div class="row">

                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <h1>U-CONTACT</h1>
                    <h2>Gardez le contact avec votre réseau !</h2>
                </div>
            </div>

            <div class="container main_content">

                <h1>Connexion</h1>
                <p class="instructions">Pour vous connecter et profiter des services U-Contact, remplissez le formulaire suivant :</p>

                <form id="form1" runat="server" class="form-horizontal">
                    <div class="form-group">
                        <label for="inputEmail" class="col-xs-12 col-sm-4 col-md-4 col-lg-4 control-label">Adresse email</label>
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                            <div class="input-group">
                                <span class="input-group-addon">@</span>
                                <asp:Label ID="Label1" runat="server" Text="Login">Email</asp:Label>
                                <asp:TextBox ID="TextBoxlogin" runat="server" Width="165px"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputPwd" class="col-xs-12 col-sm-4 col-md-4 col-lg-4 control-label">Mot de passe</label>
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                            <asp:Label ID="Label2" runat="server" Text="Mot de passe"></asp:Label>
                            <asp:TextBox ID="TextBoxMPD" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-xs-offset-12 col-xs-12 col-sm-offset-4 col-sm-6 col-md-offset-4 col-md-6 col-lg-offset-4 col-lg-6">
                            <asp:Button ID="Button1" runat="server" Text="Se connecter" OnClick="ButtonConnexion_Click" />
                        </div>
                    </div>
                </form>
            </div>



            <div id="presentation" class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <asp:Image ID="imageSmartphoneID" runat="server" ImageUrl="~/Ressources/imgs/iphone.png" title="Smartphone" />
                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <h3>Qu'est-ce que U-CONTACT ?</h3>
                        <p>
                            U-Contact, c'est l'annuaire de contacts qu'il vous faut pour gérer tous vos contacts.
					<br />
                            Ne perdez plus le contact avec les membres de votre famille, vos amis, vos collègues ou vos clients.
					<br />
                            Triez ou recherchez vos contacts facilement grâce à U-Contact !
                        </p>
                    </div>
                </div>
            </div>

        </div>


        <div id="contact" class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <h3>
                        <asp:HyperLink ID="contactezID" runat="server" title="Contactez-nous">Contactez-nous</asp:HyperLink>
                        <asp:HyperLink ID="contactezID2" runat="server" title="Contactez-nous">
						<span class="glyphicon glyphicon-envelope"></span>
                        </asp:HyperLink>
                    </h3>
                    <p>Une demande, une interrogation, un bug, n'hésitez pas, contactez-nous</p>

                </div>
            </div>
        </div>
    </div>

</body>
</html>
