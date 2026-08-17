using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TailMates.Models;

namespace TailMates.Data
{
    public class TailmatesContext : IdentityDbContext<User>
    {
        public TailmatesContext(
            DbContextOptions<TailmatesContext> options)
            : base(options)
        {
        }

    }

}