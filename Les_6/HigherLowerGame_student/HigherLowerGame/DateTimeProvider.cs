using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public interface IDate
    {
        public DateTime Today { get; }
        public DateTime Now { get; }
    }

    internal class DateTimeProvider : IDate
    {
        public DateTime Today => DateTime.Today;
        public DateTime Now => DateTime.Now;
    }
}
