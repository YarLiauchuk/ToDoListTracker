using AutoMapper;
using MediatR;
using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Entities;
using ToDoListTracker.Domain.Exceptions;
using ToDoItemDb = ToDoListTracker.Domain.Entities.ToDoItem;

namespace ToDoListTracker.Features.ToDoItem.PartialUpdate;

public record PartialUpdateToDoItemRequest : IRequest
{
	public Guid Id { get; init; }
	
	public Guid? UserId { get; init; }
}

public class PartialUpdateToDoItemHandler : IRequestHandler<PartialUpdateToDoItemRequest>
{
	private readonly IToDoItemRepository _toDoItemRepository;
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public PartialUpdateToDoItemHandler(
		IToDoItemRepository toDoItemRepository,
		IUserRepository userRepository,
		IMapper mapper)
	{
		_toDoItemRepository = toDoItemRepository;
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task Handle(PartialUpdateToDoItemRequest request,
		CancellationToken cancellationToken)
	{
		var toDoItem = await _toDoItemRepository.GetById(request.Id, cancellationToken:cancellationToken);

		if (toDoItem is null)
		{
			throw new EntitiesNotFoundException<Guid>(request.Id, nameof(ToDoItemDb), nameof(request.Id));
		}
		
		if (request.UserId is not null && !await _userRepository.IsExist(request.UserId.Value, cancellationToken))
		{
			throw new EntitiesNotFoundException<Guid>(request.UserId.Value, nameof(User), nameof(request.UserId));
		}
		
		_mapper.Map(request, toDoItem);
		
		await _toDoItemRepository.Update(toDoItem, cancellationToken);
	}
}


