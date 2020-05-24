using DMCIT.Core.Entities.Messaging.TemplateMessage;
using DMCIT.Core.Entities.Reports;
using DMCIT.Infrastructure.Events.CustomerAREvent;
using Hangfire.Server;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface ISendCustomerARService
    {
        Task CalculateAR(int distributor, IEnumerable<int> providers, PerformContext context);
        Task CalculatePayment(int distributor, IEnumerable<int> providers, PerformContext context);
        Task BuildARMessageContent(int distributor, IEnumerable<CustomerAR> payments, PerformContext context);
        Task SendPaymentMessages(int distributor, IEnumerable<CustomerPaymentMessage> pMsg, PerformContext context);
        Task SendARMessages(int distributor, IEnumerable<CustomerARMessage> arMsg, PerformContext context);
        Task SendPaymentProcessBegin(int distributor, DateTime startTime, DateTime endTime, PerformContext context);
        Task SendPaymentProcessEnd(int distributor, DateTime startTime, DateTime endTime, PerformContext context);
        Task UpdateCustomerPaymentMessage(int distributor, IEnumerable<int> providers, DateTime from, DateTime to, PerformContext context);
    }
    public class SendCustomerARService : ISendCustomerARService
    {
        private readonly IMediator _mediatR;
        public SendCustomerARService(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task BuildARMessageContent(int distributor, IEnumerable<CustomerAR> payments, PerformContext context)
        {
            await _mediatR.Publish(new BuildARMessageContentEvent
            {
                Distributor = distributor,
                CustomerPayments = payments,
                Context = context
            });
        }

        public async Task CalculateAR(int distributor, IEnumerable<int> providers, PerformContext context)
        {
            await _mediatR.Publish(new CalculateAREvent
            {
                Distributor = distributor,
                Providers = providers,
                Context = context
            });
        }

        public async Task CalculatePayment(int distributor, IEnumerable<int> providers, PerformContext context)
        {
            await _mediatR.Publish(new CalculatePaymentEvent
            {
                Distributor = distributor,
                Providers = providers,
                Context = context
            });
        }

        public async Task SendARMessages(int distributor, IEnumerable<CustomerARMessage> arMsg, PerformContext context)
        {
            await _mediatR.Publish(new SendARMessage
            {
                Distributor = distributor,
                ARMsg = arMsg,
                Context = context
            });
        }

        public async Task SendPaymentMessages(int distributor, IEnumerable<CustomerPaymentMessage> pMsg, PerformContext context)
        {
            await _mediatR.Publish(new SendPaymentMessageEvent
            {
                Distributor = distributor,
                PMsg = pMsg,
                Context = context
            });
        }

        public async Task SendPaymentProcessBegin(int distributor, DateTime startTime, DateTime endTime, PerformContext context)
        {
            await _mediatR.Publish(new SendPaymentProcessBegin
            {
                Disitributor = distributor,
                StartTime = startTime,
                EndTime = endTime,
                Context = context
            });
        }

        public async Task SendPaymentProcessEnd(int distributor, DateTime startTime, DateTime endTime, PerformContext context)
        {
            await _mediatR.Publish(new SendPaymentProcessEnd
            {
                Distributor = distributor,
                StartTime = startTime,
                EndTime = endTime,
                Context = context
            });
        }

        public async Task UpdateCustomerPaymentMessage(int distributor, IEnumerable<int> providers, DateTime from, DateTime to, PerformContext context)
        {
            await _mediatR.Publish(new UpdateCustomerPaymentMessageEvent
            {
                Distributor = distributor,
                Providers = providers,
                StartTime = from,
                EndTime = to
            });
        }
    }
}
