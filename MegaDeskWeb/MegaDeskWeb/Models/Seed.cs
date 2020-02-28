using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDeskWeb.Data;
using System;
using System.Linq;

namespace MegaDeskWeb.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskWebContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskWebContext>>()))
            {
                //look for any data
                if (context.Quote.Any())
                {
                    return; //DB seeded no quotes added
                }

                context.Quote.AddRange(
                    new Quote
                    {
                        quoteDate = DateTime.Parse("2020-02-02"),
                        firstname = "Hans",
                        lastname = "Solo",
                        width = 48,
                        depth = 28,
                        drawers = 5,
                        surfaceMaterial = "Oak",
                        rushDelivery = 0,
                        total = 1802
                    },

                    new Quote
                    {
                        quoteDate = DateTime.Parse("2020-01-27"),
                        firstname = "Luke",
                        lastname = "Skywalker",
                        width = 36,
                        depth = 30,
                        drawers = 2,
                        surfaceMaterial = "Pine",
                        rushDelivery = 3,
                        total = 1500
                    },

                    new Quote
                    {
                        quoteDate = DateTime.Parse("2020-02-29"),
                        firstname = "Leia",
                        lastname = "Organa",
                        width = 24,
                        depth = 18,
                        drawers = 1,
                        surfaceMaterial = "Rosewood",
                        rushDelivery = 5,
                        total = 1022
                    },

                    new Quote
                    {
                        quoteDate = DateTime.Parse("2020-01-01"),
                        firstname = "Darth",
                        lastname = "Vader",
                        width = 96,
                        depth = 48,
                        drawers = 7,
                        surfaceMaterial = "Oak",
                        rushDelivery = 7,
                        total = 5254
                    },

                    new Quote
                    {
                        quoteDate = DateTime.Parse("2019-12-11"),
                        firstname = "Minch",
                        lastname = "Yoda",
                        width = 24,
                        depth = 12,
                        drawers = 0,
                        surfaceMaterial = "Veneer",
                        rushDelivery = 0,
                        total = 613
                    }
                );
                context.SaveChanges(); //quotes added

            }
        }
    }
}

