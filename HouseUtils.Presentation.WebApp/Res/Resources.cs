using HouseUtils.Shared;

using System.Reflection;

namespace HouseUtils.Presentation.Res;

public interface IResource;

public class Resources (
   Areas areas, 
   ViewData viewData, 
   Routes routes,
   App app,
   Sections sections) : IResource
{
   public readonly Areas AREAS = areas;
   public readonly ViewData VIEW_DATA = viewData;
   public readonly Routes ROUTES = routes;
   public readonly App APP = app;
   public readonly Sections SECTIONS = sections;
}

public static class ResourcesRegistry
{
   public static IServiceCollection AddResources (this IServiceCollection services)
   {
      Assembly assembly = Assembly.GetAssembly(typeof(IResource))
         ?? throw new Exception($"Assembly with {nameof(IResource)} could not be found");
      foreach (Type type in assembly.GetTypes())
      {
         if (type.IsClass && !type.IsAbstract && typeof(IResource).IsAssignableFrom(type))
         {
            services.AddTransient(type);
         }
      }
      return services;
   }
}