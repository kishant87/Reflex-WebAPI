using System;

namespace Xpanxion.Reflex.API.Contracts.Types
{
    public class SurveyFeedback : Base
    {

        public SurveyFeedbackTypes Type { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
