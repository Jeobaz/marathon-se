using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RegEventWithRanks : RegistrationEvent
    {
        public int GeneralRank { get; set; }
        public int CatRank { get; set; }
    }
}
