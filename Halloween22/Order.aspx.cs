using System;
using System.Web.UI;
using System.Data;

/// <summary>
/// This class describes the page that allows the user to select and add a product to their cart
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class Order : Page
{
    private Product _selectedProduct;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //bind dropdown on first load; get and show product data on every load        
        if (!IsPostBack) this.ddlProducts.DataBind();
        this._selectedProduct = this.GetSelectedProduct();
        this.lblName.Text = this._selectedProduct.Name;
        this.lblShortDescription.Text = this._selectedProduct.ShortDescription;
        this.lblLongDescription.Text = this._selectedProduct.LongDescription;
        this.lblUnitPrice.Text = this._selectedProduct.UnitPrice.ToString("c") + " each";
        this.imgProduct.ImageUrl = "Images/Products/" + this._selectedProduct.ImageFile;
    }

    /// <summary>
    /// Gets the selected product.
    /// </summary>
    /// <returns></returns>
    private Product GetSelectedProduct()
    {
        //get row from AccessDataSource based on value in dropdownlist
        var productsTable = (DataView)
            this.SqlDataSource1.Select(DataSourceSelectArguments.Empty);

        if (productsTable == null)
            return null;
        productsTable.RowFilter = string.Format("ProductId = '{0}'",
            this.ddlProducts.SelectedValue);
        var row = productsTable[0];

        //create a new product object and load with data from row
        var p = new Product(
            row["ProductId"].ToString(),
            row["Name"].ToString(),
            row["ShortDescription"].ToString(),
            row["LongDescription"].ToString(),
            (decimal)row["UnitPrice"],
            row["ImageFile"].ToString());
        return p;
    }

    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.lblMessage.Text = "Not Implemented";
    }
}