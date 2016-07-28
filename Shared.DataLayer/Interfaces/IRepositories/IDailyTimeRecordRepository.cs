using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models.Helper;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IRepositories
{
    public interface IDailyTimeRecordRepository : IDefaultRepository<DailyTimeRecord>, IDisposable
    {  
        Task<DailyTimeRecord> SelectByEmployeeId(int? id);
        Task<int?> SelectByEmployeeNumber(string number);
        Task<IEnumerable<DailyTimeRecord>> SelectEmployeeIdDateCreated(int? id, DateTime startDate, DateTime endDate);
        Task<Notification> GetEmployeeNotification(int? employeeId, int? timeCategoryId);
        Task<IEnumerable<DailyTimeDetails>> GetDailyTimeRecordTopFive(int? employeeId);
    }
}
