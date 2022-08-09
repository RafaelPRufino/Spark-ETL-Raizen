
namespace Domain.Interfaces.Services
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
