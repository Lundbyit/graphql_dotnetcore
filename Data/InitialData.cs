using graphql_dotnetcore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnetcore.Data
{
    public static class InitialData
    {
        public static void Seed(this BookStoreDbContext dbContext)
        {
            if (!dbContext.Authors.Any())
            {
                dbContext.Authors.Add(new Author
                {
                    Name = "J.R.R. Tolkien",
                    Genre = GenreType.Fantasy,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Name = "Ringens Brödraskap",
                        },
                        new Book
                        {
                            Name = "Sagan om de två tornen",
                        },
                        new Book
                        {
                            Name = "Konungens återkomst",
                        }
                    }
                });

                dbContext.Add(new Author
                {
                    Name = "Douglas Adams",
                    Genre = GenreType.SciFi,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Name = "Liftarens guide till galaxen",
                        }
                    }
                });

                dbContext.Add(new Author
                {
                    Name = "Walter Isaacson",
                    Genre = GenreType.Biography,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Name = "Benjamin Franklin: An American Life",
                        },
                        new Book
                        {
                            Name = "Steve Jobs",
                        }
                    }
                });

                dbContext.Authors.Add(new Author
                {
                    Name = "Robert Jordan",
                    Genre = GenreType.Fantasy,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Name = "De dödas stad",
                        },
                        new Book
                        {
                            Name = "Tidens hjul",
                        }
                    }
                });

                dbContext.SaveChanges();
            }
        }
    }
}
