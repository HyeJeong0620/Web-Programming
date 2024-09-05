#include "mydht.h"

class TEST{
  public:
    TEST(HardwareSerial *myserial){
      _myserial = myserial;
      _myserial->begin(115200);
    }
    void testprint(){
      _myserial->println("testprint호출");
    }
  private:
    HardwareSerial *_myserial;
};

TEST tt(&Serial);

MYDHT dht(16,2);
void setup() {
  Serial.begin(115200);
  dht.begin();
  tt.testprint();
}

void loop() {
  // put your main code here, to run repeatedly:
  float temp = dht.readTemperature();
  float humi = dht.readHumidity();
  Serial.print(F("Humidity: "));
  Serial.print(humi);
  Serial.print(F("%  Temperature: "));
  Serial.print(temp);
  Serial.println(F("°C "));
  delay(2000);
}
