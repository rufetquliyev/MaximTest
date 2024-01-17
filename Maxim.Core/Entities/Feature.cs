using Maxim.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Core.Entities
{
    public class Feature : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? IconUrl { get; set; }
    }
}
