using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.NewProject.Domain;
using Volo.Abp.Application.Services;

namespace Abp.NewProject.Application
{
    public class TestUserAppService:ApplicationService,ITestUserAppService
    {
        private readonly ITestUserManager _testUserManager;

        public TestUserAppService(ITestUserManager testUserManager)
        {
            _testUserManager = testUserManager;
        }

        public async Task AddUser(TestUser user)
        {
            await _testUserManager.AddUser(user);
        }

        public async Task<List<TestUser>> GetAllUsers()
        {
            return await _testUserManager.GetAllUser();
        }
    }
}