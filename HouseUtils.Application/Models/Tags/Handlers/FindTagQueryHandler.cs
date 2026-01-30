// using FluentValidation;
//
// using HouseUtils.Application.DTOs;
// using HouseUtils.Application.Extensions;
// using HouseUtils.Application.Models.Tags.DTOs;
// using HouseUtils.Application.Persistence;
// using HouseUtils.Domain.Models;
// using HouseUtils.Shared;
// using HouseUtils.Shared.UnionTypes;
//
// namespace HouseUtils.Application.Models.Tags.Handlers;
//
// public class FindTagQueryHandler 
//    (IApplicationDbContext context, IValidator<FindTagArgumentsDTO> validator)
//    : IResultArgumentHandler<Attempt<TagDetailsDTO, ProblemDTO>, FindTagArgumentsDTO>
// {
//    public Attempt<TagDetailsDTO, ProblemDTO> Handle (FindTagArgumentsDTO arguments)
//    {
//       if (validator.TryValidate(arguments, out var errors))
//          return errors;
//
//       Tag? tag = context.Tags.FindById(arguments.Id);
//
//       if (tag is null) return Problems.NotFound<Tag>(arguments.Id);
//
//       return TagDetailsDTO.Of(tag);
//    }
// }
