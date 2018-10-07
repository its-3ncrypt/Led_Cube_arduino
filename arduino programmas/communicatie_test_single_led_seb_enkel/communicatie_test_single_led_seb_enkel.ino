char led_response = 0;
int ledPin = 13;
int dela;

void setup() {
  // initialize serial:
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
  digitalWrite(ledPin, LOW);

}

void loop() {
if(Serial.available() > 0){
 led_response = Serial.read();
       digitalWrite(ledPin, HIGH);
        if(led_response == '0'){
        digitalWrite(ledPin, LOW);
        dela = 1000;
        Serial.println("0000");
        }
         if(led_response == '1'){
        dela = 1000;
        Serial.println("1000");
        }
        if(led_response == '2'){
        dela = 2000;
        Serial.println("2000");
        }
        if(led_response == '3'){
        dela = 3000;
        Serial.println("3000");
        }
        if(led_response > '3'){
        dela = 4000;
        Serial.println("4000");
        }
        
      }
    delay(dela);
    digitalWrite(ledPin, LOW);
    delay(dela);
    Serial.println(led_response);
}
