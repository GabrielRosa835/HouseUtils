using HouseUtils.Application.Data;

namespace HouseUtils.Application.Providers;

public interface IDbProvider
{
   IApplicationDbContext Context ();
   ITransactionDbContext Transaction ();
}
