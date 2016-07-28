using System;

namespace Shared.Models.Interfaces
{
    public interface IDailyTimeDetails
    {
        DateTime DateCreated { get; set; }
        DateTime Time { get; set; }
        string TimeCategoryValue { get; set; }
    }
}
