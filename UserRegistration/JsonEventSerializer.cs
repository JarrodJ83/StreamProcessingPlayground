using System.Collections.Generic;
using System.Text;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;

namespace UserRegistration.Serialization
{
    public class JsonEventSerializer<T> : Confluent.Kafka.Serialization.ISerializer<T>
    {
        private readonly StringSerializer _stringSerializer = new StringSerializer(Encoding.UTF8);
        public IEnumerable<KeyValuePair<string, object>> Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
        {
            return new KeyValuePair<string, object>[0];
        }

        public void Dispose()
        {
        }

        public byte[] Serialize(string topic, T data)
        {
             string serializedObject = JsonConvert.SerializeObject(data);
             return _stringSerializer.Serialize(topic, serializedObject);
        }
    }
}