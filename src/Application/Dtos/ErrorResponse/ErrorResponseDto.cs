namespace Application.Dtos
{
    /// <summary>
    /// ErrorResponseDto
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>10/07/2021</date>
    public class ErrorResponseDto
    {
        public string Message { get; set; }
        public string ErrorType { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int ErrorCode { get; set; }
        public string UserId { get; set; }
        public string Source { get; set; }
    }
}
