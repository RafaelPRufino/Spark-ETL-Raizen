using Domain.Interfaces.Context;
using Domain.Interfaces.Services;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic.Services
{
    public class MessageService : IMessageService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly bool _isConnect;
        private readonly IEnvironmentContext _environment;
        public MessageService(IEnvironmentContext environment)
        {
            _environment = environment;

            _factory = new ConnectionFactory() { HostName = _environment.ENV_RABBIT_HOST };
            _factory.UserName = _environment.ENV_RABBIT_USER;
            _factory.Password = _environment.ENV_RABBIT_PASSWORD;
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: _environment.ENV_RABBIT_QUEUE,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            _isConnect = true;
        }

        public bool Enqueue(string messageString)
        {
            var body = Encoding.UTF8.GetBytes(messageString);

            _channel.BasicPublish(exchange: "",
                                routingKey: _environment.ENV_RABBIT_QUEUE,
                                basicProperties: null,
                                body: body);
            return true;
        }
    }
}
