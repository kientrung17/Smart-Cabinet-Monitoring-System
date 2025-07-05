#include <esp_now.h>
#include <WiFi.h>
#include <Wire.h>
#include "HardwareSerial.h"
#include <freertos/FreeRTOS.h>
#include <freertos/task.h>

#define RX_PIN 3  // GPIO3
#define TX_PIN 1  // GPIO1

int count=0;
HardwareSerial SerialPort(0);

// Địa chỉ MAC để gửi dữ liệu
uint8_t broadcastAddress[] = {0xD8, 0x13, 0x2A, 0x7F, 0x2F, 0xA0};

// Cấu trúc dữ liệu gửi đi
int32_t DataUart[22];
typedef struct struct_message {
  int32_t DataSend[22];
} struct_message;

struct_message myData; // Dùng để gửi dữ liệu
esp_now_peer_info_t peerInfo; // Lưu thông tin peer

unsigned long lastSendTime = 0;
const unsigned long SEND_INTERVAL = 40;

// Callback khi dữ liệu được gửi
void OnDataSent(const uint8_t *mac_addr, esp_now_send_status_t status) {
  Serial.print("\r\nLast Packet Send Status:\t");
  Serial.println(status == ESP_NOW_SEND_SUCCESS ? "Delivery Success" : "Delivery Fail");
}

// Task đọc dữ liệu từ UART
void uartTask(void *pvParameters) {
  uint8_t rx_buffer[88];  // Buffer chứa 16 byte (4 phần tử x 4 byte)
  
  while (1) {
    if (SerialPort.available() >= 88) {
        int bytesRead = SerialPort.readBytes(rx_buffer,88);
        
        // In dữ liệu nhận được
        if(bytesRead == 88) 
        {
        for (int i = 0; i < 22; i++) 
          { 
          memcpy(&DataUart[i], &rx_buffer[i * 4], sizeof(int32_t)); 
          }
          Serial.println("Received Sensor Data:"); 
          for (int i = 0; i < 22; i++) 
          { Serial.print(DataUart[i]); Serial.print(" "); }
        }
    }
    vTaskDelay(38 / portTICK_PERIOD_MS); // Chờ 35ms trước khi kiểm tra lại UART
  }
}

// Task gửi dữ liệu qua ESP-NOW
void sendDataTask(void *pvParameters) {
  while (1) {
    // Sao chép dữ liệu vào struct_message
    memcpy(myData.DataSend, DataUart, sizeof(DataUart));

    // Gửi dữ liệu qua ESP-NOW
    esp_err_t result = esp_now_send(broadcastAddress, (uint8_t *) &myData, sizeof(myData));

    if (result == ESP_OK) {
      Serial.println("Sent with success");
    } else {
      Serial.println("Error sending the data");
    }

    vTaskDelay(SEND_INTERVAL / portTICK_PERIOD_MS); // Gửi lại sau mỗi SEND_INTERVAL (30ms)
  }
}

void setup() {
  // Khởi tạo Serial Monitor
  Serial.begin(115200);

  // Thiết lập chế độ Wi-Fi là Station
  WiFi.mode(WIFI_STA);

  // Khởi tạo ESP-NOW
  if (esp_now_init() != ESP_OK) {
    Serial.println("Error initializing ESP-NOW");
    return;
  }

  // Đăng ký callback cho việc gửi dữ liệu
  esp_now_register_send_cb(OnDataSent);
  
  // Đăng ký peer
  memcpy(peerInfo.peer_addr, broadcastAddress, 6);
  peerInfo.channel = 0;
  peerInfo.encrypt = false; // Tắt mã hóa
  
  // Thêm peer
  if (esp_now_add_peer(&peerInfo) != ESP_OK) {
    Serial.println("Failed to add peer");
    return;
  }

  // Khởi tạo UART1 cho truyền nhận
  SerialPort.begin(115200, SERIAL_8N1, RX_PIN, TX_PIN);

  Serial.println("ESP32 UART Test");

  // Tạo hai task và gán cho hai core khác nhau
  xTaskCreatePinnedToCore(uartTask, "uartTask", 2048, NULL, 1, NULL, 0);  // Tạo task đọc UART trên Core 0
  xTaskCreatePinnedToCore(sendDataTask, "sendDataTask", 2048, NULL, 1, NULL, 1);  // Tạo task gửi dữ liệu trên Core 1
}

void loop() {
  // Không cần gì trong loop vì FreeRTOS sẽ quản lý các task
}
