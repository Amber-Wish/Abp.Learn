using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using Volo.Abp.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Abp.SqlSugar
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class AbpSqlSugarModule:AbpModule
    {
    }
}