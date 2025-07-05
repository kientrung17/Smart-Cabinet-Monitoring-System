# Đồ án Tốt nghiệp: Hệ thống Giám sát cho Tủ lưu trữ Thông minh
# Graduation Thesis: Smart Cabinet Monitoring System

Đây là đồ án tốt nghiệp cử nhân, thực hiện việc thiết kế và xây dựng một hệ thống giám sát toàn diện cho các tủ lưu trữ tài liệu thông minh, áp dụng các công nghệ IoT, hệ thống nhúng và xử lý tín hiệu.

## Kiến trúc hệ thống

Hệ thống được xây dựng dựa trên kiến trúc phân tán, bao gồm các thành phần chính sau:
1.  **Các Node Cảm biến (Sensor Nodes):** Được tích hợp vi điều khiển STM32 và các cảm biến (LiDAR, nhiệt, gia tốc) để thu thập dữ liệu trạng thái của tủ.
2.  **Module Giao tiếp (Communication Module):** Sử dụng vi điều khiển ESP32 và giao thức ESP-NOW để tạo thành một mạng không dây cục bộ, truyền dữ liệu từ các node cảm biến về một Gateway trung tâm.
3.  **Phần mềm Điều khiển Trung tâm (Desktop Application):** Một ứng dụng C# trên máy tính, có vai trò là Gateway, nhận dữ liệu từ mạng ESP-NOW và cung cấp giao diện để người dùng giám sát, điều khiển toàn bộ hệ thống.

## Cấu trúc thư mục

-   **/STM32_RTOS_Firmware:** Chứa mã nguồn firmware cho vi điều khiển STM32H745, được viết bằng C/C++ và sử dụng hệ điều hành thời gian thực (RTOS) để quản lý các tác vụ đọc cảm biến và xử lý tín hiệu.
-   **/ESP32:** Chứa mã nguồn cho các module ESP32, chịu trách nhiệm giao tiếp không dây bằng giao thức ESP-NOW.
-   **/App:** Chứa mã nguồn của ứng dụng giám sát trên máy tính, được phát triển bằng ngôn ngữ C# và nền tảng .NET.

## Công nghệ và Kỹ năng nổi bật

-   **Lập trình Nhúng:** C/C++, RTOS (FreeRTOS), STM32CubeIDE.
-   **Vi điều khiển:** STM32H7, ESP32.
-   **Tích hợp cảm biến:** LiDAR (TF-Luna), Cảm biến nhiệt (Omron D6T), Cảm biến gia tốc (IMU WT901C).
-   **Mạng không dây:** ESP-NOW.
-   **Phát triển Phần mềm Desktop:** C#, .NET Framework.
-   **Xử lý Tín hiệu:** Áp dụng thuật toán Tracking Differentiator để lọc nhiễu và ước tính vận tốc.
