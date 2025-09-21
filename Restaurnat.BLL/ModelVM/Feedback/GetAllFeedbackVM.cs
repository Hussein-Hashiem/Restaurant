using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Feedback
{
    public class GetAllFeedbackVM
    {
        public int feedback_id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int rating { get; set; }
        public string? comment { get; set; }
    }
}
