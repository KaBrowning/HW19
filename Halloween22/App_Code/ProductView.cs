
using System;

/// <summary>
/// This class describes a Halloween ProductView
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public class ProductView
{
    private string _productId;
    private string _productName;
    private string _categoryId;
    private int _viewCount;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductView"/> class.
    /// </summary>
    public ProductView()
    {
        
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductView"/> class.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="productName">Name of the product.</param>
    /// <param name="categoryId">The category identifier.</param>
    /// <param name="viewCount">The view count.</param>
    public ProductView(string productId, string productName, string categoryId, int viewCount)
    {
        this.ProductId = productId;
        this.ProductName = productName;
        this.CategoryId = categoryId;
        this.ViewCount = viewCount;
    }


    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    /// <value>
    /// The product identifier.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product id</exception>
    public string ProductId
    {
        get
        {
            return this._productId;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product id");
            }
            this._productId = value;
        }
    }

    /// <summary>
    /// Gets or sets the product name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product name</exception>
    public string ProductName
    {
        get
        {
            return this._productName;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product name");
            }
            this._productName = value;
        }
    }

    /// <summary>
    /// Gets or sets the category identifier.
    /// </summary>
    /// <value>
    /// The category identifier.
    /// </value>
    /// <exception cref="ArgumentException">Invalid category id</exception>
    public string CategoryId
    {
        get
        {
            return this._categoryId;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid category id");
            }
            this._categoryId = value;
        }
    }

    /// <summary>
    /// Gets or sets the view count.
    /// </summary>
    /// <value>
    /// The view count.
    /// </value>
    /// <exception cref="ArgumentException">Invalid view count</exception>
    public int ViewCount
    {
        get
        {
            return this._viewCount;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid view count");
            }
            this._viewCount = value;
        }
    }
}