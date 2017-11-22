namespace Xpanxion.Reflex.API.Data.ClientProxy
{
    public interface IClientProxy
    {
        object GetDBClient();

        string GetConnectionString();

        //void GetDatabase();

        void CloseDBClient();

        string GenerateAuthToken(string verb, string resourceType, string resourceId, string date, string key, string keyType, string tokenVersion);
    }
}
