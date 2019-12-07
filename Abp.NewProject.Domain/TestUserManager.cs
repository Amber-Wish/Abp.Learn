using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Abp.NewProject.Domain
{
    public class TestUserManager:DomainService,ITestUserManager
    {
        private readonly ITestUserRepository _testUserRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TestUserManager(ITestUserRepository testUserRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _testUserRepository = testUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task AddUser(TestUser user)
        {
            using (var uow = _unitOfWorkManager.Begin(true))
            {
                await _testUserRepository.InsertAsync(user);
                uow.Complete();
            }
        }

        public async Task<List<TestUser>> GetAllUser()
        {
            var allUsers = await _testUserRepository.GetListAsync();
            return allUsers;
        }
    }
}