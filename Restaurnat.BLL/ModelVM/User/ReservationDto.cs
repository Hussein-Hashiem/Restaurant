using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.User
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Duration { get; set; }
        public int NumberOfPeople { get; set; }
        public int Fees { get; set; }
        public int TotalMoney { get; set; }
        public string UserId { get; set; }
    }
}
