using Application.Data;
using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.TestApi.SeedContext
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context,
           ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!await context.TypeIdentifications.AnyAsync())
                {
                    await context.TypeIdentifications.AddRangeAsync(
                        GetTypeIdentificationConfigure());

                    await context.SaveChangesAsync();
                }

                if (!await context.Users.AnyAsync())
                {
                    await context.Users.AddRangeAsync(
                        GetUserConfigure());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AppDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<User> GetUserConfigure()
        {
            return new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name ="Miguel",
                    LastName ="Urbano",
                    TypeIdentificationId = "974beb4d-1717-4440-bb71-8a303aa661ea",
                    Identification = "123322445",
                    CreatedBy = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    Password = "Abc12345#",
                    Email ="miguel@corre.com",
                    State = true
                },
                 new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name ="Sonia",
                    LastName ="Castrillon",
                    TypeIdentificationId ="d3535230-c282-4cc1-a641-9e690c5388ab",
                    Identification = "448789987",
                    CreatedBy = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    Password = "Abc12345#",
                    Email ="sonian@castrillon.com",
                    State = true
                }
            };
        }

        private static IEnumerable<TypeIdentification> GetTypeIdentificationConfigure()
        {
            return new List<TypeIdentification>()
            {
                new TypeIdentification
                {
                    Id = "9f090d22-d983-44af-8a24-a6350c0f74f7",
                    CreatedBy = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    State= true,
                    Description ="Cedula de ciudadania"

                },
                 new TypeIdentification
                {
                    Id = "1e37c543-5610-4885-97ea-ba509faf0db6",
                    CreatedBy = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    State= true,
                    Description ="Tarjeta de Identidad"

                },
            };
        }
    }
}
