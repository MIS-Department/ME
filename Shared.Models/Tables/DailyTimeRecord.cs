using System;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class DailyTimeRecord : IDailyTimeRecord
    {
        public int DailyTimeRecordId{ get; set; }
        public int? EmployeeId { get; set; }
        public int? TimeCategoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Time { get; set; }
    }
}
