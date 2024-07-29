using AutoMapper;
using ToDoListTracker.Domain.Entities;
using ToDoListTracker.Domain.Models;
using ToDoListTracker.Domain.Models.Criteria;
using ToDoListTracker.Features.ToDoItem.Create;
using ToDoListTracker.Features.ToDoItem.PartialUpdate;
using ToDoListTracker.Features.ToDoItem.Search;
using ToDoListTracker.Features.ToDoItem.Update;
using ToDoItemDb = ToDoListTracker.Domain.Entities.ToDoItem;
using PriorityDb = ToDoListTracker.Domain.Entities.Priority;

namespace ToDoListTracker.Features.ToDoItem;

public class ToDoItemMapper : Profile
{
	public ToDoItemMapper()
	{
		CreateMap();
		UpdateMap();
		PartialUpdateMap();
		SearchMap();
	}

	private void CreateMap()
	{
		CreateMap<CreateToDoItemRequest, ToDoItemDb>();
	}
	
	private void UpdateMap()
	{
		CreateMap<UpdateToDoItemRequest, ToDoItemDb>();
	}
	
	private void PartialUpdateMap()
	{
		CreateMap<PartialUpdateToDoItemRequest, ToDoItemDb>();
	}
	
	private void SearchMap()
	{
		CreateMap<SearchToDoItemRequest, SearchToDoItemCriteria>();
		CreateMap<ToDoItemDb, SearchToDoItemResponse>();
		CreateMap<PagedList<ToDoItemDb>, PagedList<SearchToDoItemResponse>>();
		CreateMap<PriorityDb, SearchToDoItemPriorityResponse>();
		CreateMap<User, SearchToDoItemUserResponse>();
	}
}
