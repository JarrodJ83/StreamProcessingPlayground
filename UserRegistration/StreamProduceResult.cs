using System;

namespace UserRegistration
{
    public class StreamProduceResult
    {
        public long Offfset { get; set; }
        public Exception Exception { get; set; }
    }
}