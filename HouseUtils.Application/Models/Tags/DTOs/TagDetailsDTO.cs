using HouseUtils.Domain.Models;

namespace HouseUtils.Application.Models.Tags.DTOs;

public record TagDetailsDTO
{
   public int Id { get; init; }
   public required string Name { get; init; }
   public string? Description { get; init; }

   public static TagDetailsDTO Of(Tag tag) => new()
   {
      Id = tag.Id,
      Name = tag.Name,
      Description = tag.Description,
   };
}
