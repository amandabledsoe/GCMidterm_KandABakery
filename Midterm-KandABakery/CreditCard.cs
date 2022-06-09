using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_KandABakery
{
    public class CreditCard
    {
        public ulong CreditCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVV { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(ulong creditCardNumber, int expirationMonth, int expirationYear, int cVV)
        {
            CreditCardNumber = creditCardNumber;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            CVV = cVV;
        }
    }
}
