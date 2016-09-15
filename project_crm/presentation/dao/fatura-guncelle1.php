<?php 
require_once("../config/config.php");

//$mysqli = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="Update ".DB_SCHEMA_NAME.".faturalar set fatura_no=?,fatura_tarihi=?,fatura_tutar=?,duzenlenme_tarihi=?,kdvtutar=?,odenme_tarihi=? where fatura_no=? and proje_id = ?";

$statement = $mysqli->prepare($query);



//bind parameters for markers, where (s = string, i = integer, d = double,  b = blob)
$results =  $statement->bind_param('sssssssi', $_REQUEST['fid'],$_REQUEST['faturatarihi'],$_REQUEST['faturatutar'],$_REQUEST['duzenlemetarihi'],$_REQUEST['kdv_tutar'],$_REQUEST['odemetarih'], $_REQUEST['fatura_no'],$_REQUEST['pid'] );
$statement->execute();
if($results){
	
	$mysqli1 = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
	if (!$mysqli1 ) {
	die("Connection failed: " . mysqli_connect_error());
	}
	$mysqli1->set_charset("utf8");
	$query1="Update ".DB_SCHEMA_NAME.".odemeler set fatura_no=? where fatura_no=? and proje_id = ?";
	$statement1 = $mysqli1->prepare($query1);
	$results1 =  $statement1->bind_param('ssi', $_REQUEST['fid'], $_REQUEST['fatura_no'],$_REQUEST['pid'] );
	$statement1->execute();
   if($results1){
     echo 'success'; 
	 }else{
	   error_log('Error : ('. $mysqli1->errno .') '. $mysqli1->error, 0);
      echo 'Error : ('. $mysqli1->errno .') '. $mysqli1->error;
    }
  
	
	
    
}else{
	 error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
    echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}


?>