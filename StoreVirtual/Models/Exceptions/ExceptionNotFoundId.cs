using System;
using System.Runtime.Serialization;

namespace StoreVirtual.Models.Exceptions
{
    [Serializable]
    internal class ExceptionNotFoundId : Exception
    {
        public ExceptionNotFoundId()
        {
        }

        public ExceptionNotFoundId(string message) : base(message)
        {
        }

        public ExceptionNotFoundId(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptionNotFoundId(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}