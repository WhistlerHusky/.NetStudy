using System;

namespace NetSutdy.DesignPattern.Behavioral.ChainOfResponsibility
{
    public class President : Approver
    {
        public President()
        {
            _maxAmount = 30000;
        }

        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < _maxAmount)
            {
                Console.WriteLine(
                    $"purchase:{purchase.PurchaseNumber} has been Approved by {GetType().Name} - amount:{purchase.Amount}");
            }
            else if (null != NextApprover)
            {
                NextApprover.ProcessRequest(purchase);
            }
            else
            {
                Console.WriteLine($"{GetType().Name} said this request should be approved in a board meeting");
            }
        }
    }
}
