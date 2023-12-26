using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewHMS.Models;

namespace NewHMS.Data
{
    public class DatabaseContext:IdentityDbContext<ApplicationUser>
    {
        //constructeur
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        
        }

    }
}
