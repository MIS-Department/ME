using System;
using System.Collections.Generic;
using Shared.Models.Helper;
using Shared.Models.Interfaces;

namespace Shared.Models.DTO
{
    public class IdentityDto : IReturnStatus<Int32>
    {
        public Status Status { get; set; }
        public int ModelSingle { get; set; }
        public IEnumerable<int> ModelList { get; set; }
    }
}
