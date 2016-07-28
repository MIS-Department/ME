using System;

namespace Shared.Models.Interfaces
{
    public interface IEmployeeSchedule
    {
        int EmployeeScheduleId { get; set; }
        int EmployeeId { get; set; }
        int ScheduleId { get; set; }
        DateTime Date { get; set; }
    }
}
