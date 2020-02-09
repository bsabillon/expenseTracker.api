namespace expenseTracker.api.data{
using   Microsoft.EntityFrameworkCore;
using expenseTracker.api.models;
    public class DataContext : DbContext
    {
    public DbSet<Category> Categories { get; set; }


    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    }

}