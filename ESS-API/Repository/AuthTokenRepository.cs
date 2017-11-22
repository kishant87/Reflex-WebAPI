using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xpanxion.Reflex.API.Web.Repository
{
    public class AuthTokenRepository : IAuthTokenRepository
    {
        public bool CheckValidAuthToken(string reqkey)
        {
            var authTokenList = new List<string>
            {
                "28236d8ec201df516d0f6472d516d72d",
                "38236d8ec201df516d0f6472d516d72c",
                "48236d8ec201df516d0f6472d516d72b"
            };

            if (authTokenList.Contains(reqkey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
