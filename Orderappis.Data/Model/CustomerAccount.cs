using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderis.Data.Model
{
    public class CustomerAccount
    {
        public int CustomerAccountId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidTo { get; set; }

        public CustomerAccount() { }

        public CustomerAccount(int aCustomerAccountId,
            int aUserId,
            DateTime aCreatedAt,
            DateTime aValidTo
        ) {
            CustomerAccountId = aCustomerAccountId;
            UserId = aUserId;
            CreatedAt = aCreatedAt;
            ValidTo = aValidTo;
        }
    }
}
