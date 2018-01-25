using NetStudy.Core;

namespace NetSutdy.DesignPattern.Behavioral.ChainOfResponsibility
{
    public class ChainOfResponsibilityRunner : IRunner
    {
        public void Run()
        {
            Approver director = new Director();
            Approver vicePresident = new VicePresident();
            Approver President = new President();

            director.NextApprover = vicePresident;
            vicePresident.NextApprover = President;

            var purchase = new Purchase { PurchaseNumber = 1, Amount = 5000};

            director.ProcessRequest(purchase);

            purchase = new Purchase { PurchaseNumber = 2, Amount = 15000 };

            director.ProcessRequest(purchase);

            purchase = new Purchase { PurchaseNumber = 3, Amount = 25000 };

            director.ProcessRequest(purchase);

            purchase = new Purchase { PurchaseNumber = 4, Amount = 35000 };

            director.ProcessRequest(purchase);
        }
    }   
}
