using FluentValidation;

namespace ToDoListTracker.Features.ToDoItem.Create;

public class CreateToDoItemRequestValidator : AbstractValidator<CreateToDoItemRequest>
{
	public CreateToDoItemRequestValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(100)
			.WithMessage("Title field is required and cannot be more then 100 characters");

		RuleFor(x => x.Description)
			.MaximumLength(500)
			.WithMessage("Description cannot be more then 500 characters");

		RuleFor(x => x.PriorityId)
			.NotEmpty()
			.WithMessage("PriorityId filed is required");
	}
}