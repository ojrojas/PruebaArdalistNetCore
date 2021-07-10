using System;

namespace Application.Commons
{
    /// <summary>
    /// Correlation id request
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>10/07/2021</date>
    public abstract class BaseMessage
    {
        protected Guid _correlationId = Guid.NewGuid();
        public Guid CorrelationId() => _correlationId;
    }
}
