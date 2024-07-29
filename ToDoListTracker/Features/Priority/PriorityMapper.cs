using AutoMapper;
using ToDoListTracker.Features.Priority.GetAll;
using PriorityDb = ToDoListTracker.Domain.Entities.Priority;

namespace ToDoListTracker.Features.Priority;

public class PriorityMapper : Profile
{
	public PriorityMapper()
	{
		GetAllMap();
	}

	private void GetAllMap()
	{
		CreateMap<PriorityDb, PriorityResponse>();
	}
}
