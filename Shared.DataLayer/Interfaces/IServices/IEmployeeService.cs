using Shared.Models.DTO;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IServices
{
    public interface IEmployeeService : IDefaultService<EmployeeDto, Employee>
    {
    }
}
