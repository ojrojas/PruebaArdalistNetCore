using System;

namespace Application.Entities
{
    /// <summary>
    /// ErrorResponse Middleware component
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class ErrorResponse
    {
        public Guid Id { get; set; }
        public string StactTrace { get; set; }
        public string Message { get; set; }
        public string ErrorType { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int ErrorCode { get; set; }
        public Guid UserId { get; set; }
        public string Source { get; set; }
    }
}
