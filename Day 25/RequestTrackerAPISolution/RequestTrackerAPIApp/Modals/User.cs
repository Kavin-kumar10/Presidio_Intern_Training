﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RequestTrackerAPIApp.Modals
{
    public class User
    {
        [Key]
        public int EmployeeId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public string Status { get; set; }

    }
}
