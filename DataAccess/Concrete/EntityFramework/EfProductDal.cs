using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.PostgreSQL;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, PostgreSqlContext>, IProductDal
{
    public List<ProductDetailDto> GetProductDetails()
    {
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var result = from p in context.Products
                join c in context.Categories
                    on p.CategoryId equals c.CategoryId
                select new ProductDetailDto
                {
                    ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName,
                    UnitsInStock = p.UnitsInStock,
                };
            return result.ToList();
        }
    }

    public bool AddProduct(Product product)
    {
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            context.Products.Add(product);
            return context.SaveChanges() > 0;
        }
    }

    public Product GetProductById(int productId)
    {
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var result = context.Products.Find(productId);
            return result;
        }
    }
}