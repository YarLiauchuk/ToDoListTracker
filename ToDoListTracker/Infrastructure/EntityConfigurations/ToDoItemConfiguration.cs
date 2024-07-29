using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListTracker.Domain.Entities;

namespace ToDoListTracker.Infrastructure.EntityConfigurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
	public void Configure(EntityTypeBuilder<ToDoItem> builder)
	{
		builder
			.HasKey(x => x.Id);
		
		builder
			.Property(x => x.Title)
			.IsRequired()
			.HasMaxLength(100);

		builder
			.Property(x => x.Description)
			.HasMaxLength(500);

		builder
			.Property(x => x.IsCompleted)
			.IsRequired();
		
		builder
			.Property(x => x.IsCompleted)
			.IsRequired();

		builder
			.Property(x => x.DueDate);

		builder
			.HasOne(x => x.Priority)
			.WithMany()
			.HasForeignKey(x => x.PriorityId)
			.IsRequired(false);

		builder
			.HasOne(x => x.User)
			.WithMany()
			.HasForeignKey(x => x.UserId);

		builder
			.HasData(GetDefaultToDoItems());
	}

	private static IEnumerable<ToDoItem> GetDefaultToDoItems()
	{
		return new List<ToDoItem>
		{
			new (Guid.Parse("84d15eb3-036a-4f15-832c-418b0ac9d047"), "Household chores", false, DateTime.UtcNow, Guid.Parse("4396a607-4fa1-4ce6-9378-69b6db56e963"), Guid.Parse("6ba91f37-5e9d-425b-bdc7-b498437098ee")),
			new (Guid.Parse("fcfe54f0-7b06-48ce-a636-eec4457e725f"), "Work task", false, DateTime.UtcNow, Guid.Parse("1998214e-0fea-4673-b736-6bf6b87de8da"), Guid.Parse("f283ce82-f941-4068-acc2-a788ffd4b634")),
			new (Guid.Parse("0fcd221c-3cc4-42ba-819d-2ee157a745ec"), "Something", true, DateTime.UtcNow, Guid.Parse("14a32d34-9241-4040-bc9d-e438530810de"), Guid.Parse("23c59c51-5ab1-4a0e-8374-89f7d5323295")),
			new (Guid.Parse("bd4e74b9-6728-4233-99e7-976799932854"), "Relax", true, DateTime.UtcNow, Guid.Parse("3ec8efa0-5305-403f-adfe-644051f4e476"), Guid.Parse("63a16261-755c-42d9-b490-c1bfbb93f18d")),
		};
	}
}