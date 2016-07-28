using System.ComponentModel.DataAnnotations;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class Schedule : ISchedule
    {
        public int ScheduleId { get; set; }

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "Schedule name must have atleast 5 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }
    }
}
