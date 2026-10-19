# BÀI TẬP THỰC HÀNH 02 – CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT

**Sinh viên:** Trần Tất Nguyên  
**MSSV:** 31251020719  
**Học phần:** Cấu trúc dữ liệu và Giải thuật  
**Giảng viên:** TS. Nguyễn Thành Huy  
**Ngôn ngữ:** C#

## 1. Cấu trúc bài nộp

```text
CTDLGT-Buoi02-BoSung-31251020719/
├── Bai1/
├── Bai2/
├── Bai3/
├── Bai4/
└── README.md
```

Mỗi thư mục `Bai1` đến `Bai4` chứa mã nguồn hoặc project C# tương ứng. Báo cáo Word được nộp riêng trên LMS theo yêu cầu của giảng viên.

## 2. Hướng dẫn chạy chương trình

**Yêu cầu:** Máy có cài .NET SDK và một trình soạn thảo/IDE hỗ trợ C# (ví dụ: Visual Studio hoặc VS Code).

1. Mở thư mục bài cần chạy (`Bai1`, `Bai2`, `Bai3` hoặc `Bai4`).
2. Mở project C# tương ứng bằng IDE và chạy chương trình.
3. Nếu thư mục chứa file `.csproj`, có thể mở terminal tại thư mục đó và chạy:

```bash
dotnet run
```

4. Nhập dữ liệu theo hướng dẫn trên màn hình. Các bài có menu cho phép thực hiện liên tiếp nhiều thao tác để kiểm thử.

> Lưu ý: Nếu chỉ lưu file `.cs` mà chưa tạo project, cần tạo project Console C# trước khi sử dụng `dotnet run`.

## 3. Bài 1 – Thống kê và đảo mảng

**Mô tả thuật toán:** Nhập `n` và `n` số nguyên; duyệt mảng một lần để tính tổng, giá trị nhỏ nhất, lớn nhất, trung bình cộng và số phần tử âm/dương/bằng 0. Sau đó sử dụng hai chỉ số `left` và `right` để hoán đổi các phần tử đối xứng, đảo mảng tại chỗ.

**Độ phức tạp:** Thống kê `Θ(n)`, đảo mảng `Θ(n)`; mỗi phần dùng `Θ(1)` bộ nhớ phụ. Sau khi mảng đã được lưu, tổng thời gian `Θ(n)`.

**Ca kiểm thử:**

| TC | Đầu vào | Nội dung cần kiểm tra |
|---|---|---|
| 1 | `[3, 7, 2, 9, 5]` | Min = 2, Max = 9, đảo thành `[5, 9, 2, 7, 3]` |
| 2 | `[-5, 0, 5, 0]` | Âm = 1, dương = 1, bằng 0 = 2 |
| 3 | `[8]` | Min = Max = 8, mảng đảo không đổi |
| 4 | `[-4, -2, -9]` | Max = -2, trung bình = -5,00 |

## 4. Bài 2 – Chèn và xóa trên mảng

**Mô tả thuật toán:** `Insert` kiểm tra chỉ số và dung lượng, dịch các phần tử từ phải sang trái để tạo chỗ, chèn giá trị mới rồi tăng `count`. `RemoveAt` kiểm tra chỉ số, dịch các phần tử phía sau sang trái và giảm `count`. `count` là số phần tử hợp lệ, còn `data.Length` là dung lượng đã cấp phát.

**Độ phức tạp:** `Insert` tại `index` mất `Θ(count - index + 1)`; `RemoveAt` mất `Θ(count - index)`; trường hợp xấu nhất `O(n)` và bộ nhớ phụ `Θ(1)` cho cả hai phương thức.

**Ca kiểm thử:**

| TC | Thao tác | Nội dung cần kiểm tra |
|---|---|---|
| 1 | Với `[4, 7, 2, 9, 5]`, chèn 99 tại index 2 rồi xóa index 1 | Sau cùng: `[4, 99, 2, 9, 5]` |
| 2 | Chèn 5 tại đầu `[10, 20, 30]` | `[5, 10, 20, 30]` |
| 3 | Chèn 40 tại cuối `[10, 20, 30]` | `[10, 20, 30, 40]` |
| 4 | Xóa phần tử đầu | Các phần tử phía sau được dịch trái |
| 5 | Xóa phần tử cuối | Không cần dịch phần tử |
| 6 | Chèn với index âm | `ArgumentOutOfRangeException` |
| 7 | Xóa với index bằng `count` | `ArgumentOutOfRangeException` |
| 8 | Chèn khi mảng đầy | `InvalidOperationException` |

## 5. Bài 3 – Quản lý danh sách Student

**Mô tả thuật toán:** Sử dụng `List<Student>` để lưu mã sinh viên, họ tên và điểm tổng kết. Chương trình có menu để thêm, cập nhật, xóa, tìm kiếm theo một phần họ tên, hiển thị danh sách và thống kê điểm. Mã sinh viên được tìm bằng cách duyệt tuần tự; không dùng LINQ cho tìm kiếm.

**Độ phức tạp:** Kiểm tra mã trùng, tìm theo mã/họ tên và xóa theo mã có độ phức tạp trường hợp xấu nhất `O(n)`; thống kê trung bình và đếm sinh viên đạt có thời gian `Θ(n)`, bộ nhớ phụ `Θ(1)` (không tính vùng lưu danh sách).

**Ca kiểm thử:**

| TC | Thao tác | Nội dung cần kiểm tra |
|---|---|---|
| 1 | Thêm SV01–SV05 | Thêm thành công 5 sinh viên |
| 2 | Thêm lại SV01 | Từ chối mã trùng |
| 3 | Thêm SV06 với điểm 11 | Từ chối điểm không hợp lệ |
| 4 | Cập nhật SV03 thành Chi Nguyễn, điểm 8 | Cập nhật thành công |
| 5 | Tìm `an` | Tìm thấy SV01 (An), không phân biệt hoa/thường |
| 6 | Tìm `xyz` | Không có kết quả |
| 7 | Xóa SV02 | Xóa thành công, còn 4 sinh viên |
| 8 | Xóa SV99 | Thông báo không tìm thấy |
| 9 | Thống kê sau khi xóa SV02 | 4 sinh viên, trung bình 7,75; 4 sinh viên đạt |
| 10 | Thống kê khi danh sách rỗng | Không chia cho 0; số sinh viên bằng 0 |

*Dữ liệu của TC1: SV01–An–8; SV02–Bình–7; SV03–Chi–4; SV04–Dũng–9; SV05–Hà–6. Các TC2–TC9 thực hiện theo thứ tự trên cùng danh sách; TC10 khởi động với danh sách rỗng.*

## 6. Bài 4 – Mảng động và Capacity

**Mô tả thuật toán:** Cài đặt `DynamicArray<T>` bằng mảng `T[]` với `Count`, `Capacity`, phương thức `Add`, `EnsureCapacity` và indexer `get/set`. Khi mảng đầy, tạo mảng mới với dung lượng tăng gấp đôi, sao chép các phần tử cũ theo đúng thứ tự và tiếp tục thêm dữ liệu. Trường hợp dung lượng ban đầu bằng 0 cần mở rộng thành ít nhất 1 để thêm phần tử đầu tiên.

**Độ phức tạp:** Indexer `get/set` là `O(1)`. `Add` khi còn chỗ `O(1)`, khi mở rộng `O(n)`, khấu hao `O(1)`; `n` lần thêm có tổng thời gian `O(n)`. Bộ nhớ lưu trữ `O(n)`; một lần mở rộng có thể cần `O(n)` bộ nhớ tạm.

**Ca kiểm thử:**

| TC | Thao tác | Nội dung cần kiểm tra |
|---|---|---|
| 1 | Thêm các số 1–4, capacity ban đầu 4 | Count = 4, Capacity = 4 |
| 2 | Thêm số 5 | Capacity 4 → 8; sao chép 4 phần tử |
| 3 | Thêm số 6–8 | Capacity vẫn là 8 |
| 4 | Thêm số 9–10 | Capacity 8 → 16; sao chép 8 phần tử |
| 5 | Đọc index 4 | Giá trị 5 |
| 6 | Gán index 4 thành 99 | Phần tử tại index 4 đổi thành 99 |
| 7 | Đọc index -1 | `ArgumentOutOfRangeException` |
| 8 | Đọc index bằng `Count` | `ArgumentOutOfRangeException` |
| 9 | Gán index bằng `Count` | `ArgumentOutOfRangeException` |
| 10 | Khởi tạo capacity = -1 | `ArgumentOutOfRangeException` |

## 7. Kiểm thử và minh chứng

Kết quả thực tế, nhận xét từng ca và ảnh chụp màn hình chương trình được trình bày trong báo cáo Word. Các bảng trên mô tả dữ liệu và **kết quả cần kiểm tra**, không phải tuyên bố mọi ca đã được chạy thành công.

## 8. Sử dụng AI

Tôi đã sử dụng ChatGPT để hỗ trợ định dạng và trình bày báo cáo, xây dựng bảng kiểm thử, đồng thời tham khảo giải thích thuật toán và cách kiểm thử. Tôi tự kiểm tra, đối chiếu mã nguồn và chịu trách nhiệm về nội dung bài nộp.
