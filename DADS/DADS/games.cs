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
    
    public class games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public games()
        {
            this.maps = new HashSet<maps>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    
        public virtual users players { get; set; }
        public virtual player_sheets player_sheets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<maps> maps { get; set; }
        public virtual users dm { get; set; }
    }
}
