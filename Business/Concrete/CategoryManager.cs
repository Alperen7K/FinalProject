using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public IDataResult<List<Category>> GetAll()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList());
    }

    public IDataResult<Category> GetById(int id)
    {
        return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id));
    }

    public IDataResult<int> GetCategoryCount()
    {
        return new SuccessDataResult<int>(_categoryDal.GetAll().Count());
    }
}