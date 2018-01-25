using System;
using System.Linq;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Mediator
{
    public abstract class SpeakableUnit : AttackableUnit
    {
        public Mediator Mediator { get; set; }

        public void Speak(string message)
        {
            Mediator.Speak(this, message);
        }

        public void Hear(Unit fromUnit, string message)
        {
            Console.WriteLine($"{Name} heard {fromUnit.Name} say {message}");
        }
    }
}