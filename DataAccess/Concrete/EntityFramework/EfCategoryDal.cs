using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.PostgreSQL;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCategoryDal: EfEntityRepositoryBase<Category,PostgreSqlContext>,ICategoryDal
{
    
}