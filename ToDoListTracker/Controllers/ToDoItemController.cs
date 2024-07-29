using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListTracker.Domain.Models;
using ToDoListTracker.Features.ToDoItem.Create;
using ToDoListTracker.Features.ToDoItem.Delete;
using ToDoListTracker.Features.ToDoItem.PartialUpdate;
using ToDoListTracker.Features.ToDoItem.Search;
using ToDoListTracker.Features.ToDoItem.Update;

namespace ToDoListTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoItemController : ControllerBase
{
	private readonly IMediator _mediator;

	public ToDoItemController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost]
	public Task Create([FromBody]CreateToDoItemRequest request, CancellationToken cancellationToken)
	{
		return _mediator.Send(request, cancellationToken);
	}

	[HttpPost("search")]
	public Task<PagedList<SearchToDoItemResponse>> Search([FromBody] SearchToDoItemRequest request,
		CancellationToken cancellationToken)
	{
		return _mediator.Send(request, cancellationToken);
	}
	
	[HttpPost("assign-user")]
	public Task PartialUpdate([FromBody] PartialUpdateToDoItemRequest request,
		CancellationToken cancellationToken)
	{
		return _mediator.Send(request, cancellationToken);
	}
	
	[HttpPut]
	public Task Update([FromBody]UpdateToDoItemRequest request, CancellationToken cancellationToken)
	{
		return _mediator.Send(request, cancellationToken);
	}
	
	[HttpDelete("{id:guid}")]
	public Task Delete(Guid id, CancellationToken cancellationToken)
	{
		return _mediator.Send(new DeleteToDoItemRequest(id), cancellationToken);
	}
}