using Microsoft.Azure.Documents.Client;
using System;

namespace Xpanxion.Reflex.API.Data.ClientProxy
{
    public class DocumentDB : IClientProxy
    {
        //private string EndpointUri = "https://ess.documents.azure.com:443/";
        //private string PrimaryKey = "EgFygtpjjNmGSDZrCrJiuhMjgiTdRhGOHW3ENTU3tVlPjzWSet490whbEsNPGXGQguAgrTBcJwd64CthI9Q1kg==";
        private string EndpointUri = "https://localhost:8081/";
        private string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public void CloseDBClient()
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public object GetDBClient()
        {
            //DocumentClient client = new DocumentClient(new Uri(EndpointUri), authToken);
            DocumentClient client = new DocumentClient(
                new Uri(EndpointUri),
                PrimaryKey);

            return client;
        }

        public string GenerateAuthToken(string verb, string resourceType, string resourceId, string date, string key, string keyType, string tokenVersion)
        {
            var hmacSha256 = new System.Security.Cryptography.HMACSHA256 { Key = Convert.FromBase64String(key) };

            verb = verb ?? "";
            resourceType = resourceType ?? "";
            resourceId = resourceId ?? "";

            string payLoad = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}\n{1}\n{2}\n{3}\n{4}\n",
                    verb.ToLowerInvariant(),
                    resourceType.ToLowerInvariant(),
                    resourceId,
                    date.ToLowerInvariant(),
                    ""
            );

            byte[] hashPayLoad = hmacSha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(payLoad));
            string signature = Convert.ToBase64String(hashPayLoad);

            return System.Web.HttpUtility.UrlEncode(String.Format(System.Globalization.CultureInfo.InvariantCulture, "type={0}&ver={1}&sig={2}",
                keyType,
                tokenVersion,
                signature));
        }
    }
}
