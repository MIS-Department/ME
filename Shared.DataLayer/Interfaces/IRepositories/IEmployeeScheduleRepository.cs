using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IRepositories
{
    public interface IEmployeeScheduleRepository : IDefaultRepository<EmployeeSchedule>, IDisposable
    {   
        Task<IEnumerable<EmployeeSchedule>> SelectByDate(DateTime startTime, DateTime endTime);
        Task<EmployeeSchedule> SelectByScheduleId(int? id);
        Task<EmployeeSchedule> SelectByEmployee(int? id);
    }
}
