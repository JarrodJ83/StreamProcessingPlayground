using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace UserRegistration
{
    public class KafkaStreamProducer : IStreamProducer<Null, string>, IDisposable   
    {
        
        Producer<Null, string> _producer;
        public KafkaStreamProducer()
        {
            _producer  = new Producer<Null, string>(new Dictionary<string, object> 
                        { 
                            { "bootstrap.servers", "52.234.230.110:9092" } 
                        }, null, new StringSerializer(Encoding.UTF8));
        }
        public async Task<StreamProduceResult> ProduceAsync(string topic, Null key, string value)
        {
            var result = await _producer.ProduceAsync(topic, key, value);

            return new StreamProduceResult
            {
                Offfset = result.Offset.Value,
                Exception = result.Error.HasError ? new Exception(result.Error.Reason) : null
            };
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _producer.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}