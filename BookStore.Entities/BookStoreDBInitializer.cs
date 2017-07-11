using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using BookStore.Entities.Migrations;

namespace BookStore.Entities
{
    public class BookStoreDBInitializer: CreateDatabaseIfNotExists<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            base.Seed(context);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());

            List<Author> authors = new List<Author>
            {
                new Author
                {
                    Name = "Stephen King",
                    BirthDate = DateTime.ParseExact("09-21-1947", "MM-dd-yyyy", CultureInfo.InvariantCulture)
                },
                new Author
                {
                    Name = "George Martin",
                    BirthDate = DateTime.ParseExact("09-20-1948", "MM-dd-yyyy", CultureInfo.InvariantCulture)
                }
            };

            List<Book> books = new List<Book>
            {
                new Book
                {
                    Name = "The Shining",
                    Year = 1977,
                    Price = 99,
                    Author = authors[0]
                },
                new Book
                {
                    Name = "Carrie",
                    Year = 1974,
                    Price = 89,
                    Author = authors[0]
                },
                new Book
                {
                    Name = "Green mile",
                    Year = 1996,
                    Price = 79,
                    Author = authors[0]
                },
                new Book
                {
                    Name = "Under the Dome",
                    Year = 2009,
                    Price = 100,
                    Author = authors[0]
                },
                new Book
                {
                    Name = "A Game of Thrones",
                    Year = 1996,
                    Price = 90,
                    Author = authors[1]
                },
                new Book
                {
                    Name = "A Clash of Kings",
                    Year = 1998,
                    Price = 95,
                    Author = authors[1]
                },
                new Book
                {
                    Name = "A Storm of Swords",
                    Year = 2000,
                    Price = 100,
                    Author = authors[1]
                }
            };

            foreach (var item in books)
            {
                context.Books.Add(item);
            }
            foreach (var item in authors)
            {
                context.Authors.Add(item);
            }
            context.SaveChanges();
        }
    }
}
