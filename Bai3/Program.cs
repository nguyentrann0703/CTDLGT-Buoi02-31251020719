using System;
using System.Collections.Generic;

public class Student
{
    public string Id { get; set; } = "";
    public string FullName { get; set; } = "";
    public double Score { get; set; }
}

public class Program
{
    static int FindById(List<Student> students, string id)
    {
        // Duyệt lần lượt vì mã sinh viên không phải chỉ số của List
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Id == id) return i;
        }
        return -1;
    }

    static void AddStudent(List<Student> students)
    {
        Console.Write("Enter ID: ");
        string id = Console.ReadLine() ?? "";

        // Không thêm nếu mã đã tồn tại trong danh sách
        if (FindById(students, id) != -1 || id.Trim() == "")
        {
            Console.WriteLine("Invalid or duplicate ID.");
            return;
        }

        Console.Write("Enter full name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter score: ");

        // Chỉ chấp nhận điểm hợp lệ trong đoạn từ 0 đến 10
        if (!double.TryParse(Console.ReadLine(), out double score) || score < 0 || score > 10)
        {
            Console.WriteLine("Invalid score.");
            return;
        }

        students.Add(new Student { Id = id, FullName = name, Score = score });
        Console.WriteLine("Added successfully.");
    }

    static void UpdateStudent(List<Student> students)
    {
        Console.Write("Enter ID to update: ");
        string id = Console.ReadLine() ?? "";
        int index = FindById(students, id);
        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter new name: ");
        string newName = Console.ReadLine() ?? "";
        Console.Write("Enter new score: ");
        if (!double.TryParse(Console.ReadLine(), out double score) || score < 0 || score > 10)
        {
            Console.WriteLine("Invalid score.");
            return;
        }

        // Chỉ cập nhật dữ liệu khi điểm mới hợp lệ.
        students[index].FullName = newName;
        students[index].Score = score;
        Console.WriteLine("Updated successfully.");
    }

    static void RemoveStudent(List<Student> students)
    {
        Console.Write("Enter ID to remove: ");
        string id = Console.ReadLine() ?? "";
        int index = FindById(students, id);
        if (index == -1)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        // RemoveAt dịch các phần tử phía sau để lấp vị trí vừa xóa
        students.RemoveAt(index);
        Console.WriteLine("Removed successfully.");
    }

    static void SearchStudent(List<Student> students)
    {
        Console.Write("Enter part of name: ");
        string keyword = Console.ReadLine() ?? "";
        bool found = false;

        // Tìm theo một phần họ tên, không phân biệt chữ hoa và thường
        foreach (Student student in students)
        {
            if (student.FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine($"{student.Id} | {student.FullName} | {student.Score:F2}");
                found = true;
            }
        }
        if (!found) Console.WriteLine("No results.");
    }

    static void PrintStatistics(List<Student> students)
    {
        double sum = 0;
        int passed = 0;

        foreach (Student student in students)
        {
            sum += student.Score;
            if (student.Score >= 5) passed++;
        }

        // Tránh chia cho 0 nếu danh sách đang rỗng
        double average = students.Count == 0 ? 0 : sum / students.Count;
        Console.WriteLine($"Students: {students.Count} | Average: {average:F2} | Passed: {passed}");
    }

    static void PrintStudents(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("List is empty.");
            return;
        }
        foreach (Student student in students)
            Console.WriteLine($"{student.Id} | {student.FullName} | {student.Score:F2}");
    }

    static void Main()
    {
        List<Student> students = new List<Student>();
        while (true)
        {
            Console.WriteLine("\n1. Add | 2. Update | 3. Remove | 4. Search | 5. List | 6. Statistics | 0. Exit");
            Console.Write("Choose: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            switch (choice)
            {
                case 1: AddStudent(students); break;
                case 2: UpdateStudent(students); break;
                case 3: RemoveStudent(students); break;
                case 4: SearchStudent(students); break;
                case 5: PrintStudents(students); break;
                case 6: PrintStatistics(students); break;
                case 0: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
