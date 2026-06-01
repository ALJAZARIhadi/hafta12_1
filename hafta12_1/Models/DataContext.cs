using Microsoft.EntityFrameworkCore;

namespace hafta12_1.Models
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Register> Registers { get; set; }
      
    }
}
