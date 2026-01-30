using HouseUtils.Presentation.Models;

namespace HouseUtils.Presentation.Res;

public partial class Areas : IResource
{
   public static class C
   {
      public const string REGISTRY_ID = "registry";
      public const string SERVICES_ID = "services";
   }

   public readonly Area REGISTRY = new(C.REGISTRY_ID, "registries", "Registros");
   public readonly Area SERVICES = new(C.SERVICES_ID, "services", "Serviços");
   public readonly Area[] ALL;

   public Areas ()
   {
      ALL = [REGISTRY, SERVICES];
   }
}
