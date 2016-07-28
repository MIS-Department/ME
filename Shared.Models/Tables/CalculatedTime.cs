using System;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class CalculatedTime : ICalculatedTime
    {
        public int CalculatedTimeId { get; set; }
        public int TimeTypeId { get; set; }
        public DateTime Value { get; set; }
        public int DailyTimeRecordId { get; set; }
    }
}
