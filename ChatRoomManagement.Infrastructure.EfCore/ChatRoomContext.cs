using ChatRoomManagement.Domain.UserAgg;
using ChatRoomManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ChatRoomManagement.Infrastructure.EfCore
{
    public class ChatRoomContext:DbContext
    {
        public ChatRoomContext(DbContextOptions<ChatRoomContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly= typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
