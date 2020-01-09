using Microsoft.EntityFrameworkCore;

namespace Command.Models
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }


    }
}