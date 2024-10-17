using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTip.Models
{
    public class Shift
    {
        private DateTime startTime;
        private DateTime endTime;

        public Shift(DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public decimal ShiftDurationInHours()
        {
            return (decimal)(endTime - startTime).TotalHours;
        }
    }
}
