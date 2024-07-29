using FluentValidation;

namespace ToDoListTracker.Features.ToDoItem.Update;

public class UpdateToDoItemRequestValidator : AbstractValidator<UpdateToDoItemRequest>
{
	public UpdateToDoItemRequestValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage("Id field is required");
		
		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(100)
			.WithMessage("Title field is required and cannot be more then 100 characters");

		RuleFor(x => x.Description)
			.MaximumLength(500)
			.WithMessage("Description field cannot be more then 500 characters");

		RuleFor(x => x.PriorityId)
			.NotEmpty()
			.WithMessage("PriorityId field is required");

		RuleFor(x => x.isCompleted)
			.NotEmpty()
			.WithMessage("IsCompleted field is required");
	}
}