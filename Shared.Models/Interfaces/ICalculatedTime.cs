using System;

namespace Shared.Models.Interfaces
{
    public interface ICalculatedTime
    {
        int CalculatedTimeId { get; set; }
        int TimeTypeId { get; set; }
        DateTime Value { get; set; }
        int DailyTimeRecordId { get; set; }
    }
}
