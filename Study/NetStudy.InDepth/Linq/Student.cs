using System;
using NetStudy.Core;
using System.Linq;

namespace NetStudy.InDepth.Linq
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
