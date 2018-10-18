using System;
using System.Runtime.Serialization;

namespace Lesson9
{
    class IncorrectInputException: ApplicationException
    {
        public IncorrectInputException()
        {
        }

        public IncorrectInputException(string message) : base(message)
        {
        }

        public IncorrectInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
