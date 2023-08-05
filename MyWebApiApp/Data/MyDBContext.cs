using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options): base(options) { }

        public DbSet<HangHoa> HangHoas { get; set;}
        public DbSet<Loai> Loais { get; set;}
    }
}
