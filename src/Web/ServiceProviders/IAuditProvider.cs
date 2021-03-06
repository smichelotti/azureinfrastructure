﻿using AzureInfrastructure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureInfrastructure.Web.ServiceProviders
{
    public interface IAuditProvider
    {
        IEnumerable<AuditEntry> Search(string srNumber);
    }
}
