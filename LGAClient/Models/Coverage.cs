using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGAClient.Models
{
    public class Coverage
    {
        public int Id { get; set; }

        public int CoverageName { get; set; }

        public int CoverageGroup { get; set; }

        public int IsPolicyCoverage { get; set; }
    }
}
