<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 22: Shopping Cart</title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/Order.css" rel="stylesheet" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
    <form id="form1" runat="server">

        <label>Please select a product&nbsp;</label>
        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ProductId">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:HalloweenConnectionString %>' SelectCommand="SELECT [ProductId], [Name], [ShortDescription], [LongDescription], [ImageFile], [UnitPrice] FROM [Products] ORDER BY [Name]"></asp:SqlDataSource>
        
        <asp:UpdatePanel ID="upProducts" runat="server">
            <ContentTemplate>
                <div id="productData">   
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lblShortDescription" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lblLongDescription" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lblUnitPrice" runat="server" Text="Label"></asp:Label>
                    <label>Quantity&nbsp;</label>
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>               
                    <br />
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add to Cart" />
                    <asp:Button ID="btnCategory" runat="server" Text="Products By Category" PostBackUrl="~/Default.aspx" />
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label><br />
                </div>
                <asp:Image ID="imgProduct" runat="server" /> 
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    </section>        
</body>
</html>
