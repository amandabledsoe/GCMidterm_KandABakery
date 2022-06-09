using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_KandABakery
{
    public class CashPayment
    {
        public int BillsTendered { get; set; }
        public decimal CoinsTendered { get; set; }
        public decimal TotalCashTendered { get; private set; }

        public CashPayment()
        {

        }
        public CashPayment(int newBillsTendered, decimal newCoinsTendered)
        {
            if (newBillsTendered>=0)
            {
                BillsTendered = newBillsTendered;
            }
            if (newCoinsTendered>=0)
            {
                CoinsTendered = newCoinsTendered;
            }
            TotalCashTendered = newBillsTendered + newCoinsTendered;
        }
        public decimal CalculateChange(decimal orderTotal)
        {
            return Math.Round(TotalCashTendered-orderTotal,2);
        }
    }
}
