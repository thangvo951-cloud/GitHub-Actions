# 🚀 .NET Core CI/CD Pipeline với GitHub Actions

Dự án này thiết lập một quy trình quản lý mã nguồn chuyên nghiệp bằng **Gitflow** và **GitHub Actions** cho ứng dụng .NET. Hệ thống tự động hóa toàn bộ các khâu từ khôi phục gói phụ thuộc, biên dịch mã nguồn đến kiểm thử tự động, đảm bảo mọi thay đổi đều ổn định trước khi triển khai.

---

## 🛠️ Công Nghệ Sử Dụng

* **Ngôn ngữ**: C# (.NET 8.0)
* **Framework**: .NET Core SDK
* **CI/CD Tool**: GitHub Actions (Workflow tự động)
* **Quản lý dự án**: .NET Solution (.sln) kết nối `src` và `tests`

---

## ✨ Quy Trình Tự Động Hóa (CI/CD)

Mỗi khi có mã nguồn được đẩy lên các nhánh `main` hoặc `develop`, GitHub Actions sẽ tự động thực hiện:

1. **Checkout Code**: Lấy mã nguồn mới nhất từ kho lưu trữ.
2. **Setup .NET**: Thiết lập môi trường .NET SDK phiên bản 8.x.
3. **Restore**: Khôi phục các gói NuGet cần thiết.
4. **Build**: Biên dịch dự án trên môi trường Ubuntu sạch để phát hiện lỗi cú pháp.
5. **Test**: Chạy các bài kiểm tra Unit Test tự động. Nếu có bất kỳ bài test nào thất bại, hệ thống sẽ báo lỗi đỏ ❌ và ngăn chặn việc gộp code lỗi.
6. **Notify**: Thông báo trạng thái triển khai sau khi hoàn tất kiểm tra.

---

## 🚀 Cách thức cài đặt và chạy trực tiếp trên máy (Local)

Để chạy dự án này dưới máy cá nhân và kiểm tra các tính năng, bạn hãy thực hiện theo các bước sau:

### 1. Yêu cầu môi trường
* Máy tính đã cài đặt **.NET SDK 8.0** (Phiên bản LTS).
* Đã cài đặt **Git** để quản lý mã nguồn.

> **Mẹo cài nhanh (Windows/PowerShell):**
> ```powershell
> # Cài đặt .NET SDK 8
> winget install Microsoft.DotNet.SDK.8
> 
> # Cài đặt Git
> winget install Git.Git
> ```

### 2. Tải Source Code (Clone)
Mở Terminal hoặc Git Bash tại thư mục bạn muốn lưu dự án trên máy tính và chạy lệnh:
```bash
git clone https://github.com/thangvo951-cloud/GitHub-Actions.git
cd GitHub-Actions
```

### 3. Chuỗi lệnh thực thi cốt lõi dưới máy (Chạy theo thứ tự)
Để kiểm tra dự án chạy bình thường dưới máy local trước khi đẩy lên GitHub, bạn gõ 3 lệnh sau tại thư mục gốc của dự án:

* **Bước A: Khôi phục toàn bộ thư viện NuGet (Dependencies)**
  ```bash
  dotnet restore
  ```

* **Bước B: Biên dịch dự án để quét lỗi cú pháp**
  ```bash
  dotnet build --no-restore
  ```

* **Bước C: Chạy hệ thống Unit Test để quét lỗi logic**
  ```bash
  dotnet test --no-build --verbosity normal
  ```
  *(Nếu kết quả màn hình hiển thị chữ `Passed!` màu xanh, nghĩa là code logic tính toán của bạn hoàn toàn chính xác).*

---

## 👥 Hướng Dẫn Quy Trình Làm Việc Nhóm (Gitflow)

Để nhiều thành viên cùng tham gia phát triển dự án mà không xảy ra xung đột code hoặc làm hỏng nhánh chính, toàn bộ nhóm cần tuân thủ quy trình sau:

### Bước 1: Phát triển và thử nghiệm trên nhánh `develop`
Tuyệt đối không được gõ code hoặc push thẳng vào nhánh `main`. Hãy làm việc trên nhánh phát triển:
```bash
# 1. Tạo một nhánh phát triển mới và chuyển sang nhánh đó
git checkout -b develop

# 2. Sửa đổi code hoặc chỉnh sửa file test, sau đó commit:
git add .
git commit -m "feat: cập nhật logic toán học và kịch bản test mới"

# 3. Đẩy nhánh develop lên GitHub để kích hoạt Pipeline tự động quét lỗi
git push origin develop
```

### Bước 2: Gộp code an toàn vào nhánh sản xuất `main`
Khi bạn truy cập vào giao diện Web của GitHub, vào mục **Actions** và thấy nhánh `develop` vừa đẩy lên đã chạy xong và báo **Tích xanh ✅**, lúc này bạn mới tiến hành gộp code vào nhánh `main`:
```bash
# 1. Chuyển từ nhánh develop về lại nhánh chính main
git checkout main

# 2. Cập nhật code mới nhất từ Server về máy để tránh xung đột
git pull origin main

# 3. Tiến hành gộp toàn bộ code sạch từ develop vào main
git merge develop

# 4. Đẩy sản phẩm hoàn chỉnh cuối cùng lên Server GitHub
git push origin main
```

---

## 🛠️ Hướng Dẫn Tạo Demo "Test Lỗi Đỏ" (Kiểm Tra Tính Năng Bắt Lỗi)

Nếu bạn muốn biểu diễn hoặc kiểm tra xem hệ thống GitHub Actions tự động phát hiện lỗi nhạy bén như thế nào, hãy thử làm theo kịch bản sau:

1. Dưới máy local, mở file kịch bản test tại đường dẫn: `tests/CalculatorTests.cs`.
2. Tiến hành sửa đổi giá trị mong muốn từ ĐÚNG thành SAI. Ví dụ:
   ```csharp
   // Đoạn code gốc đang ĐÚNG: 
   Assert.Equal(5, calc.Add(2, 3));

   // Hãy sửa số 5 thành số 100100 để cố tình tạo ra lỗi logic:
   Assert.Equal(100100, calc.Add(2, 3));
   ```
3. Lưu file lại, mở Terminal lên và tiến hành commit, push đoạn code lỗi này lên GitHub:
   ```bash
   git add .
   git commit -m "test: cố tình tạo lỗi logic để demo pipeline bắt lỗi"
   git push origin develop
   ```
4. **Kết quả trên GitHub:** Bạn mở trình duyệt, truy cập vào kho lưu trữ GitHub của mình và chọn tab **Actions**. Bạn sẽ thấy hệ thống lập tiếp khởi động máy ảo, chạy đến bước `dotnet test` và phát hiện ra kết quả trả về không khớp. Toàn bộ Pipeline sẽ bị nhuộm màu **X đỏ ❌** cảnh báo, đồng thời hệ thống sẽ khóa chặt, không cho phép bạn trộn (Merge) đoạn code lỗi này vào nhánh sản xuất `main`.

---
*Dự án của nhóm 21, chúc bạn có những trải nghiệm tuyệt vời khi khám phá dự án này!* 🚀