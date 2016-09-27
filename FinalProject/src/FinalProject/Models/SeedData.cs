using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinalProject.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.CashAccount.Any())
                {
                    return;   // DB has been seeded
                }

                context.CashAccount.AddRange(
                    new FinalProject.Models.CashAccount
                    {
                        AccountDescription = "Test",
                        BankName = "ThinhNu",
                        BankAccountNumber = "123"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}