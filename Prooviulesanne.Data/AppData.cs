using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proov.Data;
using Prooviulesanne.Models.Domain;

namespace Prooviulesanne.Data
{
    public class AppData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
                if (!context.Event.Any())
            {
                for (int i = 1; i <= 2; i++)
                {
                    context.Event.Add(
                            new Event
                            {
                                EventName = $"Cinnamon Club {i}",
                                StartTime = DateTime.ParseExact("10/06/2021 20:45:00", "dd/MM/yyyy HH:mm:ss", null),
                                StartingPlace = "UK",
                                Details = "Fancy",
                                Citizens = new List<Citizen>()
                                {
                            new Citizen()
                            {
                                FirstName = $"Alex{i}",
                                LastName = "Kren",
                                IdentificationNumber = 5521312,
                                PaymentType = 0,
                                Details = "Empty"
                            }
                                }
                            });
                    context.Event.Add(
                              new Event
                              {
                                  EventName = $"Rannamaja Pidu {i}",
                                  StartTime = DateTime.ParseExact("15/06/2015 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                                  StartingPlace = "France",
                                  Details = "Fancy",
                                  Enterprises = new List<Enterprise>()
                                  {
                            new Enterprise()
                            {
                                EnterpriseName = $"Uusküla{i}",
                                BusinessIdentificationNumber = 5521312,
                                AttendanceNumber = 3,
                                PaymentType = 0,
                                Details = "Empty"
                            }
                                  }
                              });
                    context.Event.Add(
                                new Event
                                {
                                    EventName = $"Investorite Club {i}",
                                    StartTime = DateTime.ParseExact("30/08/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                                    StartingPlace = "Estonia",
                                    Details = "Fancy",
                                    Enterprises = new List<Enterprise>()                                  
                                    {
                            new Enterprise()
                            {
                                EnterpriseName = $"Tankigon{i}",
                                BusinessIdentificationNumber = 352232,
                                AttendanceNumber = 18,
                                PaymentType = (PaymentType)1,
                                Details = "Empty"
                            }
                                    },
                            Citizens = new List<Citizen>()
                            {
                                new Citizen()
                                {
                                FirstName = $"Ramon{i}",
                                LastName = "Ernits",
                                IdentificationNumber = 5521312,
                                PaymentType = 0,
                                Details = "Empty"
                                }
                              
                            }
                                });
                }
                context.SaveChanges();
            }
        }
    }
}