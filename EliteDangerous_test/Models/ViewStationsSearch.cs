using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliteDangerous_test.Models
{
    public class ViewStationsSearch
    {
        public string SearchCritere { get; set; }

        public List<Station> Stations { get; set; }
    }
}