using System;
using System.Threading;

namespace NetSutdy.DesignPattern.Structural.Proxy
{
    public class BattleNet : IBattleNet, IDisposable
    {
        private bool _connected;

        public BattleNet()
        {
            ConnectToBattleNet();
        }

        public void ConnectToBattleNet()
        {
            // 커넥션에 3초가 걸린다.
            Thread.Sleep(3000);

            _connected = true;

            Console.WriteLine("BattleNet connected");
        }

        public void DisconnectFromBattleNet()
        {
            Dispose();
        }

        public bool Login(string id, string password)
        {
            if (_connected == false)
            {
                Console.WriteLine("Battlent is not connected");
            }

            if (id == "starcraft" && password == "battlenet")
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            //메모리 정리
        }
    }
}
