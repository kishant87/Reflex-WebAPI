using Xpanxion.Reflex.API.Contracts.Types;

namespace Xpanxion.Reflex.API.Contracts.Responses
{
    public class AuthResponse : BaseResponse
    {
        public bool IsAuthenticated { get; set; }

        public Employee Data { get; set; }
    }
}
