﻿using Azure.Messaging.ServiceBus;
using MailService.Models;
using MailService.Models.Dtos;
using MailService.Service;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace MailService.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _queueName;
        private readonly ServiceBusProcessor _emailProcessor;
        private readonly ServiceBusProcessor _bookingProcessor;
        private readonly MailsService _emailService;
        private readonly EmailService _email;


        public AzureServiceBusConsumer(IConfiguration configuration,EmailService service)
        {
            _configuration = configuration;
            _email= service;
            //------GETS THE PRIMARY CONNECTION STRING FROM OUR JSON FILE------
            _connectionString = _configuration.GetValue<string>("AzureConnectionString");
            //-----GETS THE NAME OF OUR AZURE SERVICE BUS FROM THE JSON FILE------
            _queueName= _configuration.GetValue<string>("QueueName:RegistrationQueue");

            var client = new ServiceBusClient(_connectionString);
            _emailProcessor = client.CreateProcessor(_queueName);
            _bookingProcessor= client.CreateProcessor("bookingadded", "EmailService");
            _emailService = new MailsService(configuration);

        }
        public async Task Start()
        {
            _emailProcessor.ProcessMessageAsync += OnRegisterUser;
            _emailProcessor.ProcessErrorAsync += ErrorHandler;
            await _emailProcessor.StartProcessingAsync();

            _bookingProcessor.ProcessMessageAsync += OnBooking;
            _bookingProcessor.ProcessErrorAsync += ErrorHandler;
            await _bookingProcessor.StartProcessingAsync();
        }

        public async Task Stop()
        {
            await _emailProcessor.StopProcessingAsync();
            await _emailProcessor.DisposeAsync();

            await _bookingProcessor.StopProcessingAsync();
            await _bookingProcessor.DisposeAsync();
        }
        //-----------NOTE TO SELF
        //------------THIS SHOULD BE THE SECTION WHERE EMAILS ARE SENT AFTER A BID IS WON------
        private  async Task OnBooking(ProcessMessageEventArgs arg)
        {

            var message = arg.Message;
            var body = Encoding.UTF8.GetString(message.Body);//read  as String
            var reward = JsonConvert.DeserializeObject<RewardsDto>(body);//string to UserMessageDto

            try
            {

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<img src=\"https://cdn.pixabay.com/photo/2016/01/02/16/53/lion-1118467_640.jpg\" width=\"1000\" height=\"600\">");
                stringBuilder.Append("<h1> Hello " + reward.Name + "</h1>");
                stringBuilder.AppendLine("<br/> Booking Made Successfully ");

                stringBuilder.Append("<br/>");
                stringBuilder.Append('\n');
                stringBuilder.Append("<p>You can Make another Booking!!</p>");

                var user = new UserMessageDto()
                {
                    Email = reward.Email,
                    Name = reward.Name,
                };
                await _emailService.sendEmail(user, stringBuilder.ToString(), "Safari Booking");


                //insert  to Database
                var emaiLLogger = new EmailLogger()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Message = stringBuilder.ToString(),
                    DateTime = DateTime.Now,

                };
                await _email.addDatatoDatabase(emaiLLogger);

                await arg.CompleteMessageAsync(arg.Message);//we are done delete the message from the queue 
            }
            catch (Exception ex)
            {
                throw;
                //send an Email to Admin
            }
        }

      

        private Task ErrorHandler(ProcessErrorEventArgs arg)
        {

            //send Email to Admin 
             return Task.CompletedTask;
        }

        private async Task OnRegisterUser(ProcessMessageEventArgs arg)
        {
           
            var message = arg.Message;
            var body = Encoding.UTF8.GetString(message.Body);//read  as String
            var user = JsonConvert.DeserializeObject<UserMessageDto>(body);//string to UserMessageDto

            try
            {

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<img src=\"https://images.pexels.com/photos/942317/pexels-photo-942317.jpeg?auto=compress&cs=tinysrgb&w=600\" width=\"1000\" height=\"600\">");
                stringBuilder.Append("<h1> Hello " + user.Name + "</h1>");
                stringBuilder.AppendLine("<br/>Thankyou for registering to pick-a-saw");

                stringBuilder.Append("<br/>");
                stringBuilder.Append('\n');
                stringBuilder.Append("<p>Log in to your account and start bidding!!!!</p>");

                await _emailService.sendEmail(user, stringBuilder.ToString());


                //insert  to Database
                var emaiLLogger = new EmailLogger()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Message = stringBuilder.ToString(),
                    DateTime = DateTime.Now,

                };
                await _email.addDatatoDatabase(emaiLLogger);

                await arg.CompleteMessageAsync(arg.Message);//we are done delete the message from the queue 
            }catch (Exception ex)
            {
                throw;
                //send an Email to Admin
            }
        }

       
    }
}
