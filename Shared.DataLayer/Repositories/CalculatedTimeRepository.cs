using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Shared.DataLayer.Interfaces;
using Shared.DataLayer.Interfaces.IRepositories;
using Shared.Models.Tables;

namespace Shared.DataLayer.Repositories
{
    public class CalculatedTimeRepository : ICalculatedTimeRepository
    {
        private readonly IDapperContext _dbContext;

        public CalculatedTimeRepository(IDapperContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<CalculatedTime>> SelectAll()
        {
            return await _dbContext.Connection.QueryAsync<CalculatedTime>("CalculatedTimeAll",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<CalculatedTime> SelectById(int? id)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@CalculatedTimeId", id);

            var result = await _dbContext.Connection.QueryAsync<CalculatedTime>("CalculatedTimeSelectById",
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }

        public async Task<int> Insert(CalculatedTime model)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@TimeTypeId", model.TimeTypeId);
            p.Add("@Value", model.Value);
            p.Add("@DailyTimeRecordId", model.DailyTimeRecordId);
            p.Add("@CalculatedId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("CalculatedTimeInsert",
                commandType: CommandType.StoredProcedure);
            return p.Get<int>("@CalculatedId");

        }

        public async Task Delete(int? id)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@CalculatedTimeId", id);

            await _dbContext.Connection.ExecuteAsync("CalculatedTimeDelete", p,
                commandType: CommandType.StoredProcedure);
        }

        public async Task Update(CalculatedTime model)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@CalculatedTimeId", model.CalculatedTimeId);
            p.Add("@TimeTypeId", model.TimeTypeId);
            p.Add("@Value", model.Value);
            p.Add("@DailyTimeRecordId", model.DailyTimeRecordId);

            await _dbContext.Connection.ExecuteAsync("CalculatedTimeUpdate", p,
                commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
