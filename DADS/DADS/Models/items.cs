namespace DADS
{
    using System;
    using System.Collections.Generic;

    public partial class items
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int damage { get; set; }
        public string description { get; set; }
        public string types { get; set; }

        public virtual player_sheets player_sheet { get; set; }
    }
}