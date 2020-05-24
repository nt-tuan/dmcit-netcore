﻿using DMCIT.Core.SharedKernel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DMCIT.Core.Entities.Messaging
{
    public class MessageServiceProvider : BaseVersionControlEntity<MessageServiceProvider>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Module { get; set; }

        public string AddressRegex { get; set; }

        public string AddressLabel { get; set; }

        public bool IsValidAddress(string address)
        {
            return Regex.IsMatch(address, AddressRegex);
        }
        public ICollection<ReceiverProvider> ReceiverProviders { get; set; }
    }
}
