void setup() {
  Serial.begin(9600);

  // 문자열은 char 배열이다
  char text1[] = "나는 문자열1이다"; //123
  char *text2 = "나는 문자열2이다"; //123
  String serverURL = "<html><input type=text><input type=button></html>"; 
  int num = 123;

  int first_pos = serverURL.indexOf("<input type=b"); // 시작위치
  int second_pos = serverURL.indexOf("</html>");

  String output = serverURL.substring(first_pos, second_pos); // (이상, 미만)
  
  serverURL = serverURL + num;

  Serial.print("첫번째위치=");
  Serial.println(first_pos);
  Serial.print("두번째위치=");
  Serial.println(second_pos);
  Serial.print("결과=");
  Serial.println(output);

  //int num = 10;
  //PC에서 아두이노로 전송
  //Serial.print("값은="); // CR, 개행없이 전송
  //Serial.println(num); // CR+LF 개행있게 전송
  // Serial.write("문자열");
}

void loop() {
  
}
