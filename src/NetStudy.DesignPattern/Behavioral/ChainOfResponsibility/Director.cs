﻿using System;

namespace NetSutdy.DesignPattern.Behavioral.ChainOfResponsibility
{
    public class Director : Approver
    {
        public Director()
        {
            _maxAmount = 10000;
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
                Console.WriteLine($"{GetType().Name} cannot process purchase number:{purchase.PurchaseNumber} because it's amount is more than {_maxAmount}");
            }
        }
    }
}
