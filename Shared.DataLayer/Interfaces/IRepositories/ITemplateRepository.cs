using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IRepositories
{
    public interface ITemplateRepository : IDefaultRepository<Template>, IDisposable
    {     
        Task<IEnumerable<Template>> SelectByDescription(string description);
        Task<IEnumerable<Template>> SelectByDate(DateTime startTime, DateTime endTime);
        Task<int> TemplateGetIdentity();
    }
}
