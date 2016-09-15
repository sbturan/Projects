
<!DOCTYPE html>
<html>
<head>

<meta charset='utf-8' />
<link href='../fullcalendar.css' rel='stylesheet' />
<link href='../fullcalendar.print.css' rel='stylesheet' media='print' />
<script src='../lib/moment.min.js'></script>
<script src='../lib/jquery.min.js'></script>
<script src='../fullcalendar.min.js'></script>
<script src='../lang-all.js'></script>
<script>

	$(document).ready(function() {

		$('#calendar').fullCalendar({
			header: {
					left: 'prev,next today',
					center: 'title',
					right: 'month,agendaWeek,agendaDay'
				},

			
			
			lang: 'tr',
			height: 400,
			buttonIcons: false, // show the prev/next text
			weekNumbers: true,
			editable: false,
			//eventLimit: true, // allow "more" link when too many events
			
			events: [
			 <?php 
                   
              // require_once $_SERVER['DOCUMENT_ROOT'] ."/config/config.php";
                 //require_once $_SERVER['DOCUMENT_ROOT'] . "/config/config.php"; 
				 require_once $_SERVER['DOCUMENT_ROOT']."/config/config.php";
				$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
		 		if (!$conn) {
				die("Connection failed: " . mysqli_connect_error());
			}

			$conn ->set_charset("utf8");
			$sqlKategori = "SELECT *
			FROM ".DB_SCHEMA_NAME.".projeler;";

			$resultKategori = $conn->query($sqlKategori);
            $dizi = array("yellow", "blue", "orange", "green", "pink");
			$i =0;
			if ($resultKategori->num_rows > 0) {
              
				while($row = $resultKategori->fetch_assoc()) {
					
                    echo "{";
					echo "title: '".$row['is_adi']."',";
					$sdate=substr($row['baslangic_tarih'],0,10);
					$sdate=str_replace(".","-",$sdate);
					$stime=substr($row['baslangic_tarih'],-5);
					 if($i == 5){
					   $i = 0;
					 }	
                    echo "color: '".$dizi[$i]."',";
					 $i=$i+1;
                    echo "start: '".$sdate."T".$stime.":00" ."',";
                    $edate=substr($row['bitis_tarihi'],0,10);
					$edate=str_replace("/","-",$edate);
					$etime=substr($row['bitis_tarihi'],-5);

                    echo "end: '".$edate."T".$etime.":00"."',";
                    echo "}," ;
				}

				} else {
					echo "0 results";
				}


			    ?> 

				
				{
					title: 'Click for Google',
					url: 'http://google.com/',
					start: '1996-02-28'
				}
			]
		});
		
	});

</script>
<style>

	body {
		margin: 40px 10px;
		padding: 0;
		font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
		font-size: 14px;
	}

	#calendar {
		max-width: 900px;
		margin: 0 auto;
	}

</style>
</head>
<body>

	<div id='calendar'></div>

</body>
</html>
