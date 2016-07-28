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
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IDapperContext _dbContext;

        public ScheduleRepository(IDapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Schedule>> SelectAll()
        {
            //_connection = await Connect.OpenAsync();
            return
                await
                    _dbContext.Connection.QueryAsync<Schedule>("ScheduleAll", commandType: CommandType.StoredProcedure);
        }

        public async Task<Schedule> SelectById(int? id)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@ScheduleId", id);
            var result =
                await
                    _dbContext.Connection.QueryAsync<Schedule>("ScheduleSelectById", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> Insert(Schedule model)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@Name", model.Name);
            p.Add("@ScheduleId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("ScheduleInsert", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("@ScheduleId");
        }

        public async Task Delete(int? id)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@ScheduleId", id);

            await _dbContext.Connection.ExecuteAsync("ScheduleDelete", p, commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Schedule model)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@ScheduleId", model.ScheduleId);
            p.Add("@Name", model.Name);

            await _dbContext.Connection.ExecuteAsync("ScheduleUpdate", p, commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<IEnumerable<Schedule>> SelectByName(string name)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@Name", name);
            return
                await
                    _dbContext.Connection.QueryAsync<Schedule>("ScheduleSelectByName", p,
                        commandType: CommandType.StoredProcedure);
        }
    }
}
