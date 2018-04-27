using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace UserRegistration
{
    public class KafkaStreamProducer : IStreamProducer<int, string>, IDisposable   
    {
        
        Producer<int, string> _producer;
        public KafkaStreamProducer(Producer<int, string> producer)
        {
            _producer  = producer;
        }
        public async Task<StreamProduceResult> ProduceAsync(string topic, int key, string value)
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