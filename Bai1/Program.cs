using System;
using System.Runtime.InteropServices;
using System.Transactions;

public partial class Program
{

    private static void Main(string[] args)
    {
        // Khởi tạo mảng
        Console.Write("Enter n: "); int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i =0; i < n; i++)
        {
            Console.Write($"Input {i}th element: "); arr[i] = int.Parse(Console.ReadLine());
        }

        // Khởi tạo biến
        long sum = 0;
        int min = arr[0];
        int max = arr[0];
        int positives = 0;
        int negatives = 0;
        int zeros = 0;

        for (int i=0; i<n; i++)
        {
            // tìm max, min
            if (arr[i] > max) max = arr[i];
            if (arr[i] < min) min = arr[i];

            // tìm positives, negatives, zeros

            if (arr[i] > 0) positives ++;
            else if (arr[i] < 0) negatives++;
            else zeros++;
            
            // tính sum để tính average
            sum += arr[i];

        }
        // tính average. Cần phải cast double cho sum trước để tránh hiện tượng làm tròn số
        double average = (double) sum/ n;

        
        // Khởi tạo biến left, right
        int left = 0;
        int right = n-1;
        while (left< right)
        {   
            // Khởi tạo biến tạm để chứa giá trị left 
            int temp  = arr[left];

            // Đổi phần từ bên phải sang trái
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
        Console.WriteLine($"Max = {max}| Min = {min} | Average = {average:F2}");
        Console.WriteLine($"Positves = {positives}| Negatives = {negatives} | Zeros = {zeros}");
        Console.WriteLine("Reversed array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{arr[i]}\t");
        }
        Console.WriteLine();

    }
}

