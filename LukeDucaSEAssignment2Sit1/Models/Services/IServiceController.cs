﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LukeDucaSEAssignment2Sit1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceController" in both code and config file together.
    [ServiceContract]
    public interface IServiceController
    {
        [OperationContract]
        void DoWork();
    }
}
