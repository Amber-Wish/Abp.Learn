using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.NewProject.Application;
using Abp.NewProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.NewProject.Service.Controllers
{
    [Route("[controller]")]
    [Produces("application/json", new string[] { })]
    public class UserController : AbpController
    {
        private readonly ITestUserAppService _testUserAppService;

        public UserController(ITestUserAppService testUserAppService)
        {
            _testUserAppService = testUserAppService;
        }

        [HttpGet("Get")]
        public async Task<List<TestUser>> GetAsync()
        {
            return await _testUserAppService.GetAllUsers();
        }

        [HttpPost("AddUser")]
        public async Task AddUserAsync(TestUser user)
        { 
            await _testUserAppService.AddUser(user);
        }



    }
}