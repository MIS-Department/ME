using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IRepositories
{
    public interface IScheduleRepository : IDefaultRepository<Schedule>, IDisposable
    {  
        Task<IEnumerable<Schedule>> SelectByName(string name);
    }
}
