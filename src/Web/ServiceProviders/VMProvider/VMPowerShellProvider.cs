using AzureInfrastructure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureInfrastructure.Web.ServiceProviders.VMProvider
{
    public class VMPowerShellProvider : IVMProvider
    {
        public bool CreateVMs(VMCreateSetting vmCreateSetting)
        {
            throw new NotImplementedException();
        }
    }
}