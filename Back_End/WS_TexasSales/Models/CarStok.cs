using System;
using System.Collections.Generic;

namespace WS_TexasSales.Models
{
    public partial class CarStok
    {
        public int CsId { get; set; }
        public int CsCarId { get; set; }
        public decimal CsInitPrice { get; set; }

        public virtual CarList CsCar { get; set; }
    }
}
