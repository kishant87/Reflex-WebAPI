using Xpanxion.Reflex.API.Data.ClientProxy;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace Xpanxion.Reflex.API.Data.ClientProvider
{
    public class BaseProvider
    {
        public static string DatabaseName = "ReflexDB";
        public static string EmployeesCollection = "Employees";
        string EmployeesPartitionKey = "/role";

        DocumentClient client;
        public DocumentClient Client
        { get { return (DocumentClient)ClientProxyObj.GetDBClient(); } }
        public IClientProxy ClientProxyObj
        {
            set; get;
        }

        public async Task<DocumentClient> IntitializeProxy()
        {
            client = (DocumentClient)ClientProxyObj.GetDBClient();
            Database databaseInfo = new Database { Id = DatabaseName };
            await this.client.CreateDatabaseIfNotExistsAsync(databaseInfo);
            DocumentCollection collectionInfo = new DocumentCollection();
            collectionInfo.Id = EmployeesCollection;
            collectionInfo.PartitionKey.Paths.Add(EmployeesPartitionKey);
            collectionInfo.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });


            await this.client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(databaseInfo.Id),
                collectionInfo,
                new RequestOptions { OfferThroughput = 400 });
            return client;

        }
    }
}
