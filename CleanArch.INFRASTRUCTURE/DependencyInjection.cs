using CleanArch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=LAPTOP-KCT619UI\\SQLEXPRESS;Database=Test_Db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
            });
            return service;
        }
    }
}
