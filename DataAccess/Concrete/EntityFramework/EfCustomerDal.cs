using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.PostgreSQL;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal:EfEntityRepositoryBase<Customer,PostgreSqlContext>,ICustomerDal
{
    
}