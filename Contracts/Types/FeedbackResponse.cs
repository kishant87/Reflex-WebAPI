using System;
using System.Collections.Generic;

namespace Xpanxion.Reflex.API.Contracts.Types
{
    public class FeedbackResponse : Base
    {
        public DateTime SubmitDate { get; set; }
        public string EmployeeId { get; set; }
        public int OTP { get; set; }
        public List<Response> Response { get; set; } = new List<Response>();


    }
}
