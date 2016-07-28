using System.Collections.Generic;
using Shared.Models.Helper;
using Shared.Models.Interfaces;
using Shared.Models.Tables;

namespace Shared.Models.DTO
{
    public class DailyTimeRecordDto : IReturnStatus<DailyTimeRecord>
    {
        public Status Status { get; set; }
        public DailyTimeRecord ModelSingle { get; set; }
        public IEnumerable<DailyTimeRecord> ModelList { get; set; }
    }
}
