using System;
using System.ComponentModel.DataAnnotations;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class Template : ITemplate
    {
        public int TemplateId { get; set; }

        [Required, Display(Name = "Code")]
        public string TemplateCode { get; set; }

        [Required, Display(Name = "Description")]
        public string Description { get; set; }

        [Required, Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required, Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}
