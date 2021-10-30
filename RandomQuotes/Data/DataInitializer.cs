using Microsoft.EntityFrameworkCore;
using RandomQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomQuotes.Data
{
    internal static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var quotes = new List<QuotesViewModel>
            {
                 new QuotesViewModel
                 {
                     Id = 1,
                     Quote = "Do not despise the days of your little beginning",
                     Author = "Annonymous",
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },

                 new QuotesViewModel
                 {
                     Id = 2,
                     Quote = "Just flow with the moment",
                     Author = "Annonymous",
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },

                 new QuotesViewModel
                 {
                     Id = 3,
                     Quote = "The end will justify the beginning",
                     Author = "Annonymous",
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 
            };
            modelBuilder.Entity<QuotesViewModel>().HasData(quotes);
        }
    }
}
