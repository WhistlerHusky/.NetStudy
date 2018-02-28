namespace NetSutdy.DesignPattern.Structural.Proxy
{
    public interface IBattleNet
    {
        void ConnectToBattleNet();
        void DisconnectFromBattleNet();
        bool Login(string id, string password);
    }
}
