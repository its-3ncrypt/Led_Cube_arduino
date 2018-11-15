/*
You may check out our instructables for more detail at http://www.instructables.com/id/JolliCube-an-8x8x8-LED-Cube-SPI/
*/

/* Wirings
SPI connections between Arduino Nano/UNO and the jolliCube are MOSI (Pin 11), SCK (Pin 13) and SS (Pin 10) at the Arduino side and Din, CLK and Load pins at jolliCube respectively.        
*/


#include <SPI.h>          
       
int SPI_CS = 10;// This SPI Chip Select pin controls the MAX7219
int maxInUse = 8; // No. of MAX72xx ICs



//**********************************************************************************************************************************************************  
void setup() 
{
  pinMode(SPI_CS, OUTPUT);

  SPI.begin(); //setup SPI Interface

  // Initialize MAX7219 IC
  maxTransferAll(0x0F, 0x00);   // 00 - Turn off Test mode
  maxTransferAll(0x09, 0x00);   // Register 09 - BCD Decoding  // 0 = No decoding
  maxTransferAll(0x0B, 0x07);   // Register B - Scan limit 1-7  // 7 = All LEDS
  maxTransferAll(0x0C, 0x01);   // 01 = on 00 = Power saving mode or shutdown
  maxTransferAll(0x0A, 0x06);   // brightness value 0x01 to 0x0F

  //clear matrix
  for (int y=1; y<maxInUse+1; y++) {
    maxTransferAll(y, 0x00); 
  }

  Serial.begin (115200);
  Serial.println("jolliFactory 8x8x8 jolliCube Test example 1.0");              
}



//**********************************************************************************************************************************************************  
void loop() 
{
  //test matrix row by row
  for (int y=1; y<maxInUse+1; y++) {
    maxTransferAll(y, 0xff); 
    delay(500);
  }

  //clear matrix
  for (int y=1; y<maxInUse+1; y++) {
    maxTransferAll(y, 0x00); 
  }

    delay(500);
}



//**********************************************************************************************************************************************************  
void maxTransferAll(uint8_t address, uint8_t value)
{
  digitalWrite(SPI_CS, LOW); 

    for ( int c=1; c<= maxInUse;c++) {
        SPI.transfer(address);  // specify register
        SPI.transfer(value);    // put data
    }

  digitalWrite(SPI_CS, HIGH); 
}
