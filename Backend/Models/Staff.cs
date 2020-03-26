using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public byte PostionId { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }

        public virtual Position Postion { get; set; }
    }
}
