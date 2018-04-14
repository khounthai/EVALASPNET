<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageAjouter.aspx.cs" Inherits="EvalASPNET.WebForm.PagAjouter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ajouter un contact</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/css/bootstrap.min.css"
        asp-fallback-href="~/Ressources/Content/bootstrap.min.css"
        asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute" />
    <link rel="stylesheet" href="~/Ressources/Content/site.min.css" asp-append-version="true" />

</head>
<body>
    <div class="container" style="background: url('../Ressources/imgs/contact-bluewin.jpg') center center; background-size: cover;">

        <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                <br />
                <br />
                <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DefaultMode="Insert" OnItemInserting="FormView1_ItemInserting" Width="463px" OnPageIndexChanging="FormView1_PageIndexChanging">
                    <EditItemTemplate>
                        Civilite:
                     <asp:TextBox ID="CiviliteTextBox" runat="server" Text='<%# Bind("Civilite") %>' />
                        <br />
                        Nom:
                    <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                        <br />
                        Prenom:
                    <asp:TextBox ID="PrenomTextBox" runat="server" Text='<%# Bind("Prenom") %>' />
                        <br />
                        DateNaissance:
                    <asp:TextBox ID="DateNaissanceTextBox" runat="server" Text='<%# Bind("DateNaissance") %>' />
                        <br />
                        Adresse:
                    <asp:TextBox ID="AdresseTextBox" runat="server" Text='<%# Bind("Adresse") %>' />
                        <br />
                        CP:
                    <asp:TextBox ID="CPTextBox" runat="server" Text='<%# Bind("CP") %>' />
                        <br />
                        Ville:
                    <asp:TextBox ID="VilleTextBox" runat="server" Text='<%# Bind("Ville") %>' />
                        <br />
                        Pays:
                    <asp:TextBox ID="PaysTextBox" runat="server" Text='<%# Bind("Pays") %>' />
                        <br />
                        Telephone:
                    <asp:TextBox ID="TelephoneTextBox" runat="server" Text='<%# Bind("Telephone") %>' />
                        <br />
                        Portable:
                    <asp:TextBox ID="PortableTextBox" runat="server" Text='<%# Bind("Portable") %>' />
                        <br />
                        Email:
                    <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Civilite</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="CiviliteTextBox" runat="server" Text='<%# Bind("Civilite") %>' />
                                </div>
                            </div>
                        </div>
                        <%--                        Civilite:
                    <asp:TextBox ID="CiviliteTextBox" runat="server" Text='<%# Bind("Civilite") %>' /
                        <br />>--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Nom</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                                </div>
                            </div>
                        </div>

                        <%--       Nom:
                    <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                        <br />  --%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Prenom</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="PrenomTextBox" runat="server" Text='<%# Bind("Prenom") %>' />
                                </div>
                            </div>
                        </div>

                        <%--  Prenom:
                    <asp:TextBox ID="PrenomTextBox" runat="server" Text='<%# Bind("Prenom") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Date de naissance</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="DateNaissanceTextBox" runat="server" Text='<%# Bind("Prenom") %>' />
                                </div>
                            </div>
                        </div>
                        <%--   DateNaissance:
                    <asp:TextBox ID="DateNaissanceTextBox" runat="server" Text='<%# Bind("DateNaissance") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Adresse</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="AdresseTextBox" runat="server" Text='<%# Bind("Adresse") %>' />
                                </div>
                            </div>
                        </div>
                        <%--  Adresse:
                    <asp:TextBox ID="AdresseTextBox" runat="server" Text='<%# Bind("Adresse") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">CP</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="CPTextBox" runat="server" Text='<%# Bind("CP") %>' />
                                </div>
                            </div>
                        </div>
                        <%-- CP:
                    <asp:TextBox ID="CPTextBox" runat="server" Text='<%# Bind("CP") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Ville</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="VilleTextBox" runat="server" Text='<%# Bind("Ville") %>' />
                                </div>
                            </div>
                        </div>
                        <%--  Ville:
                    <asp:TextBox ID="VilleTextBox" runat="server" Text='<%# Bind("Ville") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Pays</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="PaysTextBox" runat="server" Text='<%# Bind("Pays") %>' />
                                </div>
                            </div>
                        </div>
                        <%--    Pays:
                  <asp:TextBox ID="PaysTextBox" runat="server" Text='<%# Bind("Pays") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Telephone</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="TelephoneTextBox" runat="server" Text='<%# Bind("Telephone") %>' />
                                </div>
                            </div>
                        </div>
                        <%-- Telephone:
                    <asp:TextBox ID="TelephoneTextBox" runat="server" Text='<%# Bind("Telephone") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Portable</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="PortableTextBox" runat="server" Text='<%# Bind("Portable") %>' />
                                </div>
                            </div>
                        </div>
                        <%--  Portable:
                    <asp:TextBox ID="PortableTextBox" runat="server" Text='<%# Bind("Portable") %>' />
                        <br />--%>
                        <div class="form-group">
                            <label class="col-xs-6 .col-md-4 control-label">Email</label>
                            <div class="col-xs-6 .col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                                </div>
                            </div>
                        </div>
                        <%-- Email:
                    <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        <br />--%>
                        <div class="form-group">
                            <asp:LinkButton class="col-xs-6 .col-md-4 control-label" ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insérer" ForeColor="Black" Font-Bold="true" />
                            <div class="col-xs-6 .col-md-4">
                                <asp:LinkButton class="col-xs-6 .col-md-4 control-label" ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" ForeColor="Black" Font-Bold="true" />
                            </div>
                        </div>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        Civilite:
                    <asp:Label ID="CiviliteLabel" runat="server" Text='<%# Bind("Civilite") %>' />
                        <br />
                        Nom:
                    <asp:Label ID="NomLabel" runat="server" Text='<%# Bind("Nom") %>' />
                        <br />
                        Prenom:
                    <asp:Label ID="PrenomLabel" runat="server" Text='<%# Bind("Prenom") %>' />
                        <br />
                        DateNaissance:
                    <asp:Label ID="DateNaissanceLabel" runat="server" Text='<%# Bind("DateNaissance") %>' />
                        <br />
                        Adresse:
                    <asp:Label ID="AdresseLabel" runat="server" Text='<%# Bind("Adresse") %>' />
                        <br />
                        CP:
                    <asp:Label ID="CPLabel" runat="server" Text='<%# Bind("CP") %>' />
                        <br />
                        Ville:
                    <asp:Label ID="VilleLabel" runat="server" Text='<%# Bind("Ville") %>' />
                        <br />
                        Pays:
                    <asp:Label ID="PaysLabel" runat="server" Text='<%# Bind("Pays") %>' />
                        <br />
                        Telephone:
                    <asp:Label ID="TelephoneLabel" runat="server" Text='<%# Bind("Telephone") %>' />
                        <br />
                        Portable:
                    <asp:Label ID="PortableLabel" runat="server" Text='<%# Bind("Portable") %>' />
                        <br />
                        Email:
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' />
                        <br />

                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ucontactConnectionString2 %>" SelectCommand="SELECT [Civilite], [Nom], [Prenom], [DateNaissance], [Adresse], [CP], [Ville], [Pays], [Telephone], [Portable], [Email] FROM [CONTACT] WHERE ([iduser] = @iduser)" InsertCommand="select 1+1">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="iduser" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:Button ID="Buttonretour" runat="server" OnClick="ButtonRetour_Click" Text="Retour" />
                <span style="display: inline-block; width: 100px;"></span>
                <asp:Button ID="ButtonDeconnexion" runat="server" Text="Déconnexion" OnClick="ButtonDeconnexion_Click" />
                <br />
            </div>
        </form>
    </div>
</body>
</html>
