namespace Xpanxion.Reflex.API.Contracts.Types
{
    public class Device : Base
    {
        public int OTP { get; set; }
        public string DeviceNumber { get; set; }
        public string MobileNumber { get; set; }
        public DeviceType Type { get; set; }
        public bool IsLandingEnabled { get; set; }

    }
}
