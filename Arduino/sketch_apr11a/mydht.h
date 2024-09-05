class MYDHT{
  public:
    MYDHT(int pin, int type){
      mypin = pin;
      mytype = type;
    }
    void begin(){
      Serial.println("begin이 호출 되었습니다");
      Serial.print("현재 연결된 핀 번호=");
      Serial.print(mypin);
      Serial.print("이고 타입은 ");
      Serial.println(mytype);
    }
    float readHumidity(){
      return humi;
    }
    float readTemperature(){
      return temp;
    }
    float temp = 11.22;
    float humi = 22.33;
  private:
    int mypin;
    int mytype;
};
