using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Abp.NewProject.Domain
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class AbpDomainModule: AbpModule
    {

    }
}