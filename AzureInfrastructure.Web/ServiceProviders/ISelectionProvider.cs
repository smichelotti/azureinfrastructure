using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureInfrastructure.Web.ServiceProviders
{
    public interface ISelectionProvider
    {
        IList<T> GetSelection<T>();
    }
}
