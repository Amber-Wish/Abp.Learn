using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.NewProject.Domain;
using Volo.Abp.Application.Services;

namespace Abp.NewProject.Application
{
    public interface ITestUserAppService:IApplicationService
    {
        Task AddUser(TestUser user);

        Task<List<TestUser>> GetAllUsers();
    }
}