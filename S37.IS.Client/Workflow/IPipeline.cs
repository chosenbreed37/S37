﻿using S37.IS.Client.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Workflow
{
    public interface IPipeline
    {
        Task<bool> Push(Message message);
    }
}
