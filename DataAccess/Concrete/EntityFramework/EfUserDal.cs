using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.PostgreSQL;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, PostgreSqlContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new PostgreSqlContext())
        {
            var result = from operationClaim in context.UserOperationClaims
                join userOperationClaim in context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim
                {
                    Id = operationClaim.Id //, Name = operationClaim.Name
                };
            return result.ToList();
        }
    }
}