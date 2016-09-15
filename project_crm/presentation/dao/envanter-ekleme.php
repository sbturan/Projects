<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".envanter (seri_no,cinsi,adi,MM,adet,giris_tarihi) values (?,?,?,?,?,?)";
$statement = $mysqli->prepare($query);


$results =  $statement->bind_param('ssssss', $_REQUEST['seri_no'],$_REQUEST['cinsi'],$_REQUEST['adi'],$_REQUEST['MM'],
	$_REQUEST['adet'],$_REQUEST['giris_tarihi']);

$statement->execute();
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

