using MongoDB.Driver;
using System;

namespace Xpanxion.Reflex.API.Data.ClientProxy
{
    public class MongoDB : IClientProxy
    {
        public void CloseDBClient()
        {
            //return (object)(new MongoClient(ConfigurationSettings.AppSettings.Get("MySetting").ToString()));
        }

        public string GenerateAuthToken(string verb, string resourceType, string resourceId, string date, string key, string keyType, string tokenVersion)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            return "";
        }

        //public void GetDatabase()
        //{
        //    throw new NotImplementedException();
        //}

        public object GetDBClient()
        {
            //var str = ConfigurationManager.AppSettings["ESSDB"];

            return (object)(new MongoClient(@"mongodb://essdb:xBmHmlPOikEWMK3iHEQB5ICXgQ0UduZkCiYTjMLgklWWRmM6VjvJ1pXhgjqeWP1v8BT826IbFvTPFn9JiJ15ag==@essdb.documents.azure.com:10255/?ssl=false&replicaSet=globaldb"));
        }
    }
}
