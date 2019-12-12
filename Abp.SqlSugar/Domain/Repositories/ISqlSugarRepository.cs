using SqlSugar;
using Volo.Abp.DependencyInjection;

namespace Abp.SqlSugar.Domain.Repositories
{
    public interface ISqlSugarRepository: ITransientDependency
    {
        ISqlSugarClient GetDbClient();
    }
}