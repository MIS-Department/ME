using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Shared.DataLayer.Interfaces;
using Shared.DataLayer.Interfaces.IRepositories;
using Shared.DataLayer.Util;
using Shared.Models.Helper;
using Shared.Models.Tables;

namespace Shared.DataLayer.Repositories
{
    public class DailyTimeRecordRepository : IDailyTimeRecordRepository
    {
        private readonly IDapperContext _dbContext;

        public DailyTimeRecordRepository(IDapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DailyTimeRecord>> SelectAll()
        {

            //_connection = await Connect.OpenAsync();
            return
                await
                    _dbContext.Connection.QueryAsync<DailyTimeRecord>("DailyTimeRecordAll",
                        commandType: CommandType.StoredProcedure);


        }

        public async Task<DailyTimeRecord> SelectById(int? id)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@DailyTimeRecordId", id);

            var result =
                await
                    _dbContext.Connection.QueryAsync<DailyTimeRecord>("DailyTimeRecordSelectById", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<int> Insert(DailyTimeRecord model)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId", model.EmployeeId);
            p.Add("@TimeCategoryId", model.TimeCategoryId);
            p.Add("@DateCreated", model.DateCreated);
            p.Add("@Time", model.Time);
            p.Add("@DailyTimeRecordId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("DailyTimeRecordInsert", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("@DailyTimeRecordId");

        }

        public async Task Delete(int? id)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@DailyTimeRecordId", id);
            await _dbContext.Connection.ExecuteAsync("DailyTimeRecordDelete", p, commandType: CommandType.StoredProcedure);

        }

        public async Task Update(DailyTimeRecord model)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@DailyTimeRecordId", model.DailyTimeRecordId);
            p.Add("@EmployeeId", model.EmployeeId);
            p.Add("@TimeCategoryId", model.TimeCategoryId);
            p.Add("@DateCreated", model.DateCreated);
            p.Add("@Time", model.Time);
            await _dbContext.Connection.ExecuteAsync("DailyTimeRecordUpdate", p, commandType: CommandType.StoredProcedure);

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<DailyTimeRecord> SelectByEmployeeId(int? id)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId", id);
            var result =
                await
                    _dbContext.Connection.QueryAsync<DailyTimeRecord>("DailyTimeRecordSelectByEmployeeId", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<int?> SelectByEmployeeNumber(string number)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeNumber", number);

            var result =
                await
                    _dbContext.Connection.QueryAsync<int?>("DailyTimeRecordEmployeeNumber", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<IEnumerable<DailyTimeRecord>> SelectEmployeeIdDateCreated(int? id, DateTime startDate, DateTime endDate)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId", id);
            p.Add("@StartDate", startDate);
            p.Add("@EndDate", endDate);

            return
                await
                    _dbContext.Connection.QueryAsync<DailyTimeRecord>("DailyTimeRecordSelectByEmployeeIdDateCreated", p,
                        commandType: CommandType.StoredProcedure);

        }

        public async Task<Notification> GetEmployeeNotification(int? employeeId, int? timeCategoryId)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId", employeeId);
            p.Add("@TimeCategoryId", timeCategoryId);

            var multi =
                await
                    _dbContext.Connection.QueryMultipleAsync("EmployeeCheckTimeCategory", p, commandType: CommandType.StoredProcedure);

            Notification notify = new Notification
            {
                IsTimeCheck = multi.ReadAsync<bool>().Result.FirstOrDefault(),
                IsSuspended = multi.ReadAsync<bool>().Result.FirstOrDefault(),
                IsResign = multi.ReadAsync<bool>().Result.FirstOrDefault()
            };


            return notify;

        }

        public async Task<IEnumerable<DailyTimeDetails>> GetDailyTimeRecordTopFive(int? employeeId)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId", employeeId);

            return
                await
                    _dbContext.Connection.QueryAsync<DailyTimeDetails>("DailyTimeRecordSelectByEmplyeeIdTopFive", p,
                        commandType: CommandType.StoredProcedure);

        }
    }
}
