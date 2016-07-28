using System.Collections.Generic;
using Shared.Models.Helper;
using Shared.Models.Interfaces;
using Shared.Models.Tables;

namespace Shared.Models.DTO
{
    public class EmployeeNotifyDto : IEmployeeNotify
    {
        public Employee Employee { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsTimeCheck { get; set; }
        public bool IsResign { get; set; }
        public IEnumerable<DailyTimeDetails> DailyTimeRecord { get; set; }
        public Status Status { get; set; }
    }
}
