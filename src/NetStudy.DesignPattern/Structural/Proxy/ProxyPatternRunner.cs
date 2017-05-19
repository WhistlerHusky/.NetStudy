using System;
using NetStudy.Core;

namespace NetSutdy.DesignPattern.Structural.Proxy
{
    public class ProxyPatternRunner : IRunner
    {
        public void Run()
        {
            IBattleNet login = new ProxyBattleNet();

            for (int i = 0; i < 10; i++)
            {
                var loginResult = login.Login("starcraft", "Battlenet");
                Console.WriteLine($"{i} : {(loginResult ? "Successfully logged in" : "Login failed" )}");
            }
        }
    }
}
