using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new SchoolContextFactory().CreateDbContext())
            {
                List<SchoolClass> schoolClasses = context.SchoolClasses.ToList();

                foreach (SchoolClass item in schoolClasses)
                {
                    Console.WriteLine($"{item.Name}\t{item.Department}\t{item.Id}");
                }
            }
        }
    }
}
