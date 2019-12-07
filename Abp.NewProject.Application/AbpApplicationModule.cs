using Abp.NewProject.Domain;
using Volo.Abp.Modularity;

namespace Abp.NewProject.Application
{
    [DependsOn(typeof(AbpDomainModule))]
    public class AbpApplicationModule:AbpModule
    {
        
    }
}