using HouseUtils.Application.Abstractions;
using HouseUtils.Shared.UnionTypes;

using Microsoft.Extensions.Logging;

namespace HouseUtils.Application.Decorators;

public partial class LoggingDecorator
{
   public class QueryHandler<TQuery, TResult> : LoggingDecorator, IQueryHandler<TQuery, TResult> where TQuery : IQuery
   {
      private readonly IQueryHandler<TQuery, TResult> _handler;

      public QueryHandler (IQueryHandler<TQuery, TResult> handler, ILogger<LoggingDecorator> logger) : base(logger)
      {
         _handler = handler;
      }

      public Task<Attempt<TResult>> HandleAsync (TQuery args)
      {
         try
         {
            _logger.LogInformation("Starting handler {HandlerName}", _handler.GetType().Name);
            return _handler.HandleAsync(args);
         }
         finally
         {
            _logger.LogInformation("End of handler {HandlerName}", _handler.GetType().Name);
         }
      }
   }
}