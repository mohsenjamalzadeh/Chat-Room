using ChatRoomManagement.Domain.UserAgg;
using ChatRoomManagement.Infrastructure.EfCore;
using ChatRoomManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChatRoomManagement.Infrastructure.Configuration
{
    public  static class ChatRoomManagementBootStrapper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IUserRepository,UserRepository>();

            services.AddDbContext<ChatRoomContext>(p=>p.UseSqlServer(connectionString));
        }
    }
}
