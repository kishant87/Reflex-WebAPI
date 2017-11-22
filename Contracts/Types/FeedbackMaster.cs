using System;
using System.Collections.Generic;

namespace Xpanxion.Reflex.API.Contracts.Types
{
    public class FeedbackMaster : Base
    {
        public DateTime PublishDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string EmployeeIds { get; set; }
        public string OTPs { get; set; }
        public string Description { get; set; }
        public string QRCodeImage { get; set; }
        public string QRCodeKey { get; set; }
        public int ConductedBy { get; set; }
        public SurveyFeedbackTypes TypeId { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
