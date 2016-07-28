using System;
using System.ComponentModel.DataAnnotations;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class EmployeeSchedule : IEmployeeSchedule
    {
        public int EmployeeScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public int ScheduleId { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
