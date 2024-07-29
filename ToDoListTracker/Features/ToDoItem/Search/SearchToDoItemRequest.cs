using AutoMapper;
using MediatR;
using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Models;
using ToDoListTracker.Domain.Models.Criteria;

namespace ToDoListTracker.Features.ToDoItem.Search;

public record SearchToDoItemRequest(string? Keyword) : PagedRequest, IRequest<PagedList<SearchToDoItemResponse>>;

public class SearchToDoItemHandler : IRequestHandler<SearchToDoItemRequest, PagedList<SearchToDoItemResponse>>
{
	private readonly IToDoItemRepository _toDoItemRepository;
	private readonly IMapper _mapper;

	public SearchToDoItemHandler(
		IToDoItemRepository toDoItemRepository,
		IMapper mapper)
	{
		_toDoItemRepository = toDoItemRepository;
		_mapper = mapper;
	}

	public async Task<PagedList<SearchToDoItemResponse>> Handle(SearchToDoItemRequest request,
		CancellationToken cancellationToken)
	{
		var searchCriteria = _mapper.Map<SearchToDoItemCriteria>(request);

		var toDoItems = await _toDoItemRepository.Search(searchCriteria, cancellationToken);

		return _mapper.Map<PagedList<SearchToDoItemResponse>>(toDoItems);
	}
}


