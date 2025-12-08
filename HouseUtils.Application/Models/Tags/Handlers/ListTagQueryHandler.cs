using FluentValidation;

using HouseUtils.Application.Data;
using HouseUtils.Application.DTOs;
using HouseUtils.Application.Extensions;
using HouseUtils.Application.Models.Tags.DTOs;
using HouseUtils.Shared;
using HouseUtils.Shared.Attempts;
using HouseUtils.Shared.Extensions;

namespace HouseUtils.Application.Models.Tags.Handlers;

public class ListTagQueryHandler
   (IApplicationDbContext context, IValidator<ListTagArgumentsDTO> validator)
   : IResultArgumentHandler<Attempt<PageDTO<TagSummaryDTO>, ProblemDTO>, ListTagArgumentsDTO>
{
   public Attempt<PageDTO<TagSummaryDTO>, ProblemDTO> Handle (ListTagArgumentsDTO arguments)
   {
      if (validator.TryValidate(arguments, out ValidationProblemDTO errors))
         return errors;

      ICollection<TagSummaryDTO> tags = context.Tags.Set
         .Paging(arguments.PageIndex, arguments.PageSize)
         .Select(TagSummaryDTO.Of)
         .ToList();

      int totalCount = context.Tags.Set.Count();

      return PageDTO<TagSummaryDTO>.Of(tags, arguments.PageIndex, arguments.PageSize, totalCount);
   }
}
