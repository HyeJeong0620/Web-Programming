/*
 * 17번핀에 연결된 버튼을 누르면 10초부터 다운카운트 되어서 시리얼모니터에 0.1초 간격으로 출력한다
 * 이때 17번핀을 한번더 누르면 카운트가 멈춘다
 * 다시한번더 누르면 10초부터 다시 다운카운트한다
 * 
 * 0초에 도달하면 16번에 연결된 LED가 5초간 켜졌다가 꺼지도록 하시오!
 * 버튼은 50ms 디바운스 처리할 것
 */
unsigned long t1 = 0;//0.1초 간격으로 출력
unsigned long t2 = 0;//millis 반환하는 값이기 때문
unsigned long t3 = 0;
bool old_btn = HIGH;
bool sw = false;
float cnt = 10;
void setup() {
  Serial.begin(115200);
  pinMode(16,OUTPUT);
  pinMode(17,INPUT);
  
}

void loop() {
  if(digitalRead(16) == HIGH){
    if(millis() -t2>5000){
      digitalWrite(16,LOW);
    }
  }
  if(millis() - t1>100){
    t1 = millis();
    if(sw){
      Serial.print("다운카운트중=");
      Serial.println(cnt);
      cnt -= 0.1;
      if(cnt<=0){
        Serial.println("LED 작동");
        digitalWrite(16,HIGH);
        t2 = millis();
        sw = false;
      }
    }else{
      //Serial.println("중지");
      cnt = 10;
    }
  }
  
  bool now_btn = digitalRead(17);//n번째
  if(old_btn == HIGH && now_btn == LOW){
    t3 = millis();
  }else if(old_btn == LOW && now_btn == HIGH){
    if(millis() - t3>50){
      sw = !sw;
    }
  }
  old_btn = now_btn;
  
}
