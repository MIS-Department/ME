using System.ComponentModel.DataAnnotations;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class TimeCategory : ITimeCategory
    {
        public int TimeCategoryId { get; set; }

        [Required, Display(Name = "Category")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string TimeCategoryValue { get; set; }
    }
}
