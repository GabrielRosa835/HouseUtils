using HouseUtils.Application.Persistence;
using HouseUtils.Application.Providers;

using Microsoft.Extensions.DependencyInjection;

namespace HouseUtils.Infrastructure.Providers;

public class IocDbProvider (IServiceProvider serviceProvider) : IDbProvider
{
   public IApplicationDbContext GetContext () => serviceProvider.GetRequiredService<IApplicationDbContext>();
   public ITransactionDbContext GetTransaction () => serviceProvider.GetRequiredService<ITransactionDbContext>();
}
