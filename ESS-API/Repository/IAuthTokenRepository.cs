using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xpanxion.Reflex.API.Web.Repository
{
    public interface IAuthTokenRepository
    {
        bool CheckValidAuthToken(string reqkey);
    }
}
