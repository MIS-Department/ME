using System.ComponentModel.DataAnnotations;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class TimeType : ITimeType
    {
        public int TimeTypeId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }
    }
}
