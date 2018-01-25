using System;

namespace NetSutdy.DesignPattern.Structural.Proxy
{
    public class ServerBattleNet : IUserAge
    {
        public int GetUserAge()
        {
            return new Random().Next(10,20);
        }
    }
}