using System;
using System.Collections.Generic;
using System.Text;

namespace NetSutdy.DesignPattern.Behavioral.Interpreter
{
    public interface Expression
    {
        int Interpret(int mineral);
        int CreateUnit(ref int mineral);
    }
}
