using System;
using System.Collections.Generic;

namespace WS_TexasSales.Models
{
    public partial class CarList
    {
        public CarList()
        {
            CarStok = new HashSet<CarStok>();
        }

        public int CarId { get; set; }
        public int CarTmId { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public string CarColor { get; set; }
        public int? CarDoors { get; set; }
        public int? CarHpMotor { get; set; }

        public virtual Trademark CarTm { get; set; }
        public virtual ICollection<CarStok> CarStok { get; set; }
    }
}
