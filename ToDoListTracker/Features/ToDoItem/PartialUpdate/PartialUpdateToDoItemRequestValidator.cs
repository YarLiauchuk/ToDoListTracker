using FluentValidation;

namespace ToDoListTracker.Features.ToDoItem.PartialUpdate;

public class PartialUpdateToDoItemRequestValidator : AbstractValidator<PartialUpdateToDoItemRequest>
{
	public PartialUpdateToDoItemRequestValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage("Id field is required");
	}
}