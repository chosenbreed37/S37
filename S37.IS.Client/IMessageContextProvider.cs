﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client
{
    public interface IMessageContextProvider
    {
        MessageContext GetMessageContext();
    }
}
