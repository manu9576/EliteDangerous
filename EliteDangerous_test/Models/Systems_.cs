using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EliteDangerous_test.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Systems
    {
        public string XYZ
        {
            get
            {
                return (this.xyz.XCoordinate.ToString() + " : " +
                    this.xyz.YCoordinate.ToString() + " : " +
                    this.xyz.Elevation.ToString() );
            }

        }
        
        public IEnumerable<Systems> GetSystems(double dist)
        {

            EliteDangerousEntities db = new EliteDangerousEntities();


            return db.Systems.Where(s => s.xyz.Distance(this.xyz) < dist);


        }
    }
}