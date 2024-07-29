using AutoMapper;
using MediatR;
using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Entities;
using ToDoListTracker.Domain.Exceptions;
using ToDoItemDb = ToDoListTracker.Domain.Entities.ToDoItem;

namespace ToDoListTracker.Features.ToDoItem.Delete;

public record DeleteToDoItemRequest(Guid Id) : IRequest;

public class DeleteToDoItemHandler : IRequestHandler<DeleteToDoItemRequest>
{
	private readonly IToDoItemRepository _toDoItemRepository;

	public DeleteToDoItemHandler(IToDoItemRepository toDoItemRepository)
	{
		_toDoItemRepository = toDoItemRepository;
	}

	public async Task Handle(DeleteToDoItemRequest request,
		CancellationToken cancellationToken)
	{
		var toDoItem = await _toDoItemRepository.GetById(request.Id, cancellationToken:cancellationToken);

		if (toDoItem is null)
		{
			throw new EntitiesNotFoundException<Guid>(request.Id, nameof(ToDoItemDb), nameof(request.Id));
		}

		toDoItem.IsDeleted = true;
		
		await _toDoItemRepository.Update(toDoItem, cancellationToken);
	}
}


