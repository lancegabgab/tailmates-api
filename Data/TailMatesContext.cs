using Microsoft.EntityFrameworkCore;

namespace TailMates.Data
{
    public class TailMatesContext : DbContext
    {
        public TailMatesContext(DbContextOptions<TailMatesContext> options)
            : base(options)
        {
        }

    }
}