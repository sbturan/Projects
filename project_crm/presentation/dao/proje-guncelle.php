<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$id=$_REQUEST['id'];
$query="update  ".DB_SCHEMA_NAME.".projeler set 
	firma_id=?,is_adi=?,butce=?,baslangic_tarih=?,bitis_tarihi=?,isin_lokasyonu=?,proje_sorumlusu=?,sahip=?,kaynak=? where proje_id=".$id;
$statement = $mysqli->prepare($query);


$results =  $statement->bind_param('isssssiis', $_REQUEST['firma_id'],$_REQUEST['is_ad'],$_REQUEST['butce'],
	$_REQUEST['isbastarih'],$_REQUEST['isbittarih'],$_REQUEST['is_lokasyon'],$_REQUEST['sorumlu'],$_REQUEST['sahip'],$_REQUEST['kaynak']);


$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>