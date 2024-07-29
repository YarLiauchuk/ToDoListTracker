using FluentValidation;
using ToDoListTracker.Domain.Models;

namespace ToDoListTracker.Features.ToDoItem.Search;

public class SearchToDoItemRequestValidator : AbstractValidator<SearchToDoItemRequest>
{
	public SearchToDoItemRequestValidator()
	{
		RuleFor(x => x.Take)
			.GreaterThan(0)
			.WithMessage("Take must be greater than 0.");

		RuleFor(x => x.Skip)
			.GreaterThanOrEqualTo(0)
			.WithMessage("Skip must be greater than or equal to 0.");
		
		RuleForEach(x => x.SortExpressions)
			.SetValidator(new SearchToDoItemRequestSortExpressionValidator());
	}
}

public class SearchToDoItemRequestSortExpressionValidator : AbstractValidator<SortExpression>
{
	public SearchToDoItemRequestSortExpressionValidator()
	{
		RuleFor(x => x.Direction)
			.IsInEnum()
			.WithMessage("Direction can be only 0 (asc) or 1(desc)");
		
		RuleFor(x => x.PropertyName)
			.Must(PropertyExists)
			.WithMessage("One or more property names from SortExpressions is not exists");
	}
	
	private static bool PropertyExists(string propertyName)
	{
		var type = typeof(Domain.Entities.ToDoItem);
		foreach (var part in propertyName.Split('.'))
		{
			var property = type.GetProperty(part);
			if (property == null)
				return false;

			type = property.PropertyType;
		}
		return true;
	}
}