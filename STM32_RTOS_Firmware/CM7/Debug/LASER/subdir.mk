################################################################################
# Automatically-generated file. Do not edit!
# Toolchain: GNU Tools for STM32 (12.3.rel1)
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
D:/DATN/Tu\ Tai\ Lieu/Library/Libraries\ for\ Sensors/LASER/TOF.c 

OBJS += \
./LASER/TOF.o 

C_DEPS += \
./LASER/TOF.d 


# Each subdirectory must supply rules for building sources it contributes
LASER/TOF.o: D:/DATN/Tu\ Tai\ Lieu/Library/Libraries\ for\ Sensors/LASER/TOF.c LASER/subdir.mk
	arm-none-eabi-gcc "$<" -mcpu=cortex-m7 -std=gnu11 -g3 -DDEBUG -DCORE_CM7 -DUSE_HAL_DRIVER -DSTM32H745xx -c -I../Core/Inc -I../../Drivers/STM32H7xx_HAL_Driver/Inc -I../../Drivers/STM32H7xx_HAL_Driver/Inc/Legacy -I../../Drivers/CMSIS/Device/ST/STM32H7xx/Include -I../../Drivers/CMSIS/Include -I../../Middlewares/Third_Party/FreeRTOS/Source/include -I../../Middlewares/Third_Party/FreeRTOS/Source/CMSIS_RTOS -I../../Middlewares/Third_Party/FreeRTOS/Source/portable/GCC/ARM_CM4F -I"D:/DATN/Tu Tai Lieu/Library/IR/imu" -I"D:/DATN/Tu Tai Lieu/Library/IR/d6t" -I"D:/DATN/Tu Tai Lieu/Library/Libraries for Sensors/LASER" -O0 -ffunction-sections -fdata-sections -Wall -fstack-usage -fcyclomatic-complexity -MMD -MP -MF"$(@:%.o=%.d)" -MT"$@" --specs=nano.specs -mfpu=fpv5-d16 -mfloat-abi=hard -mthumb -o "$@"

clean: clean-LASER

clean-LASER:
	-$(RM) ./LASER/TOF.cyclo ./LASER/TOF.d ./LASER/TOF.o ./LASER/TOF.su

.PHONY: clean-LASER

