using Microsoft.EntityFrameworkCore;
using ToDoListTracker.Domain.Entities;

namespace ToDoListTracker.Infrastructure;

public class ToDoListDbContext : DbContext
{
	public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }
	
	public DbSet<User> Users { get; set; }
	public DbSet<Priority> Priorities { get; set; }
	public DbSet<ToDoItem> ToDoItems { get; set; }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoListDbContext).Assembly);
	}
}