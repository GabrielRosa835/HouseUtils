using HouseUtils.Domain.Models;

namespace HouseUtils.Application.Models.Tags.DTOs;

public record AddTagArgumentsDTO
{
   public string Name { get; set; } = null!;
   public string? Description { get; set; }

   public Tag ToTag() => new ()
   {
      Name = Name,
      Description = Description,
   };
}
