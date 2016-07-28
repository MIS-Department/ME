using System.Collections.Generic;
using Shared.Models.Helper;
using Shared.Models.Tables;

namespace Shared.Models.Interfaces
{
    public interface IEmployeeNotify
    {
        Employee Employee { get; set; }
        bool IsSuspended { get; set; }
        bool IsTimeCheck { get; set; }
        bool IsResign { get; set; }
        IEnumerable<DailyTimeDetails> DailyTimeRecord { get; set; }
        Status Status { get; set; }      
    }
}
