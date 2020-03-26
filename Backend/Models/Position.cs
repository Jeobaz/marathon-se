using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Position
    {
        public Position()
        {
            Staff = new HashSet<Staff>();
        }

        public byte PositionId { get; set; }
        public string PositionName { get; set; }
        public string PositionDescription { get; set; }
        public decimal Payrate { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
