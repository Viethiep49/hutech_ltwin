using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLINQ
{
    // Định nghĩa lớp Student
    class Student
    {
        public int Id { get; set; }     // Mã số học sinh
        public string Name { get; set; } // Tên học sinh
        public int Age { get; set; }     // Tuổi học sinh
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách học sinh
            List<Student> students = new List<Student>()
            {
                new Student { Id = 1, Name = "An", Age = 16 },
                new Student { Id = 2, Name = "Binh", Age = 18 },
                new Student { Id = 3, Name = "Hoa", Age = 14 },
                new Student { Id = 4, Name = "Hiep", Age = 19 },
                new Student { Id = 5, Name = "Anh", Age = 17 }
            };

            // a. In toàn bộ danh sách
            Console.WriteLine("Danh sách học sinh:");
            foreach (var s in students)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // b. Học sinh tuổi từ 15 đến 18
            var tuoi1518 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            Console.WriteLine("\nHọc sinh có tuổi từ 15 đến 18:");
            foreach (var s in tuoi1518)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // c. Học sinh tên bắt đầu bằng "A"
            var tenA = students.Where(s => s.Name.StartsWith("A"));
            Console.WriteLine("\nHọc sinh có tên bắt đầu bằng 'A':");
            foreach (var s in tenA)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // d. Tổng tuổi của tất cả học sinh
            var tongTuoi = students.Sum(s => s.Age);
            Console.WriteLine($"\nTổng tuổi của tất cả học sinh: {tongTuoi}");

            // e. Học sinh có tuổi lớn nhất
            var maxAge = students.Max(s => s.Age);
            var hsLonNhat = students.Where(s => s.Age == maxAge);
            Console.WriteLine("\nHọc sinh có tuổi lớn nhất:");
            foreach (var s in hsLonNhat)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // f. Sắp xếp theo tuổi tăng dần
            var sapXep = students.OrderBy(s => s.Age);
            Console.WriteLine("\nDanh sách sau khi sắp xếp theo tuổi tăng dần:");
            foreach (var s in sapXep)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
        }
    }
}