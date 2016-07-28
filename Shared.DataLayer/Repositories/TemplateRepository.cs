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
    public class TemplateRepository : ITemplateRepository
    {
        private readonly IDapperContext _dbContext;

        public TemplateRepository(IDapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Template>> SelectAll()
        {
            //_connection = await Connect.OpenAsync();
            return
                await
                    _dbContext.Connection.QueryAsync<Template>("TemplateSelectAll",
                        commandType: CommandType.StoredProcedure);
        }

        public async Task<Template> SelectById(int? id)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@TemplateId", id);
            var result =
                await
                    _dbContext.Connection.QueryAsync<Template>("TemplateSelectById", p,
                        commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> Insert(Template model)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@TemplateCode", model.TemplateCode);
            p.Add("@Description", model.Description);
            p.Add("@StartTime", model.StartTime);
            p.Add("@EndTime", model.EndTime);
            p.Add("@TemplateId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("TemplateInsert", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("@TemplateId");
        }

        public async Task Delete(int? id)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@TemplateId", id);

            await _dbContext.Connection.ExecuteAsync("TemplateDelete", p, commandType: CommandType.StoredProcedure);

        }

        public async Task Update(Template model)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@TemplateId", model.TemplateId);
            p.Add("@TemplateCode", model.TemplateCode);
            p.Add("@Description", model.Description);
            p.Add("@StartTime", model.StartTime);
            p.Add("@EndTime",model.EndTime);

            await _dbContext.Connection.ExecuteAsync("TemplateUpdate", p, commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<IEnumerable<Template>> SelectByDescription(string description)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@Description", description);

            return
                await
                    _dbContext.Connection.QueryAsync<Template>("TemplateSelectByDescription", p,
                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Template>> SelectByDate(DateTime startTime, DateTime endTime)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@StartTime", startTime);
            p.Add("@EndTime", endTime);

            return
                await
                    _dbContext.Connection.QueryAsync<Template>("SelectByStartEnd", p,
                        commandType: CommandType.StoredProcedure);
        }

        public async Task<int> TemplateGetIdentity()
        {
            var p = new DynamicParameters();

            p.Add("@TemplateId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("TemplateGetIdentity", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("@TemplateId");
        }
    }
}
