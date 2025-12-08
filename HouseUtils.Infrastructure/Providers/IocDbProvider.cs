using HouseUtils.Application.Data;
using HouseUtils.Application.Providers;

using Microsoft.Extensions.DependencyInjection;

namespace HouseUtils.Infrastructure.Providers;

public class IocDbProvider (IServiceProvider serviceProvider) : IDbProvider
{
   public IApplicationDbContext Context () => serviceProvider.GetRequiredService<IApplicationDbContext>();
   public ITransactionDbContext Transaction () => serviceProvider.GetRequiredService<ITransactionDbContext>();
}
