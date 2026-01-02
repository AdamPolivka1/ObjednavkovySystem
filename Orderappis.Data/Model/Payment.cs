using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderis.Data.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethod { get; set; }
        public decimal TotalCZK { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }

        public Payment() { }

        public Payment(int paymentId,
            DateTime paymentDate,
            int paymentMethod,
            decimal totalCZK,
            int status,
            string note)
        {
            PaymentId = paymentId;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            TotalCZK = totalCZK;
            Status = status;
            Note = note;
        }
    }
}
