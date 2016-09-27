using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinalProject.Data;
using System;
using System.Linq;

namespace FinalProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.CashAccount.Any())
                {
                    return;   // DB has been seeded
                }

                context.CashAccount.AddRange(
                    new CashAccount
                    {
                        AccountDescription = "ACB Bank",
                        BankName = "ThinhLe",
                        BankAccountNumber = "051.100.389.1938"
                    },

                    new CashAccount
                    {
                        AccountDescription = "OCEAN Bank",
                        BankName = "DatNgo",
                        BankAccountNumber = "751.130.319.4316"
                    },

                    new CashAccount
                    {
                        AccountDescription = "Viettin Bank",
                        BankName = "BinhBo",
                        BankAccountNumber = "321.130.568.1954"
                    },

                    new CashAccount
                    {
                        AccountDescription = "ACB Bank",
                        BankName = "NguyenTruong",
                        BankAccountNumber = "052.900.679.2422"
                    },

                    new CashAccount
                    {
                        AccountDescription = "Dong A Bank",
                        BankName = "NgocQuy",
                        BankAccountNumber = "751.120.389.351"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}