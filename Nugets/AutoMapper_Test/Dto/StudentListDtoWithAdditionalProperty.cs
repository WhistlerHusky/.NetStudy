using AutoMapper_Test.Core;

namespace AutoMapper_Test.Dto
{
    public class StudentListDtoWithAdditionalProperty
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }
        public BookList Book { get; set; }
    }
}
