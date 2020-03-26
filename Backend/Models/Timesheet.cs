using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Timesheet
    {
        public int TimesheetId { get; set; }
        public int StaffId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public decimal? PayAmount { get; set; }
    }
}
