using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> SelectAll();
        Task<Employee> SelectById(int? id);
        Task<Employee> SelectByEmployeeNumber(string employeeNumber);
    }
}
