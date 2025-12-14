namespace HouseUtils.Presentation.Views.Models;

public class Icons
{
   
}

public abstract record Icon 
{
   public required string Name { get; set; }
   public abstract string Content { get; }
}

public record FaIcon : Icon
{
   public FaFamily Family { get; set; }
   public FaStyle Style { get; set; }

   public override string Content => $"""
      <i class="{Family.Class()} {Style.Class()}">
      """;

   public enum FaFamily
   {
      Classic = 0,
   }
   public enum FaStyle
   {
      Regular = 0,
      Solid = 1,
   }
}

public static class FaIconExtensions
{
   public static string Class (this FaIcon.FaFamily family) => family switch
   {
      FaIcon.FaFamily.Classic => "fa-classic",

   };
   public static string Class (this FaIcon.FaStyle style) => style switch
   {
      FaIcon.FaStyle.Regular => "fa-regular",
      FaIcon.FaStyle.Solid => "fa-solid"
   };
}
