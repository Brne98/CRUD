using Microsoft.EntityFrameworkCore;

namespace ExchangeRate.Api.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<ExchangeRate> ExchangeRates { get; set; }
}