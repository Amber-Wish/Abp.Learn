using SqlSugar;
using Volo.Abp.Uow;

namespace Abp.SqlSugar.Domain.Repositories
{
    public class SqlSugarRepository<TConfig>:ISqlSugarRepository, IUnitOfWorkEnabled
        where TConfig: ConnectionConfig
    {

        private readonly ISqlSugarClient _sqlSugarClient;

        private readonly TConfig _sqlConfiguration;

        public SqlSugarRepository(TConfig config)
        {
            _sqlConfiguration = config;
            _sqlSugarClient = new SqlSugarClient(config);

        }

        public ISqlSugarClient GetDbClient()
        {
            return _sqlSugarClient;
        }
    }
}