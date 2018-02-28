namespace NetSutdy.DesignPattern.Behavioral.ChainOfResponsibility
{
    public abstract class Approver
    {
        protected decimal _maxAmount;
        public Approver NextApprover { get; set; }
        public abstract void ProcessRequest(Purchase purchase);
    }
}