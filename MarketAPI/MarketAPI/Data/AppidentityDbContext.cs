﻿using System;
using System.Threading.Tasks;
using MarketAPI.Models;
using MarketAPI.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketAPI.Data
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public static async Task CreateBaseAccount(IServiceProvider serviceProvider)
        {
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            UserManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<UserManager<IdentityRole>>();
            var userName = "Joe";
            var email = "Joe@example.com";
            var role = "Admin";
            var passvvord = "Pass$.Vvord";
            AppUser user = new AppUser {
                UserName = userName,
                Email = email
            };
            await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.CreateAsync(user, passvvord);
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}