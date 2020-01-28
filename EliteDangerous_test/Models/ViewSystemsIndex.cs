using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliteDangerous_test.Models
{
    public class ViewSystemsIndex
    {
        public IEnumerable<EliteDangerous_test.Models.Systems> Systems {get; set; }

        public int SystemCount { get; set; }
    }
}