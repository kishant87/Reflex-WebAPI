using System;
using System.Collections.Generic;

namespace Xpanxion.Reflex.API.Contracts.Types
{
    public class Employee : Base
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsGroup { get; set; }
        public string OTP { get; set; }
        public bool IsActive { get; set; }
        public EmployeeRoles Role { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool Rating { get; set; }
        public bool Image { get; set; }
        public List<Device> EmployeeDevice { get; set; } = new List<Device>();

    }
}
