<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".butceler (kalem,adet_gun,birim_fiyati,birim_maliyet,toplam_maliyet,proje_id,teklif)   values (?,?,?,?,?,?,?)";
$statement = $mysqli->prepare($query);


$results =  $statement->bind_param('sssssis', $_REQUEST['kalem'],$_REQUEST['adet_gun'],$_REQUEST['birim_fiyati'],$_REQUEST['birim_maliyet'],$_REQUEST['toplam_maliyet'],$_REQUEST['proje_id'],$_REQUEST['teklif']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

