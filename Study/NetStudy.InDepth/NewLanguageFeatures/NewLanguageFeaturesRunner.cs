using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetStudy.Core;

namespace NetStudy.InDepth.NewLanguageFeatures
{
    public class NewLanguageFeaturesRunner : IRunner
    {
        public void Run()
        {
            PatternMatch();
            LocalFunction();
            RefLocalsAndReturnsTest();
            MoreExpressionBodiedMembers();
        }

        private void RefLocalsAndReturnsTest()
        {
            var refLocalsAndReturn = new RefLocalsAndReturns();
            refLocalsAndReturn.Run();
        }

        private void LocalFunction()
        {
            //Local function...wow..
            int Add(int a, int b) => a + b;

            var firstNum = 10;
            var lastNum = 20;

            Console.WriteLine(Add(firstNum,lastNum));
        }

        private void MoreExpressionBodiedMembers()
        {
            var testClass = new MoreExpressionBodiedMemberTestClass();
            testClass.Birthday = new DateTime(1983,11,20);

            Console.WriteLine(testClass.Birthday);
        }

        private static void PatternMatch()
        {
            int o = 20;

            switch (o)
            {
                case int even when (even % 2) == 0:
                    Console.WriteLine($"Even - {even}");
                    break;
                case int odd:
                    Console.WriteLine($"odd - {odd}");
                    break;
            }

            o = 19;

            switch (o)
            {
                case int even when (even % 2) == 0:
                    Console.WriteLine($"Even - {even}");
                    break;
                case int odd:
                    Console.WriteLine($"odd - {odd}");
                    break;
            }
        }
    }
}