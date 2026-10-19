using System;

public class DynamicArray<T>
{
    // Mảng bên trong dùng để lưu dữ liệu, không dùng List<T>.
    private T[] items;

    // Count là số phần tử đang có trong mảng.
    public int Count { get; private set; }

    // Capacity là tổng số ô đã cấp phát.
    public int Capacity => items.Length;

    // Theo dõi số phần tử được sao chép khi mở rộng.
    public int LastCopied { get; private set; }

    public DynamicArray(int capacity = 4)
    {
        // Không cho phép cấp phát mảng với dung lượng âm.
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        // Tạo mảng với dung lượng ban đầu được yêu cầu.
        items = new T[capacity];
        Count = 0;
        LastCopied = 0;
    }

    public void Add(T item)
    {
        // Kiểm tra và tăng dung lượng trước khi thêm nếu mảng đã đầy.
        EnsureCapacity();

        // Đặt phần tử mới vào ô trống ngay sau phần tử hợp lệ cuối cùng.
        items[Count] = item;

        // Tăng số phần tử hợp lệ sau khi thêm thành công.
        Count++;
    }

    private void EnsureCapacity()
    {
        // Mỗi lần Add bắt đầu với số phần tử sao chép bằng 0.
        LastCopied = 0;

        // Nếu vẫn còn ô trống thì không cần cấp phát lại.
        if (Count < Capacity)
            return;

        // Nếu Capacity = 0, bắt đầu từ 1; còn lại tăng gấp đôi.
        int newCapacity = Capacity == 0 ? 1 : Capacity * 2;

        // Tạo mảng mới lớn hơn để chứa cả dữ liệu cũ và phần tử mới.
        T[] newItems = new T[newCapacity];

        // Sao chép đúng Count phần tử, giữ nguyên thứ tự.
        for (int i = 0; i < Count; i++)
        {
            newItems[i] = items[i];
            LastCopied++;
        }

        // Chuyển sang vùng lưu trữ mới sau khi sao chép xong.
        items = newItems;
    }

    public T this[int index]
    {
        get
        {
            // Chỉ được đọc vị trí có phần tử hợp lệ.
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Truy cập trực tiếp theo chỉ số, không cần duyệt mảng.
            return items[index];
        }
        set
        {
            // Không được gán vào chỉ số ngoài vùng dữ liệu hợp lệ.
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Cập nhật giá trị ngay tại ô được chọn.
            items[index] = value;
        }
    }
}

public class Program
{
    // Hiển thị các phần tử đang hợp lệ mà không tạo mảng phụ.
    static void PrintArray(DynamicArray<int> data)
    {
        Console.Write("Array: ");
        for (int i = 0; i < data.Count; i++)
        {
            Console.Write(data[i]);
            if (i < data.Count - 1)
                Console.Write(" ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Nhập dung lượng ban đầu để thử cả trường hợp mặc định và capacity = 0.
        Console.Write("Enter capacity (default 4): ");
        string input = Console.ReadLine() ?? "";
        int capacity = input == "" ? 4 : int.Parse(input);

        DynamicArray<int> data;
        try
        {
            // Tạo mảng động, kiểm tra capacity âm ở constructor.
            data = new DynamicArray<int>(capacity);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid capacity.");
            return;
        }

        // Cho người dùng thực hiện nhiều thao tác trên cùng một mảng.
        while (true)
        {
            Console.WriteLine("\n1. Add | 2. Get | 3. Set | 4. Print | 0. Exit");
            Console.Write("Choose: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            if (choice == 0)
                break;

            try
            {
                if (choice == 1)
                {
                    // Thêm phần tử và in trạng thái sau mỗi lần Add.
                    Console.Write("Enter value: ");
                    int value = int.Parse(Console.ReadLine());
                    int oldCapacity = data.Capacity;
                    data.Add(value);
                    Console.WriteLine($"Count = {data.Count} | Capacity = {data.Capacity} | Copied = {data.LastCopied}");
                    if (oldCapacity != data.Capacity)
                        Console.WriteLine($"Capacity changed: {oldCapacity} -> {data.Capacity}");
                }
                else if (choice == 2)
                {
                    // Đọc trực tiếp phần tử qua indexer.
                    Console.Write("Enter index: ");
                    int index = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Value = {data[index]}");
                }
                else if (choice == 3)
                {
                    // Cập nhật giá trị tại chỉ số hợp lệ qua indexer.
                    Console.Write("Enter index: ");
                    int index = int.Parse(Console.ReadLine());
                    Console.Write("Enter new value: ");
                    int value = int.Parse(Console.ReadLine());
                    data[index] = value;
                    PrintArray(data);
                }
                else if (choice == 4)
                {
                    PrintArray(data);
                    Console.WriteLine($"Count = {data.Count} | Capacity = {data.Capacity}");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Xử lý các trường hợp index âm hoặc index >= Count.
                Console.WriteLine("Invalid index.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }
}
