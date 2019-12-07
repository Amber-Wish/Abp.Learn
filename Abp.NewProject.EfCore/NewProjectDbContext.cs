using Abp.NewProject.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Abp.NewProject.EfCore
{
    [ConnectionStringName("Default")]
    public class NewProjectDbContext:AbpDbContext<NewProjectDbContext>
    {
        public NewProjectDbContext(DbContextOptions<NewProjectDbContext> options) : base(options)
        {
        }

        public DbSet<TestUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TestUser>(b =>
            {
                b.ToTable("t_test_user");
                b.HasKey(k => k.Id);
            });
        }

    }
}