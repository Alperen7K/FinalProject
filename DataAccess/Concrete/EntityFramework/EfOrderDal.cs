using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.PostgreSQL;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfOrderDal:EfEntityRepositoryBase<Order,PostgreSqlContext>,IOrderDal
{
    
}