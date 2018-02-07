using System;
using System.Collections.Generic;
using NetStudy.Core;
using System.Linq;

namespace NetStudy.InDepth.Linq
{
    public class LinqRunner : IRunner
    {
        public void Run()
        {
            RunSelectMany();

            RunJoin();

            RunTakeWhileVsWhere();

            RunSkipWhileVsWhere();

            RunGroupBy();
            
            //합집합
            RunUnion();

            //교집합
            RunIntersect();
        }

        private void RunIntersect()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("Common numbers shared by both arrays:");
            foreach (var n in commonNumbers)
            {
                Console.WriteLine(n);
            }
        }

        private void RunUnion()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            foreach (var n in uniqueNumbers)
            {
                Console.WriteLine(n);
            }
        }

        private void RunGroupBy()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lambdaResultGroups = numbers.GroupBy(x => x % 5).Select(x => new {x.Key, x});
            Console.WriteLine("Lambda :", lambdaResultGroups.Count());

            foreach (var g in lambdaResultGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Key);
                foreach (var n in g.x)
                {
                    Console.WriteLine(n);
                }
            }

            var queryResultGroups =
                from n in numbers
                group n by n % 5 into g
                select new { Remainder = g.Key, Numbers = g };

            Console.WriteLine("Query :", queryResultGroups.Count());

            foreach (var g in queryResultGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }

        }

        private void RunSkipWhileVsWhere()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allAfterMatchingCondition = numbers.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("All elements starting from first element divisible by 3:");

            foreach (var n in allAfterMatchingCondition)
            {
                Console.WriteLine(n);
            }
        }

        private void RunTakeWhileVsWhere()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //TakeWhile stops when the condition is false
            var firstNumbersLessThan9 = numbers.TakeWhile(n => n < 9);

            Console.WriteLine("First numbers less than 9:");

            foreach (var n in firstNumbersLessThan9)

            {
                Console.WriteLine(n);
            }

            var allNumbersLessThan9 = numbers.Where(n => n < 9);

            Console.WriteLine("All numbers less than 9:");

            foreach (var n in allNumbersLessThan9)

            {
                Console.WriteLine(n);
            }
        }

        private void RunJoin()
        {
            var teachers = GetTeachers();

            var lambdaResults = teachers[1].Students
                .Join(teachers, s => s.TeacherId, t => t.Id, (s, t) => new { s.Id, s.Name, TeacherName = t.Name });

            Console.WriteLine($"Lambda results : {lambdaResults.Count()}");
            foreach (var result in lambdaResults)
            {
                Console.WriteLine($"Student Id = {result.Id}, Name={result.Name} , Teacher{result.TeacherName}");
            }

            var queryResults = from s in teachers[1].Students
                              from t in teachers
                              where s.TeacherId == t.Id
                              select new { s.Id, s.Name, TeacherName = t.Name};

            Console.WriteLine($"Query results : {queryResults.Count()}");
            foreach (var result in queryResults)
            {
                Console.WriteLine($"Student Id = {result.Id}, Name={result.Name} , Teacher{result.TeacherName}");
            }
        }


        private List<Teacher> GetTeachers()
        {
            return new List<Teacher>
            {
                new Teacher
                {
                    Id = 1,
                    Name = "Teach 1",
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Id = 1,
                            TeacherId = 1,
                            Name="Student 1"
                        },
                        new Student
                        {
                            Id = 2,
                            TeacherId = 1,
                            Name="Student 2"
                        }
                    }
                },
                new Teacher
                {
                    Id = 2,
                    Name = "Teach 2",
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Id = 3,
                            TeacherId = 2,
                            Name="Student 3"
                        },
                        new Student
                        {
                            Id = 4,
                            TeacherId = 2,
                            Name="Student 4"
                        }
                    }
                },
            };
        }

        private void RunSelectMany()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var lambdaResults = numbersA.SelectMany(f => numbersB, (a, b) => new { a, b }).Where((a, b) => a.a < a.b);

            Console.WriteLine($"Lambda results : {lambdaResults.Count()}");
            foreach (var result in lambdaResults)
            {
                Console.WriteLine($"{result.a} > {result.b}");
            }

            var queryResults =
                from a in numbersA
                from b in numbersB
                where a < b
                select new { a, b };

            Console.WriteLine($"Query results : {queryResults.Count()}");

            foreach (var result in queryResults)
            {
                Console.WriteLine($"{result.a} > {result.b}");
            }
        }
    }
}
