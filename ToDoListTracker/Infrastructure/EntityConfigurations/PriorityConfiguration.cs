using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListTracker.Domain.Entities;

namespace ToDoListTracker.Infrastructure.EntityConfigurations;

public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
	public void Configure(EntityTypeBuilder<Priority> builder)
	{
		builder
			.HasKey(x => x.Id);

		builder
			.Property(x => x.Id);
		
		builder
			.Property(x => x.Level)
			.IsRequired();
		
		builder
			.HasMany(x => x.ToDoItems)
			.WithOne()
			.HasForeignKey(x => x.PriorityId);

		builder
			.HasData(GetDefaultPriorities());
	}
	
	private static IEnumerable<Priority> GetDefaultPriorities()
	{
		return new List<Priority>
		{
			new (Guid.Parse("4396a607-4fa1-4ce6-9378-69b6db56e963"), 1),
			new (Guid.Parse("1998214e-0fea-4673-b736-6bf6b87de8da"), 2),
			new (Guid.Parse("14a32d34-9241-4040-bc9d-e438530810de"), 3),
			new (Guid.Parse("3ec8efa0-5305-403f-adfe-644051f4e476"), 4),
		};
	}
}