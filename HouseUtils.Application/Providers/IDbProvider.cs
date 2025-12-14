using HouseUtils.Application.Persistence;

namespace HouseUtils.Application.Providers;

public interface IDbProvider
{
   IApplicationDbContext GetContext ();
   ITransactionDbContext GetTransaction ();
}
