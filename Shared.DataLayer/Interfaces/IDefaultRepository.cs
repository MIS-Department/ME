using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.DataLayer.Interfaces
{
    public interface IDefaultRepository<T>
    {
        Task<IEnumerable<T>> SelectAll();
        Task<T> SelectById(int? id);
        Task<int> Insert(T model);
        Task Delete(int? id);
        Task Update(T model);
    }
}
