﻿using ChatRoomManagement.Domain.GroupAgg;
using ChatRoomManagement.Domain.UserAgg;
using ChatRoomManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ChatRoomManagement.Infrastructure.EfCore
{
    public class ChatRoomContext:DbContext
    {
        public ChatRoomContext(DbContextOptions<ChatRoomContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly= typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
