using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NetSutdy.DesignPattern.Structural.Proxy
{
    public interface IBattleNet
    {
        void ConnectToBattleNet();
        void DisconnectFromBattleNet();
        bool Login(string id, string password);
    }
}
