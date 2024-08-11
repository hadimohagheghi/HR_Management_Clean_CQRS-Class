using HR_Management.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto 
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
