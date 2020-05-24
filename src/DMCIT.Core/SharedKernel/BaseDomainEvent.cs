using DMCIT.Core.Entities.Core;
using Hangfire.Server;
using MediatR;
using System;

namespace DMCIT.Core.SharedKernel
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
        public AppUser Actor { get; set; }
        public PerformContext Context { get; set; }
    }
}