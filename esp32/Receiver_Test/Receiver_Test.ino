#include <esp_now.h>
#include <WiFi.h>
#include <HardwareSerial.h> // UART

// UART
  // HardwareSerial MySerial(0);   // using UART0 
HardwareSerial SerialPort(0); // if use UART2

// Structure example to receive data
// Must match the sender structure
typedef struct struct_message {
    int32_t DataReceive[22];
} struct_message;
int32_t DataSendWf[22] = {0};
// Create a struct_message called myData
struct_message myData;

// callback function that will be executed when data is received
void OnDataRecv(const uint8_t * mac, const uint8_t *incomingData, int len) {
  memcpy(&myData, incomingData, sizeof(myData));

        for (int i = 0; i < 22; i++) {
    Serial.write((uint8_t*)&myData.DataReceive[i], sizeof(int32_t));
  }

  // for(int i = 0; i < 21; i++) {
  //   Serial.print(myData.DataReceive[i]);
    
  //   // if(i < 20) Serial.print(", "); // Thêm dấu phẩy giữa các số, trừ số cuối
  // }

  // for(int i = 0; i < 21; i++) {
  //   SerialPort.print(myData.DataReceive[i]);
  //   if(i < 20) SerialPort.print(", ");
  // }
  // SerialPort.println("]");
  // Serial.println();
    //   for(int i=0;i<21;i++)
    // {
    //   DataSendWf[i] = myData.DataReceive[i];
    // }


  // MySerial.print(DataSendWf[21]);
}
 
void setup() {
  // Initialize Serial Monitor
  Serial.begin(115200);
  
  // Set device as a Wi-Fi Station
  WiFi.mode(WIFI_STA);

  if (esp_now_init() != ESP_OK) {
  // Serial.println("Error initializing ESP-NOW");
  return;
}
  // Once ESPNow is successfully Init, we will register for recv CB to
  // get recv packer info
  esp_now_register_recv_cb(esp_now_recv_cb_t(OnDataRecv));

  // SerialPort.begin (BaudRate, SerialMode, RX_pin, TX_pin) cau truc lenh setup uart.
  SerialPort.begin(115200, SERIAL_8N1, 03, 01); 
}
 
void loop() {

    //   for (int i = 0; i < 21; i++) {
    //   Serial.print(myData.DataReceive[i]);
    //   Serial.print(" ");
    // }
    // Serial.println();
  
  // MySerial.print(DataSendWf[21]);
}