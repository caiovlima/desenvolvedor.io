﻿using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.DomainObjects
{
    public class DomainEvent : Event
    {

        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
