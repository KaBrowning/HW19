using System.Collections.Generic;
using System.Linq;

/// <summary>
/// This class describes a Halloween ProductView List
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public class ProductViewList
{
    private readonly List<ProductView> _productList = new List<ProductView>();

    /// <summary>
    /// Adds the specified new view.
    /// </summary>
    /// <param name="newView">The new view.</param>
    public void Add(ProductView newView)
    {
        System.Threading.Thread.Sleep(2000);
        var view = this._productList.FirstOrDefault(v => v.ProductName == newView.ProductName);
        if (view == null)
        {
            this._productList.Add(newView);
        }
        else
        {
            view.ViewCount += 1;
        }
    }

    /// <summary>
    /// Displays this instance.
    /// </summary>
    /// <returns></returns>
    public List<ProductView> Display()
    {
        return this._productList.OrderByDescending(p => p.ViewCount).ThenBy(p => p.ProductName).ToList();
    }
}