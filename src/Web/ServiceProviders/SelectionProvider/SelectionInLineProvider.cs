using AzureInfrastructure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureInfrastructure.Web.ServiceProviders.SelectionProvider
{
    public class SelectionInLineProvider : ISelectionProvider
    {
        public IList<T> GetSelection<T>()
        {
            if (typeof(T).Equals(typeof(VMType)))
            {
                var selection = new List<VMType>()
                {
                    new VMType() { Id = 1, Name = "Windows 2012 (Base) "},
                    new VMType() { Id = 2, Name = "Base + SQL Server" },
                    new VMType() { Id = 3, Name = "Base + App Fabric" }
                };
                return (IList<T>) selection;
            }
            else if (typeof(T).Equals(typeof(VMSize)))
            {
                var selection = new List<VMSize>()
                {
                    new VMSize(){Id=1, Size="Extra Small"},
                    new VMSize(){Id=2, Size="Small"},
                    new VMSize(){Id=3, Size="Medium"},
                    new VMSize(){Id=4, Size="Large"},
                    new VMSize(){Id=5, Size="Extra Large"},
                    new VMSize(){Id=6, Size="Extra Extra Large"},
                };
                return (IList<T>)selection;
            }
            else
            {
                return null;
            }
        }
    }
}