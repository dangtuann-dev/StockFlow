# Phần Mềm Quản Lý Kho Hàng (StockFlow) 📦

**Đồ Án Môn Lập Trình Ứng Dụng**

StockFlow là hệ thống phần mềm desktop được xây dựng với mục tiêu số hoá quy trình nhập/xuất và tồn kho, giúp thay thế phương pháp quản lý thủ công truyền thống.

## 🎯 1. Mục tiêu dự án

- Quản lý toàn diện hàng hoá, nhà cung cấp/khách hàng, phiếu nhập/xuất và tình trạng tồn kho theo thời gian thực.
- Giảm thiểu sai sót khi ghi chép thủ công, tối ưu hoá khả năng tra cứu và thống kê dữ liệu.
- Xây dựng kiến trúc phần mềm linh hoạt (mô hình 3 lớp), dễ dàng bảo trì và mở rộng các module trong tương lai.

## ⚙️ 2. Phạm vi & Chức năng chính

Dựa trên cấu trúc cơ sở dữ liệu, hệ thống tập trung vào các luồng nghiệp vụ cốt lõi sau:

- **Quản lý Hệ thống (Bảng USERS):**
  - Đăng nhập hệ thống.
  - Quản lý thông tin tài khoản nhân viên/người dùng (Họ tên, Tên đăng nhập, Mật khẩu, Số điện thoại).

- **Quản lý Danh mục Hàng hóa (Bảng CATEGORIES & PRODUCTS):**
  - **Danh mục (Categories):** Phân loại hàng hóa thành các nhóm khác nhau để dễ quản lý.
  - **Sản phẩm (Products):** Quản lý thông tin chi tiết của từng mặt hàng (Tên, Mô tả) và theo dõi trực tiếp **số lượng tồn kho (Quantity)**. Mỗi sản phẩm được gắn với một danh mục cụ thể.

- **Quản lý Khách hàng (Bảng CUSTOMERS):**
  - Lưu trữ và quản lý danh sách khách hàng (Tên khách hàng) tham gia vào quá trình xuất kho/mua hàng.

- **Nghiệp vụ Xuất kho / Bán hàng (Bảng ORDERS & ORDER_DETAILS):**
  - **Đơn hàng/Phiếu xuất (Orders):** Ghi nhận thông tin mỗi lần xuất hàng, bao gồm Khách hàng nhận và Ngày lập đơn (OrderDate).
  - **Chi tiết xuất kho (Order Details):** Ghi nhận chi tiết từng mặt hàng được xuất trong một đơn hàng, bao gồm Số lượng xuất (Qty) và Tổng tiền (Total).
  - **Cập nhật tồn kho:** (Logic BLL) Tự động trừ số lượng tồn kho (Quantity) trong bảng Products mỗi khi tạo đơn xuất hàng thành công.

## 💻 3. Công nghệ sử dụng

| Hạng mục               | Công nghệ                |
| :--------------------- | :----------------------- |
| **Ngôn ngữ lập trình** | C#                       |
| **Giao diện (UI)**     | Windows Forms (WinForms) |
| **Backend Framework**  | .NET                     |
| **Cơ sở dữ liệu**      | SQL Server               |

## 🏗️ 4. Kiến trúc đề xuất (3-Tier Architecture)

- **UI (WinForms):** Quản lý Form/Controls, validate dữ liệu đầu vào và gọi các hàm từ tầng Service.
- **Business/Service (BLL):** Chứa logic nghiệp vụ (ví dụ: quy tắc tính toán tồn kho, kiểm tra điều kiện xuất/nhập).
- **Data Access (DAL):** Tương tác trực tiếp với Database (CRUD, Query, Transaction).
- **Database:** Lưu trữ bảng Danh mục, Chứng từ và Chi tiết chứng từ.

## 👥 5. Thành viên & Vai trò

| STT | MSSV       | Họ và tên          | Vai trò            | Liên hệ                                                |
| :-- | :--------- | :----------------- | :----------------- | :----------------------------------------------------- |
| 1   | 2400000794 | Đặng Thanh Tuấn    | **Tech Leader**    | [GitHub](https://github.com/dangtuann-dev)             |
| 2   | 2400004037 | Vũ Chi Tôn         | Backend + Database | [GitHub](https://github.com/vutoncode)                 |
| 3   | 2400009245 | Trương Gia Khang   | Desktop Interface  | [GitHub](https://github.com/giakhang14112006)          |
| 4   | 2400003798 | Nguyễn Đức Duy     | Desktop Interface  | [GitHub](https://github.com/Duy042006)                 |
| 5   | 2400008936 | Trần Quỳnh Như     | Backend            | [GitHub](https://github.com/tranquynhnhu102025-hashef) |
| 6   | 2400004752 | Cao Thị Thùy Dương | Backend            | [GitHub](https://github.com/thuyduongdev)              |

## 🔄 6. Quy ước làm việc

- [HƯỚNG DẪN DÙNG GITHUB TRONG PHÁT TRIỂN PHẦN MỀM (TEAM WORKFLOW)](link_den_tai_lieu_huong_dan_github)

## 📊 7. Phân công & Theo dõi

- [Bảng Phân Công & Theo Dõi Công Việc](link_den_bang_theo_doi_tien_do)

## ✅ 8. Tiêu chí hoàn thành (Definition of Done)

1. Source code chạy ổn định trên máy giảng viên/thành viên với hướng dẫn cấu hình rõ ràng.
2. Luồng nhập/xuất cập nhật tồn kho chính xác và có validate dữ liệu.
3. Có sẵn script sinh dữ liệu mẫu (Mock data) để demo.
4. Hoàn thiện UI tối thiểu cho: CRUD danh mục, tạo phiếu nhập/xuất, xem tồn kho.

---

_Ghi chú: Các tính năng "tuỳ chọn" sẽ được triển khai vào giai đoạn cuối nếu tiến độ cho phép._
