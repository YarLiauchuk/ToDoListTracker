using AutoMapper;
using MediatR;
using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Entities;
using ToDoListTracker.Domain.Exceptions;
using ToDoItemDb = ToDoListTracker.Domain.Entities.ToDoItem;

namespace ToDoListTracker.Features.ToDoItem.Update;

public record UpdateToDoItemRequest : IRequest
{
	public Guid Id { get; init; }
	
	public string Title { get; init; }
	
	public string? Description { get; init; }
	
	public DateTime? DueDate { get; init; }
	
	public bool isCompleted { get; init; }
	
	public Guid PriorityId { get; init; }
	
	public Guid? UserId { get; init; }
}

public class UpdateToDoItemHandler : IRequestHandler<UpdateToDoItemRequest>
{
	private readonly IToDoItemRepository _toDoItemRepository;
	private readonly IPriorityRepository _priorityRepository;
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public UpdateToDoItemHandler(
		IToDoItemRepository toDoItemRepository,
		IUserRepository userRepository,
		IPriorityRepository priorityRepository,
		IMapper mapper)
	{
		_toDoItemRepository = toDoItemRepository;
		_priorityRepository = priorityRepository;
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task Handle(UpdateToDoItemRequest request,
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
		
		if (!await _priorityRepository.IsExist(request.PriorityId, cancellationToken))
		{
			throw new EntitiesNotFoundException<Guid>(request.PriorityId, nameof(Priority), nameof(request.PriorityId));
		}

		_mapper.Map(request, toDoItem);
		
		await _toDoItemRepository.Update(toDoItem, cancellationToken);
	}
}


