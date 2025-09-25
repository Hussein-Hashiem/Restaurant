
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.BLL.ModelVM.Feedback
{
    public class CreateFeedbackVM
    {
		[Required]
		public string UserId { get; set; }
		[Required]
		[Range(1, 5, ErrorMessage = "1 To 5")]
		public int rating { get; set; }
		[StringLength(200)]
		public string? comment { get; set; }
    }
}
