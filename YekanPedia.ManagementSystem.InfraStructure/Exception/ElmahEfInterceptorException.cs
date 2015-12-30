

namespace YekanPedia.ManagementSystem.InfraStructure.Exception
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ElmahEfInterceptorException : Exception
    {
        public ElmahEfInterceptorException(string message)
            : base(message)
        {
        }

        public ElmahEfInterceptorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ElmahEfInterceptorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
