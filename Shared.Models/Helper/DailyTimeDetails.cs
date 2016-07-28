using System;
using Shared.Models.Interfaces;

namespace Shared.Models.Helper
{
    public class DailyTimeDetails : IDailyTimeDetails
    {
        public DateTime DateCreated { get; set; }
        public DateTime Time { get; set; }
        public string TimeCategoryValue { get; set; }
    }
}
