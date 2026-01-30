using HouseUtils.Application.Abstractions;

using Microsoft.Extensions.Logging;

namespace HouseUtils.Application.Decorators;

public partial class LoggingDecorator : IEventHandler
{
   public const string SERVICE_KEY = nameof(LoggingDecorator);
   
   protected readonly ILogger<LoggingDecorator> _logger;

   public LoggingDecorator(ILogger<LoggingDecorator> logger)
   {
      _logger = logger;
   }
}

