using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_Management.Domain.Common;

namespace HR_Management.Domain
{
    public class LeaveType : BaseDomainEntity
    {
       
        public string Name { get; set; }
        public int DefaultDay { get; set; }

    }
}
