﻿using PocketServer.DataAccess.EntityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketServer.DataAccess.Entities
{
    public class Subscription
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }

        public User User { get; set; }
        public Device Device { get; set; }
    }
}
