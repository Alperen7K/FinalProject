
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IProductDal:IEntityRepository<Product>
{
    List<ProductDetailDto> GetProductDetails();
    
    Boolean AddProduct (Product product);
    
    Product GetProductById(int productId);
}