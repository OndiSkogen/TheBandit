using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBandit
{
    class IllegalAgeException : Exception
    {
        public IllegalAgeException()
        {
        }

        public IllegalAgeException(string message) : base(message)
        {
        }

        public IllegalAgeException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
