using System.Collections.Generic;

namespace NetStudy.InDepth.Linq
{
    public class Teacher 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Student> Students { get; set; }
    }
}
