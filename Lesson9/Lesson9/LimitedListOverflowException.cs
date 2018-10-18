using System;
using System.Runtime.Serialization;

namespace Lesson9
{
    class LimitedListOverflowException: ApplicationException
    {
        public LimitedListOverflowException()
        {
        }

        public LimitedListOverflowException(string message) : base(message)
        {
        }

        public LimitedListOverflowException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LimitedListOverflowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
