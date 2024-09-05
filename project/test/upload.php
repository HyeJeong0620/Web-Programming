<?php
    // ESP32가 GET방식으로 넘기는 변수명
    //PHP변수   //ESP32가 넘기는 변수명
	$temp = $_GET['t']; // *
	$humi = $_GET['h']; // *
	$date = date("Y-m-d H:i:s",time());

	// MYSQL에 연결한다
	$conn = mysqli_connect('localhost', 'root', '', 'exam_db'); // *

    // insert into 테이블이름(필드명...) values(값...);
    // 필드명에 key값은 제외
	$query = "insert into exam_data(temp_data, humi_data) values(".$temp.", ".$humi.");"; // *
    
    // 작성한 쿼리를 실행한다
	$result = mysqli_query($conn, $query);
	// 실행결과 확인
	if($result){
		echo "성공";
 	}else {
		echo "실패";
  	}
?>