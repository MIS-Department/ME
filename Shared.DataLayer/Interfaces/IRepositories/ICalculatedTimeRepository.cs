using System;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IRepositories
{
    public interface ICalculatedTimeRepository : IDefaultRepository<CalculatedTime>, IDisposable
    {         
    }
}
