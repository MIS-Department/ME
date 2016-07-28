using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class TemplateSchedule : ITemplateSchedule
    {
        public int TemplateScheduleId { get; set; }
        public int ScheduleId { get; set; }
        public int TemplateId { get; set; }
    }
}
