using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArtGallery_ServiceBus
{
    public class MessageService: IMessage
    {
        //  <---- SET THE PRIMARY CONECTION STRING  ---->
        private readonly string _connectionString = "Endpoint=sb://artgalleryservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=1ojL9Xv22RZUY/az2SpalDlwIoUnjgekR+ASbJIx6ZA=";
        public async Task PublishMessage(object message, string queueName)
        {
            
            //  <---- CREATE A CLIENT TO OUR SERVICEBUS---->
            var client = new ServiceBusClient(_connectionString);

            //  <---- CREATE A SENDER TO OUR QUEUE ---->
            ServiceBusSender sender = client.CreateSender(queueName);

            //  <---- SERIALIZE THE MESSAGE TO JSON FORMAT ---->
            var serializedMsg = JsonConvert.SerializeObject(message);

            //  <---- ENCODE THE MESSAGE AND ADD AN ADDITIONAL CORRELATIONAL ID ---->
            ServiceBusMessage encodedMsg = new ServiceBusMessage(Encoding.UTF8.GetBytes(serializedMsg))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };


            //  <---- SEND THE MESSAGE  ---->
            await sender.SendMessageAsync(encodedMsg);

            //  <---- FREE THE RESOURCES  ---->
            await sender.DisposeAsync();
        }
    }
}
