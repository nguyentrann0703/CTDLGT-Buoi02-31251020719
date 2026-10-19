
using System;

public class Program
{
    
    static void Insert(int[] data, ref int count, int index, int value)
    {
        // Chỉ số chèn hợp lệ từ 0 đến count
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException(nameof(index));

        // Không thể chèn nếu toàn bộ các ô của mảng đã được sài
        if (count == data.Length)
            throw new InvalidOperationException("Array is full.");

        // Dịch các phần tử sang phải để tạo khoảng trống tại index và duyệt từ phải sang trái để tránh ghi đè dữ liệu chưa dịch
        for (int i = count;i > index; i--)
        {
            data[i] = data[i - 1];
        }

    
        data[index] = value;
        count++;
    }

    static void RemoveAt(int[] data, ref int count, int index)
    {
        // Chỉ số xóa hợp lệ từ 0 đến count - 1
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));

        // Dịch các phần tử phía sau sang trái để lấp vị trí bị xóa
        for (int i = index; i < count - 1; i++)
        {
            data[i] = data[i + 1];
        }
        count--;
    }

    static void PrintArray(string label, int[] data, int count)
    {
        Console.Write(label);

        for (int i = 0; i < count; i++)
        {
            Console.Write(data[i]);

            if (i < count - 1)
                Console.Write(" ");
        }

        Console.WriteLine($" | count = {count}, capacity = {data.Length}");
    }

    
    private static void Main(string[] args)
    {
        Console.Write("Enter capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        Console.Write("Enter count: ");
        int count = int.Parse(Console.ReadLine());

        if (capacity < 0|| count <0 || count> capacity)
        {
            Console.WriteLine("Invalid capacity or count");
            return;
        }

        int[] data = new int[capacity];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Input {i}th element: ");
            data[i] = int.Parse(Console.ReadLine());
        }

        PrintArray("Before: ", data, count);

        while (true)
        {
            Console.WriteLine("\n1. Insert");
            Console.WriteLine("2. RemoveAt");
            Console.WriteLine("3. Print array");
            Console.WriteLine("0. Exit");

            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
                break;

            try
            {
                if (choice == 1)
                {
                    Console.Write("Enter index: ");
                    int index = int.Parse(Console.ReadLine());

                    Console.Write("Enter value: ");
                    int value = int.Parse(Console.ReadLine());

                    Insert(data, ref count, index, value);
                    PrintArray("After insert: ", data, count);
                }
                else if (choice == 2)
                {
                    Console.Write("Enter index: ");
                    int index = int.Parse(Console.ReadLine());

                    RemoveAt(data, ref count, index);
                    PrintArray("After remove: ", data, count);
                }
                else if (choice == 3)
                {
                    PrintArray("Current array: ", data, count);
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid index!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Array is full!");
            }
        }
    }
}
