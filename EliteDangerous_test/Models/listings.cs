//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EliteDangerous_test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class listings
    {
        public int Id { get; set; }
        public int station_id { get; set; }
        public int commodity_id { get; set; }
        public int supply { get; set; }
        public int buy_price { get; set; }
        public int sell_price { get; set; }
        public Nullable<int> demand { get; set; }
        public Nullable<System.DateTime> collected_at { get; set; }
        public Nullable<int> update_count { get; set; }
    
        public virtual Commodities Commodities { get; set; }
        public virtual Station Station { get; set; }
    }
}
