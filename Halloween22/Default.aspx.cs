using System;
using System.Collections.Generic;

/// <summary>
/// This class describes the page that lets users select and view the details of a product
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class Default : System.Web.UI.Page
{
    private const string AppKey = "viewlist";

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ProductViewList viewlist;
        if (Application[AppKey] == null)
        {
            viewlist = new ProductViewList();
            Application.Add(AppKey, viewlist);
        }
        else
        {
            viewlist = (ProductViewList)Application[AppKey];
            this.BindViewGrid(viewlist.Display());
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the grdProducts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void grdProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        var view = new ProductView(
            this.grdProducts.SelectedValue.ToString(),
            this.grdProducts.SelectedRow.Cells[2].Text,
            this.ddlCategory.SelectedValue, 1);

        Application.Lock();
        var viewlist = (ProductViewList)Application[AppKey];
        viewlist.Add(view);
        Application.UnLock();

        this.BindViewGrid(viewlist.Display());
    }

    /// <summary>
    /// Binds the view grid.
    /// </summary>
    /// <param name="views">The views.</param>
    private void BindViewGrid(List<ProductView> views)
    {
        this.grdViews.DataSource = views;
        this.grdViews.DataBind();
    }

    /// <summary>
    /// Resets the specified sender.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Reset(object sender, EventArgs e)
    {
        this.grdProducts.SelectedIndex = -1;
    }
}