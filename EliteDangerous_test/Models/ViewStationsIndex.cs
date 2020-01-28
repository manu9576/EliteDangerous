using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliteDangerous_test.Models
{
    public class ViewStationsIndex
    {
        public IEnumerable<EliteDangerous_test.Models.Station> Stations { get; set; }

        public int StationCount { get; set; }
    }
}