using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Email
{
    public class EmailSendVM
    {
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
