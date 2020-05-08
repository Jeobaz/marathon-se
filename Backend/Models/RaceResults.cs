using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RaceResults
    {
        public int TotalRunners { get; set; }
        public int TotalRunnersFinished { get; set; }
        public double AvgRaceTime { get; set; }
        public List<RegistrationEvent> Runners { get; set; }
    }
}
