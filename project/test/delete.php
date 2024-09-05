<?php
	// MYSQL에 연결한다
	$conn = mysqli_connect('localhost', 'root', '', 'exam_db'); // *
	$query = "TRUNCATE TABLE exam_db.exam_data;"; // *
    
    // 작성한 쿼리를 실행한다
	$result = mysqli_query($conn, $query);
	// 실행결과 확인
	if($result){
		echo "성공";
 	}else {
		echo "실패";
  	}
?>