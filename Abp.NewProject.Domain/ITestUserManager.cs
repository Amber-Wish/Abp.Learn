using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Abp.NewProject.Domain
{
    public interface ITestUserManager:IDomainService
    {
        Task AddUser(TestUser user);

        Task<List<TestUser>> GetAllUser();
    }
}