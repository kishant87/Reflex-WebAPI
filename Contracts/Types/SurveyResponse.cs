using System;
using System.Collections.Generic;

namespace Xpanxion.Reflex.API.Contracts.Types
{
    public class SurveyResponse : Base
    {
        public DateTime SubmitDate { get; set; }
        public int EmployeeId { get; set; }
        public string OTP { get; set; }
        public List<Response> Response { get; set; } = new List<Response>();

    }
}
