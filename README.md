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

## 📂 Cấu Trúc Thư Mục

```text
GITHUB-ACTIONS/
├── .github/workflows/
│   └── ci-cd.yml          # Cấu hình quy trình CI/CD
├── src/
│   ├── MyProject.csproj   # Dự án thực thi chính
│   └── Program.cs         # Logic ứng dụng (Calculator)
├── tests/
│   ├── tests.csproj       # Dự án kiểm thử
│   └── CalculatorTests.cs # Các kịch bản Unit Test
└── GitHub-Actions.sln     # File quản lý tổng thể Solution
```

## 🚀 Hướng Dẫn Cài Đặt & Chạy Trực Tiếp Trên Máy (Local)

Để chạy dự án này dưới máy cá nhân và kiểm tra các tính năng, bạn hãy thực hiện theo các bước sau:

### 1. Yêu cầu môi trường
* [cite_start]Máy tính đã cài đặt **.NET SDK 8.0** (Phiên bản LTS)[cite: 2].
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
Mở Terminal hoặc Command Prompt và chạy lệnh sau để tải dự án về máy:
```bash
git clone [https://github.com/thangvo951-cloud/GitHub-Actions.git](https://github.com/thangvo951-cloud/GitHub-Actions.git)
cd GitHub-Actions
```
---
*Dự án của nhóm 21, chúc bạn có những trải nghiệm tuyệt vời khi khám phá dự án này!* 🚀