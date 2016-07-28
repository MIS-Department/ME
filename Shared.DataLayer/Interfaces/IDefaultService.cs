using System.Threading.Tasks;

namespace Shared.DataLayer.Interfaces
{
    public interface IDefaultService<T, in TN>
    {
        Task<T> SelectAll();
        Task<T> SelectById(int? id);
        Task<T> Insert(TN model);
        Task<T> Delete(int? id);
        Task<T> Update(TN model);
    }
}
