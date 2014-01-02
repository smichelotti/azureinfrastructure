using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using AzureInfrastructure.Web.Models;

namespace AzureInfrastructure.Web.ServiceProviders.ProvisionRequestProvider
{
    public class ProvisonRequestAzureTableProvider : IProvisionRequestProvider
    {
        CloudStorageAccount _account;
        CloudTableClient _client;
        CloudTable _requestTable;

        public ProvisonRequestAzureTableProvider()
        {
        }

        private void initializeAzureStorageTable()
        {
            try
            {
                _account = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);

            }
            catch (Exception exp)
            {

                throw new Exception("Error parsing Azure Storage configuration value.", exp);
            }

            try
            {
                _client = _account.CreateCloudTableClient();
            }
            catch (Exception exp)
            {
                throw new Exception("Error retreiving reference to Azure Storage Account.", exp);
            }
            try
            {
                _client = _account.CreateCloudTableClient();
            }
            catch (Exception exp)
            {
                throw new Exception("Error creating Azure Table Client Object.", exp);
            }
            try
            {
                _requestTable = _client.GetTableReference("ProvisionRequest");
                _requestTable.CreateIfNotExists();
            }
            catch (Exception exp)
            {
                throw new Exception("Error retreiving reference to Azure Table Object.", exp);
            }
        }

        public IEnumerable<ProvisionRequest> Search(string requestNumber)
        {
            if (_requestTable == null){
                initializeAzureStorageTable();
            }
            try
            {
                var result = (from entry
                            in _requestTable.CreateQuery<ProvisionRequest>()
                            where entry.Number == requestNumber
                            select entry).ToList();
                return result;
            }
            catch (Exception exp)
            {
                throw new Exception("Error searching Azure Storage for request number=[" + requestNumber + "]", exp);
            }
        }
    }
}