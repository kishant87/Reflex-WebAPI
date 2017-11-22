using Xpanxion.Reflex.API.Contracts.Requests;
using Xpanxion.Reflex.API.Contracts.Responses;
using Xpanxion.Reflex.API.Data.ClientProvider;
using Xpanxion.Reflex.API.Data.ClientProxy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Xpanxion.Reflex.API.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        // GET: api/values
        [HttpPost]
        public async Task<AuthResponse> AuthenticateUserAsync(AuthRequest request)
        {

            AuthProvider provider = new AuthProvider();
            provider.ClientProxyObj = new DocumentDB();

            return await provider.GetAuthenticationTokenDetailsAsync(request);
        }
    }
}
