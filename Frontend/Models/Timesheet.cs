using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Timesheet
    {
        [Key]
        public int TimesheetId { get; set; }
        public int StaffId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDateTime { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? PayAmount { get; set; }
    }
}
