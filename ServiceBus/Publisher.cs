using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Messages.Base;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace ServiceBus
{
    public class Publisher
    {
        private readonly string ServiceBusConnectionString;
        private readonly Dictionary<string, IQueueClient> QueueClients = new Dictionary<string, IQueueClient>();

        public Publisher(string serviceBusConnectionString)
        {
            ServiceBusConnectionString = serviceBusConnectionString;
        }

        protected IQueueClient GetQueueClient(string queueName)
        {
            if (!QueueClients.ContainsKey(queueName))
            {
                QueueClients[queueName] = new QueueClient(ServiceBusConnectionString, queueName);
            }

            return QueueClients[queueName];
        }

        public async Task Publish(BaseMessage message, string queueName)
        {
            var messageToPublish = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
            var queueClient = GetQueueClient(queueName);

            await queueClient.SendAsync(messageToPublish);
            await queueClient.CloseAsync();
        }
    }
}
