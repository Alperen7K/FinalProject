using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        ProductTest();

        // CategoryTest();
    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(
                $"ID: {category.CategoryName}, CategoryId: {category.CategoryId}");
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        var result = productManager.GetProductDetails();

        if (result.Success)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(
                    $"ID: {product.ProductId}, Name: {product.ProductName}, Units In Stock: {product.UnitsInStock}, CategoryName: {product.CategoryName}");
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}