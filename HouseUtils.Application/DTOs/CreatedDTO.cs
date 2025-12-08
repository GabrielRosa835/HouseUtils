namespace HouseUtils.Application.DTOs;

public record CreatedDTO
{
   public required int Id { get; set; }
   public required string Location { get; set; }
}
