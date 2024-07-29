using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListTracker.Domain.Entities;

namespace ToDoListTracker.Infrastructure.EntityConfigurations;

public class  UserConfiguration : IEntityTypeConfiguration< User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder
			.HasKey(x => x.Id);
		
		builder
			.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder
			.HasData(GetDefaultUsers());
	}
	
	private static IEnumerable<User> GetDefaultUsers()
	{
		return new List<User>
		{
			new (Guid.Parse("6ba91f37-5e9d-425b-bdc7-b498437098ee"), "Ivan"),
			new (Guid.Parse("f283ce82-f941-4068-acc2-a788ffd4b634"), "Alex"),
			new (Guid.Parse("23c59c51-5ab1-4a0e-8374-89f7d5323295"), "Helena"),
			new (Guid.Parse("63a16261-755c-42d9-b490-c1bfbb93f18d"), "Jonh"),
		};
	}
}