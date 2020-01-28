using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliteDangerous_test.Models
{
    public class ViewSystemsSearch
    {
        public string SearchCritere { get; set; }

        public List<Systems> Systems { get; set; }
    }
}