using System;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using AutoMapper_Practice.Core;
using AutoMapper_Practice.Dto;
using NetStudy.Core;

namespace AutoMapper_Practice
{
    public class AutoMapperRunner : IRunner
    {
        public void Run()
        {
            // 1. Sttatic method 이용한 방법
            //Mapper.Initialize(x => { });

            // 2. configuration 이용한 방법
            var config = new MapperConfiguration(x => { });
            var mapper = config.CreateMapper();
            
            //RunAutoMapper(mapper); // Without creating map

            //config = new MapperConfiguration(x => { x.CreateMap<Student, StudentListDtoWithAdditionalProperty>();});
            //mapper = config.CreateMapper();
            //RunAutoMapper(mapper); // With creating map
            
            config = new MapperConfiguration(x => {
                x.CreateMap<Student, StudentListDtoWithAdditionalProperty>(); //일일이 매핑
                x.CreateMap<Student, StudentEditDto>(); // 이거 주석치면 안됨,,잘 모르겠음 
                x.AddMemberConfiguration().AddName<PrePostfixName>(
                    _ => _.AddStrings(p => p.DestinationPostfixes, "EditDto"));
                x.AddConditionalObjectMapper().Where((s, d) => d.Name == s.Name + "EditDto");
            });

            mapper = config.CreateMapper();
            RunAutoMapper(mapper); // With creating map
        }

        private void RunAutoMapper(IMapper mapper)
        {
            var student = new Student
            {
                Age = 19,
                Name = "Jun",
                Book = new Book
                {
                    Title = "TestBook",
                    Page = 200
                }
            };

            //아래는 맵핑없이도 작동함, 이유는 StudentListDto와 Student 클래스가 정확하게 동일한 멤버 프라퍼티를 가지고기 때문
            var studentListDto = mapper.Map<StudentListDto>(student);

            Console.WriteLine(studentListDto.Age);
            Console.WriteLine(studentListDto.Name);
            Console.WriteLine(studentListDto.Book.Page);
            Console.WriteLine(studentListDto.Book.Title);
            try
            {
                //아래 예외발생, StudentListDtoWithAdditionalProperty는 추가 프라퍼티가 있기때문에 맵핑정보없이 맵핑이 안됨. 
                var studentListDtoWithAdditionalProperty = mapper.Map<StudentListDtoWithAdditionalProperty>(student);
                Console.WriteLine(studentListDtoWithAdditionalProperty.Age);
                Console.WriteLine(studentListDtoWithAdditionalProperty.Name);
                Console.WriteLine(studentListDtoWithAdditionalProperty.Book.Page);
                Console.WriteLine(studentListDtoWithAdditionalProperty.Book.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return;
            }

            try
            {
                var studentEditDto = mapper.Map<StudentEditDto>(student);
                Console.WriteLine(studentEditDto.Age);
                Console.WriteLine(studentEditDto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
