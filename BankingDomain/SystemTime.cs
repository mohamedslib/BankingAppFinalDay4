using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDomain
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
            // Quote: The only way to deal with untestable code is to kick it to the corner and not
            // use it until it learns to play nice - Jeremy Miller.
        }
    }
}
