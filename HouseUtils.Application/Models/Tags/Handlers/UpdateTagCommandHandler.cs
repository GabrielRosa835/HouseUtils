using FluentValidation;

using HouseUtils.Application.DTOs;
using HouseUtils.Application.Extensions;
using HouseUtils.Application.Models.Tags.DTOs;
using HouseUtils.Application.Providers;
using HouseUtils.Domain.Models;
using HouseUtils.Shared;
using HouseUtils.Shared.Attempts;

namespace HouseUtils.Application.Models.Tags.Handlers;

public class UpdateTagCommandHandler
   (IDbProvider db, IValidator<UpdateTagArgumentsDTO> validator)
   : IResultArgumentHandler<Attempt<ProblemDTO>, UpdateTagArgumentsDTO>
{
   public Attempt<ProblemDTO> Handle (UpdateTagArgumentsDTO arguments)
   {
      if (validator.TryValidate(arguments, out ValidationProblemDTO errors))
         return errors;

      Tag? tag;
      using (var context = db.GetContext())
      {
         tag = context.Tags.FindById(arguments.Id);
      }

      if (tag is null)
         return Problems.NotFound<Tag>(arguments.Id);

      arguments.ApplyChangesTo(tag);

      try
      {
         using var transaction = db.GetTransaction();
         transaction.Tags.Update(tag);
      }
      catch (Exception e)
      {
         return Problems.Of(e);
      }

      return Attempts.Success<ProblemDTO>();
   }
}
