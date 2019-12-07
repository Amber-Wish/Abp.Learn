using Abp.NewProject.Domain;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.NewProject.EfCore
{
    public class TestUserRepository: EfCoreRepository<NewProjectDbContext,TestUser,long>, ITestUserRepository
    {
        public TestUserRepository(IDbContextProvider<NewProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}