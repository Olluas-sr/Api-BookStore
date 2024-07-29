using Microsoft.EntityFrameworkCore;

namespace e_comerceAPIs.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option)
            :base(option)
        { }

        public DbSet<Produto> todoProducts { get; set; }
    }
}
