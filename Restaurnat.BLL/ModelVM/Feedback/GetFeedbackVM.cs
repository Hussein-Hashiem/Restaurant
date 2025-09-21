

namespace Restaurnat.BLL.ModelVM.Feedback
{
    public class GetFeedbackVM
    {
        public int feedback_id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int rating { get; set; }
        public string? comment { get; set; }
    }
}
