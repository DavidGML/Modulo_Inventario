using System;
using System.Collections.Generic;

namespace WS_TexasSales.Models
{
    public partial class Trademark
    {
        public Trademark()
        {
            CarList = new HashSet<CarList>();
        }

        public int TmId { get; set; }
        public string TmName { get; set; }

        public virtual ICollection<CarList> CarList { get; set; }
    }
}
