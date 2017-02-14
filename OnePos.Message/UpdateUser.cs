﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class UpdateUserRequest : Request
    {
        public User User { get; set; }
    }

    public class UpdateUserResponse : Response
    {

    }
}
