using Xpanxion.Reflex.API.Contracts.Responses;
using Xpanxion.Reflex.API.Contracts.Types;
using Xpanxion.Reflex.API.Data.ClientProxy;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Linq;

namespace Xpanxion.Reflex.API.Data.ClientProvider
{
    public class EmployeeProvider
    {
        string DatabaseName = "ReflexDB_Test";
        string EmployeesCollection = "Employees";
        string EmployeesPartitionKey = "/role";

        DocumentClient client;
        public IClientProxy ClientProxyObj
        {
            set; get;
        }


        public async Task<BaseResponse> InsertEmployee(Employee request)
        {
            try
            {
                client = (DocumentClient)ClientProxyObj.GetDBClient();

                Database databaseInfo = new Database { Id = DatabaseName };

                await this.client.CreateDatabaseIfNotExistsAsync(databaseInfo);

                DocumentCollection collectionInfo = new DocumentCollection();
                collectionInfo.Id = EmployeesCollection;

                collectionInfo.PartitionKey.Paths.Add(EmployeesPartitionKey);

                collectionInfo.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

                //string suthToken = ClientProxyObj.GenerateAuthToken("POST", "dbs", "", string date, string key, string keyType, string tokenVersion);

                await this.client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseInfo.Id),
                    collectionInfo,
                    new RequestOptions { OfferThroughput = 400 });

                await this.CreateFamilyDocumentIfNotExists(databaseInfo.Id, collectionInfo.Id, request);

                return new BaseResponse { Message = "Employee added", ResultCode = 0 };
            }
            catch (System.Exception ex)
            {
                return new BaseResponse { Message = "Employee cannot be added. Error returned. " + ex.Message, ResultCode = 1 };
            }


        }

        public async Task<BaseResponse> GetEmployee(string id)
        {
            try
            {
                client = (DocumentClient)ClientProxyObj.GetDBClient();
                Database databaseInfo = new Database { Id = DatabaseName };

                await this.client.CreateDatabaseIfNotExistsAsync(databaseInfo);

                DocumentCollection collectionInfo = new DocumentCollection();
                collectionInfo.Id = EmployeesCollection;

                collectionInfo.PartitionKey.Paths.Add(EmployeesPartitionKey);

                collectionInfo.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

                try
                {
                    Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseInfo.Id,
                        collectionInfo.Id, id));
                    return (dynamic)document;
                }
                catch (DocumentClientException e)
                {
                    if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (System.Exception ex)
            {
                return new BaseResponse { Message = "Employee cannot be added. Error returned. " + ex.Message, ResultCode = 1 };
            }
        }

        public BaseResponse UpdateEmployee(Employee request, int id)
        {
            return new BaseResponse();

        }
        public BaseResponse DeleteEmployee(int id)
        {
            return new BaseResponse();
        }

        private async Task CreateFamilyDocumentIfNotExists(string databaseName, string collectionName, Employee family)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, family.Id.ToString()), new RequestOptions { PartitionKey = new PartitionKey(family.Role.ToString()) });
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), family);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
