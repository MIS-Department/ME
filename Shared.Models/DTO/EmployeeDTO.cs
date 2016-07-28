using System.Collections.Generic;
using Shared.Models.Helper;
using Shared.Models.Interfaces;
using Shared.Models.Tables;

namespace Shared.Models.DTO
{
    public class EmployeeDto : IReturnStatus<Employee>
    {
        public Status Status { get; set; }
        public Employee ModelSingle { get; set; }
        public IEnumerable<Employee> ModelList { get; set; }
    }
}
