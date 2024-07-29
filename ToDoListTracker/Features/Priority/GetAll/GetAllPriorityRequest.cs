using AutoMapper;
using MediatR;
using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Models;
using ToDoListTracker.Domain.Models.Criteria;

namespace ToDoListTracker.Features.Priority.GetAll;

public record GetAllPriorityRequest : IRequest<List<PriorityResponse>>;

public class GetAllPriorityHandler : IRequestHandler<GetAllPriorityRequest, List<PriorityResponse>>
{
	private readonly IPriorityRepository _priorityRepository;
	private readonly IMapper _mapper;

	public GetAllPriorityHandler(
		IPriorityRepository priorityRepository,
		IMapper mapper)
	{
		_priorityRepository = priorityRepository;
		_mapper = mapper;
	}

	public async Task<List<PriorityResponse>> Handle(GetAllPriorityRequest request,
		CancellationToken cancellationToken)
	{
		return _mapper.Map<List<PriorityResponse>>(await _priorityRepository.GetAll(cancellationToken));
	}
}


