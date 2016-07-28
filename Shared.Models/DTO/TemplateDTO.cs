using System.Collections.Generic;
using Shared.Models.Helper;
using Shared.Models.Interfaces;
using Shared.Models.Tables;

namespace Shared.Models.DTO
{
    public class TemplateDto : IReturnStatus<Template>
    {
        public Status Status { get; set; }
        public Template ModelSingle { get; set; }
        public IEnumerable<Template> ModelList { get; set; }
    }
}
