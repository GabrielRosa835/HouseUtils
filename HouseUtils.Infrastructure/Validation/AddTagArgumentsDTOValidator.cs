using FluentValidation;

using HouseUtils.Application.Data;
using HouseUtils.Application.Models.Tags;
using HouseUtils.Application.Models.Tags.DTOs;

namespace HouseUtils.Infrastructure.Validators;

public class AddTagArgumentsDTOValidator : AbstractValidator<AddTagArgumentsDTO>
{
   public AddTagArgumentsDTOValidator (IApplicationDbContext context)
   {
      RuleFor(x => x.Name)
         .NotEmpty()
         .WithMessage("Name must not be empty.")
         .MaximumLength(100)
         .WithMessage("Name must not exceed 100 characters.")
         .Must(name => !context.Tags.ExistsByName(name))
         .WithMessage("Name is already in use, chose another one");

      RuleFor(x => x.Description)
         .MaximumLength(500).WithMessage("Tag description must not exceed 500 characters.")
         .When(x => !string.IsNullOrEmpty(x.Description));
   }
}
