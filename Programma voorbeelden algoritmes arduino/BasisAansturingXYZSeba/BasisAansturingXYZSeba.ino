#include <SPI.h> 
#define SS 10            
int SPI_CS = 10;// This SPI Chip Select pin controls the MAX7219
int maxInUse = 8; // No. of MAX72xx ICs
byte hoeveel[8];
String Thecode = "01000101";

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
  maxTransferAll(0x0A, 0x0F);   // brightness value 0x01 to 0x0F

  //clear matrix
  for (int y=1; y<maxInUse+1; y++) {
    maxTransferAll(y, 0x00); 
  }

  Serial.begin (74880);       
}



//**********************************************************************************************************************************************************  
void loop() 
{
  
    hoeveel[0] = Code_To_Hexadecimal(Thecode);
    hoeveel[1] = Code_To_Hexadecimal(Thecode);
    hoeveel[2] = Code_To_Hexadecimal(Thecode);
    hoeveel[3] = Code_To_Hexadecimal(Thecode);
    hoeveel[4] = Code_To_Hexadecimal(Thecode);
    hoeveel[5] = Code_To_Hexadecimal(Thecode);
    hoeveel[6] = Code_To_Hexadecimal(Thecode);
    hoeveel[7] = Code_To_Hexadecimal(Thecode);
	for (int i = 0; i <= 7; i++) 
	{
		maxTransferBall(i);
	}
    
    
  delay(500);
  
  for (int y=1; y<maxInUse+1; y++) {
    maxTransferAll(y, 0x00); 
  }
  delay(500);
}

///*******************************************************************************************************************************
//Code Conversie 0xCodes
uint8_t Code_To_Hexadecimal(String Code)
{
  //eerste rij
  if(Code == "00000000")
  {
    return 0x00;
  }
  else if(Code == "10000000")
  {
    return 0x01;
  }
  else if(Code == "01000000")
  {
    return 0x02;
  }
  else if(Code == "11000000")
  {
    return 0x03;
  }
  else if(Code == "00100000")
  {
    return 0x04;
  }
  else if(Code == "10100000")
  {
    return 0x05;
  }
  else if(Code == "01100000")
  {
    return 0x06;
  }
  else if(Code == "11100000")
  {
    return 0x07;
  }
  else if(Code == "00010000")
  {
    return 0x08;
  }
  else if(Code == "10010000")
  {
    return 0x09;
  }
  else if(Code == "01010000")
  {
    return 0x0A;
  }
  else if(Code == "11010000")
  {
    return 0x0B;
  }
  else if(Code == "00110000")
  {
    return 0x0C;
  }
  else if(Code == "10110000")
  {
    return 0x0D;
  }
  else if(Code == "01110000")
  {
    return 0x0E;
  }
  else if(Code == "11110000")
  {
    return 0x0F;
  }

  //2e rij
  //------------------------------------------------------------
  else if(Code == "00001000")
  {
    return 0x10;
  }
  else if(Code == "10001000")
  {
    return 0x11;
  }
  else if(Code == "01001000")
  {
    return 0x12;
  }
  else if(Code == "11001000")
  {
    return 0x13;
  }
  else if(Code == "00101000")
  {
    return 0x14;
  }
  else if(Code == "10101000")
  {
    return 0x15;
  }
  else if(Code == "01101000")
  {
    return 0x16;
  }
  else if(Code == "11101000")
  {
    return 0x17;
  }
  else if(Code == "00011000")
  {
    return 0x18;
  }
  else if(Code == "10011000")
  {
    return 0x19;
  }
  else if(Code == "01011000")
  {
    return 0x1A;
  }
  else if(Code == "11011000")
  {
    return 0x1B;
  }
  else if(Code == "00111000")
  {
    return 0x1C;
  }
  else if(Code == "10111000")
  {
    return 0x1D;
  }
  else if(Code == "01111000")
  {
    return 0x1E;
  }
  else if(Code == "11111000")
  {
    return 0x1F;
  }
  //derde rij
//------------------------------------------------------------
  else if(Code == "00000100")
  {
    return 0x20;
  }
  else if(Code == "10000100")
  {
    return 0x21;
  }
  else if(Code == "01000100")
  {
    return 0x22;
  }
  else if(Code == "11000100")
  {
    return 0x23;
  }
  else if(Code == "00100100")
  {
    return 0x24;
  }
  else if(Code == "10100100")
  {
    return 0x25;
  }
  else if(Code == "01100100")
  {
    return 0x26;
  }
  else if(Code == "11100100")
  {
    return 0x27;
  }
  else if(Code == "00010100")
  {
    return 0x28;
  }
  else if(Code == "10010100")
  {
    return 0x29;
  }
  else if(Code == "01010100")
  {
    return 0x2A;
  }
  else if(Code == "11010100")
  {
    return 0x2B;
  }
  else if(Code == "00110100")
  {
    return 0x2C;
  }
  else if(Code == "10110100")
  {
    return 0x2D;
  }
  else if(Code == "01110100")
  {
    return 0x2E;
  }
  else if(Code == "11110100")
  {
    return 0x2F;
  }

  //4e rij
  //------------------------------------------------------------
  else if(Code == "00001100")
  {
    return 0x30;
  }
  else if(Code == "10001100")
  {
    return 0x31;
  }
  else if(Code == "01001100")
  {
    return 0x32;
  }
  else if(Code == "11001100")
  {
    return 0x33;
  }
  else if(Code == "00101100")
  {
    return 0x34;
  }
  else if(Code == "10101100")
  {
    return 0x35;
  }
  else if(Code == "01101100")
  {
    return 0x36;
  }
  else if(Code == "11101100")
  {
    return 0x37;
  }
  else if(Code == "00011100")
  {
    return 0x38;
  }
  else if(Code == "10011100")
  {
    return 0x39;
  }
  else if(Code == "01011100")
  {
    return 0x3A;
  }
  else if(Code == "11011100")
  {
    return 0x3B;
  }
  else if(Code == "00111100")
  {
    return 0x3C;
  }
  else if(Code == "10111100")
  {
    return 0x3D;
  }
  else if(Code == "01111100")
  {
    return 0x3E;
  }
  else if(Code == "11111100")
  {
    return 0x3F;
  }

  //5e rij
  //------------------------------------------------------------
  else if(Code == "00000010")
  {
    return 0x40;
  }
  else if(Code == "10000010")
  {
    return 0x41;
  }
  else if(Code == "01000010")
  {
    return 0x42;
  }
  else if(Code == "11000010")
  {
    return 0x43;
  }
  else if(Code == "00100010")
  {
    return 0x44;
  }
  else if(Code == "10100010")
  {
    return 0x45;
  }
  else if(Code == "01100010")
  {
    return 0x46;
  }
  else if(Code == "11100010")
  {
    return 0x47;
  }
  else if(Code == "00010010")
  {
    return 0x48;
  }
  else if(Code == "10010010")
  {
    return 0x49;
  }
  else if(Code == "01010010")
  {
    return 0x4A;
  }
  else if(Code == "11010010")
  {
    return 0x4B;
  }
  else if(Code == "00110010")
  {
    return 0x4C;
  }
  else if(Code == "10110010")
  {
    return 0x4D;
  }
  else if(Code == "01110010")
  {
    return 0x4E;
  }
  else if(Code == "11110010")
  {
    return 0x4F;
  }
  
  //6e rij
  //------------------------------------------------------------
  else if(Code == "00001010")
  {
    return 0x50;
  }
  else if(Code == "10001010")
  {
    return 0x51;
  }
  else if(Code == "01001010")
  {
    return 0x52;
  }
  else if(Code == "11001010")
  {
    return 0x53;
  }
  else if(Code == "00101010")
  {
    return 0x54;
  }
  else if(Code == "10101010")
  {
    return 0x55;
  }
  else if(Code == "01101010")
  {
    return 0x56;
  }
  else if(Code == "11101010")
  {
    return 0x57;
  }
  else if(Code == "00011010")
  {
    return 0x58;
  }
  else if(Code == "10011010")
  {
    return 0x59;
  }
  else if(Code == "01011010")
  {
    return 0x5A;
  }
  else if(Code == "11011010")
  {
    return 0x5B;
  }
  else if(Code == "00111010")
  {
    return 0x5C;
  }
  else if(Code == "10111010")
  {
    return 0x5D;
  }
  else if(Code == "01111010")
  {
    return 0x5E;
  }
  else if(Code == "11111010")
  {
    return 0x5F;
  }

  //7e rij
//------------------------------------------------------------
  else if(Code == "00000110")
  {
    return 0x60;
  }
  else if(Code == "10000110")
  {
    return  0x61;
  }
  else if(Code == "01000110")
  {
    return 0x62;
  }
  else if(Code == "11000110")
  {
    return 0x63;
  }
  else if(Code == "00100110")
  {
    return 0x64;
  }
  else if(Code == "10100110")
  {
    return 0x65;
  }
  else if(Code == "01100110")
  {
    return 0x66;
  }
  else if(Code == "11100110")
  {
    return 0x67;
  }
  else if(Code == "00010110")
  {
    return 0x68;
  }
  else if(Code == "10010110")
  {
    return 0x69;
  }
  else if(Code == "01010110")
  {
    return 0x6A;
  }
  else if(Code == "11010110")
  {
    return 0x6B;
  }
  else if(Code == "00110110")
  {
    return 0x6C;
  }
  else if(Code == "10110110")
  {
    return 0x6D;
  }
  else if(Code == "01110110")
  {
    return 0x6E;
  }
  else if(Code == "11110110")
  {
    return 0x6F;
  }
   //8e rij
//------------------------------------------------------------
  else if(Code == "00001110")
  {
    return 0x70;
  }
  else if(Code == "10001110")
  {
    return 0x71;
  }
  else if(Code == "01001110")
  {
    return 0x72;
  }
  else if(Code == "11001110")
  {
    return 0x73;
  }
  else if(Code == "00101110")
  {
    return 0x74;
  }
  else if(Code == "10101110")
  {
    return 0x75;
  }
  else if(Code == "01101110")
  {
    return 0x76;
  }
  else if(Code == "11101110")
  {
    return 0x77;
  }
  else if(Code == "00011110")
  {
    return 0x78;
  }
  else if(Code == "10011110")
  {
    return 0x79;
  }
  else if(Code == "01011110")
  {
    return 0x7A;
  }
  else if(Code == "11011110")
  {
    return 0x7B;
  }
  else if(Code == "00111110")
  {
    return 0x7C;
  }
  else if(Code == "10111110")
  {
    return 0x7D;
  }
  else if(Code == "01111110")
  {
    return 0x7E;
  }
  else if(Code == "11111110")
  {
    return 0x7F;
  }
  //------------------------------------------------------------  
  //9e rij
  else if(Code == "00000001")
  {
    return 0x80;
  }
  else if(Code == "10000001")
  {
    return 0x81;
  }
  else if(Code == "01000001")
  {
    return 0x82;
  }
  else if(Code == "11000001")
  {
    return 0x83;
  }
  else if(Code == "00100001")
  {
    return 0x84;
  }
  else if(Code == "10100001")
  {
    return 0x85;
  }
  else if(Code == "01100001")
  {
    return 0x86;
  }
  else if(Code == "11100001")
  {
    return 0x87;
  }
  else if(Code == "00010001")
  {
    return 0x88;
  }
  else if(Code == "10010001")
  {
    return 0x89;
  }
  else if(Code == "01010001")
  {
    return 0x8A;
  }
  else if(Code == "11010001")
  {
    return 0x8B;
  }
  else if(Code == "00110001")
  {
    return 0x8C;
  }
  else if(Code == "10110001")
  {
    return 0x8D;
  }
  else if(Code == "01110001")
  {
    return 0x8E;
  }
  else if(Code == "11110001")
  {
    return 0x8F;
  }

  //------------------------------------------------------------  
  //10e rij
  else if(Code == "00001001")
  {
    return 0x90;
  }
  else if(Code == "10001001")
  {
    return 0x91;
  }
  else if(Code == "01001001")
  {
    return 0x92;
  }
  else if(Code == "11001001")
  {
    return 0x93;
  }
  else if(Code == "00101001")
  {
    return 0x94;
  }
  else if(Code == "10101001")
  {
    return 0x95;
  }
  else if(Code == "01101001")
  {
    return 0x96;
  }
  else if(Code == "11101001")
  {
    return 0x97;
  }
  else if(Code == "00011001")
  {
    return 0x98;
  }
  else if(Code == "10011001")
  {
    return 0x99;
  }
  else if(Code == "01011001")
  {
    return 0x9A;
  }
  else if(Code == "11011001")
  {
    return 0x9B;
  }
  else if(Code == "00111001")
  {
    return 0x9C;
  }
  else if(Code == "10111001")
  {
    return 0x9D;
  }
  else if(Code == "01111001")
  {
    return 0x9E;
  }
  else if(Code == "11111001")
  {
    return 0x9F;
  }
  //------------------------------------------------------------  
  //11e rij
  else if(Code == "00000101")
  {
    return 0xA0;
  }
  else if(Code == "10000101")
  {
    return 0xA1;
  }
  else if(Code == "01000101")
  {
    return 0xA2;
  }
  else if(Code == "11000101")
  {
    return 0xA3;
  }
  else if(Code == "00100101")
  {
    return 0xA4;
  }
  else if(Code == "10100101")
  {
    return 0xA5;
  }
  else if(Code == "01100101")
  {
    return 0xA6;
  }
  else if(Code == "11100101")
  {
    return 0xA7;
  }
  else if(Code == "00010101")
  {
    return 0xA8;
  }
  else if(Code == "10010101")
  {
    return 0xA9;
  }
  else if(Code == "01010101")
  {
    return 0xAA;
  }
  else if(Code == "11010101")
  {
    return 0xAB;
  }
  else if(Code == "00110101")
  {
    return 0xAC;
  }
  else if(Code == "10110101")
  {
    return 0xAD;
  }
  else if(Code == "01110101")
  {
    return 0xAE;
  }
  else if(Code == "11110101")
  {
    return 0xAF;
  }
  //------------------------------------------------------------  
  //12e rij
  else if(Code == "00001101")
  {
    return 0xB0;
  }
  else if(Code == "10001101")
  {
    return 0xB1;
  }
  else if(Code == "01001101")
  {
    return 0xB2;
  }
  else if(Code == "11001101")
  {
    return 0xB3;
  }
  else if(Code == "00101101")
  {
    return 0xB4;
  }
  else if(Code == "10101101")
  {
    return 0xB5;
  }
  else if(Code == "01101101")
  {
    return 0xB6;
  }
  else if(Code == "11101101")
  {
    return 0xB7;
  }
  else if(Code == "00011101")
  {
    return 0xB8;
  }
  else if(Code == "10011101")
  {
    return 0xB9;
  }
  else if(Code == "01011101")
  {
    return 0xBA;
  }
  else if(Code == "11011101")
  {
    return 0xBB;
  }
  else if(Code == "00111101")
  {
    return 0xBC;
  }
  else if(Code == "10111101")
  {
    return 0xBD;
  }
  else if(Code == "01111101")
  {
    return 0xBE;
  }
  else if(Code == "11111101")
  {
    return 0xBF;
  }
  //------------------------------------------------------------  
  //13e rij
  else if(Code == "00000011")
  {
    return 0xC0;
  }
  else if(Code == "10000011")
  {
    return 0xC1;
  }
  else if(Code == "01000011")
  {
    return 0xC2;
  }
  else if(Code == "11000011")
  {
    return 0xC3;
  }
  else if(Code == "00100011")
  {
    return 0xC4;
  }
  else if(Code == "10100011")
  {
    return 0xC5;
  }
  else if(Code == "01100011")
  {
    return 0xC6;
  }
  else if(Code == "11100011")
  {
    return 0xC7;
  }
  else if(Code == "00010011")
  {
    return 0xC8;
  }
  else if(Code == "10010011")
  {
    return 0xC9;
  }
  else if(Code == "01010011")
  {
    return 0xCA;
  }
  else if(Code == "11010011")
  {
    return 0xCB;
  }
  else if(Code == "00110011")
  {
    return 0xCC;
  }
  else if(Code == "10110011")
  {
    return 0xCD;
  }
  else if(Code == "01110011")
  {
    return 0xCE;
  }
  else if(Code == "11110011")
  {
    return 0xCF;
  }

  //------------------------------------------------------------  
  //14e rij
  else if(Code == "00001011")
  {
    return 0xD0;
  }
  else if(Code == "10001011")
  {
    return 0xD1;
  }
  else if(Code == "01001011")
  {
    return 0xD2;
  }
  else if(Code == "11001011")
  {
    return 0xD3;
  }
  else if(Code == "00101011")
  {
    return 0xD4;
  }
  else if(Code == "10101011")
  {
    return 0xD5;
  }
  else if(Code == "01101011")
  {
    return 0xD6;
  }
  else if(Code == "11101011")
  {
    return 0xD7;
  }
  else if(Code == "00011011")
  {
    return 0xD8;
  }
  else if(Code == "10011011")
  {
    return 0xD9;
  }
  else if(Code == "01011011")
  {
    return 0xDA;
  }
  else if(Code == "11011011")
  {
    return 0xDB;
  }
  else if(Code == "00111011")
  {
    return 0xDC;
  }
  else if(Code == "10111011")
  {
    return 0xDD;
  }
  else if(Code == "01111011")
  {
    return 0xDE;
  }
  else if(Code == "11111011")
  {
    return 0xDF;
  }
  //15e rij
  else if (Code == "00000111")
  {
  return 0xE0;
  }
  else if (Code == "10000111")
  {
  return 0xE1;
  }
  else if (Code == "01000111")
  {
  return 0xE2;
  }
  else if (Code == "11000111")
  {
  return 0xE3;
  }
  else if (Code == "00100111")
  {
  return 0xE4;
  }
  else if (Code == "10100111")
  {
  return 0xE5;
  }
  else if (Code == "01100111")
  {
  return 0xE6;
  }
  else if (Code == "11100111")
  {
  return 0xE7;
  }
  else if (Code == "00010111")
  {
  return 0xE8;
  }
  else if (Code == "10010111")
  {
  return 0xE9;
  }
  else if (Code == "01010111")
  {
  return 0xEA;
  }
  else if (Code == "11010111")
  {
  return 0xEB;
  }
  else if (Code == "00110111")
  {
  return 0xEC;
  }
  else if (Code == "10110111")
  {
  return 0xED;
  }
  else if (Code == "01110111")
  {
  return 0xEE;
  }
  else if (Code == "11110111")
  {
  return 0xEF;
  }
  //16e rij
  else if (Code == "00001111")
  {
  return 0xF0;
  }
  else if (Code == "10001111")
  {
  return 0xF1;
  }
  else if (Code == "01001111")
  {
  return 0xF2;
  }
  else if (Code == "11001111")
  {
  return 0xF3;
  }
  else if (Code == "00101111")
  {
  return 0xF4;
  }
  else if (Code == "10101111")
  {
  return 0xF5;
  }
  else if (Code == "01101111")
  {
  return 0xF6;
  }
  else if (Code == "11101111")
  {
  return 0xF7;
  }
  else if (Code == "00011111")
  {
  return 0xF8;
  }
  else if (Code == "10011111")
  {
  return 0xF9;
  }
  else if (Code == "01011111")
  {
  return 0xFA;
  }
  else if (Code == "11011111")
  {
  return 0xFB;
  }
  else if (Code == "00111111")
  {
  return 0xFC;
  }
  else if (Code == "10111111")
  {
  return 0xFD;
  }
  else if (Code == "01111111")
  {
  return 0xFE;
  }
  else if (Code == "11111111")
  {
  return 0xFF;
  }
}
///*******************************************************************************************************************************

void maxTransferBall(uint8_t address)
{
  digitalWrite(SPI_CS, LOW); 

    for ( int c=0; c<=7;c++) 
    {
        SPI.transfer(address);  // specify register
        SPI.transfer(hoeveel[c]);    // put data
    }

  digitalWrite(SPI_CS, HIGH); 
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
