using Newtonsoft.Json;

namespace Application.Commons
{
    public class Response<T>
    {
        public bool Success { get; set; } = true;
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
