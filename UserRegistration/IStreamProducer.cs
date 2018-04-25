using System.Threading.Tasks;

namespace UserRegistration
{
    public interface IStreamProducer<TKey, TValue>
    {
        Task<StreamProduceResult> ProduceAsync(string topic, TKey key, TValue value);
    }
}