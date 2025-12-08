using HouseUtils.Application.Data;

namespace HouseUtils.Infrastructure.Persistence;

public class TransactionDbContext : ApplicationDbContext, ITransactionDbContext
{
   public override void Dispose ()
   {
      SaveChanges();
      base.Dispose();
   }
}
