using MannariEnterprises.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }
    public DbSet<StudentLogin>Logins{get;set;}
    public DbSet<Category> Categories{get;set;}
    public DbSet<Product>Products{get;set;}
    
}