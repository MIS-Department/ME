using System.Collections.Generic;
using Shared.Models.Helper;

namespace Shared.Models.Interfaces
{
    public interface IReturnStatus<T>
    {
        Status Status { get; set; }
        T ModelSingle { get; set; }
        IEnumerable<T> ModelList { get; set; } 
    }
}
