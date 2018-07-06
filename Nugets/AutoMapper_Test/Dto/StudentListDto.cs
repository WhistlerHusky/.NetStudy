using AutoMapper_Test.Core;

namespace AutoMapper_Test.Dto
{
    public class StudentListDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public BookList Book { get; set; }
    }
}
