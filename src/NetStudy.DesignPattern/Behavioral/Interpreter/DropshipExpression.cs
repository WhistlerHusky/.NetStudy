using System;
using System.Collections.Generic;
using System.Text;

namespace NetSutdy.DesignPattern.Behavioral.Interpreter
{
    public class DropshipExpression : Expression
    {
        private const int RequiredMineral = 100;

        public int Interpret(int mineral)
        {
            return mineral / RequiredMineral;
        }

        public int CreateUnit(ref int mineral)
        {
            var count = mineral / RequiredMineral;
            mineral = mineral % RequiredMineral;

            return count;
        }
    }
}
