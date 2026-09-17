using biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace biblioteka.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
}