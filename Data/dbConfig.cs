using BookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace NameSpace.Data;

    public class dbConfig:DbContext
    
{
    public dbConfig(DbContextOptions<dbConfig> options) :base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
}