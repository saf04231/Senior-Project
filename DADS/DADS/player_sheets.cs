//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DADS
{
    using System;
    using System.Collections.Generic;
    
    public partial class player_sheets
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int[] stats { get; set; }
        public string spells { get; set; }
        public string notes { get; set; }

        public virtual items weapon1 { get; set; }
        public virtual items weapon2 { get; set; }
        public virtual items weapon3 { get; set; }

        public virtual users user { get; set; }
        public virtual games games { get; set; }
    }
}