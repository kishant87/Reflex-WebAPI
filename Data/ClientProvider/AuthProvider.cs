using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xpanxion.Reflex.API.Contracts.Requests;
using Xpanxion.Reflex.API.Contracts.Responses;
using Xpanxion.Reflex.API.Contracts.Types;
using Xpanxion.Reflex.API.Data.ClientProxy;

namespace Xpanxion.Reflex.API.Data.ClientProvider
{
    public class AuthProvider
    {
        public IClientProxy ClientProxyObj
        {
            set; get;
        }

        string DatabaseName = "ReflexDB";
        string EmployeesCollection = "Employees";


        public async Task<AuthResponse> GetAuthenticationTokenDetailsAsync(AuthRequest request)
        {

            DocumentClient client = (DocumentClient)ClientProxyObj.GetDBClient();
            Database databaseInfo = new Database { Id = DatabaseName };

            IDocumentQuery<Employee> query = client.CreateDocumentQuery<Employee>(
            UriFactory.CreateDocumentCollectionUri(DatabaseName, EmployeesCollection),
            new FeedOptions { MaxItemCount = -1 })
           .AsDocumentQuery();

            List<Employee> results = new List<Employee>();

            AuthResponse authResponse = new AuthResponse();

            while (query.HasMoreResults)
            {
                dynamic vres = await query.ExecuteNextAsync();

                results.AddRange((IEnumerable<Employee>)vres);
            }

            authResponse.Data = results.Where(s => s.EmployeeDevice.All(ed => ed.OTP == request.OTP)).
                                        Where(e => e.EmailAddress == request.EmailAddress).FirstOrDefault();

            if (authResponse.Data != null)
            {
                authResponse.IsAuthenticated = true;
                authResponse.ResultCode = 0;
            }
            else
            {
                authResponse.IsAuthenticated = false;
                authResponse.ResultCode = -1;
                authResponse.Message = "Either OTP or Email address is not matching.";
            }
            return authResponse;
        }

        public IEnumerable<Device> AuthenticateToken()
        {

            return null;
        }

    }
}
