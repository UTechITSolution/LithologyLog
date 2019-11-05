using LithologyLog.Constant;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LithologyLog.Model.Context
{
    public class LithologyLogContext : IdentityDbContext<UserApp,
                                                  ApplicationRole, string,
                                                  IdentityUserClaim<string>,
                                                  ApplicationUserRole,
                                                  IdentityUserLogin<string>,
                                                  IdentityRoleClaim<string>,
                                                  IdentityUserToken<string>>
    {

        public LithologyLogContext(DbContextOptions<LithologyLogContext> options) : base(options)
        {

        }
        public LithologyLogContext()
        {

        }

        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
 


        }
    }
}
