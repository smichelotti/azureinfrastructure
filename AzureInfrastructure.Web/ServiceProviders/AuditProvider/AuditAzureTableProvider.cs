using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using AzureInfrastructure.Web.Models;

namespace AzureInfrastructure.Web.ServiceProviders.AuditProvider
{
    public class AuditAzureTableProvider : IAuditProvider
    {
        CloudStorageAccount _account;
        CloudTableClient _client;
        CloudTable _vmAuditTable;

        public AuditAzureTableProvider()
        {
            try
            {
                _account = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
                _client = _account.CreateCloudTableClient();
            }
            catch (Exception exp)
            {
                throw new Exception("Error retreiving reference to Azure Storage Account", exp);
            }
            try
            {
                _client = _account.CreateCloudTableClient();
            }
            catch (Exception exp)
            {
                throw new Exception("Error creating Azure Table Client Object", exp);
            }
            try
            {
                _vmAuditTable = _client.GetTableReference("VMAudits");
            }
            catch (Exception exp)
            {
                throw new Exception("Error retreiving reference to Azure Table Object", exp);
            }
        }

        public IEnumerable<AuditEntry> Search(string srNumber)
        {
            try
            {
                var result = (from AuditEntry
                            in _vmAuditTable.CreateQuery<AuditEntry>()
                            where AuditEntry.PartitionKey == srNumber
                            select AuditEntry).ToList();
                return result;
            }
            catch (Exception exp)
            {
                throw new Exception("Unable to search Azure Storage", exp);
            }
        }
    }
}