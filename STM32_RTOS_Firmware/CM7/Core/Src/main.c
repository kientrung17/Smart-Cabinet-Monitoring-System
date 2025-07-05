/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2024 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "cmsis_os.h"
#include "dma.h"
#include "i2c.h"
#include "usart.h"
#include "usb_otg.h"
#include "gpio.h"
#include "math.h"
/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "D6T.h"
#include "IMU.h"
#include "TOF.h"

#include "FreeRTOS.h"
#include "task.h"
#include "timers.h"
#include "queue.h"
#include "semphr.h"
#include "event_groups.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

#ifndef HSEM_ID_0
#define HSEM_ID_0 (0U) /* HW semaphore 0*/
#endif

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */


int32_t velocity = 0;              // Giá trị vận tốc tính được

// Tham số bộ Tracking Different
float h = 0.02f; // Bước thời gian (0.02 giây)
float r = 3.0f; // Tham số r
float alpha1 = 1.0f; // Tham số alpha1
float alpha2 = 3.0f; // Tham số alpha2
float x1_prev = 0.0f; // Giá trị trước đó của x1
float x2_prev = 0.0f; // Giá trị trước đó của x2
// END
/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */

TOF_LunaTypedef tof_luna;
IMU_Typedef imu;

float Accel;
int16_t tP[16];

int dem = 0;

uint8_t Downward[] = {ADDRESS, READ, 0x00, 0x34, 0x00, 0x03, 0x49, 0x84};
uint8_t Upward[11] = {0};
uint8_t Head;
int32_t Test_Laser[5];
HAL_StatusTypeDef ret,retIT;
float retVal;
float x,y,z;
int32_t DistanceDMA;

uint8_t TxData[6] = {0x5A, 0x06, 0x03, 0xFA, 0x00, 0x00};

int32_t TxEsp32[22] = {0};
int32_t RxEsp32[5];

uint8_t Laser_DMA[45];
uint8_t Imu_DMA[11];

int32_t DistanceData[2];

uint8_t RxFreq[6];
uint8_t RxData[45];


/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
void MX_FREERTOS_Init(void);
/* USER CODE BEGIN PFP */

/***************************** TASK HANDLE ****************************/
xTaskHandle Sender_HPT_Handler;
xTaskHandle Receiver_Handler;
xTaskHandle Read_IMU_Handler;
xTaskHandle Read_IR_Handler;
xTaskHandle Init_Handler;

/***************************** QUEUE HANDLER ***************************/
QueueHandle_t xQueueLaser, xQueueIMU, xQueueIR,xQueueRxData;
xQueueHandle St_Queue_Handler;


/***************************** SEMAPHORE HANDLER *******************************/

SemaphoreHandle_t xBinarySemaphore;

/***************************** TASK FUNCTION ***************************/
//void Sender_HPT_Task(void *argument);
void Read_IMU_Task(void *argument);
void Receiver_Task(void *argument);
void Read_IR_Task(void *argument);

void vInitTask(void *pvParameters);
/***************************** API *************************************/

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{

  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */
/* USER CODE BEGIN Boot_Mode_Sequence_0 */
  int32_t timeout;
/* USER CODE END Boot_Mode_Sequence_0 */

/* USER CODE BEGIN Boot_Mode_Sequence_1 */
  /* Wait until CPU2 boots and enters in stop mode or timeout*/
  timeout = 0xFFFF;
  while((__HAL_RCC_GET_FLAG(RCC_FLAG_D2CKRDY) != RESET) && (timeout-- > 0));
  if ( timeout < 0 )
  {
  Error_Handler();
  }
/* USER CODE END Boot_Mode_Sequence_1 */
  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();
/* USER CODE BEGIN Boot_Mode_Sequence_2 */
/* When system initialization is finished, Cortex-M7 will release Cortex-M4 by means of
HSEM notification */
/*HW semaphore Clock enable*/
__HAL_RCC_HSEM_CLK_ENABLE();
/*Take HSEM */
HAL_HSEM_FastTake(HSEM_ID_0);
/*Release HSEM in order to notify the CPU2(CM4)*/
HAL_HSEM_Release(HSEM_ID_0,0);
/* wait until CPU2 wakes up from stop mode */
timeout = 0xFFFF;
while((__HAL_RCC_GET_FLAG(RCC_FLAG_D2CKRDY) == RESET) && (timeout-- > 0));
if ( timeout < 0 )
{
Error_Handler();
}
/* USER CODE END Boot_Mode_Sequence_2 */

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_DMA_Init();
  MX_USB_OTG_FS_PCD_Init();
  MX_UART4_Init();
  MX_UART7_Init();
  MX_USART1_UART_Init();
  MX_USART2_UART_Init();
  MX_UART5_Init();
  MX_I2C1_Init();
  MX_USART3_UART_Init();
  MX_I2C2_Init();
  /* USER CODE BEGIN 2 */

  /******************************* CREATE INTEGER QUEUE **********************/
  xQueueLaser = xQueueCreate(10, sizeof(int32_t[2]));  // Laser gửi 5 giá trị
  xQueueIMU = xQueueCreate(10, sizeof(int32_t[3]));    // IMU gửi 3 giá trị
  xQueueIR = xQueueCreate(10, sizeof(int32_t[16]));    // IR gửi 16 giá trị
  xQueueRxData = xQueueCreate(10, sizeof(int32_t[5]));

  /******************************** CREATE SEMAPHORE *************************/
  xBinarySemaphore = xSemaphoreCreateBinary();
  xSemaphoreGive(xBinarySemaphore);

  /******************************** TASK RELETED ***************************/

  x1_prev = GET_Distance(&huart4);

	ret = HAL_UART_Receive_IT(&huart2, Upward, 11);

  xTaskCreate(vInitTask, "Init task", 128, NULL, 3, &Init_Handler);

//  xTaskCreate(Sender_HPT_Task, "HPT SEND", 128, NULL, 2, &Sender_HPT_Handler);
  xTaskCreate(Read_IMU_Task, "Read IMU", 128, NULL, 2, &Read_IMU_Handler);
  xTaskCreate(Read_IR_Task	 , "Read IR" , 128, NULL, 2, &Read_IR_Handler);

  xTaskCreate(Receiver_Task, "RECEIVE", 128, NULL, 3, &Receiver_Handler);
//  xTaskCreate(Process_Received_Data_Task, "Process_Received_Data_Task", 256, NULL, 2, NULL);

  vTaskStartScheduler();
  /* USER CODE END 2 */

  /* Call init function for freertos objects (in cmsis_os2.c) */
  MX_FREERTOS_Init();

  /* We should never get here as control is now taken by the scheduler */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Supply configuration update enable
  */
  HAL_PWREx_ConfigSupply(PWR_DIRECT_SMPS_SUPPLY);

  /** Configure the main internal regulator output voltage
  */
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE3);

  while(!__HAL_PWR_GET_FLAG(PWR_FLAG_VOSRDY)) {}

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_BYPASS;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 1;
  RCC_OscInitStruct.PLL.PLLN = 45;
  RCC_OscInitStruct.PLL.PLLP = 2;
  RCC_OscInitStruct.PLL.PLLQ = 2;
  RCC_OscInitStruct.PLL.PLLR = 2;
  RCC_OscInitStruct.PLL.PLLRGE = RCC_PLL1VCIRANGE_3;
  RCC_OscInitStruct.PLL.PLLVCOSEL = RCC_PLL1VCOWIDE;
  RCC_OscInitStruct.PLL.PLLFRACN = 0;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2
                              |RCC_CLOCKTYPE_D3PCLK1|RCC_CLOCKTYPE_D1PCLK1;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.SYSCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB3CLKDivider = RCC_APB3_DIV2;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_APB1_DIV4;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_APB2_DIV4;
  RCC_ClkInitStruct.APB4CLKDivider = RCC_APB4_DIV2;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_3) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	BaseType_t xHigherPriorityTaskWoken = pdFALSE;
	if(huart == &huart4) // Laser
	{
		int32_t Distance;
        int32_t laser_data[5];
        laser_data[0] = (int32_t)(Laser_DMA[0 + 2] | Laser_DMA[0 + 3] << 8U);
        laser_data[1] = (int32_t)(Laser_DMA[9 + 2] | Laser_DMA[9 + 3] << 8U);
        laser_data[2] = (int32_t)(Laser_DMA[18 + 2] | Laser_DMA[18 + 3] << 8U);
        laser_data[3] = (int32_t)(Laser_DMA[27 + 2] | Laser_DMA[27 + 3] << 8U);
        laser_data[4] = (int32_t)(Laser_DMA[36 + 2] | Laser_DMA[36 + 3] << 8U);

        Distance = (laser_data[0] + laser_data[1] + laser_data[2] + laser_data[3] + laser_data[4]) /5;

		 // Update Tracking Differentiator

        float x2_new = x2_prev + h * (-alpha1 * r * r * (x1_prev - Distance) - alpha2 * r * x2_prev);
        float x1_new = x1_prev + h * x2_prev;

        // Update value
        x1_prev = x1_new;
        x2_prev = x2_new;

        // Update velocity
        velocity =  x2_new;

        // Send data through the queue
        DistanceData[0] = x1_new;
        DistanceData[1] = velocity;
        xQueueSendFromISR(xQueueLaser, DistanceData, &xHigherPriorityTaskWoken);

		HAL_UART_Receive_DMA(&huart4, Laser_DMA, 45);
	}
	if(huart == &huart2) // Read Sensor IMU
	{
		int32_t imu_data[3];
		x = imu.Acceleration.Xasis_Accel = (int16_t)((Upward[3] << 8U) | Upward[4]);
		y = imu.Acceleration.Yasis_Accel = (int16_t)((Upward[5] << 8U) | Upward[6]);
		z = imu.Acceleration.Zasis_Accel = (int16_t)((Upward[7] << 8U) | Upward[8]);

		imu_data[0] = (int32_t) imu.Acceleration.Xasis_Accel;
		imu_data[1] = (int32_t) imu.Acceleration.Yasis_Accel;
		imu_data[2] = (int32_t) imu.Acceleration.Zasis_Accel;

		x = (float)(x/32768)*16;
		y = (float)(y/32768)*16;
		z = (float)(z/32768)*16;
		retVal = (float) sqrt(x*x + y*y + z*z); // Calculate the average acceleration

		// Send data through the queue
		xQueueSendFromISR(xQueueIMU, imu_data, &xHigherPriorityTaskWoken);

	}
	portYIELD_FROM_ISR(xHigherPriorityTaskWoken);
}

void vInitTask(void *pvParameters)
{

    uint8_t init_success[70U] = "Initialize system Successfully";

    while(1)
    {
//
//        do
//        {
//            status = Init_TOF(&huart4, &tof_luna);
//        } while (status);
//
//        Distance = GET_Distance(&huart4) + 2U;

//    	TOF_FRAMERATE_SETTING(&huart2, 250);
        HAL_UART_Transmit(&huart3, init_success, 30U, 200U);
        /* Suspend InitTask after initialization */
        vTaskDelete(NULL); /* Delete itself */
    }
}

void Read_IMU_Task(void *argument)
{
	uint32_t TickDelay = pdMS_TO_TICKS(5);
	while(1)
	{
		HAL_UART_Transmit(&huart2, Downward, 8, 1000);

		ret = HAL_UART_Receive_IT(&huart2, Upward, 11);

        vTaskDelay(TickDelay);
	}
}

void Read_IR_Task(void *argument)
{
	uint32_t TickDelay = pdMS_TO_TICKS(40);
	while(1)
	{
			int32_t ir_data[16];
			D6T_getvalue(&hi2c1, tP);

			for(int i=0;i<16;i++)
			{
				ir_data[i] = (int32_t) tP[i];
			}

			xQueueSend(xQueueIR, ir_data, portMAX_DELAY);

		vTaskDelay(TickDelay);
	}
}
void Receiver_Task(void *argument)
{
	int32_t receivedLaser[2];
	int32_t receivedIMU[3], receivedIR[16];
	uint32_t TickDelay = pdMS_TO_TICKS(40);
	while(1)
	{
        if (xQueueReceive(xQueueLaser, receivedLaser, 0) == pdTRUE)
        {
            // Laser sensor data processing
            TxEsp32[0] = 0xFFFA;
            TxEsp32[1] = receivedLaser[0];
            TxEsp32[21] = receivedLaser[1];
        }

        if (xQueueReceive(xQueueIMU, receivedIMU, 0) == pdTRUE)
        {
            // IMU sensor data processing
            TxEsp32[18] = receivedIMU[0];
            TxEsp32[19] = receivedIMU[1];
            TxEsp32[20] = receivedIMU[2];
        }

        if (xQueueReceive(xQueueIR, receivedIR, 0) == pdTRUE)
        {
            // IR sensor data processing
            for (int i = 0; i < 16; i++)
            {
                TxEsp32[i + 2] = receivedIR[i];
            }
        }
//        HAL_UART_Transmit_IT(&huart5,(uint8_t*)TxEsp32, sizeof(TxEsp32));
        // Transmit data to ESP32

        HAL_UART_Transmit(&huart3,TxEsp32, sizeof(TxEsp32),1000);
        // Transmit data to WinForm
        if (HAL_UART_Receive(&huart5, RxEsp32, sizeof(RxEsp32), 100) == HAL_OK)
               {
                   // Send the received data to the queue for processing
                   xQueueSend(xQueueRxData, RxEsp32, portMAX_DELAY);
               }

        HAL_GPIO_TogglePin(SAMPLE_IMU_GPIO_Port, SAMPLE_IMU_Pin);

		vTaskDelay(TickDelay);
	}

}
void Process_Received_Data_Task(void *argument)
{
    uint8_t receivedData[5];

    while (1)
    {
        // Wait for data from the xQueueRxData queue
        if (xQueueReceive(xQueueRxData, receivedData, portMAX_DELAY) == pdTRUE)
        {
            // Xử lý dữ liệu nhận được (ví dụ: giải mã, tính toán)
            // Thêm logic xử lý cụ thể của bạn ở đây
            // Ví dụ: In ra dữ liệu nhận được
            printf("Received Data: %s\n", receivedData);
        }
    }
}

/* USER CODE END 4 */

/**
  * @brief  Period elapsed callback in non blocking mode
  * @note   This function is called  when TIM1 interrupt took place, inside
  * HAL_TIM_IRQHandler(). It makes a direct call to HAL_IncTick() to increment
  * a global variable "uwTick" used as application time base.
  * @param  htim : TIM handle
  * @retval None
  */
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
  /* USER CODE BEGIN Callback 0 */

  /* USER CODE END Callback 0 */
  if (htim->Instance == TIM1) {
    HAL_IncTick();
  }
  /* USER CODE BEGIN Callback 1 */

  /* USER CODE END Callback 1 */
}

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
