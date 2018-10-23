using System;
using System.Threading;

namespace NetSutdy.DesignPattern.Structural.Proxy
{
    public class ProxyBattleNet : IBattleNet
    {
        private int _count;

        private BattleNet _battle;

        public void ConnectToBattleNet()
        {
            if (_battle == null)
            {
                _battle = new BattleNet();
                _count = 1;
            }
            else
            {
                _count++;
            }
        }

        public void DisconnectFromBattleNet()
        {
            if (_count == 1)
            {
                _battle.DisconnectFromBattleNet();
            }
            else
            {
                _count--;
            }
        }

        public bool Login(string id, string password)
        {
            var age = GetUserAge();

            //Protection proxy
            if (age < 16)
            {
                Console.WriteLine($"{age} is too young to play this game");
                return false;
            }
            else
            {
                if (_battle == null)
                {
                    //Virtual proxy
                    ConnectToBattleNet();
                }

                //실제 로그인 실행
                _battle.Login(id, password);

                return true;
            }
        }

        public int GetUserAge()
        {
            Thread.Sleep(1000);
            
            //서버 접속이 여기서 이루어 진다고 가정.
            IUserAge userAge = new ServerBattleNet();

            return userAge.GetUserAge();
        }
    }
}
