using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete;

using ProductService = IProductService;

public class ProductManager : ProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
    }

    public IDataResult<List<Product>> GetAllByCategory(int id)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id),
            Messages.ProductListed);
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),
            Messages.ProductListed);
    }

    public IDataResult<Product> GetById(int id)
    {
        var result = _productDal.GetProductById(id);
        if (result != null)
        {
            return new SuccessDataResult<Product>(result, Messages.ProductGetted);
        }

        return new ErrorDataResult<Product>(Messages.ProductNotFound);
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    // [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        
        IResult result = BusinessRules.Run(CheckIfCategoryProductCountOfCategoryCorrect(product.CategoryId),
            CheckIfProductNameExist(product.ProductName));

        if (result != null)
        {
            return result;
        }

        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);

    }

    public IResult Update(Product product)
    {
        _productDal.Update(product);

        return new SuccessResult(Messages.ProductUpdated);
    }

    private IResult CheckIfCategoryProductCountOfCategoryCorrect(int categoryId)
    {
        var result = _productDal.GetAll(u => u.CategoryId == categoryId).Count();

        if (result >= 10)
        {
            return new ErrorResult(Messages.ProductCounOfCategoryError);
        }

        return new SuccessResult();
    }

    private IResult CheckIfProductNameExist(string name)
    {
        var result = _productDal.GetAll(p => p.ProductName == name).Any();

        if (result)
        {
            return new ErrorResult(Messages.ProductNameExist);
        }

        return new SuccessResult();
    }
}