using Newtonsoft.Json;
using System;

namespace Application.Commons
{
    public class Response<T> : BaseMessage
    {
        public Response() : base()
        {
            this.SetCorrelation(base._correlationId);
        }

        private Guid correlation;

        public Guid GetCorrelation()
        {
            return correlation;
        }

        private void SetCorrelation(Guid value)
        {
            correlation = value;
        }

        public bool IsSuccess { get; set; } = true;
        public string ReturnMessage { get; set; }
        public T Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
