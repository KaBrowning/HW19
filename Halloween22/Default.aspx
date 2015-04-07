<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Chapter 22: Ajax</title>
    <link href="Styles/Main.css" rel="stylesheet" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h1>View Our Products By Category</h1>    
    
        <div id="products">
            Choose a category:&nbsp;
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True"
                Width="130" DataSourceID="SqlDataSource1"
                DataTextField="LongName" DataValueField="CategoryId" OnSelectedIndexChanged="Reset">
                </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>"
                SelectCommand="SELECT [CategoryId], [LongName]
                               FROM [Categories] ORDER BY [LongName]">
            </asp:SqlDataSource>     
            <asp:Button ID="Button1" runat="server" Text="Clear" OnClick="Reset" />
            <asp:Button ID="Button2" runat="server" Text="Order Page" PostBackUrl="~/Order.aspx" /><br />      
           
            <asp:UpdatePanel ID="productsPanel" runat="server">
              <ContentTemplate>
                <asp:GridView ID="grdProducts" runat="server" DataSourceID="SqlDataSource2" DataKeyNames="ProductId" 
                    AutoGenerateColumns="false" OnSelectedIndexChanged="grdProducts_SelectedIndexChanged" Width="400">
                  <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="View" />
                    <asp:BoundField DataField="ProductId" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="OnHand" HeaderText="On Hand" />
                  </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>"
                    SelectCommand="SELECT [ProductId], [Name], [UnitPrice], [OnHand]
                                    FROM [Products] WHERE ([CategoryId] = @CategoryId)
                                    ORDER BY [ProductId]">
                  <SelectParameters>
                    <asp:ControlParameter Name="CategoryId" Type="String"
                        ControlID="ddlCategory" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
        
                <h2>Product Details</h2>
                <asp:DetailsView ID="dvwProduct" runat="server" AutoGenerateRows="False" DataKeyNames="ProductId" 
                    DataSourceID="SqlDataSource3" Width="400">
                  <Fields>
                    <asp:BoundField DataField="ProductId" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="OnHand" HeaderText="On Hand" />
                    <asp:BoundField DataField="ShortDescription" HeaderText="Short Description" />
                    <asp:BoundField DataField="LongDescription" HeaderText="Long Description" />
                    <asp:BoundField DataField="CategoryId" HeaderText="Category ID" />
                  </Fields>
                </asp:DetailsView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource3" 
                    ConnectionString='<%$ ConnectionStrings:HalloweenConnectionString %>' 
                    SelectCommand="SELECT [ProductId], [Name], [ShortDescription], [LongDescription], 
                                        [CategoryId], [UnitPrice], [OnHand] 
                                    FROM [Products] WHERE ([ProductId] = @ProductId)">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="grdProducts" PropertyName="SelectedValue" Name="ProductId" Type="String"></asp:ControlParameter>
                  </SelectParameters>
                </asp:SqlDataSource>
              </ContentTemplate>
              <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged" />
              </Triggers>
            </asp:UpdatePanel>
        </div>

        <div id="views">
            <h2>Most Viewed Products</h2>
            <asp:UpdatePanel ID="viewsPanel" runat="server">
              <ContentTemplate>
                <asp:GridView ID="grdViews" runat="server" AutoGenerateColumns="false" Width="250">
                  <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product" />
                    <asp:BoundField DataField="ViewCount" HeaderText="Views" />
                    <asp:BoundField DataField="CategoryId" HeaderText="CatID" />
                  </Columns>
                </asp:GridView>
                
              </ContentTemplate>
              <Triggers>
                <asp:AsyncPostBackTrigger ControlID="grdProducts" EventName="SelectedIndexChanged" />
              </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
    </section>
</body>
</html>

