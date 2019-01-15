#include <SPI.h>
#include <avr/interrupt.h>
#include <string.h>
#include <math.h>

#define AXIS_X 1
#define AXIS_Y 2
#define AXIS_Z 3
#define REFRESH_RATE 120
#define SS 10

int CUBE_SIZE = 8;
int SPI_CS = 10;// This SPI Chip Select pin controls the MAX72xx
byte value[8];

volatile unsigned char cube[8][8];
volatile int current_layer = 0;

/* Variabelen voor communicatie*/
char BinnenkomendeConnectie = '1';
int Connectie1 = 0;


//***********************************************************************************************************************
void setup()
{
  Serial.begin (115200);            

  pinMode(SPI_CS, OUTPUT);

  SPI.begin();

  maxTransferAll(0x0F, 0x00);   // 00 - Turn off Test mode
  maxTransferAll(0x09, 0x00);   // Register 09 - BCD Decoding  // 0 = No decoding
  maxTransferAll(0x0B, 0x07);   // Register B - Scan limit 1-7  // 7 = All LEDS
  maxTransferAll(0x0C, 0x01);   // 01 = on 00 = Power saving mode or shutdown
  maxTransferAll(0x0A, 0x0F);   // Set Brightness Intensity

}

void loop() {
  // put your main code here, to run repeatedly:

  fireworks(100, 15 , 500);
  delay(100);

}


// ======================================================================================================================
//   Effect functions
// ======================================================================================================================

//***********************************************************************************************************************
void fireworks (int iterations, int n, int delay)
{
  fill(0x00);

  int i,f,e;

  float origin_x = 3;
  float origin_y = 3;
  float origin_z = 3;

  int rand_y, rand_x, rand_z;

  float slowrate, gravity;

  // Particles and their position, x,y,z and their movement, dx, dy, dz
  float particles[n][6];

  for (i=0; i<iterations; i++)
  {

    origin_x = rand()%4;
    origin_y = rand()%4;
    origin_z = rand()%2;
    origin_z +=5;
        origin_x +=2;
        origin_y +=2;

    // shoot a particle up in the air
    for (e=0;e<origin_z;e++)
    {
      setvoxel(origin_x,origin_y,e);
      delay_ms(600+500*e);
      fill(0x00);
    }

    // Fill particle array
    for (f=0; f<n; f++)
    {
      // Position
      particles[f][0] = origin_x;
      particles[f][1] = origin_y;
      particles[f][2] = origin_z;
      
      rand_x = rand()%200;
      rand_y = rand()%200;
      rand_z = rand()%200;

      // Movement
      particles[f][3] = 1-(float)rand_x/100; // dx
      particles[f][4] = 1-(float)rand_y/100; // dy
      particles[f][5] = 1-(float)rand_z/100; // dz
    }

    // explode
    for (e=0; e<25; e++)
    {
      slowrate = 1+tan((e+0.1)/20)*10;
      
      gravity = tan((e+0.1)/20)/2;

      for (f=0; f<n; f++)
      {
        particles[f][0] += particles[f][3]/slowrate;
        particles[f][1] += particles[f][4]/slowrate;
        particles[f][2] += particles[f][5]/slowrate;
        particles[f][2] -= gravity;

        setvoxel(particles[f][0],particles[f][1],particles[f][2]);


      }

      delay_ms(delay);
      fill(0x00);
    }

  }

}

// ======================================================================================================================
//   Draw functions
// ======================================================================================================================

//***********************************************************************************************************************
// Set a single voxel to ON
void setvoxel(int x, int y, int z)
{
  if (inrange(x,y,z))
    cube[z][y] |= (1 << x);
}



//***********************************************************************************************************************
// Set a single voxel to ON
void clrvoxel(int x, int y, int z)
{
  if (inrange(x,y,z))
    cube[z][y] &= ~(1 << x);
}



//***********************************************************************************************************************
// This function validates that we are drawing inside the cube.
unsigned char inrange(int x, int y, int z)
{
  if (x >= 0 && x < 8 && y >= 0 && y < 8 && z >= 0 && z < 8)
  {
    return 0x01;
  } else
  {
    // One of the coordinates was outside the cube.
    return 0x00;
  }
}



//***********************************************************************************************************************
// Get the current status of a voxel
unsigned char getvoxel(int x, int y, int z)
{
  if (inrange(x,y,z))
  {
    if (cube[z][y] & (1 << x))
    {
      return 0x01;
    } else
    {
      return 0x00;
    }
  } else
  {
    return 0x00;
  }
}



//***********************************************************************************************************************
// In some effect we want to just take bool and write it to a voxel
// this function calls the apropriate voxel manipulation function.
void altervoxel(int x, int y, int z, int state)
{
  if (state == 1)
  {
    setvoxel(x,y,z);
  } else
  {
    clrvoxel(x,y,z);
  }
}



//***********************************************************************************************************************
// Flip the state of a voxel.
// If the voxel is 1, its turned into a 0, and vice versa.
void flpvoxel(int x, int y, int z)
{
  if (inrange(x, y, z))
    cube[z][y] ^= (1 << x);
}



//***********************************************************************************************************************
// Makes sure x1 is alwas smaller than x2
// This is usefull for functions that uses for loops,
// to avoid infinite loops
void argorder(int ix1, int ix2, int *ox1, int *ox2)
{
  if (ix1>ix2)
  {
    int tmp;
    tmp = ix1;
    ix1= ix2;
    ix2 = tmp;
  }
  *ox1 = ix1;
  *ox2 = ix2;
}



//***********************************************************************************************************************
// Sets all voxels along a X/Y plane at a given point
// on axis Z
void setplane_z (int z)
{
  int i;
  if (z>=0 && z<8)
  {
    for (i=0;i<8;i++)
      cube[z][i] = 0xff;
  }
}



//***********************************************************************************************************************
// Clears voxels in the same manner as above
void clrplane_z (int z)
{
  int i;
  if (z>=0 && z<8)
  {
    for (i=0;i<8;i++)
      cube[z][i] = 0x00;
  }
}



//***********************************************************************************************************************
void setplane_x (int x)
{
  int z;
  int y;
  if (x>=0 && x<8)
  {
    for (z=0;z<8;z++)
    {
      for (y=0;y<8;y++)
      {
        cube[z][y] |= (1 << x);
      }
    }
  }
}



//***********************************************************************************************************************
void clrplane_x (int x)
{
  int z;
  int y;
  if (x>=0 && x<8)
  {
    for (z=0;z<8;z++)
    {
      for (y=0;y<8;y++)
      {
        cube[z][y] &= ~(1 << x);
      }
    }
  }
}



//***********************************************************************************************************************
void setplane_y (int y)
{
  int z;
  if (y>=0 && y<8)
  {
    for (z=0;z<8;z++)
      cube[z][y] = 0xff;
  } 
}



//***********************************************************************************************************************
void clrplane_y (int y)
{
  int z;
  if (y>=0 && y<8)
  {
    for (z=0;z<8;z++)
      cube[z][y] = 0x00; 
  }
}



//***********************************************************************************************************************
void setplane (char axis, unsigned char i)
{
    switch (axis)
    {
        case AXIS_X:
            setplane_x(i);
            break;
        
       case AXIS_Y:
            setplane_y(i);
            break;

       case AXIS_Z:
            setplane_z(i);
            break;
    }
}



//***********************************************************************************************************************
void clrplane (char axis, unsigned char i)
{
    switch (axis)
    {
        case AXIS_X:
            clrplane_x(i);
            break;
        
       case AXIS_Y:
            clrplane_y(i);
            break;

       case AXIS_Z:
            clrplane_z(i);
            break;
    }
}



//***********************************************************************************************************************
// Fill a value into all 64 byts of the cube buffer
// Mostly used for clearing. fill(0x00)
// or setting all on. fill(0xff)
void fill (unsigned char pattern)
{
  int z;
  int y;
  for (z=0;z<8;z++)
  {
    for (y=0;y<8;y++)
    {
      cube[z][y] = pattern;
    }
  }
}



//***********************************************************************************************************************
// Draw a box with all walls drawn and all voxels inside set
void box_filled(int x1, int y1, int z1, int x2, int y2, int z2)
{
  int iy;
  int iz;

  argorder(x1, x2, &x1, &x2);
  argorder(y1, y2, &y1, &y2);
  argorder(z1, z2, &z1, &z2);

  for (iz=z1;iz<=z2;iz++)
  {
    for (iy=y1;iy<=y2;iy++)
    {
      cube[iz][iy] |= byteline(x1,x2);
    }
  }

}



//***********************************************************************************************************************
// Darw a hollow box with side walls.
void box_walls(int x1, int y1, int z1, int x2, int y2, int z2)
{
  int iy;
  int iz;
  
  argorder(x1, x2, &x1, &x2);
  argorder(y1, y2, &y1, &y2);
  argorder(z1, z2, &z1, &z2);

  for (iz=z1;iz<=z2;iz++)
  {
    for (iy=y1;iy<=y2;iy++)
    { 
      if (iy == y1 || iy == y2 || iz == z1 || iz == z2)
      {
        cube[iz][iy] = byteline(x1,x2);
      } else
      {
        cube[iz][iy] |= ((0x01 << x1) | (0x01 << x2));
      }
    }
  }

}



//***********************************************************************************************************************
// Draw a wireframe box. This only draws the corners and edges,
// no walls.
void box_wireframe(int x1, int y1, int z1, int x2, int y2, int z2)
{
  int iy;
  int iz;

  argorder(x1, x2, &x1, &x2);
  argorder(y1, y2, &y1, &y2);
  argorder(z1, z2, &z1, &z2);

  // Lines along X axis
  cube[z1][y1] = byteline(x1,x2);
  cube[z1][y2] = byteline(x1,x2);
  cube[z2][y1] = byteline(x1,x2);
  cube[z2][y2] = byteline(x1,x2);

  // Lines along Y axis
  for (iy=y1;iy<=y2;iy++)
  {
    setvoxel(x1,iy,z1);
    setvoxel(x1,iy,z2);
    setvoxel(x2,iy,z1);
    setvoxel(x2,iy,z2);
  }

  // Lines along Z axis
  for (iz=z1;iz<=z2;iz++)
  {
    setvoxel(x1,y1,iz);
    setvoxel(x1,y2,iz);
    setvoxel(x2,y1,iz);
    setvoxel(x2,y2,iz);
  }

}



//***********************************************************************************************************************
// Returns a byte with a row of 1's drawn in it.
// byteline(2,5) gives 0b00111100
char byteline (int start, int end)
{
  return ((0xff<<start) & ~(0xff<<(end+1)));
}



//***********************************************************************************************************************
// Flips a byte 180 degrees.
// MSB becomes LSB, LSB becomes MSB.
char flipbyte (char byte)
{
  char flop = 0x00;

  flop = (flop & 0b11111110) | (0b00000001 & (byte >> 7));
  flop = (flop & 0b11111101) | (0b00000010 & (byte >> 5));
  flop = (flop & 0b11111011) | (0b00000100 & (byte >> 3));
  flop = (flop & 0b11110111) | (0b00001000 & (byte >> 1));
  flop = (flop & 0b11101111) | (0b00010000 & (byte << 1));
  flop = (flop & 0b11011111) | (0b00100000 & (byte << 3));
  flop = (flop & 0b10111111) | (0b01000000 & (byte << 5));
  flop = (flop & 0b01111111) | (0b10000000 & (byte << 7));
  return flop;
}



//***********************************************************************************************************************
// Draw a line between any coordinates in 3d space.
// Uses integer values for input, so dont expect smooth animations.
void line(int x1, int y1, int z1, int x2, int y2, int z2)
{
  float xy; // how many voxels do we move on the y axis for each step on the x axis
  float xz; // how many voxels do we move on the y axis for each step on the x axis 
  unsigned char x,y,z;
  unsigned char lasty,lastz;

  // We always want to draw the line from x=0 to x=7.
  // If x1 is bigget than x2, we need to flip all the values.
  if (x1>x2)
  {
    int tmp;
    tmp = x2; x2 = x1; x1 = tmp;
    tmp = y2; y2 = y1; y1 = tmp;
    tmp = z2; z2 = z1; z1 = tmp;
  }

  
  if (y1>y2)
  {
    xy = (float)(y1-y2)/(float)(x2-x1);
    lasty = y2;
  } else
  {
    xy = (float)(y2-y1)/(float)(x2-x1);
    lasty = y1;
  }

  if (z1>z2)
  {
    xz = (float)(z1-z2)/(float)(x2-x1);
    lastz = z2;
  } else
  {
    xz = (float)(z2-z1)/(float)(x2-x1);
    lastz = z1;
  }



  // For each step of x, y increments by:
  for (x = x1; x<=x2;x++)
  {
    y = (xy*(x-x1))+y1;
    z = (xz*(x-x1))+z1;
    setvoxel(x,y,z);
  }
  
}



//***********************************************************************************************************************
// Delay loop.
// This is not calibrated to milliseconds,
// but we had allready made to many effects using this
// calibration when we figured it might be a good idea
// to calibrate it.
void delay_ms(uint16_t x)
{
  uint8_t y, z;
  for ( ; x > 0 ; x--){
    for ( y = 0 ; y < 90 ; y++){
      for ( z = 0 ; z < 6 ; z++){
        asm volatile ("nop");
      }
    }
  }
}



//***********************************************************************************************************************
// Shift the entire contents of the cube along an axis
// This is great for effects where you want to draw something
// on one side of the cube and have it flow towards the other
// side. Like rain flowing down the Z axiz.
void shift (char axis, int direction)
{
  int i, x ,y;
  int ii, iii;
  int state;

  for (i = 0; i < 8; i++)
  {
    if (direction == -1)
    {
      ii = i;
    } else
    {
      ii = (7-i);
    } 
  
  
    for (x = 0; x < 8; x++)
    {
      for (y = 0; y < 8; y++)
      {
        if (direction == -1)
        {
          iii = ii+1;
        } else
        {
          iii = ii-1;
        }
        
        if (axis == AXIS_Z)
        {
          state = getvoxel(x,y,iii);
          altervoxel(x,y,ii,state);
        }
        
        if (axis == AXIS_Y)
        {
          state = getvoxel(x,iii,y);
          altervoxel(x,ii,y,state);
        }
        
        if (axis == AXIS_X)
        {
          state = getvoxel(iii,y,x);
          altervoxel(ii,y,x,state);
        }
      }
    }
  }
  
  if (direction == -1)
  {
    i = 7;
  } else
  {
    i = 0;
  } 
  
  for (x = 0; x < 8; x++)
  {
    for (y = 0; y < 8; y++)
    {
      if (axis == AXIS_Z)
        clrvoxel(x,y,i);
        
      if (axis == AXIS_Y)
        clrvoxel(x,i,y);
      
      if (axis == AXIS_X)
        clrvoxel(i,y,x);
    }
  }
}
//***********************************************************************************************************************
void init_LUT(unsigned char LUT[65])
{
  unsigned char i;
  float sin_of,sine;
  for (i=0;i<65;i++)
  {
    sin_of=i*PI/64; // Just need half a sin wave
    sine=sin(sin_of);
    // Use 181.0 as this squared is <32767, so we can multiply two sin or cos without overflowing an int.
    LUT[i]=sine*181.0;
  }
}



// ======================================================================================================================
// 3D addins
// ======================================================================================================================

//***********************************************************************************************************************
void linespin (int iterations, int delay)
{
  float top_x, top_y, top_z, bot_x, bot_y, bot_z, sin_base;
  float center_x, center_y;

  center_x = 4;
  center_y = 4;

  int i, z;
  for (i=0;i<iterations;i++)
  {

    //printf("Sin base %f \n",sin_base);

    for (z = 0; z < 8; z++)
    {

    sin_base = (float)i/50 + (float)z/(10+(7*sin((float)i/200)));

    top_x = center_x + sin(sin_base)*5;
    top_y = center_x + cos(sin_base)*5;
    //top_z = center_x + cos(sin_base/100)*2.5;

    bot_x = center_x + sin(sin_base+3.14)*10;
    bot_y = center_x + cos(sin_base+3.14)*10;
    //bot_z = 7-top_z;
    
    bot_z = z;
    top_z = z;

    // setvoxel((int) top_x, (int) top_y, 7);
    // setvoxel((int) bot_x, (int) bot_y, 0);

    //printf("P1: %i %i %i P2: %i %i %i \n", (int) top_x, (int) top_y, 7, (int) bot_x, (int) bot_y, 0);

    //line_3d((int) top_x, (int) top_y, (int) top_z, (int) bot_x, (int) bot_y, (int) bot_z);
    line_3d((int) top_z, (int) top_x, (int) top_y, (int) bot_z, (int) bot_x, (int) bot_y);
    }

    delay_ms(delay);
    fill(0x00);
  }

}



//***********************************************************************************************************************
void line_3d (int x1, int y1, int z1, int x2, int y2, int z2)
{
  int i, dx, dy, dz, l, m, n, x_inc, y_inc, z_inc,
  err_1, err_2, dx2, dy2, dz2;
  int pixel[3];
  pixel[0] = x1;
  pixel[1] = y1;
  pixel[2] = z1;
  dx = x2 - x1;
  dy = y2 - y1;
  dz = z2 - z1;
  x_inc = (dx < 0) ? -1 : 1;
  l = abs(dx);
  y_inc = (dy < 0) ? -1 : 1;
  m = abs(dy);
  z_inc = (dz < 0) ? -1 : 1;
  n = abs(dz);
  dx2 = l << 1;
  dy2 = m << 1;
  dz2 = n << 1;
  if ((l >= m) && (l >= n)) {
  err_1 = dy2 - l;
  err_2 = dz2 - l;
  for (i = 0; i < l; i++) {
  //PUT_PIXEL(pixel);
  setvoxel(pixel[0],pixel[1],pixel[2]);
  //printf("Setting %i %i %i \n", pixel[0],pixel[1],pixel[2]);
  if (err_1 > 0) {
  pixel[1] += y_inc;
  err_1 -= dx2;
  }
  if (err_2 > 0) {
  pixel[2] += z_inc;
  err_2 -= dx2;
  }
  err_1 += dy2;
  err_2 += dz2;
  pixel[0] += x_inc;
  }
  } else if ((m >= l) && (m >= n)) {
  err_1 = dx2 - m;
  err_2 = dz2 - m;
  for (i = 0; i < m; i++) {
  //PUT_PIXEL(pixel);
  setvoxel(pixel[0],pixel[1],pixel[2]);
  //printf("Setting %i %i %i \n", pixel[0],pixel[1],pixel[2]);
  if (err_1 > 0) {
  pixel[0] += x_inc;
  err_1 -= dy2;
  }
  if (err_2 > 0) {
  pixel[2] += z_inc;
  err_2 -= dy2;
  }
  err_1 += dx2;
  err_2 += dz2;
  pixel[1] += y_inc;
  }
  } else {
  err_1 = dy2 - n;
  err_2 = dx2 - n;
  for (i = 0; i < n; i++) {
  setvoxel(pixel[0],pixel[1],pixel[2]);
  //printf("Setting %i %i %i \n", pixel[0],pixel[1],pixel[2]);
  //PUT_PIXEL(pixel);
  if (err_1 > 0) {
  pixel[1] += y_inc;
  err_1 -= dz2;
  }
  if (err_2 > 0) {
  pixel[0] += x_inc;
  err_2 -= dz2;
  }
  err_1 += dy2;
  err_2 += dx2;
  pixel[2] += z_inc;
  }
  }
  setvoxel(pixel[0],pixel[1],pixel[2]);
  //printf("Setting %i %i %i \n", pixel[0],pixel[1],pixel[2]);
  //PUT_PIXEL(pixel);
}



//***********************************************************************************************************************
int totty_sin(unsigned char LUT[65],int sin_of)
{
  unsigned char inv=0;
  if (sin_of<0)
  {
    sin_of=-sin_of;
    inv=1;
  }
  sin_of&=0x7f; //127
  if (sin_of>64)
  {
    sin_of-=64;
    inv=1-inv;
  }
  if (inv)
    return -LUT[sin_of];
  else
    return LUT[sin_of];
}



//***********************************************************************************************************************
int totty_cos(unsigned char LUT[65],int cos_of)
{
  unsigned char inv=0;
  cos_of+=32;// Simply rotate by 90 degrees for COS
  cos_of&=0x7f;//127
  if (cos_of>64)
  {
    cos_of-=64;
    inv=1;
  }
  if (inv)
    return -LUT[cos_of];
  else
    return LUT[cos_of];
}



// **********************************************************
volatile const unsigned char font[910] [5] = {
//volatile const unsigned char font[455] EEMEM = {
  0x00,0x00,0x00,0x00,0x00,0x00,0x5f,0x5f,0x00,0x00,  //  !
  0x00,0x03,0x00,0x03,0x00,0x14,0x7f,0x14,0x7f,0x14,  // "#
  0x24,0x2a,0x7f,0x2a,0x12,0x23,0x13,0x08,0x64,0x62,  // $%
  0x36,0x49,0x55,0x22,0x50,0x00,0x05,0x03,0x00,0x00,  // &'
  0x00,0x1c,0x22,0x41,0x00,0x00,0x41,0x22,0x1c,0x00,  // ()
  0x14,0x08,0x3e,0x08,0x14,0x08,0x08,0x3e,0x08,0x08,  // *+
  0x00,0x50,0x30,0x00,0x00,0x08,0x08,0x08,0x08,0x08,  // ,-
  0x00,0x60,0x60,0x00,0x00,0x20,0x10,0x08,0x04,0x02,  // ./
  0x3e,0x51,0x49,0x45,0x3e,0x00,0x42,0x7f,0x40,0x00,  // 01
  0x42,0x61,0x51,0x49,0x46,0x21,0x41,0x45,0x4b,0x31,  // 23
  0x18,0x14,0x12,0x7f,0x10,0x27,0x45,0x45,0x45,0x39,  // 45
  0x3c,0x4a,0x49,0x49,0x30,0x01,0x71,0x09,0x05,0x03,  // 67
  0x36,0x49,0x49,0x49,0x36,0x06,0x49,0x49,0x29,0x1e,  // 89
  0x00,0x36,0x36,0x00,0x00,0x00,0x56,0x36,0x00,0x00,  // :;
  0x08,0x14,0x22,0x41,0x00,0x14,0x14,0x14,0x14,0x14,  // <=
  0x00,0x41,0x22,0x14,0x08,0x02,0x01,0x51,0x09,0x06,  // >?
  0x32,0x49,0x79,0x41,0x3e,0x7e,0x11,0x11,0x11,0x7e,  // @A
  0x7f,0x49,0x49,0x49,0x36,0x3e,0x41,0x41,0x41,0x22,  // BC
  0x7f,0x41,0x41,0x22,0x1c,0x7f,0x49,0x49,0x49,0x41,  // DE
  0x7f,0x09,0x09,0x09,0x01,0x3e,0x41,0x49,0x49,0x7a,  // FG
  0x7f,0x08,0x08,0x08,0x7f,0x00,0x41,0x7f,0x41,0x00,  // HI
  0x20,0x40,0x41,0x3f,0x01,0x7f,0x08,0x14,0x22,0x41,  // JK
  0x7f,0x40,0x40,0x40,0x40,0x7f,0x02,0x0c,0x02,0x7f,  // LM
  0x7f,0x04,0x08,0x10,0x7f,0x3e,0x41,0x41,0x41,0x3e,  // NO
  0x7f,0x09,0x09,0x09,0x06,0x3e,0x41,0x51,0x21,0x5e,  // PQ
  0x7f,0x09,0x19,0x29,0x46,0x46,0x49,0x49,0x49,0x31,  // RS
  0x01,0x01,0x7f,0x01,0x01,0x3f,0x40,0x40,0x40,0x3f,  // TU
  0x1f,0x20,0x40,0x20,0x1f,0x3f,0x40,0x38,0x40,0x3f,  // VW
  0x63,0x14,0x08,0x14,0x63,0x07,0x08,0x70,0x08,0x07,  // XY
  0x61,0x51,0x49,0x45,0x43,0x00,0x7f,0x41,0x41,0x00,  // Z[
  0x02,0x04,0x08,0x10,0x20,0x00,0x41,0x41,0x7f,0x00,  // \]
  0x04,0x02,0x01,0x02,0x04,0x40,0x40,0x40,0x40,0x40,  // ^_
  0x00,0x01,0x02,0x04,0x00,0x20,0x54,0x54,0x54,0x78,  // `a
  0x7f,0x48,0x44,0x44,0x38,0x38,0x44,0x44,0x44,0x20,  // bc
  0x38,0x44,0x44,0x48,0x7f,0x38,0x54,0x54,0x54,0x18,  // de
  0x08,0x7e,0x09,0x01,0x02,0x0c,0x52,0x52,0x52,0x3e,  // fg
  0x7f,0x08,0x04,0x04,0x78,0x00,0x44,0x7d,0x40,0x00,  // hi
  0x20,0x40,0x44,0x3d,0x00,0x7f,0x10,0x28,0x44,0x00,  // jk
  0x00,0x41,0x7f,0x40,0x00,0x7c,0x04,0x18,0x04,0x78,  // lm
  0x7c,0x08,0x04,0x04,0x78,0x38,0x44,0x44,0x44,0x38,  // no
  0x7c,0x14,0x14,0x14,0x08,0x08,0x14,0x14,0x18,0x7c,  // pq
  0x7c,0x08,0x04,0x04,0x08,0x48,0x54,0x54,0x54,0x20,  // rs
  0x04,0x3f,0x44,0x40,0x20,0x3c,0x40,0x40,0x20,0x7c,  // tu
  0x1c,0x20,0x40,0x20,0x1c,0x3c,0x40,0x30,0x40,0x3c,  // vw
  0x44,0x28,0x10,0x28,0x44,0x0c,0x50,0x50,0x50,0x3c,  // xy
  0x44,0x64,0x54,0x4c,0x44        // z
};

volatile const unsigned char bitmaps[13][8] = {
// volatile const unsigned char bitmaps[13][8] EEMEM = {
  {0xc3,0xc3,0x00,0x18,0x18,0x81,0xff,0x7e}, // smiley 3 small
  {0x3c,0x42,0x81,0x81,0xc3,0x24,0xa5,0xe7}, // Omega
  {0x00,0x04,0x06,0xff,0xff,0x06,0x04,0x00},  // Arrow
  {0x81,0x42,0x24,0x18,0x18,0x24,0x42,0x81}, // X
  {0xBD,0xA1,0xA1,0xB9,0xA1,0xA1,0xA1,0x00}, // ifi
  {0xEF,0x48,0x4B,0x49,0x4F,0x00,0x00,0x00}, // TG
  {0x38,0x7f,0xE6,0xC0,0xE6,0x7f,0x38,0x00}, // Commodore symbol
  {0x00,0x22,0x77,0x7f,0x3e,0x3e,0x1c,0x08}, // Heart
  {0x1C,0x22,0x55,0x49,0x5d,0x22,0x1c,0x00}, // face
  {0x37,0x42,0x22,0x12,0x62,0x00,0x7f,0x00}, // ST
  {0x89,0x4A,0x2c,0xF8,0x1F,0x34,0x52,0x91}, // STAR
  {0x18,0x3c,0x7e,0xdb,0xff,0x24,0x5a,0xa5}, // Space Invader
  {0x00,0x9c,0xa2,0xc5,0xc1,0xa2,0x9c,0x00} // Fish
};

const unsigned char paths[44] PROGMEM = {0x07,0x06,0x05,0x04,0x03,0x02,0x01,0x00,0x10,0x20,0x30,0x40,0x50,0x60,0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x67,0x57,0x47,0x37,0x27,0x17,
0x04,0x03,0x12,0x21,0x30,0x40,0x51,0x62,0x73,0x74,0x65,0x56,0x47,0x37,0x26,0x15}; // circle, len 16, offset 28



//***********************************************************************************************************************
void font_getpath (unsigned char path, unsigned char *destination, int length)
{
  int i;
  int offset = 0;
  
  if (path == 1)
    offset=28;
  
  for (i = 0; i < length; i++)
    destination[i] = pgm_read_byte(&paths[i+offset]);
}



//***********************************************************************************************************************
void effect_pathmove (unsigned char *path, int length)
{
  int i,z;
  unsigned char state;
  
  for (i=(length-1);i>=1;i--)
  {
    for (z=0;z<8;z++)
    {
    
      state = getvoxel(((path[(i-1)]>>4) & 0x0f), (path[(i-1)] & 0x0f), z);
      altervoxel(((path[i]>>4) & 0x0f), (path[i] & 0x0f), z, state);
    }
  }
  for (i=0;i<8;i++)
    clrvoxel(((path[0]>>4) & 0x0f), (path[0] & 0x0f),i);
}



//***********************************************************************************************************************
void effect_rand_patharound (int iterations, int delay)
{
  int z, dz, i;
  z = 4;
  unsigned char path[28];
  
  font_getpath(0,path,28);
  
  for (i = 0; i < iterations; i++)
  {
    dz = ((rand()%3)-1);
    z += dz;
    
    if (z>7)
      z = 7;
      
    if (z<0)
      z = 0;
    
    effect_pathmove(path, 28);
    setvoxel(0,7,z);
    delay_ms(delay);
  }
}



//***********************************************************************************************************************
void display()
{ 
  for(byte y = 0 ; y < CUBE_SIZE ; y++)
  {
    byte b = 0;

    for(byte x = 0 ; x < CUBE_SIZE ; x++)
    {
      //form data byte
      b = b << 1;

      if (getvoxel(x,y,current_layer)==1)
      {
        b |= 1;
        
      }
    }
    
    value[y] = b;    
  }

  maxTransferLEDCube(CUBE_SIZE - current_layer);

  current_layer++;
  
  if (current_layer == 8)
    current_layer = 0;
}



//***********************************************************************************************************************
void maxTransferAll(uint8_t address, uint8_t value)
{
  digitalWrite(SPI_CS, LOW); 

    for ( int c=1; c<= CUBE_SIZE;c++) {
        SPI.transfer(address);
        SPI.transfer(value);
    }

  digitalWrite(SPI_CS, HIGH); 
}



//**********************************************************************************************************************************************************  
void maxTransferOne(uint8_t whichMax, uint8_t address, uint8_t value)
{
  byte noop_reg = 0x00;    //max72xx No op register
  byte noop_value = 0x00;  //value

  digitalWrite(SPI_CS, LOW); 

  for (int i=CUBE_SIZE; i>0; i--)   // Loop through our number of Max72xx ICs 
  {
    if (i==whichMax)
    {
      SPI.transfer(address);
      SPI.transfer(value);
    }
    else
    {
      SPI.transfer(noop_reg);
      SPI.transfer(noop_value);
    }
  }

  digitalWrite(SPI_CS, HIGH);
}



//***********************************************************************************************************************
void maxTransferLEDCube(uint8_t address)
{
  digitalWrite(SPI_CS, LOW); 

  for (int i=0; i<CUBE_SIZE; i++)   // Loop through our number of Max72xx ICs 
  {
      SPI.transfer(address);
      SPI.transfer(value[CUBE_SIZE-i-1]);
  }

  digitalWrite(SPI_CS, HIGH);
}
