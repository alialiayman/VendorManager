﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorManager
{
    public class NotificationEventAgrs: EventArgs
    {

        public string Message { get; set; }
        public int StatusId { get; set; }
    }
}
