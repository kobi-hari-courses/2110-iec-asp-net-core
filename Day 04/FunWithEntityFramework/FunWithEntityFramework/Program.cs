using FunWithEntityFramework.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithEntityFramework
{
    class Program
    {
        async static Task Main(string[] args)
        {
            using (var context = new UniversityDbContext())
            {
                //            await context.Database.EnsureCreatedAsync();

                var courses = context
                    .Courses 
                    .Where(c => c.Category.Contains("Prog"))
                    .OrderBy(c => c.DisplayName)
                    .ToList();

                context.Courses.Add(new Course
                {
                    Id = "beginnermath",
                    DisplayName = "Arithmatics for Beginners",
                    Category = "Mathematics"
                });

                context.Courses.Add(new Course
                {
                    Id = "advancedmath",
                    DisplayName = "Introduction to Trigonometry",
                    Category = "Mathematics"
                });

                var c = context.Courses
                    .Where(c => c.Category == "Cooking")
                    .FirstOrDefault();

                if (c != null)
                {
                    context.Courses.Remove(c);
                }

                await context.SaveChangesAsync();


            }



            //foreach (var course in courses)
            //{
            //    Console.WriteLine($"1 Name: {course.DisplayName}, Category: {course.Category}");
            //}

            //foreach (var course in courses)
            //{
            //    Console.WriteLine($"2 Name: {course.DisplayName}, Category: {course.Category}");
            //}

        }
    }
}
