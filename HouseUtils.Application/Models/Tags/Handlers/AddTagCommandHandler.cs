using FluentValidation;

using HouseUtils.Application.DTOs;
using HouseUtils.Application.Extensions;
using HouseUtils.Application.Models.Tags.DTOs;
using HouseUtils.Application.Providers;
using HouseUtils.Domain.Models;
using HouseUtils.Shared;
using HouseUtils.Shared.Attempts;

namespace HouseUtils.Application.Models.Tags.Handlers;

public class AddTagCommandHandler
   (IDbProvider dbProvider, IValidator<AddTagArgumentsDTO> validator)
   : IResultArgumentHandler<Attempt<CreatedDTO, ProblemDTO>, AddTagArgumentsDTO>
{
   public Attempt<CreatedDTO, ProblemDTO> Handle (AddTagArgumentsDTO arguments)
   {
      if (validator.TryValidate(arguments, out ValidationProblemDTO errors))
         return errors;

      Tag tag = arguments.ToTag();

      using var transaction = dbProvider.GetTransaction();
      transaction.Tags.Add(tag);

      return new CreatedDTO
      {
         Id = tag.Id,
         Location = $"/api/tags/{tag.Id}"
      };
   }
}
