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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDapperContext _dbContext;

        public EmployeeRepository(IDapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> SelectAll()
        {

            //_connection = await Connect.OpenAsync();
            return
                await
                    _dbContext.Connection.QueryAsync<Employee>("EmployeeSelectAll",
                        commandType: CommandType.StoredProcedure);

        }

        public async Task<Employee> SelectById(int? id)
        {
            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeId", id);

            var result = await _dbContext.Connection.QueryAsync<Employee>("EmployeeSelectById", p,
                commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }

        public async Task<Employee> SelectByEmployeeNumber(string employeeNumber)
        {

            //_connection = await Connect.OpenAsync();
            var p = new DynamicParameters();

            p.Add("@EmployeeNumber", employeeNumber);

            var result =
                await
                    _dbContext.Connection.QueryAsync<Employee>("EmployeeSelectByEmployeeNumber", p,
                        commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();


        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
