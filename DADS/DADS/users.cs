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
    using System.Collections;
    using System.Collections.Generic;

    public partial class users : IEnumerable<games>
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    
        public virtual games gameList { get; set; }
        public virtual player_sheets player_sheets { get; set; }
        public virtual games game { get; set; }

        IEnumerator<games> IEnumerable<games>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}
