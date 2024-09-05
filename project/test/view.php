<form method=post action=view.php>
	<input type=radio name=order value=asc checked>오름차순</input><br>
	<input type=radio name=order value=desc>내림차순</input><br>
	<input type=submit value=확인>
</form>

<?php
    $conn = mysqli_connect('localhost', 'root', '', 'exam_db'); // *
    // exam_data테이블에서 최대 25건 조회한다
    $query = "select * from exam_data order by record_num ".$_POST['order']." limit 25"; // *
	// order 값을 받아 오름차순, 내름차순 결정
    $result = mysqli_query($conn, $query);

    // 
    echo "<table border=1 width=500>";
	echo "<tr><td>key값</td><td>온도(temp)</td><td>습도(temp)</td></tr>";
    // 데이터베이스에서 가져온 결과를 한 레코드씩 출력한다
    $i = 0;
	while($row = mysqli_fetch_assoc($result)) {
		$mylabel[$i] = $row['record_num'];
		$mytemp[$i] = $row['temp_data'];
		$myhumi[$i] = $row['humi_data'];
		if($i == 0){
			$mytemp2 = $row['temp_data'];
			$myhumi2 = $row['humi_data']; 
		}
		$i++;

        // $row : 현재 주목된 레코드 
        // $row['num'] $row['temp'] $row['humi'] 
        echo "<tr><td>".$row['record_num'] ."</td><td>".$row['temp_data'] ."</td><td>".$row['humi_data'] ."</td></tr>"; // *
    }
    echo "</table>";

	// 실시간 그래프 불러오기
    echo "<table border=1 width=600>";
	echo "<tr><td colspan=2>";
	include 'graph.php';
	echo "</td></tr>";
	echo "</table>";
?>