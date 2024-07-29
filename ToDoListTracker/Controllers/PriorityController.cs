using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListTracker.Domain.Models;
using ToDoListTracker.Features.Priority.GetAll;
using ToDoListTracker.Features.ToDoItem.Create;
using ToDoListTracker.Features.ToDoItem.Delete;
using ToDoListTracker.Features.ToDoItem.PartialUpdate;
using ToDoListTracker.Features.ToDoItem.Search;
using ToDoListTracker.Features.ToDoItem.Update;

namespace ToDoListTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class PriorityController : ControllerBase
{
	private readonly IMediator _mediator;

	public PriorityController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("get-all")]
	public Task<List<PriorityResponse>> GetAll(CancellationToken cancellationToken)
	{
		return _mediator.Send(new GetAllPriorityRequest(), cancellationToken);
	}
}