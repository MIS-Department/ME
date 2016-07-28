using System;
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
    public class EmployeeScheduleRepository : IEmployeeScheduleRepository
    {
        private readonly IDapperContext _dbContext;

        public EmployeeScheduleRepository(IDapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeSchedule>> SelectAll()
        {
            //_connection = await Connect.OpenAsync();
            return
                await
                    _dbContext.Connection.QueryAsync<EmployeeSchedule>("EmployeeScheduleAll",
                        commandType: CommandType.StoredProcedure);

        }

        public async Task<EmployeeSchedule> SelectById(int? id)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeScheduleId", id);

            var result =
                await
                    _dbContext.Connection.QueryAsync<EmployeeSchedule>("EmployeeScheduleSelectById", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<int> Insert(EmployeeSchedule model)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId", model.EmployeeId);
            p.Add("@ScheduleId", model.ScheduleId);
            p.Add("@Date", model.Date);
            p.Add("@EmployeeScheduleId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await
                _dbContext.Connection.ExecuteAsync("EmployeeScheduleInsert", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("@EmployeeScheduleId");

        }

        public async Task Delete(int? id)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeScheduleId", id);

            await
                _dbContext.Connection.ExecuteAsync("EmployeeScheduleDelete", p, commandType: CommandType.StoredProcedure);
        }

        public async Task Update(EmployeeSchedule model)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeScheduleId", model.EmployeeScheduleId);
            p.Add("@EmployeeId", model.EmployeeId);
            p.Add("@ScheduleId", model.ScheduleId);
            p.Add("@Date", model.Date);

            await
                _dbContext.Connection.ExecuteAsync("EmployeeScheduleUpdates", p,
                    commandType: CommandType.StoredProcedure);

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<IEnumerable<EmployeeSchedule>> SelectByDate(DateTime startTime, DateTime endTime)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@StartDate", startTime);
            p.Add("@EndTime", endTime);

            return
                await
                    _dbContext.Connection.QueryAsync<EmployeeSchedule>("EmployeeScheduleSelectByDate", p,
                        commandType: CommandType.StoredProcedure);


        }

        public async Task<EmployeeSchedule> SelectByScheduleId(int? id)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@ScheduleId", id);

            var result =
                await
                    _dbContext.Connection.QueryAsync<EmployeeSchedule>("EmployeeScheduleSelectByScheduleId", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<EmployeeSchedule> SelectByEmployee(int? id)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId");

            var result =
                await
                    _dbContext.Connection.QueryAsync<EmployeeSchedule>("EmployeeScheduleSelectByEmployee", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }
    }
}
