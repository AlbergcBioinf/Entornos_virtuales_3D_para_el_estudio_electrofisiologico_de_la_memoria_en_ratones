#include <Stepper.h>

const int pinCLK = 2;      // Rotary encoder pin A
const int pinDT = 3;      // Rotary encoder pin B
const int stepsPerRevolution = 512;
const int motSpeed = 15;
const int dt = 1000;

int encoderPos = 0;
int lastEncoderPos = 0;

Stepper myStepper(stepsPerRevolution, 8, 10, 9, 11);

void setup() {
  pinMode(pinCLK, INPUT_PULLUP);
  pinMode(pinDT, INPUT_PULLUP);
  Serial.begin(9600);
  myStepper.setSpeed(motSpeed);
}

void loop() {
  int readingCLK = digitalRead(pinCLK);
  int readingDT = digitalRead(pinDT);
  
  if (readingCLK != lastEncoderPos) {
    if (readingDT != readingCLK) {
      encoderPos++;
    } else {
      encoderPos--;
    }
    Serial.println(encoderPos);
  }
  
  lastEncoderPos = readingCLK;

  if (Serial.available() > 0) {
    int command = Serial.read();
    
    if (command == '1') {
      myStepper.step(stepsPerRevolution);
      delay(dt);
    }
    else if (command == '0') {
      myStepper.step(-stepsPerRevolution);
      delay(dt);
    }
  }
}


