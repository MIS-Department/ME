using System;

namespace Shared.Models.Interfaces
{
    public interface IDailyTimeRecord
    {
        int DailyTimeRecordId { get; set; }
        int? EmployeeId { get; set; }
        int? TimeCategoryId { get; set; }
        DateTime DateCreated { get; set; }
        DateTime Time { get; set; }
    }
}
