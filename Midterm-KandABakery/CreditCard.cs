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
        public string ExpirationDate{ get; set; }
        public int CVV { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(ulong creditCardNumber, string expirationDate, int expirationYear, int cVV)
        {
            CreditCardNumber = creditCardNumber;
            ExpirationDate = expirationDate;
            CVV = cVV;
        }
    }
}
