using FluentValidation;

using HouseUtils.Application.DTOs;
using HouseUtils.Application.Extensions;
using HouseUtils.Application.Models.Tags.DTOs;
using HouseUtils.Application.Providers;
using HouseUtils.Domain.Models;
using HouseUtils.Shared;
using HouseUtils.Shared.UnionTypes;

namespace HouseUtils.Application.Models.Tags.Handlers;

public class RemoveTagCommandHandler
   (IDbProvider db, IValidator<RemoveTagArgumentsDTO> validator)
   : IResultArgumentHandler<Attempt<ProblemDTO>, RemoveTagArgumentsDTO>
{
   public Attempt<ProblemDTO> Handle (RemoveTagArgumentsDTO arguments)
   {
      if (validator.TryValidate(arguments, out ValidationProblemDTO? errors))
         return errors;

      Tag? tag;
      using (var context = db.GetContext())
      {
         tag = context.Tags.FindById(arguments.Id);
      }

      if (tag is null)
         return Problems.NotFound<Tag>(arguments.Id);

      try
      {
         using var transaction = db.GetTransaction();
         transaction.Tags.Remove(tag);
      }
      catch (Exception e)
      {
         return Problems.Of(e);
      }

      return Results.Success<ProblemDTO>(null!);
   }
}
