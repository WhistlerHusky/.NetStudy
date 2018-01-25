using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Behavioral.Memento;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.TemplateMethod
{
    public class TemplateMethodPatternRunner : IRunner
    {
        public void Run()
        {
            TerranBuild build = new Terran8SCVThenSuppliesBuild();

            build.PrepareWar();

            build = new Terran8SCVThenBarracksBuild();

            build.PrepareWar();
        }
    }
}
