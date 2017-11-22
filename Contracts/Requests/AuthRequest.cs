namespace Xpanxion.Reflex.API.Contracts.Requests
{
    public class AuthRequest
    {
        public string EmailAddress { get; set; }

        public int OTP { get; set; }
    }
}
