using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAlarm.Exceptions
{
    public class BeforeCurrentDateException : Exception
    {
        public BeforeCurrentDateException(string message) : base(message) { }
        public BeforeCurrentDateException() : base() { } // optional
        public BeforeCurrentDateException(string message, Exception inner) : base(message, inner) { } // optional
    }
}
