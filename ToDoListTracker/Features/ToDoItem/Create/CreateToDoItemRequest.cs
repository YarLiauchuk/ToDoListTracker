using AutoMapper;
using MediatR;
using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Entities;
using ToDoListTracker.Domain.Exceptions;
using ToDoItemDb = ToDoListTracker.Domain.Entities.ToDoItem;

namespace ToDoListTracker.Features.ToDoItem.Create;

public record CreateToDoItemRequest : IRequest
{
	public string Title { get; set; }
	
	public string? Description { get; set; }
	
	public DateTime? DueDate { get; set; }
	
	public Guid PriorityId { get; set; }
	
	public Guid? UserId { get; set; }
}

public class CreateToDoItemHandler : IRequestHandler<CreateToDoItemRequest>
{
	private readonly IToDoItemRepository _toDoItemRepository;
	private readonly IPriorityRepository _priorityRepository;
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public CreateToDoItemHandler(
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

	public async Task Handle(CreateToDoItemRequest request,
		CancellationToken cancellationToken)
	{
		var toDoItem = _mapper.Map<ToDoItemDb>(request);

		if (request.UserId is not null && !await _userRepository.IsExist(request.UserId.Value, cancellationToken))
		{
			throw new EntitiesNotFoundException<Guid>(request.UserId.Value, nameof(User), nameof(request.UserId));
		}
		
		if (!await _priorityRepository.IsExist(request.PriorityId, cancellationToken))
		{
			throw new EntitiesNotFoundException<Guid>(request.PriorityId, nameof(Priority), nameof(request.PriorityId));
		}
		
		await _toDoItemRepository.Add(toDoItem, cancellationToken);
	}
}


