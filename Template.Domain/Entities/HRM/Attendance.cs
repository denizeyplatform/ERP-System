using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;

namespace Template.Domain.Entities.HRM
{
    public class Attendance : BaseEntity
    {
        public int EId;
        public DateTime date;
        public TimeSpan time;
        public bool IsChecked;

    }
}
