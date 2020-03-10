using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMSData.Model;

namespace LMSData
{
    public class LMSDBInitializer
    {
        //private readonly Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();
        //private readonly Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();
        //private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();
        //private readonly Dictionary<int, Shipper> Shippers = new Dictionary<int, Shipper>();
        //private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();

        public static void Initialize(LMSDBContext context)
        {
            var initializer = new LMSDBInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(LMSDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Members.Any())
            {
                return; // Db has been seeded
            }

            SeedIdentifier(context);

        }

        public void SeedIdentifier(LMSDBContext context)
        {
            var courseCategories = new[]
            {
                new CourseCategory() {
                    IDNumber = "CS01",
                    Name = "Test 1"
                },
                new CourseCategory() {
                    IDNumber = "CS02",
                    Name = "Test 2"
                },
                new CourseCategory() {
                    IDNumber = "CS03",
                    Name = "Test 3"
                },
            };

            context.CourseCategories.AddRange(courseCategories);

            context.SaveChanges();
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }

}
