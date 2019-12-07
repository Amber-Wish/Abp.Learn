using Abp.NewProject.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Abp.NewProject.EfCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule))]
    public class AbpEfCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NewProjectDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories();
                options.AddRepository<TestUser, TestUserRepository>();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also ABPTestMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}