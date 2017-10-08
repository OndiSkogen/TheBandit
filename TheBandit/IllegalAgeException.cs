using System;

//Andreas Norberg, 2017
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
